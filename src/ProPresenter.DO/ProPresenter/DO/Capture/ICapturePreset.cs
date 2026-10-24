using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public interface ICapturePreset : ICloneable<ICapturePreset>, INotifyPropertyChanged
{
	Guid ID { get; set; }

	string Name { get; set; }

	IStream DefaultStream { get; }

	IStreamCollection Streams { get; }

	IDiskDestination? DiskDestination { get; }

	IRtmpDestination? RTMPDestination { get; }

	IResiDestination? ResiDestination { get; }

	UndoStack? UndoStack { get; set; }

	event System.Action DataModified;

	void Deserialize(Recording.Types.Preset protoPreset);

	Recording.Types.Preset Serialize();
}
