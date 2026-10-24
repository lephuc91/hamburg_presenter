using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Utility;

namespace ProPresenter.DO.Bibles;

public class Chapter : IComparable, IComparable<Chapter>, IEquatable<Chapter>
{
	private readonly int _hashCode;

	public int Number { get; }

	public Verse[] Verses { get; }

	public int FirstVerseNumber { get; }

	public int LastVerseNumber { get; }

	public Verse FirstVerse { get; }

	public Verse LastVerse { get; }

	public Chapter(int number, IEnumerable<Verse> verses)
	{
		Number = number;
		Verses = verses.OrderBy((Verse v) => v.StartNumber).ToArray();
		FirstVerseNumber = Verses.Min((Verse v) => v.StartNumber);
		LastVerseNumber = Verses.Max((Verse v) => v.EndNumber);
		FirstVerse = GetVerse(FirstVerseNumber);
		LastVerse = GetVerse(LastVerseNumber);
		IEnumerable[] collections = new Verse[1][] { Verses };
		_hashCode = HashCodeHelper.GenerateHashCode(collections, Number);
	}

	public Verse? GetVerse(int verseNumber)
	{
		return Verses.FirstOrDefault((Verse v) => verseNumber >= v.StartNumber && verseNumber <= v.EndNumber);
	}

	public int CompareTo(object? obj)
	{
		if (!(obj is Chapter other))
		{
			return 1;
		}
		return CompareTo(other);
	}

	public int CompareTo(Chapter? other)
	{
		return Number.CompareTo(other?.Number);
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Chapter)
		{
			return Equals((Chapter)obj);
		}
		return false;
	}

	public bool Equals(Chapter? other)
	{
		if ((object)other != null && Number == other.Number)
		{
			return Verses == other.Verses;
		}
		return false;
	}

	public static bool operator ==(Chapter lhs, Chapter rhs)
	{
		return lhs.NullableEquals<Chapter>(rhs);
	}

	public static bool operator !=(Chapter lhs, Chapter rhs)
	{
		return !lhs.NullableEquals<Chapter>(rhs);
	}
}
