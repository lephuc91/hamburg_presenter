using System;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;

namespace Pro.Text;

public class LevelSettingsCollection : ImmutableObservableCollection<LevelSettings>, ICloneable<LevelSettingsCollection>
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
			base.Collection.ForEach(delegate(LevelSettings s)
			{
				s.UndoStack = value;
			});
		}
	}

	public event Action<LevelSettingsCollection>? LevelSettingsChanged;

	public LevelSettings AddLevel(LevelSettings? newLevel = null)
	{
		newLevel = newLevel?.Clone() ?? this.LastOrDefault()?.Clone() ?? new LevelSettings();
		OnAddLevel(newLevel);
		OnLevelSettingsChanged();
		return newLevel;
	}

	private void OnAddLevel(LevelSettings newLevel)
	{
		newLevel.LevelIndex = base.Collection.Count;
		newLevel.UndoStack = UndoStack;
		newLevel.PropertyChanged += OnLevelSettingsPropertyChanged;
		base.Collection.Add(newLevel);
	}

	public void RemoveLevel()
	{
		if (this.Any())
		{
			this[Count - 1].PropertyChanged -= OnLevelSettingsPropertyChanged;
			base.Collection.RemoveAt(base.Count - 1);
			OnLevelSettingsChanged();
		}
	}

	public LevelSettings GetLevelSettings(int index)
	{
		if (index == base.Count)
		{
			OnAddLevel(new LevelSettings
			{
				LevelIndex = index
			});
		}
		return this.ElementAtOrDefault(index) ?? new LevelSettings
		{
			LevelIndex = index
		};
	}

	private void OnLevelSettingsChanged()
	{
		this.LevelSettingsChanged?.Invoke(this);
	}

	private void OnLevelSettingsPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnLevelSettingsChanged();
	}

	public LevelSettingsCollection Clone()
	{
		LevelSettingsCollection levelSettingsCollection = new LevelSettingsCollection();
		this.CloneItems().ToArray().ForEach(levelSettingsCollection.OnAddLevel);
		return levelSettingsCollection;
	}
}
