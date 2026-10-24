using System;
using System.ComponentModel;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Transitions.Descriptions;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Transitions;

public class TransitionParameters : EffectParameters, IEquatable<TransitionParameters>
{
	private TimeSlice _duration;

	private TransitionPreset? _preset;

	public string Name
	{
		get
		{
			return Preset?.Name ?? TransitionDescription?.DisplayName ?? string.Empty;
		}
		set
		{
			if (Preset == null)
			{
				throw new InvalidOperationException();
			}
			Preset.Name = value;
		}
	}

	public TransitionDescription? TransitionDescription => base.EffectDescription as TransitionDescription;

	public bool SupportsDuration
	{
		get
		{
			if (TransitionDescription != null)
			{
				return TransitionDescription.SupportsDuration;
			}
			return false;
		}
	}

	public TimeSlice Duration
	{
		get
		{
			return _duration;
		}
		set
		{
			if (!SupportsDuration)
			{
				throw new InvalidOperationException("Duration is not supported for this type");
			}
			ThrowIfLocked();
			SetValue("Duration", ref _duration, value, base.OnParametersChanged);
		}
	}

	public TransitionPreset? Preset
	{
		get
		{
			return _preset;
		}
		private set
		{
			SetValue<TransitionPreset>("Preset", ref _preset, value, delegate(TransitionPreset o, TransitionPreset n)
			{
				if (o != null)
				{
					o.PropertyChanged -= OnPresetPropertyChanged;
				}
				if (n != null)
				{
					n.PropertyChanged += OnPresetPropertyChanged;
				}
			});
		}
	}

	public bool ResetToStandard { get; }

	public bool CanResetDuration { get; }

	public static ObjectBinder<TransitionParameters, ITransition> CreateBinder(IEntityFactory entityFactory, TransitionParameters? left, ITransition? right)
	{
		ObjectBinder<EffectParameters, IEffect> effectsBinder = EffectParameters.CreateBinder(entityFactory, left, right?.Effect.Value);
		ObjectBinder<TransitionParameters, ITransition> objectBinder = new ObjectBinder<TransitionParameters, ITransition>(left, right);
		objectBinder.Bind((TransitionParameters l) => l.WhenPropertyChanges("Duration"), (ITransition r) => r.Duration.WhenValueChanges, delegate(TransitionParameters l, ITransition r)
		{
			r.Duration.Set(l.Duration.TotalSeconds);
		}, delegate(ITransition r, TransitionParameters l)
		{
			if (l.SupportsDuration)
			{
				l.Duration = TimeSlice.FromSeconds(r.Duration.Value);
			}
		}).Bind((TransitionParameters l) => l.WhenPropertyChanges("Preset"), (ITransition r) => r.FavoriteUuid.WhenValueChanges, delegate(TransitionParameters l, ITransition r)
		{
			r.FavoriteUuid.Set(l.Preset?.ID ?? Guid.Empty);
		}, delegate(ITransition r, TransitionParameters l)
		{
			Log.Warning($"Transition Preset UUID updated from collaboration for {r.Effect.Value.Name} with ID - {r.FavoriteUuid}");
		}).DoOnInitializeRightFromLeft(effectsBinder.InitializeRightFromLeft)
			.DoOnInitializeLeftFromRight(effectsBinder.InitializeLeftFromRight)
			.RegisterChildDisposable(() => effectsBinder);
		return objectBinder;
	}

	internal TransitionParameters(ITransitionDescriptionCollection transitionDescriptions, Transition protoTransition)
		: this(transitionDescriptions.FindDescription(Guid.Parse(protoTransition.Effect.RenderId)))
	{
		Deserialize(protoTransition);
	}

	public TransitionParameters(Guid id, TransitionDescription? description)
		: base(id, description)
	{
		if (description != null)
		{
			_duration = description.DefaultDuration;
		}
		Preset = null;
		ResetToStandard = true;
		CanResetDuration = true;
		Reset(ignoreLock: true, raiseNotification: false);
	}

	public TransitionParameters(TransitionDescription? description)
		: base(description, isEnabled: true, isLocked: false, loadParams: false)
	{
		if (description != null)
		{
			_duration = description.DefaultDuration;
		}
		Preset = null;
		ResetToStandard = true;
		CanResetDuration = true;
		Reset(ignoreLock: true, raiseNotification: false);
	}

	public TransitionParameters(TransitionPreset? preset, bool resetToStandard = true, bool canResetDuration = true)
		: base(preset?.Parameters?.TransitionDescription, isEnabled: true, isLocked: false, loadParams: false)
	{
		if (TransitionDescription != null)
		{
			_duration = TransitionDescription.DefaultDuration;
		}
		Preset = preset;
		ResetToStandard = resetToStandard;
		CanResetDuration = canResetDuration;
		Reset(ignoreLock: true, raiseNotification: false);
	}

	protected override void OnReset()
	{
		base.OnReset();
		if (!SupportsDuration || !CanResetDuration)
		{
			return;
		}
		if (Preset != null && !ResetToStandard)
		{
			if (Preset.Parameters != null)
			{
				Duration = Preset.Parameters.Duration;
			}
		}
		else if (TransitionDescription != null)
		{
			Duration = TransitionDescription.DefaultDuration;
		}
	}

	protected override object? GetDefaultValue(ParameterDescriptionBase parameter)
	{
		if (Preset != null && !ResetToStandard)
		{
			return Preset.Parameters?.GetValue(parameter);
		}
		return base.GetDefaultValue(parameter);
	}

	public override bool Equals(object? obj)
	{
		if (obj is TransitionParameters)
		{
			return Equals((TransitionParameters)obj);
		}
		return false;
	}

	public bool Equals(TransitionParameters? other)
	{
		if (other != null)
		{
			return Equals(other, ignoreDuration: false, ignoreName: true);
		}
		return false;
	}

	public bool Equals(TransitionParameters? other, bool ignoreDuration, bool ignoreName)
	{
		if (!Equals((EffectParameters?)other))
		{
			return false;
		}
		if (!ignoreDuration && Duration != other.Duration)
		{
			return false;
		}
		if (!ignoreName && Name != other.Name)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	protected override int GenerateHashCode()
	{
		return HashCodeHelper.GenerateHashCode(base.GenerateHashCode(), Duration);
	}

	public override EffectParameters CopyFrom(EffectParameters source)
	{
		base.CopyFrom(source);
		if (SupportsDuration)
		{
			Duration = ((TransitionParameters)source).Duration;
		}
		return this;
	}

	public new Transition Serialize()
	{
		return new Transition
		{
			Duration = Duration.TotalSeconds,
			Effect = base.Serialize(),
			FavoriteUuid = Preset?.ID.ToUUID()
		};
	}

	public void Deserialize(Transition protoTransition)
	{
		if (SupportsDuration)
		{
			Duration = TimeSlice.FromSeconds(protoTransition.Duration);
		}
		Deserialize(protoTransition.Effect);
	}

	private void OnPresetPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Name")
		{
			OnPropertyChanged("Name");
		}
	}

	public static bool operator ==(TransitionParameters? lhs, TransitionParameters? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(TransitionParameters? lhs, TransitionParameters? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
