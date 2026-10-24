using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using ProPresenter.DO.MacroGroups;

namespace ProPresenter.DO.Macros;

public class MacroCollectionSource : IMacroSource
{
	private readonly MacroCollection _macros;

	public IEnumerable<ProPresenterMacro> FlatCollection => _macros;

	public IEnumerable<ProPresenterMacro>? ActiveCollection { get; set; }

	public IEnumerable<MacroGroup> MacroGroups => Array.Empty<MacroGroup>();

	public event NotifyCollectionChangedEventHandler? MacroCollectionsChanged;

	public event PropertyChangedEventHandler? MacroPropertyChanged;

	public MacroCollectionSource(MacroCollection macros)
	{
		_macros = macros;
		_macros.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			this.MacroCollectionsChanged?.Invoke(s, e);
		};
		_macros.MacroPropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			this.MacroPropertyChanged?.Invoke(s, e);
		};
	}

	public ProPresenterMacro? FindMacro(Guid id, string name, Guid parentCollectionID, string parentCollectionName)
	{
		return _macros?.FirstOrDefaultBy((ProPresenterMacro m) => m.ID == id, (ProPresenterMacro m) => m.Name == name);
	}

	public void RemoveMacro(ProPresenterMacro macro)
	{
		_macros.UndoStack.StartIgnoring();
		_macros.RemoveMacro(macro);
		_macros.UndoStack.StopIgnoring();
	}

	public MacroGroup? CreateMacroGroup(string name, out int index)
	{
		index = -1;
		return null;
	}

	public void RemoveMacroGroup(MacroGroup macroGroup)
	{
	}
}
