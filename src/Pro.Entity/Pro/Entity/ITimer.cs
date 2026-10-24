using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface ITimer : IEntity, IDisposable
{
	public class Types
	{
		public interface IConfiguration : IEntity, IDisposable
		{
			public class Types
			{
				public interface ITimerTypeCountdown : IEntity, IDisposable
				{
					IObservableProperty<double> Duration { get; }
				}

				internal sealed class TimerTypeCountdown : ITimerTypeCountdown, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private DoubleObservableProperty Duration_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<double> Duration => Duration_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Duration_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Duration_.UpdateMapOnInternalMapUpdate(_map);
					}

					public TimerTypeCountdown()
						: this(new LoroMap())
					{
					}

					public TimerTypeCountdown(LoroMap values)
					{
						_map = values;
						Duration_ = new DoubleObservableProperty("duration__1", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Duration_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Duration_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Duration_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ITimerTypeCountdownToTime : IEntity, IDisposable
				{
					public class Types
					{
						public enum TimePeriod
						{
							Am,
							Pm,
							_24
						}
					}

					IObservableProperty<double> TimeOfDay { get; }

					IObservableProperty<Types.TimePeriod> Period { get; }
				}

				internal sealed class TimerTypeCountdownToTime : ITimerTypeCountdownToTime, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private DoubleObservableProperty TimeOfDay_;

					private EnumObservableProperty<ITimerTypeCountdownToTime.Types.TimePeriod> Period_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<double> TimeOfDay => TimeOfDay_;

					public IObservableProperty<ITimerTypeCountdownToTime.Types.TimePeriod> Period => Period_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						TimeOfDay_.UpdateMap(_map);
						Period_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						TimeOfDay_.UpdateMapOnInternalMapUpdate(_map);
						Period_.UpdateMapOnInternalMapUpdate(_map);
					}

					public TimerTypeCountdownToTime()
						: this(new LoroMap())
					{
					}

					public TimerTypeCountdownToTime(LoroMap values)
					{
						_map = values;
						TimeOfDay_ = new DoubleObservableProperty("time_of_day__1", LoroMap);
						Period_ = new EnumObservableProperty<ITimerTypeCountdownToTime.Types.TimePeriod>("period__2", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = TimeOfDay_.WhenChangeHappens.Merge(Period_.WhenChangeHappens);
					}

					public void Dispose()
					{
						TimeOfDay_.Dispose();
						Period_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						TimeOfDay_.OnDiff(path, diff);
						Period_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ITimerTypeElapsedTime : IEntity, IDisposable
				{
					IObservableProperty<double> StartTime { get; }

					IObservableProperty<double> EndTime { get; }

					IObservableProperty<bool> HasEndTime { get; }
				}

				internal sealed class TimerTypeElapsedTime : ITimerTypeElapsedTime, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private DoubleObservableProperty StartTime_;

					private DoubleObservableProperty EndTime_;

					private BoolObservableProperty HasEndTime_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<double> StartTime => StartTime_;

					public IObservableProperty<double> EndTime => EndTime_;

					public IObservableProperty<bool> HasEndTime => HasEndTime_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						StartTime_.UpdateMap(_map);
						EndTime_.UpdateMap(_map);
						HasEndTime_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						StartTime_.UpdateMapOnInternalMapUpdate(_map);
						EndTime_.UpdateMapOnInternalMapUpdate(_map);
						HasEndTime_.UpdateMapOnInternalMapUpdate(_map);
					}

					public TimerTypeElapsedTime()
						: this(new LoroMap())
					{
					}

					public TimerTypeElapsedTime(LoroMap values)
					{
						_map = values;
						StartTime_ = new DoubleObservableProperty("start_time__1", LoroMap);
						EndTime_ = new DoubleObservableProperty("end_time__2", LoroMap);
						HasEndTime_ = new BoolObservableProperty("has_end_time__3", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(StartTime_.WhenChangeHappens, EndTime_.WhenChangeHappens, HasEndTime_.WhenChangeHappens);
					}

					public void Dispose()
					{
						StartTime_.Dispose();
						EndTime_.Dispose();
						HasEndTime_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						StartTime_.OnDiff(path, diff);
						EndTime_.OnDiff(path, diff);
						HasEndTime_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ITimerType : IEntity, IDisposable
				{
					public interface ICountdown : ITimerType, IEntity, IDisposable, IObservableProperty<ITimerTypeCountdown>
					{
					}

					public interface ICountdownToTime : ITimerType, IEntity, IDisposable, IObservableProperty<ITimerTypeCountdownToTime>
					{
					}

					public interface IElapsedTime : ITimerType, IEntity, IDisposable, IObservableProperty<ITimerTypeElapsedTime>
					{
					}

					internal class Countdown : ICountdown, ITimerType, IEntity, IDisposable, IObservableProperty<ITimerTypeCountdown>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITimerTypeCountdown> _Countdown_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Countdown_.WhenChangeHappens;

						public IObservable<ITimerTypeCountdown> WhenValueChanges => _Countdown_.WhenValueChanges;

						public ITimerTypeCountdown Value => _Countdown_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Countdown_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Countdown_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "countdown__1".ToLoroValueLike());
							return loroMap;
						}

						public Countdown()
							: this(InitializeMap())
						{
						}

						public Countdown(LoroMap values)
						{
							_map = values;
							_Countdown_ = new ComplexObservableProperty<ITimerTypeCountdown>("countdown__1", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Countdown_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Countdown_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Countdown_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITimerTypeCountdown value)
						{
							_Countdown_.Set(value);
						}
					}

					internal class CountdownToTime : ICountdownToTime, ITimerType, IEntity, IDisposable, IObservableProperty<ITimerTypeCountdownToTime>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITimerTypeCountdownToTime> _CountdownToTime_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _CountdownToTime_.WhenChangeHappens;

						public IObservable<ITimerTypeCountdownToTime> WhenValueChanges => _CountdownToTime_.WhenValueChanges;

						public ITimerTypeCountdownToTime Value => _CountdownToTime_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_CountdownToTime_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_CountdownToTime_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "countdown_to_time__2".ToLoroValueLike());
							return loroMap;
						}

						public CountdownToTime()
							: this(InitializeMap())
						{
						}

						public CountdownToTime(LoroMap values)
						{
							_map = values;
							_CountdownToTime_ = new ComplexObservableProperty<ITimerTypeCountdownToTime>("countdown_to_time__2", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_CountdownToTime_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_CountdownToTime_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_CountdownToTime_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITimerTypeCountdownToTime value)
						{
							_CountdownToTime_.Set(value);
						}
					}

					internal class ElapsedTime : IElapsedTime, ITimerType, IEntity, IDisposable, IObservableProperty<ITimerTypeElapsedTime>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITimerTypeElapsedTime> _ElapsedTime_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _ElapsedTime_.WhenChangeHappens;

						public IObservable<ITimerTypeElapsedTime> WhenValueChanges => _ElapsedTime_.WhenValueChanges;

						public ITimerTypeElapsedTime Value => _ElapsedTime_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_ElapsedTime_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_ElapsedTime_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "elapsed_time__3".ToLoroValueLike());
							return loroMap;
						}

						public ElapsedTime()
							: this(InitializeMap())
						{
						}

						public ElapsedTime(LoroMap values)
						{
							_map = values;
							_ElapsedTime_ = new ComplexObservableProperty<ITimerTypeElapsedTime>("elapsed_time__3", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_ElapsedTime_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_ElapsedTime_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_ElapsedTime_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITimerTypeElapsedTime value)
						{
							_ElapsedTime_.Set(value);
						}
					}
				}

				internal class TimerTypeFactory : IUnionValueFactory<ITimerType>
				{
					public string SelectionKey => "__tag";

					public ITimerType? CreateInstance(LoroMap map)
					{
						return map.Get("__tag").ToStringValue() switch
						{
							"countdown__1" => new ITimerType.Countdown(map), 
							"countdown_to_time__2" => new ITimerType.CountdownToTime(map), 
							"elapsed_time__3" => new ITimerType.ElapsedTime(map), 
							_ => null, 
						};
					}

					public ITimerType CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "countdown__1".ToLoroValueLike());
						return new ITimerType.Countdown(map);
					}
				}
			}

			IObservableProperty<bool> AllowsOverrun { get; }

			IComplexObservableProperty<Types.ITimerType> TimerType { get; }
		}

		internal sealed class Configuration : IConfiguration, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private BoolObservableProperty AllowsOverrun_;

			private UnionObservableProperty<IConfiguration.Types.ITimerType> TimerType_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<bool> AllowsOverrun => AllowsOverrun_;

			public IComplexObservableProperty<IConfiguration.Types.ITimerType> TimerType => TimerType_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				AllowsOverrun_.UpdateMap(_map);
				TimerType_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				AllowsOverrun_.UpdateMapOnInternalMapUpdate(_map);
				TimerType_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Configuration()
				: this(new LoroMap())
			{
			}

			public Configuration(LoroMap values)
			{
				_map = values;
				AllowsOverrun_ = new BoolObservableProperty("allows_overrun__4", LoroMap);
				TimerType_ = new UnionObservableProperty<IConfiguration.Types.ITimerType>("TimerType__union", LoroMap, new IConfiguration.Types.TimerTypeFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = AllowsOverrun_.WhenChangeHappens.Merge(TimerType_.WhenChangeHappens);
			}

			public void Dispose()
			{
				AllowsOverrun_.Dispose();
				TimerType_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				AllowsOverrun_.OnDiff(path, diff);
				TimerType_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IFormat : IEntity, IDisposable
		{
			public class Types
			{
				public enum Style
				{
					None,
					Short,
					Long,
					RemoveShort,
					RemoveLong
				}
			}

			IObservableProperty<Types.Style> Hour { get; }

			IObservableProperty<Types.Style> Minute { get; }

			IObservableProperty<Types.Style> Second { get; }

			IObservableProperty<Types.Style> Millisecond { get; }

			IObservableProperty<bool> IsWallClockTime { get; }

			IObservableProperty<bool> Is24HourTime { get; }

			IObservableProperty<bool> ShowMillisecondsUnderMinuteOnly { get; }
		}

		internal sealed class Format : IFormat, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private EnumObservableProperty<IFormat.Types.Style> Hour_;

			private EnumObservableProperty<IFormat.Types.Style> Minute_;

			private EnumObservableProperty<IFormat.Types.Style> Second_;

			private EnumObservableProperty<IFormat.Types.Style> Millisecond_;

			private BoolObservableProperty IsWallClockTime_;

			private BoolObservableProperty Is24HourTime_;

			private BoolObservableProperty ShowMillisecondsUnderMinuteOnly_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<IFormat.Types.Style> Hour => Hour_;

			public IObservableProperty<IFormat.Types.Style> Minute => Minute_;

			public IObservableProperty<IFormat.Types.Style> Second => Second_;

			public IObservableProperty<IFormat.Types.Style> Millisecond => Millisecond_;

			public IObservableProperty<bool> IsWallClockTime => IsWallClockTime_;

			public IObservableProperty<bool> Is24HourTime => Is24HourTime_;

			public IObservableProperty<bool> ShowMillisecondsUnderMinuteOnly => ShowMillisecondsUnderMinuteOnly_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Hour_.UpdateMap(_map);
				Minute_.UpdateMap(_map);
				Second_.UpdateMap(_map);
				Millisecond_.UpdateMap(_map);
				IsWallClockTime_.UpdateMap(_map);
				Is24HourTime_.UpdateMap(_map);
				ShowMillisecondsUnderMinuteOnly_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Hour_.UpdateMapOnInternalMapUpdate(_map);
				Minute_.UpdateMapOnInternalMapUpdate(_map);
				Second_.UpdateMapOnInternalMapUpdate(_map);
				Millisecond_.UpdateMapOnInternalMapUpdate(_map);
				IsWallClockTime_.UpdateMapOnInternalMapUpdate(_map);
				Is24HourTime_.UpdateMapOnInternalMapUpdate(_map);
				ShowMillisecondsUnderMinuteOnly_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Format()
				: this(new LoroMap())
			{
			}

			public Format(LoroMap values)
			{
				_map = values;
				Hour_ = new EnumObservableProperty<IFormat.Types.Style>("hour__1", LoroMap);
				Minute_ = new EnumObservableProperty<IFormat.Types.Style>("minute__2", LoroMap);
				Second_ = new EnumObservableProperty<IFormat.Types.Style>("second__3", LoroMap);
				Millisecond_ = new EnumObservableProperty<IFormat.Types.Style>("millisecond__4", LoroMap);
				IsWallClockTime_ = new BoolObservableProperty("is_wall_clock_time__5", LoroMap);
				Is24HourTime_ = new BoolObservableProperty("is_24_hour_time__6", LoroMap);
				ShowMillisecondsUnderMinuteOnly_ = new BoolObservableProperty("show_milliseconds_under_minute_only__7", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Hour_.WhenChangeHappens, Minute_.WhenChangeHappens, Second_.WhenChangeHappens, Millisecond_.WhenChangeHappens, IsWallClockTime_.WhenChangeHappens, Is24HourTime_.WhenChangeHappens, ShowMillisecondsUnderMinuteOnly_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Hour_.Dispose();
				Minute_.Dispose();
				Second_.Dispose();
				Millisecond_.Dispose();
				IsWallClockTime_.Dispose();
				Is24HourTime_.Dispose();
				ShowMillisecondsUnderMinuteOnly_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Hour_.OnDiff(path, diff);
				Minute_.OnDiff(path, diff);
				Second_.OnDiff(path, diff);
				Millisecond_.OnDiff(path, diff);
				IsWallClockTime_.OnDiff(path, diff);
				Is24HourTime_.OnDiff(path, diff);
				ShowMillisecondsUnderMinuteOnly_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string> Name { get; }
}
