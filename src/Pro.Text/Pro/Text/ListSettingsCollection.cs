using System;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Text.Reversibility;

namespace Pro.Text;

public class ListSettingsCollection : ImmutableObservableCollection<ListSettings>, ICloneable<ListSettingsCollection>
{
	private UndoStack? _undoStack;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			base.Collection.ForEach(delegate(ListSettings s)
			{
				s.UndoStack = value;
			});
		}
	}

	public event Action<ListSettingsCollection>? ListSettingsChanged;

	public ListSettings AddList(ListPreset preset)
	{
		int settingsIndex;
		return AddList(preset, out settingsIndex);
	}

	public ListSettings AddList(ListPreset preset, out int settingsIndex)
	{
		return AddList(ListPresetFactory.LoadPreset(preset), out settingsIndex);
	}

	internal ListSettings AddList(ListSettings settings, out int settingsIndex)
	{
		settingsIndex = base.Count;
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddList), delegate
		{
			RemoveList(settings);
		}, delegate
		{
			AddList(settings, out var _);
		});
		settings.ListSettingsChanged += OnListSettingsChanged;
		settings.UndoStack = UndoStack;
		base.Collection.Add(settings);
		OnCollectionChanged();
		return settings;
	}

	public void RemoveList(ListSettings settings)
	{
		settings.ListSettingsChanged -= OnListSettingsChanged;
		base.Collection.Remove(settings);
		OnCollectionChanged();
	}

	public void Clear()
	{
		this.ToArray().ForEach(RemoveList);
	}

	public ListSettingsCollection Clone()
	{
		ListSettingsCollection listSettingsCollection = new ListSettingsCollection();
		listSettingsCollection.Collection.AddRange(this.CloneItems(), ignoreDuplicates: false);
		return listSettingsCollection;
	}

	private void OnListSettingsChanged(ListSettings listSettings)
	{
		OnCollectionChanged();
	}

	private void OnCollectionChanged()
	{
		this.ListSettingsChanged?.Invoke(this);
	}
}
