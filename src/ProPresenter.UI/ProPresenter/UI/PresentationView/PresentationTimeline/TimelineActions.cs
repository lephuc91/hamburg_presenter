using System.Collections.Generic;
using System.Linq;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Presentation;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

public class TimelineActions : NotifyPropertyChangedBase, IActionRepository
{
	private readonly Timeline _timeline;

	private readonly IEnumerable<IAction> _actions;

	public IEnumerable<IAction> Actions => (from i in _actions.OfType<ITimelineItem>()
		where i.TimelineItemType == TimelineItemType.Actions
		select i).OfType<IAction>();

	public TimeSlice TargetTime { get; set; } = TimeSlice.Zero;

	public TimelineActions(Timeline timeline, IEnumerable<IAction>? actions = null)
	{
		_timeline = timeline;
		_actions = actions ?? _timeline.Actions;
	}

	public void AddAction(IAction? action, bool addMediaReferences = false)
	{
		if (action is ITimelineItem item)
		{
			_timeline.AddItem(new TimelineItemInfo(item, TargetTime, action.Name, _timeline));
		}
	}

	public bool CanAddAction(object data)
	{
		return _timeline.CanAddAction(data);
	}

	public bool CanReplace(object data)
	{
		return _timeline.CanReplace(data);
	}

	public void RemoveAction(IAction action)
	{
		_timeline.RemoveAction(action);
	}

	public void RemoveActions(IEnumerable<IAction> actions)
	{
		_timeline.RemoveActions(actions);
	}

	public bool CanAssign(object data, IAction? action)
	{
		return this.CanAssignData(data, action);
	}

	public void InsertActions(IEnumerable<IAction> actions, int index, bool addMediaReferences = false)
	{
		foreach (ITimelineItem item in actions.OfType<ITimelineItem>())
		{
			_timeline.AddItem(new TimelineItemInfo(item, TargetTime, item.Name, _timeline));
		}
	}
}
