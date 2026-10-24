using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Effect : IEffect, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private BoolObservableProperty Enabled_;

	private StringObservableProperty Name_;

	private StringObservableProperty RenderId_;

	private StringObservableProperty BehaviorDescription_;

	private StringObservableProperty Category_;

	private MapCollection<IEffect.Types.IEffectVariable> Variables_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<bool> Enabled => Enabled_;

	public IObservableProperty<string> Name => Name_;

	public IObservableProperty<string> RenderId => RenderId_;

	public IObservableProperty<string> BehaviorDescription => BehaviorDescription_;

	public IObservableProperty<string> Category => Category_;

	public IComplexCollection<IEffect.Types.IEffectVariable> Variables => Variables_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Enabled_.UpdateMap(_map);
		Name_.UpdateMap(_map);
		RenderId_.UpdateMap(_map);
		BehaviorDescription_.UpdateMap(_map);
		Category_.UpdateMap(_map);
		Variables_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Enabled_.UpdateMapOnInternalMapUpdate(_map);
		Name_.UpdateMapOnInternalMapUpdate(_map);
		RenderId_.UpdateMapOnInternalMapUpdate(_map);
		BehaviorDescription_.UpdateMapOnInternalMapUpdate(_map);
		Category_.UpdateMapOnInternalMapUpdate(_map);
		Variables_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Effect()
		: this(new LoroMap())
	{
	}

	public Effect(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		Enabled_ = new BoolObservableProperty("enabled__2", LoroMap);
		Name_ = new StringObservableProperty("name__3", LoroMap);
		RenderId_ = new StringObservableProperty("render_id__4", LoroMap);
		BehaviorDescription_ = new StringObservableProperty("behavior_description__5", LoroMap);
		Category_ = new StringObservableProperty("category__6", LoroMap);
		Variables_ = new MapCollection<IEffect.Types.IEffectVariable>(LoroMap, "variables__7", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Enabled_.WhenChangeHappens, Name_.WhenChangeHappens, RenderId_.WhenChangeHappens, BehaviorDescription_.WhenChangeHappens, Category_.WhenChangeHappens, Variables_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Enabled_.Dispose();
		Name_.Dispose();
		RenderId_.Dispose();
		BehaviorDescription_.Dispose();
		Category_.Dispose();
		Variables_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Enabled_.OnDiff(path, diff);
		Name_.OnDiff(path, diff);
		RenderId_.OnDiff(path, diff);
		BehaviorDescription_.OnDiff(path, diff);
		Category_.OnDiff(path, diff);
		Variables_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
