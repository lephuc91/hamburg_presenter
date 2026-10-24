using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class CloudProPresenterScreen : ICloudProPresenterScreen, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private StringObservableProperty Name_;

	private EnumObservableProperty<IProPresenterScreen.Types.ScreenType> ScreenType_;

	private GuidObservableProperty Uuid_;

	private AtomicObservableProperty<IGraphics.Types.Size> Size_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<string> Name => Name_;

	public IObservableProperty<IProPresenterScreen.Types.ScreenType> ScreenType => ScreenType_;

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<IGraphics.Types.Size> Size => Size_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Name_.UpdateMap(_map);
		ScreenType_.UpdateMap(_map);
		Uuid_.UpdateMap(_map);
		Size_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Name_.UpdateMapOnInternalMapUpdate(_map);
		ScreenType_.UpdateMapOnInternalMapUpdate(_map);
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Size_.UpdateMapOnInternalMapUpdate(_map);
	}

	public CloudProPresenterScreen()
		: this(new LoroMap())
	{
	}

	public CloudProPresenterScreen(LoroMap values)
	{
		_map = values;
		Name_ = new StringObservableProperty("name__1", LoroMap);
		ScreenType_ = new EnumObservableProperty<IProPresenterScreen.Types.ScreenType>("screen_type__2", LoroMap);
		Uuid_ = new GuidObservableProperty("uuid__6", LoroMap);
		Size_ = new AtomicObservableProperty<IGraphics.Types.Size>("size__7", LoroMap, IGraphics.Types.SizeExtension.Deserialize, IGraphics.Types.SizeExtension.Serialize);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Name_.WhenChangeHappens, ScreenType_.WhenChangeHappens, Uuid_.WhenChangeHappens, Size_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Name_.Dispose();
		ScreenType_.Dispose();
		Uuid_.Dispose();
		Size_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Name_.OnDiff(path, diff);
		ScreenType_.OnDiff(path, diff);
		Uuid_.OnDiff(path, diff);
		Size_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
