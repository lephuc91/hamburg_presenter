using System;

namespace Pro.Entity;

public record Font(string? Name, double Size, bool Italic, bool Bold, string? Family, string? Face)
{
	public virtual bool Equals(Font? other)
	{
		if ((object)other != null && Name == other.Name && Size == other.Size && Italic == other.Italic && Bold == other.Bold && Family == other.Family)
		{
			return Face == other.Face;
		}
		return false;
	}

	public override int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(Name);
		hashCode.Add(Size);
		hashCode.Add(Italic);
		hashCode.Add(Bold);
		hashCode.Add(Family);
		hashCode.Add(Face);
		return hashCode.ToHashCode();
	}
}
