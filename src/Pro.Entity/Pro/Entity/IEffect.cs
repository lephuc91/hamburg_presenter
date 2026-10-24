using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IEffect : IEntity, IDisposable
{
	public class Types
	{
		public interface IEffectVariable : IEntity, IDisposable
		{
			public class Types
			{
				public interface IEffectColor : IEntity, IDisposable
				{
					IObservableProperty<Color> Color { get; }

					IObservableProperty<Color> DefaultColor { get; }
				}

				internal sealed class EffectColor : IEffectColor, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private AtomicObservableProperty<Color> Color_;

					private AtomicObservableProperty<Color> DefaultColor_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<Color> Color => Color_;

					public IObservableProperty<Color> DefaultColor => DefaultColor_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Color_.UpdateMap(_map);
						DefaultColor_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Color_.UpdateMapOnInternalMapUpdate(_map);
						DefaultColor_.UpdateMapOnInternalMapUpdate(_map);
					}

					public EffectColor()
						: this(new LoroMap())
					{
					}

					public EffectColor(LoroMap values)
					{
						_map = values;
						Color_ = new AtomicObservableProperty<Color>("color__1", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
						DefaultColor_ = new AtomicObservableProperty<Color>("default_color__2", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Color_.WhenChangeHappens.Merge(DefaultColor_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Color_.Dispose();
						DefaultColor_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Color_.OnDiff(path, diff);
						DefaultColor_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IEffectDirection : IEntity, IDisposable
				{
					public class Types
					{
						public enum EffectDirection
						{
							None = 0,
							TopLeft = 1,
							Top = 2,
							TopRight = 4,
							Left = 8,
							Center = 0x10,
							Right = 0x20,
							BottomLeft = 0x40,
							Bottom = 0x80,
							BottomRight = 0x100
						}
					}

					IObservableProperty<Types.EffectDirection> Direction { get; }

					IObservableProperty<Types.EffectDirection> DefaultDirection { get; }

					IObservableProperty<uint> AvailableDirections { get; }
				}

				internal sealed class EffectDirection : IEffectDirection, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private EnumObservableProperty<IEffectDirection.Types.EffectDirection> Direction_;

					private EnumObservableProperty<IEffectDirection.Types.EffectDirection> DefaultDirection_;

					private UintObservableProperty AvailableDirections_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<IEffectDirection.Types.EffectDirection> Direction => Direction_;

					public IObservableProperty<IEffectDirection.Types.EffectDirection> DefaultDirection => DefaultDirection_;

					public IObservableProperty<uint> AvailableDirections => AvailableDirections_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Direction_.UpdateMap(_map);
						DefaultDirection_.UpdateMap(_map);
						AvailableDirections_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Direction_.UpdateMapOnInternalMapUpdate(_map);
						DefaultDirection_.UpdateMapOnInternalMapUpdate(_map);
						AvailableDirections_.UpdateMapOnInternalMapUpdate(_map);
					}

					public EffectDirection()
						: this(new LoroMap())
					{
					}

					public EffectDirection(LoroMap values)
					{
						_map = values;
						Direction_ = new EnumObservableProperty<IEffectDirection.Types.EffectDirection>("direction__1", LoroMap);
						DefaultDirection_ = new EnumObservableProperty<IEffectDirection.Types.EffectDirection>("default_direction__2", LoroMap);
						AvailableDirections_ = new UintObservableProperty("available_directions__3", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Direction_.WhenChangeHappens, DefaultDirection_.WhenChangeHappens, AvailableDirections_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Direction_.Dispose();
						DefaultDirection_.Dispose();
						AvailableDirections_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Direction_.OnDiff(path, diff);
						DefaultDirection_.OnDiff(path, diff);
						AvailableDirections_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IEffectDouble : IEntity, IDisposable
				{
					IObservableProperty<double> Value { get; }

					IObservableProperty<double> DefaultValue { get; }

					IObservableProperty<double> Min { get; }

					IObservableProperty<double> Max { get; }
				}

				internal sealed class EffectDouble : IEffectDouble, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private DoubleObservableProperty Value_;

					private DoubleObservableProperty DefaultValue_;

					private DoubleObservableProperty Min_;

					private DoubleObservableProperty Max_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<double> Value => Value_;

					public IObservableProperty<double> DefaultValue => DefaultValue_;

					public IObservableProperty<double> Min => Min_;

					public IObservableProperty<double> Max => Max_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Value_.UpdateMap(_map);
						DefaultValue_.UpdateMap(_map);
						Min_.UpdateMap(_map);
						Max_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Value_.UpdateMapOnInternalMapUpdate(_map);
						DefaultValue_.UpdateMapOnInternalMapUpdate(_map);
						Min_.UpdateMapOnInternalMapUpdate(_map);
						Max_.UpdateMapOnInternalMapUpdate(_map);
					}

					public EffectDouble()
						: this(new LoroMap())
					{
					}

					public EffectDouble(LoroMap values)
					{
						_map = values;
						Value_ = new DoubleObservableProperty("value__1", LoroMap);
						DefaultValue_ = new DoubleObservableProperty("default_value__2", LoroMap);
						Min_ = new DoubleObservableProperty("min__3", LoroMap);
						Max_ = new DoubleObservableProperty("max__4", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Value_.WhenChangeHappens, DefaultValue_.WhenChangeHappens, Min_.WhenChangeHappens, Max_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Value_.Dispose();
						DefaultValue_.Dispose();
						Min_.Dispose();
						Max_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Value_.OnDiff(path, diff);
						DefaultValue_.OnDiff(path, diff);
						Min_.OnDiff(path, diff);
						Max_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IEffectFloat : IEntity, IDisposable
				{
					IObservableProperty<float> Value { get; }

					IObservableProperty<float> DefaultValue { get; }

					IObservableProperty<float> Min { get; }

					IObservableProperty<float> Max { get; }
				}

				internal sealed class EffectFloat : IEffectFloat, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private FloatObservableProperty Value_;

					private FloatObservableProperty DefaultValue_;

					private FloatObservableProperty Min_;

					private FloatObservableProperty Max_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<float> Value => Value_;

					public IObservableProperty<float> DefaultValue => DefaultValue_;

					public IObservableProperty<float> Min => Min_;

					public IObservableProperty<float> Max => Max_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Value_.UpdateMap(_map);
						DefaultValue_.UpdateMap(_map);
						Min_.UpdateMap(_map);
						Max_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Value_.UpdateMapOnInternalMapUpdate(_map);
						DefaultValue_.UpdateMapOnInternalMapUpdate(_map);
						Min_.UpdateMapOnInternalMapUpdate(_map);
						Max_.UpdateMapOnInternalMapUpdate(_map);
					}

					public EffectFloat()
						: this(new LoroMap())
					{
					}

					public EffectFloat(LoroMap values)
					{
						_map = values;
						Value_ = new FloatObservableProperty("value__1", LoroMap);
						DefaultValue_ = new FloatObservableProperty("default_value__2", LoroMap);
						Min_ = new FloatObservableProperty("min__3", LoroMap);
						Max_ = new FloatObservableProperty("max__4", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Value_.WhenChangeHappens, DefaultValue_.WhenChangeHappens, Min_.WhenChangeHappens, Max_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Value_.Dispose();
						DefaultValue_.Dispose();
						Min_.Dispose();
						Max_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Value_.OnDiff(path, diff);
						DefaultValue_.OnDiff(path, diff);
						Min_.OnDiff(path, diff);
						Max_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IEffectInt : IEntity, IDisposable
				{
					IObservableProperty<int> Value { get; }

					IObservableProperty<int> DefaultValue { get; }

					IObservableProperty<int> Min { get; }

					IObservableProperty<int> Max { get; }
				}

				internal sealed class EffectInt : IEffectInt, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private IntObservableProperty Value_;

					private IntObservableProperty DefaultValue_;

					private IntObservableProperty Min_;

					private IntObservableProperty Max_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<int> Value => Value_;

					public IObservableProperty<int> DefaultValue => DefaultValue_;

					public IObservableProperty<int> Min => Min_;

					public IObservableProperty<int> Max => Max_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Value_.UpdateMap(_map);
						DefaultValue_.UpdateMap(_map);
						Min_.UpdateMap(_map);
						Max_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Value_.UpdateMapOnInternalMapUpdate(_map);
						DefaultValue_.UpdateMapOnInternalMapUpdate(_map);
						Min_.UpdateMapOnInternalMapUpdate(_map);
						Max_.UpdateMapOnInternalMapUpdate(_map);
					}

					public EffectInt()
						: this(new LoroMap())
					{
					}

					public EffectInt(LoroMap values)
					{
						_map = values;
						Value_ = new IntObservableProperty("value__1", LoroMap);
						DefaultValue_ = new IntObservableProperty("default_value__2", LoroMap);
						Min_ = new IntObservableProperty("min__3", LoroMap);
						Max_ = new IntObservableProperty("max__4", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Value_.WhenChangeHappens, DefaultValue_.WhenChangeHappens, Min_.WhenChangeHappens, Max_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Value_.Dispose();
						DefaultValue_.Dispose();
						Min_.Dispose();
						Max_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Value_.OnDiff(path, diff);
						DefaultValue_.OnDiff(path, diff);
						Min_.OnDiff(path, diff);
						Max_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IType : IEntity, IDisposable
				{
					public interface IInt : IType, IEntity, IDisposable, IObservableProperty<IEffectInt>
					{
					}

					public interface IFloat : IType, IEntity, IDisposable, IObservableProperty<IEffectFloat>
					{
					}

					public interface IColor : IType, IEntity, IDisposable, IObservableProperty<IEffectColor>
					{
					}

					public interface IDirection : IType, IEntity, IDisposable, IObservableProperty<IEffectDirection>
					{
					}

					public interface IDouble : IType, IEntity, IDisposable, IObservableProperty<IEffectDouble>
					{
					}

					internal class Int : IInt, IType, IEntity, IDisposable, IObservableProperty<IEffectInt>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IEffectInt> _Int_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Int_.WhenChangeHappens;

						public IObservable<IEffectInt> WhenValueChanges => _Int_.WhenValueChanges;

						public IEffectInt Value => _Int_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Int_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Int_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "int__3".ToLoroValueLike());
							return loroMap;
						}

						public Int()
							: this(InitializeMap())
						{
						}

						public Int(LoroMap values)
						{
							_map = values;
							_Int_ = new ComplexObservableProperty<IEffectInt>("int__3", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Int_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Int_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Int_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IEffectInt value)
						{
							_Int_.Set(value);
						}
					}

					internal class Float : IFloat, IType, IEntity, IDisposable, IObservableProperty<IEffectFloat>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IEffectFloat> _Float_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Float_.WhenChangeHappens;

						public IObservable<IEffectFloat> WhenValueChanges => _Float_.WhenValueChanges;

						public IEffectFloat Value => _Float_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Float_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Float_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "float__4".ToLoroValueLike());
							return loroMap;
						}

						public Float()
							: this(InitializeMap())
						{
						}

						public Float(LoroMap values)
						{
							_map = values;
							_Float_ = new ComplexObservableProperty<IEffectFloat>("float__4", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Float_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Float_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Float_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IEffectFloat value)
						{
							_Float_.Set(value);
						}
					}

					internal class Color : IColor, IType, IEntity, IDisposable, IObservableProperty<IEffectColor>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IEffectColor> _Color_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Color_.WhenChangeHappens;

						public IObservable<IEffectColor> WhenValueChanges => _Color_.WhenValueChanges;

						public IEffectColor Value => _Color_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Color_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Color_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "color__5".ToLoroValueLike());
							return loroMap;
						}

						public Color()
							: this(InitializeMap())
						{
						}

						public Color(LoroMap values)
						{
							_map = values;
							_Color_ = new ComplexObservableProperty<IEffectColor>("color__5", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Color_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Color_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Color_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IEffectColor value)
						{
							_Color_.Set(value);
						}
					}

					internal class Direction : IDirection, IType, IEntity, IDisposable, IObservableProperty<IEffectDirection>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IEffectDirection> _Direction_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Direction_.WhenChangeHappens;

						public IObservable<IEffectDirection> WhenValueChanges => _Direction_.WhenValueChanges;

						public IEffectDirection Value => _Direction_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Direction_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Direction_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "direction__6".ToLoroValueLike());
							return loroMap;
						}

						public Direction()
							: this(InitializeMap())
						{
						}

						public Direction(LoroMap values)
						{
							_map = values;
							_Direction_ = new ComplexObservableProperty<IEffectDirection>("direction__6", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Direction_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Direction_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Direction_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IEffectDirection value)
						{
							_Direction_.Set(value);
						}
					}

					internal class Double : IDouble, IType, IEntity, IDisposable, IObservableProperty<IEffectDouble>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IEffectDouble> _Double_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Double_.WhenChangeHappens;

						public IObservable<IEffectDouble> WhenValueChanges => _Double_.WhenValueChanges;

						public IEffectDouble Value => _Double_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Double_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Double_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "double__7".ToLoroValueLike());
							return loroMap;
						}

						public Double()
							: this(InitializeMap())
						{
						}

						public Double(LoroMap values)
						{
							_map = values;
							_Double_ = new ComplexObservableProperty<IEffectDouble>("double__7", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Double_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Double_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Double_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IEffectDouble value)
						{
							_Double_.Set(value);
						}
					}
				}

				internal class TypeFactory : IUnionValueFactory<IType>
				{
					public string SelectionKey => "__tag";

					public IType? CreateInstance(LoroMap map)
					{
						return map.Get("__tag").ToStringValue() switch
						{
							"int__3" => new IType.Int(map), 
							"float__4" => new IType.Float(map), 
							"color__5" => new IType.Color(map), 
							"direction__6" => new IType.Direction(map), 
							"double__7" => new IType.Double(map), 
							_ => null, 
						};
					}

					public IType CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "int__3".ToLoroValueLike());
						return new IType.Int(map);
					}
				}
			}

			IObservableProperty<string> Name { get; }

			IObservableProperty<string> Description { get; }

			IComplexObservableProperty<Types.IType> Type { get; }
		}

		internal sealed class EffectVariable : IEffectVariable, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty Name_;

			private StringObservableProperty Description_;

			private UnionObservableProperty<IEffectVariable.Types.IType> Type_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<string> Description => Description_;

			public IComplexObservableProperty<IEffectVariable.Types.IType> Type => Type_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Name_.UpdateMap(_map);
				Description_.UpdateMap(_map);
				Type_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Description_.UpdateMapOnInternalMapUpdate(_map);
				Type_.UpdateMapOnInternalMapUpdate(_map);
			}

			public EffectVariable()
				: this(new LoroMap())
			{
			}

			public EffectVariable(LoroMap values)
			{
				_map = values;
				Name_ = new StringObservableProperty("name__1", LoroMap);
				Description_ = new StringObservableProperty("description__2", LoroMap);
				Type_ = new UnionObservableProperty<IEffectVariable.Types.IType>("Type__union", LoroMap, new IEffectVariable.Types.TypeFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Name_.WhenChangeHappens, Description_.WhenChangeHappens, Type_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Name_.Dispose();
				Description_.Dispose();
				Type_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Name_.OnDiff(path, diff);
				Description_.OnDiff(path, diff);
				Type_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IPreset : IEntity, IDisposable
		{
			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<string> Name { get; }

			IComplexCollection<IEffect> Effects { get; }
		}

		public interface IPresetDoc : IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IPreset
		{
		}

		internal sealed class Preset : IPreset, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private StringObservableProperty Name_;

			private MapCollection<IEffect> Effects_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<string> Name => Name_;

			public IComplexCollection<IEffect> Effects => Effects_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Effects_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Effects_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Preset()
				: this(new LoroMap())
			{
			}

			public Preset(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Effects_ = new MapCollection<IEffect>(LoroMap, "effects__3", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Effects_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				Name_.Dispose();
				Effects_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Effects_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		internal sealed class PresetDoc : EntityDocumentBase, IPresetDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IPreset
		{
			private readonly Preset _entity;

			public IObservableProperty<Guid> Uuid => _entity.Uuid;

			public IObservableProperty<string> Name => _entity.Name;

			public IComplexCollection<IEffect> Effects => _entity.Effects;

			public PresetDoc(LoroDoc doc, ulong peerId)
				: base(doc, peerId)
			{
				_entity = new Preset(base.Doc.GetMap("root".ToLoroContainerIdLike()));
			}

			public PresetDoc(ulong peerId)
				: this(new LoroDoc(), peerId)
			{
			}

			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
				if (disposing)
				{
					_entity.Dispose();
				}
			}

			public override void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				_entity.OnDiff(path, diff);
			}

			public override void RegisterLinkedDisposable(IDisposable disposable)
			{
				_entity.RegisterLinkedDisposable(disposable);
			}
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<bool> Enabled { get; }

	IObservableProperty<string> Name { get; }

	IObservableProperty<string> RenderId { get; }

	IObservableProperty<string> BehaviorDescription { get; }

	IObservableProperty<string> Category { get; }

	IComplexCollection<Types.IEffectVariable> Variables { get; }
}
