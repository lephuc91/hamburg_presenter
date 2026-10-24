namespace ProPresenter.DO.Bibles;

public struct BibleReference
{
	public static readonly BibleReference Invalid = new BibleReference(-1, null, null, -1, -1);

	public int BookIndex { get; }

	public string? BookKey { get; }

	public string? BookName { get; }

	public int ChapterNumber { get; }

	public int VerseNumber { get; }

	public bool IsValid
	{
		get
		{
			if (BookIndex >= 0 && !string.IsNullOrWhiteSpace(BookKey) && !string.IsNullOrWhiteSpace(BookName) && ChapterNumber > 0)
			{
				return VerseNumber > 0;
			}
			return false;
		}
	}

	public BibleReference(int bookIndex, string? bookKey, string? bookName, int chapterNumber, int verseNumber)
	{
		BookIndex = bookIndex;
		BookKey = bookKey;
		BookName = bookName;
		ChapterNumber = chapterNumber;
		VerseNumber = verseNumber;
	}
}
