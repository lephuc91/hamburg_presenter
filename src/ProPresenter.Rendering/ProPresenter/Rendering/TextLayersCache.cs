using Pro.Common.Cache;

namespace ProPresenter.Rendering;

internal class TextLayersCache : LimitCache<TextDocumentKey, CachedTextLayers>
{
	private const int MaxCapacity = 200;

	public TextLayersCache()
		: base(200)
	{
	}

	protected override CachedTextLayers GenerateValue(TextDocumentKey target)
	{
		target.LockDocument();
		return new CachedTextLayers(target.Document);
	}
}
