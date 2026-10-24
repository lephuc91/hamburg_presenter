using System;
using System.ComponentModel;
using Pro.Common.Collections;
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
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Actions;

public class StageAction : ActionBase, IScrimSource, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private IStageScreenAssignments _screenAssignments;

	private readonly IImmutableObservableCollection<ScreenArrangementBase> _stageScreens;

	private readonly StagePresentation _stagePresentation;

	public override ActionType ActionType => ActionType.StageLayout;

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => true;

	public ListViewType ListViewType => ListViewType.Content;

	public IStageScreenAssignments ScreenAssignments
	{
		get
		{
			return _screenAssignments;
		}
		private set
		{
			SetValue("ScreenAssignments", ref _screenAssignments, value, delegate(IStageScreenAssignments o, IStageScreenAssignments n)
			{
				o.CollectionModified -= ScreenAssignments_CollectionModified;
				n.CollectionModified += ScreenAssignments_CollectionModified;
			});
		}
	}

	public override bool IsValid => ScreenAssignments.IsValid;

	protected override bool CanRename => false;

	protected sealed override string DefaultName => LocalizedStrings.Get("ACTION_TYPE_STAGE_title");

	public TimelineItemType TimelineItemType => TimelineItemType.Actions;

	public override string ContainerId => "Stage";

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, StageAction left, Pro.Entity.IAction right, Action<Pro.DO.Triggering.IAction, Pro.Entity.IAction> onEntityActionTypeChanged)
	{
		Pro.Entity.IAction.Types.IStageLayoutType stageLayoutType = (right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.IStage)?.Value;
		if (stageLayoutType == null)
		{
			Pro.Entity.IAction.Types.IActionTypeData.IStage stage = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.IStage>();
			stageLayoutType = entityFactory.Create<Pro.Entity.IAction.Types.IStageLayoutType>();
			stage.Set(stageLayoutType);
			right.ActionTypeData.Set(stage);
		}
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, onEntityActionTypeChanged);
		ObjectBinder<StageAction, Pro.Entity.IAction.Types.IStageLayoutType> binder = new ObjectBinder<StageAction, Pro.Entity.IAction.Types.IStageLayoutType>(left, stageLayoutType).Bind((StageAction l) => l.ScreenAssignments.WhenCollectionChanges(), (Pro.Entity.IAction.Types.IStageLayoutType r) => r.StageScreenAssignments.WhenCollectionChanges, delegate(StageAction l, Pro.Entity.IAction.Types.IStageLayoutType r)
		{
			r.StageScreenAssignments.SynchronizeFrom(l.ScreenAssignments, delegate(StageScreenAssignment m, IStage.Types.IScreenAssignment e)
			{
				Guid iD = m.Screen.ID;
				Guid? value = e.Screen.Value.ParameterUuid.Value;
				return iD == value;
			}, delegate(StageScreenAssignment m)
			{
				IStage.Types.IScreenAssignment screenAssignment = entityFactory.Create<IStage.Types.IScreenAssignment>();
				ObjectBinder<StageScreenAssignment, IStage.Types.IScreenAssignment> objectBinder2 = CreateScreenAssignmentBinder(scheduler, m, screenAssignment);
				objectBinder2.InitializeRightFromLeft();
				screenAssignment.RegisterLinkedDisposable(objectBinder2);
				return screenAssignment;
			});
		}, delegate(Pro.Entity.IAction.Types.IStageLayoutType r, StageAction l)
		{
			r.StageScreenAssignments.Items.SynchronizeTo(l.ScreenAssignments, delegate(IStage.Types.IScreenAssignment e, StageScreenAssignment m)
			{
				Guid iD2 = m.Screen.ID;
				Guid? value2 = e.Screen.Value.ParameterUuid.Value;
				return iD2 == value2;
			}, delegate(IStage.Types.IScreenAssignment e, int i)
			{
				Identifier screen = new Identifier(e.Screen.Value.ParameterUuid.ToGuidOrEmpty(), e.Screen.Value.ParameterName.Value ?? string.Empty);
				Identifier layout = ((!e.Layout.Value.ParameterUuid.Value.HasValue) ? null : new Identifier(e.Layout.Value.ParameterUuid.ToGuidOrEmpty(), e.Layout.Value.ParameterName.Value ?? string.Empty));
				StageScreenAssignment stageScreenAssignment = new StageScreenAssignment(screen, layout);
				ObjectBinder<StageScreenAssignment, IStage.Types.IScreenAssignment> objectBinder3 = CreateScreenAssignmentBinder(scheduler, stageScreenAssignment, e);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				l.ScreenAssignments.InsertAssignment(stageScreenAssignment, i);
			}, delegate(int from, int to)
			{
				l.ScreenAssignments.MoveAssignment(from, to);
			}, delegate(int i)
			{
				StageScreenAssignment assignment = l.ScreenAssignments[i];
				l.ScreenAssignments.RemoveAssignment(assignment);
			});
		}, null, scheduler.Scheduler);
		objectBinder.DoOnInitializeRightFromLeft(binder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(binder.InitializeLeftFromRight).RegisterChildDisposable(() => binder);
		return objectBinder;
	}

	public static ObjectBinder<StageScreenAssignment, IStage.Types.IScreenAssignment> CreateScreenAssignmentBinder(IUiScheduler scheduler, StageScreenAssignment left, IStage.Types.IScreenAssignment right)
	{
		return new ObjectBinder<StageScreenAssignment, IStage.Types.IScreenAssignment>(left, right).Bind((StageScreenAssignment l) => l.WhenPropertyChanges("Screen"), (IStage.Types.IScreenAssignment r) => r.Screen.WhenAnyValueChanges, delegate(StageScreenAssignment l, IStage.Types.IScreenAssignment r)
		{
			r.Screen.Value.ParameterUuid.Set(l.Screen.ID);
			r.Screen.Value.ParameterName.Set(l.Screen.Name);
		}, delegate(IStage.Types.IScreenAssignment r, StageScreenAssignment l)
		{
			l.Screen = new Identifier(r.Screen.Value.ParameterUuid.ToGuidOrEmpty(), r.Screen.Value.ParameterName.Value ?? string.Empty);
		}).Bind((StageScreenAssignment l) => l.WhenPropertyChanges("Layout"), (IStage.Types.IScreenAssignment r) => r.Layout.WhenAnyValueChanges, delegate(StageScreenAssignment l, IStage.Types.IScreenAssignment r)
		{
			r.Layout.Value.ParameterUuid.Set(l.Layout?.ID);
			r.Layout.Value.ParameterName.Set(l.Layout?.Name);
		}, delegate(IStage.Types.IScreenAssignment r, StageScreenAssignment l)
		{
			if (r.Layout.Value.ParameterUuid.Value.HasValue)
			{
				l.Layout = new Identifier(r.Layout.Value.ParameterUuid.Value.Value, r.Layout.Value.ParameterName.Value ?? string.Empty);
			}
			else
			{
				l.Layout = null;
			}
		}, null, scheduler.Scheduler);
	}

	public StageAction(IImmutableObservableCollection<ScreenArrangementBase> stageScreens, StagePresentation stagePresentation)
	{
		_stageScreens = stageScreens;
		_stagePresentation = stagePresentation;
		base.Name = DefaultName;
		_screenAssignments = new StageScreenAssignments(stageScreens, stagePresentation);
		_screenAssignments.CollectionModified += ScreenAssignments_CollectionModified;
	}

	private void ScreenAssignments_CollectionModified()
	{
		OnDataModified();
		OnPropertyChanged("IsValid");
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new StageAction(_stageScreens, _stagePresentation));
	}

	protected override T CopyProperties<T>(T action)
	{
		base.CopyProperties(action);
		if (action is StageAction stageAction)
		{
			stageAction.ScreenAssignments = ScreenAssignments.Clone();
		}
		return action;
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.Stage = new Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType();
		action.Stage.StageScreenAssignments.AddRange(ScreenAssignments.Serialize());
		return action;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		base.Deserialize(data, applicationData, containerId);
		Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType stage = data.Stage;
		if (stage != null)
		{
			ScreenAssignments.Deserialize(stage.StageScreenAssignments, _stageScreens);
		}
	}

	protected override void OnUndoStackChanged(UndoStack undoStack)
	{
		base.OnUndoStackChanged(undoStack);
		ScreenAssignments.UndoStack = undoStack;
	}
}
