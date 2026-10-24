using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Macros;

namespace ProPresenter.DO.MacroGroups;

public interface IMacroGroupCollection : IDragDropNotifyEnumerableChanged<MacroGroup>, INotifyEnumerableChanged<MacroGroup>, IEnumerable<MacroGroup>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<MacroGroup>, IImmutableObservableCollection<MacroGroup>, IReadOnlyList<MacroGroup>, IReadOnlyCollection<MacroGroup>
{
	UndoStack UndoStack { get; }

	event System.Action? DataModified;

	event System.Action? TargetDirectoryChanged;

	void AddDefaultMacro();

	MacroGroup AddMacroGroup();

	void AddMacroGroup(MacroGroup macroGroup);

	void Deserialize(MacrosDocument document);

	void InsertMacroGroup(MacroGroup macroGroup, int index);

	void RemoveMacroGroup(MacroGroup macroGroup);

	void RemoveMacroGroups(IEnumerable<MacroGroup> macroGroups);

	MacrosDocument Serialize();

	void SetTriggerOnStartup(ProPresenterMacro? macro, bool triggerOnStartUp);
}
