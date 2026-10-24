using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.DO.Transitions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Props;

public interface IPropGroupCollection : IImmutableObservableCollection<IPropGroup>, IReadOnlyList<IPropGroup>, IEnumerable<IPropGroup>, IEnumerable, IReadOnlyCollection<IPropGroup>, INotifyEnumerableChanged<IPropGroup>, INotifyCollectionChanged, IDragDropNotifyEnumerableChanged<IPropGroup>, IDragDropCollection<IPropGroup>, ICutPasteCollection<IPropGroup>, ICutCollection<IPropGroup>, INotifyPropertyChanged, IDocumentProvider
{
	UndoStack UndoStack { get; }

	TransitionParameters? SelectedTransition { get; set; }

	event System.Action DataModified;

	event System.Action TargetDirectoryChanged;

	void AddDefault();

	IPropGroup AddGroup();

	void AddGroup(IPropGroup group);

	void InsertGroup(IPropGroup group, int index);

	void RemoveGroup(IPropGroup group);

	void RemoveGroups(IEnumerable<IPropGroup> groups);

	PropDocument Serialize();

	void Deserialize(PropDocument document);
}
