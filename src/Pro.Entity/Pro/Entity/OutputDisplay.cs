using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class OutputDisplay : IOutputDisplay, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private StringObservableProperty Name_;

	private StringObservableProperty Model_;

	private StringObservableProperty Serial_;

	private StringObservableProperty DeviceName_;

	private StringObservableProperty Vendor_;

	private UintObservableProperty ModeIndex_;

	private AtomicObservableProperty<IGraphics.Types.Rect> Bounds_;

	private EnumObservableProperty<IOutputDisplay.Types.Type> Type_;

	private ComplexObservableProperty<IDisplayMode> Mode_;

	private StringObservableProperty RenderId_;

	private IntObservableProperty VideoDelay_;

	private EnumObservableProperty<IOutputDisplay.Types.RenderFormat> RenderFormat_;

	private IntObservableProperty HdrMaxNitsOffset_;

	private UnionObservableProperty<IOutputDisplay.Types.IHardwareOptions> HardwareOptions_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<string> Name => Name_;

	public IObservableProperty<string> Model => Model_;

	public IObservableProperty<string> Serial => Serial_;

	public IObservableProperty<string> DeviceName => DeviceName_;

	public IObservableProperty<string> Vendor => Vendor_;

	public IObservableProperty<uint> ModeIndex => ModeIndex_;

	public IObservableProperty<IGraphics.Types.Rect> Bounds => Bounds_;

	public IObservableProperty<IOutputDisplay.Types.Type> Type => Type_;

	public IComplexObservableProperty<IDisplayMode> Mode => Mode_;

	public IObservableProperty<string> RenderId => RenderId_;

	public IObservableProperty<int> VideoDelay => VideoDelay_;

	public IObservableProperty<IOutputDisplay.Types.RenderFormat> RenderFormat => RenderFormat_;

	public IObservableProperty<int> HdrMaxNitsOffset => HdrMaxNitsOffset_;

	public IComplexObservableProperty<IOutputDisplay.Types.IHardwareOptions> HardwareOptions => HardwareOptions_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Name_.UpdateMap(_map);
		Model_.UpdateMap(_map);
		Serial_.UpdateMap(_map);
		DeviceName_.UpdateMap(_map);
		Vendor_.UpdateMap(_map);
		ModeIndex_.UpdateMap(_map);
		Bounds_.UpdateMap(_map);
		Type_.UpdateMap(_map);
		Mode_.UpdateMap(_map);
		RenderId_.UpdateMap(_map);
		VideoDelay_.UpdateMap(_map);
		RenderFormat_.UpdateMap(_map);
		HdrMaxNitsOffset_.UpdateMap(_map);
		HardwareOptions_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Name_.UpdateMapOnInternalMapUpdate(_map);
		Model_.UpdateMapOnInternalMapUpdate(_map);
		Serial_.UpdateMapOnInternalMapUpdate(_map);
		DeviceName_.UpdateMapOnInternalMapUpdate(_map);
		Vendor_.UpdateMapOnInternalMapUpdate(_map);
		ModeIndex_.UpdateMapOnInternalMapUpdate(_map);
		Bounds_.UpdateMapOnInternalMapUpdate(_map);
		Type_.UpdateMapOnInternalMapUpdate(_map);
		Mode_.UpdateMapOnInternalMapUpdate(_map);
		RenderId_.UpdateMapOnInternalMapUpdate(_map);
		VideoDelay_.UpdateMapOnInternalMapUpdate(_map);
		RenderFormat_.UpdateMapOnInternalMapUpdate(_map);
		HdrMaxNitsOffset_.UpdateMapOnInternalMapUpdate(_map);
		HardwareOptions_.UpdateMapOnInternalMapUpdate(_map);
	}

	public OutputDisplay()
		: this(new LoroMap())
	{
	}

	public OutputDisplay(LoroMap values)
	{
		_map = values;
		Name_ = new StringObservableProperty("name__1", LoroMap);
		Model_ = new StringObservableProperty("model__2", LoroMap);
		Serial_ = new StringObservableProperty("serial__3", LoroMap);
		DeviceName_ = new StringObservableProperty("deviceName__4", LoroMap);
		Vendor_ = new StringObservableProperty("vendor__5", LoroMap);
		ModeIndex_ = new UintObservableProperty("modeIndex__6", LoroMap);
		Bounds_ = new AtomicObservableProperty<IGraphics.Types.Rect>("bounds__7", LoroMap, IGraphics.Types.RectExtension.Deserialize, IGraphics.Types.RectExtension.Serialize);
		Type_ = new EnumObservableProperty<IOutputDisplay.Types.Type>("type__8", LoroMap);
		Mode_ = new ComplexObservableProperty<IDisplayMode>("mode__9", LoroMap, new EntityFactory());
		RenderId_ = new StringObservableProperty("render_id__10", LoroMap);
		VideoDelay_ = new IntObservableProperty("video_delay__12", LoroMap);
		RenderFormat_ = new EnumObservableProperty<IOutputDisplay.Types.RenderFormat>("render_format__13", LoroMap);
		HdrMaxNitsOffset_ = new IntObservableProperty("hdr_max_nits_offset__14", LoroMap);
		HardwareOptions_ = new UnionObservableProperty<IOutputDisplay.Types.IHardwareOptions>("HardwareOptions__union", LoroMap, new IOutputDisplay.Types.HardwareOptionsFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Name_.WhenChangeHappens, Model_.WhenChangeHappens, Serial_.WhenChangeHappens, DeviceName_.WhenChangeHappens, Vendor_.WhenChangeHappens, ModeIndex_.WhenChangeHappens, Bounds_.WhenChangeHappens, Type_.WhenChangeHappens, Mode_.WhenChangeHappens, RenderId_.WhenChangeHappens, VideoDelay_.WhenChangeHappens, RenderFormat_.WhenChangeHappens, HdrMaxNitsOffset_.WhenChangeHappens, HardwareOptions_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Name_.Dispose();
		Model_.Dispose();
		Serial_.Dispose();
		DeviceName_.Dispose();
		Vendor_.Dispose();
		ModeIndex_.Dispose();
		Bounds_.Dispose();
		Type_.Dispose();
		Mode_.Dispose();
		RenderId_.Dispose();
		VideoDelay_.Dispose();
		RenderFormat_.Dispose();
		HdrMaxNitsOffset_.Dispose();
		HardwareOptions_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Name_.OnDiff(path, diff);
		Model_.OnDiff(path, diff);
		Serial_.OnDiff(path, diff);
		DeviceName_.OnDiff(path, diff);
		Vendor_.OnDiff(path, diff);
		ModeIndex_.OnDiff(path, diff);
		Bounds_.OnDiff(path, diff);
		Type_.OnDiff(path, diff);
		Mode_.OnDiff(path, diff);
		RenderId_.OnDiff(path, diff);
		VideoDelay_.OnDiff(path, diff);
		RenderFormat_.OnDiff(path, diff);
		HdrMaxNitsOffset_.OnDiff(path, diff);
		HardwareOptions_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
