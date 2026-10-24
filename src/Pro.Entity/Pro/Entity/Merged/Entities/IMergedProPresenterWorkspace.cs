using System;
using Pro.Entity.Collections;
using Pro.Entity.Merged.Collections;
using Pro.Entity.Properties;

namespace Pro.Entity.Merged.Entities;

public interface IMergedProPresenterWorkspace : IDisposable
{
	IComplexCollection<IProAudienceLook> AudienceLooks { get; }

	IComplexCollection<IProMask> Masks { get; }

	IComplexObservableProperty<IAudio.Types.ISettingsDocument> AudioSettings { get; }

	IObservableProperty<string> SelectedLibraryName { get; }

	IComplexObservableProperty<IRecording.Types.ISettingsDocument?> RecordSettings { get; }

	IObservableProperty<double> AudioInputTransitionTime { get; }

	IMergedCollection<IMergedVideoInput> VideoInputs { get; }

	IMergedCollection<IMergedAudioInput> AudioInputs { get; }

	IMergedCollection<IMergedScreen> Screens { get; }

	IObservableProperty<uint> AudioChannelCount { get; }

	IComplexObservableProperty<IDigitalAudio.Types.ISetup?> DigitalAudioSetup { get; }

	IComplexObservableProperty<IProAudienceLook> LiveAudienceLook { get; }

	IComplexCollection<IStage.Types.IScreenAssignment> StageLayoutMappings { get; }

	IProPresenterWorkspace Remote { get; }

	IProPresenterLocalWorkspace Local { get; }

	void RegisterLinkedDisposable(IDisposable disposable);
}
