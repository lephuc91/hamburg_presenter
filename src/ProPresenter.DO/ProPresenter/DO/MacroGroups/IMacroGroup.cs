using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Macros;

namespace ProPresenter.DO.MacroGroups;

public interface IMacroGroup : IDragDropNotifyEnumerableChanged<ProPresenterMacro>, INotifyEnumerableChanged<ProPresenterMacro>, IEnumerable<ProPresenterMacro>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<ProPresenterMacro>, ICutPasteCollection<IMacro>, ICutCollection<IMacro>, IActionRepoContainer, ICloneable<MacroGroup>, INotifyPropertyChanged
{
	Guid ID { get; }

	string Name { get; set; }

	event System.Action? DataModified;

	event PropertyChangedEventHandler? MacroPropertyChanged;

	void AddMacro();

	void AddMacro(ProPresenterMacro macro);

	void Deserialize(MacrosDocument document, MacrosDocument.Types.MacroCollection collection, ApplicationData applicationData);

	void InsertMacro(ProPresenterMacro macro, int index);

	void InsertMacros(IEnumerable<ProPresenterMacro> macros, int index);

	void RemoveMacro(ProPresenterMacro macro);

	void RemoveMacros(IEnumerable<ProPresenterMacro> macros);

	MacrosDocument.Types.MacroCollection Serialize(MacrosDocument document);
}
