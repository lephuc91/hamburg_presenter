using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface ICommunicationCommand : IEntity, IDisposable
{
	public class Types
	{
		public interface IParameters : IEntity, IDisposable
		{
			IObservableProperty<string> Name { get; }

			IObservableProperty<IntRange> ReplacementRange { get; }

			ICollection<string> PossibleValues { get; }

			IObservableProperty<string> Value { get; }
		}

		internal sealed class Parameters : IParameters, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty Name_;

			private AtomicObservableProperty<IntRange> ReplacementRange_;

			private StringCollection PossibleValues_;

			private StringObservableProperty Value_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<IntRange> ReplacementRange => ReplacementRange_;

			public ICollection<string> PossibleValues => PossibleValues_;

			public IObservableProperty<string> Value => Value_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Name_.UpdateMap(_map);
				ReplacementRange_.UpdateMap(_map);
				PossibleValues_.UpdateMap(_map);
				Value_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Name_.UpdateMapOnInternalMapUpdate(_map);
				ReplacementRange_.UpdateMapOnInternalMapUpdate(_map);
				PossibleValues_.UpdateMapOnInternalMapUpdate(_map);
				Value_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Parameters()
				: this(new LoroMap())
			{
			}

			public Parameters(LoroMap values)
			{
				_map = values;
				Name_ = new StringObservableProperty("name__1", LoroMap);
				ReplacementRange_ = new AtomicObservableProperty<IntRange>("replacement_range__2", LoroMap, IntRangeExtension.Deserialize, IntRangeExtension.Serialize);
				PossibleValues_ = new StringCollection(LoroMap, "possible_values__3");
				Value_ = new StringObservableProperty("value__4", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Name_.WhenChangeHappens, ReplacementRange_.WhenChangeHappens, PossibleValues_.WhenChangeHappens, Value_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Name_.Dispose();
				ReplacementRange_.Dispose();
				PossibleValues_.Dispose();
				Value_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Name_.OnDiff(path, diff);
				ReplacementRange_.OnDiff(path, diff);
				PossibleValues_.OnDiff(path, diff);
				Value_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}
}
