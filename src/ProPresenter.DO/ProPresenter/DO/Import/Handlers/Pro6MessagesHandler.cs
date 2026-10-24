using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Xml;
using Pro.Common.Extensions;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.DO.Application;
using Pro.DO.Utility;
using Pro.Entity.Persistence;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Migration.RVData;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class Pro6MessagesHandler : IRequestHandler
{
	private readonly IFileCreator _fileCreator;

	private readonly ICollectionStorage _collectionStorage;

	public Pro6MessagesHandler(IFileCreator fileCreator, ICollectionStorage collectionStorage)
	{
		_fileCreator = fileCreator;
		_collectionStorage = collectionStorage;
	}

	public bool CanHandle(IImportRequest request)
	{
		string text = (request as FileImportRequest)?.Filename;
		if (!text.NullableIsNullOrWhiteSpace() && text.IsPro6DataFile())
		{
			return Path.GetFileNameWithoutExtension(text).Equals("messageData");
		}
		return false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, requests, updateStatus, handlingComplete);
		return default(ValueTask);
	}

	private void Handle(ImportProcess process, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete)
	{
		foreach (FileImportRequest item in requests.Cast<FileImportRequest>())
		{
			if (process.ImportCanceled)
			{
				break;
			}
			updateStatus(item, ImportStatus.Migrating);
			try
			{
				string tempFile = ImportHelper.GetTempFile(string.Empty);
				if (!XHelper.TryReadFile<RVAnnouncementDocument>(item.FullName, out RVAnnouncementDocument messagesDocument))
				{
					continue;
				}
				process.Dispatcher?.InvokeAsync(delegate
				{
					MessagesPreferences.Settings.DefaultTokens = (from t in messagesDocument?.Fields?.Where((RVPlaceholder f) => f.PlaceholderType?.Equals("Normal") ?? false)
						select new MessageTextData(t.FieldName ?? string.Empty, t.FieldValue ?? string.Empty)).ToList() ?? new List<MessageTextData>();
				});
				MessageDocument messageDocument = new MessageDocument
				{
					ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize()
				};
				if (messagesDocument?.Messages != null)
				{
					foreach (RVAnnouncement message2 in messagesDocument.Messages)
					{
						string messageText = ToProtoMessageText(message2.MessageBody ?? string.Empty);
						double timeToRemove;
						Pro.SerializationInterop.RVProtoData.Message.Types.ClearType clearType = ToProtoMessageClearType(message2.Duration ?? string.Empty, out timeToRemove);
						Pro.SerializationInterop.RVProtoData.Message message = new Pro.SerializationInterop.RVProtoData.Message
						{
							ClearType = clearType,
							TimeToRemove = timeToRemove,
							Title = (message2.MessageTitle ?? string.Empty),
							Uuid = message2.MessageId.ToUUID(),
							VisibleOnNetwork = message2.VisibleOnNetwork,
							MessageText = messageText
						};
						if (!Guid.TryParse(message2.MessageTemplate?.UUID, out var result) && DataVault.Themes != null)
						{
							result = DataVault.Themes.DefaultTheme[0].Slide.ID;
						}
						message.Template = new TemplateIdentification
						{
							SlideUuid = result.ToUUID(),
							SlideName = string.Empty
						};
						if (message2.Placeholders != null)
						{
							foreach (RVPlaceholder placeholder in message2.Placeholders)
							{
								message.Tokens.Add(ToProtoToken(placeholder));
								message.TokenValues.Add(ToProtoTokenValue(placeholder));
							}
						}
						messageDocument.Messages.Add(message);
					}
				}
				if ((bool)FileHelper.WaitForFileAccess(tempFile, enforceFileExists: false, null))
				{
					ProtoHelper.WriteFile(tempFile, messageDocument);
				}
				item.ChangeFile(tempFile);
				item.ChangeName("Messages");
				handlingComplete(item, RequestHandlerType.Unknown, new FileImportResult(item.FullName, CommonPaths.Configuration, _fileCreator, _collectionStorage));
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
		}
	}

	private static Pro.SerializationInterop.RVProtoData.Message.Types.ClearType ToProtoMessageClearType(string rvMessageDuration, out double timeToRemove)
	{
		timeToRemove = 0.0;
		if (rvMessageDuration.Equals("UntilIRemove", StringComparison.OrdinalIgnoreCase))
		{
			return Pro.SerializationInterop.RVProtoData.Message.Types.ClearType.Manual;
		}
		if (rvMessageDuration.Contains("Secs"))
		{
			if (rvMessageDuration.Equals("FiveSecs", StringComparison.OrdinalIgnoreCase))
			{
				timeToRemove = 5.0;
			}
			else if (rvMessageDuration.Equals("TenSecs", StringComparison.OrdinalIgnoreCase))
			{
				timeToRemove = 10.0;
			}
			else if (rvMessageDuration.Equals("FifteenSecs", StringComparison.OrdinalIgnoreCase))
			{
				timeToRemove = 15.0;
			}
			else if (rvMessageDuration.Equals("TwentySecs", StringComparison.OrdinalIgnoreCase))
			{
				timeToRemove = 20.0;
			}
			else if (rvMessageDuration.Equals("ThirtySecs", StringComparison.OrdinalIgnoreCase))
			{
				timeToRemove = 30.0;
			}
			else if (rvMessageDuration.Equals("FortyFiveSecs", StringComparison.OrdinalIgnoreCase))
			{
				timeToRemove = 45.0;
			}
			return Pro.SerializationInterop.RVProtoData.Message.Types.ClearType.AfterTime;
		}
		if (rvMessageDuration.Equals("OneMinute", StringComparison.OrdinalIgnoreCase))
		{
			timeToRemove = 60.0;
			return Pro.SerializationInterop.RVProtoData.Message.Types.ClearType.AfterTime;
		}
		return Pro.SerializationInterop.RVProtoData.Message.Types.ClearType.AfterTimers;
	}

	private static string ToProtoMessageText(string rvMessageBody)
	{
		try
		{
			FlowDocument obj = (FlowDocument)XamlReader.Load(new XmlTextReader(new StringReader(rvMessageBody.Replace("clr-namespace:ProPresenter.UI.Plugin;assembly=ProPresenter.UI.Plugin", "clr-namespace:ProPresenter.DO.Migration.RVData;assembly=ProPresenter.DO"))));
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Inline item in obj.Blocks.OfType<Paragraph>().AsEnumerable().SelectMany((Paragraph p) => p.Inlines))
			{
				if (item is Run run)
				{
					stringBuilder.Append(run.Text);
				}
				else if (item is InlineUIContainer { Child: RVPlaceholderItem child })
				{
					stringBuilder.AppendMany("${", child.ObjectId.ToString(), "}");
				}
			}
			return stringBuilder.ToString();
		}
		catch
		{
			return string.Empty;
		}
	}

	private Pro.SerializationInterop.RVProtoData.Message.Types.Token ToProtoToken(RVPlaceholder placeHolder)
	{
		Pro.SerializationInterop.RVProtoData.Message.Types.Token token = new Pro.SerializationInterop.RVProtoData.Message.Types.Token
		{
			Uuid = placeHolder.FieldId.ToUUID()
		};
		string? placeholderType = placeHolder.PlaceholderType;
		if (placeholderType != null && placeholderType.Equals("normal", StringComparison.OrdinalIgnoreCase))
		{
			token.Text = new Pro.SerializationInterop.RVProtoData.Message.Types.Token.Types.TokenTypeText
			{
				Name = placeHolder.FieldName
			};
		}
		else
		{
			string? placeholderType2 = placeHolder.PlaceholderType;
			if (placeholderType2 != null && placeholderType2.Equals("timer", StringComparison.OrdinalIgnoreCase))
			{
				TimerData timerData = DataVault.TimerDocument?.Timers.Where((TimerData a) => a.Source != null).FirstOrDefault((TimerData t) => t.Name.Equals(placeHolder.FieldName, StringComparison.OrdinalIgnoreCase));
				token.Timer = new Pro.SerializationInterop.RVProtoData.Message.Types.Token.Types.TokenTypeTimer
				{
					Name = placeHolder.FieldName,
					TimerUuid = (timerData?.ID ?? Guid.Empty).ToUUID()
				};
			}
			else
			{
				string? placeholderType3 = placeHolder.PlaceholderType;
				if (placeholderType3 != null && placeholderType3.Equals("clock", StringComparison.OrdinalIgnoreCase))
				{
					token.Clock = new Pro.SerializationInterop.RVProtoData.Message.Types.Token.Types.TokenTypeClock();
				}
			}
		}
		return token;
	}

	private Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue ToProtoTokenValue(RVPlaceholder placeHolder)
	{
		Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue = new Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue
		{
			TokenId = placeHolder.FieldId.ToUUID()
		};
		string? placeholderType = placeHolder.PlaceholderType;
		if (placeholderType != null && placeholderType.Equals("normal", StringComparison.OrdinalIgnoreCase))
		{
			tokenValue.Text = new Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Types.TokenValueText
			{
				Value = placeHolder.FieldValue
			};
		}
		else
		{
			string? placeholderType2 = placeHolder.PlaceholderType;
			if (placeholderType2 != null && placeholderType2.Equals("timer", StringComparison.OrdinalIgnoreCase))
			{
				tokenValue.Timer = new Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Types.TokenValueTimer();
				RVTimer rVTimer = new RVTimer
				{
					EndTime = placeHolder.EndTime,
					FieldId = placeHolder.FieldId,
					FieldName = placeHolder.FieldName,
					Meridiem = placeHolder.Meridiem,
					OverRun = placeHolder.OverRun,
					TimeFormat = placeHolder.TimeFormat,
					TimerType = placeHolder.TimerType,
					TimerValueDictionary = placeHolder.TimerValueDictionary
				};
				TimerData timerData = rVTimer.TimerType?.ToTimerData();
				timerData?.RVDeserialize(rVTimer);
				tokenValue.Timer.Configuration = timerData?.Source?.Serialize();
				tokenValue.Timer.Format = ToProtoTimerFormat(rVTimer.TimeFormat ?? string.Empty);
			}
			else
			{
				string? placeholderType3 = placeHolder.PlaceholderType;
				if (placeholderType3 != null && placeholderType3.Equals("clock", StringComparison.OrdinalIgnoreCase))
				{
					tokenValue.Clock = new Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Types.TokenValueClock
					{
						Format = new Clock.Types.Format
						{
							TimeFormat = Clock.Types.Format.Types.DateFormatterStyle.Long,
							DateType = Clock.Types.Format.Types.DateFormatterStyle.Long,
							MilitaryTimeEnabled = false
						}
					};
				}
			}
		}
		return tokenValue;
	}

	private Pro.SerializationInterop.RVProtoData.Timer.Types.Format ToProtoTimerFormat(string timeFormat)
	{
		Pro.SerializationInterop.RVProtoData.Timer.Types.Format format = new Pro.SerializationInterop.RVProtoData.Timer.Types.Format
		{
			Hour = Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Long,
			Minute = Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Long,
			Second = Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Long,
			Millisecond = Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Long,
			Is24HourTime = false
		};
		string[] array = ((!string.IsNullOrWhiteSpace(timeFormat)) ? timeFormat.Split(':') : new string[0]);
		if (array.Length == 3)
		{
			if (array[0].Equals("h", StringComparison.OrdinalIgnoreCase))
			{
				format.Hour = Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Short;
			}
			else if (array[0].Equals("hh", StringComparison.OrdinalIgnoreCase))
			{
				format.Hour = Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Long;
			}
			if (array[1].Equals("m", StringComparison.OrdinalIgnoreCase))
			{
				format.Minute = Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Short;
			}
			else if (array[1].Equals("mm", StringComparison.OrdinalIgnoreCase))
			{
				format.Minute = Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Long;
			}
			if (array[2].Equals("s", StringComparison.OrdinalIgnoreCase))
			{
				format.Second = Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Short;
			}
			else if (array[2].Equals("ss", StringComparison.OrdinalIgnoreCase))
			{
				format.Second = Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Long;
			}
			format.Millisecond = Pro.SerializationInterop.RVProtoData.Timer.Types.Format.Types.Style.Long;
			format.Is24HourTime = false;
		}
		return format;
	}
}
