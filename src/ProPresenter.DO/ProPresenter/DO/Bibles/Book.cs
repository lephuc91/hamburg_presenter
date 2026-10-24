using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Utility;

namespace ProPresenter.DO.Bibles;

public class Book : IEquatable<Book>
{
	private readonly int _hashCode;

	public int Index { get; }

	public string Key { get; }

	public string Name { get; }

	public Chapter[] Chapters { get; }

	public int FirstChapterNumber { get; }

	public int LastChapterNumber { get; }

	public Chapter FirstChapter { get; }

	public Chapter LastChapter { get; }

	public Book(int index, string key, string name, IEnumerable<Chapter> chapters)
	{
		Index = index;
		Key = key;
		Name = name;
		Chapters = chapters.OrderBy((Chapter c) => c.Number).ToArray();
		FirstChapterNumber = Chapters.Min((Chapter c) => c.Number);
		LastChapterNumber = Chapters.Max((Chapter c) => c.Number);
		FirstChapter = GetChapter(FirstChapterNumber);
		LastChapter = GetChapter(LastChapterNumber);
		IEnumerable[] collections = new Chapter[1][] { Chapters };
		_hashCode = HashCodeHelper.GenerateHashCode(collections, Index, Name);
	}

	public Chapter? GetChapter(int chapterNumber)
	{
		return Chapters.FirstOrDefault((Chapter c) => c.Number == chapterNumber);
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Book)
		{
			return Equals((Book)obj);
		}
		return false;
	}

	public bool Equals(Book? other)
	{
		if ((object)other != null && Index == other.Index && Name == other.Name)
		{
			return Chapters == other.Chapters;
		}
		return false;
	}

	public static bool operator ==(Book lhs, Book rhs)
	{
		return lhs.NullableEquals<Book>(rhs);
	}

	public static bool operator !=(Book lhs, Book rhs)
	{
		return !lhs.NullableEquals<Book>(rhs);
	}
}
