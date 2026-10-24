using System;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions.Capture;

public interface ICapture : INotifyPropertyChanged
{
	CaptureType CaptureType { get; }

	bool IsValid { get; }

	UndoStack UndoStack { get; set; }

	event System.Action DataModified;

	void Serialize(Pro.SerializationInterop.RVProtoData.Action.Types.CaptureType action);

	void Deserialize(Pro.SerializationInterop.RVProtoData.Action.Types.CaptureType action);

	void CopyProperties(ICapture other);

	void Cleanup();
}
