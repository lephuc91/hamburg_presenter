using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.CrdtKeySerializers;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IGraphics : IEntity, IDisposable
{
	public class Types
	{
		public interface IBackgroundEffect : IEntity, IDisposable
		{
			public class Types
			{
				public interface IBackgroundEffectBlur : IEntity, IDisposable
				{
					IObservableProperty<double> Saturation { get; }

					IObservableProperty<double> BlurAmount { get; }
				}

				internal sealed class BackgroundEffectBlur : IBackgroundEffectBlur, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private DoubleObservableProperty Saturation_;

					private DoubleObservableProperty BlurAmount_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<double> Saturation => Saturation_;

					public IObservableProperty<double> BlurAmount => BlurAmount_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Saturation_.UpdateMap(_map);
						BlurAmount_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Saturation_.UpdateMapOnInternalMapUpdate(_map);
						BlurAmount_.UpdateMapOnInternalMapUpdate(_map);
					}

					public BackgroundEffectBlur()
						: this(new LoroMap())
					{
					}

					public BackgroundEffectBlur(LoroMap values)
					{
						_map = values;
						Saturation_ = new DoubleObservableProperty("saturation__1", LoroMap);
						BlurAmount_ = new DoubleObservableProperty("blur_amount__2", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Saturation_.WhenChangeHappens.Merge(BlurAmount_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Saturation_.Dispose();
						BlurAmount_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Saturation_.OnDiff(path, diff);
						BlurAmount_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IBackgroundEffectInvert : IEntity, IDisposable
				{
				}

				internal sealed class BackgroundEffectInvert : IBackgroundEffectInvert, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

					public BackgroundEffectInvert()
						: this(new LoroMap())
					{
					}

					public BackgroundEffectInvert(LoroMap values)
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

				public interface IEffectType : IEntity, IDisposable
				{
					public interface IBackgroundBlur : IEffectType, IEntity, IDisposable, IObservableProperty<IBackgroundEffectBlur>
					{
					}

					public interface IBackgroundInvert : IEffectType, IEntity, IDisposable, IObservableProperty<IBackgroundEffectInvert>
					{
					}

					internal class BackgroundBlur : IBackgroundBlur, IEffectType, IEntity, IDisposable, IObservableProperty<IBackgroundEffectBlur>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IBackgroundEffectBlur> _BackgroundBlur_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _BackgroundBlur_.WhenChangeHappens;

						public IObservable<IBackgroundEffectBlur> WhenValueChanges => _BackgroundBlur_.WhenValueChanges;

						public IBackgroundEffectBlur Value => _BackgroundBlur_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_BackgroundBlur_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_BackgroundBlur_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "backgroundBlur__2".ToLoroValueLike());
							return loroMap;
						}

						public BackgroundBlur()
							: this(InitializeMap())
						{
						}

						public BackgroundBlur(LoroMap values)
						{
							_map = values;
							_BackgroundBlur_ = new ComplexObservableProperty<IBackgroundEffectBlur>("backgroundBlur__2", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_BackgroundBlur_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_BackgroundBlur_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_BackgroundBlur_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IBackgroundEffectBlur value)
						{
							_BackgroundBlur_.Set(value);
						}
					}

					internal class BackgroundInvert : IBackgroundInvert, IEffectType, IEntity, IDisposable, IObservableProperty<IBackgroundEffectInvert>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IBackgroundEffectInvert> _BackgroundInvert_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _BackgroundInvert_.WhenChangeHappens;

						public IObservable<IBackgroundEffectInvert> WhenValueChanges => _BackgroundInvert_.WhenValueChanges;

						public IBackgroundEffectInvert Value => _BackgroundInvert_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_BackgroundInvert_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_BackgroundInvert_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "backgroundInvert__3".ToLoroValueLike());
							return loroMap;
						}

						public BackgroundInvert()
							: this(InitializeMap())
						{
						}

						public BackgroundInvert(LoroMap values)
						{
							_map = values;
							_BackgroundInvert_ = new ComplexObservableProperty<IBackgroundEffectInvert>("backgroundInvert__3", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_BackgroundInvert_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_BackgroundInvert_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_BackgroundInvert_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IBackgroundEffectInvert value)
						{
							_BackgroundInvert_.Set(value);
						}
					}
				}

				internal class EffectTypeFactory : IUnionValueFactory<IEffectType>
				{
					public string SelectionKey => "__tag";

					public IEffectType? CreateInstance(LoroMap map)
					{
						string text = map.Get("__tag").ToStringValue();
						if (!(text == "backgroundBlur__2"))
						{
							if (text == "backgroundInvert__3")
							{
								return new IEffectType.BackgroundInvert(map);
							}
							return null;
						}
						return new IEffectType.BackgroundBlur(map);
					}

					public IEffectType CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "backgroundBlur__2".ToLoroValueLike());
						return new IEffectType.BackgroundBlur(map);
					}
				}
			}

			IComplexObservableProperty<Types.IEffectType> EffectType { get; }
		}

		internal sealed class BackgroundEffect : IBackgroundEffect, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private UnionObservableProperty<IBackgroundEffect.Types.IEffectType> EffectType_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IBackgroundEffect.Types.IEffectType> EffectType => EffectType_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				EffectType_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				EffectType_.UpdateMapOnInternalMapUpdate(_map);
			}

			public BackgroundEffect()
				: this(new LoroMap())
			{
			}

			public BackgroundEffect(LoroMap values)
			{
				_map = values;
				EffectType_ = new UnionObservableProperty<IBackgroundEffect.Types.IEffectType>("EffectType__union", LoroMap, new IBackgroundEffect.Types.EffectTypeFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(EffectType_.WhenChangeHappens);
			}

			public void Dispose()
			{
				EffectType_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				EffectType_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IEdgeInsets : IEntity, IDisposable
		{
			IObservableProperty<double> Left { get; }

			IObservableProperty<double> Right { get; }

			IObservableProperty<double> Top { get; }

			IObservableProperty<double> Bottom { get; }
		}

		internal sealed class EdgeInsets : IEdgeInsets, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private DoubleObservableProperty Left_;

			private DoubleObservableProperty Right_;

			private DoubleObservableProperty Top_;

			private DoubleObservableProperty Bottom_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<double> Left => Left_;

			public IObservableProperty<double> Right => Right_;

			public IObservableProperty<double> Top => Top_;

			public IObservableProperty<double> Bottom => Bottom_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Left_.UpdateMap(_map);
				Right_.UpdateMap(_map);
				Top_.UpdateMap(_map);
				Bottom_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Left_.UpdateMapOnInternalMapUpdate(_map);
				Right_.UpdateMapOnInternalMapUpdate(_map);
				Top_.UpdateMapOnInternalMapUpdate(_map);
				Bottom_.UpdateMapOnInternalMapUpdate(_map);
			}

			public EdgeInsets()
				: this(new LoroMap())
			{
			}

			public EdgeInsets(LoroMap values)
			{
				_map = values;
				Left_ = new DoubleObservableProperty("left__1", LoroMap);
				Right_ = new DoubleObservableProperty("right__2", LoroMap);
				Top_ = new DoubleObservableProperty("top__3", LoroMap);
				Bottom_ = new DoubleObservableProperty("bottom__4", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Left_.WhenChangeHappens, Right_.WhenChangeHappens, Top_.WhenChangeHappens, Bottom_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Left_.Dispose();
				Right_.Dispose();
				Top_.Dispose();
				Bottom_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Left_.OnDiff(path, diff);
				Right_.OnDiff(path, diff);
				Top_.OnDiff(path, diff);
				Bottom_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IElement : IEntity, IDisposable
		{
			public class Types
			{
				public enum FlipMode
				{
					None,
					Vertical,
					Horizontal,
					Both
				}

				public interface IMask : IEntity, IDisposable
				{
					public interface ITextLineMask : IMask, IEntity, IDisposable, IObservableProperty<IText.Types.ILineFillMask>
					{
					}

					internal class TextLineMask : ITextLineMask, IMask, IEntity, IDisposable, IObservableProperty<IText.Types.ILineFillMask>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IText.Types.ILineFillMask> _TextLineMask_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _TextLineMask_.WhenChangeHappens;

						public IObservable<IText.Types.ILineFillMask> WhenValueChanges => _TextLineMask_.WhenValueChanges;

						public IText.Types.ILineFillMask Value => _TextLineMask_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_TextLineMask_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_TextLineMask_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "text_line_mask__14".ToLoroValueLike());
							return loroMap;
						}

						public TextLineMask()
							: this(InitializeMap())
						{
						}

						public TextLineMask(LoroMap values)
						{
							_map = values;
							_TextLineMask_ = new ComplexObservableProperty<IText.Types.ILineFillMask>("text_line_mask__14", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_TextLineMask_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_TextLineMask_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_TextLineMask_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IText.Types.ILineFillMask value)
						{
							_TextLineMask_.Set(value);
						}
					}
				}

				internal class MaskFactory : IUnionValueFactory<IMask>
				{
					public string SelectionKey => "__tag";

					public IMask? CreateInstance(LoroMap map)
					{
						if (map.Get("__tag").ToStringValue() == "text_line_mask__14")
						{
							return new IMask.TextLineMask(map);
						}
						return null;
					}

					public IMask CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "text_line_mask__14".ToLoroValueLike());
						return new IMask.TextLineMask(map);
					}
				}
			}

			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<string> Name { get; }

			IObservableProperty<Rect> Bounds { get; }

			IObservableProperty<double> Rotation { get; }

			IObservableProperty<double> Opacity { get; }

			IObservableProperty<bool> Locked { get; }

			IObservableProperty<bool> AspectRatioLocked { get; }

			IComplexObservableProperty<IPath> Path { get; }

			IComplexObservableProperty<IFill> Fill { get; }

			IComplexObservableProperty<IStroke> Stroke { get; }

			IComplexObservableProperty<IShadow> Shadow { get; }

			IComplexObservableProperty<IFeather> Feather { get; }

			IComplexObservableProperty<IText> Text { get; }

			IObservableProperty<Types.FlipMode> FlipMode { get; }

			IObservableProperty<bool> Hidden { get; }

			IComplexObservableProperty<Types.IMask> Mask { get; }
		}

		internal sealed class Element : IElement, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private StringObservableProperty Name_;

			private AtomicObservableProperty<Rect> Bounds_;

			private DoubleObservableProperty Rotation_;

			private DoubleObservableProperty Opacity_;

			private BoolObservableProperty Locked_;

			private BoolObservableProperty AspectRatioLocked_;

			private ComplexObservableProperty<IPath> Path_;

			private ComplexObservableProperty<IFill> Fill_;

			private ComplexObservableProperty<IStroke> Stroke_;

			private ComplexObservableProperty<IShadow> Shadow_;

			private ComplexObservableProperty<IFeather> Feather_;

			private ComplexObservableProperty<IText> Text_;

			private EnumObservableProperty<IElement.Types.FlipMode> FlipMode_;

			private BoolObservableProperty Hidden_;

			private UnionObservableProperty<IElement.Types.IMask> Mask_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<Rect> Bounds => Bounds_;

			public IObservableProperty<double> Rotation => Rotation_;

			public IObservableProperty<double> Opacity => Opacity_;

			public IObservableProperty<bool> Locked => Locked_;

			public IObservableProperty<bool> AspectRatioLocked => AspectRatioLocked_;

			public IComplexObservableProperty<IPath> Path => Path_;

			public IComplexObservableProperty<IFill> Fill => Fill_;

			public IComplexObservableProperty<IStroke> Stroke => Stroke_;

			public IComplexObservableProperty<IShadow> Shadow => Shadow_;

			public IComplexObservableProperty<IFeather> Feather => Feather_;

			public IComplexObservableProperty<IText> Text => Text_;

			public IObservableProperty<IElement.Types.FlipMode> FlipMode => FlipMode_;

			public IObservableProperty<bool> Hidden => Hidden_;

			public IComplexObservableProperty<IElement.Types.IMask> Mask => Mask_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Bounds_.UpdateMap(_map);
				Rotation_.UpdateMap(_map);
				Opacity_.UpdateMap(_map);
				Locked_.UpdateMap(_map);
				AspectRatioLocked_.UpdateMap(_map);
				Path_.UpdateMap(_map);
				Fill_.UpdateMap(_map);
				Stroke_.UpdateMap(_map);
				Shadow_.UpdateMap(_map);
				Feather_.UpdateMap(_map);
				Text_.UpdateMap(_map);
				FlipMode_.UpdateMap(_map);
				Hidden_.UpdateMap(_map);
				Mask_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Bounds_.UpdateMapOnInternalMapUpdate(_map);
				Rotation_.UpdateMapOnInternalMapUpdate(_map);
				Opacity_.UpdateMapOnInternalMapUpdate(_map);
				Locked_.UpdateMapOnInternalMapUpdate(_map);
				AspectRatioLocked_.UpdateMapOnInternalMapUpdate(_map);
				Path_.UpdateMapOnInternalMapUpdate(_map);
				Fill_.UpdateMapOnInternalMapUpdate(_map);
				Stroke_.UpdateMapOnInternalMapUpdate(_map);
				Shadow_.UpdateMapOnInternalMapUpdate(_map);
				Feather_.UpdateMapOnInternalMapUpdate(_map);
				Text_.UpdateMapOnInternalMapUpdate(_map);
				FlipMode_.UpdateMapOnInternalMapUpdate(_map);
				Hidden_.UpdateMapOnInternalMapUpdate(_map);
				Mask_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Element()
				: this(new LoroMap())
			{
			}

			public Element(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Bounds_ = new AtomicObservableProperty<Rect>("bounds__3", LoroMap, RectExtension.Deserialize, RectExtension.Serialize);
				Rotation_ = new DoubleObservableProperty("rotation__4", LoroMap);
				Opacity_ = new DoubleObservableProperty("opacity__5", LoroMap);
				Locked_ = new BoolObservableProperty("locked__6", LoroMap);
				AspectRatioLocked_ = new BoolObservableProperty("aspect_ratio_locked__7", LoroMap);
				Path_ = new ComplexObservableProperty<IPath>("path__8", LoroMap, new EntityFactory());
				Fill_ = new ComplexObservableProperty<IFill>("fill__9", LoroMap, new EntityFactory());
				Stroke_ = new ComplexObservableProperty<IStroke>("stroke__10", LoroMap, new EntityFactory());
				Shadow_ = new ComplexObservableProperty<IShadow>("shadow__11", LoroMap, new EntityFactory());
				Feather_ = new ComplexObservableProperty<IFeather>("feather__12", LoroMap, new EntityFactory());
				Text_ = new ComplexObservableProperty<IText>("text__13", LoroMap, new EntityFactory());
				FlipMode_ = new EnumObservableProperty<IElement.Types.FlipMode>("flipMode__15", LoroMap);
				Hidden_ = new BoolObservableProperty("hidden__16", LoroMap);
				Mask_ = new UnionObservableProperty<IElement.Types.IMask>("Mask__union", LoroMap, new IElement.Types.MaskFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Bounds_.WhenChangeHappens, Rotation_.WhenChangeHappens, Opacity_.WhenChangeHappens, Locked_.WhenChangeHappens, AspectRatioLocked_.WhenChangeHappens, Path_.WhenChangeHappens, Fill_.WhenChangeHappens, Stroke_.WhenChangeHappens, Shadow_.WhenChangeHappens, Feather_.WhenChangeHappens, Text_.WhenChangeHappens, FlipMode_.WhenChangeHappens, Hidden_.WhenChangeHappens, Mask_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				Name_.Dispose();
				Bounds_.Dispose();
				Rotation_.Dispose();
				Opacity_.Dispose();
				Locked_.Dispose();
				AspectRatioLocked_.Dispose();
				Path_.Dispose();
				Fill_.Dispose();
				Stroke_.Dispose();
				Shadow_.Dispose();
				Feather_.Dispose();
				Text_.Dispose();
				FlipMode_.Dispose();
				Hidden_.Dispose();
				Mask_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Bounds_.OnDiff(path, diff);
				Rotation_.OnDiff(path, diff);
				Opacity_.OnDiff(path, diff);
				Locked_.OnDiff(path, diff);
				AspectRatioLocked_.OnDiff(path, diff);
				Path_.OnDiff(path, diff);
				Fill_.OnDiff(path, diff);
				Stroke_.OnDiff(path, diff);
				Shadow_.OnDiff(path, diff);
				Feather_.OnDiff(path, diff);
				Text_.OnDiff(path, diff);
				FlipMode_.OnDiff(path, diff);
				Hidden_.OnDiff(path, diff);
				Mask_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IFeather : IEntity, IDisposable
		{
			public class Types
			{
				public enum Style
				{
					Inside,
					Center,
					Outside
				}
			}

			IObservableProperty<Types.Style> Style { get; }

			IObservableProperty<double> Radius { get; }

			IObservableProperty<bool> Enable { get; }
		}

		internal sealed class Feather : IFeather, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private EnumObservableProperty<IFeather.Types.Style> Style_;

			private DoubleObservableProperty Radius_;

			private BoolObservableProperty Enable_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<IFeather.Types.Style> Style => Style_;

			public IObservableProperty<double> Radius => Radius_;

			public IObservableProperty<bool> Enable => Enable_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Style_.UpdateMap(_map);
				Radius_.UpdateMap(_map);
				Enable_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Style_.UpdateMapOnInternalMapUpdate(_map);
				Radius_.UpdateMapOnInternalMapUpdate(_map);
				Enable_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Feather()
				: this(new LoroMap())
			{
			}

			public Feather(LoroMap values)
			{
				_map = values;
				Style_ = new EnumObservableProperty<IFeather.Types.Style>("style__1", LoroMap);
				Radius_ = new DoubleObservableProperty("radius__2", LoroMap);
				Enable_ = new BoolObservableProperty("enable__3", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Style_.WhenChangeHappens, Radius_.WhenChangeHappens, Enable_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Style_.Dispose();
				Radius_.Dispose();
				Enable_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Style_.OnDiff(path, diff);
				Radius_.OnDiff(path, diff);
				Enable_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IFill : IEntity, IDisposable
		{
			public class Types
			{
				public interface IFillType : IEntity, IDisposable
				{
					public interface IColor : IFillType, IEntity, IDisposable, IObservableProperty<Pro.Entity.Color>
					{
					}

					public interface IGradient : IFillType, IEntity, IDisposable, IObservableProperty<IGraphics.Types.IGradient>
					{
					}

					public interface IMedia : IFillType, IEntity, IDisposable, IObservableProperty<Pro.Entity.IMedia>
					{
					}

					public interface IBackgroundEffect : IFillType, IEntity, IDisposable, IObservableProperty<IGraphics.Types.IBackgroundEffect>
					{
					}

					internal class Color : IColor, IFillType, IEntity, IDisposable, IObservableProperty<Pro.Entity.Color>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private CompositeDisposable _linkedDisposables = new CompositeDisposable();

						private AtomicObservableProperty<Pro.Entity.Color> _Color_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Color_.WhenChangeHappens;

						public IObservable<Pro.Entity.Color> WhenValueChanges => _Color_.WhenValueChanges;

						public Pro.Entity.Color Value => _Color_.Value;

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
							loroMap.Insert("__tag", "color__1".ToLoroValueLike());
							return loroMap;
						}

						public Color()
							: this(InitializeMap())
						{
						}

						public Color(LoroMap values)
						{
							_map = values;
							_Color_ = new AtomicObservableProperty<Pro.Entity.Color>("color__1", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
						}

						public void Dispose()
						{
							_Color_.Dispose();
							LoroMap.Dispose();
							_linkedDisposables.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Color_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_linkedDisposables.Add(disposable);
						}

						public void Set(Pro.Entity.Color value)
						{
							_Color_.Set(value);
						}
					}

					internal class Gradient : IGradient, IFillType, IEntity, IDisposable, IObservableProperty<IGraphics.Types.IGradient>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IGraphics.Types.IGradient> _Gradient_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Gradient_.WhenChangeHappens;

						public IObservable<IGraphics.Types.IGradient> WhenValueChanges => _Gradient_.WhenValueChanges;

						public IGraphics.Types.IGradient Value => _Gradient_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Gradient_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Gradient_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "gradient__2".ToLoroValueLike());
							return loroMap;
						}

						public Gradient()
							: this(InitializeMap())
						{
						}

						public Gradient(LoroMap values)
						{
							_map = values;
							_Gradient_ = new ComplexObservableProperty<IGraphics.Types.IGradient>("gradient__2", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Gradient_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Gradient_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Gradient_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IGraphics.Types.IGradient value)
						{
							_Gradient_.Set(value);
						}
					}

					internal class Media : IMedia, IFillType, IEntity, IDisposable, IObservableProperty<Pro.Entity.IMedia>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<Pro.Entity.IMedia> _Media_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _Media_.WhenChangeHappens;

						public IObservable<Pro.Entity.IMedia> WhenValueChanges => _Media_.WhenValueChanges;

						public Pro.Entity.IMedia Value => _Media_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_Media_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_Media_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "media__3".ToLoroValueLike());
							return loroMap;
						}

						public Media()
							: this(InitializeMap())
						{
						}

						public Media(LoroMap values)
						{
							_map = values;
							_Media_ = new ComplexObservableProperty<Pro.Entity.IMedia>("media__3", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_Media_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_Media_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_Media_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(Pro.Entity.IMedia value)
						{
							_Media_.Set(value);
						}
					}

					internal class BackgroundEffect : IBackgroundEffect, IFillType, IEntity, IDisposable, IObservableProperty<IGraphics.Types.IBackgroundEffect>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IGraphics.Types.IBackgroundEffect> _BackgroundEffect_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _BackgroundEffect_.WhenChangeHappens;

						public IObservable<IGraphics.Types.IBackgroundEffect> WhenValueChanges => _BackgroundEffect_.WhenValueChanges;

						public IGraphics.Types.IBackgroundEffect Value => _BackgroundEffect_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_BackgroundEffect_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_BackgroundEffect_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "backgroundEffect__5".ToLoroValueLike());
							return loroMap;
						}

						public BackgroundEffect()
							: this(InitializeMap())
						{
						}

						public BackgroundEffect(LoroMap values)
						{
							_map = values;
							_BackgroundEffect_ = new ComplexObservableProperty<IGraphics.Types.IBackgroundEffect>("backgroundEffect__5", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_BackgroundEffect_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_BackgroundEffect_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_BackgroundEffect_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IGraphics.Types.IBackgroundEffect value)
						{
							_BackgroundEffect_.Set(value);
						}
					}
				}

				internal class FillTypeFactory : IUnionValueFactory<IFillType>
				{
					public string SelectionKey => "__tag";

					public IFillType? CreateInstance(LoroMap map)
					{
						return map.Get("__tag").ToStringValue() switch
						{
							"color__1" => new IFillType.Color(map), 
							"gradient__2" => new IFillType.Gradient(map), 
							"media__3" => new IFillType.Media(map), 
							"backgroundEffect__5" => new IFillType.BackgroundEffect(map), 
							_ => null, 
						};
					}

					public IFillType CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "color__1".ToLoroValueLike());
						return new IFillType.Color(map);
					}
				}
			}

			IObservableProperty<bool> Enable { get; }

			IComplexObservableProperty<Types.IFillType> FillType { get; }
		}

		internal sealed class Fill : IFill, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private BoolObservableProperty Enable_;

			private UnionObservableProperty<IFill.Types.IFillType> FillType_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<bool> Enable => Enable_;

			public IComplexObservableProperty<IFill.Types.IFillType> FillType => FillType_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Enable_.UpdateMap(_map);
				FillType_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Enable_.UpdateMapOnInternalMapUpdate(_map);
				FillType_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Fill()
				: this(new LoroMap())
			{
			}

			public Fill(LoroMap values)
			{
				_map = values;
				Enable_ = new BoolObservableProperty("enable__4", LoroMap);
				FillType_ = new UnionObservableProperty<IFill.Types.IFillType>("FillType__union", LoroMap, new IFill.Types.FillTypeFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Enable_.WhenChangeHappens.Merge(FillType_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Enable_.Dispose();
				FillType_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Enable_.OnDiff(path, diff);
				FillType_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IGradient : IEntity, IDisposable
		{
			public class Types
			{
				public interface IColorStop : IEntity, IDisposable
				{
					IObservableProperty<Color> Color { get; }

					IObservableProperty<double> Position { get; }

					IObservableProperty<double> BlendPoint { get; }
				}

				internal sealed class ColorStop : IColorStop, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private AtomicObservableProperty<Color> Color_;

					private DoubleObservableProperty Position_;

					private DoubleObservableProperty BlendPoint_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<Color> Color => Color_;

					public IObservableProperty<double> Position => Position_;

					public IObservableProperty<double> BlendPoint => BlendPoint_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Color_.UpdateMap(_map);
						Position_.UpdateMap(_map);
						BlendPoint_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Color_.UpdateMapOnInternalMapUpdate(_map);
						Position_.UpdateMapOnInternalMapUpdate(_map);
						BlendPoint_.UpdateMapOnInternalMapUpdate(_map);
					}

					public ColorStop()
						: this(new LoroMap())
					{
					}

					public ColorStop(LoroMap values)
					{
						_map = values;
						Color_ = new AtomicObservableProperty<Color>("color__1", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
						Position_ = new DoubleObservableProperty("position__2", LoroMap);
						BlendPoint_ = new DoubleObservableProperty("blend_point__3", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Color_.WhenChangeHappens, Position_.WhenChangeHappens, BlendPoint_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Color_.Dispose();
						Position_.Dispose();
						BlendPoint_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Color_.OnDiff(path, diff);
						Position_.OnDiff(path, diff);
						BlendPoint_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public enum Type
				{
					Linear,
					Radial,
					Angle
				}
			}

			IObservableProperty<Types.Type> Type { get; }

			IObservableProperty<double> Angle { get; }

			IObservableProperty<double> Length { get; }

			IComplexCollection<Types.IColorStop> Stops { get; }
		}

		internal sealed class Gradient : IGradient, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private EnumObservableProperty<IGradient.Types.Type> Type_;

			private DoubleObservableProperty Angle_;

			private DoubleObservableProperty Length_;

			private MapCollection<IGradient.Types.IColorStop> Stops_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<IGradient.Types.Type> Type => Type_;

			public IObservableProperty<double> Angle => Angle_;

			public IObservableProperty<double> Length => Length_;

			public IComplexCollection<IGradient.Types.IColorStop> Stops => Stops_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Type_.UpdateMap(_map);
				Angle_.UpdateMap(_map);
				Length_.UpdateMap(_map);
				Stops_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Type_.UpdateMapOnInternalMapUpdate(_map);
				Angle_.UpdateMapOnInternalMapUpdate(_map);
				Length_.UpdateMapOnInternalMapUpdate(_map);
				Stops_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Gradient()
				: this(new LoroMap())
			{
			}

			public Gradient(LoroMap values)
			{
				_map = values;
				Type_ = new EnumObservableProperty<IGradient.Types.Type>("type__1", LoroMap);
				Angle_ = new DoubleObservableProperty("angle__2", LoroMap);
				Length_ = new DoubleObservableProperty("length__3", LoroMap);
				Stops_ = new MapCollection<IGradient.Types.IColorStop>(LoroMap, "stops__4", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Type_.WhenChangeHappens, Angle_.WhenChangeHappens, Length_.WhenChangeHappens, Stops_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Type_.Dispose();
				Angle_.Dispose();
				Length_.Dispose();
				Stops_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Type_.OnDiff(path, diff);
				Angle_.OnDiff(path, diff);
				Length_.OnDiff(path, diff);
				Stops_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IPath : IEntity, IDisposable
		{
			public class Types
			{
				public interface IBezierPoint : IEntity, IDisposable
				{
					IObservableProperty<Point> Point { get; }

					IObservableProperty<Point> Q0 { get; }

					IObservableProperty<Point> Q1 { get; }

					IObservableProperty<bool> Curved { get; }
				}

				internal sealed class BezierPoint : IBezierPoint, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private AtomicObservableProperty<Point> Point_;

					private AtomicObservableProperty<Point> Q0_;

					private AtomicObservableProperty<Point> Q1_;

					private BoolObservableProperty Curved_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<Point> Point => Point_;

					public IObservableProperty<Point> Q0 => Q0_;

					public IObservableProperty<Point> Q1 => Q1_;

					public IObservableProperty<bool> Curved => Curved_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Point_.UpdateMap(_map);
						Q0_.UpdateMap(_map);
						Q1_.UpdateMap(_map);
						Curved_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Point_.UpdateMapOnInternalMapUpdate(_map);
						Q0_.UpdateMapOnInternalMapUpdate(_map);
						Q1_.UpdateMapOnInternalMapUpdate(_map);
						Curved_.UpdateMapOnInternalMapUpdate(_map);
					}

					public BezierPoint()
						: this(new LoroMap())
					{
					}

					public BezierPoint(LoroMap values)
					{
						_map = values;
						Point_ = new AtomicObservableProperty<Point>("point__1", LoroMap, PointExtension.Deserialize, PointExtension.Serialize);
						Q0_ = new AtomicObservableProperty<Point>("q0__2", LoroMap, PointExtension.Deserialize, PointExtension.Serialize);
						Q1_ = new AtomicObservableProperty<Point>("q1__3", LoroMap, PointExtension.Deserialize, PointExtension.Serialize);
						Curved_ = new BoolObservableProperty("curved__4", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Point_.WhenChangeHappens, Q0_.WhenChangeHappens, Q1_.WhenChangeHappens, Curved_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Point_.Dispose();
						Q0_.Dispose();
						Q1_.Dispose();
						Curved_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Point_.OnDiff(path, diff);
						Q0_.OnDiff(path, diff);
						Q1_.OnDiff(path, diff);
						Curved_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public record Shape(Types.Type Type, Types.AdditionalData AdditionalData)
				{
					public class Types
					{
						public record Arrow(Point Corner)
						{
							public virtual bool Equals(Arrow? other)
							{
								if ((object)other != null)
								{
									return Corner == other.Corner;
								}
								return false;
							}

							public override int GetHashCode()
							{
								HashCode hashCode = default(HashCode);
								hashCode.Add(Corner);
								return hashCode.ToHashCode();
							}
						}

						internal static class ArrowExtension
						{
							internal static Arrow Deserialize(Dictionary<string, LoroValue> map)
							{
								return new Arrow(PointExtension.Deserialize(map.GetMap("corner__1")));
							}

							internal static Arrow CreateDefault()
							{
								return new Arrow(PointExtension.CreateDefault());
							}

							public static LoroValue Serialize(Arrow instance)
							{
								LoroMap loroMap = new LoroMap();
								loroMap.Insert("corner__1", PointExtension.Serialize(instance.Corner).AsValueLike());
								return loroMap.GetDeepValue();
							}
						}

						public record Polygon(uint NumberSides)
						{
							public virtual bool Equals(Polygon? other)
							{
								if ((object)other != null)
								{
									return NumberSides == other.NumberSides;
								}
								return false;
							}

							public override int GetHashCode()
							{
								HashCode hashCode = default(HashCode);
								hashCode.Add(NumberSides);
								return hashCode.ToHashCode();
							}
						}

						internal static class PolygonExtension
						{
							internal static Polygon Deserialize(Dictionary<string, LoroValue> map)
							{
								return new Polygon(map.GetUint("number_sides__1"));
							}

							internal static Polygon CreateDefault()
							{
								return new Polygon(0u);
							}

							public static LoroValue Serialize(Polygon instance)
							{
								LoroMap loroMap = new LoroMap();
								loroMap.Insert("number_sides__1", instance.NumberSides.ToLoroValueLike());
								return loroMap.GetDeepValue();
							}
						}

						public record RoundedRectangle(double Roundness)
						{
							public virtual bool Equals(RoundedRectangle? other)
							{
								if ((object)other != null)
								{
									return Roundness == other.Roundness;
								}
								return false;
							}

							public override int GetHashCode()
							{
								HashCode hashCode = default(HashCode);
								hashCode.Add(Roundness);
								return hashCode.ToHashCode();
							}
						}

						internal static class RoundedRectangleExtension
						{
							internal static RoundedRectangle Deserialize(Dictionary<string, LoroValue> map)
							{
								return new RoundedRectangle(map.GetDouble("roundness__1"));
							}

							internal static RoundedRectangle CreateDefault()
							{
								return new RoundedRectangle(0.0);
							}

							public static LoroValue Serialize(RoundedRectangle instance)
							{
								LoroMap loroMap = new LoroMap();
								loroMap.Insert("roundness__1", instance.Roundness.ToLoroValueLike());
								return loroMap.GetDeepValue();
							}
						}

						public record Star(double InnerRadius, uint NumberPoints)
						{
							public virtual bool Equals(Star? other)
							{
								if ((object)other != null && InnerRadius == other.InnerRadius)
								{
									return NumberPoints == other.NumberPoints;
								}
								return false;
							}

							public override int GetHashCode()
							{
								HashCode hashCode = default(HashCode);
								hashCode.Add(InnerRadius);
								hashCode.Add(NumberPoints);
								return hashCode.ToHashCode();
							}
						}

						internal static class StarExtension
						{
							internal static Star Deserialize(Dictionary<string, LoroValue> map)
							{
								return new Star(map.GetDouble("inner_radius__1"), map.GetUint("number_points__2"));
							}

							internal static Star CreateDefault()
							{
								return new Star(0.0, 0u);
							}

							public static LoroValue Serialize(Star instance)
							{
								LoroMap loroMap = new LoroMap();
								loroMap.Insert("inner_radius__1", instance.InnerRadius.ToLoroValueLike());
								loroMap.Insert("number_points__2", instance.NumberPoints.ToLoroValueLike());
								return loroMap.GetDeepValue();
							}
						}

						public enum Type
						{
							Unknown,
							Rectangle,
							Ellipse,
							IsoscelesTriangle,
							RightTriangle,
							Rhombus,
							Star,
							Polygon,
							Custom,
							RightArrow,
							DoubleArrow,
							RoundedRectangle
						}

						public abstract record AdditionalData
						{
							public record RoundedRectangle(Types.RoundedRectangle _RoundedRectangle) : AdditionalData()
							{
								public virtual bool Equals(RoundedRectangle? other)
								{
									if ((object)other != null)
									{
										return _RoundedRectangle == other._RoundedRectangle;
									}
									return false;
								}

								public override int GetHashCode()
								{
									HashCode hashCode = default(HashCode);
									hashCode.Add(_RoundedRectangle);
									return hashCode.ToHashCode();
								}

								internal override LoroValue Serialize()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("rounded_rectangle__2", RoundedRectangleExtension.Serialize(_RoundedRectangle).AsValueLike());
									loroMap.Insert("__tag", "rounded_rectangle__2".ToLoroValueLike());
									return loroMap.GetDeepValue();
								}
							}

							public record Polygon(Types.Polygon _Polygon) : AdditionalData()
							{
								public virtual bool Equals(Polygon? other)
								{
									if ((object)other != null)
									{
										return _Polygon == other._Polygon;
									}
									return false;
								}

								public override int GetHashCode()
								{
									HashCode hashCode = default(HashCode);
									hashCode.Add(_Polygon);
									return hashCode.ToHashCode();
								}

								internal override LoroValue Serialize()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("polygon__3", PolygonExtension.Serialize(_Polygon).AsValueLike());
									loroMap.Insert("__tag", "polygon__3".ToLoroValueLike());
									return loroMap.GetDeepValue();
								}
							}

							public record Star(Types.Star _Star) : AdditionalData()
							{
								public virtual bool Equals(Star? other)
								{
									if ((object)other != null)
									{
										return _Star == other._Star;
									}
									return false;
								}

								public override int GetHashCode()
								{
									HashCode hashCode = default(HashCode);
									hashCode.Add(_Star);
									return hashCode.ToHashCode();
								}

								internal override LoroValue Serialize()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("star__4", StarExtension.Serialize(_Star).AsValueLike());
									loroMap.Insert("__tag", "star__4".ToLoroValueLike());
									return loroMap.GetDeepValue();
								}
							}

							public record Arrow(Types.Arrow _Arrow) : AdditionalData()
							{
								public virtual bool Equals(Arrow? other)
								{
									if ((object)other != null)
									{
										return _Arrow == other._Arrow;
									}
									return false;
								}

								public override int GetHashCode()
								{
									HashCode hashCode = default(HashCode);
									hashCode.Add(_Arrow);
									return hashCode.ToHashCode();
								}

								internal override LoroValue Serialize()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("arrow__5", ArrowExtension.Serialize(_Arrow).AsValueLike());
									loroMap.Insert("__tag", "arrow__5".ToLoroValueLike());
									return loroMap.GetDeepValue();
								}
							}

							internal abstract LoroValue Serialize();
						}

						internal static class AdditionalDataExtension
						{
							internal static AdditionalData Deserialize(Dictionary<string, LoroValue> map)
							{
								return map.GetString("__tag") switch
								{
									"polygon__3" => new AdditionalData.Polygon(PolygonExtension.Deserialize(map.GetMap("polygon__3"))), 
									"star__4" => new AdditionalData.Star(StarExtension.Deserialize(map.GetMap("star__4"))), 
									"arrow__5" => new AdditionalData.Arrow(ArrowExtension.Deserialize(map.GetMap("arrow__5"))), 
									_ => new AdditionalData.RoundedRectangle(RoundedRectangleExtension.Deserialize(map.GetMap("rounded_rectangle__2"))), 
								};
							}

							internal static AdditionalData CreateDefault()
							{
								return new AdditionalData.RoundedRectangle(RoundedRectangleExtension.CreateDefault());
							}

							public static LoroValue Serialize(AdditionalData instance)
							{
								return instance.Serialize();
							}
						}
					}

					public virtual bool Equals(Shape? other)
					{
						if ((object)other != null && Type == other.Type)
						{
							return AdditionalData == other.AdditionalData;
						}
						return false;
					}

					public override int GetHashCode()
					{
						HashCode hashCode = default(HashCode);
						hashCode.Add(Type);
						hashCode.Add(AdditionalData);
						return hashCode.ToHashCode();
					}
				}

				internal static class ShapeExtension
				{
					internal static Shape Deserialize(Dictionary<string, LoroValue> map)
					{
						return new Shape(map.GetEnum<Shape.Types.Type>("type__1"), Shape.Types.AdditionalDataExtension.Deserialize(map.GetMap("AdditionalData__union")));
					}

					internal static Shape CreateDefault()
					{
						return new Shape(Shape.Types.Type.Unknown, Shape.Types.AdditionalDataExtension.CreateDefault());
					}

					public static LoroValue Serialize(Shape instance)
					{
						LoroMap loroMap = new LoroMap();
						loroMap.Insert("type__1", instance.Type.ToLoroValueLike());
						loroMap.Insert("AdditionalData__union", Shape.Types.AdditionalDataExtension.Serialize(instance.AdditionalData).AsValueLike());
						return loroMap.GetDeepValue();
					}
				}
			}

			IObservableProperty<bool> Closed { get; }

			IComplexCollection<Types.IBezierPoint> Points { get; }

			IObservableProperty<Types.Shape> Shape { get; }
		}

		internal sealed class Path : IPath, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private BoolObservableProperty Closed_;

			private MapCollection<IPath.Types.IBezierPoint> Points_;

			private AtomicObservableProperty<IPath.Types.Shape> Shape_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<bool> Closed => Closed_;

			public IComplexCollection<IPath.Types.IBezierPoint> Points => Points_;

			public IObservableProperty<IPath.Types.Shape> Shape => Shape_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Closed_.UpdateMap(_map);
				Points_.UpdateMap(_map);
				Shape_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Closed_.UpdateMapOnInternalMapUpdate(_map);
				Points_.UpdateMapOnInternalMapUpdate(_map);
				Shape_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Path()
				: this(new LoroMap())
			{
			}

			public Path(LoroMap values)
			{
				_map = values;
				Closed_ = new BoolObservableProperty("closed__1", LoroMap);
				Points_ = new MapCollection<IPath.Types.IBezierPoint>(LoroMap, "points__2", new EntityFactory());
				Shape_ = new AtomicObservableProperty<IPath.Types.Shape>("shape__3", LoroMap, IPath.Types.ShapeExtension.Deserialize, IPath.Types.ShapeExtension.Serialize);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Closed_.WhenChangeHappens, Points_.WhenChangeHappens, Shape_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Closed_.Dispose();
				Points_.Dispose();
				Shape_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Closed_.OnDiff(path, diff);
				Points_.OnDiff(path, diff);
				Shape_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public record Point(double X, double Y)
		{
			public virtual bool Equals(Point? other)
			{
				if ((object)other != null && X == other.X)
				{
					return Y == other.Y;
				}
				return false;
			}

			public override int GetHashCode()
			{
				HashCode hashCode = default(HashCode);
				hashCode.Add(X);
				hashCode.Add(Y);
				return hashCode.ToHashCode();
			}
		}

		internal static class PointExtension
		{
			internal static Point Deserialize(Dictionary<string, LoroValue> map)
			{
				return new Point(map.GetDouble("x__1"), map.GetDouble("y__2"));
			}

			internal static Point CreateDefault()
			{
				return new Point(0.0, 0.0);
			}

			public static LoroValue Serialize(Point instance)
			{
				LoroMap loroMap = new LoroMap();
				loroMap.Insert("x__1", instance.X.ToLoroValueLike());
				loroMap.Insert("y__2", instance.Y.ToLoroValueLike());
				return loroMap.GetDeepValue();
			}
		}

		public record Rect(Point Origin, Size Size)
		{
			public virtual bool Equals(Rect? other)
			{
				if ((object)other != null && Origin == other.Origin)
				{
					return Size == other.Size;
				}
				return false;
			}

			public override int GetHashCode()
			{
				HashCode hashCode = default(HashCode);
				hashCode.Add(Origin);
				hashCode.Add(Size);
				return hashCode.ToHashCode();
			}
		}

		internal static class RectExtension
		{
			internal static Rect Deserialize(Dictionary<string, LoroValue> map)
			{
				return new Rect(PointExtension.Deserialize(map.GetMap("origin__1")), SizeExtension.Deserialize(map.GetMap("size__2")));
			}

			internal static Rect CreateDefault()
			{
				return new Rect(PointExtension.CreateDefault(), SizeExtension.CreateDefault());
			}

			public static LoroValue Serialize(Rect instance)
			{
				LoroMap loroMap = new LoroMap();
				loroMap.Insert("origin__1", PointExtension.Serialize(instance.Origin).AsValueLike());
				loroMap.Insert("size__2", SizeExtension.Serialize(instance.Size).AsValueLike());
				return loroMap.GetDeepValue();
			}
		}

		public interface IShadow : IEntity, IDisposable
		{
			public class Types
			{
				public enum Style
				{
					Drop
				}
			}

			IObservableProperty<Types.Style> Style { get; }

			IObservableProperty<double> Angle { get; }

			IObservableProperty<double> Offset { get; }

			IObservableProperty<double> Radius { get; }

			IObservableProperty<Color> Color { get; }

			IObservableProperty<double> Opacity { get; }

			IObservableProperty<bool> Enable { get; }
		}

		internal sealed class Shadow : IShadow, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private EnumObservableProperty<IShadow.Types.Style> Style_;

			private DoubleObservableProperty Angle_;

			private DoubleObservableProperty Offset_;

			private DoubleObservableProperty Radius_;

			private AtomicObservableProperty<Color> Color_;

			private DoubleObservableProperty Opacity_;

			private BoolObservableProperty Enable_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<IShadow.Types.Style> Style => Style_;

			public IObservableProperty<double> Angle => Angle_;

			public IObservableProperty<double> Offset => Offset_;

			public IObservableProperty<double> Radius => Radius_;

			public IObservableProperty<Color> Color => Color_;

			public IObservableProperty<double> Opacity => Opacity_;

			public IObservableProperty<bool> Enable => Enable_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Style_.UpdateMap(_map);
				Angle_.UpdateMap(_map);
				Offset_.UpdateMap(_map);
				Radius_.UpdateMap(_map);
				Color_.UpdateMap(_map);
				Opacity_.UpdateMap(_map);
				Enable_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Style_.UpdateMapOnInternalMapUpdate(_map);
				Angle_.UpdateMapOnInternalMapUpdate(_map);
				Offset_.UpdateMapOnInternalMapUpdate(_map);
				Radius_.UpdateMapOnInternalMapUpdate(_map);
				Color_.UpdateMapOnInternalMapUpdate(_map);
				Opacity_.UpdateMapOnInternalMapUpdate(_map);
				Enable_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Shadow()
				: this(new LoroMap())
			{
			}

			public Shadow(LoroMap values)
			{
				_map = values;
				Style_ = new EnumObservableProperty<IShadow.Types.Style>("style__1", LoroMap);
				Angle_ = new DoubleObservableProperty("angle__2", LoroMap);
				Offset_ = new DoubleObservableProperty("offset__3", LoroMap);
				Radius_ = new DoubleObservableProperty("radius__4", LoroMap);
				Color_ = new AtomicObservableProperty<Color>("color__5", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
				Opacity_ = new DoubleObservableProperty("opacity__6", LoroMap);
				Enable_ = new BoolObservableProperty("enable__7", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Style_.WhenChangeHappens, Angle_.WhenChangeHappens, Offset_.WhenChangeHappens, Radius_.WhenChangeHappens, Color_.WhenChangeHappens, Opacity_.WhenChangeHappens, Enable_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Style_.Dispose();
				Angle_.Dispose();
				Offset_.Dispose();
				Radius_.Dispose();
				Color_.Dispose();
				Opacity_.Dispose();
				Enable_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Style_.OnDiff(path, diff);
				Angle_.OnDiff(path, diff);
				Offset_.OnDiff(path, diff);
				Radius_.OnDiff(path, diff);
				Color_.OnDiff(path, diff);
				Opacity_.OnDiff(path, diff);
				Enable_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public record Size(double Width, double Height)
		{
			public virtual bool Equals(Size? other)
			{
				if ((object)other != null && Width == other.Width)
				{
					return Height == other.Height;
				}
				return false;
			}

			public override int GetHashCode()
			{
				HashCode hashCode = default(HashCode);
				hashCode.Add(Width);
				hashCode.Add(Height);
				return hashCode.ToHashCode();
			}
		}

		internal static class SizeExtension
		{
			internal static Size Deserialize(Dictionary<string, LoroValue> map)
			{
				return new Size(map.GetDouble("width__1"), map.GetDouble("height__2"));
			}

			internal static Size CreateDefault()
			{
				return new Size(0.0, 0.0);
			}

			public static LoroValue Serialize(Size instance)
			{
				LoroMap loroMap = new LoroMap();
				loroMap.Insert("width__1", instance.Width.ToLoroValueLike());
				loroMap.Insert("height__2", instance.Height.ToLoroValueLike());
				return loroMap.GetDeepValue();
			}
		}

		public interface IStroke : IEntity, IDisposable
		{
			public class Types
			{
				public enum Style
				{
					SolidLine,
					SquareDash,
					ShortDash,
					LongDash
				}
			}

			IObservableProperty<Types.Style> Style { get; }

			IObservableProperty<double> Width { get; }

			IObservableProperty<Color> Color { get; }

			IObservableProperty<bool> Enable { get; }
		}

		internal sealed class Stroke : IStroke, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private EnumObservableProperty<IStroke.Types.Style> Style_;

			private DoubleObservableProperty Width_;

			private AtomicObservableProperty<Color> Color_;

			private BoolObservableProperty Enable_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<IStroke.Types.Style> Style => Style_;

			public IObservableProperty<double> Width => Width_;

			public IObservableProperty<Color> Color => Color_;

			public IObservableProperty<bool> Enable => Enable_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Style_.UpdateMap(_map);
				Width_.UpdateMap(_map);
				Color_.UpdateMap(_map);
				Enable_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Style_.UpdateMapOnInternalMapUpdate(_map);
				Width_.UpdateMapOnInternalMapUpdate(_map);
				Color_.UpdateMapOnInternalMapUpdate(_map);
				Enable_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Stroke()
				: this(new LoroMap())
			{
			}

			public Stroke(LoroMap values)
			{
				_map = values;
				Style_ = new EnumObservableProperty<IStroke.Types.Style>("style__1", LoroMap);
				Width_ = new DoubleObservableProperty("width__2", LoroMap);
				Color_ = new AtomicObservableProperty<Color>("color__3", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
				Enable_ = new BoolObservableProperty("enable__5", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Style_.WhenChangeHappens, Width_.WhenChangeHappens, Color_.WhenChangeHappens, Enable_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Style_.Dispose();
				Width_.Dispose();
				Color_.Dispose();
				Enable_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Style_.OnDiff(path, diff);
				Width_.OnDiff(path, diff);
				Color_.OnDiff(path, diff);
				Enable_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IText : IEntity, IDisposable
		{
			public class Types
			{
				public interface IAlternateText : IEntity, IDisposable
				{
					public class Types
					{
						public interface IContentType : IEntity, IDisposable
						{
							public interface IPlainText : IContentType, IEntity, IDisposable, IObservableProperty<string>
							{
							}

							internal class PlainText : IPlainText, IContentType, IEntity, IDisposable, IObservableProperty<string>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private CompositeDisposable _linkedDisposables = new CompositeDisposable();

								private StringObservableProperty _PlainText_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _PlainText_.WhenChangeHappens;

								public IObservable<string> WhenValueChanges => _PlainText_.WhenValueChanges;

								public string Value => _PlainText_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_PlainText_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_PlainText_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "plain_text__2".ToLoroValueLike());
									return loroMap;
								}

								public PlainText()
									: this(InitializeMap())
								{
								}

								public PlainText(LoroMap values)
								{
									_map = values;
									_PlainText_ = new StringObservableProperty("plain_text__2", LoroMap);
								}

								public void Dispose()
								{
									_PlainText_.Dispose();
									LoroMap.Dispose();
									_linkedDisposables.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_PlainText_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_linkedDisposables.Add(disposable);
								}

								public void Set(string value)
								{
									_PlainText_.Set(value);
								}
							}
						}

						internal class ContentTypeFactory : IUnionValueFactory<IContentType>
						{
							public string SelectionKey => "__tag";

							public IContentType? CreateInstance(LoroMap map)
							{
								if (map.Get("__tag").ToStringValue() == "plain_text__2")
								{
									return new IContentType.PlainText(map);
								}
								return null;
							}

							public IContentType CreateDefault(LoroMap map)
							{
								map.Insert("__tag", "plain_text__2".ToLoroValueLike());
								return new IContentType.PlainText(map);
							}
						}
					}

					IObservableProperty<string> Key { get; }

					IComplexObservableProperty<Types.IContentType> ContentType { get; }
				}

				internal sealed class AlternateText : IAlternateText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private StringObservableProperty Key_;

					private UnionObservableProperty<IAlternateText.Types.IContentType> ContentType_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<string> Key => Key_;

					public IComplexObservableProperty<IAlternateText.Types.IContentType> ContentType => ContentType_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Key_.UpdateMap(_map);
						ContentType_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Key_.UpdateMapOnInternalMapUpdate(_map);
						ContentType_.UpdateMapOnInternalMapUpdate(_map);
					}

					public AlternateText()
						: this(new LoroMap())
					{
					}

					public AlternateText(LoroMap values)
					{
						_map = values;
						Key_ = new StringObservableProperty("key__1", LoroMap);
						ContentType_ = new UnionObservableProperty<IAlternateText.Types.IContentType>("ContentType__union", LoroMap, new IAlternateText.Types.ContentTypeFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Key_.WhenChangeHappens.Merge(ContentType_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Key_.Dispose();
						ContentType_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Key_.OnDiff(path, diff);
						ContentType_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IAttributes : IEntity, IDisposable
				{
					public class Types
					{
						public interface ICustomAttribute : IEntity, IDisposable
						{
							public class Types
							{
								public interface IAttribute : IEntity, IDisposable
								{
									public interface ICapitalization : IAttribute, IEntity, IDisposable, IObservableProperty<IAttributes.Types.Capitalization>
									{
									}

									public interface IOriginalFontSize : IAttribute, IEntity, IDisposable, IObservableProperty<double>
									{
									}

									public interface IFontScaleFactor : IAttribute, IEntity, IDisposable, IObservableProperty<double>
									{
									}

									public interface ITextGradientFill : IAttribute, IEntity, IDisposable, IObservableProperty<IGradientFill>
									{
									}

									public interface IShouldPreserveForegroundColor : IAttribute, IEntity, IDisposable, IObservableProperty<bool>
									{
									}

									public interface IChord : IAttribute, IEntity, IDisposable, IObservableProperty<string>
									{
									}

									public interface ICutOutFill : IAttribute, IEntity, IDisposable, IObservableProperty<IText.Types.ICutOutFill>
									{
									}

									public interface IMediaFill : IAttribute, IEntity, IDisposable, IObservableProperty<IText.Types.IMediaFill>
									{
									}

									public interface IBackgroundEffect : IAttribute, IEntity, IDisposable, IObservableProperty<IGraphics.Types.IBackgroundEffect>
									{
									}

									public interface IOriginalFont : IAttribute, IEntity, IDisposable, IObservableProperty<Font>
									{
									}

									internal class Capitalization : ICapitalization, IAttribute, IEntity, IDisposable, IObservableProperty<IAttributes.Types.Capitalization>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private CompositeDisposable _linkedDisposables = new CompositeDisposable();

										private EnumObservableProperty<IAttributes.Types.Capitalization> _Capitalization_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _Capitalization_.WhenChangeHappens;

										public IObservable<IAttributes.Types.Capitalization> WhenValueChanges => _Capitalization_.WhenValueChanges;

										public IAttributes.Types.Capitalization Value => _Capitalization_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_Capitalization_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_Capitalization_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "capitalization__2".ToLoroValueLike());
											return loroMap;
										}

										public Capitalization()
											: this(InitializeMap())
										{
										}

										public Capitalization(LoroMap values)
										{
											_map = values;
											_Capitalization_ = new EnumObservableProperty<IAttributes.Types.Capitalization>("capitalization__2", LoroMap);
										}

										public void Dispose()
										{
											_Capitalization_.Dispose();
											LoroMap.Dispose();
											_linkedDisposables.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_Capitalization_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_linkedDisposables.Add(disposable);
										}

										public void Set(IAttributes.Types.Capitalization value)
										{
											_Capitalization_.Set(value);
										}
									}

									internal class OriginalFontSize : IOriginalFontSize, IAttribute, IEntity, IDisposable, IObservableProperty<double>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private CompositeDisposable _linkedDisposables = new CompositeDisposable();

										private DoubleObservableProperty _OriginalFontSize_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _OriginalFontSize_.WhenChangeHappens;

										public IObservable<double> WhenValueChanges => _OriginalFontSize_.WhenValueChanges;

										public double Value => _OriginalFontSize_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_OriginalFontSize_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_OriginalFontSize_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "original_font_size__3".ToLoroValueLike());
											return loroMap;
										}

										public OriginalFontSize()
											: this(InitializeMap())
										{
										}

										public OriginalFontSize(LoroMap values)
										{
											_map = values;
											_OriginalFontSize_ = new DoubleObservableProperty("original_font_size__3", LoroMap);
										}

										public void Dispose()
										{
											_OriginalFontSize_.Dispose();
											LoroMap.Dispose();
											_linkedDisposables.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_OriginalFontSize_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_linkedDisposables.Add(disposable);
										}

										public void Set(double value)
										{
											_OriginalFontSize_.Set(value);
										}
									}

									internal class FontScaleFactor : IFontScaleFactor, IAttribute, IEntity, IDisposable, IObservableProperty<double>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private CompositeDisposable _linkedDisposables = new CompositeDisposable();

										private DoubleObservableProperty _FontScaleFactor_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _FontScaleFactor_.WhenChangeHappens;

										public IObservable<double> WhenValueChanges => _FontScaleFactor_.WhenValueChanges;

										public double Value => _FontScaleFactor_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_FontScaleFactor_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_FontScaleFactor_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "font_scale_factor__4".ToLoroValueLike());
											return loroMap;
										}

										public FontScaleFactor()
											: this(InitializeMap())
										{
										}

										public FontScaleFactor(LoroMap values)
										{
											_map = values;
											_FontScaleFactor_ = new DoubleObservableProperty("font_scale_factor__4", LoroMap);
										}

										public void Dispose()
										{
											_FontScaleFactor_.Dispose();
											LoroMap.Dispose();
											_linkedDisposables.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_FontScaleFactor_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_linkedDisposables.Add(disposable);
										}

										public void Set(double value)
										{
											_FontScaleFactor_.Set(value);
										}
									}

									internal class TextGradientFill : ITextGradientFill, IAttribute, IEntity, IDisposable, IObservableProperty<IGradientFill>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private ComplexObservableProperty<IGradientFill> _TextGradientFill_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _TextGradientFill_.WhenChangeHappens;

										public IObservable<IGradientFill> WhenValueChanges => _TextGradientFill_.WhenValueChanges;

										public IGradientFill Value => _TextGradientFill_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_TextGradientFill_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_TextGradientFill_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "text_gradient_fill__5".ToLoroValueLike());
											return loroMap;
										}

										public TextGradientFill()
											: this(InitializeMap())
										{
										}

										public TextGradientFill(LoroMap values)
										{
											_map = values;
											_TextGradientFill_ = new ComplexObservableProperty<IGradientFill>("text_gradient_fill__5", LoroMap, new EntityFactory());
										}

										public void Dispose()
										{
											_TextGradientFill_.Dispose();
											LoroMap.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_TextGradientFill_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_TextGradientFill_.Value.RegisterLinkedDisposable(disposable);
										}

										public void Set(IGradientFill value)
										{
											_TextGradientFill_.Set(value);
										}
									}

									internal class ShouldPreserveForegroundColor : IShouldPreserveForegroundColor, IAttribute, IEntity, IDisposable, IObservableProperty<bool>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private CompositeDisposable _linkedDisposables = new CompositeDisposable();

										private BoolObservableProperty _ShouldPreserveForegroundColor_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _ShouldPreserveForegroundColor_.WhenChangeHappens;

										public IObservable<bool> WhenValueChanges => _ShouldPreserveForegroundColor_.WhenValueChanges;

										public bool Value => _ShouldPreserveForegroundColor_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_ShouldPreserveForegroundColor_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_ShouldPreserveForegroundColor_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "should_preserve_foreground_color__6".ToLoroValueLike());
											return loroMap;
										}

										public ShouldPreserveForegroundColor()
											: this(InitializeMap())
										{
										}

										public ShouldPreserveForegroundColor(LoroMap values)
										{
											_map = values;
											_ShouldPreserveForegroundColor_ = new BoolObservableProperty("should_preserve_foreground_color__6", LoroMap);
										}

										public void Dispose()
										{
											_ShouldPreserveForegroundColor_.Dispose();
											LoroMap.Dispose();
											_linkedDisposables.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_ShouldPreserveForegroundColor_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_linkedDisposables.Add(disposable);
										}

										public void Set(bool value)
										{
											_ShouldPreserveForegroundColor_.Set(value);
										}
									}

									internal class Chord : IChord, IAttribute, IEntity, IDisposable, IObservableProperty<string>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private CompositeDisposable _linkedDisposables = new CompositeDisposable();

										private StringObservableProperty _Chord_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _Chord_.WhenChangeHappens;

										public IObservable<string> WhenValueChanges => _Chord_.WhenValueChanges;

										public string Value => _Chord_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_Chord_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_Chord_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "chord__7".ToLoroValueLike());
											return loroMap;
										}

										public Chord()
											: this(InitializeMap())
										{
										}

										public Chord(LoroMap values)
										{
											_map = values;
											_Chord_ = new StringObservableProperty("chord__7", LoroMap);
										}

										public void Dispose()
										{
											_Chord_.Dispose();
											LoroMap.Dispose();
											_linkedDisposables.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_Chord_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_linkedDisposables.Add(disposable);
										}

										public void Set(string value)
										{
											_Chord_.Set(value);
										}
									}

									internal class CutOutFill : ICutOutFill, IAttribute, IEntity, IDisposable, IObservableProperty<IText.Types.ICutOutFill>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private ComplexObservableProperty<IText.Types.ICutOutFill> _CutOutFill_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _CutOutFill_.WhenChangeHappens;

										public IObservable<IText.Types.ICutOutFill> WhenValueChanges => _CutOutFill_.WhenValueChanges;

										public IText.Types.ICutOutFill Value => _CutOutFill_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_CutOutFill_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_CutOutFill_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "cut_out_fill__8".ToLoroValueLike());
											return loroMap;
										}

										public CutOutFill()
											: this(InitializeMap())
										{
										}

										public CutOutFill(LoroMap values)
										{
											_map = values;
											_CutOutFill_ = new ComplexObservableProperty<IText.Types.ICutOutFill>("cut_out_fill__8", LoroMap, new EntityFactory());
										}

										public void Dispose()
										{
											_CutOutFill_.Dispose();
											LoroMap.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_CutOutFill_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_CutOutFill_.Value.RegisterLinkedDisposable(disposable);
										}

										public void Set(IText.Types.ICutOutFill value)
										{
											_CutOutFill_.Set(value);
										}
									}

									internal class MediaFill : IMediaFill, IAttribute, IEntity, IDisposable, IObservableProperty<IText.Types.IMediaFill>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private ComplexObservableProperty<IText.Types.IMediaFill> _MediaFill_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _MediaFill_.WhenChangeHappens;

										public IObservable<IText.Types.IMediaFill> WhenValueChanges => _MediaFill_.WhenValueChanges;

										public IText.Types.IMediaFill Value => _MediaFill_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_MediaFill_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_MediaFill_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "media_fill__9".ToLoroValueLike());
											return loroMap;
										}

										public MediaFill()
											: this(InitializeMap())
										{
										}

										public MediaFill(LoroMap values)
										{
											_map = values;
											_MediaFill_ = new ComplexObservableProperty<IText.Types.IMediaFill>("media_fill__9", LoroMap, new EntityFactory());
										}

										public void Dispose()
										{
											_MediaFill_.Dispose();
											LoroMap.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_MediaFill_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_MediaFill_.Value.RegisterLinkedDisposable(disposable);
										}

										public void Set(IText.Types.IMediaFill value)
										{
											_MediaFill_.Set(value);
										}
									}

									internal class BackgroundEffect : IBackgroundEffect, IAttribute, IEntity, IDisposable, IObservableProperty<IGraphics.Types.IBackgroundEffect>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private ComplexObservableProperty<IGraphics.Types.IBackgroundEffect> _BackgroundEffect_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _BackgroundEffect_.WhenChangeHappens;

										public IObservable<IGraphics.Types.IBackgroundEffect> WhenValueChanges => _BackgroundEffect_.WhenValueChanges;

										public IGraphics.Types.IBackgroundEffect Value => _BackgroundEffect_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_BackgroundEffect_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_BackgroundEffect_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "background_effect__10".ToLoroValueLike());
											return loroMap;
										}

										public BackgroundEffect()
											: this(InitializeMap())
										{
										}

										public BackgroundEffect(LoroMap values)
										{
											_map = values;
											_BackgroundEffect_ = new ComplexObservableProperty<IGraphics.Types.IBackgroundEffect>("background_effect__10", LoroMap, new EntityFactory());
										}

										public void Dispose()
										{
											_BackgroundEffect_.Dispose();
											LoroMap.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_BackgroundEffect_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_BackgroundEffect_.Value.RegisterLinkedDisposable(disposable);
										}

										public void Set(IGraphics.Types.IBackgroundEffect value)
										{
											_BackgroundEffect_.Set(value);
										}
									}

									internal class OriginalFont : IOriginalFont, IAttribute, IEntity, IDisposable, IObservableProperty<Font>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
									{
										private LoroMap _map;

										private CompositeDisposable _linkedDisposables = new CompositeDisposable();

										private AtomicObservableProperty<Font> _OriginalFont_;

										public LoroMap LoroMap => _map;

										public IObservable<Unit> WhenChangeHappens => _OriginalFont_.WhenChangeHappens;

										public IObservable<Font> WhenValueChanges => _OriginalFont_.WhenValueChanges;

										public Font Value => _OriginalFont_.Value;

										public void UpdateMap(LoroMap value)
										{
											_map = value;
											_OriginalFont_.UpdateMap(_map);
										}

										public void UpdateMapOnInternalMapUpdate(LoroMap value)
										{
											_map = value;
											_OriginalFont_.UpdateMapOnInternalMapUpdate(_map);
										}

										private static LoroMap InitializeMap()
										{
											LoroMap loroMap = new LoroMap();
											loroMap.Insert("__tag", "original_font__12".ToLoroValueLike());
											return loroMap;
										}

										public OriginalFont()
											: this(InitializeMap())
										{
										}

										public OriginalFont(LoroMap values)
										{
											_map = values;
											_OriginalFont_ = new AtomicObservableProperty<Font>("original_font__12", LoroMap, FontExtension.Deserialize, FontExtension.Serialize);
										}

										public void Dispose()
										{
											_OriginalFont_.Dispose();
											LoroMap.Dispose();
											_linkedDisposables.Dispose();
										}

										public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
										{
											_OriginalFont_.OnDiff(path, diff);
										}

										public void RegisterLinkedDisposable(IDisposable disposable)
										{
											_linkedDisposables.Add(disposable);
										}

										public void Set(Font value)
										{
											_OriginalFont_.Set(value);
										}
									}
								}

								internal class AttributeFactory : IUnionValueFactory<IAttribute>
								{
									public string SelectionKey => "__tag";

									public IAttribute? CreateInstance(LoroMap map)
									{
										return map.Get("__tag").ToStringValue() switch
										{
											"capitalization__2" => new IAttribute.Capitalization(map), 
											"original_font_size__3" => new IAttribute.OriginalFontSize(map), 
											"font_scale_factor__4" => new IAttribute.FontScaleFactor(map), 
											"text_gradient_fill__5" => new IAttribute.TextGradientFill(map), 
											"should_preserve_foreground_color__6" => new IAttribute.ShouldPreserveForegroundColor(map), 
											"chord__7" => new IAttribute.Chord(map), 
											"cut_out_fill__8" => new IAttribute.CutOutFill(map), 
											"media_fill__9" => new IAttribute.MediaFill(map), 
											"background_effect__10" => new IAttribute.BackgroundEffect(map), 
											"original_font__12" => new IAttribute.OriginalFont(map), 
											_ => null, 
										};
									}

									public IAttribute CreateDefault(LoroMap map)
									{
										map.Insert("__tag", "capitalization__2".ToLoroValueLike());
										return new IAttribute.Capitalization(map);
									}
								}
							}

							IObservableProperty<IntRange> Range { get; }

							IComplexObservableProperty<Types.IAttribute> Attribute { get; }
						}

						internal sealed class CustomAttribute : ICustomAttribute, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private AtomicObservableProperty<IntRange> Range_;

							private UnionObservableProperty<ICustomAttribute.Types.IAttribute> Attribute_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<IntRange> Range => Range_;

							public IComplexObservableProperty<ICustomAttribute.Types.IAttribute> Attribute => Attribute_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								Range_.UpdateMap(_map);
								Attribute_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								Range_.UpdateMapOnInternalMapUpdate(_map);
								Attribute_.UpdateMapOnInternalMapUpdate(_map);
							}

							public CustomAttribute()
								: this(new LoroMap())
							{
							}

							public CustomAttribute(LoroMap values)
							{
								_map = values;
								Range_ = new AtomicObservableProperty<IntRange>("range__1", LoroMap, IntRangeExtension.Deserialize, IntRangeExtension.Serialize);
								Attribute_ = new UnionObservableProperty<ICustomAttribute.Types.IAttribute>("Attribute__union", LoroMap, new ICustomAttribute.Types.AttributeFactory());
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Range_.WhenChangeHappens.Merge(Attribute_.WhenChangeHappens);
							}

							public void Dispose()
							{
								Range_.Dispose();
								Attribute_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								Range_.OnDiff(path, diff);
								Attribute_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IParagraph : IEntity, IDisposable
						{
							public class Types
							{
								public interface ITabStop : IEntity, IDisposable
								{
									IObservableProperty<double> Location { get; }

									IObservableProperty<Alignment> Alignment { get; }
								}

								internal sealed class TabStop : ITabStop, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
								{
									private LoroMap _map;

									private CompositeDisposable _linkedDisposables;

									private DoubleObservableProperty Location_;

									private EnumObservableProperty<Alignment> Alignment_;

									public LoroMap LoroMap => _map;

									public IObservable<Unit> WhenChangeHappens { get; }

									public IObservableProperty<double> Location => Location_;

									public IObservableProperty<Alignment> Alignment => Alignment_;

									public void UpdateMap(LoroMap value)
									{
										_map = value;
										Location_.UpdateMap(_map);
										Alignment_.UpdateMap(_map);
									}

									public void UpdateMapOnInternalMapUpdate(LoroMap value)
									{
										_map = value;
										Location_.UpdateMapOnInternalMapUpdate(_map);
										Alignment_.UpdateMapOnInternalMapUpdate(_map);
									}

									public TabStop()
										: this(new LoroMap())
									{
									}

									public TabStop(LoroMap values)
									{
										_map = values;
										Location_ = new DoubleObservableProperty("location__1", LoroMap);
										Alignment_ = new EnumObservableProperty<Alignment>("alignment__2", LoroMap);
										_linkedDisposables = new CompositeDisposable();
										WhenChangeHappens = Location_.WhenChangeHappens.Merge(Alignment_.WhenChangeHappens);
									}

									public void Dispose()
									{
										Location_.Dispose();
										Alignment_.Dispose();
										LoroMap.Dispose();
										_linkedDisposables.Dispose();
									}

									public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
									{
										Location_.OnDiff(path, diff);
										Alignment_.OnDiff(path, diff);
									}

									public void RegisterLinkedDisposable(IDisposable disposable)
									{
										_linkedDisposables.Add(disposable);
									}
								}

								public interface ITextList : IEntity, IDisposable
								{
									public class Types
									{
										public enum NumberType
										{
											Box,
											Check,
											Circle,
											Diamond,
											Disc,
											Hyphen,
											Square,
											Decimal,
											LowercaseAlpha,
											UppercaseAlpha,
											LowercaseRoman,
											UppercaseRoman
										}
									}

									IObservableProperty<bool> IsEnabled { get; }

									IObservableProperty<Types.NumberType> NumberType { get; }

									IObservableProperty<string> Prefix { get; }

									IObservableProperty<string> Postfix { get; }

									IObservableProperty<int> StartingNumber { get; }
								}

								internal sealed class TextList : ITextList, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
								{
									private LoroMap _map;

									private CompositeDisposable _linkedDisposables;

									private BoolObservableProperty IsEnabled_;

									private EnumObservableProperty<ITextList.Types.NumberType> NumberType_;

									private StringObservableProperty Prefix_;

									private StringObservableProperty Postfix_;

									private IntObservableProperty StartingNumber_;

									public LoroMap LoroMap => _map;

									public IObservable<Unit> WhenChangeHappens { get; }

									public IObservableProperty<bool> IsEnabled => IsEnabled_;

									public IObservableProperty<ITextList.Types.NumberType> NumberType => NumberType_;

									public IObservableProperty<string> Prefix => Prefix_;

									public IObservableProperty<string> Postfix => Postfix_;

									public IObservableProperty<int> StartingNumber => StartingNumber_;

									public void UpdateMap(LoroMap value)
									{
										_map = value;
										IsEnabled_.UpdateMap(_map);
										NumberType_.UpdateMap(_map);
										Prefix_.UpdateMap(_map);
										Postfix_.UpdateMap(_map);
										StartingNumber_.UpdateMap(_map);
									}

									public void UpdateMapOnInternalMapUpdate(LoroMap value)
									{
										_map = value;
										IsEnabled_.UpdateMapOnInternalMapUpdate(_map);
										NumberType_.UpdateMapOnInternalMapUpdate(_map);
										Prefix_.UpdateMapOnInternalMapUpdate(_map);
										Postfix_.UpdateMapOnInternalMapUpdate(_map);
										StartingNumber_.UpdateMapOnInternalMapUpdate(_map);
									}

									public TextList()
										: this(new LoroMap())
									{
									}

									public TextList(LoroMap values)
									{
										_map = values;
										IsEnabled_ = new BoolObservableProperty("is_enabled__1", LoroMap);
										NumberType_ = new EnumObservableProperty<ITextList.Types.NumberType>("number_type__2", LoroMap);
										Prefix_ = new StringObservableProperty("prefix__3", LoroMap);
										Postfix_ = new StringObservableProperty("postfix__4", LoroMap);
										StartingNumber_ = new IntObservableProperty("starting_number__5", LoroMap);
										_linkedDisposables = new CompositeDisposable();
										WhenChangeHappens = Observable.Merge<Unit>(IsEnabled_.WhenChangeHappens, NumberType_.WhenChangeHappens, Prefix_.WhenChangeHappens, Postfix_.WhenChangeHappens, StartingNumber_.WhenChangeHappens);
									}

									public void Dispose()
									{
										IsEnabled_.Dispose();
										NumberType_.Dispose();
										Prefix_.Dispose();
										Postfix_.Dispose();
										StartingNumber_.Dispose();
										LoroMap.Dispose();
										_linkedDisposables.Dispose();
									}

									public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
									{
										IsEnabled_.OnDiff(path, diff);
										NumberType_.OnDiff(path, diff);
										Prefix_.OnDiff(path, diff);
										Postfix_.OnDiff(path, diff);
										StartingNumber_.OnDiff(path, diff);
									}

									public void RegisterLinkedDisposable(IDisposable disposable)
									{
										_linkedDisposables.Add(disposable);
									}
								}
							}

							IObservableProperty<Alignment> Alignment { get; }

							IObservableProperty<double> FirstLineHeadIndent { get; }

							IObservableProperty<double> HeadIndent { get; }

							IObservableProperty<double> TailIndent { get; }

							IObservableProperty<double> LineHeightMultiple { get; }

							IObservableProperty<double> MaximumLineHeight { get; }

							IObservableProperty<double> MinimumLineHeight { get; }

							IObservableProperty<double> LineSpacing { get; }

							IObservableProperty<double> ParagraphSpacing { get; }

							IObservableProperty<double> ParagraphSpacingBefore { get; }

							IComplexCollection<Types.ITabStop> TabStops { get; }

							IObservableProperty<double> DefaultTabInterval { get; }

							IComplexObservableProperty<Types.ITextList?> TextList { get; }

							IComplexCollection<Types.ITextList> TextLists { get; }
						}

						internal sealed class Paragraph : IParagraph, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<Alignment> Alignment_;

							private DoubleObservableProperty FirstLineHeadIndent_;

							private DoubleObservableProperty HeadIndent_;

							private DoubleObservableProperty TailIndent_;

							private DoubleObservableProperty LineHeightMultiple_;

							private DoubleObservableProperty MaximumLineHeight_;

							private DoubleObservableProperty MinimumLineHeight_;

							private DoubleObservableProperty LineSpacing_;

							private DoubleObservableProperty ParagraphSpacing_;

							private DoubleObservableProperty ParagraphSpacingBefore_;

							private MapCollection<IParagraph.Types.ITabStop> TabStops_;

							private DoubleObservableProperty DefaultTabInterval_;

							private OptionalComplexObservableProperty<IParagraph.Types.ITextList> TextList_;

							private MapCollection<IParagraph.Types.ITextList> TextLists_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<Alignment> Alignment => Alignment_;

							public IObservableProperty<double> FirstLineHeadIndent => FirstLineHeadIndent_;

							public IObservableProperty<double> HeadIndent => HeadIndent_;

							public IObservableProperty<double> TailIndent => TailIndent_;

							public IObservableProperty<double> LineHeightMultiple => LineHeightMultiple_;

							public IObservableProperty<double> MaximumLineHeight => MaximumLineHeight_;

							public IObservableProperty<double> MinimumLineHeight => MinimumLineHeight_;

							public IObservableProperty<double> LineSpacing => LineSpacing_;

							public IObservableProperty<double> ParagraphSpacing => ParagraphSpacing_;

							public IObservableProperty<double> ParagraphSpacingBefore => ParagraphSpacingBefore_;

							public IComplexCollection<IParagraph.Types.ITabStop> TabStops => TabStops_;

							public IObservableProperty<double> DefaultTabInterval => DefaultTabInterval_;

							public IComplexObservableProperty<IParagraph.Types.ITextList?> TextList => TextList_;

							public IComplexCollection<IParagraph.Types.ITextList> TextLists => TextLists_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								Alignment_.UpdateMap(_map);
								FirstLineHeadIndent_.UpdateMap(_map);
								HeadIndent_.UpdateMap(_map);
								TailIndent_.UpdateMap(_map);
								LineHeightMultiple_.UpdateMap(_map);
								MaximumLineHeight_.UpdateMap(_map);
								MinimumLineHeight_.UpdateMap(_map);
								LineSpacing_.UpdateMap(_map);
								ParagraphSpacing_.UpdateMap(_map);
								ParagraphSpacingBefore_.UpdateMap(_map);
								TabStops_.UpdateMap(_map);
								DefaultTabInterval_.UpdateMap(_map);
								TextList_.UpdateMap(_map);
								TextLists_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								Alignment_.UpdateMapOnInternalMapUpdate(_map);
								FirstLineHeadIndent_.UpdateMapOnInternalMapUpdate(_map);
								HeadIndent_.UpdateMapOnInternalMapUpdate(_map);
								TailIndent_.UpdateMapOnInternalMapUpdate(_map);
								LineHeightMultiple_.UpdateMapOnInternalMapUpdate(_map);
								MaximumLineHeight_.UpdateMapOnInternalMapUpdate(_map);
								MinimumLineHeight_.UpdateMapOnInternalMapUpdate(_map);
								LineSpacing_.UpdateMapOnInternalMapUpdate(_map);
								ParagraphSpacing_.UpdateMapOnInternalMapUpdate(_map);
								ParagraphSpacingBefore_.UpdateMapOnInternalMapUpdate(_map);
								TabStops_.UpdateMapOnInternalMapUpdate(_map);
								DefaultTabInterval_.UpdateMapOnInternalMapUpdate(_map);
								TextList_.UpdateMapOnInternalMapUpdate(_map);
								TextLists_.UpdateMapOnInternalMapUpdate(_map);
							}

							public Paragraph()
								: this(new LoroMap())
							{
							}

							public Paragraph(LoroMap values)
							{
								_map = values;
								Alignment_ = new EnumObservableProperty<Alignment>("alignment__1", LoroMap);
								FirstLineHeadIndent_ = new DoubleObservableProperty("first_line_head_indent__2", LoroMap);
								HeadIndent_ = new DoubleObservableProperty("head_indent__3", LoroMap);
								TailIndent_ = new DoubleObservableProperty("tail_indent__4", LoroMap);
								LineHeightMultiple_ = new DoubleObservableProperty("line_height_multiple__5", LoroMap);
								MaximumLineHeight_ = new DoubleObservableProperty("maximum_line_height__6", LoroMap);
								MinimumLineHeight_ = new DoubleObservableProperty("minimum_line_height__7", LoroMap);
								LineSpacing_ = new DoubleObservableProperty("line_spacing__8", LoroMap);
								ParagraphSpacing_ = new DoubleObservableProperty("paragraph_spacing__9", LoroMap);
								ParagraphSpacingBefore_ = new DoubleObservableProperty("paragraph_spacing_before__10", LoroMap);
								TabStops_ = new MapCollection<IParagraph.Types.ITabStop>(LoroMap, "tab_stops__11", new EntityFactory());
								DefaultTabInterval_ = new DoubleObservableProperty("default_tab_interval__12", LoroMap);
								TextList_ = new OptionalComplexObservableProperty<IParagraph.Types.ITextList>("text_list__13", LoroMap, new EntityFactory());
								TextLists_ = new MapCollection<IParagraph.Types.ITextList>(LoroMap, "text_lists__14", new EntityFactory());
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(Alignment_.WhenChangeHappens, FirstLineHeadIndent_.WhenChangeHappens, HeadIndent_.WhenChangeHappens, TailIndent_.WhenChangeHappens, LineHeightMultiple_.WhenChangeHappens, MaximumLineHeight_.WhenChangeHappens, MinimumLineHeight_.WhenChangeHappens, LineSpacing_.WhenChangeHappens, ParagraphSpacing_.WhenChangeHappens, ParagraphSpacingBefore_.WhenChangeHappens, TabStops_.WhenChangeHappens, DefaultTabInterval_.WhenChangeHappens, TextList_.WhenChangeHappens, TextLists_.WhenChangeHappens);
							}

							public void Dispose()
							{
								Alignment_.Dispose();
								FirstLineHeadIndent_.Dispose();
								HeadIndent_.Dispose();
								TailIndent_.Dispose();
								LineHeightMultiple_.Dispose();
								MaximumLineHeight_.Dispose();
								MinimumLineHeight_.Dispose();
								LineSpacing_.Dispose();
								ParagraphSpacing_.Dispose();
								ParagraphSpacingBefore_.Dispose();
								TabStops_.Dispose();
								DefaultTabInterval_.Dispose();
								TextList_.Dispose();
								TextLists_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								Alignment_.OnDiff(path, diff);
								FirstLineHeadIndent_.OnDiff(path, diff);
								HeadIndent_.OnDiff(path, diff);
								TailIndent_.OnDiff(path, diff);
								LineHeightMultiple_.OnDiff(path, diff);
								MaximumLineHeight_.OnDiff(path, diff);
								MinimumLineHeight_.OnDiff(path, diff);
								LineSpacing_.OnDiff(path, diff);
								ParagraphSpacing_.OnDiff(path, diff);
								ParagraphSpacingBefore_.OnDiff(path, diff);
								TabStops_.OnDiff(path, diff);
								DefaultTabInterval_.OnDiff(path, diff);
								TextList_.OnDiff(path, diff);
								TextLists_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IUnderline : IEntity, IDisposable
						{
							public class Types
							{
								public enum Pattern
								{
									Solid,
									Dot,
									Dash,
									DashDot,
									DashDotDot
								}

								public enum Style
								{
									None,
									Single,
									Thick,
									Double
								}
							}

							IObservableProperty<Types.Style> Style { get; }

							IObservableProperty<Types.Pattern> Pattern { get; }

							IObservableProperty<bool> ByWord { get; }
						}

						internal sealed class Underline : IUnderline, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private EnumObservableProperty<IUnderline.Types.Style> Style_;

							private EnumObservableProperty<IUnderline.Types.Pattern> Pattern_;

							private BoolObservableProperty ByWord_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<IUnderline.Types.Style> Style => Style_;

							public IObservableProperty<IUnderline.Types.Pattern> Pattern => Pattern_;

							public IObservableProperty<bool> ByWord => ByWord_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								Style_.UpdateMap(_map);
								Pattern_.UpdateMap(_map);
								ByWord_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								Style_.UpdateMapOnInternalMapUpdate(_map);
								Pattern_.UpdateMapOnInternalMapUpdate(_map);
								ByWord_.UpdateMapOnInternalMapUpdate(_map);
							}

							public Underline()
								: this(new LoroMap())
							{
							}

							public Underline(LoroMap values)
							{
								_map = values;
								Style_ = new EnumObservableProperty<IUnderline.Types.Style>("style__1", LoroMap);
								Pattern_ = new EnumObservableProperty<IUnderline.Types.Pattern>("pattern__2", LoroMap);
								ByWord_ = new BoolObservableProperty("by_word__3", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(Style_.WhenChangeHappens, Pattern_.WhenChangeHappens, ByWord_.WhenChangeHappens);
							}

							public void Dispose()
							{
								Style_.Dispose();
								Pattern_.Dispose();
								ByWord_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								Style_.OnDiff(path, diff);
								Pattern_.OnDiff(path, diff);
								ByWord_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public enum Alignment
						{
							Left,
							Right,
							Center,
							Justified,
							Natural
						}

						public enum Capitalization
						{
							None,
							AllCaps,
							SmallCaps,
							TitleCase,
							StartCase
						}

						public enum LigatureStyle
						{
							Default,
							None
						}

						public interface IFill : IEntity, IDisposable
						{
							public interface ITextSolidFill : IFill, IEntity, IDisposable, IObservableProperty<Color>
							{
							}

							public interface ITextGradientFill : IFill, IEntity, IDisposable, IObservableProperty<IGradientFill>
							{
							}

							public interface ICutOutFill : IFill, IEntity, IDisposable, IObservableProperty<IText.Types.ICutOutFill>
							{
							}

							public interface IMediaFill : IFill, IEntity, IDisposable, IObservableProperty<IText.Types.IMediaFill>
							{
							}

							public interface IBackgroundEffect : IFill, IEntity, IDisposable, IObservableProperty<IGraphics.Types.IBackgroundEffect>
							{
							}

							internal class TextSolidFill : ITextSolidFill, IFill, IEntity, IDisposable, IObservableProperty<Color>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private CompositeDisposable _linkedDisposables = new CompositeDisposable();

								private AtomicObservableProperty<Color> _TextSolidFill_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _TextSolidFill_.WhenChangeHappens;

								public IObservable<Color> WhenValueChanges => _TextSolidFill_.WhenValueChanges;

								public Color Value => _TextSolidFill_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_TextSolidFill_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_TextSolidFill_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "text_solid_fill__3".ToLoroValueLike());
									return loroMap;
								}

								public TextSolidFill()
									: this(InitializeMap())
								{
								}

								public TextSolidFill(LoroMap values)
								{
									_map = values;
									_TextSolidFill_ = new AtomicObservableProperty<Color>("text_solid_fill__3", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
								}

								public void Dispose()
								{
									_TextSolidFill_.Dispose();
									LoroMap.Dispose();
									_linkedDisposables.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_TextSolidFill_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_linkedDisposables.Add(disposable);
								}

								public void Set(Color value)
								{
									_TextSolidFill_.Set(value);
								}
							}

							internal class TextGradientFill : ITextGradientFill, IFill, IEntity, IDisposable, IObservableProperty<IGradientFill>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<IGradientFill> _TextGradientFill_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _TextGradientFill_.WhenChangeHappens;

								public IObservable<IGradientFill> WhenValueChanges => _TextGradientFill_.WhenValueChanges;

								public IGradientFill Value => _TextGradientFill_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_TextGradientFill_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_TextGradientFill_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "text_gradient_fill__14".ToLoroValueLike());
									return loroMap;
								}

								public TextGradientFill()
									: this(InitializeMap())
								{
								}

								public TextGradientFill(LoroMap values)
								{
									_map = values;
									_TextGradientFill_ = new ComplexObservableProperty<IGradientFill>("text_gradient_fill__14", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_TextGradientFill_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_TextGradientFill_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_TextGradientFill_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(IGradientFill value)
								{
									_TextGradientFill_.Set(value);
								}
							}

							internal class CutOutFill : ICutOutFill, IFill, IEntity, IDisposable, IObservableProperty<IText.Types.ICutOutFill>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<IText.Types.ICutOutFill> _CutOutFill_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _CutOutFill_.WhenChangeHappens;

								public IObservable<IText.Types.ICutOutFill> WhenValueChanges => _CutOutFill_.WhenValueChanges;

								public IText.Types.ICutOutFill Value => _CutOutFill_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_CutOutFill_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_CutOutFill_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "cut_out_fill__16".ToLoroValueLike());
									return loroMap;
								}

								public CutOutFill()
									: this(InitializeMap())
								{
								}

								public CutOutFill(LoroMap values)
								{
									_map = values;
									_CutOutFill_ = new ComplexObservableProperty<IText.Types.ICutOutFill>("cut_out_fill__16", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_CutOutFill_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_CutOutFill_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_CutOutFill_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(IText.Types.ICutOutFill value)
								{
									_CutOutFill_.Set(value);
								}
							}

							internal class MediaFill : IMediaFill, IFill, IEntity, IDisposable, IObservableProperty<IText.Types.IMediaFill>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<IText.Types.IMediaFill> _MediaFill_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _MediaFill_.WhenChangeHappens;

								public IObservable<IText.Types.IMediaFill> WhenValueChanges => _MediaFill_.WhenValueChanges;

								public IText.Types.IMediaFill Value => _MediaFill_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_MediaFill_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_MediaFill_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "media_fill__17".ToLoroValueLike());
									return loroMap;
								}

								public MediaFill()
									: this(InitializeMap())
								{
								}

								public MediaFill(LoroMap values)
								{
									_map = values;
									_MediaFill_ = new ComplexObservableProperty<IText.Types.IMediaFill>("media_fill__17", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_MediaFill_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_MediaFill_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_MediaFill_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(IText.Types.IMediaFill value)
								{
									_MediaFill_.Set(value);
								}
							}

							internal class BackgroundEffect : IBackgroundEffect, IFill, IEntity, IDisposable, IObservableProperty<IGraphics.Types.IBackgroundEffect>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<IGraphics.Types.IBackgroundEffect> _BackgroundEffect_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _BackgroundEffect_.WhenChangeHappens;

								public IObservable<IGraphics.Types.IBackgroundEffect> WhenValueChanges => _BackgroundEffect_.WhenValueChanges;

								public IGraphics.Types.IBackgroundEffect Value => _BackgroundEffect_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_BackgroundEffect_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_BackgroundEffect_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "background_effect__18".ToLoroValueLike());
									return loroMap;
								}

								public BackgroundEffect()
									: this(InitializeMap())
								{
								}

								public BackgroundEffect(LoroMap values)
								{
									_map = values;
									_BackgroundEffect_ = new ComplexObservableProperty<IGraphics.Types.IBackgroundEffect>("background_effect__18", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_BackgroundEffect_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_BackgroundEffect_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_BackgroundEffect_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(IGraphics.Types.IBackgroundEffect value)
								{
									_BackgroundEffect_.Set(value);
								}
							}
						}

						internal class FillFactory : IUnionValueFactory<IFill>
						{
							public string SelectionKey => "__tag";

							public IFill? CreateInstance(LoroMap map)
							{
								return map.Get("__tag").ToStringValue() switch
								{
									"text_solid_fill__3" => new IFill.TextSolidFill(map), 
									"text_gradient_fill__14" => new IFill.TextGradientFill(map), 
									"cut_out_fill__16" => new IFill.CutOutFill(map), 
									"media_fill__17" => new IFill.MediaFill(map), 
									"background_effect__18" => new IFill.BackgroundEffect(map), 
									_ => null, 
								};
							}

							public IFill CreateDefault(LoroMap map)
							{
								map.Insert("__tag", "text_solid_fill__3".ToLoroValueLike());
								return new IFill.TextSolidFill(map);
							}
						}
					}

					IObservableProperty<Font?> Font { get; }

					IObservableProperty<Types.Capitalization> Capitalization { get; }

					IComplexObservableProperty<Types.IUnderline?> UnderlineStyle { get; }

					IObservableProperty<Color?> UnderlineColor { get; }

					IComplexObservableProperty<Types.IParagraph?> ParagraphStyle { get; }

					IObservableProperty<double> Kerning { get; }

					IObservableProperty<int> Superscript { get; }

					IComplexObservableProperty<Types.IUnderline?> StrikethroughStyle { get; }

					IObservableProperty<Color?> StrikethroughColor { get; }

					IObservableProperty<double> StrokeWidth { get; }

					IObservableProperty<Color?> StrokeColor { get; }

					IComplexCollection<Types.ICustomAttribute> CustomAttributes { get; }

					IObservableProperty<Color?> BackgroundColor { get; }

					IObservableProperty<Types.LigatureStyle> LigatureStyle { get; }

					IComplexObservableProperty<Types.IFill> Fill { get; }
				}

				internal sealed class Attributes : IAttributes, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private OptionalAtomicObservableProperty<Font> Font_;

					private EnumObservableProperty<IAttributes.Types.Capitalization> Capitalization_;

					private OptionalComplexObservableProperty<IAttributes.Types.IUnderline> UnderlineStyle_;

					private OptionalAtomicObservableProperty<Color> UnderlineColor_;

					private OptionalComplexObservableProperty<IAttributes.Types.IParagraph> ParagraphStyle_;

					private DoubleObservableProperty Kerning_;

					private IntObservableProperty Superscript_;

					private OptionalComplexObservableProperty<IAttributes.Types.IUnderline> StrikethroughStyle_;

					private OptionalAtomicObservableProperty<Color> StrikethroughColor_;

					private DoubleObservableProperty StrokeWidth_;

					private OptionalAtomicObservableProperty<Color> StrokeColor_;

					private MapCollection<IAttributes.Types.ICustomAttribute> CustomAttributes_;

					private OptionalAtomicObservableProperty<Color> BackgroundColor_;

					private EnumObservableProperty<IAttributes.Types.LigatureStyle> LigatureStyle_;

					private UnionObservableProperty<IAttributes.Types.IFill> Fill_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<Font?> Font => Font_;

					public IObservableProperty<IAttributes.Types.Capitalization> Capitalization => Capitalization_;

					public IComplexObservableProperty<IAttributes.Types.IUnderline?> UnderlineStyle => UnderlineStyle_;

					public IObservableProperty<Color?> UnderlineColor => UnderlineColor_;

					public IComplexObservableProperty<IAttributes.Types.IParagraph?> ParagraphStyle => ParagraphStyle_;

					public IObservableProperty<double> Kerning => Kerning_;

					public IObservableProperty<int> Superscript => Superscript_;

					public IComplexObservableProperty<IAttributes.Types.IUnderline?> StrikethroughStyle => StrikethroughStyle_;

					public IObservableProperty<Color?> StrikethroughColor => StrikethroughColor_;

					public IObservableProperty<double> StrokeWidth => StrokeWidth_;

					public IObservableProperty<Color?> StrokeColor => StrokeColor_;

					public IComplexCollection<IAttributes.Types.ICustomAttribute> CustomAttributes => CustomAttributes_;

					public IObservableProperty<Color?> BackgroundColor => BackgroundColor_;

					public IObservableProperty<IAttributes.Types.LigatureStyle> LigatureStyle => LigatureStyle_;

					public IComplexObservableProperty<IAttributes.Types.IFill> Fill => Fill_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Font_.UpdateMap(_map);
						Capitalization_.UpdateMap(_map);
						UnderlineStyle_.UpdateMap(_map);
						UnderlineColor_.UpdateMap(_map);
						ParagraphStyle_.UpdateMap(_map);
						Kerning_.UpdateMap(_map);
						Superscript_.UpdateMap(_map);
						StrikethroughStyle_.UpdateMap(_map);
						StrikethroughColor_.UpdateMap(_map);
						StrokeWidth_.UpdateMap(_map);
						StrokeColor_.UpdateMap(_map);
						CustomAttributes_.UpdateMap(_map);
						BackgroundColor_.UpdateMap(_map);
						LigatureStyle_.UpdateMap(_map);
						Fill_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Font_.UpdateMapOnInternalMapUpdate(_map);
						Capitalization_.UpdateMapOnInternalMapUpdate(_map);
						UnderlineStyle_.UpdateMapOnInternalMapUpdate(_map);
						UnderlineColor_.UpdateMapOnInternalMapUpdate(_map);
						ParagraphStyle_.UpdateMapOnInternalMapUpdate(_map);
						Kerning_.UpdateMapOnInternalMapUpdate(_map);
						Superscript_.UpdateMapOnInternalMapUpdate(_map);
						StrikethroughStyle_.UpdateMapOnInternalMapUpdate(_map);
						StrikethroughColor_.UpdateMapOnInternalMapUpdate(_map);
						StrokeWidth_.UpdateMapOnInternalMapUpdate(_map);
						StrokeColor_.UpdateMapOnInternalMapUpdate(_map);
						CustomAttributes_.UpdateMapOnInternalMapUpdate(_map);
						BackgroundColor_.UpdateMapOnInternalMapUpdate(_map);
						LigatureStyle_.UpdateMapOnInternalMapUpdate(_map);
						Fill_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Attributes()
						: this(new LoroMap())
					{
					}

					public Attributes(LoroMap values)
					{
						_map = values;
						Font_ = new OptionalAtomicObservableProperty<Font>("font__1", LoroMap, FontExtension.Deserialize, FontExtension.Serialize);
						Capitalization_ = new EnumObservableProperty<IAttributes.Types.Capitalization>("capitalization__2", LoroMap);
						UnderlineStyle_ = new OptionalComplexObservableProperty<IAttributes.Types.IUnderline>("underline_style__4", LoroMap, new EntityFactory());
						UnderlineColor_ = new OptionalAtomicObservableProperty<Color>("underline_color__5", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
						ParagraphStyle_ = new OptionalComplexObservableProperty<IAttributes.Types.IParagraph>("paragraph_style__6", LoroMap, new EntityFactory());
						Kerning_ = new DoubleObservableProperty("kerning__7", LoroMap);
						Superscript_ = new IntObservableProperty("superscript__8", LoroMap);
						StrikethroughStyle_ = new OptionalComplexObservableProperty<IAttributes.Types.IUnderline>("strikethrough_style__9", LoroMap, new EntityFactory());
						StrikethroughColor_ = new OptionalAtomicObservableProperty<Color>("strikethrough_color__10", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
						StrokeWidth_ = new DoubleObservableProperty("stroke_width__11", LoroMap);
						StrokeColor_ = new OptionalAtomicObservableProperty<Color>("stroke_color__12", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
						CustomAttributes_ = new MapCollection<IAttributes.Types.ICustomAttribute>(LoroMap, "custom_attributes__13", new EntityFactory());
						BackgroundColor_ = new OptionalAtomicObservableProperty<Color>("background_color__15", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
						LigatureStyle_ = new EnumObservableProperty<IAttributes.Types.LigatureStyle>("ligature_style__19", LoroMap);
						Fill_ = new UnionObservableProperty<IAttributes.Types.IFill>("fill__union", LoroMap, new IAttributes.Types.FillFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Font_.WhenChangeHappens, Capitalization_.WhenChangeHappens, UnderlineStyle_.WhenChangeHappens, UnderlineColor_.WhenChangeHappens, ParagraphStyle_.WhenChangeHappens, Kerning_.WhenChangeHappens, Superscript_.WhenChangeHappens, StrikethroughStyle_.WhenChangeHappens, StrikethroughColor_.WhenChangeHappens, StrokeWidth_.WhenChangeHappens, StrokeColor_.WhenChangeHappens, CustomAttributes_.WhenChangeHappens, BackgroundColor_.WhenChangeHappens, LigatureStyle_.WhenChangeHappens, Fill_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Font_.Dispose();
						Capitalization_.Dispose();
						UnderlineStyle_.Dispose();
						UnderlineColor_.Dispose();
						ParagraphStyle_.Dispose();
						Kerning_.Dispose();
						Superscript_.Dispose();
						StrikethroughStyle_.Dispose();
						StrikethroughColor_.Dispose();
						StrokeWidth_.Dispose();
						StrokeColor_.Dispose();
						CustomAttributes_.Dispose();
						BackgroundColor_.Dispose();
						LigatureStyle_.Dispose();
						Fill_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Font_.OnDiff(path, diff);
						Capitalization_.OnDiff(path, diff);
						UnderlineStyle_.OnDiff(path, diff);
						UnderlineColor_.OnDiff(path, diff);
						ParagraphStyle_.OnDiff(path, diff);
						Kerning_.OnDiff(path, diff);
						Superscript_.OnDiff(path, diff);
						StrikethroughStyle_.OnDiff(path, diff);
						StrikethroughColor_.OnDiff(path, diff);
						StrokeWidth_.OnDiff(path, diff);
						StrokeColor_.OnDiff(path, diff);
						CustomAttributes_.OnDiff(path, diff);
						BackgroundColor_.OnDiff(path, diff);
						LigatureStyle_.OnDiff(path, diff);
						Fill_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IChordPro : IEntity, IDisposable
				{
					public class Types
					{
						public enum Notation
						{
							Chords,
							Numbers,
							Numerals,
							DoReMi
						}
					}

					IObservableProperty<bool> Enabled { get; }

					IObservableProperty<Types.Notation> Notation { get; }

					IObservableProperty<Color> Color { get; }
				}

				internal sealed class ChordPro : IChordPro, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private BoolObservableProperty Enabled_;

					private EnumObservableProperty<IChordPro.Types.Notation> Notation_;

					private AtomicObservableProperty<Color> Color_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<bool> Enabled => Enabled_;

					public IObservableProperty<IChordPro.Types.Notation> Notation => Notation_;

					public IObservableProperty<Color> Color => Color_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Enabled_.UpdateMap(_map);
						Notation_.UpdateMap(_map);
						Color_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Enabled_.UpdateMapOnInternalMapUpdate(_map);
						Notation_.UpdateMapOnInternalMapUpdate(_map);
						Color_.UpdateMapOnInternalMapUpdate(_map);
					}

					public ChordPro()
						: this(new LoroMap())
					{
					}

					public ChordPro(LoroMap values)
					{
						_map = values;
						Enabled_ = new BoolObservableProperty("enabled__1", LoroMap);
						Notation_ = new EnumObservableProperty<IChordPro.Types.Notation>("notation__2", LoroMap);
						Color_ = new AtomicObservableProperty<Color>("color__3", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Enabled_.WhenChangeHappens, Notation_.WhenChangeHappens, Color_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Enabled_.Dispose();
						Notation_.Dispose();
						Color_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Enabled_.OnDiff(path, diff);
						Notation_.OnDiff(path, diff);
						Color_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ICutOutFill : IEntity, IDisposable
				{
				}

				internal sealed class CutOutFill : ICutOutFill, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

					public CutOutFill()
						: this(new LoroMap())
					{
					}

					public CutOutFill(LoroMap values)
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

				public interface IGradientFill : IEntity, IDisposable
				{
					IComplexObservableProperty<IGradient> Gradient { get; }

					IObservableProperty<bool> StretchToDocumentBounds { get; }
				}

				internal sealed class GradientFill : IGradientFill, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private ComplexObservableProperty<IGradient> Gradient_;

					private BoolObservableProperty StretchToDocumentBounds_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IComplexObservableProperty<IGradient> Gradient => Gradient_;

					public IObservableProperty<bool> StretchToDocumentBounds => StretchToDocumentBounds_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Gradient_.UpdateMap(_map);
						StretchToDocumentBounds_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Gradient_.UpdateMapOnInternalMapUpdate(_map);
						StretchToDocumentBounds_.UpdateMapOnInternalMapUpdate(_map);
					}

					public GradientFill()
						: this(new LoroMap())
					{
					}

					public GradientFill(LoroMap values)
					{
						_map = values;
						Gradient_ = new ComplexObservableProperty<IGradient>("gradient__1", LoroMap, new EntityFactory());
						StretchToDocumentBounds_ = new BoolObservableProperty("stretch_to_document_bounds__2", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Gradient_.WhenChangeHappens.Merge(StretchToDocumentBounds_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Gradient_.Dispose();
						StretchToDocumentBounds_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Gradient_.OnDiff(path, diff);
						StretchToDocumentBounds_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface ILineFillMask : IEntity, IDisposable
				{
					public class Types
					{
						public enum LineMaskStyle
						{
							FullWidth,
							LineWidth,
							MaxLineWidth
						}
					}

					IObservableProperty<bool> Enabled { get; }

					IObservableProperty<double> HeightOffset { get; }

					IObservableProperty<double> VerticalOffset { get; }

					IObservableProperty<Types.LineMaskStyle> MaskStyle { get; }

					IObservableProperty<double> WidthOffset { get; }

					IObservableProperty<double> HorizontalOffset { get; }
				}

				internal sealed class LineFillMask : ILineFillMask, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private BoolObservableProperty Enabled_;

					private DoubleObservableProperty HeightOffset_;

					private DoubleObservableProperty VerticalOffset_;

					private EnumObservableProperty<ILineFillMask.Types.LineMaskStyle> MaskStyle_;

					private DoubleObservableProperty WidthOffset_;

					private DoubleObservableProperty HorizontalOffset_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<bool> Enabled => Enabled_;

					public IObservableProperty<double> HeightOffset => HeightOffset_;

					public IObservableProperty<double> VerticalOffset => VerticalOffset_;

					public IObservableProperty<ILineFillMask.Types.LineMaskStyle> MaskStyle => MaskStyle_;

					public IObservableProperty<double> WidthOffset => WidthOffset_;

					public IObservableProperty<double> HorizontalOffset => HorizontalOffset_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Enabled_.UpdateMap(_map);
						HeightOffset_.UpdateMap(_map);
						VerticalOffset_.UpdateMap(_map);
						MaskStyle_.UpdateMap(_map);
						WidthOffset_.UpdateMap(_map);
						HorizontalOffset_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Enabled_.UpdateMapOnInternalMapUpdate(_map);
						HeightOffset_.UpdateMapOnInternalMapUpdate(_map);
						VerticalOffset_.UpdateMapOnInternalMapUpdate(_map);
						MaskStyle_.UpdateMapOnInternalMapUpdate(_map);
						WidthOffset_.UpdateMapOnInternalMapUpdate(_map);
						HorizontalOffset_.UpdateMapOnInternalMapUpdate(_map);
					}

					public LineFillMask()
						: this(new LoroMap())
					{
					}

					public LineFillMask(LoroMap values)
					{
						_map = values;
						Enabled_ = new BoolObservableProperty("enabled__1", LoroMap);
						HeightOffset_ = new DoubleObservableProperty("height_offset__2", LoroMap);
						VerticalOffset_ = new DoubleObservableProperty("vertical_offset__3", LoroMap);
						MaskStyle_ = new EnumObservableProperty<ILineFillMask.Types.LineMaskStyle>("mask_style__4", LoroMap);
						WidthOffset_ = new DoubleObservableProperty("width_offset__5", LoroMap);
						HorizontalOffset_ = new DoubleObservableProperty("horizontal_offset__6", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Enabled_.WhenChangeHappens, HeightOffset_.WhenChangeHappens, VerticalOffset_.WhenChangeHappens, MaskStyle_.WhenChangeHappens, WidthOffset_.WhenChangeHappens, HorizontalOffset_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Enabled_.Dispose();
						HeightOffset_.Dispose();
						VerticalOffset_.Dispose();
						MaskStyle_.Dispose();
						WidthOffset_.Dispose();
						HorizontalOffset_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Enabled_.OnDiff(path, diff);
						HeightOffset_.OnDiff(path, diff);
						VerticalOffset_.OnDiff(path, diff);
						MaskStyle_.OnDiff(path, diff);
						WidthOffset_.OnDiff(path, diff);
						HorizontalOffset_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IMediaFill : IEntity, IDisposable
				{
					IComplexObservableProperty<IMedia> Media { get; }
				}

				internal sealed class MediaFill : IMediaFill, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private ComplexObservableProperty<IMedia> Media_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IComplexObservableProperty<IMedia> Media => Media_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Media_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Media_.UpdateMapOnInternalMapUpdate(_map);
					}

					public MediaFill()
						: this(new LoroMap())
					{
					}

					public MediaFill(LoroMap values)
					{
						_map = values;
						Media_ = new ComplexObservableProperty<IMedia>("media__1", LoroMap, new EntityFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Media_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Media_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Media_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public enum ScaleBehavior
				{
					None,
					AdjustContainerHeight,
					ScaleFontDown,
					ScaleFontUp,
					ScaleFontUpDown
				}

				public enum Transform
				{
					None,
					SingleLine,
					OneWordPerLine,
					OneCharacterPerLine,
					ReplaceLineReturns
				}

				public enum VerticalAlignment
				{
					Top,
					Middle,
					Bottom
				}
			}

			IComplexObservableProperty<Types.IAttributes?> Attributes { get; }

			IComplexObservableProperty<IShadow> Shadow { get; }

			IObservableProperty<byte[]?> RtfData { get; }

			IObservableProperty<Types.VerticalAlignment> VerticalAlignment { get; }

			IObservableProperty<Types.ScaleBehavior> ScaleBehavior { get; }

			IComplexObservableProperty<IEdgeInsets> Margins { get; }

			IObservableProperty<Types.Transform> Transform { get; }

			IObservableProperty<string> TransformDelimiter { get; }

			IComplexObservableProperty<Types.IChordPro?> ChordPro { get; }

			IKeyedCollection<string, Types.IAlternateText> AlternateTexts { get; }
		}

		internal sealed class Text : IText, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private OptionalComplexObservableProperty<IText.Types.IAttributes> Attributes_;

			private ComplexObservableProperty<IShadow> Shadow_;

			private OptionalBytesObservableProperty RtfData_;

			private EnumObservableProperty<IText.Types.VerticalAlignment> VerticalAlignment_;

			private EnumObservableProperty<IText.Types.ScaleBehavior> ScaleBehavior_;

			private ComplexObservableProperty<IEdgeInsets> Margins_;

			private EnumObservableProperty<IText.Types.Transform> Transform_;

			private StringObservableProperty TransformDelimiter_;

			private OptionalComplexObservableProperty<IText.Types.IChordPro> ChordPro_;

			private KeyedMapCollection<string, IText.Types.IAlternateText> AlternateTexts_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IText.Types.IAttributes?> Attributes => Attributes_;

			public IComplexObservableProperty<IShadow> Shadow => Shadow_;

			public IObservableProperty<byte[]?> RtfData => RtfData_;

			public IObservableProperty<IText.Types.VerticalAlignment> VerticalAlignment => VerticalAlignment_;

			public IObservableProperty<IText.Types.ScaleBehavior> ScaleBehavior => ScaleBehavior_;

			public IComplexObservableProperty<IEdgeInsets> Margins => Margins_;

			public IObservableProperty<IText.Types.Transform> Transform => Transform_;

			public IObservableProperty<string> TransformDelimiter => TransformDelimiter_;

			public IComplexObservableProperty<IText.Types.IChordPro?> ChordPro => ChordPro_;

			public IKeyedCollection<string, IText.Types.IAlternateText> AlternateTexts => AlternateTexts_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Attributes_.UpdateMap(_map);
				Shadow_.UpdateMap(_map);
				RtfData_.UpdateMap(_map);
				VerticalAlignment_.UpdateMap(_map);
				ScaleBehavior_.UpdateMap(_map);
				Margins_.UpdateMap(_map);
				Transform_.UpdateMap(_map);
				TransformDelimiter_.UpdateMap(_map);
				ChordPro_.UpdateMap(_map);
				AlternateTexts_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Attributes_.UpdateMapOnInternalMapUpdate(_map);
				Shadow_.UpdateMapOnInternalMapUpdate(_map);
				RtfData_.UpdateMapOnInternalMapUpdate(_map);
				VerticalAlignment_.UpdateMapOnInternalMapUpdate(_map);
				ScaleBehavior_.UpdateMapOnInternalMapUpdate(_map);
				Margins_.UpdateMapOnInternalMapUpdate(_map);
				Transform_.UpdateMapOnInternalMapUpdate(_map);
				TransformDelimiter_.UpdateMapOnInternalMapUpdate(_map);
				ChordPro_.UpdateMapOnInternalMapUpdate(_map);
				AlternateTexts_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Text()
				: this(new LoroMap())
			{
			}

			public Text(LoroMap values)
			{
				_map = values;
				Attributes_ = new OptionalComplexObservableProperty<IText.Types.IAttributes>("attributes__3", LoroMap, new EntityFactory());
				Shadow_ = new ComplexObservableProperty<IShadow>("shadow__4", LoroMap, new EntityFactory());
				RtfData_ = new OptionalBytesObservableProperty("rtf_data__5", LoroMap);
				VerticalAlignment_ = new EnumObservableProperty<IText.Types.VerticalAlignment>("vertical_alignment__6", LoroMap);
				ScaleBehavior_ = new EnumObservableProperty<IText.Types.ScaleBehavior>("scale_behavior__7", LoroMap);
				Margins_ = new ComplexObservableProperty<IEdgeInsets>("margins__8", LoroMap, new EntityFactory());
				Transform_ = new EnumObservableProperty<IText.Types.Transform>("transform__10", LoroMap);
				TransformDelimiter_ = new StringObservableProperty("transformDelimiter__11", LoroMap);
				ChordPro_ = new OptionalComplexObservableProperty<IText.Types.IChordPro>("chord_pro__12", LoroMap, new EntityFactory());
				AlternateTexts_ = new KeyedMapCollection<string, IText.Types.IAlternateText>(LoroMap, "alternate_texts__13", new EntityFactory(), new StringCrdtKeySerializer());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Attributes_.WhenChangeHappens, Shadow_.WhenChangeHappens, RtfData_.WhenChangeHappens, VerticalAlignment_.WhenChangeHappens, ScaleBehavior_.WhenChangeHappens, Margins_.WhenChangeHappens, Transform_.WhenChangeHappens, TransformDelimiter_.WhenChangeHappens, ChordPro_.WhenChangeHappens, AlternateTexts_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Attributes_.Dispose();
				Shadow_.Dispose();
				RtfData_.Dispose();
				VerticalAlignment_.Dispose();
				ScaleBehavior_.Dispose();
				Margins_.Dispose();
				Transform_.Dispose();
				TransformDelimiter_.Dispose();
				ChordPro_.Dispose();
				AlternateTexts_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Attributes_.OnDiff(path, diff);
				Shadow_.OnDiff(path, diff);
				RtfData_.OnDiff(path, diff);
				VerticalAlignment_.OnDiff(path, diff);
				ScaleBehavior_.OnDiff(path, diff);
				Margins_.OnDiff(path, diff);
				Transform_.OnDiff(path, diff);
				TransformDelimiter_.OnDiff(path, diff);
				ChordPro_.OnDiff(path, diff);
				AlternateTexts_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}
}
