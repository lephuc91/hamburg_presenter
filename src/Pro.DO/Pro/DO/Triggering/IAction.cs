using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.DO.Application;
using Pro.DO.Label;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

public interface IAction : ICloneable<IAction>, INotifyPropertyChanged, IDisposable, IHasMediaContainerId
{
	ActionType ActionType { get; }

	Guid ID { get; }

	UndoStack UndoStack { get; set; }

	string Name { get; set; }

	bool IsEnabled { get; set; }

	TimeSlice DelayTime { get; set; }

	TimeSlice Duration { get; set; }

	ActionLabel? Label { get; set; }

	bool IsValid { get; }

	event System.Action DataModified;

	void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId);

	Pro.SerializationInterop.RVProtoData.Action Serialize();

	void CopyAction(IAction dest);
}
