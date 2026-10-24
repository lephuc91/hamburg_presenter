using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IPropDocument : IEntity, IDisposable
{
	public class Types
	{
		public interface IPropCollection : IEntity, IDisposable
		{
			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<string> Name { get; }

			IObservableProperty<bool> SinglePropEnabled { get; }

			IComplexCollection<ICue> Cues { get; }
		}

		internal sealed class PropCollection : IPropCollection, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private StringObservableProperty Name_;

			private BoolObservableProperty SinglePropEnabled_;

			private MapCollection<ICue> Cues_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<bool> SinglePropEnabled => SinglePropEnabled_;

			public IComplexCollection<ICue> Cues => Cues_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				SinglePropEnabled_.UpdateMap(_map);
				Cues_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				SinglePropEnabled_.UpdateMapOnInternalMapUpdate(_map);
				Cues_.UpdateMapOnInternalMapUpdate(_map);
			}

			public PropCollection()
				: this(new LoroMap())
			{
			}

			public PropCollection(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				SinglePropEnabled_ = new BoolObservableProperty("single_prop_enabled__4", LoroMap);
				Cues_ = new MapCollection<ICue>(LoroMap, "cues__5", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, SinglePropEnabled_.WhenChangeHappens, Cues_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				Name_.Dispose();
				SinglePropEnabled_.Dispose();
				Cues_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				SinglePropEnabled_.OnDiff(path, diff);
				Cues_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IComplexObservableProperty<ITransition?> Transition { get; }

	IComplexCollection<Types.IPropCollection> PropCollections { get; }
}
