using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface ICalendar : IEntity, IDisposable
{
	public class Types
	{
		public interface IEvent : IEntity, IDisposable
		{
			public class Types
			{
				public interface IAction : IEntity, IDisposable
				{
					public class Types
					{
						public interface IMacro : IEntity, IDisposable
						{
							IComplexObservableProperty<ICollectionElementType> Identification { get; }
						}

						internal sealed class Macro : IMacro, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private ComplexObservableProperty<ICollectionElementType> Identification_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IComplexObservableProperty<ICollectionElementType> Identification => Identification_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								Identification_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								Identification_.UpdateMapOnInternalMapUpdate(_map);
							}

							public Macro()
								: this(new LoroMap())
							{
							}

							public Macro(LoroMap values)
							{
								_map = values;
								Identification_ = new ComplexObservableProperty<ICollectionElementType>("identification__1", LoroMap, new EntityFactory());
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(Identification_.WhenChangeHappens);
							}

							public void Dispose()
							{
								Identification_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								Identification_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IPlaylist : IEntity, IDisposable
						{
							IObservableProperty<Guid?> PlaylistUuid { get; }

							IObservableProperty<Guid?> PlaylistItemUuid { get; }
						}

						internal sealed class Playlist : IPlaylist, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private OptionalGuidObservableProperty PlaylistUuid_;

							private OptionalGuidObservableProperty PlaylistItemUuid_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<Guid?> PlaylistUuid => PlaylistUuid_;

							public IObservableProperty<Guid?> PlaylistItemUuid => PlaylistItemUuid_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								PlaylistUuid_.UpdateMap(_map);
								PlaylistItemUuid_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								PlaylistUuid_.UpdateMapOnInternalMapUpdate(_map);
								PlaylistItemUuid_.UpdateMapOnInternalMapUpdate(_map);
							}

							public Playlist()
								: this(new LoroMap())
							{
							}

							public Playlist(LoroMap values)
							{
								_map = values;
								PlaylistUuid_ = new OptionalGuidObservableProperty("playlist_uuid__1", LoroMap);
								PlaylistItemUuid_ = new OptionalGuidObservableProperty("playlist_item_uuid__2", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = PlaylistUuid_.WhenChangeHappens.Merge(PlaylistItemUuid_.WhenChangeHappens);
							}

							public void Dispose()
							{
								PlaylistUuid_.Dispose();
								PlaylistItemUuid_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								PlaylistUuid_.OnDiff(path, diff);
								PlaylistItemUuid_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}
					}
				}

				internal sealed class Action : IAction, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public void UpdateMap(LoroMap value)
					{
						_map = value;
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
					}

					public Action()
						: this(new LoroMap())
					{
					}

					public Action(LoroMap values)
					{
						_map = values;
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge(Array.Empty<IObservable<Unit>>());
					}

					public void Dispose()
					{
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public enum DayOfWeek
				{
					Unknown,
					Sunday,
					Monday,
					Tuesday,
					Wednesday,
					Thursday,
					Friday,
					Saturday
				}
			}

			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<string> Name { get; }

			IObservableProperty<string?> Description { get; }

			IObservableProperty<Timestamp> Date { get; }

			ICollection<Types.DayOfWeek> RecurrenceDays { get; }

			IObservableProperty<Timestamp?> RecurrenceLimitDate { get; }

			ICollection<Timestamp> RecurrenceExcludedDates { get; }

			IComplexCollection<IAction> Actions { get; }
		}

		internal sealed class Event : IEvent, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private StringObservableProperty Name_;

			private OptionalStringObservableProperty Description_;

			private AtomicObservableProperty<Timestamp> Date_;

			private EnumCollection<IEvent.Types.DayOfWeek> RecurrenceDays_;

			private OptionalAtomicObservableProperty<Timestamp> RecurrenceLimitDate_;

			private AtomicMapCollection<Timestamp> RecurrenceExcludedDates_;

			private MapCollection<IAction> Actions_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<string?> Description => Description_;

			public IObservableProperty<Timestamp> Date => Date_;

			public ICollection<IEvent.Types.DayOfWeek> RecurrenceDays => RecurrenceDays_;

			public IObservableProperty<Timestamp?> RecurrenceLimitDate => RecurrenceLimitDate_;

			public ICollection<Timestamp> RecurrenceExcludedDates => RecurrenceExcludedDates_;

			public IComplexCollection<IAction> Actions => Actions_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Description_.UpdateMap(_map);
				Date_.UpdateMap(_map);
				RecurrenceDays_.UpdateMap(_map);
				RecurrenceLimitDate_.UpdateMap(_map);
				RecurrenceExcludedDates_.UpdateMap(_map);
				Actions_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Description_.UpdateMapOnInternalMapUpdate(_map);
				Date_.UpdateMapOnInternalMapUpdate(_map);
				RecurrenceDays_.UpdateMapOnInternalMapUpdate(_map);
				RecurrenceLimitDate_.UpdateMapOnInternalMapUpdate(_map);
				RecurrenceExcludedDates_.UpdateMapOnInternalMapUpdate(_map);
				Actions_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Event()
				: this(new LoroMap())
			{
			}

			public Event(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Description_ = new OptionalStringObservableProperty("description__3", LoroMap);
				Date_ = new AtomicObservableProperty<Timestamp>("date__4", LoroMap, TimestampExtension.Deserialize, TimestampExtension.Serialize);
				RecurrenceDays_ = new EnumCollection<IEvent.Types.DayOfWeek>(LoroMap, "recurrence_days__5");
				RecurrenceLimitDate_ = new OptionalAtomicObservableProperty<Timestamp>("recurrence_limit_date__6", LoroMap, TimestampExtension.Deserialize, TimestampExtension.Serialize);
				RecurrenceExcludedDates_ = new AtomicMapCollection<Timestamp>(LoroMap, "recurrence_excluded_dates__7", new EntityFactory(), TimestampExtension.Serialize);
				Actions_ = new MapCollection<IAction>(LoroMap, "actions__9", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Description_.WhenChangeHappens, Date_.WhenChangeHappens, RecurrenceDays_.WhenChangeHappens, RecurrenceLimitDate_.WhenChangeHappens, RecurrenceExcludedDates_.WhenChangeHappens, Actions_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				Name_.Dispose();
				Description_.Dispose();
				Date_.Dispose();
				RecurrenceDays_.Dispose();
				RecurrenceLimitDate_.Dispose();
				RecurrenceExcludedDates_.Dispose();
				Actions_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Description_.OnDiff(path, diff);
				Date_.OnDiff(path, diff);
				RecurrenceDays_.OnDiff(path, diff);
				RecurrenceLimitDate_.OnDiff(path, diff);
				RecurrenceExcludedDates_.OnDiff(path, diff);
				Actions_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IComplexCollection<Types.IEvent> Events { get; }

	IObservableProperty<bool> Active { get; }
}
