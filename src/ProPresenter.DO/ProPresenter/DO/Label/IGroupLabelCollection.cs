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

public interface IGroupLabelCollection : INotifyEnumerableChanged<GroupLabel>, IEnumerable<GroupLabel>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<GroupLabel>, IDocumentProvider
{
	UndoStack UndoStack { get; }

	event System.Action ContentsModified;

	void Add(GroupLabel groupLabel);

	void Add(IEnumerable<GroupLabel> groupLabels);

	void Add(string text, System.Windows.Media.Color color);

	void Clear();

	void Deserialize(IEnumerable<Group> groups, bool removeExisting = true);

	void Insert(int index, GroupLabel groupLabel);

	void Remove(GroupLabel groupLabel);

	void RemoveRange(IEnumerable<GroupLabel> groupLabels);

	void Replace(GroupLabel existingLabel, GroupLabel newLabel);

	void Reset(bool canUndo = false);

	ProGroupsDocument Serialize();
}
