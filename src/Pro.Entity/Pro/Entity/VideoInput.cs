using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class VideoInput : IVideoInput, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private OptionalStringObservableProperty UserDescription_;

	private OptionalComplexObservableProperty<IMedia.Types.IVideoDevice> VideoInputDevice_;

	private AtomicObservableProperty<Color> DisplayColor_;

	private EnumObservableProperty<IVideoInput.Types.AudioDeviceType> AudioType_;

	private EnumObservableProperty<AlphaType> AlphaType_;

	private UnionObservableProperty<IVideoInput.Types.IAltAudioSource> AltAudioSource_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string?> UserDescription => UserDescription_;

	public IComplexObservableProperty<IMedia.Types.IVideoDevice?> VideoInputDevice => VideoInputDevice_;

	public IObservableProperty<Color> DisplayColor => DisplayColor_;

	public IObservableProperty<IVideoInput.Types.AudioDeviceType> AudioType => AudioType_;

	public IObservableProperty<AlphaType> AlphaType => AlphaType_;

	public IComplexObservableProperty<IVideoInput.Types.IAltAudioSource> AltAudioSource => AltAudioSource_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		UserDescription_.UpdateMap(_map);
		VideoInputDevice_.UpdateMap(_map);
		DisplayColor_.UpdateMap(_map);
		AudioType_.UpdateMap(_map);
		AlphaType_.UpdateMap(_map);
		AltAudioSource_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		UserDescription_.UpdateMapOnInternalMapUpdate(_map);
		VideoInputDevice_.UpdateMapOnInternalMapUpdate(_map);
		DisplayColor_.UpdateMapOnInternalMapUpdate(_map);
		AudioType_.UpdateMapOnInternalMapUpdate(_map);
		AlphaType_.UpdateMapOnInternalMapUpdate(_map);
		AltAudioSource_.UpdateMapOnInternalMapUpdate(_map);
	}

	public VideoInput()
		: this(new LoroMap())
	{
	}

	public VideoInput(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		UserDescription_ = new OptionalStringObservableProperty("user_description__2", LoroMap);
		VideoInputDevice_ = new OptionalComplexObservableProperty<IMedia.Types.IVideoDevice>("video_input_device__3", LoroMap, new EntityFactory());
		DisplayColor_ = new AtomicObservableProperty<Color>("display_color__4", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
		AudioType_ = new EnumObservableProperty<IVideoInput.Types.AudioDeviceType>("audio_type__8", LoroMap);
		AlphaType_ = new EnumObservableProperty<AlphaType>("alpha_type__9", LoroMap);
		AltAudioSource_ = new UnionObservableProperty<IVideoInput.Types.IAltAudioSource>("AltAudioSource__union", LoroMap, new IVideoInput.Types.AltAudioSourceFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, UserDescription_.WhenChangeHappens, VideoInputDevice_.WhenChangeHappens, DisplayColor_.WhenChangeHappens, AudioType_.WhenChangeHappens, AlphaType_.WhenChangeHappens, AltAudioSource_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		UserDescription_.Dispose();
		VideoInputDevice_.Dispose();
		DisplayColor_.Dispose();
		AudioType_.Dispose();
		AlphaType_.Dispose();
		AltAudioSource_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		UserDescription_.OnDiff(path, diff);
		VideoInputDevice_.OnDiff(path, diff);
		DisplayColor_.OnDiff(path, diff);
		AudioType_.OnDiff(path, diff);
		AlphaType_.OnDiff(path, diff);
		AltAudioSource_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
