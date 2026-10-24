using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Slide : ISlide, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private MapCollection<ISlide.Types.IElement> Elements_;

	private GuidCollection ElementBuildOrder_;

	private MapCollection<IAlignmentGuide> Guidelines_;

	private BoolObservableProperty DrawsBackgroundColor_;

	private OptionalAtomicObservableProperty<Color> BackgroundColor_;

	private OptionalAtomicObservableProperty<IGraphics.Types.Size> Size_;

	private GuidObservableProperty Uuid_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexCollection<ISlide.Types.IElement> Elements => Elements_;

	public ICollection<Guid> ElementBuildOrder => ElementBuildOrder_;

	public IComplexCollection<IAlignmentGuide> Guidelines => Guidelines_;

	public IObservableProperty<bool> DrawsBackgroundColor => DrawsBackgroundColor_;

	public IObservableProperty<Color?> BackgroundColor => BackgroundColor_;

	public IObservableProperty<IGraphics.Types.Size?> Size => Size_;

	public IObservableProperty<Guid> Uuid => Uuid_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Elements_.UpdateMap(_map);
		ElementBuildOrder_.UpdateMap(_map);
		Guidelines_.UpdateMap(_map);
		DrawsBackgroundColor_.UpdateMap(_map);
		BackgroundColor_.UpdateMap(_map);
		Size_.UpdateMap(_map);
		Uuid_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Elements_.UpdateMapOnInternalMapUpdate(_map);
		ElementBuildOrder_.UpdateMapOnInternalMapUpdate(_map);
		Guidelines_.UpdateMapOnInternalMapUpdate(_map);
		DrawsBackgroundColor_.UpdateMapOnInternalMapUpdate(_map);
		BackgroundColor_.UpdateMapOnInternalMapUpdate(_map);
		Size_.UpdateMapOnInternalMapUpdate(_map);
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Slide()
		: this(new LoroMap())
	{
	}

	public Slide(LoroMap values)
	{
		_map = values;
		Elements_ = new MapCollection<ISlide.Types.IElement>(LoroMap, "elements__1", new EntityFactory());
		ElementBuildOrder_ = new GuidCollection(LoroMap, "element_build_order__2");
		Guidelines_ = new MapCollection<IAlignmentGuide>(LoroMap, "guidelines__3", new EntityFactory());
		DrawsBackgroundColor_ = new BoolObservableProperty("draws_background_color__4", LoroMap);
		BackgroundColor_ = new OptionalAtomicObservableProperty<Color>("background_color__5", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
		Size_ = new OptionalAtomicObservableProperty<IGraphics.Types.Size>("size__6", LoroMap, IGraphics.Types.SizeExtension.Deserialize, IGraphics.Types.SizeExtension.Serialize);
		Uuid_ = new GuidObservableProperty("uuid__7", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Elements_.WhenChangeHappens, ElementBuildOrder_.WhenChangeHappens, Guidelines_.WhenChangeHappens, DrawsBackgroundColor_.WhenChangeHappens, BackgroundColor_.WhenChangeHappens, Size_.WhenChangeHappens, Uuid_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Elements_.Dispose();
		ElementBuildOrder_.Dispose();
		Guidelines_.Dispose();
		DrawsBackgroundColor_.Dispose();
		BackgroundColor_.Dispose();
		Size_.Dispose();
		Uuid_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Elements_.OnDiff(path, diff);
		ElementBuildOrder_.OnDiff(path, diff);
		Guidelines_.OnDiff(path, diff);
		DrawsBackgroundColor_.OnDiff(path, diff);
		BackgroundColor_.OnDiff(path, diff);
		Size_.OnDiff(path, diff);
		Uuid_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
