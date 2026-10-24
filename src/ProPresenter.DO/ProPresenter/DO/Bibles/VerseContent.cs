namespace ProPresenter.DO.Bibles;

public class VerseContent
{
	public VerseKey Key { get; }

	public Content Content { get; }

	internal VerseContent(VerseKey key, Content content)
	{
		Key = key;
		Content = content;
	}
}
