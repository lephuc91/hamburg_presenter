using System;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Effects.Descriptions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Transitions.Descriptions;

public sealed class TransitionDescription : EffectDescription, IEquatable<TransitionDescription?>
{
	public static readonly Guid CutTransitionID = new Guid("AB29D07B-E9E2-4E0A-93BD-AD3EA58120FA");

	public static readonly Guid AutoTransitionID = new Guid("EC52A828-AD85-4602-B70C-1DEE7C904DB6");

	public TimeSlice DefaultDuration { get; }

	public bool SupportsDuration { get; }

	public TransitionDescription(Transition protoTransition)
		: base(protoTransition.Effect)
	{
		DefaultDuration = TimeSlice.FromSeconds(protoTransition.Duration);
		SupportsDuration = DefaultDuration != TimeSlice.Zero;
	}

	public override bool Equals(object? obj)
	{
		if (obj is TransitionDescription)
		{
			return Equals((TransitionDescription)obj);
		}
		return false;
	}

	public bool Equals(TransitionDescription? other)
	{
		if (Equals((EffectDescription?)other) && DefaultDuration == other.DefaultDuration)
		{
			return SupportsDuration == other.SupportsDuration;
		}
		return false;
	}

	protected override int GenerateHashCode()
	{
		return HashCodeHelper.GenerateHashCode(base.GenerateHashCode(), DefaultDuration, SupportsDuration);
	}

	public override int GetHashCode()
	{
		return GenerateHashCode();
	}

	public static bool operator ==(TransitionDescription? lhs, TransitionDescription? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(TransitionDescription? lhs, TransitionDescription? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
