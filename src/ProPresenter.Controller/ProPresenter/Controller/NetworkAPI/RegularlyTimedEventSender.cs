using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.FeatureFlag;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_updateTimer" })]
internal class RegularlyTimedEventSender : EventSender, IDisposable
{
	[CompilerGenerated]
	private sealed class _003CGetParams_003Ed__13 : IEnumerable<NetworkAPI_v1>, IEnumerable, IEnumerator<NetworkAPI_v1>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private NetworkAPI_v1 _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public RegularlyTimedEventSender _003C_003E4__this;

		private List<API_v1_TimerValue> _003CcurrentTimersState_003E5__2;

		private IEnumerable<(ProLayerIndex, double)> _003CcurrentLayerTimeState_003E5__3;

		private IEnumerator<((ProLayerIndex, double), int)> _003C_003E7__wrap3;

		NetworkAPI_v1 IEnumerator<NetworkAPI_v1>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetParams_003Ed__13(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 2)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003CcurrentTimersState_003E5__2 = null;
			_003CcurrentLayerTimeState_003E5__3 = null;
			_003C_003E7__wrap3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				RegularlyTimedEventSender regularlyTimedEventSender = _003C_003E4__this;
				bool flag2;
				bool flag3;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003CcurrentTimersState_003E5__2 = TimerHandler.CurrentTimersState(DataVault.TimerDocument.Timers).ToList();
					if (!_003CcurrentTimersState_003E5__2.ContentsMatch(regularlyTimedEventSender._previousTimersState))
					{
						_003C_003E2__current = TimerHandler.CurrentTimersUpdate(_003CcurrentTimersState_003E5__2);
						_003C_003E1__state = 1;
						return true;
					}
					goto IL_009d;
				case 1:
					_003C_003E1__state = -1;
					regularlyTimedEventSender._previousTimersState = _003CcurrentTimersState_003E5__2;
					goto IL_009d;
				case 2:
					_003C_003E1__state = -3;
					goto IL_013a;
				case 3:
				{
					_003C_003E1__state = -1;
					bool flag = regularlyTimedEventSender.CheckTimeline(regularlyTimedEventSender._service.Triggering.ActiveSlideParent, ref regularlyTimedEventSender._previousActivePresentationTimelinePlayingOffset, OutputDestination.Presentation, regularlyTimedEventSender._dispatcher, regularlyTimedEventSender._isDispatcherShuttingDown);
					if (!regularlyTimedEventSender._service.Dependencies.FlagService.IsFlagEnabled(Flag.CoreNetworkapiPresentation) && flag)
					{
						_003C_003E2__current = PresentationHandler.ActivePresentationTimelineStatus(regularlyTimedEventSender._service);
						_003C_003E1__state = 4;
						return true;
					}
					goto IL_01f7;
				}
				case 4:
					_003C_003E1__state = -1;
					goto IL_01f7;
				case 5:
					_003C_003E1__state = -1;
					goto IL_026b;
				case 6:
					{
						_003C_003E1__state = -1;
						break;
					}
					IL_01f7:
					flag2 = regularlyTimedEventSender.CheckTimeline(regularlyTimedEventSender._service.Triggering.ActivePlaylistItem, ref regularlyTimedEventSender._previousFocusedPresentationTimelinePlayingOffset, OutputDestination.Presentation, regularlyTimedEventSender._dispatcher, regularlyTimedEventSender._isDispatcherShuttingDown);
					if (!regularlyTimedEventSender._service.Dependencies.FlagService.IsFlagEnabled(Flag.CoreNetworkapiPresentation) && flag2)
					{
						_003C_003E2__current = PresentationHandler.FocusedTimelineStatus(regularlyTimedEventSender._service);
						_003C_003E1__state = 5;
						return true;
					}
					goto IL_026b;
					IL_009d:
					_003CcurrentLayerTimeState_003E5__3 = TransportHandler.CurrentLayerTimes(regularlyTimedEventSender._service.Triggering);
					_003C_003E7__wrap3 = _003CcurrentLayerTimeState_003E5__3.Enumerate().GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_013a;
					IL_026b:
					flag3 = regularlyTimedEventSender.CheckTimeline(regularlyTimedEventSender._service.Triggering.ActiveAnnouncementParent, ref regularlyTimedEventSender._previousActiveAnnouncementTimelinePlayingOffset, OutputDestination.Announcement, regularlyTimedEventSender._dispatcher, regularlyTimedEventSender._isDispatcherShuttingDown);
					if (!regularlyTimedEventSender._service.Dependencies.FlagService.IsFlagEnabled(Flag.CoreNetworkapiPresentation) && flag3)
					{
						_003C_003E2__current = PresentationHandler.ActiveAnnouncementTimelineStatus(regularlyTimedEventSender._service);
						_003C_003E1__state = 6;
						return true;
					}
					break;
					IL_013a:
					while (_003C_003E7__wrap3.MoveNext())
					{
						var (x, num2) = _003C_003E7__wrap3.Current;
						if (num2 >= regularlyTimedEventSender._previousTransportTimeState.Count || x.Item2 != regularlyTimedEventSender._previousTransportTimeState[num2].Item2)
						{
							_003C_003E2__current = TransportHandler.LayerCurrentTimeUpdate(x);
							_003C_003E1__state = 2;
							return true;
						}
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap3 = null;
					regularlyTimedEventSender._previousTransportTimeState = _003CcurrentLayerTimeState_003E5__3.ToList();
					_003C_003E2__current = TimerHandler.SystemTime();
					_003C_003E1__state = 3;
					return true;
				}
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap3 != null)
			{
				_003C_003E7__wrap3.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<NetworkAPI_v1> IEnumerable<NetworkAPI_v1>.GetEnumerator()
		{
			_003CGetParams_003Ed__13 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CGetParams_003Ed__13(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<NetworkAPI_v1>)this).GetEnumerator();
		}
	}

	private const int UpdateIntervalMS = 1000;

	private readonly System.Timers.Timer _updateTimer = new System.Timers.Timer(1000.0);

	private readonly Dispatcher _dispatcher;

	private readonly IAPIv1Service _service;

	private List<API_v1_TimerValue> _previousTimersState;

	private List<(ProLayerIndex, double)> _previousTransportTimeState;

	private long _previousActivePresentationTimelinePlayingOffset;

	private long _previousFocusedPresentationTimelinePlayingOffset;

	private long _previousActiveAnnouncementTimelinePlayingOffset;

	private bool _isDispatcherShuttingDown;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public RegularlyTimedEventSender(IAPIv1Service service)
	{
		_dispatcher = Dispatcher.CurrentDispatcher;
		_isDispatcherShuttingDown = false;
		_dispatcher.ShutdownStarted += DispatcherOnShutdownStarted;
		_service = service;
		_previousTimersState = TimerHandler.CurrentTimersState(DataVault.TimerDocument.Timers).ToList();
		_previousTransportTimeState = TransportHandler.CurrentLayerTimes(service.Triggering).ToList();
		_previousActivePresentationTimelinePlayingOffset = 0L;
		_previousFocusedPresentationTimelinePlayingOffset = 0L;
		_previousActiveAnnouncementTimelinePlayingOffset = 0L;
		_updateTimer.Elapsed += delegate
		{
			Tick();
		};
		_updateTimer.Start();
	}

	private void Tick()
	{
		if (!_isDispatcherShuttingDown)
		{
			OnSend(GetParams().ToArray());
		}
	}

	private void DispatcherOnShutdownStarted(object? sender, EventArgs e)
	{
		_isDispatcherShuttingDown = true;
		_updateTimer.Stop();
	}

	[IteratorStateMachine(typeof(_003CGetParams_003Ed__13))]
	private IEnumerable<NetworkAPI_v1> GetParams()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetParams_003Ed__13(-2)
		{
			_003C_003E4__this = this
		};
	}

	private bool CheckTimeline(ProPresenterCue? cue, ref long previous, OutputDestination? destination, Dispatcher? dispatcher = null, bool isDispatcherShuttingDown = false)
	{
		if (dispatcher == null)
		{
			dispatcher = Dispatcher.CurrentDispatcher;
		}
		if (!dispatcher.Thread.IsAlive || isDispatcherShuttingDown)
		{
			return false;
		}
		if (cue is IDocumentCue documentCue && documentCue?.DocumentAction?.Presentation != null)
		{
			try
			{
				if (documentCue.DocumentAction.Destination == destination)
				{
					if (documentCue.DocumentAction != null)
					{
						dispatcher.Invoke((System.Action)documentCue.DocumentAction.Presentation.EnsureLoaded);
					}
					(bool isPlaying, bool isRecording, TimeSlice time) info = _service.Dependencies.TimelineManager.GetInfo(documentCue);
					bool item = info.isPlaying;
					TimeSlice item2 = info.time;
					long num = (long)Math.Truncate(item2.TotalSeconds);
					if (num != previous)
					{
						previous = num;
						return item;
					}
				}
			}
			catch (TaskCanceledException)
			{
			}
		}
		return false;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_updateTimer.Dispose();
		}
	}
}
