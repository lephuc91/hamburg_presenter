using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;

namespace ProPresenter.DO.Import;

public class FontReplacementOptionCollection : ImmutableObservableCollection<IFontReplacementOption>, IFontReplacementOptionCollection, INotifyEnumerableChanged<IFontReplacementOption>, IEnumerable<IFontReplacementOption>, IEnumerable, INotifyCollectionChanged, IReadOnlyCollection<IFontReplacementOption>
{
	public event Action<FontReplacementOptionCollection>? DataModified;

	public FontReplacementOptionCollection()
	{
		base.CollectionChanged += delegate
		{
			OnDataModified();
		};
	}

	public void Add(IFontReplacementOption fontOption)
	{
		AddSorted(fontOption);
	}

	public void Add(IEnumerable<IFontReplacementOption> fontOptions)
	{
		AddSorted(fontOptions);
	}

	public void Remove(IFontReplacementOption fontOption)
	{
		Remove(new global::_003C_003Ez__ReadOnlySingleElementList<IFontReplacementOption>(fontOption));
	}

	public void Remove(IEnumerable<IFontReplacementOption> fontOptions)
	{
		OnRemoveFontOptions(fontOptions);
	}

	public void Clear()
	{
		Remove(base.Collection);
	}

	private void AddSorted(IFontReplacementOption fontOption)
	{
		AddSorted(new global::_003C_003Ez__ReadOnlySingleElementList<IFontReplacementOption>(fontOption));
	}

	private void AddSorted(IEnumerable<IFontReplacementOption> fontOptions)
	{
		foreach (IFontReplacementOption fontOption in fontOptions)
		{
			SetupFontOption(fontOption);
			int index = FindInsertionIndex(fontOption);
			base.Collection.Insert(index, fontOption);
		}
	}

	private int FindInsertionIndex(IFontReplacementOption fontOption)
	{
		if (fontOption.IsDefault)
		{
			return 0;
		}
		int i;
		for (i = 0; i < base.Collection.Count && base.Collection[i].IsDefault; i++)
		{
		}
		for (int j = i; j < base.Collection.Count; j++)
		{
			IFontReplacementOption fontReplacementOption = base.Collection[j];
			if (string.Compare(fontOption.DisplayName, fontReplacementOption.DisplayName, StringComparison.OrdinalIgnoreCase) < 0)
			{
				return j;
			}
		}
		return base.Collection.Count;
	}

	private void OnRemoveFontOptions(IEnumerable<IFontReplacementOption> fontOptions)
	{
		IFontReplacementOption[] array = fontOptions.ToArray();
		List<int> list = new List<int>();
		IFontReplacementOption[] array2 = array;
		foreach (IFontReplacementOption item in array2)
		{
			int num = base.Collection.IndexOf(item);
			if (num >= 0)
			{
				list.Add(num);
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		array2 = array;
		foreach (IFontReplacementOption fontReplacementOption in array2)
		{
			if (base.Collection.Contains(fontReplacementOption))
			{
				TearDownFontOption(fontReplacementOption);
			}
		}
		foreach (int item2 in list.OrderByDescending((int i) => i))
		{
			base.Collection.RemoveAt(item2);
		}
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	private void SetupFontOption(IFontReplacementOption fontOption)
	{
		fontOption.PropertyChanged += OnFontOptionPropertyChanged;
	}

	private void OnFontOptionPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "DisplayName" || e.PropertyName == "IsDefault")
		{
			SortCollection();
		}
	}

	private void TearDownFontOption(IFontReplacementOption fontOption)
	{
		fontOption.PropertyChanged -= OnFontOptionPropertyChanged;
	}

	private void SortCollection()
	{
		IFontReplacementOption[] array = base.Collection.OrderBy((IFontReplacementOption f) => (!f.IsDefault) ? 1 : 0).ThenBy<IFontReplacementOption, string>((IFontReplacementOption f) => f.DisplayName, StringComparer.OrdinalIgnoreCase).ToArray();
		base.Collection.Clear();
		IFontReplacementOption[] array2 = array;
		foreach (IFontReplacementOption item in array2)
		{
			base.Collection.Add(item);
		}
	}
}
