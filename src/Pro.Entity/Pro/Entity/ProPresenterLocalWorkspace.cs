using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProPresenterLocalWorkspace : IProPresenterLocalWorkspace, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private OptionalComplexObservableProperty<IDigitalAudio.Types.ISetup> DigitalAudioSetup_;

	private MapCollection<IProPresenterScreen> ProScreens_;

	private MapCollection<IVideoInput> VideoInputs_;

	private MapCollection<IAudioInput> AudioInputs_;

	private ComplexObservableProperty<IProAudienceLook> LiveAudienceLook_;

	private MapCollection<IStage.Types.IScreenAssignment> StageLayoutMappings_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexObservableProperty<IDigitalAudio.Types.ISetup?> DigitalAudioSetup => DigitalAudioSetup_;

	public IComplexCollection<IProPresenterScreen> ProScreens => ProScreens_;

	public IComplexCollection<IVideoInput> VideoInputs => VideoInputs_;

	public IComplexCollection<IAudioInput> AudioInputs => AudioInputs_;

	public IComplexObservableProperty<IProAudienceLook> LiveAudienceLook => LiveAudienceLook_;

	public IComplexCollection<IStage.Types.IScreenAssignment> StageLayoutMappings => StageLayoutMappings_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		DigitalAudioSetup_.UpdateMap(_map);
		ProScreens_.UpdateMap(_map);
		VideoInputs_.UpdateMap(_map);
		AudioInputs_.UpdateMap(_map);
		LiveAudienceLook_.UpdateMap(_map);
		StageLayoutMappings_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		DigitalAudioSetup_.UpdateMapOnInternalMapUpdate(_map);
		ProScreens_.UpdateMapOnInternalMapUpdate(_map);
		VideoInputs_.UpdateMapOnInternalMapUpdate(_map);
		AudioInputs_.UpdateMapOnInternalMapUpdate(_map);
		LiveAudienceLook_.UpdateMapOnInternalMapUpdate(_map);
		StageLayoutMappings_.UpdateMapOnInternalMapUpdate(_map);
	}

	public ProPresenterLocalWorkspace()
		: this(new LoroMap())
	{
	}

	public ProPresenterLocalWorkspace(LoroMap values)
	{
		_map = values;
		DigitalAudioSetup_ = new OptionalComplexObservableProperty<IDigitalAudio.Types.ISetup>("digital_audio_setup__1", LoroMap, new EntityFactory());
		ProScreens_ = new MapCollection<IProPresenterScreen>(LoroMap, "pro_screens__2", new EntityFactory());
		VideoInputs_ = new MapCollection<IVideoInput>(LoroMap, "video_inputs__3", new EntityFactory());
		AudioInputs_ = new MapCollection<IAudioInput>(LoroMap, "audio_inputs__4", new EntityFactory());
		LiveAudienceLook_ = new ComplexObservableProperty<IProAudienceLook>("live_audience_look__5", LoroMap, new EntityFactory());
		StageLayoutMappings_ = new MapCollection<IStage.Types.IScreenAssignment>(LoroMap, "stage_layout_mappings__6", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(DigitalAudioSetup_.WhenChangeHappens, ProScreens_.WhenChangeHappens, VideoInputs_.WhenChangeHappens, AudioInputs_.WhenChangeHappens, LiveAudienceLook_.WhenChangeHappens, StageLayoutMappings_.WhenChangeHappens);
	}

	public void Dispose()
	{
		DigitalAudioSetup_.Dispose();
		ProScreens_.Dispose();
		VideoInputs_.Dispose();
		AudioInputs_.Dispose();
		LiveAudienceLook_.Dispose();
		StageLayoutMappings_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		DigitalAudioSetup_.OnDiff(path, diff);
		ProScreens_.OnDiff(path, diff);
		VideoInputs_.OnDiff(path, diff);
		AudioInputs_.OnDiff(path, diff);
		LiveAudienceLook_.OnDiff(path, diff);
		StageLayoutMappings_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
