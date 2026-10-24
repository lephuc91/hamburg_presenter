using System;

namespace Pro.Entity;

public record Color(float Red, float Green, float Blue, float Alpha)
{
	public virtual bool Equals(Color? other)
	{
		if ((object)other != null && Red == other.Red && Green == other.Green && Blue == other.Blue)
		{
			return Alpha == other.Alpha;
		}
		return false;
	}

	public override int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(Red);
		hashCode.Add(Green);
		hashCode.Add(Blue);
		hashCode.Add(Alpha);
		return hashCode.ToHashCode();
	}
}
