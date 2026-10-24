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

public interface ITestPatternDocument : IEntity, IDisposable
{
	public class Types
	{
		public interface ITestPatternData : IEntity, IDisposable
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
				}

				internal sealed class ColorProperty : IColorProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private AtomicObservableProperty<Color> Value_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<Color> Value => Value_;

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

					public ColorProperty()
						: this(new LoroMap())
					{
					}

					public ColorProperty(LoroMap values)
					{
						_map = values;
						Value_ = new AtomicObservableProperty<Color>("value__1", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
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

				public interface IDoubleProperty : IEntity, IDisposable
				{
					IObservableProperty<double> Value { get; }
				}

				internal sealed class DoubleProperty : IDoubleProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private DoubleObservableProperty Value_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<double> Value => Value_;

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

					public DoubleProperty()
						: this(new LoroMap())
					{
					}

					public DoubleProperty(LoroMap values)
					{
						_map = values;
						Value_ = new DoubleObservableProperty("value__1", LoroMap);
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

				public interface IFontProperty : IEntity, IDisposable
				{
					IObservableProperty<Font> Value { get; }
				}

				internal sealed class FontProperty : IFontProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private AtomicObservableProperty<Font> Value_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<Font> Value => Value_;

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

					public FontProperty()
						: this(new LoroMap())
					{
					}

					public FontProperty(LoroMap values)
					{
						_map = values;
						Value_ = new AtomicObservableProperty<Font>("value__1", LoroMap, FontExtension.Deserialize, FontExtension.Serialize);
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

				public interface IIntProperty : IEntity, IDisposable
				{
					IObservableProperty<int> Value { get; }
				}

				internal sealed class IntProperty : IIntProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private IntObservableProperty Value_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<int> Value => Value_;

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

					public IntProperty()
						: this(new LoroMap())
					{
					}

					public IntProperty(LoroMap values)
					{
						_map = values;
						Value_ = new IntObservableProperty("value__1", LoroMap);
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

				public interface IProperty : IEntity, IDisposable
				{
					public class Types
					{
						public interface IPropertyType : IEntity, IDisposable
						{
							public interface IColorProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.IColorProperty>
							{
							}

							public interface IDoubleProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.IDoubleProperty>
							{
							}

							public interface IIntProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.IIntProperty>
							{
							}

							public interface IBoolProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.IBoolProperty>
							{
							}

							public interface IStringProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.IStringProperty>
							{
							}

							public interface IFontProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.IFontProperty>
							{
							}

							public interface ISelectorProperty : IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.ISelectorProperty>
							{
							}

							internal class ColorProperty : IColorProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.IColorProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<ITestPatternData.Types.IColorProperty> _ColorProperty_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _ColorProperty_.WhenChangeHappens;

								public IObservable<ITestPatternData.Types.IColorProperty> WhenValueChanges => _ColorProperty_.WhenValueChanges;

								public ITestPatternData.Types.IColorProperty Value => _ColorProperty_.Value;

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
									loroMap.Insert("__tag", "color_property__2".ToLoroValueLike());
									return loroMap;
								}

								public ColorProperty()
									: this(InitializeMap())
								{
								}

								public ColorProperty(LoroMap values)
								{
									_map = values;
									_ColorProperty_ = new ComplexObservableProperty<ITestPatternData.Types.IColorProperty>("color_property__2", LoroMap, new EntityFactory());
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

								public void Set(ITestPatternData.Types.IColorProperty value)
								{
									_ColorProperty_.Set(value);
								}
							}

							internal class DoubleProperty : IDoubleProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.IDoubleProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<ITestPatternData.Types.IDoubleProperty> _DoubleProperty_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _DoubleProperty_.WhenChangeHappens;

								public IObservable<ITestPatternData.Types.IDoubleProperty> WhenValueChanges => _DoubleProperty_.WhenValueChanges;

								public ITestPatternData.Types.IDoubleProperty Value => _DoubleProperty_.Value;

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
									loroMap.Insert("__tag", "double_property__3".ToLoroValueLike());
									return loroMap;
								}

								public DoubleProperty()
									: this(InitializeMap())
								{
								}

								public DoubleProperty(LoroMap values)
								{
									_map = values;
									_DoubleProperty_ = new ComplexObservableProperty<ITestPatternData.Types.IDoubleProperty>("double_property__3", LoroMap, new EntityFactory());
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

								public void Set(ITestPatternData.Types.IDoubleProperty value)
								{
									_DoubleProperty_.Set(value);
								}
							}

							internal class IntProperty : IIntProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.IIntProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<ITestPatternData.Types.IIntProperty> _IntProperty_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _IntProperty_.WhenChangeHappens;

								public IObservable<ITestPatternData.Types.IIntProperty> WhenValueChanges => _IntProperty_.WhenValueChanges;

								public ITestPatternData.Types.IIntProperty Value => _IntProperty_.Value;

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
									loroMap.Insert("__tag", "int_property__4".ToLoroValueLike());
									return loroMap;
								}

								public IntProperty()
									: this(InitializeMap())
								{
								}

								public IntProperty(LoroMap values)
								{
									_map = values;
									_IntProperty_ = new ComplexObservableProperty<ITestPatternData.Types.IIntProperty>("int_property__4", LoroMap, new EntityFactory());
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

								public void Set(ITestPatternData.Types.IIntProperty value)
								{
									_IntProperty_.Set(value);
								}
							}

							internal class BoolProperty : IBoolProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.IBoolProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<ITestPatternData.Types.IBoolProperty> _BoolProperty_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _BoolProperty_.WhenChangeHappens;

								public IObservable<ITestPatternData.Types.IBoolProperty> WhenValueChanges => _BoolProperty_.WhenValueChanges;

								public ITestPatternData.Types.IBoolProperty Value => _BoolProperty_.Value;

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
									loroMap.Insert("__tag", "bool_property__5".ToLoroValueLike());
									return loroMap;
								}

								public BoolProperty()
									: this(InitializeMap())
								{
								}

								public BoolProperty(LoroMap values)
								{
									_map = values;
									_BoolProperty_ = new ComplexObservableProperty<ITestPatternData.Types.IBoolProperty>("bool_property__5", LoroMap, new EntityFactory());
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

								public void Set(ITestPatternData.Types.IBoolProperty value)
								{
									_BoolProperty_.Set(value);
								}
							}

							internal class StringProperty : IStringProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.IStringProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<ITestPatternData.Types.IStringProperty> _StringProperty_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _StringProperty_.WhenChangeHappens;

								public IObservable<ITestPatternData.Types.IStringProperty> WhenValueChanges => _StringProperty_.WhenValueChanges;

								public ITestPatternData.Types.IStringProperty Value => _StringProperty_.Value;

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
									loroMap.Insert("__tag", "string_property__6".ToLoroValueLike());
									return loroMap;
								}

								public StringProperty()
									: this(InitializeMap())
								{
								}

								public StringProperty(LoroMap values)
								{
									_map = values;
									_StringProperty_ = new ComplexObservableProperty<ITestPatternData.Types.IStringProperty>("string_property__6", LoroMap, new EntityFactory());
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

								public void Set(ITestPatternData.Types.IStringProperty value)
								{
									_StringProperty_.Set(value);
								}
							}

							internal class FontProperty : IFontProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.IFontProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<ITestPatternData.Types.IFontProperty> _FontProperty_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _FontProperty_.WhenChangeHappens;

								public IObservable<ITestPatternData.Types.IFontProperty> WhenValueChanges => _FontProperty_.WhenValueChanges;

								public ITestPatternData.Types.IFontProperty Value => _FontProperty_.Value;

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
									loroMap.Insert("__tag", "font_property__7".ToLoroValueLike());
									return loroMap;
								}

								public FontProperty()
									: this(InitializeMap())
								{
								}

								public FontProperty(LoroMap values)
								{
									_map = values;
									_FontProperty_ = new ComplexObservableProperty<ITestPatternData.Types.IFontProperty>("font_property__7", LoroMap, new EntityFactory());
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

								public void Set(ITestPatternData.Types.IFontProperty value)
								{
									_FontProperty_.Set(value);
								}
							}

							internal class SelectorProperty : ISelectorProperty, IPropertyType, IEntity, IDisposable, IObservableProperty<ITestPatternData.Types.ISelectorProperty>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<ITestPatternData.Types.ISelectorProperty> _SelectorProperty_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _SelectorProperty_.WhenChangeHappens;

								public IObservable<ITestPatternData.Types.ISelectorProperty> WhenValueChanges => _SelectorProperty_.WhenValueChanges;

								public ITestPatternData.Types.ISelectorProperty Value => _SelectorProperty_.Value;

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
									loroMap.Insert("__tag", "selector_property__8".ToLoroValueLike());
									return loroMap;
								}

								public SelectorProperty()
									: this(InitializeMap())
								{
								}

								public SelectorProperty(LoroMap values)
								{
									_map = values;
									_SelectorProperty_ = new ComplexObservableProperty<ITestPatternData.Types.ISelectorProperty>("selector_property__8", LoroMap, new EntityFactory());
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

								public void Set(ITestPatternData.Types.ISelectorProperty value)
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
									"color_property__2" => new IPropertyType.ColorProperty(map), 
									"double_property__3" => new IPropertyType.DoubleProperty(map), 
									"int_property__4" => new IPropertyType.IntProperty(map), 
									"bool_property__5" => new IPropertyType.BoolProperty(map), 
									"string_property__6" => new IPropertyType.StringProperty(map), 
									"font_property__7" => new IPropertyType.FontProperty(map), 
									"selector_property__8" => new IPropertyType.SelectorProperty(map), 
									_ => null, 
								};
							}

							public IPropertyType CreateDefault(LoroMap map)
							{
								map.Insert("__tag", "color_property__2".ToLoroValueLike());
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
					IObservableProperty<int> Value { get; }
				}

				internal sealed class SelectorProperty : ISelectorProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private IntObservableProperty Value_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<int> Value => Value_;

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

					public SelectorProperty()
						: this(new LoroMap())
					{
					}

					public SelectorProperty(LoroMap values)
					{
						_map = values;
						Value_ = new IntObservableProperty("value__1", LoroMap);
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

				public interface IStringProperty : IEntity, IDisposable
				{
					IObservableProperty<string> Value { get; }
				}

				internal sealed class StringProperty : IStringProperty, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

					public StringProperty()
						: this(new LoroMap())
					{
					}

					public StringProperty(LoroMap values)
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
			}

			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<string> NameLocalizationKey { get; }

			IComplexCollection<Types.IProperty> Properties { get; }
		}

		internal sealed class TestPatternData : ITestPatternData, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private StringObservableProperty NameLocalizationKey_;

			private MapCollection<ITestPatternData.Types.IProperty> Properties_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<string> NameLocalizationKey => NameLocalizationKey_;

			public IComplexCollection<ITestPatternData.Types.IProperty> Properties => Properties_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				NameLocalizationKey_.UpdateMap(_map);
				Properties_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				NameLocalizationKey_.UpdateMapOnInternalMapUpdate(_map);
				Properties_.UpdateMapOnInternalMapUpdate(_map);
			}

			public TestPatternData()
				: this(new LoroMap())
			{
			}

			public TestPatternData(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				NameLocalizationKey_ = new StringObservableProperty("name_localization_key__2", LoroMap);
				Properties_ = new MapCollection<ITestPatternData.Types.IProperty>(LoroMap, "properties__3", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, NameLocalizationKey_.WhenChangeHappens, Properties_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				NameLocalizationKey_.Dispose();
				Properties_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				NameLocalizationKey_.OnDiff(path, diff);
				Properties_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ITestPatternStateData : IEntity, IDisposable
		{
			IObservableProperty<Guid?> TestPatternId { get; }

			IObservableProperty<ITestPatternState.Types.DisplayLocation> DisplayLocation { get; }

			IObservableProperty<Guid?> SpecificScreen { get; }

			IObservableProperty<bool> IdentifyScreens { get; }

			IObservableProperty<LogoType> LogoType { get; }

			IObservableProperty<Url?> UserLogoLocation { get; }
		}

		internal sealed class TestPatternStateData : ITestPatternStateData, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private OptionalGuidObservableProperty TestPatternId_;

			private EnumObservableProperty<ITestPatternState.Types.DisplayLocation> DisplayLocation_;

			private OptionalGuidObservableProperty SpecificScreen_;

			private BoolObservableProperty IdentifyScreens_;

			private EnumObservableProperty<LogoType> LogoType_;

			private OptionalAtomicObservableProperty<Url> UserLogoLocation_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid?> TestPatternId => TestPatternId_;

			public IObservableProperty<ITestPatternState.Types.DisplayLocation> DisplayLocation => DisplayLocation_;

			public IObservableProperty<Guid?> SpecificScreen => SpecificScreen_;

			public IObservableProperty<bool> IdentifyScreens => IdentifyScreens_;

			public IObservableProperty<LogoType> LogoType => LogoType_;

			public IObservableProperty<Url?> UserLogoLocation => UserLogoLocation_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				TestPatternId_.UpdateMap(_map);
				DisplayLocation_.UpdateMap(_map);
				SpecificScreen_.UpdateMap(_map);
				IdentifyScreens_.UpdateMap(_map);
				LogoType_.UpdateMap(_map);
				UserLogoLocation_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				TestPatternId_.UpdateMapOnInternalMapUpdate(_map);
				DisplayLocation_.UpdateMapOnInternalMapUpdate(_map);
				SpecificScreen_.UpdateMapOnInternalMapUpdate(_map);
				IdentifyScreens_.UpdateMapOnInternalMapUpdate(_map);
				LogoType_.UpdateMapOnInternalMapUpdate(_map);
				UserLogoLocation_.UpdateMapOnInternalMapUpdate(_map);
			}

			public TestPatternStateData()
				: this(new LoroMap())
			{
			}

			public TestPatternStateData(LoroMap values)
			{
				_map = values;
				TestPatternId_ = new OptionalGuidObservableProperty("test_pattern_id__1", LoroMap);
				DisplayLocation_ = new EnumObservableProperty<ITestPatternState.Types.DisplayLocation>("display_location__3", LoroMap);
				SpecificScreen_ = new OptionalGuidObservableProperty("specific_screen__4", LoroMap);
				IdentifyScreens_ = new BoolObservableProperty("identify_screens__5", LoroMap);
				LogoType_ = new EnumObservableProperty<LogoType>("logo_type__6", LoroMap);
				UserLogoLocation_ = new OptionalAtomicObservableProperty<Url>("user_logo_location__7", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(TestPatternId_.WhenChangeHappens, DisplayLocation_.WhenChangeHappens, SpecificScreen_.WhenChangeHappens, IdentifyScreens_.WhenChangeHappens, LogoType_.WhenChangeHappens, UserLogoLocation_.WhenChangeHappens);
			}

			public void Dispose()
			{
				TestPatternId_.Dispose();
				DisplayLocation_.Dispose();
				SpecificScreen_.Dispose();
				IdentifyScreens_.Dispose();
				LogoType_.Dispose();
				UserLogoLocation_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				TestPatternId_.OnDiff(path, diff);
				DisplayLocation_.OnDiff(path, diff);
				SpecificScreen_.OnDiff(path, diff);
				IdentifyScreens_.OnDiff(path, diff);
				LogoType_.OnDiff(path, diff);
				UserLogoLocation_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IComplexObservableProperty<Types.ITestPatternStateData?> State { get; }

	IComplexCollection<Types.ITestPatternData> Patterns { get; }
}
