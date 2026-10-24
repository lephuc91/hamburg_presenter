using System;
using Pro.Entity.Collections;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface IProPresenterWorkspace : IEntity, IDisposable
{
	IComplexCollection<IProAudienceLook> AudienceLooks { get; }

	IComplexCollection<IProMask> Masks { get; }

	IComplexObservableProperty<IAudio.Types.ISettingsDocument> AudioSettings { get; }

	IObservableProperty<string> SelectedLibraryName { get; }

	IComplexObservableProperty<IRecording.Types.ISettingsDocument?> RecordSettings { get; }

	IObservableProperty<double> AudioInputTransitionTime { get; }

	IComplexCollection<ICloudProPresenterScreen> CloudOutputScreens { get; }

	IComplexCollection<ICloudVideoInput> CloudVideoInputs { get; }

	IComplexCollection<ICloudAudioInput> CloudAudioInputs { get; }

	IObservableProperty<uint> AudioChannelCount { get; }
}
