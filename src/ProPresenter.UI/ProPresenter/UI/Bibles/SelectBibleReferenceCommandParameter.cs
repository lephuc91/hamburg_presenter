using System;
using System.Diagnostics.CodeAnalysis;
using ProPresenter.DO.Bibles;

namespace ProPresenter.UI.Bibles;

public class SelectBibleReferenceCommandParameter
{
	public Book? Book { get; }

	public Chapter? Chapter { get; }

	public Verse? Verse { get; }

	public SelectBibleReferenceCommandParameter([NotNull] Book? book, Chapter? chapter, Verse? verse)
	{
		Book = book ?? throw new ArgumentNullException("book", "The parameter book must never be null");
		Chapter = chapter;
		Verse = verse;
	}
}
