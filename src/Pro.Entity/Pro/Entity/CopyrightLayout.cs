using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class CopyrightLayout : ICopyrightLayout, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private AtomicMapCollection<ICopyrightLayout.Types.Token> Tokens_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public ICollection<ICopyrightLayout.Types.Token> Tokens => Tokens_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Tokens_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Tokens_.UpdateMapOnInternalMapUpdate(_map);
	}

	public CopyrightLayout()
		: this(new LoroMap())
	{
	}

	public CopyrightLayout(LoroMap values)
	{
		_map = values;
		Tokens_ = new AtomicMapCollection<ICopyrightLayout.Types.Token>(LoroMap, "tokens__2", new EntityFactory(), ICopyrightLayout.Types.TokenExtension.Serialize);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Tokens_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Tokens_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Tokens_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
