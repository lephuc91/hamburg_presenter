using System;
using System.Reactive.Disposables;
using Pro.Entity.Collections;
using Pro.Entity.Merged.Collections;
using Pro.Entity.Merged.Factory;
using Pro.Entity.Properties;

namespace Pro.Entity.Merged.Entities;

internal sealed class MergedProPresenterWorkspace : IMergedProPresenterWorkspace, IDisposable
{
	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	public IProPresenterWorkspace Remote { get; }

	public IProPresenterLocalWorkspace Local { get; }

	public IComplexCollection<IProAudienceLook> AudienceLooks => Remote.AudienceLooks;

	public IComplexCollection<IProMask> Masks => Remote.Masks;

	public IComplexObservableProperty<IAudio.Types.ISettingsDocument> AudioSettings => Remote.AudioSettings;

	public IObservableProperty<string> SelectedLibraryName => Remote.SelectedLibraryName;

	public IComplexObservableProperty<IRecording.Types.ISettingsDocument?> RecordSettings => Remote.RecordSettings;

	public IObservableProperty<double> AudioInputTransitionTime => Remote.AudioInputTransitionTime;

	public IObservableProperty<uint> AudioChannelCount => Remote.AudioChannelCount;

	public IMergedCollection<IMergedScreen> Screens { get; }

	public IMergedCollection<IMergedVideoInput> VideoInputs { get; }

	public IMergedCollection<IMergedAudioInput> AudioInputs { get; }

	public IComplexObservableProperty<IDigitalAudio.Types.ISetup?> DigitalAudioSetup => Local.DigitalAudioSetup;

	public IComplexObservableProperty<IProAudienceLook> LiveAudienceLook => Local.LiveAudienceLook;

	public IComplexCollection<IStage.Types.IScreenAssignment> StageLayoutMappings => Local.StageLayoutMappings;

	internal MergedProPresenterWorkspace(IProPresenterWorkspace remote, IProPresenterLocalWorkspace local, IMergedEntityFactory mergedEntityFactory)
	{
		Remote = remote;
		Local = local;
		Screens = mergedEntityFactory.CreateScreenCollection(remote.CloudOutputScreens, local.ProScreens);
		VideoInputs = mergedEntityFactory.CreateVideoInputCollection(remote.CloudVideoInputs, local.VideoInputs);
		AudioInputs = mergedEntityFactory.CreateAudioInputCollection(remote.CloudAudioInputs, local.AudioInputs);
		_disposables.Add(Screens);
		_disposables.Add(VideoInputs);
		_disposables.Add(AudioInputs);
	}

	public void Dispose()
	{
		_disposables.Dispose();
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_disposables.Add(disposable);
	}
}
