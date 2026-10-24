using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.Time;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI;

public static class TimerHandler
{
	public static NetworkAPI_v1 Handle(TimerCollection timers, ITriggering triggering, IUiDispatcher dispatcher, IProPresenterDOFactoryProvider factoryProvider, API_v1_Timer_Request r)
	{
		if (r != null)
		{
			if (r.Timers != null)
			{
				return Timers(timers);
			}
			API_v1_Timer_Request.Types.CreateTimer createTimer = r.CreateTimer;
			if (createTimer != null)
			{
				return CreateTimer(timers, dispatcher, createTimer);
			}
			if (r.CurrentTimes != null)
			{
				return CurrentTimes(timers, factoryProvider.EntityFactory);
			}
			API_v1_Timer_Request.Types.AllTimersOperation allTimersOperation = r.AllTimersOperation;
			if (allTimersOperation != null)
			{
				return AllTimersOperation(timers, triggering, allTimersOperation);
			}
			API_v1_Timer_Request.Types.GetTimer getTimer = r.GetTimer;
			if (getTimer != null)
			{
				return GetTimer(timers, getTimer);
			}
			API_v1_Timer_Request.Types.PutTimer putTimer = r.PutTimer;
			if (putTimer != null)
			{
				return PutTimer(timers, dispatcher, putTimer);
			}
			API_v1_Timer_Request.Types.DeleteTimer deleteTimer = r.DeleteTimer;
			if (deleteTimer != null)
			{
				return DeleteTimer(timers, dispatcher, deleteTimer);
			}
			API_v1_Timer_Request.Types.TimerOperation timerOperation = r.TimerOperation;
			if (timerOperation != null)
			{
				return TimerOperation(timers, triggering, timerOperation);
			}
			API_v1_Timer_Request.Types.PutTimerOperation putTimerOperation = r.PutTimerOperation;
			if (putTimerOperation != null)
			{
				return PutTimerOperation(timers, triggering, dispatcher, putTimerOperation);
			}
			API_v1_Timer_Request.Types.TimerIncrement timerIncrement = r.TimerIncrement;
			if (timerIncrement != null)
			{
				return TimerIncrement(timers, triggering, timerIncrement);
			}
			if (r.SystemTime != null)
			{
				return SystemTime();
			}
			if (r.VideoCountdown != null)
			{
				return VideoCountdown(triggering);
			}
		}
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(r);
		NetworkAPI_v1 result = default(NetworkAPI_v1);
		return result;
	}

	private static NetworkAPI_v1 Timers(IEnumerable<TimerData> timers)
	{
		uint index = 0u;
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/timers").TimerResponse().Timers = new API_v1_Timer_Response.Types.Timers
			{
				Timers_ = { timers.Select((TimerData t) => CreateProtoTimer(t, index++)) }
			};
		});
	}

	private static NetworkAPI_v1 CreateTimer(TimerCollection timers, IUiDispatcher dispatcher, API_v1_Timer_Request.Types.CreateTimer createTimer)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			string name = createTimer.Name;
			bool allowsOverrun = createTimer.AllowsOverrun;
			API_v1_Timer_Response.Types.CreateTimer createTimer3 = (v1.Action().TimerResponse().CreateTimer = new API_v1_Timer_Response.Types.CreateTimer());
			if (createTimer != null)
			{
				API_v1_Timer.Types.API_v1_Timer_Countdown countdown = createTimer.Countdown;
				(TimerData, int) tuple;
				if (countdown == null)
				{
					API_v1_Timer.Types.API_v1_Timer_CountdownToTime countDownToTime = createTimer.CountDownToTime;
					if (countDownToTime == null)
					{
						API_v1_Timer.Types.API_v1_Timer_Elapsed elapsed = createTimer.Elapsed;
						if (elapsed == null)
						{
							goto IL_00ef;
						}
						tuple = AddNewElapsedTimer(timers, name, elapsed.StartTime, elapsed.EndTime, elapsed.HasEndTime, allowsOverrun, dispatcher);
					}
					else
					{
						tuple = AddNewCountdownToTimeTimer(timers, name, countDownToTime.TimeOfDay, createTimer.CountDownToTime.Period.Deserialize(), allowsOverrun, dispatcher);
					}
				}
				else
				{
					tuple = AddNewCountdownTimer(timers, name, countdown.Duration, allowsOverrun, dispatcher);
				}
				(TimerData, int) tuple2 = tuple;
				TimerData item = tuple2.Item1;
				int item2 = tuple2.Item2;
				createTimer3.Timer = CreateProtoTimer(item, (uint)item2);
				return;
			}
			goto IL_00ef;
			IL_00ef:
			throw new NotSupportedException();
		});
	}

	internal static NetworkAPI_v1 OnTimerChanged(TimerDocument timerDocument)
	{
		return Timers(timerDocument.Timers);
	}

	private static (TimerData, int) AddNewCountdownTimer(TimerCollection timers, string name, int duration, bool allowOverrun, IUiDispatcher dispatcher)
	{
		dispatcher.Invoke(delegate
		{
			timers.AddNewCountdownTimer(name, TimeSlice.FromSeconds(duration), allowOverrun);
		});
		return (timers.Last(), timers.Count() - 1);
	}

	private static (TimerData, int) AddNewCountdownToTimeTimer(TimerCollection timers, string name, int timeOfDay, TimeFormat timeFormat, bool allowOverrun, IUiDispatcher dispatcher)
	{
		dispatcher.Invoke(delegate
		{
			timers.AddNewCountdownToTimeTimer(name, TimeSlice.FromSeconds(timeOfDay), timeFormat, allowOverrun);
		});
		return (timers.Last(), timers.Count() - 1);
	}

	private static (TimerData, int) AddNewElapsedTimer(TimerCollection timers, string name, int startTime, int endTime, bool hasEndTime, bool allowOverrun, IUiDispatcher dispatcher)
	{
		dispatcher.Invoke(delegate
		{
			timers.AddNewElapsedTimer(name, TimeSlice.FromSeconds(startTime), TimeSlice.FromSeconds(endTime), hasEndTime, allowOverrun);
		});
		return (timers.Last(), timers.Count() - 1);
	}

	private static NetworkAPI_v1 AllTimersOperation(IEnumerable<TimerData> timers, ITriggering triggering, API_v1_Timer_Request.Types.AllTimersOperation allTimersOperation)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TimerResponse().AllTimersOperation = new API_v1_Timer_Response.Types.AllTimersOperation();
			TimerActionType operation = allTimersOperation.Operation switch
			{
				API_v1_TimerOperation.Start => TimerActionType.Start, 
				API_v1_TimerOperation.Stop => TimerActionType.Stop, 
				API_v1_TimerOperation.Reset => TimerActionType.Reset, 
				_ => throw new NotImplementedException(), 
			};
			timers.ForEach(delegate(TimerData t)
			{
				triggering.TriggerTimerAction(t, operation, null);
			});
		});
	}

	private static NetworkAPI_v1 CurrentTimes(IEnumerable<TimerData> timers, IEntityFactory entityFactory)
	{
		return CurrentTimersUpdate(CurrentTimersState(timers));
	}

	internal static NetworkAPI_v1 CurrentTimersUpdate(IEnumerable<API_v1_TimerValue> timers)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/timers/current").TimerResponse().CurrentTimes = new API_v1_Timer_Response.Types.CurrentTimes
			{
				Timers = { timers }
			};
		});
	}

	internal static IEnumerable<API_v1_TimerValue> CurrentTimersState(IEnumerable<TimerData> timers)
	{
		uint index = 0u;
		return timers.Select((TimerData t) => CreateProtoTimerValue(t, index++));
	}

	private static NetworkAPI_v1 GetTimer(IEnumerable<TimerData> timers, API_v1_Timer_Request.Types.GetTimer getTimer)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(timers, getTimer.Id, out ItemPacket<TimerData> packet))
			{
				v1.Action().TimerResponse().GetTimer = new API_v1_Timer_Response.Types.GetTimer
				{
					Timer = CreateProtoTimer(packet.Item, packet.Index)
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 PutTimer(TimerCollection timers, IUiDispatcher dispatcher, API_v1_Timer_Request.Types.PutTimer putTimer)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(timers, putTimer.Id, out ItemPacket<TimerData> p))
			{
				dispatcher.Invoke(delegate
				{
					API_v1_Timer timer = putTimer.Timer;
					p.Item.UndoStack?.StartIgnoring();
					if (timer == null)
					{
						goto IL_00c3;
					}
					API_v1_Timer.Types.API_v1_Timer_Countdown countdown = timer.Countdown;
					bool flag;
					if (countdown == null)
					{
						API_v1_Timer.Types.API_v1_Timer_CountdownToTime countDownToTime = timer.CountDownToTime;
						if (countDownToTime == null)
						{
							API_v1_Timer.Types.API_v1_Timer_Elapsed elapsed = timer.Elapsed;
							if (elapsed == null)
							{
								goto IL_00c3;
							}
							flag = UpdateElapsedTimer(p.Item, elapsed.EndTime, elapsed.HasEndTime, timer.AllowsOverrun);
						}
						else
						{
							flag = UpdateCountdownToTimeTimer(p.Item, countDownToTime.TimeOfDay, countDownToTime.Period.Deserialize(), timer.AllowsOverrun);
						}
					}
					else
					{
						flag = UpdateCountdownTimer(p.Item, countdown.Duration, timer.AllowsOverrun);
					}
					goto IL_00c6;
					IL_00c6:
					if (flag)
					{
						if (p.Item.Source != null)
						{
							p.Item.Name = timer.Id.Name;
						}
						v1.Action().TimerResponse().PutTimer = new API_v1_Timer_Response.Types.PutTimer
						{
							Timer = CreateProtoTimer(p.Item, p.Index)
						};
					}
					else
					{
						v1.Action().BadRequest();
					}
					p.Item.UndoStack?.StopIgnoring();
					return;
					IL_00c3:
					flag = false;
					goto IL_00c6;
				});
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 DeleteTimer(TimerCollection timers, IUiDispatcher dispatcher, API_v1_Timer_Request.Types.DeleteTimer deleteTimer)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(timers, deleteTimer.Id, out ItemPacket<TimerData> p))
			{
				dispatcher.Invoke(delegate
				{
					timers.UndoStack?.StartIgnoring();
					timers.RemoveTimer(p.Item);
					timers.UndoStack?.StopIgnoring();
				});
				v1.Action().TimerResponse().DeleteTimer = new API_v1_Timer_Response.Types.DeleteTimer();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 TimerOperation(IEnumerable<TimerData> timers, ITriggering triggering, API_v1_Timer_Request.Types.TimerOperation timerOperation)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(timers, timerOperation.Id, out ItemPacket<TimerData> packet))
			{
				v1.Action().TimerResponse().TimerOperation = new API_v1_Timer_Response.Types.TimerOperation();
				TriggerTimer(triggering, packet.Item, timerOperation.Operation);
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 PutTimerOperation(IEnumerable<TimerData> timers, ITriggering triggering, IUiDispatcher dispatcher, API_v1_Timer_Request.Types.PutTimerOperation putTimerOperation)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(timers, putTimerOperation.Id, out ItemPacket<TimerData> p))
			{
				dispatcher.Invoke(delegate
				{
					API_v1_Timer timer = putTimerOperation.Timer;
					p.Item.UndoStack?.StartIgnoring();
					if (timer == null)
					{
						goto IL_00c3;
					}
					API_v1_Timer.Types.API_v1_Timer_Countdown countdown = timer.Countdown;
					bool flag;
					if (countdown == null)
					{
						API_v1_Timer.Types.API_v1_Timer_CountdownToTime countDownToTime = timer.CountDownToTime;
						if (countDownToTime == null)
						{
							API_v1_Timer.Types.API_v1_Timer_Elapsed elapsed = timer.Elapsed;
							if (elapsed == null)
							{
								goto IL_00c3;
							}
							flag = UpdateElapsedTimer(p.Item, elapsed.EndTime, elapsed.HasEndTime, timer.AllowsOverrun);
						}
						else
						{
							flag = UpdateCountdownToTimeTimer(p.Item, countDownToTime.TimeOfDay, countDownToTime.Period.Deserialize(), timer.AllowsOverrun);
						}
					}
					else
					{
						flag = UpdateCountdownTimer(p.Item, countdown.Duration, timer.AllowsOverrun);
					}
					goto IL_00c6;
					IL_00c6:
					if (flag)
					{
						if (p.Item.Source != null)
						{
							p.Item.Name = timer.Id.Name;
						}
						v1.Action().TimerResponse().PutTimerOperation = new API_v1_Timer_Response.Types.PutTimerOperation
						{
							Timer = CreateProtoTimer(p.Item, p.Index)
						};
						TriggerTimer(triggering, p.Item, putTimerOperation.Operation);
					}
					else
					{
						v1.Action().BadRequest();
					}
					p.Item.UndoStack?.StopIgnoring();
					return;
					IL_00c3:
					flag = false;
					goto IL_00c6;
				});
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 TimerIncrement(IEnumerable<TimerData> timers, ITriggering triggering, API_v1_Timer_Request.Types.TimerIncrement timerIncrement)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(timers, timerIncrement.Id, out ItemPacket<TimerData> packet))
			{
				v1.Action().TimerResponse().TimerIncrement = new API_v1_Timer_Response.Types.TimerIncrement();
				IncrementTimer(triggering, packet.Item, TimeSlice.FromSeconds(timerIncrement.Amount));
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	internal static NetworkAPI_v1 SystemTime()
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/timer/system_time").TimerResponse().SystemTime = new API_v1_Timer_Response.Types.SystemTime
			{
				Time = Convert.ToUInt64(DateTimeOffset.UtcNow.ToUnixTimeSeconds())
			};
		});
	}

	private static NetworkAPI_v1 VideoCountdown(ITriggering triggering)
	{
		return VideoCountdown(TimeSlice.FromSeconds(triggering.TransportStatus.GetStatus(ProLayerIndex.PresentationBackground)?.Remaining ?? 0.0));
	}

	internal static NetworkAPI_v1 VideoCountdown(TimeSlice time)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/timer/video_countdown").TimerResponse().VideoCountdown = new API_v1_Timer_Response.Types.VideoCountdown
			{
				Time = TimeSliceHelper.TimeSliceToString(time)
			};
		});
	}

	private static API_v1_Timer CreateProtoTimer(TimerData timer, uint index)
	{
		API_v1_Timer aPI_v1_Timer = new API_v1_Timer
		{
			AllowsOverrun = (timer.Source?.IsOverRunAllowed ?? false),
			Id = Common.ID(timer, index)
		};
		int num = (int)Math.Round(timer.Source?.StartTime.TotalSeconds ?? 0.0);
		int num2 = (int)Math.Round(timer.Source?.EndTime.TotalSeconds ?? 0.0);
		TimerBase source = timer.Source;
		if (!(source is CountdownTimer))
		{
			if (!(source is CountdownToTime countdownToTime))
			{
				if (source is ElapsedTime elapsedTime)
				{
					aPI_v1_Timer.Elapsed = new API_v1_Timer.Types.API_v1_Timer_Elapsed
					{
						StartTime = num,
						EndTime = num2,
						HasEndTime = elapsedTime.HasEndTime
					};
				}
			}
			else
			{
				aPI_v1_Timer.CountDownToTime = new API_v1_Timer.Types.API_v1_Timer_CountdownToTime
				{
					Period = countdownToTime.TimeFormat.Serialize(),
					TimeOfDay = ((countdownToTime.TimeFormat == TimeFormat.TwentyFour) ? num2 : (num2 % 43200))
				};
			}
		}
		else
		{
			aPI_v1_Timer.Countdown = new API_v1_Timer.Types.API_v1_Timer_Countdown
			{
				Duration = num
			};
		}
		return aPI_v1_Timer;
	}

	private static API_v1_TimerValue CreateProtoTimerValue(TimerData timer, uint index)
	{
		return new API_v1_TimerValue
		{
			Id = Common.ID(timer, index),
			Time = ((timer.Active != null) ? GetRunningTime(timer.Active) : string.Empty),
			State = ((timer.Active != null) ? timer.Active.State.ToAPIv1State() : API_v1_TimerState.Stopped)
		};
	}

	private static API_v1_Timer_Response TimerResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.TimerResponse ?? (action.TimerResponse = new API_v1_Timer_Response());
	}

	private static bool UpdateCountdownTimer(TimerData timer, int duration, bool allowOverrun)
	{
		timer.UpdateSource(TimerType.Countdown);
		(timer.Source as CountdownTimer)?.UpdateTimer(TimeSlice.FromSeconds(duration), allowOverrun);
		return true;
	}

	private static bool UpdateCountdownToTimeTimer(TimerData timer, int timeOfDay, TimeFormat timeFormat, bool allowOverrun)
	{
		timer.UpdateSource(TimerType.CountdownToTime);
		(timer.Source as CountdownToTime)?.UpdateTimer(TimeSlice.FromSeconds(timeOfDay), timeFormat, allowOverrun);
		return true;
	}

	private static bool UpdateElapsedTimer(TimerData timer, int endTime, bool hasEndTime, bool allowOverrun)
	{
		timer.UpdateSource(TimerType.ElapsedTime);
		(timer.Source as ElapsedTime)?.UpdateTimer(TimeSlice.FromSeconds(endTime), hasEndTime, allowOverrun);
		return true;
	}

	private static void TriggerTimer(ITriggering triggering, TimerData timer, API_v1_TimerOperation op)
	{
		triggering.TriggerTimerAction(timer, op switch
		{
			API_v1_TimerOperation.Start => TimerActionType.Start, 
			API_v1_TimerOperation.Stop => TimerActionType.Stop, 
			API_v1_TimerOperation.Reset => TimerActionType.Reset, 
			_ => throw new NotImplementedException(), 
		}, null);
	}

	private static void IncrementTimer(ITriggering triggering, TimerData timer, TimeSlice incrementAmount)
	{
		triggering.TriggerTimerAction(timer, TimerActionType.Increment, incrementAmount);
	}

	private static string GetRunningTime(TimerBase timer)
	{
		if (timer.State == TimerState.Reset && timer is CountdownToTime countdownToTime)
		{
			bool flag = countdownToTime.TimeFormat == TimeFormat.TwentyFour;
			return new TimerFormatData
			{
				HourFormat = ((!flag) ? TimerFormatStyle.Short : TimerFormatStyle.Long),
				MinuteFormat = TimerFormatStyle.Long,
				SecondFormat = TimerFormatStyle.ShortTruncated
			}.FormatTime(countdownToTime.EndTime);
		}
		return TimeSliceHelper.TimeSliceToString(timer.RunningTime);
	}

	private static API_v1_TimerState ToAPIv1State(this TimerState state)
	{
		return state switch
		{
			TimerState.Reset => API_v1_TimerState.Stopped, 
			TimerState.Paused => API_v1_TimerState.Stopped, 
			TimerState.Started => API_v1_TimerState.Running, 
			TimerState.Expired => API_v1_TimerState.Complete, 
			TimerState.Overrunning => API_v1_TimerState.Overrunning, 
			TimerState.Overran => API_v1_TimerState.Overran, 
			_ => throw new NotImplementedException(), 
		};
	}
}
