using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class CloudVideoInput : ICloudVideoInput, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private OptionalStringObservableProperty UserDescription_;

	private OptionalAtomicObservableProperty<Url> ThumbnailPath_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string?> UserDescription => UserDescription_;

	public IObservableProperty<Url?> ThumbnailPath => ThumbnailPath_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		UserDescription_.UpdateMap(_map);
		ThumbnailPath_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		UserDescription_.UpdateMapOnInternalMapUpdate(_map);
		ThumbnailPath_.UpdateMapOnInternalMapUpdate(_map);
	}

	public CloudVideoInput()
		: this(new LoroMap())
	{
	}

	public CloudVideoInput(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		UserDescription_ = new OptionalStringObservableProperty("user_description__2", LoroMap);
		ThumbnailPath_ = new OptionalAtomicObservableProperty<Url>("thumbnail_path__3", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, UserDescription_.WhenChangeHappens, ThumbnailPath_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		UserDescription_.Dispose();
		ThumbnailPath_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		UserDescription_.OnDiff(path, diff);
		ThumbnailPath_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
