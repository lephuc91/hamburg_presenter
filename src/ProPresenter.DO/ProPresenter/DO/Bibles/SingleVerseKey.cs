using System;
using Pro.Common.Utility;

namespace ProPresenter.DO.Bibles;

internal class SingleVerseKey : IComparable, IComparable<SingleVerseKey>, IEquatable<SingleVerseKey>
{
	private readonly int _hashCode;

	public int BookIndex { get; }

	public int ChapterNumber { get; }

	public int VerseNumber { get; }

	public SingleVerseKey(int bookIndex, int chapterNumber, int verseNumber)
	{
		BookIndex = bookIndex;
		ChapterNumber = chapterNumber;
		VerseNumber = verseNumber;
		_hashCode = HashCodeHelper.GenerateHashCode(BookIndex, ChapterNumber, VerseNumber);
	}

	public int CompareTo(object? obj)
	{
		if (!(obj is SingleVerseKey other))
		{
			return 1;
		}
		return CompareTo(other);
	}

	public int CompareTo(SingleVerseKey? other)
	{
		int num = BookIndex.CompareTo(other?.BookIndex);
		if (num == 0)
		{
			num = ChapterNumber.CompareTo(other?.ChapterNumber);
		}
		if (num == 0)
		{
			num = VerseNumber.CompareTo(other?.VerseNumber);
		}
		return num;
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	public override bool Equals(object? obj)
	{
		if (obj is SingleVerseKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(SingleVerseKey? other)
	{
		if ((object)other != null && BookIndex == other.BookIndex && ChapterNumber == other.ChapterNumber)
		{
			return VerseNumber == other.VerseNumber;
		}
		return false;
	}

	public static bool operator ==(SingleVerseKey lhs, SingleVerseKey rhs)
	{
		return lhs.NullableEquals<SingleVerseKey>(rhs);
	}

	public static bool operator !=(SingleVerseKey lhs, SingleVerseKey rhs)
	{
		return !lhs.NullableEquals<SingleVerseKey>(rhs);
	}
}
