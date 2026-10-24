using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Arrangements;

public interface IArrangement : INotifyEnumerableChanged<CueGroup>, IEnumerable<CueGroup>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IReadOnlyCollection<CueGroup>
{
	Guid ID { get; }

	string Name { get; set; }

	bool IsMaster { get; }

	IImmutableObservableCollection<ArrangedCue> ArrangedCues { get; }

	UndoStack UndoStack { get; set; }

	void MoveArrangementGroups(IEnumerable<CueGroup> groups, int index);

	void AddArrangementGroup(CueGroup group);

	void InsertArrangementGroup(int index, CueGroup group);

	bool RemoveArrangementGroup(CueGroup group);

	void Clear();

	Pro.SerializationInterop.RVProtoData.Presentation.Types.Arrangement Serialize();

	void Deserialize(Pro.SerializationInterop.RVProtoData.Presentation.Types.Arrangement protoArrangement);

	bool RemoveArrangementGroups(IEnumerable<CueGroup> group);
}
