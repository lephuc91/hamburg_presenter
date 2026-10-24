using System;

namespace Pro.Entity;

public record Timestamp(long Seconds, int Nanos)
{
	public virtual bool Equals(Timestamp? other)
	{
		if ((object)other != null && Seconds == other.Seconds)
		{
			return Nanos == other.Nanos;
		}
		return false;
	}

	public override int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(Seconds);
		hashCode.Add(Nanos);
		return hashCode.ToHashCode();
	}
}
