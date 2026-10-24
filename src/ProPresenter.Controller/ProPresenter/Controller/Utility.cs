using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interop;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Win32;

namespace ProPresenter.Controller;

public static class Utility
{
	public static void FindMyMouse()
	{
		WindowsFunctions.GetWindowRect(new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle(), out var lpRect);
		Rect<int> rect = (Rect<int>)lpRect;
		WindowsFunctions.SetCursorPos(rect.Center.X, rect.Center.Y);
	}

	public static Dictionary<Guid, TElement> ToElementDictionary<TSource, TElement>(this IEnumerable<TSource> items, Func<TSource, TElement> convert) where TSource : IIdentifiable
	{
		Dictionary<Guid, TElement> dictionary = new Dictionary<Guid, TElement>();
		foreach (TSource item in items)
		{
			if (dictionary.TryGetValue(item.ID, out var _))
			{
				Log.Error($"Duplicate ID found for {typeof(TSource).FullName} with ID - {item.ID}");
			}
			else
			{
				dictionary.Add(item.ID, convert(item));
			}
		}
		return dictionary;
	}
}
