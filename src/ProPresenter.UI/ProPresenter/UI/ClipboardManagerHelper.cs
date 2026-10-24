using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.UI;

namespace ProPresenter.UI;

public static class ClipboardManagerHelper
{
	public static void CopyFromCollection<I>(IEnumerable<I> items, Action<ICloneable<I>>? onCloneAction = null) where I : ICloneable<I>
	{
		ClipboardManager.SetData(new ClipboardItems<I>(items));
	}

	public static void CutFromCollection<T, I>(T collection, IEnumerable<I> items) where T : ICutCollection<I> where I : ICloneable<I>
	{
		items = items.ToArray();
		collection.CutFrom(items);
		CopyFromCollection(items);
	}

	public static bool CanPasteIntoCollection<I>(Func<I, bool>? isPasteable = null) where I : ICloneable<I>
	{
		return GetPasteableItems(isPasteable).Any();
	}

	public static IEnumerable<I> PasteIntoCollection<T, I>(T collection, int index, Func<I, bool>? isPasteable = null) where T : ICutPasteCollection<I> where I : ICloneable<I>
	{
		IEnumerable<I> pasteableItems = GetPasteableItems(isPasteable);
		if (pasteableItems.Any())
		{
			collection.PasteInto(pasteableItems, index);
		}
		return pasteableItems;
	}

	public static IEnumerable<I> GetPasteableItems<I>(Func<I, bool>? isPasteable = null) where I : ICloneable<I>
	{
		ClipboardItems<I> data = ClipboardManager.GetData<ClipboardItems<I>>();
		if (data?.PasteableItems != null)
		{
			return data.PasteableItems.Where((I item) => item != null && (isPasteable?.Invoke(item) ?? true));
		}
		return Enumerable.Empty<I>();
	}
}
