using Pro.Common.Cache;

namespace ProPresenter.Rendering;

internal class ArrangedTextCache : LimitCache<TextDocumentKey, CachedArrangedText>
{
	private const int MaxCapacity = 200;

	public ArrangedTextCache()
		: base(200)
	{
	}

	protected override CachedArrangedText GenerateValue(TextDocumentKey target)
	{
		target.LockDocument();
		return new CachedArrangedText(target.Document);
	}
}
