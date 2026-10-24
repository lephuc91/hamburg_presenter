using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class CollectionElementType : ICollectionElementType, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private OptionalGuidObservableProperty ParameterUuid_;

	private OptionalStringObservableProperty ParameterName_;

	private OptionalComplexObservableProperty<ICollectionElementType> ParentCollection_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid?> ParameterUuid => ParameterUuid_;

	public IObservableProperty<string?> ParameterName => ParameterName_;

	public IComplexObservableProperty<ICollectionElementType?> ParentCollection => ParentCollection_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		ParameterUuid_.UpdateMap(_map);
		ParameterName_.UpdateMap(_map);
		ParentCollection_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		ParameterUuid_.UpdateMapOnInternalMapUpdate(_map);
		ParameterName_.UpdateMapOnInternalMapUpdate(_map);
		ParentCollection_.UpdateMapOnInternalMapUpdate(_map);
	}

	public CollectionElementType()
		: this(new LoroMap())
	{
	}

	public CollectionElementType(LoroMap values)
	{
		_map = values;
		ParameterUuid_ = new OptionalGuidObservableProperty("parameter_uuid__1", LoroMap);
		ParameterName_ = new OptionalStringObservableProperty("parameter_name__2", LoroMap);
		ParentCollection_ = new OptionalComplexObservableProperty<ICollectionElementType>("parent_collection__3", LoroMap, new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(ParameterUuid_.WhenChangeHappens, ParameterName_.WhenChangeHappens, ParentCollection_.WhenChangeHappens);
	}

	public void Dispose()
	{
		ParameterUuid_.Dispose();
		ParameterName_.Dispose();
		ParentCollection_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		ParameterUuid_.OnDiff(path, diff);
		ParameterName_.OnDiff(path, diff);
		ParentCollection_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
