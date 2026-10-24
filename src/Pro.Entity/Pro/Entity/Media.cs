using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Media : IMedia, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private ComplexObservableProperty<IMedia.Types.IMetadata> Metadata_;

	private UnionObservableProperty<IMedia.Types.ITypeProperties> TypeProperties_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IComplexObservableProperty<IMedia.Types.IMetadata> Metadata => Metadata_;

	public IComplexObservableProperty<IMedia.Types.ITypeProperties> TypeProperties => TypeProperties_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Metadata_.UpdateMap(_map);
		TypeProperties_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Metadata_.UpdateMapOnInternalMapUpdate(_map);
		TypeProperties_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Media()
		: this(new LoroMap())
	{
	}

	public Media(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		Metadata_ = new ComplexObservableProperty<IMedia.Types.IMetadata>("metadata__3", LoroMap, new EntityFactory());
		TypeProperties_ = new UnionObservableProperty<IMedia.Types.ITypeProperties>("TypeProperties__union", LoroMap, new IMedia.Types.TypePropertiesFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Metadata_.WhenChangeHappens, TypeProperties_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Metadata_.Dispose();
		TypeProperties_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Metadata_.OnDiff(path, diff);
		TypeProperties_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
