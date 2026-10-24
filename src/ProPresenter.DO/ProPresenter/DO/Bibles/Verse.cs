using System;
using Pro.Common.Utility;

namespace ProPresenter.DO.Bibles;

public class Verse : IComparable, IComparable<Verse>, IEquatable<Verse?>
{
	private readonly int _hashCode;

	public int StartNumber { get; }

	public int EndNumber { get; }

	internal object? SourceKey { get; set; }

	public Verse(int number)
		: this(number, number)
	{
	}

	public Verse(int startNumber, int endNumber)
	{
		StartNumber = startNumber;
		EndNumber = endNumber;
		_hashCode = HashCodeHelper.GenerateHashCode(StartNumber, EndNumber);
	}

	public int CompareTo(object? obj)
	{
		if (!(obj is Verse other))
		{
			return 1;
		}
		return CompareTo(other);
	}

	public int CompareTo(Verse? other)
	{
		return StartNumber.CompareTo(other?.StartNumber);
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Verse other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Verse? other)
	{
		if ((object)other != null && StartNumber == other.StartNumber)
		{
			return EndNumber == other.EndNumber;
		}
		return false;
	}

	public static bool operator ==(Verse lhs, Verse rhs)
	{
		return lhs.NullableEquals<Verse>(rhs);
	}

	public static bool operator !=(Verse lhs, Verse rhs)
	{
		return !lhs.NullableEquals<Verse>(rhs);
	}
}
