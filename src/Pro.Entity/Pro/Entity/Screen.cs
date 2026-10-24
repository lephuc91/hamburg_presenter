using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Screen : IScreen, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private StringObservableProperty Name_;

	private AtomicObservableProperty<Color> Color_;

	private AtomicObservableProperty<IGraphics.Types.Rect> Bounds_;

	private BoolObservableProperty AspectRatioLocked_;

	private BoolObservableProperty OutputBoundsAspectRatioLocked_;

	private BoolObservableProperty CornerPinningEnabled_;

	private AtomicObservableProperty<IGraphics.Types.Rect> SubscreenUnitRect_;

	private DoubleObservableProperty Rotation_;

	private DoubleObservableProperty Gamma_;

	private DoubleObservableProperty BlackLevel_;

	private UintObservableProperty BlendedEdges_;

	private ComplexObservableProperty<ICornerValues> CornerValues_;

	private OptionalComplexObservableProperty<IOutputDisplay> OutputDisplay_;

	private ComplexObservableProperty<IScreen.Types.IColorAdjustment> ColorAdjustment_;

	private ComplexObservableProperty<IScreen.Types.IBlendCompensation> BlendCompensation_;

	private ComplexObservableProperty<IScreen.Types.IAlphaSettings> AlphaSettings_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string> Name => Name_;

	public IObservableProperty<Color> Color => Color_;

	public IObservableProperty<IGraphics.Types.Rect> Bounds => Bounds_;

	public IObservableProperty<bool> AspectRatioLocked => AspectRatioLocked_;

	public IObservableProperty<bool> OutputBoundsAspectRatioLocked => OutputBoundsAspectRatioLocked_;

	public IObservableProperty<bool> CornerPinningEnabled => CornerPinningEnabled_;

	public IObservableProperty<IGraphics.Types.Rect> SubscreenUnitRect => SubscreenUnitRect_;

	public IObservableProperty<double> Rotation => Rotation_;

	public IObservableProperty<double> Gamma => Gamma_;

	public IObservableProperty<double> BlackLevel => BlackLevel_;

	public IObservableProperty<uint> BlendedEdges => BlendedEdges_;

	public IComplexObservableProperty<ICornerValues> CornerValues => CornerValues_;

	public IComplexObservableProperty<IOutputDisplay?> OutputDisplay => OutputDisplay_;

	public IComplexObservableProperty<IScreen.Types.IColorAdjustment> ColorAdjustment => ColorAdjustment_;

	public IComplexObservableProperty<IScreen.Types.IBlendCompensation> BlendCompensation => BlendCompensation_;

	public IComplexObservableProperty<IScreen.Types.IAlphaSettings> AlphaSettings => AlphaSettings_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Name_.UpdateMap(_map);
		Color_.UpdateMap(_map);
		Bounds_.UpdateMap(_map);
		AspectRatioLocked_.UpdateMap(_map);
		OutputBoundsAspectRatioLocked_.UpdateMap(_map);
		CornerPinningEnabled_.UpdateMap(_map);
		SubscreenUnitRect_.UpdateMap(_map);
		Rotation_.UpdateMap(_map);
		Gamma_.UpdateMap(_map);
		BlackLevel_.UpdateMap(_map);
		BlendedEdges_.UpdateMap(_map);
		CornerValues_.UpdateMap(_map);
		OutputDisplay_.UpdateMap(_map);
		ColorAdjustment_.UpdateMap(_map);
		BlendCompensation_.UpdateMap(_map);
		AlphaSettings_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Name_.UpdateMapOnInternalMapUpdate(_map);
		Color_.UpdateMapOnInternalMapUpdate(_map);
		Bounds_.UpdateMapOnInternalMapUpdate(_map);
		AspectRatioLocked_.UpdateMapOnInternalMapUpdate(_map);
		OutputBoundsAspectRatioLocked_.UpdateMapOnInternalMapUpdate(_map);
		CornerPinningEnabled_.UpdateMapOnInternalMapUpdate(_map);
		SubscreenUnitRect_.UpdateMapOnInternalMapUpdate(_map);
		Rotation_.UpdateMapOnInternalMapUpdate(_map);
		Gamma_.UpdateMapOnInternalMapUpdate(_map);
		BlackLevel_.UpdateMapOnInternalMapUpdate(_map);
		BlendedEdges_.UpdateMapOnInternalMapUpdate(_map);
		CornerValues_.UpdateMapOnInternalMapUpdate(_map);
		OutputDisplay_.UpdateMapOnInternalMapUpdate(_map);
		ColorAdjustment_.UpdateMapOnInternalMapUpdate(_map);
		BlendCompensation_.UpdateMapOnInternalMapUpdate(_map);
		AlphaSettings_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Screen()
		: this(new LoroMap())
	{
	}

	public Screen(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		Name_ = new StringObservableProperty("name__2", LoroMap);
		Color_ = new AtomicObservableProperty<Color>("color__3", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
		Bounds_ = new AtomicObservableProperty<IGraphics.Types.Rect>("bounds__4", LoroMap, IGraphics.Types.RectExtension.Deserialize, IGraphics.Types.RectExtension.Serialize);
		AspectRatioLocked_ = new BoolObservableProperty("aspect_ratio_locked__5", LoroMap);
		OutputBoundsAspectRatioLocked_ = new BoolObservableProperty("output_bounds_aspect_ratio_locked__6", LoroMap);
		CornerPinningEnabled_ = new BoolObservableProperty("corner_pinning_enabled__7", LoroMap);
		SubscreenUnitRect_ = new AtomicObservableProperty<IGraphics.Types.Rect>("subscreen_unit_rect__8", LoroMap, IGraphics.Types.RectExtension.Deserialize, IGraphics.Types.RectExtension.Serialize);
		Rotation_ = new DoubleObservableProperty("rotation__9", LoroMap);
		Gamma_ = new DoubleObservableProperty("gamma__10", LoroMap);
		BlackLevel_ = new DoubleObservableProperty("black_level__11", LoroMap);
		BlendedEdges_ = new UintObservableProperty("blended_edges__12", LoroMap);
		CornerValues_ = new ComplexObservableProperty<ICornerValues>("corner_values__13", LoroMap, new EntityFactory());
		OutputDisplay_ = new OptionalComplexObservableProperty<IOutputDisplay>("output_display__14", LoroMap, new EntityFactory());
		ColorAdjustment_ = new ComplexObservableProperty<IScreen.Types.IColorAdjustment>("color_adjustment__16", LoroMap, new EntityFactory());
		BlendCompensation_ = new ComplexObservableProperty<IScreen.Types.IBlendCompensation>("blend_compensation__17", LoroMap, new EntityFactory());
		AlphaSettings_ = new ComplexObservableProperty<IScreen.Types.IAlphaSettings>("alpha_settings__18", LoroMap, new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Color_.WhenChangeHappens, Bounds_.WhenChangeHappens, AspectRatioLocked_.WhenChangeHappens, OutputBoundsAspectRatioLocked_.WhenChangeHappens, CornerPinningEnabled_.WhenChangeHappens, SubscreenUnitRect_.WhenChangeHappens, Rotation_.WhenChangeHappens, Gamma_.WhenChangeHappens, BlackLevel_.WhenChangeHappens, BlendedEdges_.WhenChangeHappens, CornerValues_.WhenChangeHappens, OutputDisplay_.WhenChangeHappens, ColorAdjustment_.WhenChangeHappens, BlendCompensation_.WhenChangeHappens, AlphaSettings_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Name_.Dispose();
		Color_.Dispose();
		Bounds_.Dispose();
		AspectRatioLocked_.Dispose();
		OutputBoundsAspectRatioLocked_.Dispose();
		CornerPinningEnabled_.Dispose();
		SubscreenUnitRect_.Dispose();
		Rotation_.Dispose();
		Gamma_.Dispose();
		BlackLevel_.Dispose();
		BlendedEdges_.Dispose();
		CornerValues_.Dispose();
		OutputDisplay_.Dispose();
		ColorAdjustment_.Dispose();
		BlendCompensation_.Dispose();
		AlphaSettings_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Name_.OnDiff(path, diff);
		Color_.OnDiff(path, diff);
		Bounds_.OnDiff(path, diff);
		AspectRatioLocked_.OnDiff(path, diff);
		OutputBoundsAspectRatioLocked_.OnDiff(path, diff);
		CornerPinningEnabled_.OnDiff(path, diff);
		SubscreenUnitRect_.OnDiff(path, diff);
		Rotation_.OnDiff(path, diff);
		Gamma_.OnDiff(path, diff);
		BlackLevel_.OnDiff(path, diff);
		BlendedEdges_.OnDiff(path, diff);
		CornerValues_.OnDiff(path, diff);
		OutputDisplay_.OnDiff(path, diff);
		ColorAdjustment_.OnDiff(path, diff);
		BlendCompensation_.OnDiff(path, diff);
		AlphaSettings_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
