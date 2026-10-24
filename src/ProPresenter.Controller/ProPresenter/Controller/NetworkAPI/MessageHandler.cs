using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.Common.ToastNotifications;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Timer;

namespace ProPresenter.Controller.NetworkAPI;

public static class MessageHandler
{
	public static NetworkAPI_v1 Handle(IAPIv1Service service, API_v1_Message_Request request)
	{
		if (request != null)
		{
			if (request.Messages != null)
			{
				return Messages(service.Messages);
			}
			API_v1_Message_Request.Types.CreateMessage createMessage = request.CreateMessage;
			if (createMessage != null)
			{
				return CreateMessage(service, createMessage.Message);
			}
			API_v1_Message_Request.Types.GetMessage getMessage = request.GetMessage;
			if (getMessage != null)
			{
				return GetMessage(service.Messages, getMessage.Id);
			}
			API_v1_Message_Request.Types.PutMessage putMessage = request.PutMessage;
			if (putMessage != null)
			{
				return PutMessage(service, putMessage.Id, putMessage.Message);
			}
			API_v1_Message_Request.Types.DeleteMessage deleteMessage = request.DeleteMessage;
			if (deleteMessage != null)
			{
				return DeleteMessage(service, deleteMessage.Id);
			}
			API_v1_Message_Request.Types.TriggerMessage triggerMessage = request.TriggerMessage;
			if (triggerMessage != null)
			{
				return TriggerMessage(service, triggerMessage);
			}
			API_v1_Message_Request.Types.ClearMessage clearMessage = request.ClearMessage;
			if (clearMessage != null)
			{
				return ClearMessage(service, clearMessage.Id);
			}
		}
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(request);
		NetworkAPI_v1 result = default(NetworkAPI_v1);
		return result;
	}

	public static NetworkAPI_v1 Messages(IEnumerable<ProPresenter.DO.Messages.Message> messsages)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/messages").MessageResponse().Messages = new API_v1_Message_Response.Types.Messages
			{
				Messages_ = { messsages.Select((ProPresenter.DO.Messages.Message m, int index) => CreateProtoMessage(m, (uint)index)) }
			};
		});
	}

	private static NetworkAPI_v1 CreateMessage(IAPIv1Service service, API_v1_Message message)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			service.Dependencies.UiDispatcher.Invoke(delegate
			{
				ProPresenter.DO.Messages.Message message2 = new ProPresenter.DO.Messages.Message(service.Dependencies.ProPresenterResourceService.Themes);
				if (UpdateMessage(message2, service.Timers, message, out Pro.SerializationInterop.RVProtoData.Message protoMessage))
				{
					message2.Deserialize(protoMessage);
					service.Messages.UndoStack.StartIgnoring();
					service.Messages.AddMessage(message2);
					service.Messages.UndoStack.StopIgnoring();
					v1.Action().MessageResponse().CreateMessage = new API_v1_Message_Response.Types.CreateMessage
					{
						Message = CreateProtoMessage(message2, (uint)(service.Messages.Count - 1))
					};
				}
				else
				{
					v1.Action().BadRequest();
				}
			});
		});
	}

	private static NetworkAPI_v1 GetMessage(IEnumerable<ProPresenter.DO.Messages.Message> messsages, string id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(messsages, id, out ItemPacket<ProPresenter.DO.Messages.Message> packet))
			{
				v1.Action().MessageResponse().GetMessage = new API_v1_Message_Response.Types.GetMessage
				{
					Message = CreateProtoMessage(packet.Item, packet.Index)
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 PutMessage(IAPIv1Service service, string id, API_v1_Message message)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(service.Messages, id, out ItemPacket<ProPresenter.DO.Messages.Message> p))
			{
				service.Dependencies.UiDispatcher.Invoke(delegate
				{
					p.Item.UndoStack?.StartIgnoring();
					if (UpdateMessage(p.Item, service.Timers, message, out Pro.SerializationInterop.RVProtoData.Message protoMessage))
					{
						p.Item.Deserialize(protoMessage);
						p.Item.NotifyThemeChanged();
						v1.Action().MessageResponse().PutMessage = new API_v1_Message_Response.Types.PutMessage
						{
							Message = CreateProtoMessage(p.Item, p.Index)
						};
					}
					else
					{
						v1.Action().BadRequest();
					}
					p.Item.UndoStack?.StopIgnoring();
				});
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static void UpdateToken(ProPresenter.DO.Messages.Message message, IEnumerable<API_v1_Message.Types.API_v1_MessageToken> tokens)
	{
		foreach (API_v1_Message.Types.API_v1_MessageToken protoToken in tokens)
		{
			MessageTokenBase messageTokenBase = message.Tokens.FirstOrDefault((MessageTokenBase t) => t.Content == protoToken.Name);
			switch (protoToken.TokenTypeCase)
			{
			case API_v1_Message.Types.API_v1_MessageToken.TokenTypeOneofCase.Text:
				if (messageTokenBase is TextToken textToken)
				{
					textToken.Text = protoToken.Text.Text;
				}
				break;
			case API_v1_Message.Types.API_v1_MessageToken.TokenTypeOneofCase.Timer:
				if (messageTokenBase is TimerToken timerToken)
				{
					UpdateTimerData(timerToken.Timer, protoToken.Timer);
				}
				break;
			case API_v1_Message.Types.API_v1_MessageToken.TokenTypeOneofCase.Clock:
				if (messageTokenBase is ClockToken clockToken)
				{
					clockToken.ClockData.Use24HourFormat = protoToken.Clock.Is24Hours;
					clockToken.ClockData.DateFormatLength = ProtoLocalClockFormat(protoToken.Clock.Date).ToFormatLength();
					clockToken.ClockData.TimeFormatLength = ProtoLocalClockFormat(protoToken.Clock.Time).ToFormatLength();
				}
				break;
			}
		}
	}

	private static bool UpdateMessage(ProPresenter.DO.Messages.Message message, TimerCollection timers, API_v1_Message protoAPIMessage, out Pro.SerializationInterop.RVProtoData.Message protoMessage)
	{
		protoMessage = message.Serialize();
		protoMessage.Tokens.Clear();
		protoMessage.TokenValues.Clear();
		protoMessage.Title = protoAPIMessage.Id.Name;
		protoMessage.Template = new TemplateIdentification
		{
			SlideUuid = new UUID
			{
				String = protoAPIMessage.Theme.Uuid
			},
			SlideName = protoAPIMessage.Theme.Name
		};
		string text = protoAPIMessage.Message;
		IEnumerable<API_v1_Message.Types.API_v1_MessageToken> enumerable = (from Match m in TokenRegex().Matches(text)
			where m.Success
			select protoAPIMessage.Tokens.FirstOrDefault((API_v1_Message.Types.API_v1_MessageToken t) => t.Name == m.Groups[1].Value)).NonNull();
		HashSet<Guid> hashSet = new HashSet<Guid>();
		foreach (API_v1_Message.Types.API_v1_MessageToken item in enumerable)
		{
			if (!Guid.TryParse(item.Uuid, out var result) || !hashSet.Add(result))
			{
				result = Guid.NewGuid();
				hashSet.Add(result);
			}
			Pro.SerializationInterop.RVProtoData.Message.Types.Token token = new Pro.SerializationInterop.RVProtoData.Message.Types.Token
			{
				Uuid = result.ToUUID()
			};
			Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue = new Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue
			{
				TokenId = token.Uuid,
				TokenName = item.Name
			};
			switch (item.TokenTypeCase)
			{
			case API_v1_Message.Types.API_v1_MessageToken.TokenTypeOneofCase.Text:
				token.Text = new Pro.SerializationInterop.RVProtoData.Message.Types.Token.Types.TokenTypeText
				{
					Name = item.Name
				};
				tokenValue.Text = new Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Types.TokenValueText
				{
					Value = item.Text.Text
				};
				break;
			case API_v1_Message.Types.API_v1_MessageToken.TokenTypeOneofCase.Timer:
			{
				if (Common.TryFindItem(timers, item.Timer.Id, out ItemPacket<TimerData> packet))
				{
					TimerData timerData = packet.Item.Clone();
					UpdateTimerData(timerData, item.Timer);
					token.Timer = new Pro.SerializationInterop.RVProtoData.Message.Types.Token.Types.TokenTypeTimer
					{
						TimerUuid = timerData.ID.ToUUID(),
						Name = timerData.Name
					};
					tokenValue.Timer = new Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Types.TokenValueTimer
					{
						Configuration = timerData.Source?.Serialize(),
						Format = ToProtoTimeFormat(item.Timer.Format)
					};
					break;
				}
				return false;
			}
			case API_v1_Message.Types.API_v1_MessageToken.TokenTypeOneofCase.Clock:
				token.Clock = new Pro.SerializationInterop.RVProtoData.Message.Types.Token.Types.TokenTypeClock();
				tokenValue.Clock = new Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Types.TokenValueClock
				{
					Format = new Pro.SerializationInterop.RVProtoData.Clock.Types.Format
					{
						DateType = ProtoLocalClockFormat(item.Clock.Date),
						TimeFormat = ProtoLocalClockFormat(item.Clock.Time),
						MilitaryTimeEnabled = item.Clock.Is24Hours
					}
				};
				break;
			}
			text = new Regex("{" + item.Name + "}").Replace(text, "${" + token.Uuid.String + "}", 1);
			protoMessage.Tokens.Add(token);
			protoMessage.TokenValues.Add(tokenValue);
		}
		protoMessage.MessageText = text;
		return true;
	}

	[GeneratedRegex("\\{(.*?)\\}")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex TokenRegex()
	{
		return _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__TokenRegex_2.Instance;
	}

	private static void UpdateTimerData(TimerData timer, API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_TimerToken protoToken)
	{
		if (timer == null || protoToken == null || timer.Source == null)
		{
			return;
		}
		timer.Name = protoToken.Id.Name;
		timer.Source.IsOverRunAllowed = protoToken.AllowsOverrun;
		switch (protoToken.TimerConfigurationCase)
		{
		case API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_TimerToken.TimerConfigurationOneofCase.Countdown:
			timer.UpdateSource(TimerType.Countdown);
			if (timer.Source != null)
			{
				timer.Source.StartTime = TimeSlice.FromSeconds(protoToken.Countdown.Duration);
			}
			break;
		case API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_TimerToken.TimerConfigurationOneofCase.CountDownToTime:
		{
			timer.UpdateSource(TimerType.CountdownToTime);
			CountdownToTime obj2 = (CountdownToTime)timer.Source;
			obj2.EndTime = TimeSlice.FromSeconds(protoToken.CountDownToTime.TimeOfDay);
			obj2.TimeFormat = ToTimeFormat(protoToken.CountDownToTime.Period);
			break;
		}
		case API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_TimerToken.TimerConfigurationOneofCase.Elapsed:
		{
			timer.UpdateSource(TimerType.ElapsedTime);
			ElapsedTime obj = (ElapsedTime)timer.Source;
			obj.StartTime = TimeSlice.FromSeconds(protoToken.Elapsed.StartTime);
			obj.EndTime = TimeSlice.FromSeconds(protoToken.Elapsed.EndTime);
			obj.HasEndTime = protoToken.Elapsed.HasEndTime;
			break;
		}
		}
	}

	private static NetworkAPI_v1 DeleteMessage(IAPIv1Service service, string id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(service.Messages, id, out ItemPacket<ProPresenter.DO.Messages.Message> p))
			{
				service.Dependencies.UiDispatcher.Invoke(delegate
				{
					service.Messages.UndoStack.StartIgnoring();
					service.Messages.RemoveMessage(p.Item);
					service.Messages.UndoStack.StopIgnoring();
				});
				v1.Action().MessageResponse().DeleteMessage = new API_v1_Message_Response.Types.DeleteMessage();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 ClearMessage(IAPIv1Service service, string id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(service.Messages, id, out ItemPacket<ProPresenter.DO.Messages.Message> packet))
			{
				service.Triggering.ClearMessage(packet.Item);
				v1.Action().MessageResponse().ClearMessage = new API_v1_Message_Response.Types.ClearMessage();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 TriggerMessage(IAPIv1Service service, API_v1_Message_Request.Types.TriggerMessage trigger)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(service.Messages, trigger.Id, out ItemPacket<ProPresenter.DO.Messages.Message> p))
			{
				if (trigger.RequiresConfirmation)
				{
					service.Dependencies.ToastNotifications.ShowToast(service.Dependencies.Localization.Get("MESSAGES_WINDOW_REQUEST_title"), p.Item.GetMessageTextPreview(trigger.Tokens), showLong: true, delegate
					{
						service.Dependencies.UiDispatcher.Invoke(delegate
						{
							DoTriggerMessage(service, p.Item, trigger.Tokens);
						});
					}, null, Array.Empty<ToastButton>());
				}
				else
				{
					DoTriggerMessage(service, p.Item, trigger.Tokens);
				}
				v1.Action().MessageResponse().ClearMessage = new API_v1_Message_Response.Types.ClearMessage();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static void DoTriggerMessage(IAPIv1Service service, ProPresenter.DO.Messages.Message message, IEnumerable<API_v1_Message.Types.API_v1_MessageToken> tokens)
	{
		UpdateToken(message, tokens);
		service.Triggering.TriggerMessage(message);
	}

	private static API_v1_Message_Response MessageResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.MessageResponse ?? (action.MessageResponse = new API_v1_Message_Response());
	}

	private static API_v1_Message CreateProtoMessage(ProPresenter.DO.Messages.Message message, uint index)
	{
		uint tokenIndex = 0u;
		return new API_v1_Message
		{
			Id = Common.ID(message, index),
			Message = string.Join(string.Empty, message.EncodeToComponents("{{{0}}}", "{{{0}}}")),
			Theme = Common.ID(message.SelectedTemplate?.Slide.ID ?? Guid.Empty, message.SelectedTemplate?.Name ?? string.Empty, 0u),
			Tokens = { from t in message.Tokens.ToArray().OfType<MessageTokenBase>()
				select CreateProtoToken(t, tokenIndex++) }
		};
	}

	private static API_v1_Message.Types.API_v1_MessageToken CreateProtoToken(MessageTokenBase token, uint index)
	{
		if (!(token is ClockToken))
		{
			if (!(token is TextToken))
			{
				if (token is TimerToken token2)
				{
					return CreateProtoTimerToken(token2, index);
				}
				throw new NotImplementedException();
			}
			return CreateProtoTextToken(token.Content, token.SerializeTokenValue().Text);
		}
		return CreateProtoClockToken(token.Content, token.SerializeTokenValue().Clock);
	}

	private static API_v1_Message.Types.API_v1_MessageToken CreateProtoTimerToken(TimerToken token, uint index)
	{
		Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue = token.SerializeTokenValue();
		Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Types.TokenValueTimer timer = tokenValue.Timer;
		API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_TimerToken aPI_v1_TimerToken = new API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_TimerToken
		{
			AllowsOverrun = timer.Configuration.AllowsOverrun,
			Id = Common.ID(token.Timer.ID, tokenValue.TokenName, index),
			Format = new API_v1_TimerFormat
			{
				Hour = timer.Format.Hour.LocalToProtoUnitDisplayFormat(),
				Minute = timer.Format.Minute.LocalToProtoUnitDisplayFormat(),
				Second = timer.Format.Second.LocalToProtoUnitDisplayFormat(),
				Millisecond = timer.Format.Millisecond.LocalToProtoUnitDisplayFormat()
			}
		};
		Timer.Types.Configuration configuration = timer.Configuration;
		if (configuration == null)
		{
			goto IL_0119;
		}
		Timer.Types.Configuration.Types.TimerTypeCountdown countdown = configuration.Countdown;
		if (countdown == null)
		{
			Timer.Types.Configuration.Types.TimerTypeCountdownToTime countdownToTime = configuration.CountdownToTime;
			if (countdownToTime == null)
			{
				Timer.Types.Configuration.Types.TimerTypeElapsedTime elapsedTime = configuration.ElapsedTime;
				if (elapsedTime == null)
				{
					goto IL_0119;
				}
				API_v1_Timer.Types.API_v1_Timer_Elapsed aPI_v1_Timer_Elapsed2 = (aPI_v1_TimerToken.Elapsed = elapsedTime.CreateElapsedTimeProto());
				object obj = aPI_v1_Timer_Elapsed2;
			}
			else
			{
				API_v1_Timer.Types.API_v1_Timer_CountdownToTime aPI_v1_Timer_CountdownToTime2 = (aPI_v1_TimerToken.CountDownToTime = countdownToTime.CreateCountdownToTimeProto());
				object obj = aPI_v1_Timer_CountdownToTime2;
			}
		}
		else
		{
			API_v1_Timer.Types.API_v1_Timer_Countdown aPI_v1_Timer_Countdown2 = (aPI_v1_TimerToken.Countdown = countdown.CreateCountdownProto());
			object obj = aPI_v1_Timer_Countdown2;
		}
		goto IL_0120;
		IL_0119:
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(configuration);
		goto IL_0120;
		IL_0120:
		return new API_v1_Message.Types.API_v1_MessageToken
		{
			Name = tokenValue.TokenName,
			Timer = aPI_v1_TimerToken
		};
	}

	private static API_v1_Timer.Types.API_v1_Timer_Elapsed CreateElapsedTimeProto(this Timer.Types.Configuration.Types.TimerTypeElapsedTime elapsed)
	{
		return new API_v1_Timer.Types.API_v1_Timer_Elapsed
		{
			EndTime = Convert.ToInt32(elapsed.EndTime),
			HasEndTime = elapsed.HasEndTime,
			StartTime = Convert.ToInt32(elapsed.StartTime)
		};
	}

	private static API_v1_Timer.Types.API_v1_Timer_CountdownToTime CreateCountdownToTimeProto(this Timer.Types.Configuration.Types.TimerTypeCountdownToTime countdownToTime)
	{
		int num = Convert.ToInt32(countdownToTime.TimeOfDay);
		if (countdownToTime.Period != Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod._24)
		{
			num %= 43200;
		}
		return new API_v1_Timer.Types.API_v1_Timer_CountdownToTime
		{
			Period = LocalToProtoTimePeriod(countdownToTime.Period),
			TimeOfDay = num
		};
	}

	private static API_v1_Timer.Types.API_v1_Timer_Countdown CreateCountdownProto(this Timer.Types.Configuration.Types.TimerTypeCountdown countdown)
	{
		return new API_v1_Timer.Types.API_v1_Timer_Countdown
		{
			Duration = Convert.ToInt32(countdown.Duration)
		};
	}

	private static API_v1_Timer.Types.API_v1_TimePeriod LocalToProtoTimePeriod(Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod period)
	{
		return period switch
		{
			Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod.Am => API_v1_Timer.Types.API_v1_TimePeriod.Am, 
			Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod.Pm => API_v1_Timer.Types.API_v1_TimePeriod.Pm, 
			Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod._24 => API_v1_Timer.Types.API_v1_TimePeriod.Is24Hour, 
			_ => throw new NotImplementedException(), 
		};
	}

	private static API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat LocalToProtoUnitDisplayFormat(this Timer.Types.Format.Types.Style format)
	{
		return format switch
		{
			Timer.Types.Format.Types.Style.None => API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat.None, 
			Timer.Types.Format.Types.Style.Short => API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat.Short, 
			Timer.Types.Format.Types.Style.Long => API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat.Long, 
			Timer.Types.Format.Types.Style.RemoveShort => API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat.RemoveShort, 
			Timer.Types.Format.Types.Style.RemoveLong => API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat.RemoveLong, 
			_ => throw new NotImplementedException(), 
		};
	}

	private static Timer.Types.Format.Types.Style ProtoToLocalUnitDisplayFormat(API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat format)
	{
		return format switch
		{
			API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat.None => Timer.Types.Format.Types.Style.None, 
			API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat.Short => Timer.Types.Format.Types.Style.Short, 
			API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat.Long => Timer.Types.Format.Types.Style.Long, 
			API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat.RemoveShort => Timer.Types.Format.Types.Style.RemoveShort, 
			API_v1_TimerFormat.Types.API_v1_TimerUnitDisplayFormat.RemoveLong => Timer.Types.Format.Types.Style.RemoveLong, 
			_ => throw new NotImplementedException(), 
		};
	}

	private static TimeFormat ToTimeFormat(API_v1_Timer.Types.API_v1_TimePeriod period)
	{
		return period switch
		{
			API_v1_Timer.Types.API_v1_TimePeriod.Am => TimeFormat.AM, 
			API_v1_Timer.Types.API_v1_TimePeriod.Pm => TimeFormat.PM, 
			API_v1_Timer.Types.API_v1_TimePeriod.Is24Hour => TimeFormat.TwentyFour, 
			_ => TimeFormat.TwentyFour, 
		};
	}

	private static Timer.Types.Format ToProtoTimeFormat(API_v1_TimerFormat format)
	{
		return new Timer.Types.Format
		{
			Hour = ProtoToLocalUnitDisplayFormat(format.Hour),
			Minute = ProtoToLocalUnitDisplayFormat(format.Minute),
			Second = ProtoToLocalUnitDisplayFormat(format.Second),
			Millisecond = ProtoToLocalUnitDisplayFormat(format.Millisecond)
		};
	}

	private static API_v1_Message.Types.API_v1_MessageToken CreateProtoTextToken(string tokenName, Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Types.TokenValueText text)
	{
		return new API_v1_Message.Types.API_v1_MessageToken
		{
			Name = tokenName,
			Text = new API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_TextToken
			{
				Text = text.Value
			}
		};
	}

	private static API_v1_Message.Types.API_v1_MessageToken CreateProtoClockToken(string tokenName, Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Types.TokenValueClock clock)
	{
		return new API_v1_Message.Types.API_v1_MessageToken
		{
			Name = tokenName,
			Clock = new API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken
			{
				Date = LocalToProtoClockFormat(clock.Format.DateType),
				Time = LocalToProtoClockFormat(clock.Format.TimeFormat),
				Is24Hours = clock.Format.MilitaryTimeEnabled
			}
		};
	}

	private static API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat LocalToProtoClockFormat(Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle timeFormat)
	{
		return timeFormat switch
		{
			Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Full => API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat.Full, 
			Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.None => API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat.None, 
			Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Short => API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat.Short, 
			Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Medium => API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat.Medium, 
			Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Long => API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat.Long, 
			_ => throw new NotImplementedException(), 
		};
	}

	private static Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle ProtoLocalClockFormat(API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat timeFormat)
	{
		return timeFormat switch
		{
			API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat.Full => Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Full, 
			API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat.None => Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.None, 
			API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat.Short => Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Short, 
			API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat.Medium => Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Medium, 
			API_v1_Message.Types.API_v1_MessageToken.Types.API_v1_ClockToken.Types.API_v1_ClockTokenFormat.Long => Pro.SerializationInterop.RVProtoData.Clock.Types.Format.Types.DateFormatterStyle.Long, 
			_ => throw new NotImplementedException(), 
		};
	}
}
