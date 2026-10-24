using Pro.Common.Cache;

namespace ProPresenter.DO.Bibles;

internal class VerseCache : Cache<VerseKey, Content?>
{
	private readonly BibleBase _bible;

	public VerseCache(BibleBase bible)
	{
		_bible = bible;
	}

	protected override Content? GenerateValue(VerseKey target)
	{
		return _bible.LoadVerse(target.Book, target.Chapter, target.Verse);
	}
}
