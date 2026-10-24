using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class AudioInput : IAudioInput, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private StringObservableProperty UserDescription_;

	private ComplexObservableProperty<IAudioInput.Types.IBehaviorMode> BehaviorMode_;

	private UnionObservableProperty<IAudioInput.Types.ISource> Source_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string> UserDescription => UserDescription_;

	public IComplexObservableProperty<IAudioInput.Types.IBehaviorMode> BehaviorMode => BehaviorMode_;

	public IComplexObservableProperty<IAudioInput.Types.ISource> Source => Source_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		UserDescription_.UpdateMap(_map);
		BehaviorMode_.UpdateMap(_map);
		Source_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		UserDescription_.UpdateMapOnInternalMapUpdate(_map);
		BehaviorMode_.UpdateMapOnInternalMapUpdate(_map);
		Source_.UpdateMapOnInternalMapUpdate(_map);
	}

	public AudioInput()
		: this(new LoroMap())
	{
	}

	public AudioInput(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		UserDescription_ = new StringObservableProperty("user_description__2", LoroMap);
		BehaviorMode_ = new ComplexObservableProperty<IAudioInput.Types.IBehaviorMode>("behavior_mode__5", LoroMap, new EntityFactory());
		Source_ = new UnionObservableProperty<IAudioInput.Types.ISource>("Source__union", LoroMap, new IAudioInput.Types.SourceFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, UserDescription_.WhenChangeHappens, BehaviorMode_.WhenChangeHappens, Source_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		UserDescription_.Dispose();
		BehaviorMode_.Dispose();
		Source_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		UserDescription_.OnDiff(path, diff);
		BehaviorMode_.OnDiff(path, diff);
		Source_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
