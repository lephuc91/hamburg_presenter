using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class PlaylistTemplate : IPlaylistTemplate, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private MapCollection<IPlaylistTemplate.Types.ITemplate> Templates_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IComplexCollection<IPlaylistTemplate.Types.ITemplate> Templates => Templates_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Templates_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Templates_.UpdateMapOnInternalMapUpdate(_map);
	}

	public PlaylistTemplate()
		: this(new LoroMap())
	{
	}

	public PlaylistTemplate(LoroMap values)
	{
		_map = values;
		Templates_ = new MapCollection<IPlaylistTemplate.Types.ITemplate>(LoroMap, "templates__1", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Templates_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Templates_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Templates_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
