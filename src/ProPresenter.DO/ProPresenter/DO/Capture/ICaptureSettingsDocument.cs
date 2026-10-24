using System;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public interface ICaptureSettingsDocument : INotifyPropertyChanged
{
	IStreamCollection Streams { get; }

	ICapturePresetCollection Presets { get; }

	IStream? DefaultStream { get; }

	ICapturePreset? ActivePreset { get; set; }

	UndoStack UndoStack { get; }

	event System.Action DataModified;

	Recording.Types.SettingsDocument Serialize();

	void Deserialize(Recording.Types.SettingsDocument settingsDocument);
}
