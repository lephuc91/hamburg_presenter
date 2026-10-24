using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Utility;

namespace Pro.Common.Collections;

internal static class ObservableCollectionTwoWayHelper<K, T, KC, TC> where KC : class, IList<K>, INotifyCollectionChanged where TC : class, IList<T>, INotifyCollectionChanged, new()
{
	private static readonly ObservableCollectionCache<KC, TC> _twoWayCollectionCache = new ObservableCollectionCache<KC, TC>(CreateTwoWayCopy);

	public static TC ConvertTwoWay(KC sourceCollection)
	{
		return _twoWayCollectionCache.Get(sourceCollection) ?? throw new NullReferenceException();
	}

	private static TC CreateTwoWayCopy(KC sourceCollection)
	{
		TC val = new TC();
		NotifyCollectionChangedEventHandler sourceChangedHandler = null;
		NotifyCollectionChangedEventHandler targetChangedHandler = null;
		WeakReference<KC> sourceReference = new WeakReference<KC>(sourceCollection);
		WeakReference<TC> targetReference = new WeakReference<TC>(val);
		sourceChangedHandler = delegate(object? sender, NotifyCollectionChangedEventArgs e)
		{
			TC target = targetReference.GetTarget();
			if (target != null)
			{
				target.CollectionChanged -= targetChangedHandler;
				CollectionChanged<T, K, TC>(target, e);
				target.CollectionChanged += targetChangedHandler;
			}
		};
		targetChangedHandler = delegate(object? sender, NotifyCollectionChangedEventArgs e)
		{
			KC target2 = sourceReference.GetTarget();
			if (target2 != null)
			{
				target2.CollectionChanged -= sourceChangedHandler;
				CollectionChanged<K, T, KC>(target2, e);
				target2.CollectionChanged += sourceChangedHandler;
			}
		};
		sourceCollection.CollectionChanged += sourceChangedHandler;
		val.CollectionChanged += targetChangedHandler;
		return val;
	}

	private static void CollectionChanged<X, Y, XC>(XC target, NotifyCollectionChangedEventArgs e) where XC : IList<X>
	{
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			target.Clear();
			return;
		}
		if (e.OldItems != null)
		{
			foreach (X item3 in e.OldItems.OfType<X>())
			{
				target.Remove(item3);
			}
		}
		if (e.NewItems == null)
		{
			return;
		}
		foreach (var item4 in e.NewItems.OfType<X>().Enumerate())
		{
			X item = item4.Item1;
			int item2 = item4.Item2;
			ref XC reference = ref target;
			XC val = default(XC);
			if (val == null)
			{
				val = reference;
				reference = ref val;
			}
			reference.Insert(Math.Min(e.NewStartingIndex + item2, target.Count), item);
		}
	}
}
