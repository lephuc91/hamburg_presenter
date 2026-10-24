using System;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Props;

public class PropCue : ProPresenterCue, IPropCue, INotifyPropertyChanged, ICloneable<IPropCue>, ITriggerable, IIdentifiable
{
	private readonly IApp _app;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private Guid _parentCollectionID = Guid.Empty;

	private string _parentCollectionName = string.Empty;

	public Guid ParentCollectionID
	{
		get
		{
			return _parentCollectionID;
		}
		set
		{
			SetValue("ParentCollectionID", ref _parentCollectionID, value, (System.Action)delegate
			{
				base.Actions.OfType<ICanReceiveMediaContainerIdUpdates>().ForEach(delegate(ICanReceiveMediaContainerIdUpdates a)
				{
					a.UpdateContainerId(MediaContainerIds.Prop(value));
				});
				OnDataModified();
			}, (Predicate<Guid>?)null, referenceComparison: false);
		}
	}

	public string ParentCollectionName
	{
		get
		{
			return _parentCollectionName;
		}
		set
		{
			SetValue("ParentCollectionName", ref _parentCollectionName, value, base.OnDataModified);
		}
	}

	public PropSlideAction SlideAction => base.Actions.OfType<PropSlideAction>().First();

	public override CueType Type => CueType.Slide;

	public IReadOnlyObjectBinder<IPropCue, ICue> Bind(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, ICue right)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<PropCue, ICue> objectBinder = new ObjectBinder<PropCue, ICue>(this, right);
		objectBinder.Bind((PropCue l) => l.WhenPropertyChanges("ID"), (ICue r) => r.Uuid.WhenValueChanges, delegate(PropCue l, ICue r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(ICue r, PropCue l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((PropCue l) => l.WhenPropertyChanges("Name"), (ICue r) => r.Name.WhenValueChanges, delegate(PropCue l, ICue r)
		{
			r.Name.Set(l.Name);
		}, delegate(ICue r, PropCue l)
		{
			l.Name = r.Name.Value ?? string.Empty;
		}).Bind((PropCue l) => l.Actions.WhenCollectionChanges(), (ICue r) => r.Actions.WhenCollectionChanges, delegate(PropCue l, ICue r)
		{
			Pro.Entity.IAction.Types.IActionTypeData.ISlide slide = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.ISlide>();
			Pro.Entity.IAction.Types.ISlideType.Types.ISlide.IProp value = entityFactory.Create<Pro.Entity.IAction.Types.ISlideType.Types.ISlide.IProp>();
			Pro.Entity.IAction action = entityFactory.Create<Pro.Entity.IAction>();
			slide.Value.Slide.Set(value);
			action.ActionTypeData.Set(slide);
			r.Actions.Reset(new global::_003C_003Ez__ReadOnlySingleElementList<Pro.Entity.IAction>(action));
			ObjectBinder<PropSlideAction, Pro.Entity.IAction> objectBinder2 = PropSlideAction.CreateBinder(scheduler, factoryProvider, l.SlideAction, action);
			objectBinder2.InitializeRightFromLeft();
			action.RegisterLinkedDisposable(objectBinder2);
		}, delegate(ICue r, PropCue l)
		{
			Pro.Entity.IAction action2 = r.Actions.Items.First((Pro.Entity.IAction a) => a.ActionTypeData.Value is Pro.Entity.IAction.Types.IActionTypeData.ISlide slide2 && slide2.Value.Slide.Value is Pro.Entity.IAction.Types.ISlideType.Types.ISlide.IProp);
			ObjectBinder<PropSlideAction, Pro.Entity.IAction> objectBinder3 = PropSlideAction.CreateBinder(scheduler, factoryProvider, l.SlideAction, action2);
			objectBinder3.InitializeLeftFromRight();
			action2.RegisterLinkedDisposable(objectBinder3);
		});
		return objectBinder;
	}

	public override IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylistItem right)
	{
		throw new NotSupportedException();
	}

	public PropCue(IApp app, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, TemplateSlide? template = null)
	{
		_app = app;
		_factoryProvider = factoryProvider;
		_transitionDescriptions = transitionDescriptions;
		base.Actions.DataModified += base.OnDataModified;
		PropSlideAction propSlideAction = new PropSlideAction(new CustomSlide(factoryProvider, transitionDescriptions, template), transitionDescriptions);
		propSlideAction.PropertyChanged += base.RaiseLinkedValues;
		base.Actions.Add(propSlideAction);
	}

	public void ChangeSize(Vector2<double> size)
	{
		SlideAction?.Slide.ChangeSize(size);
	}

	IPropCue ICloneable<IPropCue>.Clone()
	{
		PropCue propCue = new PropCue(_app, _factoryProvider, _transitionDescriptions);
		propCue.Name = Name;
		propCue.Actions.Clear();
		propCue.ParentCollectionID = ParentCollectionID;
		propCue.ParentCollectionName = ParentCollectionName;
		base.Actions.CloneItems().ForEach(propCue.Actions.Add);
		return propCue;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Cue data, ApplicationData? applicationData, string containerId)
	{
		data.Actions.ForEach(delegate(Pro.SerializationInterop.RVProtoData.Action a)
		{
			a.Type = Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.PropSlide;
		});
		base.Deserialize(data, applicationData, containerId);
	}

	ActionCollection IPropCue.get_Actions()
	{
		return base.Actions;
	}

	void IPropCue.add_DataModified(Action<Pro.DO.Triggering.Cue>? value)
	{
		base.DataModified += value;
	}

	void IPropCue.remove_DataModified(Action<Pro.DO.Triggering.Cue>? value)
	{
		base.DataModified -= value;
	}

	Pro.SerializationInterop.RVProtoData.Cue IPropCue.Serialize()
	{
		return Serialize();
	}
}
