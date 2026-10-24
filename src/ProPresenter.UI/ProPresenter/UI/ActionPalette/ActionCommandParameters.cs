using System.Collections.Generic;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using ProPresenter.UI.Thumbnails;

namespace ProPresenter.UI.ActionPalette;

public class ActionCommandParameters
{
	public Thumbnail? TargetThumbnail { get; }

	public bool DroppedBefore { get; }

	public bool DroppedOutside { get; }

	public IEnumerable<IAction>? Actions { get; }

	public IEnumerable<ActionType>? ActionTypes { get; }

	public ActionCommandParameters(Thumbnail? targetThumbnail, bool droppedBefore, bool droppedOutside, IEnumerable<IAction>? actions = null, IEnumerable<ActionType>? actionTypes = null)
	{
		TargetThumbnail = targetThumbnail;
		DroppedBefore = droppedBefore;
		DroppedOutside = droppedOutside;
		Actions = actions?.NonNull();
		ActionTypes = actionTypes;
	}
}
