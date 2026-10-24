using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Label;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text.Fills;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Props;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Transitions;

namespace ProPresenter.DO.Actions;

public class SlideAction : ActionBase, ICanReceiveMediaContainerIdUpdates
{
	private string _containerId = "";

	protected ITransitionDescriptionCollection TransitionDescriptions { get; }

	public override ActionType ActionType { get; }

	public SlideBase Slide { get; }

	public override bool IsValid
	{
		get
		{
			bool num = (from p in this.FindMedia()
				select p.mediaFill).None((MediaFill m) => m.IsEnabled && (m.Media == null || !m.Media.IsValid));
			bool flag = (from p in this.FindTextMedia()
				select p.mediaFill).All((MediaTextFill m) => m.IsValid);
			return num && flag;
		}
	}

	public override string ContainerId => _containerId;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, SlideAction left, Pro.Entity.IAction right)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.ISlideType.Types.ISlide.IPresentation presentation;
		if (right.ActionTypeData.Value is Pro.Entity.IAction.Types.IActionTypeData.ISlide slide)
		{
			presentation = slide.Value.Slide.Value as Pro.Entity.IAction.Types.ISlideType.Types.ISlide.IPresentation;
			if (presentation != null)
			{
				goto IL_00ad;
			}
		}
		Pro.Entity.IAction.Types.IActionTypeData.ISlide slide2 = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.ISlide>();
		presentation = entityFactory.Create<Pro.Entity.IAction.Types.ISlideType.Types.ISlide.IPresentation>();
		slide2.Value.Slide.Set(presentation);
		right.ActionTypeData.Set(slide2);
		goto IL_00ad;
		IL_00ad:
		ObjectBinder<SlideAction, IPresentationSlide> slideActionBinder = new ObjectBinder<SlideAction, IPresentationSlide>(left, presentation.Value);
		slideActionBinder.Bind((SlideAction l) => l.WhenPropertyChanges("Slide"), (IPresentationSlide r) => r.BaseSlide.WhenValueChanges, delegate(SlideAction l, IPresentationSlide r)
		{
			ISlide slide3 = entityFactory.Create<ISlide>();
			r.BaseSlide.Set(slide3);
			ObjectBinder<CustomSlide, ISlide> objectBinder2 = CustomSlide.CreateBinder(scheduler, (CustomSlide)l.Slide, slide3);
			objectBinder2.InitializeRightFromLeft();
			slide3.RegisterLinkedDisposable(objectBinder2);
		}, delegate(IPresentationSlide r, SlideAction l)
		{
			ObjectBinder<CustomSlide, ISlide> objectBinder3 = CustomSlide.CreateBinder(scheduler, (CustomSlide)l.Slide, r.BaseSlide.Value);
			objectBinder3.InitializeLeftFromRight();
			r.BaseSlide.Value.RegisterLinkedDisposable(objectBinder3);
		});
		objectBinder.DoOnInitializeRightFromLeft(slideActionBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(slideActionBinder.InitializeLeftFromRight).RegisterChildDisposable(() => slideActionBinder);
		return objectBinder;
	}

	public SlideAction(SlideBase slide, ITransitionDescriptionCollection transitionDescriptions, ActionType? actionType = null, string containerId = "")
	{
		Slide = slide;
		TransitionDescriptions = transitionDescriptions;
		Slide.DataModified += delegate
		{
			OnDataModified();
		};
		if (Slide is CustomSlide customSlide)
		{
			customSlide.Elements.CollectionChanged += OnElementsChanged;
			customSlide.Elements.OfType<ClosedBezierPath>().ForEach(SetupElement);
		}
		if (actionType.HasValue)
		{
			if (actionType.Value != ActionType.Slide && actionType.Value != ActionType.PropSlide)
			{
				throw new InvalidOperationException();
			}
			ActionType = actionType.Value;
		}
		else
		{
			ActionType = ActionType.Slide;
		}
		UpdateContainerId((containerId == "") ? slide.ContainerId : containerId);
	}

	private SlideAction(ActionType actionType, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, string containerId = "")
		: this(new CustomSlide(factoryProvider, transitionDescriptions), transitionDescriptions, null, containerId)
	{
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new SlideAction(Slide.Clone(), TransitionDescriptions, ActionType, ContainerId));
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		if (data == null)
		{
			return;
		}
		base.Deserialize(data, applicationData, containerId);
		if (ActionType != ActionType.Slide)
		{
			return;
		}
		Slide.Deserialize(data.Slide.Presentation, applicationData, containerId);
		if (base.Label != null && data.Label != null)
		{
			base.Label.MasterLabel = DataVault.SlideLabels?.FirstOrDefault((ActionLabel l) => l.Text.Equals(data.Label.Text));
		}
		else if (ActionType == ActionType.PropSlide && data.Slide.Prop != null)
		{
			Slide.DeserializeSlide(data.Slide.Prop.BaseSlide, applicationData, containerId, null);
			Slide.SelectedTransition = data.Slide.Prop.Transition.ToTransition(TransitionDescriptions);
		}
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.Slide = new Pro.SerializationInterop.RVProtoData.Action.Types.SlideType();
		switch (ActionType)
		{
		case ActionType.Slide:
			action.Slide.Presentation = Slide.Serialize();
			break;
		case ActionType.PropSlide:
			action.Slide.Prop = new PropSlide
			{
				BaseSlide = Slide.SerializeSlide(),
				Transition = Slide.SelectedTransition?.Serialize()
			};
			break;
		}
		return action;
	}

	public static ActionBase ConstructSlideAction(ActionType type, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, string containerId)
	{
		return type switch
		{
			ActionType.Slide => new SlideAction(ActionType.Slide, factoryProvider, transitionDescriptions, containerId), 
			ActionType.PropSlide => new PropSlideAction(new CustomSlide(factoryProvider, transitionDescriptions), transitionDescriptions, containerId), 
			_ => throw new NotSupportedException(), 
		};
	}

	private void OnElementsChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ClosedBezierPath>().ForEach(TeardownElement);
		e.NewItems?.OfType<ClosedBezierPath>().ForEach(SetupElement);
		OnPropertyChanged("IsValid");
	}

	private void SetupElement(ClosedBezierPath element)
	{
		element.FillChanged += OnFillChanged;
		if (element.Fill != null)
		{
			element.Fill.PropertyChanged += OnFillPropertyChanged;
		}
	}

	private void TeardownElement(ClosedBezierPath element)
	{
		element.FillChanged -= OnFillChanged;
		if (element.Fill != null)
		{
			element.Fill.PropertyChanged -= OnFillPropertyChanged;
		}
	}

	private void OnFillChanged(IFill oldValue, IFill newValue)
	{
		if (oldValue is MediaFill mediaFill)
		{
			mediaFill.PropertyChanged -= OnFillPropertyChanged;
		}
		if (newValue is MediaFill mediaFill2)
		{
			mediaFill2.PropertyChanged += OnFillPropertyChanged;
		}
		OnPropertyChanged("IsValid");
	}

	private void OnFillPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsValid")
		{
			OnPropertyChanged("IsValid");
		}
	}

	internal void UpdateValidity()
	{
		(from p in this.FindMedia()
			select p.mediaFill).ForEach(delegate(MediaFill m)
		{
			m.Media?.UpdateValidity();
		});
		(from p in this.FindTextMedia()
			select p.mediaFill).ForEach(delegate(MediaTextFill m)
		{
			m.Media?.UpdateValidity();
		});
		OnPropertyChanged("IsValid");
	}

	public void UpdateContainerId(string newContainerId)
	{
		_containerId = newContainerId;
		Slide.UpdateContainerId(newContainerId);
	}
}
