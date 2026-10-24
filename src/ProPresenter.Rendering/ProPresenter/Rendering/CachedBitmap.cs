using System;
using System.Collections.Generic;
using Pro.Common.Collections;
using Pro.Common.Components;

namespace ProPresenter.Rendering;

internal class CachedBitmap : DisposableBase
{
	private readonly Dictionary<RenderedBitmapHandle, List<CachedBitmapHandle>> _activeHandles = new Dictionary<RenderedBitmapHandle, List<CachedBitmapHandle>>();

	public bool IsBitmapValid { get; set; }

	public bool IsInvalidateAttached { get; set; }

	public RenderedBitmapHandle? CurrentRenderedBitmap { get; private set; }

	public void UpdateBitmap(RenderedBitmapHandle? renderedBitmap)
	{
		lock (_activeHandles)
		{
			CurrentRenderedBitmap = renderedBitmap;
		}
	}

	internal CachedBitmapHandle CreateHandle()
	{
		lock (_activeHandles)
		{
			if (!IsBitmapValid || CurrentRenderedBitmap == null)
			{
				throw new InvalidOperationException();
			}
			if (!_activeHandles.TryGetValue(CurrentRenderedBitmap, out List<CachedBitmapHandle> value))
			{
				value = new List<CachedBitmapHandle>();
				_activeHandles.Add(CurrentRenderedBitmap, value);
			}
			CachedBitmapHandle cachedBitmapHandle = new CachedBitmapHandle(this, CurrentRenderedBitmap);
			value.Add(cachedBitmapHandle);
			return cachedBitmapHandle;
		}
	}

	internal void ReleaseHandle(CachedBitmapHandle handle, RenderedBitmapHandle renderedBitmap)
	{
		if (handle == null)
		{
			return;
		}
		lock (_activeHandles)
		{
			if (_activeHandles.TryGetValue(renderedBitmap, out List<CachedBitmapHandle> value))
			{
				value.Remove(handle);
			}
		}
		CleanupBitmaps();
	}

	protected override void OnDispose(bool disposeObjects)
	{
		CleanupBitmaps();
	}

	private void CleanupBitmaps()
	{
		lock (_activeHandles)
		{
			List<RenderedBitmapHandle> list = null;
			foreach (KeyValuePair<RenderedBitmapHandle, List<CachedBitmapHandle>> activeHandle in _activeHandles)
			{
				if ((base.IsDisposed || activeHandle.Key != CurrentRenderedBitmap) && activeHandle.Value.Empty())
				{
					if (list == null)
					{
						list = new List<RenderedBitmapHandle>();
					}
					activeHandle.Key.Dispose();
					list.Add(activeHandle.Key);
				}
			}
			list?.ForEach(delegate(RenderedBitmapHandle b)
			{
				_activeHandles.Remove(b);
			});
		}
	}
}
