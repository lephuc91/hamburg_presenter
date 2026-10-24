using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class FileProperties : IFileProperties, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private AtomicObservableProperty<Url> LocalUrl_;

	private ComplexObservableProperty<IFileProperties.Types.IRemoteProperties> RemoteProperties_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Url> LocalUrl => LocalUrl_;

	public IComplexObservableProperty<IFileProperties.Types.IRemoteProperties> RemoteProperties => RemoteProperties_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		LocalUrl_.UpdateMap(_map);
		RemoteProperties_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		LocalUrl_.UpdateMapOnInternalMapUpdate(_map);
		RemoteProperties_.UpdateMapOnInternalMapUpdate(_map);
	}

	public FileProperties()
		: this(new LoroMap())
	{
	}

	public FileProperties(LoroMap values)
	{
		_map = values;
		LocalUrl_ = new AtomicObservableProperty<Url>("local_url__1", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
		RemoteProperties_ = new ComplexObservableProperty<IFileProperties.Types.IRemoteProperties>("remote_properties__2", LoroMap, new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = LocalUrl_.WhenChangeHappens.Merge(RemoteProperties_.WhenChangeHappens);
	}

	public void Dispose()
	{
		LocalUrl_.Dispose();
		RemoteProperties_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		LocalUrl_.OnDiff(path, diff);
		RemoteProperties_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
