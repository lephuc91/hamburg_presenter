using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Actions;

public interface IStageScreenAssignments : ICloneable<StageScreenAssignments>, IImmutableObservableCollection<StageScreenAssignment>, IReadOnlyList<StageScreenAssignment>, IEnumerable<StageScreenAssignment>, IEnumerable, IReadOnlyCollection<StageScreenAssignment>, INotifyEnumerableChanged<StageScreenAssignment>, INotifyCollectionChanged
{
	bool IsValid { get; }

	UndoStack? UndoStack { get; set; }

	event System.Action? CollectionModified;

	void AddAssignment(StageScreenAssignment assignment);

	void InsertAssignment(StageScreenAssignment assignment, int index);

	void MoveAssignment(int fromIndex, int toIndex);

	void RemoveAssignment(StageScreenAssignment assignment);

	void Clear();

	void Deserialize(IEnumerable<Stage.Types.ScreenAssignment> protoScreenAssignments, IImmutableObservableCollection<ScreenArrangementBase> stageScreens);

	IEnumerable<Stage.Types.ScreenAssignment> Serialize();

	void Validate();
}
