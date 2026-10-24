using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using Pro.Text.Fills;
using Pro.ssAPI;
using ProPresenter.DO.Actions.Capture;
using ProPresenter.DO.Audio;
using ProPresenter.DO.Capture;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Communication;
using ProPresenter.DO.Cues;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Actions;

public static class ActionExtensions
{
	[CompilerGenerated]
	private sealed class _003CFindMedia_003Ed__19 : IEnumerable<(ClosedBezierPath element, MediaFill mediaFill)>, IEnumerable, IEnumerator<(ClosedBezierPath element, MediaFill mediaFill)>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private (ClosedBezierPath element, MediaFill mediaFill) _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private SlideAction slideAction;

		public SlideAction _003C_003E3__slideAction;

		private IEnumerator<ClosedBezierPath> _003C_003E7__wrap1;

		(ClosedBezierPath element, MediaFill mediaFill) IEnumerator<(ClosedBezierPath, MediaFill)>.Current
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
		public _003CFindMedia_003Ed__19(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					_003C_003E1__state = -3;
				}
				else
				{
					_003C_003E1__state = -1;
					if (!(slideAction.Slide is CustomSlide customSlide))
					{
						goto IL_00a8;
					}
					_003C_003E7__wrap1 = customSlide.Elements.OfType<ClosedBezierPath>().GetEnumerator();
					_003C_003E1__state = -3;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					ClosedBezierPath current = _003C_003E7__wrap1.Current;
					if (current.Fill is MediaFill item)
					{
						_003C_003E2__current = (element: current, mediaFill: item);
						_003C_003E1__state = 1;
						return true;
					}
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				goto IL_00a8;
				IL_00a8:
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
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<(ClosedBezierPath element, MediaFill mediaFill)> IEnumerable<(ClosedBezierPath, MediaFill)>.GetEnumerator()
		{
			_003CFindMedia_003Ed__19 _003CFindMedia_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFindMedia_003Ed__ = this;
			}
			else
			{
				_003CFindMedia_003Ed__ = new _003CFindMedia_003Ed__19(0);
			}
			_003CFindMedia_003Ed__.slideAction = _003C_003E3__slideAction;
			return _003CFindMedia_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<(ClosedBezierPath, MediaFill)>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CFindTextMedia_003Ed__20 : IEnumerable<(ClosedBezierPath element, MediaTextFill mediaFill)>, IEnumerable, IEnumerator<(ClosedBezierPath element, MediaTextFill mediaFill)>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private (ClosedBezierPath element, MediaTextFill mediaFill) _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private SlideAction slideAction;

		public SlideAction _003C_003E3__slideAction;

		private IEnumerator<ClosedBezierPath> _003C_003E7__wrap1;

		private ClosedBezierPath _003Celement_003E5__3;

		private IEnumerator<Paragraph> _003C_003E7__wrap3;

		private IEnumerator<RunBase> _003C_003E7__wrap4;

		(ClosedBezierPath element, MediaTextFill mediaFill) IEnumerator<(ClosedBezierPath, MediaTextFill)>.Current
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
		public _003CFindTextMedia_003Ed__20(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if ((uint)(num - -5) <= 2u || num == 1)
			{
				try
				{
					if ((uint)(num - -5) <= 1u || num == 1)
					{
						try
						{
							if (num == -5 || num == 1)
							{
								try
								{
								}
								finally
								{
									_003C_003Em__Finally3();
								}
							}
						}
						finally
						{
							_003C_003Em__Finally2();
						}
					}
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003Celement_003E5__3 = null;
			_003C_003E7__wrap3 = null;
			_003C_003E7__wrap4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					_003C_003E1__state = -5;
					goto IL_0105;
				}
				_003C_003E1__state = -1;
				if (slideAction.Slide is CustomSlide customSlide)
				{
					_003C_003E7__wrap1 = customSlide.Elements.OfType<ClosedBezierPath>().GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_0143;
				}
				goto IL_0160;
				IL_0160:
				return false;
				IL_0143:
				if (_003C_003E7__wrap1.MoveNext())
				{
					_003Celement_003E5__3 = _003C_003E7__wrap1.Current;
					if ((object)_003Celement_003E5__3.Text != null)
					{
						_003C_003E7__wrap3 = _003Celement_003E5__3.Text.GetEnumerator();
						_003C_003E1__state = -4;
						goto IL_011f;
					}
					goto IL_013c;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				goto IL_0160;
				IL_013c:
				_003Celement_003E5__3 = null;
				goto IL_0143;
				IL_011f:
				if (_003C_003E7__wrap3.MoveNext())
				{
					Paragraph current = _003C_003E7__wrap3.Current;
					_003C_003E7__wrap4 = current.GetEnumerator();
					_003C_003E1__state = -5;
					goto IL_0105;
				}
				_003C_003Em__Finally2();
				_003C_003E7__wrap3 = null;
				goto IL_013c;
				IL_0105:
				while (_003C_003E7__wrap4.MoveNext())
				{
					if (_003C_003E7__wrap4.Current.Settings.Fill is MediaTextFill item)
					{
						_003C_003E2__current = (element: _003Celement_003E5__3, mediaFill: item);
						_003C_003E1__state = 1;
						return true;
					}
				}
				_003C_003Em__Finally3();
				_003C_003E7__wrap4 = null;
				goto IL_011f;
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
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -3;
			if (_003C_003E7__wrap3 != null)
			{
				_003C_003E7__wrap3.Dispose();
			}
		}

		private void _003C_003Em__Finally3()
		{
			_003C_003E1__state = -4;
			if (_003C_003E7__wrap4 != null)
			{
				_003C_003E7__wrap4.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<(ClosedBezierPath element, MediaTextFill mediaFill)> IEnumerable<(ClosedBezierPath, MediaTextFill)>.GetEnumerator()
		{
			_003CFindTextMedia_003Ed__20 _003CFindTextMedia_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFindTextMedia_003Ed__ = this;
			}
			else
			{
				_003CFindTextMedia_003Ed__ = new _003CFindTextMedia_003Ed__20(0);
			}
			_003CFindTextMedia_003Ed__.slideAction = _003C_003E3__slideAction;
			return _003CFindTextMedia_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<(ClosedBezierPath, MediaTextFill)>)this).GetEnumerator();
		}
	}

	public static void ToForeground(this MediaAction? mediaAction)
	{
		if (mediaAction != null && mediaAction.Media.MediaType.IsAnyOf(MediaType.Image, MediaType.Video))
		{
			mediaAction.TriggerLayer = TriggerLayer.Foreground;
		}
		if (mediaAction?.Media is ITransportMedia transportMedia)
		{
			transportMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
		}
	}

	public static bool IsActionEditable(this IAction action)
	{
		switch (action.ActionType)
		{
		case ActionType.Media:
			if (action is MediaAction mediaAction)
			{
				return mediaAction.IsEditable;
			}
			return false;
		case ActionType.StageLayout:
		case ActionType.Timer:
		case ActionType.Communication:
		case ActionType.Prop:
		case ActionType.Message:
		case ActionType.AudienceLook:
		case ActionType.AudioInput:
		case ActionType.VisualPlaylist:
		case ActionType.AudioPlaylist:
		case ActionType.SlideDestination:
		case ActionType.Macro:
		case ActionType.ClearGroup:
		case ActionType.Capture:
			return true;
		default:
			return false;
		}
	}

	public static bool IsActionRemoveable(this IAction action)
	{
		switch (action.ActionType)
		{
		case ActionType.StageLayout:
		case ActionType.Media:
		case ActionType.Timer:
		case ActionType.Communication:
		case ActionType.Clear:
		case ActionType.Prop:
		case ActionType.Message:
		case ActionType.AudienceLook:
		case ActionType.AudioInput:
		case ActionType.VisualPlaylist:
		case ActionType.AudioPlaylist:
		case ActionType.SlideDestination:
		case ActionType.Macro:
		case ActionType.ClearGroup:
		case ActionType.Capture:
			return true;
		default:
			return false;
		}
	}

	public static bool CanShowDialogOnDrop(this IAction action, IEnumerable? incomingDropTypes)
	{
		bool num = action.ActionType.IsAnyOf(ActionType.AudioPlaylist, ActionType.VisualPlaylist, ActionType.StageLayout, ActionType.Timer, ActionType.Message);
		bool flag = incomingDropTypes?.AnyOf((object t) => t.GetType() == typeof(ActionType)) ?? false;
		bool flag2 = incomingDropTypes?.AllOf((object t) => t.GetType() == typeof(MediaType) && (MediaType)t == MediaType.LiveVideo) ?? false;
		return num || flag || flag2;
	}

	public static ActionBase? ToAction(this StageScreenLayoutMap assignments)
	{
		if (assignments == null)
		{
			return null;
		}
		if (ActionType.StageLayout.ConstructAction(null, "Stage") is StageAction stageAction)
		{
			{
				foreach (KeyValuePair<ScreenArrangementBase, SlideCue> assignment in assignments)
				{
					StageScreenAssignment stageScreenAssignment = stageAction.ScreenAssignments?.FirstOrDefaultBy((StageScreenAssignment a) => a.Screen.ID == assignment.Key.ID, (StageScreenAssignment a) => a.Screen.Name == assignment.Key.Name);
					if (stageScreenAssignment != null)
					{
						stageScreenAssignment.Layout = new Identifier(assignment.Value.ID, assignment.Value.Name);
					}
				}
				return stageAction;
			}
		}
		return null;
	}

	[return: NotNullIfNotNull("prop")]
	public static ActionBase? ToAction(this IPropCue? prop, PropTrigger? propTrigger = null)
	{
		if (prop == null)
		{
			return null;
		}
		PropAction propAction = new PropAction();
		propAction.SetIdentifier(prop.ID, prop.Name, prop.ParentCollectionID, prop.ParentCollectionName, propTrigger);
		return propAction;
	}

	public static ActionBase? ToAction(this TimerData timer)
	{
		if (timer == null)
		{
			return null;
		}
		TimerAction timerAction = new TimerAction();
		timerAction.SetIdentifier(timer);
		return timerAction;
	}

	public static ActionBase? ToAction(this ProPresenter.DO.Messages.Message message)
	{
		if (message == null)
		{
			return null;
		}
		if (ActionType.Message.ConstructAction(null, "Workspace") is MessageAction messageAction)
		{
			messageAction.SetMessage(message);
			return messageAction;
		}
		return null;
	}

	public static ActionBase? ToAction<T>(this IPlaylist<T>? playlist) where T : ProPresenterCue
	{
		if (playlist == null)
		{
			return null;
		}
		ActionType value = ((playlist is VisualPlaylist) ? ActionType.VisualPlaylist : ((playlist is AudioPlaylist) ? ActionType.AudioPlaylist : ((playlist is GeneralPlaylist) ? ActionType.LibraryPlaylist : ((playlist is PCOPlaylist) ? ActionType.LibraryPlaylist : ActionType.StageLayout))));
		if (new ActionType?(value).Value.ConstructAction(null, playlist.ContainerId) is PlaylistAction playlistAction)
		{
			playlistAction.SetIdentifier(playlist.ID, playlist.Name);
			return playlistAction;
		}
		return null;
	}

	public static ActionBase? ToAction(this ScreenArrangementBase screen)
	{
		if (screen == null)
		{
			return null;
		}
		if (ActionType.StageLayout.ConstructAction(null, "Stage") is StageAction stageAction)
		{
			if (stageAction.ScreenAssignments != null)
			{
				foreach (StageScreenAssignment screenAssignment in stageAction.ScreenAssignments)
				{
					if (screenAssignment.Screen.ID == screen.ID || screenAssignment.Screen.Name == screen.Name)
					{
						screenAssignment.Layout = new Identifier(Guid.Empty, string.Empty);
					}
				}
			}
			return stageAction;
		}
		return null;
	}

	public static void AssignData(this ActionBase action, object data, Action<ActionBase>? callback = null)
	{
		if (!(action is AudienceLookAction audienceLookAction))
		{
			if (!(action is TimerAction timerAction))
			{
				if (!(action is MessageAction messageAction))
				{
					if (!(action is PropAction propAction))
					{
						if (!(action is PlaylistAction playlistAction))
						{
							if (!(action is CommunicationAction communicationAction))
							{
								if (!(action is AudioInputAction audioInputAction))
								{
									if (!(action is MediaAction mediaAction))
									{
										if (!(action is SlideDestinationAction slideDestinationAction))
										{
											if (!(action is MacroAction macroAction))
											{
												if (!(action is ClearGroupAction clearGroupAction))
												{
													if (!(action is CaptureAction captureAction))
													{
														return;
													}
													if (data is CapturePreset capturePreset)
													{
														captureAction.SetIdentifier(capturePreset.ID, capturePreset.Name);
													}
													else if (data is CaptureType captureType)
													{
														captureAction.CaptureType = captureType;
														if (captureType == CaptureType.Stop)
														{
															callback?.Invoke(captureAction);
														}
													}
													else if (data is Identifier identifier)
													{
														captureAction.SetIdentifier(identifier.ID, identifier.Name);
													}
												}
												else if (data is ClearGroup clearGroup)
												{
													clearGroupAction.SetIdentifier(clearGroup.ID, clearGroup.Name);
												}
											}
											else if (data is ProPresenterMacro proPresenterMacro)
											{
												macroAction.SetIdentifier(proPresenterMacro.ID, proPresenterMacro.Name, proPresenterMacro.ParentCollectionID, proPresenterMacro.ParentCollectionName);
											}
										}
										else if (data is SlideDestinationType slideDestination)
										{
											slideDestinationAction.SetSlideDestination(slideDestination);
										}
									}
									else if (mediaAction.LiveVideo?.LiveVideo != null && data is LiveVideoInput input)
									{
										mediaAction.LiveVideo.LiveVideo.Input = input;
									}
								}
								else if (data is ProPresenter.DO.Audio.AudioInput index)
								{
									audioInputAction.SetIndex(index);
									callback?.Invoke(audioInputAction);
								}
							}
							else if (data is MIDICommand command)
							{
								communicationAction.Command = command;
								callback?.Invoke(communicationAction);
							}
						}
						else if (data is IPlaylist<MediaCue> playlist)
						{
							playlistAction.SetIdentifier(playlist.ID, playlist.Name);
							callback?.Invoke(playlistAction);
						}
					}
					else if (data is IPropCue propCue)
					{
						propAction.SetIdentifier(propCue.ID, propCue.Name, propCue.ParentCollectionID, propCue.ParentCollectionName, PropTrigger.Trigger);
					}
				}
				else if (data is ProPresenter.DO.Messages.Message message)
				{
					messageAction.SetIdentifier(message.ID, message.Name);
					callback?.Invoke(messageAction);
				}
			}
			else if (data is TimerData timerData)
			{
				timerAction.SetIdentifier(timerData.ID, timerData.Name);
				callback?.Invoke(timerAction);
			}
		}
		else if (data is AudienceLook audienceLook)
		{
			audienceLookAction.SetIdentifier(audienceLook.ID, audienceLook.Name);
		}
	}

	public static IAction ToAction(this Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType.Types.SlideTarget slideTarget)
	{
		SlideDestinationAction slideDestinationAction = new SlideDestinationAction();
		slideDestinationAction.SetSlideDestination(slideTarget.ToSlideDestinationType());
		return slideDestinationAction;
	}

	public static IAction? ToAction(this AudienceLook? look, IAudienceLookCollection audienceLooks)
	{
		if (look == null)
		{
			return null;
		}
		AudienceLookAction audienceLookAction = new AudienceLookAction(audienceLooks);
		audienceLookAction.SetIdentifier(look.ID, look.Name);
		return audienceLookAction;
	}

	public static IAction ToAction(this ClearType clearType)
	{
		return new ClearAction(clearType);
	}

	[return: NotNullIfNotNull("macro")]
	public static IAction? ToAction(this ProPresenterMacro? macro)
	{
		if (macro == null)
		{
			return null;
		}
		MacroAction macroAction = new MacroAction();
		macroAction.SetIdentifier(macro.ID, macro.Name, macro.ParentCollectionID, macro.ParentCollectionName);
		return macroAction;
	}

	public static IAction? ToAction(this ClearGroup? clearGroup)
	{
		if (clearGroup == null)
		{
			return null;
		}
		ClearGroupAction clearGroupAction = new ClearGroupAction();
		clearGroupAction.SetIdentifier(clearGroup.ID, clearGroup.Name);
		return clearGroupAction;
	}

	public static IAction? ToAction(this CapturePreset capturePreset)
	{
		if (ActionType.Capture.ConstructAction(null, "Workspace") is CaptureAction captureAction)
		{
			captureAction.SetIdentifier(capturePreset?.ID ?? Guid.Empty, capturePreset?.Name ?? string.Empty);
			return captureAction;
		}
		return null;
	}

	public static IAction? ToAction(this CaptureType captureType)
	{
		if (ActionType.Capture.ConstructAction(null, "Workspace") is CaptureAction captureAction)
		{
			captureAction.CaptureType = captureType;
			return captureAction;
		}
		return null;
	}

	public static IAction? ToAction(this ICapturePreset capturePreset)
	{
		if (ActionType.Capture.ConstructAction(null, "Workspace") is CaptureAction captureAction)
		{
			captureAction.SetIdentifier(capturePreset?.ID ?? Guid.Empty, capturePreset?.Name ?? string.Empty);
			return captureAction;
		}
		return null;
	}

	[IteratorStateMachine(typeof(_003CFindMedia_003Ed__19))]
	public static IEnumerable<(ClosedBezierPath element, MediaFill mediaFill)> FindMedia(this SlideAction slideAction)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFindMedia_003Ed__19(-2)
		{
			_003C_003E3__slideAction = slideAction
		};
	}

	[IteratorStateMachine(typeof(_003CFindTextMedia_003Ed__20))]
	public static IEnumerable<(ClosedBezierPath element, MediaTextFill mediaFill)> FindTextMedia(this SlideAction slideAction)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFindTextMedia_003Ed__20(-2)
		{
			_003C_003E3__slideAction = slideAction
		};
	}

	public static bool IsDataSelected(this IAction action, object data)
	{
		if (action is AudienceLookAction audienceLookAction && data is AudienceLook audienceLook)
		{
			return audienceLookAction.LookID == audienceLook.ID;
		}
		if (action is TimerAction timerAction && data is TimerData timerData)
		{
			return timerAction.TimerID == timerData.ID;
		}
		if (action is MessageAction messageAction && data is ProPresenter.DO.Messages.Message message)
		{
			return messageAction.MessageID == message.ID;
		}
		if (action is PropAction propAction)
		{
			if (data is IPropCue propCue)
			{
				return propAction.PropID == propCue.ID;
			}
			if (data is PropTriggerType propTriggerType)
			{
				return propAction.PropTriggerType == propTriggerType;
			}
		}
		else if (action is PlaylistAction playlistAction)
		{
			if (data is IPlaylist<MediaCue> playlist)
			{
				return playlistAction.PlaylistID == playlist.ID;
			}
			if (data is IPlaylist<ProPresenterCue> playlist2)
			{
				return playlistAction.PlaylistID == playlist2.ID;
			}
			if (data is ProPresenterCue proPresenterCue && playlistAction.PlaylistItemID != Guid.Empty && !string.IsNullOrEmpty(playlistAction.PlaylistItemName))
			{
				return playlistAction.PlaylistItemID == proPresenterCue.ID;
			}
		}
		else if (action is CommunicationAction communicationAction)
		{
			if (data is ProPresenter.DO.Communication.IDevice device)
			{
				return communicationAction.DeviceID == device.ID;
			}
			if (data is MIDICommand mIDICommand)
			{
				return communicationAction.Command == mIDICommand;
			}
		}
		else
		{
			if (action is AudioInputAction audioInputAction && data is ProPresenter.DO.Audio.AudioInput item)
			{
				return audioInputAction.Index == audioInputAction.AudioInputs?.IndexOf(item);
			}
			if (action is MediaAction mediaAction && mediaAction.LiveVideo?.LiveVideo?.Input != null && data is LiveVideoInput liveVideoInput)
			{
				return mediaAction.LiveVideo.LiveVideo.Input.Index == liveVideoInput.Index;
			}
			if (action is SlideDestinationAction slideDestinationAction && data is SlideDestinationType slideDestinationType)
			{
				return slideDestinationAction.SlideDestination == slideDestinationType;
			}
			if (action is MacroAction macroAction && data is ProPresenterMacro proPresenterMacro)
			{
				return macroAction.MacroID == proPresenterMacro.ID;
			}
			if (action is ClearGroupAction clearGroupAction && data is ClearGroup clearGroup)
			{
				return clearGroupAction.GroupID == clearGroup.ID;
			}
			if (action is CaptureAction captureAction)
			{
				if (data is CapturePreset capturePreset)
				{
					if (captureAction.Capture is CaptureStart captureStart)
					{
						return captureStart.PresetIdentifier.ID == capturePreset.ID;
					}
					return false;
				}
				if (data is CaptureType captureType)
				{
					return captureAction.CaptureType == captureType;
				}
				if (data is Identifier identifier)
				{
					if (captureAction.Capture is CaptureStart captureStart2)
					{
						return captureStart2.PresetIdentifier.ID == identifier.ID;
					}
					return false;
				}
			}
		}
		return false;
	}

	public static TimedPlayback.Types.Sequence.Types.SequenceItem? ToSequenceItem(this ITimeTriggerable triggerable, TimeSlice time, TimeSlice endTime, OutputDestination destination, string library, string presentation, double offset = 0.0, bool ignoreCompletionAction = false)
	{
		TimedPlayback.Types.Sequence.Types.SequenceItem item = new TimedPlayback.Types.Sequence.Types.SequenceItem();
		bool ignoreCompletionAction2 = ignoreCompletionAction;
		TimedPlayback.Types.Sequence.Types.SequenceItem sequenceItem = SetSequenceItemItem(item, triggerable, null, ignoreCompletionAction2);
		if (sequenceItem != null)
		{
			return SetSequenceItemDetails(sequenceItem, time, endTime, destination, library, presentation, offset);
		}
		return null;
	}

	public static TimedPlayback.Types.Sequence.Types.SequenceItem? ToSequenceItem(this ITimeTriggerable triggerable, TimeSlice time, TimeSlice endTime, OutputDestination destination, Guid playlistID, Guid itemID, double offset = 0.0, Guid? sequenceItemID = null, bool ignoreCompletionAction = false)
	{
		TimedPlayback.Types.Sequence.Types.SequenceItem sequenceItem = SetSequenceItemItem(new TimedPlayback.Types.Sequence.Types.SequenceItem(), triggerable, sequenceItemID, ignoreCompletionAction);
		if (sequenceItem != null)
		{
			return SetSequenceItemDetails(sequenceItem, time, endTime, destination, playlistID, itemID, offset);
		}
		return null;
	}

	private static TimedPlayback.Types.Sequence.Types.SequenceItem? SetSequenceItemItem(TimedPlayback.Types.Sequence.Types.SequenceItem item, ITimeTriggerable triggerable, Guid? sequenceItemID = null, bool ignoreCompletionAction = false)
	{
		item.Identifier = (sequenceItemID ?? triggerable.ID).ToUUID();
		ITriggerable item2 = triggerable.Item;
		if (!(item2 is SlideCue slideCue))
		{
			if (!(item2 is ActionBase actionBase))
			{
				return null;
			}
			item.Action = actionBase.Serialize();
		}
		else
		{
			item.Cue = slideCue.Serialize();
			if (ignoreCompletionAction)
			{
				item.Cue.CompletionActionType = Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType.AfterAction;
				item.Cue.CompletionActionUuid = null;
				item.Cue.CompletionTargetType = Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.None;
				item.Cue.CompletionTargetUuid = null;
			}
		}
		return item;
	}

	private static TimedPlayback.Types.Sequence.Types.SequenceItem? SetSequenceItemDetails(TimedPlayback.Types.Sequence.Types.SequenceItem item, TimeSlice time, TimeSlice endTime, OutputDestination destination, string library, string presentation, double offset = 0.0)
	{
		if (item != null)
		{
			item.Time = time.TotalSeconds + offset;
			item.ContentDestination = destination.ToProtoDestination();
			item.TriggerSource = new TriggerSource
			{
				LibraryLocation = new TriggerSource.Types.Library
				{
					Path = (library ?? string.Empty),
					PresentationName = (presentation ?? string.Empty)
				}
			};
			item.EndTime = endTime.TotalSeconds + offset;
		}
		return item;
	}

	private static TimedPlayback.Types.Sequence.Types.SequenceItem? SetSequenceItemDetails(TimedPlayback.Types.Sequence.Types.SequenceItem item, TimeSlice time, TimeSlice endTime, OutputDestination destination, Guid playlistID, Guid itemID, double offset = 0.0)
	{
		if (item != null)
		{
			item.Time = time.TotalSeconds + offset;
			item.ContentDestination = destination.ToProtoDestination();
			item.TriggerSource = new TriggerSource
			{
				PlaylistLocation = new TriggerSource.Types.Playlist
				{
					Identifier = playlistID.ToUUID(),
					ItemIdentifier = itemID.ToUUID()
				}
			};
			item.EndTime = endTime.TotalSeconds + offset;
		}
		return item;
	}
}
