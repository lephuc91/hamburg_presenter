using System.ComponentModel;
using Pro.Common.Components.Reversibility;
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

public class SlideDestinationAction : ActionBase, IScrimSource, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private SlideDestinationType _slideTarget;

	public override ActionType ActionType => ActionType.SlideDestination;

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => true;

	public ListViewType ListViewType => ListViewType.Content;

	public SlideDestinationType SlideDestination
	{
		get
		{
			return _slideTarget;
		}
		private set
		{
			SetValue("SlideDestination", ref _slideTarget, value, base.OnDataModified);
		}
	}

	protected override bool CanRename => false;

	protected override string DefaultName => LocalizedStrings.Get("ACTION_TYPE_SLIDE_DESTINATION_title");

	public TimelineItemType TimelineItemType => TimelineItemType.Actions;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, SlideDestinationAction left, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData.ISlideDestination slideDestination = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.ISlideDestination;
		if (slideDestination == null)
		{
			slideDestination = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.ISlideDestination>();
			right.ActionTypeData.Set(slideDestination);
		}
		ObjectBinder<SlideDestinationAction, Pro.Entity.IAction.Types.ISlideDestinationType> slideDestinationActionBinder = new ObjectBinder<SlideDestinationAction, Pro.Entity.IAction.Types.ISlideDestinationType>(left, slideDestination.Value);
		slideDestinationActionBinder.Bind((SlideDestinationAction l) => l.WhenPropertyChanges("SlideDestination"), (Pro.Entity.IAction.Types.ISlideDestinationType r) => r.SlideTarget.WhenValueChanges, delegate(SlideDestinationAction l, Pro.Entity.IAction.Types.ISlideDestinationType r)
		{
			r.SlideTarget.Set(l.SlideDestination.ToEntitySlideTarget());
		}, delegate(Pro.Entity.IAction.Types.ISlideDestinationType r, SlideDestinationAction l)
		{
			l.SlideDestination = r.SlideTarget.Value.ToSlideDestinationType();
		});
		objectBinder.DoOnInitializeRightFromLeft(slideDestinationActionBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(slideDestinationActionBinder.InitializeLeftFromRight).RegisterChildDisposable(() => slideDestinationActionBinder);
		return objectBinder;
	}

	public void SetSlideDestination(SlideDestinationType slideDestination)
	{
		SlideDestinationType oldValue = SlideDestination;
		base.UndoStack?.Commit(UndoActionTypes.ActionSetSlideDestination.ToAction(), delegate
		{
			SetSlideDestination(oldValue);
		}, delegate
		{
			SetSlideDestination(slideDestination);
		}, null, null, autoFinalize: true);
		SlideDestination = ((SlideDestination != slideDestination) ? slideDestination : SlideDestinationType.NoChange);
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new SlideDestinationAction());
	}

	protected override T CopyProperties<T>(T action)
	{
		if (action is SlideDestinationAction slideDestinationAction)
		{
			slideDestinationAction.SlideDestination = SlideDestination;
		}
		return base.CopyProperties(action);
	}

	public override Action Serialize()
	{
		Action action = base.Serialize();
		action.SlideDestination = new Action.Types.SlideDestinationType
		{
			SlideTarget = SlideDestination.ToProtoSlideTarget()
		};
		return action;
	}

	public override void Deserialize(Action data, ApplicationData? applicationData, string containerId)
	{
		base.Deserialize(data, applicationData, containerId);
		if (data?.SlideDestination != null)
		{
			SlideDestination = data.SlideDestination.SlideTarget.ToSlideDestinationType();
		}
	}
}
