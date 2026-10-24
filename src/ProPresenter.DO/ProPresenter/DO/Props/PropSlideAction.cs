using System;
using System.Diagnostics.CodeAnalysis;
using System.Reactive;
using System.Reactive.Linq;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Transitions;

namespace ProPresenter.DO.Props;

public class PropSlideAction : SlideAction
{
	private bool _autoClearEnabled;

	private double _autoClearDuration;

	public bool AutoClearEnabled
	{
		get
		{
			return _autoClearEnabled;
		}
		set
		{
			SetValue("AutoClearEnabled", ref _autoClearEnabled, value, delegate(bool o, bool n)
			{
				base.UndoStack?.Commit(UndoActionTypes.AutoClearEnabled.ToAction(), this, "AutoClearEnabled", o, n);
				OnDataModified();
			});
		}
	}

	public double AutoClearDuration
	{
		get
		{
			return _autoClearDuration;
		}
		set
		{
			SetValue("AutoClearDuration", ref _autoClearDuration, value.Clamp(0.0, 360.0), delegate(double o, double n)
			{
				base.UndoStack?.Commit(UndoActionTypes.AutoClearTime.ToAction(), this, "AutoClearDuration", o, n);
				OnDataModified();
			});
		}
	}

	public static ObjectBinder<PropSlideAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, PropSlideAction left, Pro.Entity.IAction right)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<PropSlideAction, Pro.Entity.IAction> objectBinder = new ObjectBinder<PropSlideAction, Pro.Entity.IAction>(left, right);
		objectBinder.Bind((PropSlideAction l) => l.WhenPropertyChanges("ID"), (Pro.Entity.IAction r) => r.Uuid.WhenValueChanges, delegate(PropSlideAction l, Pro.Entity.IAction r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(Pro.Entity.IAction r, PropSlideAction l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((PropSlideAction l) => l.Slide.WhenPropertyChanges("SelectedTransition"), (Pro.Entity.IAction r) => WhenSlideTransitionChanges(r), delegate(PropSlideAction l, Pro.Entity.IAction r)
		{
			IPropSlide orAssignProp = GetOrAssignProp(r, entityFactory);
			if ((object)l.Slide.SelectedTransition == null)
			{
				orAssignProp.Transition.Set(null);
			}
			else
			{
				ITransition transition = entityFactory.Create<ITransition>();
				orAssignProp.Transition.Set(transition);
				ObjectBinder<TransitionParameters, ITransition> objectBinder2 = TransitionParameters.CreateBinder(entityFactory, l.Slide.SelectedTransition, transition);
				objectBinder2.InitializeRightFromLeft();
				transition.RegisterLinkedDisposable(objectBinder2);
			}
		}, delegate(Pro.Entity.IAction r, PropSlideAction l)
		{
			if (TryGetProp(r, out IPropSlide prop) && prop.Transition.Value != null)
			{
				TransitionParameters transitionParameters = prop.Transition.Value.ToTransition(l.TransitionDescriptions);
				l.Slide.SelectedTransition = transitionParameters;
				ObjectBinder<TransitionParameters, ITransition> objectBinder3 = TransitionParameters.CreateBinder(entityFactory, transitionParameters, prop.Transition.Value);
				objectBinder3.InitializeLeftFromRight();
				prop.Transition.Value.RegisterLinkedDisposable(objectBinder3);
			}
			else
			{
				l.Slide.SelectedTransition = null;
			}
		}).Bind((PropSlideAction l) => l.WhenPropertyChanges("AutoClearEnabled"), (Pro.Entity.IAction r) => WhenSlideAutoClearEnabledChanges(r), delegate(PropSlideAction l, Pro.Entity.IAction r)
		{
			GetOrAssignProp(r, entityFactory).AutoClearEnabled.Set(l.AutoClearEnabled);
		}, delegate(Pro.Entity.IAction r, PropSlideAction l)
		{
			if (TryGetProp(r, out IPropSlide prop2))
			{
				l.AutoClearEnabled = prop2.AutoClearEnabled.Value;
			}
			else
			{
				l.AutoClearEnabled = false;
			}
		})
			.Bind((PropSlideAction l) => l.WhenPropertyChanges("AutoClearDuration"), (Pro.Entity.IAction r) => WhenSlideAutoClearDurationChanges(r), delegate(PropSlideAction l, Pro.Entity.IAction r)
			{
				GetOrAssignProp(r, entityFactory).AutoClearDuration.Set(l.AutoClearDuration);
			}, delegate(Pro.Entity.IAction r, PropSlideAction l)
			{
				if (TryGetProp(r, out IPropSlide prop3))
				{
					l.AutoClearDuration = prop3.AutoClearDuration.Value;
				}
			})
			.Bind<Unit, Unit>(null, (Pro.Entity.IAction r) => WhenBaseSlideChanges(r), delegate(PropSlideAction l, Pro.Entity.IAction r)
			{
				if (l.Slide is CustomSlide left2)
				{
					IPropSlide orAssignProp2 = GetOrAssignProp(r, entityFactory);
					ISlide slide = entityFactory.Create<ISlide>();
					orAssignProp2.BaseSlide.Set(slide);
					ObjectBinder<CustomSlide, ISlide> objectBinder4 = CustomSlide.CreateBinder(scheduler, left2, slide);
					objectBinder4.InitializeRightFromLeft();
					slide.RegisterLinkedDisposable(objectBinder4);
				}
			}, delegate(Pro.Entity.IAction r, PropSlideAction l)
			{
				if (l.Slide is CustomSlide left3)
				{
					if (TryGetProp(r, out IPropSlide prop4))
					{
						ObjectBinder<CustomSlide, ISlide> objectBinder5 = CustomSlide.CreateBinder(scheduler, left3, prop4.BaseSlide.Value);
						objectBinder5.InitializeLeftFromRight();
						prop4.BaseSlide.Value.RegisterLinkedDisposable(objectBinder5);
					}
					return;
				}
				throw new InvalidOperationException("Expected CustomSlide and valid PropSlide");
			}, null, scheduler.Scheduler);
		return objectBinder;
	}

	private static IPropSlide GetOrAssignProp(Pro.Entity.IAction r, IEntityFactory entityFactory)
	{
		Pro.Entity.IAction.Types.IActionTypeData.ISlide slide = r.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.ISlide;
		if (slide == null)
		{
			slide = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.ISlide>();
			r.ActionTypeData.Set(slide);
		}
		Pro.Entity.IAction.Types.ISlideType.Types.ISlide.IProp prop = slide.Value.Slide.Value as Pro.Entity.IAction.Types.ISlideType.Types.ISlide.IProp;
		if (prop == null)
		{
			prop = entityFactory.Create<Pro.Entity.IAction.Types.ISlideType.Types.ISlide.IProp>();
			slide.Value.Slide.Set(prop);
		}
		return prop.Value;
	}

	private static bool TryGetProp(Pro.Entity.IAction r, [NotNullWhen(true)] out IPropSlide? prop)
	{
		if (!(r.ActionTypeData.Value is Pro.Entity.IAction.Types.IActionTypeData.ISlide slide))
		{
			prop = null;
			return false;
		}
		if (!(slide.Value.Slide.Value is Pro.Entity.IAction.Types.ISlideType.Types.ISlide.IProp prop2))
		{
			prop = null;
			return false;
		}
		prop = prop2.Value;
		return true;
	}

	private static IObservable<Unit> WhenSlideTransitionChanges(Pro.Entity.IAction action)
	{
		return (from prop in WhenPropSlideChanges(action)
			select (prop != null) ? prop.Transition.WhenValueChanges.ToUnit() : Observable.Return(Unit.Default)).Switch();
	}

	private static IObservable<Unit> WhenSlideAutoClearEnabledChanges(Pro.Entity.IAction action)
	{
		return (from prop in WhenPropSlideChanges(action)
			select (prop != null) ? prop.AutoClearEnabled.WhenValueChanges.ToUnit() : Observable.Return(Unit.Default)).Switch();
	}

	private static IObservable<Unit> WhenSlideAutoClearDurationChanges(Pro.Entity.IAction action)
	{
		return (from prop in WhenPropSlideChanges(action)
			select (prop != null) ? prop.AutoClearDuration.WhenValueChanges.ToUnit() : Observable.Return(Unit.Default)).Switch();
	}

	private static IObservable<Unit> WhenBaseSlideChanges(Pro.Entity.IAction action)
	{
		return (from prop in WhenPropSlideChanges(action)
			select (prop != null) ? prop.BaseSlide.WhenValueChanges.ToUnit() : Observable.Return(Unit.Default)).Switch();
	}

	private static IObservable<IPropSlide?> WhenPropSlideChanges(Pro.Entity.IAction action)
	{
		return action.ActionTypeData.WhenValueChanges.Select((Pro.Entity.IAction.Types.IActionTypeData actionData) => (actionData is Pro.Entity.IAction.Types.IActionTypeData.ISlide slide2) ? (from slide in slide2.Value.Slide.WhenValueChanges.StartWith(slide2.Value.Slide.Value)
			select (slide is Pro.Entity.IAction.Types.ISlideType.Types.ISlide.IProp prop) ? prop.WhenValueChanges : Observable.Return<IPropSlide>(null)).Switch() : Observable.Return<IPropSlide>(null)).Switch();
	}

	public PropSlideAction(SlideBase slide, ITransitionDescriptionCollection transitionDescriptions, string containerId = "")
		: base(slide, transitionDescriptions, ActionType.PropSlide, containerId)
	{
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		PropSlideAction propSlideAction = new PropSlideAction(base.Slide.Clone(), base.TransitionDescriptions, ContainerId);
		CopyProperties(propSlideAction);
		return propSlideAction;
	}

	protected override T CopyProperties<T>(T action)
	{
		base.CopyProperties(action);
		if (action is PropSlideAction propSlideAction)
		{
			propSlideAction.AutoClearEnabled = AutoClearEnabled;
			propSlideAction.AutoClearDuration = AutoClearDuration;
		}
		return action;
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.Slide.Prop = new PropSlide
		{
			BaseSlide = base.Slide.SerializeSlide(),
			Transition = base.Slide.SelectedTransition?.Serialize(),
			AutoClearEnabled = AutoClearEnabled,
			AutoClearDuration = AutoClearDuration
		};
		return action;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		base.Deserialize(data, applicationData, containerId);
		if (ActionType == ActionType.PropSlide && data?.Slide?.Prop != null)
		{
			base.Slide.DeserializeSlide(data.Slide.Prop.BaseSlide, applicationData, containerId, null);
			base.Slide.SelectedTransition = data.Slide.Prop.Transition.ToTransition(base.TransitionDescriptions);
			AutoClearDuration = data.Slide.Prop.AutoClearDuration;
			AutoClearEnabled = data.Slide.Prop.AutoClearEnabled;
		}
	}
}
