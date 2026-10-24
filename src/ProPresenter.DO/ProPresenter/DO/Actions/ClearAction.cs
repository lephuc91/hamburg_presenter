using System.ComponentModel;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Actions;

public class ClearAction : ActionBase, IScrimSource, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private ClearType _clearType;

	public override ActionType ActionType => ActionType.Clear;

	public ClearType ClearType
	{
		get
		{
			return _clearType;
		}
		private set
		{
			SetValue("ClearType", ref _clearType, value);
		}
	}

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => false;

	public ListViewType ListViewType => ListViewType.Content;

	protected override string DefaultName => LocalizedStrings.Get(ClearType);

	public TimelineItemType TimelineItemType => TimelineItemType.Actions;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, ClearAction left, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> actionBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData value = right.ActionTypeData.Value;
		Pro.Entity.IAction.Types.IActionTypeData.IClear clearEntity = value as Pro.Entity.IAction.Types.IActionTypeData.IClear;
		if (clearEntity == null)
		{
			clearEntity = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.IClear>();
			right.ActionTypeData.Set(clearEntity);
		}
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> clearActionBinder = new ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction>(left, right);
		clearActionBinder.Bind((Pro.DO.Triggering.IAction l) => l.WhenPropertyChanges("ClearType"), (Pro.Entity.IAction r) => clearEntity.WhenValueChanges, delegate
		{
			Pro.Entity.IAction.Types.ClearType value2 = left.ClearType.ToEntityClearType();
			clearEntity.Set(value2);
		}, delegate
		{
			left.ClearType = clearEntity.Value.ToClearType();
		}).RegisterChildDisposable(() => actionBinder);
		actionBinder.DoOnInitializeRightFromLeft(clearActionBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(clearActionBinder.InitializeLeftFromRight).RegisterChildDisposable(() => clearActionBinder);
		return actionBinder;
	}

	public ClearAction(ClearType clearType)
	{
		base.Name = LocalizedStrings.Get(clearType);
		ClearType = clearType;
	}

	public ClearAction()
		: this(ClearType.All)
	{
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new ClearAction(ClearType));
	}

	public override void Deserialize(Action data, ApplicationData? applicationData, string containerId)
	{
		base.Deserialize(data, applicationData, containerId);
		if (data.Clear != null)
		{
			ClearType = data.Clear.TargetLayer.ToClearType();
			if (data.Clear.ContentDestination == Action.Types.ContentDestination.Announcements)
			{
				ClearType = ClearType.Announcement;
			}
		}
	}

	public override Action Serialize()
	{
		Action action = base.Serialize();
		action.Clear = new Action.Types.ClearType
		{
			TargetLayer = ClearType.ToProtoClearTargetLayer(out var destination),
			ContentDestination = destination
		};
		return action;
	}
}
