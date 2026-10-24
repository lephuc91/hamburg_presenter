using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;

namespace ProPresenter.DO.Import;

public class MissingFontItemCollection : ImmutableObservableCollection<IMissingFontItemVM>, IMissingFontItemCollection, IImmutableObservableCollection<IMissingFontItemVM>, IReadOnlyList<IMissingFontItemVM>, IEnumerable<IMissingFontItemVM>, IEnumerable, IReadOnlyCollection<IMissingFontItemVM>, INotifyEnumerableChanged<IMissingFontItemVM>, INotifyCollectionChanged
{
	public event Action<IMissingFontItemCollection>? DataModified;

	public void Add(IMissingFontItemVM fontItem)
	{
		Add(new global::_003C_003Ez__ReadOnlySingleElementList<IMissingFontItemVM>(fontItem));
	}

	public void Add(IEnumerable<IMissingFontItemVM> fontItems)
	{
		AddSorted(fontItems);
	}

	public void Insert(int index, IMissingFontItemVM fontItem)
	{
		Insert(index, new global::_003C_003Ez__ReadOnlySingleElementList<IMissingFontItemVM>(fontItem));
	}

	public void Insert(int index, IEnumerable<IMissingFontItemVM> fontItems)
	{
		OnInsertFontItems(index, fontItems);
	}

	public void Remove(IMissingFontItemVM fontItem)
	{
		Remove(new global::_003C_003Ez__ReadOnlySingleElementList<IMissingFontItemVM>(fontItem));
	}

	public void Remove(IEnumerable<IMissingFontItemVM> fontItems)
	{
		OnRemoveFontItems(fontItems);
	}

	public void Clear()
	{
		Remove(base.Collection);
	}

	private void AddSorted(IEnumerable<IMissingFontItemVM> fontItems)
	{
		IMissingFontItemVM[] array = fontItems.ToArray();
		IMissingFontItemVM[] array2 = array;
		foreach (IMissingFontItemVM fontItem in array2)
		{
			SetupFontItem(fontItem);
		}
		IMissingFontItemVM[] array3 = base.Collection.Concat(array).OrderBy<IMissingFontItemVM, string>((IMissingFontItemVM f) => f.FontName, StringComparer.OrdinalIgnoreCase).ToArray();
		base.Collection.Clear();
		array2 = array3;
		foreach (IMissingFontItemVM item in array2)
		{
			base.Collection.Add(item);
		}
		OnDataModified();
	}

	private void OnInsertFontItems(int index, IEnumerable<IMissingFontItemVM> fontItems)
	{
		index = base.Collection.ClampIndexExclusive(index);
		IMissingFontItemVM[] array = fontItems.ToArray();
		IMissingFontItemVM[] array2 = array;
		foreach (IMissingFontItemVM fontItem in array2)
		{
			SetupFontItem(fontItem);
		}
		for (int num = array.Length - 1; num >= 0; num--)
		{
			base.Collection.Insert(index, array[num]);
		}
		OnDataModified();
	}

	private void OnRemoveFontItems(IEnumerable<IMissingFontItemVM> fontItems)
	{
		IMissingFontItemVM[] array = fontItems.ToArray();
		HashSet<IMissingFontItemVM> hashSet = new HashSet<IMissingFontItemVM>(array);
		if (!array.All((IMissingFontItemVM item) => base.Collection.Contains(item)))
		{
			return;
		}
		IMissingFontItemVM[] array2 = array;
		foreach (IMissingFontItemVM fontItem in array2)
		{
			TearDownFontItem(fontItem);
		}
		for (int num = base.Collection.Count - 1; num >= 0; num--)
		{
			if (hashSet.Contains(base.Collection[num]))
			{
				base.Collection.RemoveAt(num);
			}
		}
		OnDataModified();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	private void SetupFontItem(IMissingFontItemVM fontItem)
	{
		fontItem.PropertyChanged += OnFontItemPropertyChanged;
	}

	private void OnFontItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnDataModified();
	}

	private void TearDownFontItem(IMissingFontItemVM fontItem)
	{
		fontItem.PropertyChanged -= OnFontItemPropertyChanged;
	}
}
