using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using ProPresenter.DO.Macros;

namespace ProPresenter.DO.MacroGroups;

public interface IMacroSource
{
	IEnumerable<ProPresenterMacro> FlatCollection { get; }

	IEnumerable<ProPresenterMacro>? ActiveCollection { get; set; }

	IEnumerable<MacroGroup> MacroGroups { get; }

	event NotifyCollectionChangedEventHandler MacroCollectionsChanged;

	event PropertyChangedEventHandler MacroPropertyChanged;

	ProPresenterMacro? FindMacro(Guid id, string name, Guid parentCollectionID, string parentCollectionName);

	void RemoveMacro(ProPresenterMacro macro);

	MacroGroup? CreateMacroGroup(string name, out int index);

	void RemoveMacroGroup(MacroGroup macroGroup);
}
