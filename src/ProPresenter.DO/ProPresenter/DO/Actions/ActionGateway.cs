using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions.Capture;
using ProPresenter.DO.Audio;
using ProPresenter.DO.Capture;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Cues;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Actions;

public class ActionGateway : IActionGateway
{
	private readonly IEnumerable<IAction> _actions;

	private readonly IAudioInputProvider _audioInputProvider;

	public ActionGateway(IEnumerable<IAction> actions, IAudioInputProvider? audioInputProvider = null)
	{
		_actions = actions;
		_audioInputProvider = audioInputProvider ?? new SlideAudioInputProvider(null, () => _actions);
	}

	public void HandleIncoming(IAction action, out IEnumerable<IAction> actionsToReplace)
	{
		IAction[] actions = _actions.Except(action).ToArray();
		List<ActionBase> replacements = new List<ActionBase>();
		actionsToReplace = replacements;
		if (!(action is MediaAction mediaAction2))
		{
			if (!(action is PlaylistAction playlistAction2))
			{
				if (!(action is AudienceLookAction action2))
				{
					if (!(action is StageAction stageAction2))
					{
						ClearAction clearAction = action as ClearAction;
						if (clearAction == null)
						{
							AudioInputAction audioInputAction = action as AudioInputAction;
							if (audioInputAction == null)
							{
								MessageAction messageAction = action as MessageAction;
								if (messageAction == null)
								{
									if (!(action is SlideDestinationAction action3))
									{
										TimerAction timerAction = action as TimerAction;
										if (timerAction == null)
										{
											PropAction propAction = action as PropAction;
											if (propAction == null)
											{
												MacroAction macroAction = action as MacroAction;
												if (macroAction == null)
												{
													ClearGroupAction clearGroupAction = action as ClearGroupAction;
													if (clearGroupAction == null)
													{
														if (action is CaptureAction action4)
														{
															handleAction<CaptureAction>(action4);
														}
													}
													else
													{
														handleAction<ClearGroupAction>(clearGroupAction, (ClearGroupAction c) => c.GroupID == clearGroupAction.GroupID);
													}
												}
												else
												{
													handleAction<MacroAction>(macroAction, (MacroAction m) => m.MacroID == macroAction.MacroID);
												}
											}
											else
											{
												handleAction<PropAction>(propAction, (PropAction p) => p.PropID == propAction.PropID);
											}
										}
										else
										{
											handleAction<TimerAction>(timerAction, (TimerAction t) => t.TimerID == timerAction.TimerID);
										}
									}
									else
									{
										handleAction<SlideDestinationAction>(action3);
									}
								}
								else
								{
									handleAction<MessageAction>(messageAction, (MessageAction m) => m.MessageID == messageAction.MessageID);
								}
							}
							else
							{
								handleAction<AudioInputAction>(audioInputAction, (AudioInputAction a) => a.Index == audioInputAction.Index);
							}
						}
						else
						{
							handleAction<ClearAction>(clearAction, (ClearAction a) => a.ClearType == clearAction.ClearType);
						}
					}
					else
					{
						handleStageAction(stageAction2);
					}
				}
				else
				{
					handleAction<AudienceLookAction>(action2);
				}
			}
			else
			{
				handlePlaylistAction(playlistAction2);
			}
		}
		else
		{
			handleMediaAction(mediaAction2);
		}
		void handleAction<T>(T action, Func<T, bool>? compare = null) where T : notnull, ActionBase
		{
			replace(from a in actions.OfType<T>()
				where compare?.Invoke(a) ?? true
				select a);
		}
		void handleMediaAction(MediaAction mediaAction)
		{
			replace(actions.OfType<MediaAction>().Where(mediaMatches));
			if (mediaAction.IsGraphicMedia)
			{
				replace(actions.OfType<VisualPlaylistAction>());
			}
			else if (mediaAction.IsAudioMedia)
			{
				AudioMedia? audioMedia = mediaAction.AudioMedia;
				if (audioMedia != null && audioMedia.AudioType == AudioType.AudioTrack)
				{
					replace(actions.OfType<AudioPlaylistAction>());
				}
			}
			bool mediaMatches(MediaAction a)
			{
				if (a.Media is AudioMedia && mediaAction.Media is AudioMedia)
				{
					AudioMedia? audioMedia2 = a.AudioMedia;
					if (audioMedia2 != null && audioMedia2.AudioType == AudioType.AudioTrack)
					{
						AudioMedia? audioMedia3 = mediaAction.AudioMedia;
						if (audioMedia3 == null)
						{
							return false;
						}
						return audioMedia3.AudioType == AudioType.AudioTrack;
					}
					return false;
				}
				bool num = a.IsGraphicMedia && mediaAction.IsGraphicMedia;
				bool flag = a.Media.MediaType == mediaAction.Media.MediaType;
				return num || flag;
			}
		}
		void handlePlaylistAction(PlaylistAction playlistAction)
		{
			replace(actions.Where((IAction a) => a.GetType() == playlistAction.GetType()));
			switch (playlistAction.ActionType)
			{
			case ActionType.VisualPlaylist:
				replace(from a in actions.OfType<MediaAction>()
					where a.IsGraphicMedia
					select a);
				break;
			case ActionType.AudioPlaylist:
				replace(from a in actions.OfType<MediaAction>()
					where a.IsAudioMedia
					select a);
				break;
			}
		}
		void handleStageAction(StageAction stageAction)
		{
			IEnumerable<StageAction> enumerable = actions.OfType<StageAction>();
			IEnumerable<StageScreenAssignment> source = stageAction.ScreenAssignments?.Where((StageScreenAssignment a) => (object)a.Layout == null) ?? Enumerable.Empty<StageScreenAssignment>();
			StageScreenAssignment[] array = (from a in enumerable.SelectMany(delegate(StageAction a)
				{
					IEnumerable<StageScreenAssignment> screenAssignments = a.ScreenAssignments;
					return screenAssignments ?? Enumerable.Empty<StageScreenAssignment>();
				})
				where (object)a.Layout != null
				select a).ToArray();
			foreach (StageScreenAssignment assignment in array)
			{
				StageScreenAssignment stageScreenAssignment = source.FirstOrDefault((StageScreenAssignment a) => a.Screen.ID == assignment.Screen.ID);
				if (stageScreenAssignment != null && (object)assignment.Layout != null)
				{
					stageScreenAssignment.Layout = new Identifier(assignment.Layout.ID, assignment.Layout.Name);
				}
			}
			replace(enumerable);
		}
		void replace(IEnumerable<IAction> with)
		{
			replacements.AddRange(with);
		}
	}

	public void HandleOutgoing(IAction? action)
	{
		if (!(action is MediaAction mediaAction))
		{
			return;
		}
		foreach (SlideAction item in _actions.OfType<SlideAction>().NonNull())
		{
			if (item.Label != null && mediaAction.Name == item.Label.Text)
			{
				item.Label = null;
			}
		}
	}

	public bool CanAddAction(object? data)
	{
		if (!(data is ActionType actionType))
		{
			if (!(data is ClearType clearType))
			{
				if (!(data is Message message))
				{
					if (!(data is IPropCue prop))
					{
						if (!(data is ActionBase action))
						{
							if (!(data is IPlaylist<MediaCue> playlist))
							{
								if (!(data is AudioInput audioInput))
								{
									if (!(data is LiveVideoInput input))
									{
										if (!(data is ProPresenterMacro macro))
										{
											if (!(data is ClearGroup clearGroup))
											{
												if (!(data is TimerData timer))
												{
													if (!(data is CapturePreset capturePreset))
													{
														if (!(data is CaptureType captureType))
														{
															if (data is MediaType || data is MediaCue || data is FileInfo)
															{
																return true;
															}
															throw new NotSupportedException();
														}
														return CanAddAction(captureType);
													}
													return CanAddAction(capturePreset);
												}
												return CanAddAction(timer);
											}
											return CanAddAction(clearGroup);
										}
										return CanAddAction(macro);
									}
									return CanAddAction(input);
								}
								return CanAddAction(audioInput);
							}
							return CanAddAction(playlist);
						}
						return CanAddAction(action);
					}
					return CanAddAction(prop.ToAction(null));
				}
				return CanAddAction(message);
			}
			return CanAddAction(clearType);
		}
		return CanAddAction(actionType);
	}

	private bool CanAddAction(ActionType actionType)
	{
		switch (actionType)
		{
		case ActionType.StageLayout:
		case ActionType.Slide:
		case ActionType.PropSlide:
		case ActionType.AudienceLook:
		case ActionType.SlideDestination:
		case ActionType.Capture:
			return _actions.None((IAction a) => a.ActionType == actionType);
		case ActionType.AudioInput:
			return _audioInputProvider?.GetAvailableInputs().Any() ?? false;
		case ActionType.LiveVideo:
			return _actions.OfType<MediaAction>().None((MediaAction m) => m.LiveVideo != null);
		default:
			return true;
		}
	}

	private bool CanAddAction(ClearType clearType)
	{
		return CanAddAction(clearType.ToAction());
	}

	private bool CanAddAction(Message message)
	{
		return CanAddAction(message.ToAction());
	}

	private bool CanAddAction(IPlaylist<MediaCue> playlist)
	{
		if (playlist.Type != PlaylistType.Group)
		{
			return CanAddAction(playlist.ToAction());
		}
		return false;
	}

	private bool CanAddAction(AudioInput audioInput)
	{
		return _actions.OfType<AudioInputAction>().None((AudioInputAction a) => a.Index == a.AudioInputs?.IndexOf(audioInput));
	}

	private bool CanAddAction(LiveVideoInput input)
	{
		return _actions.OfType<MediaAction>().None((MediaAction m) => m.LiveVideo?.LiveVideo?.Input?.Index == input.Index);
	}

	private bool CanAddAction(ProPresenterMacro macro)
	{
		return CanAddAction(macro.ToAction());
	}

	private bool CanAddAction(TimerData timer)
	{
		if (ActionType.Timer.ConstructAction(null, "") is TimerAction timerAction)
		{
			timerAction.SetIdentifier(timer);
			return CanAddAction(timerAction);
		}
		return false;
	}

	private bool CanAddAction(ClearGroup clearGroup)
	{
		return CanAddAction(clearGroup.ToAction());
	}

	private bool CanAddAction(CapturePreset capturePreset)
	{
		return CanAddAction(capturePreset.ToAction());
	}

	private bool CanAddAction(CaptureType captureType)
	{
		return CanAddAction(captureType.ToAction());
	}

	private bool CanAddAction(ActionBase? action)
	{
		if (action == null)
		{
			return false;
		}
		ClearAction clearAction = action as ClearAction;
		if (clearAction == null)
		{
			MessageAction messageAction = action as MessageAction;
			if (messageAction == null)
			{
				PlaylistAction playlistAction = action as PlaylistAction;
				if (playlistAction == null)
				{
					PropAction propAction = action as PropAction;
					if (propAction == null)
					{
						MacroAction macroAction = action as MacroAction;
						if (macroAction == null)
						{
							AudienceLookAction audienceLookAction = action as AudienceLookAction;
							if (audienceLookAction == null)
							{
								TimerAction timerAction = action as TimerAction;
								if (timerAction == null)
								{
									ClearGroupAction clearGroupAction = action as ClearGroupAction;
									if (clearGroupAction == null)
									{
										if (action is CaptureAction)
										{
											return _actions.OfType<CaptureAction>().Empty();
										}
										return true;
									}
									return _actions.OfType<ClearGroupAction>().None((ClearGroupAction c) => c.GroupID == clearGroupAction.GroupID);
								}
								return _actions.OfType<TimerAction>().None((TimerAction t) => t.TimerID == timerAction.TimerID);
							}
							return _actions.OfType<AudienceLookAction>().None((AudienceLookAction l) => l.LookID == audienceLookAction.LookID);
						}
						return _actions.OfType<MacroAction>().None((MacroAction m) => m.MacroID == macroAction.MacroID);
					}
					return _actions.OfType<PropAction>().None((PropAction p) => p.PropID == propAction.PropID);
				}
				return _actions.OfType<PlaylistAction>().None((PlaylistAction p) => p.ActionType == playlistAction.ActionType);
			}
			return _actions.OfType<MessageAction>().None((MessageAction m) => m.MessageID == messageAction.MessageID);
		}
		return _actions.OfType<ClearAction>().None((ClearAction c) => c.ClearType == clearAction.ClearType);
	}
}
