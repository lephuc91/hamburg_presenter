using System;
using System.Collections.Generic;
using System.Linq;
using Pro.DO.Triggering;
using Pro.Text.Fills;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Actions;

public class ActionValidator : IActionValidator
{
	private readonly IWarningMessageStrategy _messageStrategy;

	public ActionValidator(IWarningMessageStrategy? messageStrategy = null)
	{
		_messageStrategy = messageStrategy ?? new WarningMessageStrategy();
	}

	public bool Validate(IEnumerable<IAction> actions, out string warningMessage)
	{
		warningMessage = string.Join(Environment.NewLine, actions.Where((IAction a) => !a.IsValid).Select(GetWarningMessage));
		return actions.All((IAction a) => a.IsValid);
	}

	private string GetWarningMessage(IAction action)
	{
		if (!(action is MediaAction mediaAction))
		{
			if (!(action is StageAction))
			{
				if (!(action is TimerAction))
				{
					if (!(action is AudienceLookAction audienceLookAction))
					{
						if (!(action is CommunicationAction))
						{
							if (!(action is PropAction))
							{
								if (!(action is MessageAction))
								{
									if (!(action is AudioInputAction))
									{
										if (!(action is PlaylistAction))
										{
											if (!(action is SlideAction slideAction))
											{
												if (!(action is MacroAction))
												{
													if (!(action is ClearGroupAction))
													{
														if (action is CaptureAction captureAction)
														{
															return _messageStrategy.Capture(captureAction.Capture);
														}
														return _messageStrategy.Default(action.ActionType);
													}
													return _messageStrategy.ClearGroup();
												}
												return _messageStrategy.Macro();
											}
											return _messageStrategy.MediaFill(GetInvalidMediaFillElements(slideAction).FirstOrDefault());
										}
										return _messageStrategy.Playlist();
									}
									return _messageStrategy.AudioInput();
								}
								return _messageStrategy.Message();
							}
							return _messageStrategy.Prop();
						}
						return _messageStrategy.Communication();
					}
					return _messageStrategy.Look(audienceLookAction.LookName);
				}
				return _messageStrategy.Timer();
			}
			return _messageStrategy.Stage();
		}
		return _messageStrategy.Media(mediaAction.LiveVideo?.LiveVideo?.Input?.LongName ?? mediaAction.Name);
	}

	private static IEnumerable<string> GetInvalidMediaFillElements(SlideAction slideAction)
	{
		if (slideAction == null)
		{
			return Enumerable.Empty<string>();
		}
		IEnumerable<string> first = from e in slideAction.FindMedia()
			where !e.mediaFill.IsValid
			select e.element.Name;
		IEnumerable<string> second = from e in slideAction.FindTextMedia()
			where !e.mediaFill.IsValid
			select e.element.Name;
		return first.Union(second);
	}
}
