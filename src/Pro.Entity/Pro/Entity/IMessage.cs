using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IMessage : IEntity, IDisposable
{
	public class Types
	{
		public interface IToken : IEntity, IDisposable
		{
			public class Types
			{
				public interface ITokenTypeClock : IEntity, IDisposable
				{
				}

				internal sealed class TokenTypeClock : ITokenTypeClock, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

					public TokenTypeClock()
						: this(new LoroMap())
					{
					}

					public TokenTypeClock(LoroMap values)
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

				public interface ITokenTypeText : IEntity, IDisposable
				{
					IObservableProperty<string> Name { get; }
				}

				internal sealed class TokenTypeText : ITokenTypeText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private StringObservableProperty Name_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<string> Name => Name_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Name_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Name_.UpdateMapOnInternalMapUpdate(_map);
					}

					public TokenTypeText()
						: this(new LoroMap())
					{
					}

					public TokenTypeText(LoroMap values)
					{
						_map = values;
						Name_ = new StringObservableProperty("name__1", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Name_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Name_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Name_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ITokenTypeTimer : IEntity, IDisposable
				{
					IObservableProperty<string> Name { get; }

					IObservableProperty<Guid> TimerUuid { get; }
				}

				internal sealed class TokenTypeTimer : ITokenTypeTimer, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private StringObservableProperty Name_;

					private GuidObservableProperty TimerUuid_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<string> Name => Name_;

					public IObservableProperty<Guid> TimerUuid => TimerUuid_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Name_.UpdateMap(_map);
						TimerUuid_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Name_.UpdateMapOnInternalMapUpdate(_map);
						TimerUuid_.UpdateMapOnInternalMapUpdate(_map);
					}

					public TokenTypeTimer()
						: this(new LoroMap())
					{
					}

					public TokenTypeTimer(LoroMap values)
					{
						_map = values;
						Name_ = new StringObservableProperty("name__1", LoroMap);
						TimerUuid_ = new GuidObservableProperty("timer_uuid__2", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Name_.WhenChangeHappens.Merge(TimerUuid_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Name_.Dispose();
						TimerUuid_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Name_.OnDiff(path, diff);
						TimerUuid_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ITokenType : IEntity, IDisposable
				{
					public interface IText : ITokenType, IEntity, IDisposable, IObservableProperty<ITokenTypeText>
					{
					}

					public interface ITimer : ITokenType, IEntity, IDisposable, IObservableProperty<ITokenTypeTimer>
					{
					}

					public interface IClock : ITokenType, IEntity, IDisposable, IObservableProperty<ITokenTypeClock>
					{
					}

					internal class Text : IText, ITokenType, IEntity, IDisposable, IObservableProperty<ITokenTypeText>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITokenTypeText> _Text_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Text_.WhenChangeHappens;

						public IObservable<ITokenTypeText> WhenValueChanges => _Text_.WhenValueChanges;

						public ITokenTypeText Value => _Text_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Text_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Text_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "text__2".ToLoroValueLike());
							return loroMap;
						}

						public Text()
							: this(InitializeMap())
						{
						}

						public Text(LoroMap values)
						{
							_map = values;
							_Text_ = new ComplexObservableProperty<ITokenTypeText>("text__2", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Text_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Text_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Text_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITokenTypeText value)
						{
							_Text_.Set(value);
						}
					}

					internal class Timer : ITimer, ITokenType, IEntity, IDisposable, IObservableProperty<ITokenTypeTimer>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITokenTypeTimer> _Timer_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Timer_.WhenChangeHappens;

						public IObservable<ITokenTypeTimer> WhenValueChanges => _Timer_.WhenValueChanges;

						public ITokenTypeTimer Value => _Timer_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Timer_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Timer_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "timer__3".ToLoroValueLike());
							return loroMap;
						}

						public Timer()
							: this(InitializeMap())
						{
						}

						public Timer(LoroMap values)
						{
							_map = values;
							_Timer_ = new ComplexObservableProperty<ITokenTypeTimer>("timer__3", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Timer_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Timer_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Timer_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITokenTypeTimer value)
						{
							_Timer_.Set(value);
						}
					}

					internal class Clock : IClock, ITokenType, IEntity, IDisposable, IObservableProperty<ITokenTypeClock>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITokenTypeClock> _Clock_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Clock_.WhenChangeHappens;

						public IObservable<ITokenTypeClock> WhenValueChanges => _Clock_.WhenValueChanges;

						public ITokenTypeClock Value => _Clock_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Clock_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Clock_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "clock__4".ToLoroValueLike());
							return loroMap;
						}

						public Clock()
							: this(InitializeMap())
						{
						}

						public Clock(LoroMap values)
						{
							_map = values;
							_Clock_ = new ComplexObservableProperty<ITokenTypeClock>("clock__4", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Clock_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Clock_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Clock_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITokenTypeClock value)
						{
							_Clock_.Set(value);
						}
					}
				}

				internal class TokenTypeFactory : IUnionValueFactory<ITokenType>
				{
					public string SelectionKey => "__tag";

					public ITokenType? CreateInstance(LoroMap map)
					{
						return map.Get("__tag").ToStringValue() switch
						{
							"text__2" => new ITokenType.Text(map), 
							"timer__3" => new ITokenType.Timer(map), 
							"clock__4" => new ITokenType.Clock(map), 
							_ => null, 
						};
					}

					public ITokenType CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "text__2".ToLoroValueLike());
						return new ITokenType.Text(map);
					}
				}
			}

			IObservableProperty<Guid> Uuid { get; }

			IComplexObservableProperty<Types.ITokenType> TokenType { get; }
		}

		internal sealed class Token : IToken, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private UnionObservableProperty<IToken.Types.ITokenType> TokenType_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IComplexObservableProperty<IToken.Types.ITokenType> TokenType => TokenType_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				TokenType_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				TokenType_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Token()
				: this(new LoroMap())
			{
			}

			public Token(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				TokenType_ = new UnionObservableProperty<IToken.Types.ITokenType>("TokenType__union", LoroMap, new IToken.Types.TokenTypeFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Uuid_.WhenChangeHappens.Merge(TokenType_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				TokenType_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				TokenType_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ITokenValue : IEntity, IDisposable
		{
			public class Types
			{
				public interface ITokenValueClock : IEntity, IDisposable
				{
					IComplexObservableProperty<IClock.Types.IFormat> Format { get; }
				}

				internal sealed class TokenValueClock : ITokenValueClock, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private ComplexObservableProperty<IClock.Types.IFormat> Format_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IComplexObservableProperty<IClock.Types.IFormat> Format => Format_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Format_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Format_.UpdateMapOnInternalMapUpdate(_map);
					}

					public TokenValueClock()
						: this(new LoroMap())
					{
					}

					public TokenValueClock(LoroMap values)
					{
						_map = values;
						Format_ = new ComplexObservableProperty<IClock.Types.IFormat>("format__1", LoroMap, new EntityFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Format_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Format_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Format_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ITokenValueText : IEntity, IDisposable
				{
					IObservableProperty<string> Value { get; }
				}

				internal sealed class TokenValueText : ITokenValueText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private StringObservableProperty Value_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<string> Value => Value_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Value_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Value_.UpdateMapOnInternalMapUpdate(_map);
					}

					public TokenValueText()
						: this(new LoroMap())
					{
					}

					public TokenValueText(LoroMap values)
					{
						_map = values;
						Value_ = new StringObservableProperty("value__1", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Value_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Value_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Value_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ITokenValueTimer : IEntity, IDisposable
				{
					IComplexObservableProperty<ITimer.Types.IConfiguration> Configuration { get; }

					IComplexObservableProperty<ITimer.Types.IFormat> Format { get; }
				}

				internal sealed class TokenValueTimer : ITokenValueTimer, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private ComplexObservableProperty<ITimer.Types.IConfiguration> Configuration_;

					private ComplexObservableProperty<ITimer.Types.IFormat> Format_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IComplexObservableProperty<ITimer.Types.IConfiguration> Configuration => Configuration_;

					public IComplexObservableProperty<ITimer.Types.IFormat> Format => Format_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Configuration_.UpdateMap(_map);
						Format_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Configuration_.UpdateMapOnInternalMapUpdate(_map);
						Format_.UpdateMapOnInternalMapUpdate(_map);
					}

					public TokenValueTimer()
						: this(new LoroMap())
					{
					}

					public TokenValueTimer(LoroMap values)
					{
						_map = values;
						Configuration_ = new ComplexObservableProperty<ITimer.Types.IConfiguration>("configuration__1", LoroMap, new EntityFactory());
						Format_ = new ComplexObservableProperty<ITimer.Types.IFormat>("format__2", LoroMap, new EntityFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Configuration_.WhenChangeHappens.Merge(Format_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Configuration_.Dispose();
						Format_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Configuration_.OnDiff(path, diff);
						Format_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ITokenValueType : IEntity, IDisposable
				{
					public interface IText : ITokenValueType, IEntity, IDisposable, IObservableProperty<ITokenValueText>
					{
					}

					public interface ITimer : ITokenValueType, IEntity, IDisposable, IObservableProperty<ITokenValueTimer>
					{
					}

					public interface IClock : ITokenValueType, IEntity, IDisposable, IObservableProperty<ITokenValueClock>
					{
					}

					internal class Text : IText, ITokenValueType, IEntity, IDisposable, IObservableProperty<ITokenValueText>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITokenValueText> _Text_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Text_.WhenChangeHappens;

						public IObservable<ITokenValueText> WhenValueChanges => _Text_.WhenValueChanges;

						public ITokenValueText Value => _Text_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Text_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Text_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "text__2".ToLoroValueLike());
							return loroMap;
						}

						public Text()
							: this(InitializeMap())
						{
						}

						public Text(LoroMap values)
						{
							_map = values;
							_Text_ = new ComplexObservableProperty<ITokenValueText>("text__2", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Text_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Text_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Text_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITokenValueText value)
						{
							_Text_.Set(value);
						}
					}

					internal class Timer : ITimer, ITokenValueType, IEntity, IDisposable, IObservableProperty<ITokenValueTimer>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITokenValueTimer> _Timer_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Timer_.WhenChangeHappens;

						public IObservable<ITokenValueTimer> WhenValueChanges => _Timer_.WhenValueChanges;

						public ITokenValueTimer Value => _Timer_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Timer_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Timer_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "timer__3".ToLoroValueLike());
							return loroMap;
						}

						public Timer()
							: this(InitializeMap())
						{
						}

						public Timer(LoroMap values)
						{
							_map = values;
							_Timer_ = new ComplexObservableProperty<ITokenValueTimer>("timer__3", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Timer_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Timer_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Timer_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITokenValueTimer value)
						{
							_Timer_.Set(value);
						}
					}

					internal class Clock : IClock, ITokenValueType, IEntity, IDisposable, IObservableProperty<ITokenValueClock>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITokenValueClock> _Clock_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Clock_.WhenChangeHappens;

						public IObservable<ITokenValueClock> WhenValueChanges => _Clock_.WhenValueChanges;

						public ITokenValueClock Value => _Clock_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Clock_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Clock_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "clock__4".ToLoroValueLike());
							return loroMap;
						}

						public Clock()
							: this(InitializeMap())
						{
						}

						public Clock(LoroMap values)
						{
							_map = values;
							_Clock_ = new ComplexObservableProperty<ITokenValueClock>("clock__4", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Clock_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Clock_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Clock_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITokenValueClock value)
						{
							_Clock_.Set(value);
						}
					}
				}

				internal class TokenValueTypeFactory : IUnionValueFactory<ITokenValueType>
				{
					public string SelectionKey => "__tag";

					public ITokenValueType? CreateInstance(LoroMap map)
					{
						return map.Get("__tag").ToStringValue() switch
						{
							"text__2" => new ITokenValueType.Text(map), 
							"timer__3" => new ITokenValueType.Timer(map), 
							"clock__4" => new ITokenValueType.Clock(map), 
							_ => null, 
						};
					}

					public ITokenValueType CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "text__2".ToLoroValueLike());
						return new ITokenValueType.Text(map);
					}
				}
			}

			IObservableProperty<Guid> TokenId { get; }

			IObservableProperty<string> TokenName { get; }

			IComplexObservableProperty<Types.ITokenValueType> TokenValueType { get; }
		}

		internal sealed class TokenValue : ITokenValue, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty TokenId_;

			private StringObservableProperty TokenName_;

			private UnionObservableProperty<ITokenValue.Types.ITokenValueType> TokenValueType_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> TokenId => TokenId_;

			public IObservableProperty<string> TokenName => TokenName_;

			public IComplexObservableProperty<ITokenValue.Types.ITokenValueType> TokenValueType => TokenValueType_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				TokenId_.UpdateMap(_map);
				TokenName_.UpdateMap(_map);
				TokenValueType_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				TokenId_.UpdateMapOnInternalMapUpdate(_map);
				TokenName_.UpdateMapOnInternalMapUpdate(_map);
				TokenValueType_.UpdateMapOnInternalMapUpdate(_map);
			}

			public TokenValue()
				: this(new LoroMap())
			{
			}

			public TokenValue(LoroMap values)
			{
				_map = values;
				TokenId_ = new GuidObservableProperty("token_id__1", LoroMap);
				TokenName_ = new StringObservableProperty("token_name__5", LoroMap);
				TokenValueType_ = new UnionObservableProperty<ITokenValue.Types.ITokenValueType>("TokenValueType__union", LoroMap, new ITokenValue.Types.TokenValueTypeFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(TokenId_.WhenChangeHappens, TokenName_.WhenChangeHappens, TokenValueType_.WhenChangeHappens);
			}

			public void Dispose()
			{
				TokenId_.Dispose();
				TokenName_.Dispose();
				TokenValueType_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				TokenId_.OnDiff(path, diff);
				TokenName_.OnDiff(path, diff);
				TokenValueType_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public enum ClearType
		{
			Manual,
			AfterTime,
			AfterTimers
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string> Title { get; }

	IObservableProperty<double> TimeToRemove { get; }

	IObservableProperty<bool> VisibleOnNetwork { get; }

	IComplexObservableProperty<ITemplateIdentification?> Template { get; }

	IObservableProperty<Types.ClearType> ClearType { get; }

	IObservableProperty<string> MessageText { get; }

	IComplexCollection<Types.IToken> Tokens { get; }
}
