using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.Common.FeatureFlag;
using Pro.Common.SourceGenerator.Attributes;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Presentation;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_debouncedEventAggregator" })]
public class APIv1EventHandler : IApplicationEventHandler, IDisposable
{
	[CompilerGenerated]
	private sealed class _003COnTimelineStateChanged_003Ed__8 : IEnumerable<NetworkAPI_v1>, IEnumerable, IEnumerator<NetworkAPI_v1>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private NetworkAPI_v1 _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public APIv1EventHandler _003C_003E4__this;

		private IFlagService flagService;

		public IFlagService _003C_003E3__flagService;

		private Timeline timeline;

		public Timeline _003C_003E3__timeline;

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
		public _003COnTimelineStateChanged_003Ed__8(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			APIv1EventHandler aPIv1EventHandler = _003C_003E4__this;
			Timeline timeline2;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				Timeline timeline = (aPIv1EventHandler._triggering.ActivePresentationParent as IDocumentCue)?.DocumentAction?.Presentation?.PresentationTimeline;
				if (!flagService.IsFlagEnabled(Flag.CoreNetworkapiPresentation) && timeline == this.timeline)
				{
					_003C_003E2__current = PresentationHandler.ActivePresentationTimelineStatus(aPIv1EventHandler._service);
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_00c3;
			}
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = PresentationHandler.FocusedTimelineStatus(aPIv1EventHandler._service);
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				goto IL_00c3;
			case 3:
				_003C_003E1__state = -1;
				goto IL_0131;
			case 4:
				_003C_003E1__state = -1;
				_003C_003E2__current = PresentationHandler.FocusedTimelineStatus(aPIv1EventHandler._service);
				_003C_003E1__state = 5;
				return true;
			case 5:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_00c3:
				if (aPIv1EventHandler._triggering.ActivePlaylistItem is IDocumentCue documentCue)
				{
					IDocumentAction documentAction = documentCue.DocumentAction;
					if (documentAction != null && documentAction.Destination == OutputDestination.Presentation)
					{
						IPresentation presentation = documentAction.Presentation;
						if (presentation != null)
						{
							Timeline presentationTimeline = presentation.PresentationTimeline;
							if (presentationTimeline != null && presentationTimeline == this.timeline)
							{
								_003C_003E2__current = PresentationHandler.FocusedTimelineStatus(aPIv1EventHandler._service);
								_003C_003E1__state = 3;
								return true;
							}
						}
					}
				}
				goto IL_0131;
				IL_0131:
				timeline2 = (aPIv1EventHandler._triggering.ActiveAnnouncementParent as IDocumentCue)?.DocumentAction?.Presentation?.PresentationTimeline;
				if (!flagService.IsFlagEnabled(Flag.CoreNetworkapiPresentation) && timeline2 == this.timeline)
				{
					_003C_003E2__current = PresentationHandler.ActiveAnnouncementTimelineStatus(aPIv1EventHandler._service);
					_003C_003E1__state = 4;
					return true;
				}
				break;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<NetworkAPI_v1> IEnumerable<NetworkAPI_v1>.GetEnumerator()
		{
			_003COnTimelineStateChanged_003Ed__8 _003COnTimelineStateChanged_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003COnTimelineStateChanged_003Ed__ = this;
			}
			else
			{
				_003COnTimelineStateChanged_003Ed__ = new _003COnTimelineStateChanged_003Ed__8(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003COnTimelineStateChanged_003Ed__.timeline = _003C_003E3__timeline;
			_003COnTimelineStateChanged_003Ed__.flagService = _003C_003E3__flagService;
			return _003COnTimelineStateChanged_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<NetworkAPI_v1>)this).GetEnumerator();
		}
	}

	private readonly IProCoreInstance _proCore;

	private readonly DebouncedEventAggregator _debouncedEventAggregator;

	private readonly ITriggering _triggering;

	private readonly IAPIv1Service _service;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public APIv1EventHandler(IProCoreInstance proCore, IAPIv1Service service)
	{
		_proCore = proCore;
		_triggering = service.Triggering;
		_service = service;
		_debouncedEventAggregator = new DebouncedEventAggregator(service);
		_debouncedEventAggregator.Send += Send;
	}

	public void Handle(IApplicationEvent @event)
	{
		GetMessages(@event).ForEach(Send);
	}

	private IEnumerable<NetworkAPI_v1> GetMessages(IApplicationEvent @event)
	{
		if (@event is ToggleAudienceScreensUpdated toggleAudienceScreensUpdated)
		{
			toggleAudienceScreensUpdated.Deconstruct(out var Enabled);
			return StatusHandler.AudienceScreenUpdate(Enabled).ToEnumerable();
		}
		if (!(@event is MediaUpdated mediaUpdated))
		{
			if (@event is ToggleStageScreensUpdated toggleStageScreensUpdated)
			{
				toggleStageScreensUpdated.Deconstruct(out var Enabled2);
				return StatusHandler.StageScreenUpdate(Enabled2).ToEnumerable();
			}
			if (!(@event is StageMessageState state))
			{
				if (@event is SlidesUpdated slidesUpdated)
				{
					slidesUpdated.Deconstruct(out SlideCue CurrentSlide, out SlideCue NextSlide);
					return StatusHandler.SlidesUpdated(CurrentSlide, NextSlide).ToEnumerable();
				}
				if (@event is LibraryUpdated libraryUpdated)
				{
					libraryUpdated.Deconstruct(out ILibrary Library, out LibraryUpdateType UpdateType, out IReadOnlyList<DocumentCue> Items);
					return LibraryHandler.LibraryUpdated(Library, Serialize(UpdateType), Items).ToEnumerable();
				}
				if (!(@event is ScreensUpdated))
				{
					if (@event is TimelineStateChanged timelineStateChanged)
					{
						timelineStateChanged.Deconstruct(out Timeline Timeline, out bool _, out double _);
						return OnTimelineStateChanged(Timeline, _service.Dependencies.FlagService);
					}
					if (@event is TimerUpdated)
					{
						return TimerHandler.OnTimerChanged(DataVault.TimerDocument).ToEnumerable();
					}
					return Array.Empty<NetworkAPI_v1>();
				}
				return StatusHandler.GetScreens(_service).ToEnumerable();
			}
			return StageHandler.GetMessage(state).ToEnumerable();
		}
		return TransportHandler.MediaUpdated(mediaUpdated.Media, mediaUpdated.IsPlaying, mediaUpdated.LayerIndex);
	}

	private void Send(NetworkAPI_v1? v1)
	{
		_proCore.SendNetworkAPICommand(v1);
	}

	[IteratorStateMachine(typeof(_003COnTimelineStateChanged_003Ed__8))]
	private IEnumerable<NetworkAPI_v1> OnTimelineStateChanged(Timeline timeline, IFlagService flagService)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003COnTimelineStateChanged_003Ed__8(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__timeline = timeline,
			_003C_003E3__flagService = flagService
		};
	}

	private static API_v1_Library_Response.Types.Library.Types.UpdateType Serialize(LibraryUpdateType type)
	{
		return type switch
		{
			LibraryUpdateType.Add => API_v1_Library_Response.Types.Library.Types.UpdateType.Add, 
			LibraryUpdateType.Remove => API_v1_Library_Response.Types.Library.Types.UpdateType.Remove, 
			_ => throw new NotSupportedException(), 
		};
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
			_debouncedEventAggregator.Dispose();
		}
	}
}
