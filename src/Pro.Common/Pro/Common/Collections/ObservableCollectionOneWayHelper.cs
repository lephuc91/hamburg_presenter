using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Operations;
using Pro.Common.Utility;

namespace Pro.Common.Collections;

internal static class ObservableCollectionOneWayHelper<T>
{
	private static readonly ObservableCollectionCache<ObservableCollection<T>, ImmutableObservableCollection<T>> _oneWayCollectionCache = new ObservableCollectionCache<ObservableCollection<T>, ImmutableObservableCollection<T>>(CreateOneWayCopy);

	public static ImmutableObservableCollection<T> ConvertOneWay(ObservableCollection<T> sourceCollection)
	{
		return _oneWayCollectionCache.Get(sourceCollection) ?? throw new NullReferenceException();
	}

	private static ImmutableObservableCollection<T> CreateOneWayCopy(ObservableCollection<T> sourceCollection)
	{
		return new ImmutableObservableCollection<T>(sourceCollection);
	}
}
internal static class ObservableCollectionOneWayHelper<K, T, KC, TC> where K : T where KC : class, IReadOnlyCollection<K>, INotifyCollectionChanged where TC : class, IList<T>, new()
{
	private static readonly ObservableCollectionCache<KC, TC> _oneWayCollectionCache = new ObservableCollectionCache<KC, TC>(CreateOneWayCopy);

	public static TC ConvertOneWay(KC sourceCollection)
	{
		return _oneWayCollectionCache.Get(sourceCollection) ?? throw new NullReferenceException();
	}

	private static TC CreateOneWayCopy(KC sourceCollection)
	{
		TC val = new TC();
		WeakReference<TC> targetReference = new WeakReference<TC>(val);
		val.AddRange(sourceCollection.Cast<T>());
		sourceCollection.CollectionChanged += delegate(object? sender, NotifyCollectionChangedEventArgs e)
		{
			TC target = targetReference.GetTarget();
			if (target != null)
			{
				CollectionChanged<T, K, TC>(target, e);
			}
		};
		return val;
	}

	private static void CollectionChanged<X, Y, XC>(XC target, NotifyCollectionChangedEventArgs e) where XC : IList<X>
	{
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			target.Clear();
			return;
		}
		XC val;
		if (e.OldItems != null)
		{
			foreach (Y oldItem in e.OldItems)
			{
				ref XC reference = ref target;
				val = default(XC);
				if (val == null)
				{
					val = reference;
					reference = ref val;
				}
				reference.Remove(oldItem.Cast<X, Y>());
			}
		}
		if (e.NewItems == null)
		{
			return;
		}
		foreach (Y newItem in e.NewItems)
		{
			ref XC reference2 = ref target;
			val = default(XC);
			if (val == null)
			{
				val = reference2;
				reference2 = ref val;
			}
			reference2.Insert(e.NewStartingIndex + e.NewItems.IndexOf(newItem), newItem.Cast<X, Y>());
		}
	}
}
