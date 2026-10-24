using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProMask : IProMask, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private ComplexObservableProperty<ISlide> BaseSlide_;

	private StringObservableProperty Name_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexObservableProperty<ISlide> BaseSlide => BaseSlide_;

	public IObservableProperty<string> Name => Name_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		BaseSlide_.UpdateMap(_map);
		Name_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		BaseSlide_.UpdateMapOnInternalMapUpdate(_map);
		Name_.UpdateMapOnInternalMapUpdate(_map);
	}

	public ProMask()
		: this(new LoroMap())
	{
	}

	public ProMask(LoroMap values)
	{
		_map = values;
		BaseSlide_ = new ComplexObservableProperty<ISlide>("base_slide__1", LoroMap, new EntityFactory());
		Name_ = new StringObservableProperty("name__2", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = BaseSlide_.WhenChangeHappens.Merge(Name_.WhenChangeHappens);
	}

	public void Dispose()
	{
		BaseSlide_.Dispose();
		Name_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		BaseSlide_.OnDiff(path, diff);
		Name_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
