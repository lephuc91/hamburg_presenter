using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Effects;
using Pro.DO.Transitions;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Transitions;

namespace ProPresenter.DO.Slide.Builds;

public class Build : LinkedNotifyPropertyChangedBase, IBuild, IRenderEquatable<IBuild>, IRenderHashable, INotifyPropertyChanged
{
	private TransitionParameters? _selectedTransition;

	private StartMode _start;

	private TimeSlice _delay;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public Guid ID { get; private set; } = Guid.NewGuid();

	public string Name => Element.Name;

	public string Description => LocalizedStrings.Get(IsBuildIn ? "EDITOR_BUILD_IN_subtitle" : "EDITOR_BUILD_OUT_subtitle") + " " + SelectedTransition?.TransitionDescription?.Name;

	public SlideElementBase Element { get; }

	public UndoStack? UndoStack { get; set; }

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return _selectedTransition;
		}
		set
		{
			SetValue<TransitionParameters>("SelectedTransition", ref _selectedTransition, value, delegate(TransitionParameters o, TransitionParameters n)
			{
				UndoStack?.Commit(UndoActionTypes.BuildTransition.ToAction(), this, "SelectedTransition", o, n);
				if (o != null)
				{
					o.ParametersChanged -= Transition_ParametersChanged;
				}
				if (n != null)
				{
					n.ParametersChanged += Transition_ParametersChanged;
				}
				OnPropertyChanged("Description");
				OnDataModified();
			});
		}
	}

	public StartMode Start
	{
		get
		{
			return _start;
		}
		set
		{
			SetValue("Start", ref _start, value, delegate(StartMode o, StartMode n)
			{
				UndoStack?.Commit(UndoActionTypes.BuildStartMode.ToAction(), this, "Start", o, n);
				OnDataModified();
			});
		}
	}

	public TimeSlice Delay
	{
		get
		{
			return _delay;
		}
		set
		{
			SetValue("Delay", ref _delay, value, delegate(TimeSlice o, TimeSlice n)
			{
				UndoStack?.Commit(UndoActionTypes.BuildDelay.ToAction(), this, "Delay", o, n);
				OnDataModified();
			});
		}
	}

	public bool IsBuildIn => this == Element.BuildIn;

	public event System.Action? DataModified;

	public static ObjectBinder<Build, ISlide.Types.IElement.Types.IBuild> CreateBinder(Build buildIn, ISlide.Types.IElement.Types.IBuild value, IEntityFactory entityFactory)
	{
		ObjectBinder<Build, ISlide.Types.IElement.Types.IBuild> objectBinder = new ObjectBinder<Build, ISlide.Types.IElement.Types.IBuild>(buildIn, value);
		objectBinder.Bind((Build m) => m.WhenPropertyChanges("ID"), (ISlide.Types.IElement.Types.IBuild e) => e.Uuid.WhenValueChanges, delegate(Build model, ISlide.Types.IElement.Types.IBuild entity)
		{
			entity.Uuid.Set(model.ID);
		}, delegate(ISlide.Types.IElement.Types.IBuild entity, Build model)
		{
			model.ID = entity.Uuid.Value;
		}).Bind((Build l) => l.WhenPropertyChanges("Delay"), (ISlide.Types.IElement.Types.IBuild r) => r.DelayTime.WhenValueChanges, delegate(Build l, ISlide.Types.IElement.Types.IBuild r)
		{
			r.DelayTime.Set(l.Delay.TotalSeconds);
		}, delegate(ISlide.Types.IElement.Types.IBuild r, Build l)
		{
			l.SetValue("Delay", ref l._delay, TimeSlice.FromSeconds(r.DelayTime.Value));
		}).Bind((Build l) => l.WhenPropertyChanges("Start"), (ISlide.Types.IElement.Types.IBuild r) => r.Start.WhenValueChanges, delegate(Build l, ISlide.Types.IElement.Types.IBuild r)
		{
			r.Start.Set(l.Start.ToEntity());
		}, delegate(ISlide.Types.IElement.Types.IBuild r, Build l)
		{
			l.SetValue("Start", ref l._start, r.Start.Value.Deserialize());
		})
			.Bind((Build m) => m.WhenPropertyChanges("SelectedTransition"), (ISlide.Types.IElement.Types.IBuild e) => e.Transition.WhenValueChanges, delegate(Build model, ISlide.Types.IElement.Types.IBuild entity)
			{
				if (!(model.SelectedTransition == null))
				{
					ITransition transition = entityFactory.Create<ITransition>();
					entity.Transition.Set(transition);
					ObjectBinder<TransitionParameters, ITransition> objectBinder2 = TransitionParameters.CreateBinder(entityFactory, model.SelectedTransition, transition);
					objectBinder2.InitializeRightFromLeft();
					transition.RegisterLinkedDisposable(objectBinder2);
				}
			}, delegate(ISlide.Types.IElement.Types.IBuild entity, Build model)
			{
				ITransition value2 = entity.Transition.Value;
				if (value2 == null)
				{
					ClearSelectedTransition();
				}
				else
				{
					TransitionParameters transitionParameters = value2.ToTransition(model._transitionDescriptions);
					if (transitionParameters == null)
					{
						ClearSelectedTransition();
					}
					else
					{
						ObjectBinder<TransitionParameters, ITransition> objectBinder3 = TransitionParameters.CreateBinder(entityFactory, transitionParameters, value2);
						objectBinder3.InitializeLeftFromRight();
						value2.RegisterLinkedDisposable(objectBinder3);
						model.SetValue<TransitionParameters>("SelectedTransition", ref model._selectedTransition, transitionParameters, delegate(TransitionParameters o, TransitionParameters n)
						{
							if (o != null)
							{
								o.ParametersChanged -= model.Transition_ParametersChanged;
							}
							if (n != null)
							{
								n.ParametersChanged += model.Transition_ParametersChanged;
							}
							model.OnPropertyChanged("Description");
						});
					}
				}
				void ClearSelectedTransition()
				{
					model.SetValue<TransitionParameters>("SelectedTransition", ref model._selectedTransition, null, delegate(TransitionParameters o, TransitionParameters n)
					{
						if (o != null)
						{
							o.ParametersChanged -= model.Transition_ParametersChanged;
						}
						model.OnPropertyChanged("Description");
					});
				}
			});
		return objectBinder;
	}

	public Build(SlideElementBase element, TransitionParameters? transition, ITransitionDescriptionCollection transitionDescriptions)
	{
		Element = element;
		SelectedTransition = transition;
		_transitionDescriptions = transitionDescriptions;
		LinkProperties("Name", "Name");
		Element.PropertyChanged += base.RaiseLinkedValues;
	}

	public Build(SlideElementBase element, Build other)
		: this(element, other.SelectedTransition?.CloneTransitionParameters(), other._transitionDescriptions)
	{
		Start = other.Start;
		Delay = other.Delay;
	}

	protected internal Build(SlideElementBase element, ITransitionDescriptionCollection transitionDescriptions)
		: this(element, null, transitionDescriptions)
	{
	}

	public bool RenderEquals([NotNullWhen(true)] IBuild? other)
	{
		if (other is Build build && _selectedTransition.NullableEquals(build._selectedTransition, (TransitionParameters lhs, TransitionParameters rhs) => rhs != null && (lhs?.Equals(rhs, ignoreDuration: false, ignoreName: true) ?? false)) && _start == build._start)
		{
			return _delay == build._delay;
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_selectedTransition, _start, _delay);
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	protected internal Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build
		{
			Uuid = ID.ToUUID(),
			ElementUUID = Element.ID.ToUUID(),
			Start = _start.Serialize(),
			DelayTime = Delay.TotalSeconds,
			Transition = SelectedTransition?.Serialize()
		};
	}

	protected internal void Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build data)
	{
		if (data != null)
		{
			ID = data.Uuid.ToGuid();
			Start = data.Start.Deserialize();
			Delay = TimeSlice.FromSeconds(data.DelayTime);
			SelectedTransition = data.Transition.ToTransition(_transitionDescriptions);
		}
	}

	private void Transition_ParametersChanged(EffectParameters parameters)
	{
		OnPropertyChanged("Description");
		OnDataModified();
	}

	public double GetBuildDuration()
	{
		return (SelectedTransition?.Duration.TotalSeconds ?? 0.0) + Delay.TotalSeconds;
	}
}
