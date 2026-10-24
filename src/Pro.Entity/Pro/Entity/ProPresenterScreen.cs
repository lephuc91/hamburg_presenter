using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProPresenterScreen : IProPresenterScreen, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private StringObservableProperty Name_;

	private EnumObservableProperty<IProPresenterScreen.Types.ScreenType> ScreenType_;

	private AtomicObservableProperty<Color> BackgroundColor_;

	private GuidObservableProperty Uuid_;

	private BoolObservableProperty BackgroundColorEnabled_;

	private UnionObservableProperty<IProPresenterScreen.Types.IArrangement> Arrangement_;

	private UnionObservableProperty<IProPresenterScreen.Types.IRenderingEnabledOptional> RenderingEnabledOptional_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<string> Name => Name_;

	public IObservableProperty<IProPresenterScreen.Types.ScreenType> ScreenType => ScreenType_;

	public IObservableProperty<Color> BackgroundColor => BackgroundColor_;

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<bool> BackgroundColorEnabled => BackgroundColorEnabled_;

	public IComplexObservableProperty<IProPresenterScreen.Types.IArrangement> Arrangement => Arrangement_;

	public IComplexObservableProperty<IProPresenterScreen.Types.IRenderingEnabledOptional> RenderingEnabledOptional => RenderingEnabledOptional_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Name_.UpdateMap(_map);
		ScreenType_.UpdateMap(_map);
		BackgroundColor_.UpdateMap(_map);
		Uuid_.UpdateMap(_map);
		BackgroundColorEnabled_.UpdateMap(_map);
		Arrangement_.UpdateMap(_map);
		RenderingEnabledOptional_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Name_.UpdateMapOnInternalMapUpdate(_map);
		ScreenType_.UpdateMapOnInternalMapUpdate(_map);
		BackgroundColor_.UpdateMapOnInternalMapUpdate(_map);
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		BackgroundColorEnabled_.UpdateMapOnInternalMapUpdate(_map);
		Arrangement_.UpdateMapOnInternalMapUpdate(_map);
		RenderingEnabledOptional_.UpdateMapOnInternalMapUpdate(_map);
	}

	public ProPresenterScreen()
		: this(new LoroMap())
	{
	}

	public ProPresenterScreen(LoroMap values)
	{
		_map = values;
		Name_ = new StringObservableProperty("name__1", LoroMap);
		ScreenType_ = new EnumObservableProperty<IProPresenterScreen.Types.ScreenType>("screen_type__2", LoroMap);
		BackgroundColor_ = new AtomicObservableProperty<Color>("background_color__6", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
		Uuid_ = new GuidObservableProperty("uuid__7", LoroMap);
		BackgroundColorEnabled_ = new BoolObservableProperty("background_color_enabled__8", LoroMap);
		Arrangement_ = new UnionObservableProperty<IProPresenterScreen.Types.IArrangement>("Arrangement__union", LoroMap, new IProPresenterScreen.Types.ArrangementFactory());
		RenderingEnabledOptional_ = new UnionObservableProperty<IProPresenterScreen.Types.IRenderingEnabledOptional>("RenderingEnabledOptional__union", LoroMap, new IProPresenterScreen.Types.RenderingEnabledOptionalFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Name_.WhenChangeHappens, ScreenType_.WhenChangeHappens, BackgroundColor_.WhenChangeHappens, Uuid_.WhenChangeHappens, BackgroundColorEnabled_.WhenChangeHappens, Arrangement_.WhenChangeHappens, RenderingEnabledOptional_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Name_.Dispose();
		ScreenType_.Dispose();
		BackgroundColor_.Dispose();
		Uuid_.Dispose();
		BackgroundColorEnabled_.Dispose();
		Arrangement_.Dispose();
		RenderingEnabledOptional_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Name_.OnDiff(path, diff);
		ScreenType_.OnDiff(path, diff);
		BackgroundColor_.OnDiff(path, diff);
		Uuid_.OnDiff(path, diff);
		BackgroundColorEnabled_.OnDiff(path, diff);
		Arrangement_.OnDiff(path, diff);
		RenderingEnabledOptional_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
