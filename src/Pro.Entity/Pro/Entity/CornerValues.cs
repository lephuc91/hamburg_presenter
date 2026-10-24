using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class CornerValues : ICornerValues, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private AtomicObservableProperty<IGraphics.Types.Point> TopLeft_;

	private AtomicObservableProperty<IGraphics.Types.Point> TopRight_;

	private AtomicObservableProperty<IGraphics.Types.Point> BottomLeft_;

	private AtomicObservableProperty<IGraphics.Types.Point> BottomRight_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<IGraphics.Types.Point> TopLeft => TopLeft_;

	public IObservableProperty<IGraphics.Types.Point> TopRight => TopRight_;

	public IObservableProperty<IGraphics.Types.Point> BottomLeft => BottomLeft_;

	public IObservableProperty<IGraphics.Types.Point> BottomRight => BottomRight_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		TopLeft_.UpdateMap(_map);
		TopRight_.UpdateMap(_map);
		BottomLeft_.UpdateMap(_map);
		BottomRight_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		TopLeft_.UpdateMapOnInternalMapUpdate(_map);
		TopRight_.UpdateMapOnInternalMapUpdate(_map);
		BottomLeft_.UpdateMapOnInternalMapUpdate(_map);
		BottomRight_.UpdateMapOnInternalMapUpdate(_map);
	}

	public CornerValues()
		: this(new LoroMap())
	{
	}

	public CornerValues(LoroMap values)
	{
		_map = values;
		TopLeft_ = new AtomicObservableProperty<IGraphics.Types.Point>("top_left__1", LoroMap, IGraphics.Types.PointExtension.Deserialize, IGraphics.Types.PointExtension.Serialize);
		TopRight_ = new AtomicObservableProperty<IGraphics.Types.Point>("top_right__2", LoroMap, IGraphics.Types.PointExtension.Deserialize, IGraphics.Types.PointExtension.Serialize);
		BottomLeft_ = new AtomicObservableProperty<IGraphics.Types.Point>("bottom_left__3", LoroMap, IGraphics.Types.PointExtension.Deserialize, IGraphics.Types.PointExtension.Serialize);
		BottomRight_ = new AtomicObservableProperty<IGraphics.Types.Point>("bottom_right__4", LoroMap, IGraphics.Types.PointExtension.Deserialize, IGraphics.Types.PointExtension.Serialize);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(TopLeft_.WhenChangeHappens, TopRight_.WhenChangeHappens, BottomLeft_.WhenChangeHappens, BottomRight_.WhenChangeHappens);
	}

	public void Dispose()
	{
		TopLeft_.Dispose();
		TopRight_.Dispose();
		BottomLeft_.Dispose();
		BottomRight_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		TopLeft_.OnDiff(path, diff);
		TopRight_.OnDiff(path, diff);
		BottomLeft_.OnDiff(path, diff);
		BottomRight_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
