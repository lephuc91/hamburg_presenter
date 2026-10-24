using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface ILayer : IEntity, IDisposable
{
	public class Types
	{
		public interface IBlending : IEntity, IDisposable
		{
			public class Types
			{
				public interface IMatte : IEntity, IDisposable
				{
					public class Types
					{
						public interface IAlpha : IEntity, IDisposable
						{
							IObservableProperty<bool> Inverted { get; }
						}

						internal sealed class Alpha : IAlpha, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private BoolObservableProperty Inverted_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<bool> Inverted => Inverted_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								Inverted_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								Inverted_.UpdateMapOnInternalMapUpdate(_map);
							}

							public Alpha()
								: this(new LoroMap())
							{
							}

							public Alpha(LoroMap values)
							{
								_map = values;
								Inverted_ = new BoolObservableProperty("inverted__1", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(Inverted_.WhenChangeHappens);
							}

							public void Dispose()
							{
								Inverted_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								Inverted_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface ILuma : IEntity, IDisposable
						{
							IObservableProperty<bool> Inverted { get; }
						}

						internal sealed class Luma : ILuma, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private BoolObservableProperty Inverted_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<bool> Inverted => Inverted_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								Inverted_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								Inverted_.UpdateMapOnInternalMapUpdate(_map);
							}

							public Luma()
								: this(new LoroMap())
							{
							}

							public Luma(LoroMap values)
							{
								_map = values;
								Inverted_ = new BoolObservableProperty("inverted__1", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(Inverted_.WhenChangeHappens);
							}

							public void Dispose()
							{
								Inverted_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								Inverted_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IWhite : IEntity, IDisposable
						{
						}

						internal sealed class White : IWhite, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

							public White()
								: this(new LoroMap())
							{
							}

							public White(LoroMap values)
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

						public interface IMatteType : IEntity, IDisposable
						{
							public interface IAlpha : IMatteType, IEntity, IDisposable, IObservableProperty<Types.IAlpha>
							{
							}

							public interface ILuma : IMatteType, IEntity, IDisposable, IObservableProperty<Types.ILuma>
							{
							}

							public interface IWhite : IMatteType, IEntity, IDisposable, IObservableProperty<Types.IWhite>
							{
							}

							internal class Alpha : IAlpha, IMatteType, IEntity, IDisposable, IObservableProperty<Types.IAlpha>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IAlpha> _Alpha_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _Alpha_.WhenChangeHappens;

								public IObservable<Types.IAlpha> WhenValueChanges => _Alpha_.WhenValueChanges;

								public Types.IAlpha Value => _Alpha_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_Alpha_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_Alpha_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "alpha__1".ToLoroValueLike());
									return loroMap;
								}

								public Alpha()
									: this(InitializeMap())
								{
								}

								public Alpha(LoroMap values)
								{
									_map = values;
									_Alpha_ = new ComplexObservableProperty<Types.IAlpha>("alpha__1", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_Alpha_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_Alpha_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_Alpha_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IAlpha value)
								{
									_Alpha_.Set(value);
								}
							}

							internal class Luma : ILuma, IMatteType, IEntity, IDisposable, IObservableProperty<Types.ILuma>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.ILuma> _Luma_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _Luma_.WhenChangeHappens;

								public IObservable<Types.ILuma> WhenValueChanges => _Luma_.WhenValueChanges;

								public Types.ILuma Value => _Luma_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_Luma_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_Luma_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "luma__2".ToLoroValueLike());
									return loroMap;
								}

								public Luma()
									: this(InitializeMap())
								{
								}

								public Luma(LoroMap values)
								{
									_map = values;
									_Luma_ = new ComplexObservableProperty<Types.ILuma>("luma__2", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_Luma_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_Luma_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_Luma_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.ILuma value)
								{
									_Luma_.Set(value);
								}
							}

							internal class White : IWhite, IMatteType, IEntity, IDisposable, IObservableProperty<Types.IWhite>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IWhite> _White_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _White_.WhenChangeHappens;

								public IObservable<Types.IWhite> WhenValueChanges => _White_.WhenValueChanges;

								public Types.IWhite Value => _White_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_White_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_White_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "white__4".ToLoroValueLike());
									return loroMap;
								}

								public White()
									: this(InitializeMap())
								{
								}

								public White(LoroMap values)
								{
									_map = values;
									_White_ = new ComplexObservableProperty<Types.IWhite>("white__4", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_White_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_White_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_White_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IWhite value)
								{
									_White_.Set(value);
								}
							}
						}

						internal class MatteTypeFactory : IUnionValueFactory<IMatteType>
						{
							public string SelectionKey => "__tag";

							public IMatteType? CreateInstance(LoroMap map)
							{
								return map.Get("__tag").ToStringValue() switch
								{
									"alpha__1" => new IMatteType.Alpha(map), 
									"luma__2" => new IMatteType.Luma(map), 
									"white__4" => new IMatteType.White(map), 
									_ => null, 
								};
							}

							public IMatteType CreateDefault(LoroMap map)
							{
								map.Insert("__tag", "alpha__1".ToLoroValueLike());
								return new IMatteType.Alpha(map);
							}
						}
					}

					IComplexObservableProperty<Types.IMatteType> MatteType { get; }
				}

				internal sealed class Matte : IMatte, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private UnionObservableProperty<IMatte.Types.IMatteType> MatteType_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IComplexObservableProperty<IMatte.Types.IMatteType> MatteType => MatteType_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						MatteType_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						MatteType_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Matte()
						: this(new LoroMap())
					{
					}

					public Matte(LoroMap values)
					{
						_map = values;
						MatteType_ = new UnionObservableProperty<IMatte.Types.IMatteType>("MatteType__union", LoroMap, new IMatte.Types.MatteTypeFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(MatteType_.WhenChangeHappens);
					}

					public void Dispose()
					{
						MatteType_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						MatteType_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IStandard : IEntity, IDisposable
				{
					IObservableProperty<BlendMode> Mode { get; }

					IObservableProperty<double> Opacity { get; }
				}

				internal sealed class Standard : IStandard, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private EnumObservableProperty<BlendMode> Mode_;

					private DoubleObservableProperty Opacity_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<BlendMode> Mode => Mode_;

					public IObservableProperty<double> Opacity => Opacity_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Mode_.UpdateMap(_map);
						Opacity_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Mode_.UpdateMapOnInternalMapUpdate(_map);
						Opacity_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Standard()
						: this(new LoroMap())
					{
					}

					public Standard(LoroMap values)
					{
						_map = values;
						Mode_ = new EnumObservableProperty<BlendMode>("mode__1", LoroMap);
						Opacity_ = new DoubleObservableProperty("opacity__2", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Mode_.WhenChangeHappens.Merge(Opacity_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Mode_.Dispose();
						Opacity_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Mode_.OnDiff(path, diff);
						Opacity_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}
			}
		}

		internal sealed class Blending : IBlending, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

			public Blending()
				: this(new LoroMap())
			{
			}

			public Blending(LoroMap values)
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

		public enum BlendMode
		{
			Normal,
			Dissolve,
			Darken,
			Multiply,
			ColorBurn,
			LinearBurn,
			DarkerColor,
			Lighten,
			Screen,
			ColorDodge,
			LinearDodge,
			LighterColor,
			Overlay,
			SoftLight,
			HardLight,
			VividLight,
			LinearLight,
			PinLight,
			HardMix,
			Difference,
			Exclusion,
			Subtract,
			Divide,
			Hue,
			Saturation,
			Color,
			Luminosity
		}
	}
}
