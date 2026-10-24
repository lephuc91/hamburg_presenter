using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using ProPresenter.DO.Macros;

namespace ProPresenter.DO.MacroGroups;

public class MacroGroupSource : IMacroSource
{
	private readonly MacroGroupCollection _macroGroups;

	public IEnumerable<ProPresenterMacro> FlatCollection => _macroGroups.SelectMany((MacroGroup g) => g);

	public IEnumerable<ProPresenterMacro>? ActiveCollection { get; set; }

	public IEnumerable<MacroGroup> MacroGroups => _macroGroups;

	public event NotifyCollectionChangedEventHandler? MacroCollectionsChanged;

	public event PropertyChangedEventHandler? MacroPropertyChanged;

	public MacroGroupSource(MacroGroupCollection macroGroups)
	{
		_macroGroups = macroGroups;
		_macroGroups.ForEach(delegate(MacroGroup g)
		{
			g.CollectionChanged += MacroGroup_CollectionChanged;
			g.MacroPropertyChanged += Macro_PropertyChanged;
		});
		_macroGroups.CollectionChanged += MacroGroups_CollectionChanged;
	}

	public ProPresenterMacro? FindMacro(Guid id, string name, Guid parentCollectionID, string parentCollectionName)
	{
		return _macroGroups.FirstOrDefaultBy((MacroGroup g) => g.ID == parentCollectionID, (MacroGroup g) => g.Name == parentCollectionName)?.FirstOrDefaultBy((ProPresenterMacro m) => m.ID == id, (ProPresenterMacro m) => m.Name == name) ?? _macroGroups.SelectMany((MacroGroup g) => g).FirstOrDefaultBy((ProPresenterMacro m) => m.ID == id, (ProPresenterMacro m) => m.Name == name);
	}

	public void RemoveMacro(ProPresenterMacro macro)
	{
		MacroGroup macroGroup = _macroGroups.FirstOrDefault((MacroGroup g) => g.Contains(macro));
		if (macroGroup != null)
		{
			macroGroup.UndoStack?.StartIgnoring();
			macroGroup.RemoveMacro(macro);
			macroGroup.UndoStack?.StopIgnoring();
		}
	}

	public MacroGroup? CreateMacroGroup(string name, out int index)
	{
		_macroGroups.UndoStack?.StartIgnoring();
		MacroGroup macroGroup = _macroGroups.AddMacroGroup();
		macroGroup.Name = name;
		index = _macroGroups.IndexOf(macroGroup);
		_macroGroups.UndoStack?.StopIgnoring();
		return macroGroup;
	}

	public void RemoveMacroGroup(MacroGroup macroGroup)
	{
		_macroGroups.UndoStack?.StartIgnoring();
		_macroGroups.RemoveMacroGroup(macroGroup);
		_macroGroups.UndoStack?.StopIgnoring();
	}

	private void MacroGroups_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<MacroGroup>().ForEach(delegate(MacroGroup g)
		{
			g.CollectionChanged -= MacroGroup_CollectionChanged;
			g.MacroPropertyChanged -= Macro_PropertyChanged;
		});
		e.NewItems?.OfType<MacroGroup>().ForEach(delegate(MacroGroup g)
		{
			g.CollectionChanged += MacroGroup_CollectionChanged;
			g.MacroPropertyChanged += Macro_PropertyChanged;
		});
	}

	private void MacroGroup_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		this.MacroCollectionsChanged?.Invoke(sender, e);
	}

	private void Macro_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		this.MacroPropertyChanged?.Invoke(sender, e);
	}
}
