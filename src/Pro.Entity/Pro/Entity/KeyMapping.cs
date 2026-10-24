using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class KeyMapping : IKeyMapping, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private ComplexObservableProperty<IKeyMapping.Types.IComputerKeyboard> Keyboard_;

	private ComplexObservableProperty<IKeyMapping.Types.IMidiKeyboard> Midi_;

	private UnionObservableProperty<IKeyMapping.Types.ITargetIdentifier> TargetIdentifier_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexObservableProperty<IKeyMapping.Types.IComputerKeyboard> Keyboard => Keyboard_;

	public IComplexObservableProperty<IKeyMapping.Types.IMidiKeyboard> Midi => Midi_;

	public IComplexObservableProperty<IKeyMapping.Types.ITargetIdentifier> TargetIdentifier => TargetIdentifier_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Keyboard_.UpdateMap(_map);
		Midi_.UpdateMap(_map);
		TargetIdentifier_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Keyboard_.UpdateMapOnInternalMapUpdate(_map);
		Midi_.UpdateMapOnInternalMapUpdate(_map);
		TargetIdentifier_.UpdateMapOnInternalMapUpdate(_map);
	}

	public KeyMapping()
		: this(new LoroMap())
	{
	}

	public KeyMapping(LoroMap values)
	{
		_map = values;
		Keyboard_ = new ComplexObservableProperty<IKeyMapping.Types.IComputerKeyboard>("keyboard__1", LoroMap, new EntityFactory());
		Midi_ = new ComplexObservableProperty<IKeyMapping.Types.IMidiKeyboard>("midi__2", LoroMap, new EntityFactory());
		TargetIdentifier_ = new UnionObservableProperty<IKeyMapping.Types.ITargetIdentifier>("TargetIdentifier__union", LoroMap, new IKeyMapping.Types.TargetIdentifierFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Keyboard_.WhenChangeHappens, Midi_.WhenChangeHappens, TargetIdentifier_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Keyboard_.Dispose();
		Midi_.Dispose();
		TargetIdentifier_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Keyboard_.OnDiff(path, diff);
		Midi_.OnDiff(path, diff);
		TargetIdentifier_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
