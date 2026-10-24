using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class MusicKeyScale : IMusicKeyScale, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private EnumObservableProperty<IMusicKeyScale.Types.MusicKey> MusicKey_;

	private EnumObservableProperty<IMusicKeyScale.Types.MusicScale> MusicScale_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<IMusicKeyScale.Types.MusicKey> MusicKey => MusicKey_;

	public IObservableProperty<IMusicKeyScale.Types.MusicScale> MusicScale => MusicScale_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		MusicKey_.UpdateMap(_map);
		MusicScale_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		MusicKey_.UpdateMapOnInternalMapUpdate(_map);
		MusicScale_.UpdateMapOnInternalMapUpdate(_map);
	}

	public MusicKeyScale()
		: this(new LoroMap())
	{
	}

	public MusicKeyScale(LoroMap values)
	{
		_map = values;
		MusicKey_ = new EnumObservableProperty<IMusicKeyScale.Types.MusicKey>("music_key__1", LoroMap);
		MusicScale_ = new EnumObservableProperty<IMusicKeyScale.Types.MusicScale>("music_scale__2", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = MusicKey_.WhenChangeHappens.Merge(MusicScale_.WhenChangeHappens);
	}

	public void Dispose()
	{
		MusicKey_.Dispose();
		MusicScale_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		MusicKey_.OnDiff(path, diff);
		MusicScale_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
