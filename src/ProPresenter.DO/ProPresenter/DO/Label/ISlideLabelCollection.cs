using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.DO.Label;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Label;

public interface ISlideLabelCollection : INotifyEnumerableChanged<ActionLabel>, IEnumerable<ActionLabel>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<ActionLabel>, IDocumentProvider
{
	UndoStack UndoStack { get; }

	event System.Action ContentsModified;

	void Add(ActionLabel actionLabel);

	void Add(IEnumerable<ActionLabel> actionLabels);

	void Add(string text, System.Windows.Media.Color color);

	void Clear();

	void Deserialize(IEnumerable<Pro.SerializationInterop.RVProtoData.Action.Types.Label> labels, bool removeExisting = true);

	void Insert(int index, ActionLabel actionLabel, bool autoFinalize = true);

	void Remove(ActionLabel actionLabel, bool autoFinalize = true);

	void RemoveRange(IEnumerable<ActionLabel> slideLables);

	void Replace(ActionLabel existingLabel, ActionLabel newLabel);

	void Reset();

	ProLabelsDocument Serialize();
}
