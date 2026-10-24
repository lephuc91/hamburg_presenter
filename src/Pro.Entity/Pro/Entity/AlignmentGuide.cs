using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class AlignmentGuide : IAlignmentGuide, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private EnumObservableProperty<IAlignmentGuide.Types.GuidelineOrientation> Orientation_;

	private DoubleObservableProperty Location_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<IAlignmentGuide.Types.GuidelineOrientation> Orientation => Orientation_;

	public IObservableProperty<double> Location => Location_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Orientation_.UpdateMap(_map);
		Location_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Orientation_.UpdateMapOnInternalMapUpdate(_map);
		Location_.UpdateMapOnInternalMapUpdate(_map);
	}

	public AlignmentGuide()
		: this(new LoroMap())
	{
	}

	public AlignmentGuide(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		Orientation_ = new EnumObservableProperty<IAlignmentGuide.Types.GuidelineOrientation>("orientation__2", LoroMap);
		Location_ = new DoubleObservableProperty("location__3", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Orientation_.WhenChangeHappens, Location_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Orientation_.Dispose();
		Location_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Orientation_.OnDiff(path, diff);
		Location_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
