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

public interface ITestPatternDefinition : IEntity, IDisposable
{
	public class Types
	{
		public interface IBoolProperty : IEntity, IDisposable
		{
			IObservableProperty<bool> Value { get; }

			IComplexCollection<IProperty> DependentProperties { get; }
		}

		internal sealed class BoolProperty : IBoolProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private BoolObservableProperty Value_;

			private MapCollection<IProperty> DependentProperties_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<bool> Value => Value_;

			public IComplexCollection<IProperty> DependentProperties => DependentProperties_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Value_.UpdateMap(_map);
				DependentProperties_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Value_.UpdateMapOnInternalMapUpdate(_map);
				DependentProperties_.UpdateMapOnInternalMapUpdate(_map);
			}

			public BoolProperty()
				: this(new LoroMap())
			{
			}

			public BoolProperty(LoroMap values)
			{
				_map = values;
				Value_ = new BoolObservableProperty("value__1", LoroMap);
				DependentProperties_ = new MapCollection<IProperty>(LoroMap, "dependent_properties__2", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Value_.WhenChangeHappens.Merge(DependentProperties_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Value_.Dispose();
				DependentProperties_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Value_.OnDiff(path, diff);
				DependentProperties_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IColorProperty : IEntity, IDisposable
		{
			IObservableProperty<Color> Value { get; }

			IObservableProperty<bool> AllowAlpha { get; }

			ICollection<Color> DefaultColors { get; }
		}

		internal sealed class ColorProperty : IColorProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private AtomicObservableProperty<Color> Value_;

			private BoolObservableProperty AllowAlpha_;

			private AtomicMapCollection<Color> DefaultColors_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Color> Value => Value_;

			public IObservableProperty<bool> AllowAlpha => AllowAlpha_;

			public ICollection<Color> DefaultColors => DefaultColors_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Value_.UpdateMap(_map);
				AllowAlpha_.UpdateMap(_map);
				DefaultColors_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Value_.UpdateMapOnInternalMapUpdate(_map);
				AllowAlpha_.UpdateMapOnInternalMapUpdate(_map);
				DefaultColors_.UpdateMapOnInternalMapUpdate(_map);
			}

			public ColorProperty()
				: this(new LoroMap())
			{
			}

			public ColorProperty(LoroMap values)
			{
				_map = values;
				Value_ = new AtomicObservableProperty<Color>("value__1", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
				AllowAlpha_ = new BoolObservableProperty("allow_alpha__2", LoroMap);
				DefaultColors_ = new AtomicMapCollection<Color>(LoroMap, "default_colors__3", new EntityFactory(), ColorExtension.Serialize);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Value_.WhenChangeHappens, AllowAlpha_.WhenChangeHappens, DefaultColors_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Value_.Dispose();
				AllowAlpha_.Dispose();
				DefaultColors_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Value_.OnDiff(path, diff);
				AllowAlpha_.OnDiff(path, diff);
				DefaultColors_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IDoubleProperty : IEntity, IDisposable
		{
			public class Types
			{
				public enum ViewType
				{
					Stepper,
					Slider,
					SpeedSlider
				}
			}

			IObservableProperty<double> Value { get; }

			IObservableProperty<double> Min { get; }

			IObservableProperty<double> Max { get; }

			IObservableProperty<double> Step { get; }

			IObservableProperty<string> Units { get; }

			IObservableProperty<Types.ViewType> ViewType { get; }
		}

		internal sealed class DoubleProperty : IDoubleProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private DoubleObservableProperty Value_;

			private DoubleObservableProperty Min_;

			private DoubleObservableProperty Max_;

			private DoubleObservableProperty Step_;

			private StringObservableProperty Units_;

			private EnumObservableProperty<IDoubleProperty.Types.ViewType> ViewType_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<double> Value => Value_;

			public IObservableProperty<double> Min => Min_;

			public IObservableProperty<double> Max => Max_;

			public IObservableProperty<double> Step => Step_;

			public IObservableProperty<string> Units => Units_;

			public IObservableProperty<IDoubleProperty.Types.ViewType> ViewType => ViewType_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Value_.UpdateMap(_map);
				Min_.UpdateMap(_map);
				Max_.UpdateMap(_map);
				Step_.UpdateMap(_map);
				Units_.UpdateMap(_map);
				ViewType_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Value_.UpdateMapOnInternalMapUpdate(_map);
				Min_.UpdateMapOnInternalMapUpdate(_map);
				Max_.UpdateMapOnInternalMapUpdate(_map);
				Step_.UpdateMapOnInternalMapUpdate(_map);
				Units_.UpdateMapOnInternalMapUpdate(_map);
				ViewType_.UpdateMapOnInternalMapUpdate(_map);
			}

			public DoubleProperty()
				: this(new LoroMap())
			{
			}

			public DoubleProperty(LoroMap values)
			{
				_map = values;
				Value_ = new DoubleObservableProperty("value__1", LoroMap);
				Min_ = new DoubleObservableProperty("min__2", LoroMap);
				Max_ = new DoubleObservableProperty("max__3", LoroMap);
				Step_ = new DoubleObservableProperty("step__4", LoroMap);
				Units_ = new StringObservableProperty("units__5", LoroMap);
				ViewType_ = new EnumObservableProperty<IDoubleProperty.Types.ViewType>("viewType__6", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Value_.WhenChangeHappens, Min_.WhenChangeHappens, Max_.WhenChangeHappens, Step_.WhenChangeHappens, Units_.WhenChangeHappens, ViewType_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Value_.Dispose();
				Min_.Dispose();
				Max_.Dispose();
				Step_.Dispose();
				Units_.Dispose();
				ViewType_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Value_.OnDiff(path, diff);
				Min_.OnDiff(path, diff);
				Max_.OnDiff(path, diff);
				Step_.OnDiff(path, diff);
				Units_.OnDiff(path, diff);
				ViewType_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IFontProperty : IEntity, IDisposable
		{
			IObservableProperty<Font> Font { get; }
		}

		internal sealed class FontProperty : IFontProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private AtomicObservableProperty<Font> Font_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Font> Font => Font_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Font_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Font_.UpdateMapOnInternalMapUpdate(_map);
			}

			public FontProperty()
				: this(new LoroMap())
			{
			}

			public FontProperty(LoroMap values)
			{
				_map = values;
				Font_ = new AtomicObservableProperty<Font>("font__1", LoroMap, FontExtension.Deserialize, FontExtension.Serialize);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Font_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Font_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Font_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IIntProperty : IEntity, IDisposable
		{
			IObservableProperty<int> Value { get; }

			IObservableProperty<int> Min { get; }

			IObservableProperty<int> Max { get; }

			IObservableProperty<string> Units { get; }
		}

		internal sealed class IntProperty : IIntProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private IntObservableProperty Value_;

			private IntObservableProperty Min_;

			private IntObservableProperty Max_;

			private StringObservableProperty Units_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<int> Value => Value_;

			public IObservableProperty<int> Min => Min_;

			public IObservableProperty<int> Max => Max_;

			public IObservableProperty<string> Units => Units_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Value_.UpdateMap(_map);
				Min_.UpdateMap(_map);
				Max_.UpdateMap(_map);
				Units_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Value_.UpdateMapOnInternalMapUpdate(_map);
				Min_.UpdateMapOnInternalMapUpdate(_map);
				Max_.UpdateMapOnInternalMapUpdate(_map);
				Units_.UpdateMapOnInternalMapUpdate(_map);
			}

			public IntProperty()
				: this(new LoroMap())
			{
			}

			public IntProperty(LoroMap values)
			{
				_map = values;
				Value_ = new IntObservableProperty("value__1", LoroMap);
				Min_ = new IntObservableProperty("min__2", LoroMap);
				Max_ = new IntObservableProperty("max__3", LoroMap);
				Units_ = new StringObservableProperty("units__5", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Value_.WhenChangeHappens, Min_.WhenChangeHappens, Max_.WhenChangeHappens, Units_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Value_.Dispose();
				Min_.Dispose();
				Max_.Dispose();
				Units_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Value_.OnDiff(path, diff);
				Min_.OnDiff(path, diff);
				Max_.OnDiff(path, diff);
				Units_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IProperty : IEntity, IDisposable
		{
			public class Types
			{
				public interface IPropertyType : IEntity, IDisposable
				{
					public interface IColorProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.IColorProperty>
					{
					}

					public interface IDoubleProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.IDoubleProperty>
					{
					}

					public interface IIntProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.IIntProperty>
					{
					}

					public interface IBoolProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.IBoolProperty>
					{
					}

					public interface IStringProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.IStringProperty>
					{
					}

					public interface IFontProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.IFontProperty>
					{
					}

					public interface ISelectorProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.ISelectorProperty>
					{
					}

					internal class ColorProperty : IColorProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.IColorProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITestPatternDefinition.Types.IColorProperty> _ColorProperty_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _ColorProperty_.WhenChangeHappens;

						public IObservable<ITestPatternDefinition.Types.IColorProperty> WhenValueChanges => _ColorProperty_.WhenValueChanges;

						public ITestPatternDefinition.Types.IColorProperty Value => _ColorProperty_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_ColorProperty_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_ColorProperty_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "color_property__3".ToLoroValueLike());
							return loroMap;
						}

						public ColorProperty()
							: this(InitializeMap())
						{
						}

						public ColorProperty(LoroMap values)
						{
							_map = values;
							_ColorProperty_ = new ComplexObservableProperty<ITestPatternDefinition.Types.IColorProperty>("color_property__3", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_ColorProperty_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_ColorProperty_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_ColorProperty_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITestPatternDefinition.Types.IColorProperty value)
						{
							_ColorProperty_.Set(value);
						}
					}

					internal class DoubleProperty : IDoubleProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.IDoubleProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITestPatternDefinition.Types.IDoubleProperty> _DoubleProperty_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _DoubleProperty_.WhenChangeHappens;

						public IObservable<ITestPatternDefinition.Types.IDoubleProperty> WhenValueChanges => _DoubleProperty_.WhenValueChanges;

						public ITestPatternDefinition.Types.IDoubleProperty Value => _DoubleProperty_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_DoubleProperty_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_DoubleProperty_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "double_property__4".ToLoroValueLike());
							return loroMap;
						}

						public DoubleProperty()
							: this(InitializeMap())
						{
						}

						public DoubleProperty(LoroMap values)
						{
							_map = values;
							_DoubleProperty_ = new ComplexObservableProperty<ITestPatternDefinition.Types.IDoubleProperty>("double_property__4", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_DoubleProperty_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_DoubleProperty_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_DoubleProperty_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITestPatternDefinition.Types.IDoubleProperty value)
						{
							_DoubleProperty_.Set(value);
						}
					}

					internal class IntProperty : IIntProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.IIntProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITestPatternDefinition.Types.IIntProperty> _IntProperty_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _IntProperty_.WhenChangeHappens;

						public IObservable<ITestPatternDefinition.Types.IIntProperty> WhenValueChanges => _IntProperty_.WhenValueChanges;

						public ITestPatternDefinition.Types.IIntProperty Value => _IntProperty_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_IntProperty_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_IntProperty_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "int_property__5".ToLoroValueLike());
							return loroMap;
						}

						public IntProperty()
							: this(InitializeMap())
						{
						}

						public IntProperty(LoroMap values)
						{
							_map = values;
							_IntProperty_ = new ComplexObservableProperty<ITestPatternDefinition.Types.IIntProperty>("int_property__5", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_IntProperty_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_IntProperty_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_IntProperty_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITestPatternDefinition.Types.IIntProperty value)
						{
							_IntProperty_.Set(value);
						}
					}

					internal class BoolProperty : IBoolProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.IBoolProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITestPatternDefinition.Types.IBoolProperty> _BoolProperty_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _BoolProperty_.WhenChangeHappens;

						public IObservable<ITestPatternDefinition.Types.IBoolProperty> WhenValueChanges => _BoolProperty_.WhenValueChanges;

						public ITestPatternDefinition.Types.IBoolProperty Value => _BoolProperty_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_BoolProperty_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_BoolProperty_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "bool_property__6".ToLoroValueLike());
							return loroMap;
						}

						public BoolProperty()
							: this(InitializeMap())
						{
						}

						public BoolProperty(LoroMap values)
						{
							_map = values;
							_BoolProperty_ = new ComplexObservableProperty<ITestPatternDefinition.Types.IBoolProperty>("bool_property__6", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_BoolProperty_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_BoolProperty_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_BoolProperty_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITestPatternDefinition.Types.IBoolProperty value)
						{
							_BoolProperty_.Set(value);
						}
					}

					internal class StringProperty : IStringProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.IStringProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITestPatternDefinition.Types.IStringProperty> _StringProperty_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _StringProperty_.WhenChangeHappens;

						public IObservable<ITestPatternDefinition.Types.IStringProperty> WhenValueChanges => _StringProperty_.WhenValueChanges;

						public ITestPatternDefinition.Types.IStringProperty Value => _StringProperty_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_StringProperty_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_StringProperty_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "string_property__7".ToLoroValueLike());
							return loroMap;
						}

						public StringProperty()
							: this(InitializeMap())
						{
						}

						public StringProperty(LoroMap values)
						{
							_map = values;
							_StringProperty_ = new ComplexObservableProperty<ITestPatternDefinition.Types.IStringProperty>("string_property__7", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_StringProperty_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_StringProperty_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_StringProperty_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITestPatternDefinition.Types.IStringProperty value)
						{
							_StringProperty_.Set(value);
						}
					}

					internal class FontProperty : IFontProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.IFontProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITestPatternDefinition.Types.IFontProperty> _FontProperty_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _FontProperty_.WhenChangeHappens;

						public IObservable<ITestPatternDefinition.Types.IFontProperty> WhenValueChanges => _FontProperty_.WhenValueChanges;

						public ITestPatternDefinition.Types.IFontProperty Value => _FontProperty_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_FontProperty_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_FontProperty_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "font_property__8".ToLoroValueLike());
							return loroMap;
						}

						public FontProperty()
							: this(InitializeMap())
						{
						}

						public FontProperty(LoroMap values)
						{
							_map = values;
							_FontProperty_ = new ComplexObservableProperty<ITestPatternDefinition.Types.IFontProperty>("font_property__8", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_FontProperty_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_FontProperty_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_FontProperty_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITestPatternDefinition.Types.IFontProperty value)
						{
							_FontProperty_.Set(value);
						}
					}

					internal class SelectorProperty : ISelectorProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternDefinition.Types.ISelectorProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<ITestPatternDefinition.Types.ISelectorProperty> _SelectorProperty_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _SelectorProperty_.WhenChangeHappens;

						public IObservable<ITestPatternDefinition.Types.ISelectorProperty> WhenValueChanges => _SelectorProperty_.WhenValueChanges;

						public ITestPatternDefinition.Types.ISelectorProperty Value => _SelectorProperty_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_SelectorProperty_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_SelectorProperty_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "selector_property__9".ToLoroValueLike());
							return loroMap;
						}

						public SelectorProperty()
							: this(InitializeMap())
						{
						}

						public SelectorProperty(LoroMap values)
						{
							_map = values;
							_SelectorProperty_ = new ComplexObservableProperty<ITestPatternDefinition.Types.ISelectorProperty>("selector_property__9", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_SelectorProperty_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_SelectorProperty_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_SelectorProperty_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(ITestPatternDefinition.Types.ISelectorProperty value)
						{
							_SelectorProperty_.Set(value);
						}
					}
				}

				internal class PropertyTypeFactory : IUnionValueFactory<IPropertyType>
				{
					public string SelectionKey => "__tag";

					public IPropertyType? CreateInstance(LoroMap map)
					{
						return map.Get("__tag").ToStringValue() switch
						{
							"color_property__3" => new IPropertyType.ColorProperty(map), 
							"double_property__4" => new IPropertyType.DoubleProperty(map), 
							"int_property__5" => new IPropertyType.IntProperty(map), 
							"bool_property__6" => new IPropertyType.BoolProperty(map), 
							"string_property__7" => new IPropertyType.StringProperty(map), 
							"font_property__8" => new IPropertyType.FontProperty(map), 
							"selector_property__9" => new IPropertyType.SelectorProperty(map), 
							_ => null, 
						};
					}

					public IPropertyType CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "color_property__3".ToLoroValueLike());
						return new IPropertyType.ColorProperty(map);
					}
				}
			}

			IObservableProperty<string> NameLocalizationKey { get; }

			IComplexObservableProperty<Types.IPropertyType> PropertyType { get; }
		}

		internal sealed class Property : IProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty NameLocalizationKey_;

			private UnionObservableProperty<IProperty.Types.IPropertyType> PropertyType_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> NameLocalizationKey => NameLocalizationKey_;

			public IComplexObservableProperty<IProperty.Types.IPropertyType> PropertyType => PropertyType_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				NameLocalizationKey_.UpdateMap(_map);
				PropertyType_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				NameLocalizationKey_.UpdateMapOnInternalMapUpdate(_map);
				PropertyType_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Property()
				: this(new LoroMap())
			{
			}

			public Property(LoroMap values)
			{
				_map = values;
				NameLocalizationKey_ = new StringObservableProperty("name_localization_key__1", LoroMap);
				PropertyType_ = new UnionObservableProperty<IProperty.Types.IPropertyType>("PropertyType__union", LoroMap, new IProperty.Types.PropertyTypeFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = NameLocalizationKey_.WhenChangeHappens.Merge(PropertyType_.WhenChangeHappens);
			}

			public void Dispose()
			{
				NameLocalizationKey_.Dispose();
				PropertyType_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				NameLocalizationKey_.OnDiff(path, diff);
				PropertyType_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ISelectorProperty : IEntity, IDisposable
		{
			IObservableProperty<int> SelectedIndex { get; }

			ICollection<string> ValueLocalizationKeys { get; }
		}

		internal sealed class SelectorProperty : ISelectorProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private IntObservableProperty SelectedIndex_;

			private StringCollection ValueLocalizationKeys_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<int> SelectedIndex => SelectedIndex_;

			public ICollection<string> ValueLocalizationKeys => ValueLocalizationKeys_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				SelectedIndex_.UpdateMap(_map);
				ValueLocalizationKeys_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				SelectedIndex_.UpdateMapOnInternalMapUpdate(_map);
				ValueLocalizationKeys_.UpdateMapOnInternalMapUpdate(_map);
			}

			public SelectorProperty()
				: this(new LoroMap())
			{
			}

			public SelectorProperty(LoroMap values)
			{
				_map = values;
				SelectedIndex_ = new IntObservableProperty("selected_index__1", LoroMap);
				ValueLocalizationKeys_ = new StringCollection(LoroMap, "value_localization_keys__2");
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = SelectedIndex_.WhenChangeHappens.Merge(ValueLocalizationKeys_.WhenChangeHappens);
			}

			public void Dispose()
			{
				SelectedIndex_.Dispose();
				ValueLocalizationKeys_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				SelectedIndex_.OnDiff(path, diff);
				ValueLocalizationKeys_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IStringProperty : IEntity, IDisposable
		{
			IObservableProperty<string> Value { get; }

			IObservableProperty<int> MinChars { get; }

			IObservableProperty<int> MaxChars { get; }
		}

		internal sealed class StringProperty : IStringProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty Value_;

			private IntObservableProperty MinChars_;

			private IntObservableProperty MaxChars_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> Value => Value_;

			public IObservableProperty<int> MinChars => MinChars_;

			public IObservableProperty<int> MaxChars => MaxChars_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Value_.UpdateMap(_map);
				MinChars_.UpdateMap(_map);
				MaxChars_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Value_.UpdateMapOnInternalMapUpdate(_map);
				MinChars_.UpdateMapOnInternalMapUpdate(_map);
				MaxChars_.UpdateMapOnInternalMapUpdate(_map);
			}

			public StringProperty()
				: this(new LoroMap())
			{
			}

			public StringProperty(LoroMap values)
			{
				_map = values;
				Value_ = new StringObservableProperty("value__1", LoroMap);
				MinChars_ = new IntObservableProperty("min_chars__2", LoroMap);
				MaxChars_ = new IntObservableProperty("max_chars__3", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Value_.WhenChangeHappens, MinChars_.WhenChangeHappens, MaxChars_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Value_.Dispose();
				MinChars_.Dispose();
				MaxChars_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Value_.OnDiff(path, diff);
				MinChars_.OnDiff(path, diff);
				MaxChars_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string> NameLocalizationKey { get; }

	IComplexCollection<Types.IProperty> Properties { get; }

	IObservableProperty<bool> ShowDelaySettings { get; }

	IObservableProperty<bool> IsDefault { get; }
}
