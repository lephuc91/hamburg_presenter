using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class CommunicationDeviceOption : ICommunicationDeviceOption, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private UnionObservableProperty<ICommunicationDeviceOption.Types.IOptionType> OptionType_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexObservableProperty<ICommunicationDeviceOption.Types.IOptionType> OptionType => OptionType_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		OptionType_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		OptionType_.UpdateMapOnInternalMapUpdate(_map);
	}

	public CommunicationDeviceOption()
		: this(new LoroMap())
	{
	}

	public CommunicationDeviceOption(LoroMap values)
	{
		_map = values;
		OptionType_ = new UnionObservableProperty<ICommunicationDeviceOption.Types.IOptionType>("OptionType__union", LoroMap, new ICommunicationDeviceOption.Types.OptionTypeFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(OptionType_.WhenChangeHappens);
	}

	public void Dispose()
	{
		OptionType_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		OptionType_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
