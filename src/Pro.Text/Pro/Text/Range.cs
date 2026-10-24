using System;
using Pro.Common.Utility;

namespace Pro.Text;

public struct Range : IEquatable<Range>
{
	public static readonly Range Empty = new Range(0);

	public static readonly Range All = new Range(-1);

	public int Start { get; }

	public int End { get; }

	public bool IsSelection => Start != End;

	public Range(int start, int end)
	{
		Start = Math.Min(start, end);
		End = Math.Max(start, end);
	}

	public Range(int index)
		: this(index, index)
	{
	}

	public override bool Equals(object? obj)
	{
		if (obj is Range other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Range other)
	{
		if (Start == other.Start)
		{
			return End == other.End;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(Start, End);
	}

	public static bool operator ==(Range lhs, Range rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(Range lhs, Range rhs)
	{
		return !lhs.Equals(rhs);
	}
}
