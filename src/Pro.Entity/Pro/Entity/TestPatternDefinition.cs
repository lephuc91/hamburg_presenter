using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class TestPatternDefinition : ITestPatternDefinition, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private StringObservableProperty NameLocalizationKey_;

	private MapCollection<ITestPatternDefinition.Types.IProperty> Properties_;

	private BoolObservableProperty ShowDelaySettings_;

	private BoolObservableProperty IsDefault_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string> NameLocalizationKey => NameLocalizationKey_;

	public IComplexCollection<ITestPatternDefinition.Types.IProperty> Properties => Properties_;

	public IObservableProperty<bool> ShowDelaySettings => ShowDelaySettings_;

	public IObservableProperty<bool> IsDefault => IsDefault_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		NameLocalizationKey_.UpdateMap(_map);
		Properties_.UpdateMap(_map);
		ShowDelaySettings_.UpdateMap(_map);
		IsDefault_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		NameLocalizationKey_.UpdateMapOnInternalMapUpdate(_map);
		Properties_.UpdateMapOnInternalMapUpdate(_map);
		ShowDelaySettings_.UpdateMapOnInternalMapUpdate(_map);
		IsDefault_.UpdateMapOnInternalMapUpdate(_map);
	}

	public TestPatternDefinition()
		: this(new LoroMap())
	{
	}

	public TestPatternDefinition(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		NameLocalizationKey_ = new StringObservableProperty("name_localization_key__2", LoroMap);
		Properties_ = new MapCollection<ITestPatternDefinition.Types.IProperty>(LoroMap, "properties__3", new EntityFactory());
		ShowDelaySettings_ = new BoolObservableProperty("show_delay_settings__4", LoroMap);
		IsDefault_ = new BoolObservableProperty("is_default__5", LoroMap);
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, NameLocalizationKey_.WhenChangeHappens, Properties_.WhenChangeHappens, ShowDelaySettings_.WhenChangeHappens, IsDefault_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		NameLocalizationKey_.Dispose();
		Properties_.Dispose();
		ShowDelaySettings_.Dispose();
		IsDefault_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		NameLocalizationKey_.OnDiff(path, diff);
		Properties_.OnDiff(path, diff);
		ShowDelaySettings_.OnDiff(path, diff);
		IsDefault_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
