using Pro.Common.Cache;

namespace ProPresenter.Rendering;

internal class BitmapCache<K> : LimitCache<K, CachedBitmap> where K : class
{
	private const int Capacity = 500;

	public BitmapCache()
		: base(500)
	{
	}

	protected override CachedBitmap GenerateValue(K target)
	{
		return new CachedBitmap();
	}
}
