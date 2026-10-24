using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class MessageLocalDocument : IMessageLocalDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private MapCollection<ILocalMessage> Messages_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexCollection<ILocalMessage> Messages => Messages_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Messages_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Messages_.UpdateMapOnInternalMapUpdate(_map);
	}

	public MessageLocalDocument()
		: this(new LoroMap())
	{
	}

	public MessageLocalDocument(LoroMap values)
	{
		_map = values;
		Messages_ = new MapCollection<ILocalMessage>(LoroMap, "messages__1", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Messages_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Messages_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Messages_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
