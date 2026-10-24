using System;

namespace Pro.Entity;

public record IntRange(int Start, int End)
{
	public virtual bool Equals(IntRange? other)
	{
		if ((object)other != null && Start == other.Start)
		{
			return End == other.End;
		}
		return false;
	}

	public override int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(Start);
		hashCode.Add(End);
		return hashCode.ToHashCode();
	}
}
