using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProPresenterWorkspace : IProPresenterWorkspace, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private MapCollection<IProAudienceLook> AudienceLooks_;

	private MapCollection<IProMask> Masks_;

	private ComplexObservableProperty<IAudio.Types.ISettingsDocument> AudioSettings_;

	private StringObservableProperty SelectedLibraryName_;

	private OptionalComplexObservableProperty<IRecording.Types.ISettingsDocument> RecordSettings_;

	private DoubleObservableProperty AudioInputTransitionTime_;

	private MapCollection<ICloudProPresenterScreen> CloudOutputScreens_;

	private MapCollection<ICloudVideoInput> CloudVideoInputs_;

	private MapCollection<ICloudAudioInput> CloudAudioInputs_;

	private UintObservableProperty AudioChannelCount_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexCollection<IProAudienceLook> AudienceLooks => AudienceLooks_;

	public IComplexCollection<IProMask> Masks => Masks_;

	public IComplexObservableProperty<IAudio.Types.ISettingsDocument> AudioSettings => AudioSettings_;

	public IObservableProperty<string> SelectedLibraryName => SelectedLibraryName_;

	public IComplexObservableProperty<IRecording.Types.ISettingsDocument?> RecordSettings => RecordSettings_;

	public IObservableProperty<double> AudioInputTransitionTime => AudioInputTransitionTime_;

	public IComplexCollection<ICloudProPresenterScreen> CloudOutputScreens => CloudOutputScreens_;

	public IComplexCollection<ICloudVideoInput> CloudVideoInputs => CloudVideoInputs_;

	public IComplexCollection<ICloudAudioInput> CloudAudioInputs => CloudAudioInputs_;

	public IObservableProperty<uint> AudioChannelCount => AudioChannelCount_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		AudienceLooks_.UpdateMap(_map);
		Masks_.UpdateMap(_map);
		AudioSettings_.UpdateMap(_map);
		SelectedLibraryName_.UpdateMap(_map);
		RecordSettings_.UpdateMap(_map);
		AudioInputTransitionTime_.UpdateMap(_map);
		CloudOutputScreens_.UpdateMap(_map);
		CloudVideoInputs_.UpdateMap(_map);
		CloudAudioInputs_.UpdateMap(_map);
		AudioChannelCount_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		AudienceLooks_.UpdateMapOnInternalMapUpdate(_map);
		Masks_.UpdateMapOnInternalMapUpdate(_map);
		AudioSettings_.UpdateMapOnInternalMapUpdate(_map);
		SelectedLibraryName_.UpdateMapOnInternalMapUpdate(_map);
		RecordSettings_.UpdateMapOnInternalMapUpdate(_map);
		AudioInputTransitionTime_.UpdateMapOnInternalMapUpdate(_map);
		CloudOutputScreens_.UpdateMapOnInternalMapUpdate(_map);
		CloudVideoInputs_.UpdateMapOnInternalMapUpdate(_map);
		CloudAudioInputs_.UpdateMapOnInternalMapUpdate(_map);
		AudioChannelCount_.UpdateMapOnInternalMapUpdate(_map);
	}

	public ProPresenterWorkspace()
		: this(new LoroMap())
	{
	}

	public ProPresenterWorkspace(LoroMap values)
	{
		_map = values;
		AudienceLooks_ = new MapCollection<IProAudienceLook>(LoroMap, "audience_looks__2", new EntityFactory());
		Masks_ = new MapCollection<IProMask>(LoroMap, "masks__4", new EntityFactory());
		AudioSettings_ = new ComplexObservableProperty<IAudio.Types.ISettingsDocument>("audio_settings__7", LoroMap, new EntityFactory());
		SelectedLibraryName_ = new StringObservableProperty("selected_library_name__8", LoroMap);
		RecordSettings_ = new OptionalComplexObservableProperty<IRecording.Types.ISettingsDocument>("record_settings__9", LoroMap, new EntityFactory());
		AudioInputTransitionTime_ = new DoubleObservableProperty("audio_input_transition_time__12", LoroMap);
		CloudOutputScreens_ = new MapCollection<ICloudProPresenterScreen>(LoroMap, "cloud_output_screens__13", new EntityFactory());
		CloudVideoInputs_ = new MapCollection<ICloudVideoInput>(LoroMap, "cloud_video_inputs__14", new EntityFactory());
		CloudAudioInputs_ = new MapCollection<ICloudAudioInput>(LoroMap, "cloud_audio_inputs__15", new EntityFactory());
		AudioChannelCount_ = new UintObservableProperty("audio_channel_count__16", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(AudienceLooks_.WhenChangeHappens, Masks_.WhenChangeHappens, AudioSettings_.WhenChangeHappens, SelectedLibraryName_.WhenChangeHappens, RecordSettings_.WhenChangeHappens, AudioInputTransitionTime_.WhenChangeHappens, CloudOutputScreens_.WhenChangeHappens, CloudVideoInputs_.WhenChangeHappens, CloudAudioInputs_.WhenChangeHappens, AudioChannelCount_.WhenChangeHappens);
	}

	public void Dispose()
	{
		AudienceLooks_.Dispose();
		Masks_.Dispose();
		AudioSettings_.Dispose();
		SelectedLibraryName_.Dispose();
		RecordSettings_.Dispose();
		AudioInputTransitionTime_.Dispose();
		CloudOutputScreens_.Dispose();
		CloudVideoInputs_.Dispose();
		CloudAudioInputs_.Dispose();
		AudioChannelCount_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		AudienceLooks_.OnDiff(path, diff);
		Masks_.OnDiff(path, diff);
		AudioSettings_.OnDiff(path, diff);
		SelectedLibraryName_.OnDiff(path, diff);
		RecordSettings_.OnDiff(path, diff);
		AudioInputTransitionTime_.OnDiff(path, diff);
		CloudOutputScreens_.OnDiff(path, diff);
		CloudVideoInputs_.OnDiff(path, diff);
		CloudAudioInputs_.OnDiff(path, diff);
		AudioChannelCount_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
