using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Threading.Tasks;
using System.Web;
using Pro.Common.Collections;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.DO.Application;
using Pro.Entity.Persistence;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.CCLI;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Settings;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import.Handlers;

internal class Pro6CCLITemplateHandler : IRequestHandler
{
	private readonly IFileCreator _fileCreator;

	private readonly ICollectionStorage _collectionStorage;

	public Pro6CCLITemplateHandler(IFileCreator fileCreator, ICollectionStorage collectionStorage)
	{
		_fileCreator = fileCreator;
		_collectionStorage = collectionStorage;
	}

	public bool CanHandle(IImportRequest request)
	{
		string text = (request as FileImportRequest)?.Filename;
		if (!text.NullableIsNullOrWhiteSpace() && text.IsPro6DataFile())
		{
			return Path.GetFileNameWithoutExtension(text).Equals("CCLI");
		}
		return false;
	}

	public ValueTask HandleAsync(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
	{
		Handle(process, proCore, requests, updateStatus, handlingComplete, addRequest);
		return default(ValueTask);
	}

	[GeneratedRegex("(CopyrightTextTemplate=\"(.+)\")")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private Regex CopyRightTextRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CopyRightTextRegex_3.Instance;
	}

	[GeneratedRegex("\\[!PLACEHOLDER(.*?)\\]")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private Regex PlaceholderRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__PlaceholderRegex_4.Instance;
	}

	private void Handle(ImportProcess process, IProCoreInstance? proCore, IImportRequest[] requests, UpdateStatusDelegate updateStatus, HandlingCompleteDelegate handlingComplete, AddRequestDelegate addRequest)
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
				if (!FileHelper.WaitForFileAccess(item.FullName, enforceFileExists: false, null))
				{
					continue;
				}
				string input = File.ReadAllText(item.FullName);
				Regex regex = CopyRightTextRegex();
				Regex regex2 = PlaceholderRegex();
				Match match = regex.Match(input);
				if (match.Success && match.Groups.Count == 3)
				{
					string text = match.Groups[2].Value;
					text = HttpUtility.HtmlDecode(text);
					int num = 0;
					List<CCLIToken> tokens = new List<CCLIToken>();
					foreach (Match item2 in from m in regex2.Matches(text).OfType<Match>()
						where m.Success
						select m)
					{
						string value = item2.Groups[1].Value;
						CCLIToken cCLIToken = null;
						int index = item2.Index - num;
						if (value.Contains("Title"))
						{
							cCLIToken = new CCLIToken(CCLITokenType.Title);
						}
						else if (value.Contains("Author"))
						{
							cCLIToken = new CCLIToken(CCLITokenType.Author);
						}
						else if (value.Contains("Copyright Year"))
						{
							cCLIToken = new CCLIToken(CCLITokenType.CopyrightYear);
						}
						else if (value.Contains("Publisher"))
						{
							cCLIToken = new CCLIToken(CCLITokenType.Publisher);
						}
						else if (value.Contains("License Number"))
						{
							cCLIToken = new CCLIToken(CCLITokenType.LicenseNumber);
						}
						else if (value.Contains("Artist"))
						{
							cCLIToken = new CCLIToken(CCLITokenType.Artist);
						}
						else if (value.Contains("Song Number"))
						{
							cCLIToken = new CCLIToken(CCLITokenType.SongNumber);
						}
						if (cCLIToken != null)
						{
							cCLIToken.Index = index;
							tokens.Add(cCLIToken);
						}
						num += item2.ToString().Length;
					}
					process.Dispatcher?.InvokeAsync(delegate
					{
						General.Settings.CCLILayoutData.Text = PlaceholderRegex().Replace(text, "");
						General.Settings.CCLILayoutData.Tokens.Clear();
						General.Settings.CCLILayoutData.Tokens.AddRange(tokens);
					});
				}
				input = CopyRightTextRegex().Replace(input, "");
				input = input.Replace("RVCCLIPresentation", "RVPresentationDocument");
				if (!FileHelper.WaitForFileAccess(tempFile, enforceFileExists: false, null))
				{
					continue;
				}
				File.WriteAllText(tempFile, input);
				string tempFile2 = ImportHelper.GetTempFile(string.Empty);
				if (proCore == null || proCore.MigrateDocument(tempFile, tempFile2, ProMigrationType.Presentation) != 0)
				{
					throw new Exception("Failed to migrate Pro6 to Pro7 document");
				}
				if ((bool)FileHelper.WaitForFileAccess(tempFile2, enforceFileExists: false, null) && (bool)ProtoHelper.TryReadFile<Pro.SerializationInterop.RVProtoData.Presentation>(tempFile2, out Pro.SerializationInterop.RVProtoData.Presentation data))
				{
					Pro.SerializationInterop.RVProtoData.Slide slide = (from a in data?.Cues.SelectMany((Cue c) => c.Actions)
						select a.Slide into s
						select s.Presentation into p
						select p.BaseSlide).FirstOrDefault();
					(slide?.Elements.LastOrDefault((Pro.SerializationInterop.RVProtoData.Slide.Types.Element e) => e.Element_.Text != null))?.DataLinks.Add(new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink
					{
						CcliText = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CCLIText()
					});
					CCLIDocument data2 = new CCLIDocument
					{
						ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize(),
						CcliLicense = DataVault.CCLIPresentation?.License,
						DisplayType = DataVault.CCLIPresentation.DisplayType.ToProtoDisplayType(),
						EnableCcliDisplay = DataVault.CCLIPresentation.Display,
						Template = new Template.Types.Slide
						{
							BaseSlide = slide,
							Name = string.Empty
						}
					};
					if ((bool)FileHelper.WaitForFileAccess(tempFile2, enforceFileExists: false, null))
					{
						ProtoHelper.WriteFile(tempFile2, data2);
						item.ChangeFile(tempFile2);
						item.ChangeName("CCLI");
						handlingComplete(item, RequestHandlerType.Theme, new FileImportResult(item.FullName, CommonPaths.Configuration, _fileCreator, _collectionStorage));
					}
				}
			}
			catch (Exception exception)
			{
				Log.Error(exception);
				handlingComplete(item, RequestHandlerType.Unknown, null);
			}
		}
	}
}
