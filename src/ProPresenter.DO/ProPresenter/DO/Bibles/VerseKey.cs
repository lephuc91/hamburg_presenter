using System;
using Pro.Common.Utility;

namespace ProPresenter.DO.Bibles;

public sealed class VerseKey : IEquatable<VerseKey>
{
	private readonly int _hashCode;

	public Book Book { get; }

	public Chapter Chapter { get; }

	public Verse Verse { get; }

	internal VerseKey(Book book, Chapter chapter, Verse verse)
	{
		Book = book;
		Chapter = chapter;
		Verse = verse;
		_hashCode = HashCodeHelper.GenerateHashCode(Book, Chapter, Verse);
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	public override bool Equals(object? obj)
	{
		if (obj is VerseKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(VerseKey? other)
	{
		if ((object)other != null && Book == other.Book && Chapter == other.Chapter)
		{
			return Verse == other.Verse;
		}
		return false;
	}

	public static bool operator ==(VerseKey? lhs, VerseKey? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(VerseKey? lhs, VerseKey? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
