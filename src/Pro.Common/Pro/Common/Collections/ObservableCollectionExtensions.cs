using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;

namespace Pro.Common.Collections;

public static class ObservableCollectionExtensions
{
	private static BindingFlags ProtectedMember = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod;

	private static BindingFlags ProtectedProperty = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

	public static ObservableCollection<T> ConvertOneWay<T, K>(this ObservableCollection<K> sourceCollection) where K : T
	{
		return sourceCollection.ConvertOneWay<T, K, ObservableCollection<K>>();
	}

	public static ObservableCollection<T> ConvertOneWay<T, K, KC>(this KC sourceCollection) where K : T where KC : class, IReadOnlyCollection<K>, INotifyCollectionChanged
	{
		return sourceCollection.ConvertOneWay<T, K, ObservableCollection<T>, KC>();
	}

	public static TC ConvertOneWay<T, K, TC, KC>(this KC sourceCollection) where K : T where TC : class, IList<T>, new() where KC : class, IReadOnlyCollection<K>, INotifyCollectionChanged
	{
		return ObservableCollectionOneWayHelper<K, T, KC, TC>.ConvertOneWay(sourceCollection);
	}

	public static ObservableCollection<T> ConvertTwoWay<T, K>(this ObservableCollection<K> sourceCollection)
	{
		return sourceCollection.ConvertTwoWay<T, K, ObservableCollection<K>>();
	}

	public static ObservableCollection<T> ConvertTwoWay<T, K, KC>(this KC sourceCollection) where KC : class, IList<K>, INotifyCollectionChanged
	{
		return sourceCollection.ConvertTwoWay<T, K, ObservableCollection<T>, KC>();
	}

	public static TC ConvertTwoWay<T, K, TC, KC>(this KC sourceCollection) where TC : class, IList<T>, INotifyCollectionChanged, new() where KC : class, IList<K>, INotifyCollectionChanged
	{
		return ObservableCollectionTwoWayHelper<K, T, KC, TC>.ConvertTwoWay(sourceCollection);
	}

	public static ImmutableObservableCollection<T> ConvertImmutable<T, K>(this ObservableCollection<K> sourceCollection) where K : T
	{
		return new ImmutableObservableCollection<T>(sourceCollection.ConvertOneWay<T, K>());
	}

	public static ImmutableObservableCollection<T> ConvertImmutable<T, K, KC>(this KC sourceCollection) where K : T where KC : class, IReadOnlyCollection<K>, INotifyCollectionChanged
	{
		return new ImmutableObservableCollection<T>(sourceCollection.ConvertOneWay<T, K, KC>());
	}

	public static ImmutableObservableCollection<T> ConvertImmutable<T>(this ObservableCollection<T> sourceCollection)
	{
		return ObservableCollectionOneWayHelper<T>.ConvertOneWay(sourceCollection);
	}

	public static void MoveTo<T>(this ObservableCollection<T> sourceCollection, IEnumerable<T> targetItems, int index, UndoStack? undoStack = null)
	{
		index = index.Clamp(0, sourceCollection.Count());
		sourceCollection.MoveTo(targetItems, index, delegate(int oldIndex, int newIndex, T item)
		{
			sourceCollection.Move(oldIndex, newIndex);
			undoStack?.Commit(delegate
			{
				sourceCollection.Move(newIndex, oldIndex);
			}, delegate
			{
				sourceCollection.Move(oldIndex, newIndex);
			});
		});
	}

	public static void MoveTo<T>(this ObservableCollection<T> sourceCollection, T targetItem, int index, UndoStack? undoStack = null)
	{
		sourceCollection.MoveTo(new global::_003C_003Ez__ReadOnlySingleElementList<T>(targetItem), index, undoStack);
	}

	public static void AddRangeAndNotifyOnCompletion<T>(this ObservableCollection<T> collection, IEnumerable<T> items, bool ignoreDuplicates = true)
	{
		T[] array = (items as T[]) ?? items.ToArray();
		if (array.Any())
		{
			Type type = collection.GetType();
			collection.InsertWithBatchNotify(array, -1, ignoreDuplicates);
			type.InvokeMember("OnCollectionChanged", ProtectedMember, null, collection, new object[1]
			{
				new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)
			});
		}
	}

	public static void RemoveRangeAndNotifyOnCompletion<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
	{
		T[] array = (items as T[]) ?? items.ToArray();
		if (array.Any())
		{
			Type type = collection.GetType();
			collection.RemoveWithBatchNotify(array);
			type.InvokeMember("OnCollectionChanged", ProtectedMember, null, collection, new object[1]
			{
				new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)
			});
		}
	}

	public static void ClearAndNotifyOnCompletion<T>(this ObservableCollection<T> collection)
	{
		T[] array = collection.ToArray();
		if (array.Any())
		{
			Type type = collection.GetType();
			collection.RemoveWithBatchNotify(array);
			type.InvokeMember("OnCollectionChanged", ProtectedMember, null, collection, new object[1]
			{
				new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)
			});
		}
	}

	private static void InsertWithBatchNotify<T>(this ObservableCollection<T> collection, IEnumerable<T> items, int index = -1, bool ignoreDuplicates = true)
	{
		T[] source = (items as T[]) ?? items.ToArray();
		if (!source.Any())
		{
			return;
		}
		Type type = collection.GetType();
		type.InvokeMember("CheckReentrancy", ProtectedMember, null, collection, null);
		if (type.BaseType != null && type.BaseType.GetProperty("Items", ProtectedProperty)?.GetValue(collection) is IList<T> list)
		{
			int num = ((index > -1) ? index : list.Count());
			int num2 = source.Count();
			int num3 = num;
			for (int i = 0; i < num2; i++)
			{
				T item = source.ElementAt(i);
				if (!(list.Contains(item) && ignoreDuplicates))
				{
					list.Insert(num3, source.ElementAt(i));
					num3++;
				}
			}
		}
		type.InvokeMember("OnPropertyChanged", ProtectedMember, null, collection, new object[1]
		{
			new PropertyChangedEventArgs("Count")
		});
		type.InvokeMember("OnPropertyChanged", ProtectedMember, null, collection, new object[1]
		{
			new PropertyChangedEventArgs("Item[]")
		});
	}

	private static void RemoveWithBatchNotify<T>(this ObservableCollection<T> collection, IEnumerable<T> items, int index = -1)
	{
		T[] array = (items as T[]) ?? items.ToArray();
		if (!array.Any())
		{
			return;
		}
		Type type = collection.GetType();
		type.InvokeMember("CheckReentrancy", ProtectedMember, null, collection, null);
		if (type.BaseType != null && type.BaseType.GetProperty("Items", ProtectedProperty)?.GetValue(collection) is IList<T> list)
		{
			for (int i = 0; i < array.Length; i++)
			{
				T item = array.ElementAt(i);
				list.Remove(item);
			}
		}
		type.InvokeMember("OnPropertyChanged", ProtectedMember, null, collection, new object[1]
		{
			new PropertyChangedEventArgs("Count")
		});
		type.InvokeMember("OnPropertyChanged", ProtectedMember, null, collection, new object[1]
		{
			new PropertyChangedEventArgs("Item[]")
		});
	}

	public static void Replace<T>(this ObservableCollection<T> collection, T newItem, int index)
	{
		collection.RemoveAt(index);
		collection.Insert(index, newItem);
	}

	public static void Replace<T>(this ObservableCollection<T> collection, T targetItem, T newItem)
	{
		collection.Replace(newItem, collection.IndexOf(targetItem));
	}

	public static void Reset<T>(this ObservableCollection<T> collection, IReadOnlyCollection<T> newItems)
	{
		Type type = collection.GetType();
		type.InvokeMember("CheckReentrancy", ProtectedMember, null, collection, null);
		if (type.BaseType != null && type.BaseType.GetProperty("Items", ProtectedProperty)?.GetValue(collection) is IList<T> list)
		{
			list.Clear();
			list.AddRange(newItems);
		}
		type.InvokeMember("OnPropertyChanged", ProtectedMember, null, collection, new object[1]
		{
			new PropertyChangedEventArgs("Count")
		});
		type.InvokeMember("OnPropertyChanged", ProtectedMember, null, collection, new object[1]
		{
			new PropertyChangedEventArgs("Item[]")
		});
		type.InvokeMember("OnCollectionChanged", ProtectedMember, null, collection, new object[1]
		{
			new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)
		});
	}

	public static int FindIndex<T>(this ObservableCollection<T> items, Func<T, bool> predicate)
	{
		int num = 0;
		foreach (T item in items)
		{
			if (predicate(item))
			{
				return num;
			}
			num++;
		}
		return -1;
	}
}
