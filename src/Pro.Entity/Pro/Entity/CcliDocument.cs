using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class CcliDocument : ICcliDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private BoolObservableProperty EnableCcliDisplay_;

	private StringObservableProperty CcliLicense_;

	private EnumObservableProperty<ICcliDocument.Types.DisplayType> DisplayType_;

	private ComplexObservableProperty<ITemplate.Types.ISlide> Template_;

	private ComplexObservableProperty<ICopyrightLayout> Layout_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<bool> EnableCcliDisplay => EnableCcliDisplay_;

	public IObservableProperty<string> CcliLicense => CcliLicense_;

	public IObservableProperty<ICcliDocument.Types.DisplayType> DisplayType => DisplayType_;

	public IComplexObservableProperty<ITemplate.Types.ISlide> Template => Template_;

	public IComplexObservableProperty<ICopyrightLayout> Layout => Layout_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		EnableCcliDisplay_.UpdateMap(_map);
		CcliLicense_.UpdateMap(_map);
		DisplayType_.UpdateMap(_map);
		Template_.UpdateMap(_map);
		Layout_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		EnableCcliDisplay_.UpdateMapOnInternalMapUpdate(_map);
		CcliLicense_.UpdateMapOnInternalMapUpdate(_map);
		DisplayType_.UpdateMapOnInternalMapUpdate(_map);
		Template_.UpdateMapOnInternalMapUpdate(_map);
		Layout_.UpdateMapOnInternalMapUpdate(_map);
	}

	public CcliDocument()
		: this(new LoroMap())
	{
	}

	public CcliDocument(LoroMap values)
	{
		_map = values;
		EnableCcliDisplay_ = new BoolObservableProperty("enable_ccli_display__2", LoroMap);
		CcliLicense_ = new StringObservableProperty("ccli_license__3", LoroMap);
		DisplayType_ = new EnumObservableProperty<ICcliDocument.Types.DisplayType>("display_type__4", LoroMap);
		Template_ = new ComplexObservableProperty<ITemplate.Types.ISlide>("template__5", LoroMap, new EntityFactory());
		Layout_ = new ComplexObservableProperty<ICopyrightLayout>("layout__6", LoroMap, new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(EnableCcliDisplay_.WhenChangeHappens, CcliLicense_.WhenChangeHappens, DisplayType_.WhenChangeHappens, Template_.WhenChangeHappens, Layout_.WhenChangeHappens);
	}

	public void Dispose()
	{
		EnableCcliDisplay_.Dispose();
		CcliLicense_.Dispose();
		DisplayType_.Dispose();
		Template_.Dispose();
		Layout_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		EnableCcliDisplay_.OnDiff(path, diff);
		CcliLicense_.OnDiff(path, diff);
		DisplayType_.OnDiff(path, diff);
		Template_.OnDiff(path, diff);
		Layout_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
