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

public interface IMedia : IEntity, IDisposable
{
	public class Types
	{
		public interface IAudio : IEntity, IDisposable
		{
			public class Types
			{
				public interface IChannel : IEntity, IDisposable
				{
					public class Types
					{
						public interface IOutput : IEntity, IDisposable
						{
							IObservableProperty<int> ChannelIndex { get; }
						}

						internal sealed class Output : IOutput, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private IntObservableProperty ChannelIndex_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<int> ChannelIndex => ChannelIndex_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								ChannelIndex_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								ChannelIndex_.UpdateMapOnInternalMapUpdate(_map);
							}

							public Output()
								: this(new LoroMap())
							{
							}

							public Output(LoroMap values)
							{
								_map = values;
								ChannelIndex_ = new IntObservableProperty("channel_index__2", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = Observable.Merge<Unit>(ChannelIndex_.WhenChangeHappens);
							}

							public void Dispose()
							{
								ChannelIndex_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								ChannelIndex_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}
					}

					IObservableProperty<uint> Index { get; }

					IObservableProperty<bool> Muted { get; }

					IObservableProperty<double> Volume { get; }

					IObservableProperty<bool> CompressLimit { get; }

					IComplexCollection<Types.IOutput> Outputs { get; }
				}

				internal sealed class Channel : IChannel, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private UintObservableProperty Index_;

					private BoolObservableProperty Muted_;

					private DoubleObservableProperty Volume_;

					private BoolObservableProperty CompressLimit_;

					private MapCollection<IChannel.Types.IOutput> Outputs_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<uint> Index => Index_;

					public IObservableProperty<bool> Muted => Muted_;

					public IObservableProperty<double> Volume => Volume_;

					public IObservableProperty<bool> CompressLimit => CompressLimit_;

					public IComplexCollection<IChannel.Types.IOutput> Outputs => Outputs_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Index_.UpdateMap(_map);
						Muted_.UpdateMap(_map);
						Volume_.UpdateMap(_map);
						CompressLimit_.UpdateMap(_map);
						Outputs_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Index_.UpdateMapOnInternalMapUpdate(_map);
						Muted_.UpdateMapOnInternalMapUpdate(_map);
						Volume_.UpdateMapOnInternalMapUpdate(_map);
						CompressLimit_.UpdateMapOnInternalMapUpdate(_map);
						Outputs_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Channel()
						: this(new LoroMap())
					{
					}

					public Channel(LoroMap values)
					{
						_map = values;
						Index_ = new UintObservableProperty("index__1", LoroMap);
						Muted_ = new BoolObservableProperty("muted__2", LoroMap);
						Volume_ = new DoubleObservableProperty("volume__3", LoroMap);
						CompressLimit_ = new BoolObservableProperty("compress_limit__4", LoroMap);
						Outputs_ = new MapCollection<IChannel.Types.IOutput>(LoroMap, "outputs__5", new EntityFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Index_.WhenChangeHappens, Muted_.WhenChangeHappens, Volume_.WhenChangeHappens, CompressLimit_.WhenChangeHappens, Outputs_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Index_.Dispose();
						Muted_.Dispose();
						Volume_.Dispose();
						CompressLimit_.Dispose();
						Outputs_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Index_.OnDiff(path, diff);
						Muted_.OnDiff(path, diff);
						Volume_.OnDiff(path, diff);
						CompressLimit_.OnDiff(path, diff);
						Outputs_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}
			}
		}

		internal sealed class Audio : IAudio, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

			public Audio()
				: this(new LoroMap())
			{
			}

			public Audio(LoroMap values)
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

		public interface IAudioProperties : IEntity, IDisposable
		{
			IObservableProperty<double> Volume { get; }

			IComplexCollection<IAudio.Types.IChannel> AudioChannels { get; }

			IObservableProperty<bool> IsCustomMapping { get; }
		}

		internal sealed class AudioProperties : IAudioProperties, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private DoubleObservableProperty Volume_;

			private MapCollection<IAudio.Types.IChannel> AudioChannels_;

			private BoolObservableProperty IsCustomMapping_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<double> Volume => Volume_;

			public IComplexCollection<IAudio.Types.IChannel> AudioChannels => AudioChannels_;

			public IObservableProperty<bool> IsCustomMapping => IsCustomMapping_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Volume_.UpdateMap(_map);
				AudioChannels_.UpdateMap(_map);
				IsCustomMapping_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Volume_.UpdateMapOnInternalMapUpdate(_map);
				AudioChannels_.UpdateMapOnInternalMapUpdate(_map);
				IsCustomMapping_.UpdateMapOnInternalMapUpdate(_map);
			}

			public AudioProperties()
				: this(new LoroMap())
			{
			}

			public AudioProperties(LoroMap values)
			{
				_map = values;
				Volume_ = new DoubleObservableProperty("volume__1", LoroMap);
				AudioChannels_ = new MapCollection<IAudio.Types.IChannel>(LoroMap, "audio_channels__2", new EntityFactory());
				IsCustomMapping_ = new BoolObservableProperty("is_custom_mapping__3", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Volume_.WhenChangeHappens, AudioChannels_.WhenChangeHappens, IsCustomMapping_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Volume_.Dispose();
				AudioChannels_.Dispose();
				IsCustomMapping_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Volume_.OnDiff(path, diff);
				AudioChannels_.OnDiff(path, diff);
				IsCustomMapping_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IAudioTypeProperties : IEntity, IDisposable
		{
			IComplexObservableProperty<IAudioProperties> Audio { get; }

			IComplexObservableProperty<ITransportProperties> Transport { get; }

			IComplexObservableProperty<IFileProperties> File { get; }
		}

		internal sealed class AudioTypeProperties : IAudioTypeProperties, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<IAudioProperties> Audio_;

			private ComplexObservableProperty<ITransportProperties> Transport_;

			private ComplexObservableProperty<IFileProperties> File_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IAudioProperties> Audio => Audio_;

			public IComplexObservableProperty<ITransportProperties> Transport => Transport_;

			public IComplexObservableProperty<IFileProperties> File => File_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Audio_.UpdateMap(_map);
				Transport_.UpdateMap(_map);
				File_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Audio_.UpdateMapOnInternalMapUpdate(_map);
				Transport_.UpdateMapOnInternalMapUpdate(_map);
				File_.UpdateMapOnInternalMapUpdate(_map);
			}

			public AudioTypeProperties()
				: this(new LoroMap())
			{
			}

			public AudioTypeProperties(LoroMap values)
			{
				_map = values;
				Audio_ = new ComplexObservableProperty<IAudioProperties>("audio__1", LoroMap, new EntityFactory());
				Transport_ = new ComplexObservableProperty<ITransportProperties>("transport__2", LoroMap, new EntityFactory());
				File_ = new ComplexObservableProperty<IFileProperties>("file__3", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Audio_.WhenChangeHappens, Transport_.WhenChangeHappens, File_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Audio_.Dispose();
				Transport_.Dispose();
				File_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Audio_.OnDiff(path, diff);
				Transport_.OnDiff(path, diff);
				File_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IDrawingProperties : IEntity, IDisposable
		{
			public class Types
			{
				public enum NativeRotationType
				{
					RotateStandard = 0,
					Rotate90 = 90,
					Rotate180 = 180,
					Rotate270 = 270
				}
			}

			IObservableProperty<ScaleBehavior> ScaleBehavior { get; }

			IObservableProperty<ScaleAlignment> ScaleAlignment { get; }

			IObservableProperty<bool> FlippedHorizontally { get; }

			IObservableProperty<bool> FlippedVertically { get; }

			IObservableProperty<IGraphics.Types.Size> NaturalSize { get; }

			IObservableProperty<double> CustomImageRotation { get; }

			IObservableProperty<IGraphics.Types.Rect> CustomImageBounds { get; }

			IObservableProperty<bool> CustomImageAspectLocked { get; }

			IObservableProperty<bool> AlphaInverted { get; }

			IObservableProperty<Types.NativeRotationType> NativeRotation { get; }

			IObservableProperty<Guid?> SelectedEffectPresetUuid { get; }

			IComplexCollection<IEffect> Effects { get; }

			IObservableProperty<bool> CropEnable { get; }

			IComplexObservableProperty<IGraphics.Types.IEdgeInsets?> CropInsets { get; }

			IObservableProperty<AlphaType> AlphaType { get; }

			IObservableProperty<bool> IsBlurred { get; }
		}

		internal sealed class DrawingProperties : IDrawingProperties, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private EnumObservableProperty<ScaleBehavior> ScaleBehavior_;

			private EnumObservableProperty<ScaleAlignment> ScaleAlignment_;

			private BoolObservableProperty FlippedHorizontally_;

			private BoolObservableProperty FlippedVertically_;

			private AtomicObservableProperty<IGraphics.Types.Size> NaturalSize_;

			private DoubleObservableProperty CustomImageRotation_;

			private AtomicObservableProperty<IGraphics.Types.Rect> CustomImageBounds_;

			private BoolObservableProperty CustomImageAspectLocked_;

			private BoolObservableProperty AlphaInverted_;

			private EnumObservableProperty<IDrawingProperties.Types.NativeRotationType> NativeRotation_;

			private OptionalGuidObservableProperty SelectedEffectPresetUuid_;

			private MapCollection<IEffect> Effects_;

			private BoolObservableProperty CropEnable_;

			private OptionalComplexObservableProperty<IGraphics.Types.IEdgeInsets> CropInsets_;

			private EnumObservableProperty<AlphaType> AlphaType_;

			private BoolObservableProperty IsBlurred_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<ScaleBehavior> ScaleBehavior => ScaleBehavior_;

			public IObservableProperty<ScaleAlignment> ScaleAlignment => ScaleAlignment_;

			public IObservableProperty<bool> FlippedHorizontally => FlippedHorizontally_;

			public IObservableProperty<bool> FlippedVertically => FlippedVertically_;

			public IObservableProperty<IGraphics.Types.Size> NaturalSize => NaturalSize_;

			public IObservableProperty<double> CustomImageRotation => CustomImageRotation_;

			public IObservableProperty<IGraphics.Types.Rect> CustomImageBounds => CustomImageBounds_;

			public IObservableProperty<bool> CustomImageAspectLocked => CustomImageAspectLocked_;

			public IObservableProperty<bool> AlphaInverted => AlphaInverted_;

			public IObservableProperty<IDrawingProperties.Types.NativeRotationType> NativeRotation => NativeRotation_;

			public IObservableProperty<Guid?> SelectedEffectPresetUuid => SelectedEffectPresetUuid_;

			public IComplexCollection<IEffect> Effects => Effects_;

			public IObservableProperty<bool> CropEnable => CropEnable_;

			public IComplexObservableProperty<IGraphics.Types.IEdgeInsets?> CropInsets => CropInsets_;

			public IObservableProperty<AlphaType> AlphaType => AlphaType_;

			public IObservableProperty<bool> IsBlurred => IsBlurred_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				ScaleBehavior_.UpdateMap(_map);
				ScaleAlignment_.UpdateMap(_map);
				FlippedHorizontally_.UpdateMap(_map);
				FlippedVertically_.UpdateMap(_map);
				NaturalSize_.UpdateMap(_map);
				CustomImageRotation_.UpdateMap(_map);
				CustomImageBounds_.UpdateMap(_map);
				CustomImageAspectLocked_.UpdateMap(_map);
				AlphaInverted_.UpdateMap(_map);
				NativeRotation_.UpdateMap(_map);
				SelectedEffectPresetUuid_.UpdateMap(_map);
				Effects_.UpdateMap(_map);
				CropEnable_.UpdateMap(_map);
				CropInsets_.UpdateMap(_map);
				AlphaType_.UpdateMap(_map);
				IsBlurred_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				ScaleBehavior_.UpdateMapOnInternalMapUpdate(_map);
				ScaleAlignment_.UpdateMapOnInternalMapUpdate(_map);
				FlippedHorizontally_.UpdateMapOnInternalMapUpdate(_map);
				FlippedVertically_.UpdateMapOnInternalMapUpdate(_map);
				NaturalSize_.UpdateMapOnInternalMapUpdate(_map);
				CustomImageRotation_.UpdateMapOnInternalMapUpdate(_map);
				CustomImageBounds_.UpdateMapOnInternalMapUpdate(_map);
				CustomImageAspectLocked_.UpdateMapOnInternalMapUpdate(_map);
				AlphaInverted_.UpdateMapOnInternalMapUpdate(_map);
				NativeRotation_.UpdateMapOnInternalMapUpdate(_map);
				SelectedEffectPresetUuid_.UpdateMapOnInternalMapUpdate(_map);
				Effects_.UpdateMapOnInternalMapUpdate(_map);
				CropEnable_.UpdateMapOnInternalMapUpdate(_map);
				CropInsets_.UpdateMapOnInternalMapUpdate(_map);
				AlphaType_.UpdateMapOnInternalMapUpdate(_map);
				IsBlurred_.UpdateMapOnInternalMapUpdate(_map);
			}

			public DrawingProperties()
				: this(new LoroMap())
			{
			}

			public DrawingProperties(LoroMap values)
			{
				_map = values;
				ScaleBehavior_ = new EnumObservableProperty<ScaleBehavior>("scale_behavior__1", LoroMap);
				ScaleAlignment_ = new EnumObservableProperty<ScaleAlignment>("scale_alignment__2", LoroMap);
				FlippedHorizontally_ = new BoolObservableProperty("flipped_horizontally__3", LoroMap);
				FlippedVertically_ = new BoolObservableProperty("flipped_vertically__4", LoroMap);
				NaturalSize_ = new AtomicObservableProperty<IGraphics.Types.Size>("natural_size__5", LoroMap, IGraphics.Types.SizeExtension.Deserialize, IGraphics.Types.SizeExtension.Serialize);
				CustomImageRotation_ = new DoubleObservableProperty("custom_image_rotation__6", LoroMap);
				CustomImageBounds_ = new AtomicObservableProperty<IGraphics.Types.Rect>("custom_image_bounds__7", LoroMap, IGraphics.Types.RectExtension.Deserialize, IGraphics.Types.RectExtension.Serialize);
				CustomImageAspectLocked_ = new BoolObservableProperty("custom_image_aspect_locked__8", LoroMap);
				AlphaInverted_ = new BoolObservableProperty("alpha_inverted__9", LoroMap);
				NativeRotation_ = new EnumObservableProperty<IDrawingProperties.Types.NativeRotationType>("native_rotation__10", LoroMap);
				SelectedEffectPresetUuid_ = new OptionalGuidObservableProperty("selected_effect_preset_uuid__11", LoroMap);
				Effects_ = new MapCollection<IEffect>(LoroMap, "effects__12", new EntityFactory());
				CropEnable_ = new BoolObservableProperty("crop_enable__13", LoroMap);
				CropInsets_ = new OptionalComplexObservableProperty<IGraphics.Types.IEdgeInsets>("crop_insets__14", LoroMap, new EntityFactory());
				AlphaType_ = new EnumObservableProperty<AlphaType>("alpha_type__15", LoroMap);
				IsBlurred_ = new BoolObservableProperty("is_blurred__16", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(ScaleBehavior_.WhenChangeHappens, ScaleAlignment_.WhenChangeHappens, FlippedHorizontally_.WhenChangeHappens, FlippedVertically_.WhenChangeHappens, NaturalSize_.WhenChangeHappens, CustomImageRotation_.WhenChangeHappens, CustomImageBounds_.WhenChangeHappens, CustomImageAspectLocked_.WhenChangeHappens, AlphaInverted_.WhenChangeHappens, NativeRotation_.WhenChangeHappens, SelectedEffectPresetUuid_.WhenChangeHappens, Effects_.WhenChangeHappens, CropEnable_.WhenChangeHappens, CropInsets_.WhenChangeHappens, AlphaType_.WhenChangeHappens, IsBlurred_.WhenChangeHappens);
			}

			public void Dispose()
			{
				ScaleBehavior_.Dispose();
				ScaleAlignment_.Dispose();
				FlippedHorizontally_.Dispose();
				FlippedVertically_.Dispose();
				NaturalSize_.Dispose();
				CustomImageRotation_.Dispose();
				CustomImageBounds_.Dispose();
				CustomImageAspectLocked_.Dispose();
				AlphaInverted_.Dispose();
				NativeRotation_.Dispose();
				SelectedEffectPresetUuid_.Dispose();
				Effects_.Dispose();
				CropEnable_.Dispose();
				CropInsets_.Dispose();
				AlphaType_.Dispose();
				IsBlurred_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				ScaleBehavior_.OnDiff(path, diff);
				ScaleAlignment_.OnDiff(path, diff);
				FlippedHorizontally_.OnDiff(path, diff);
				FlippedVertically_.OnDiff(path, diff);
				NaturalSize_.OnDiff(path, diff);
				CustomImageRotation_.OnDiff(path, diff);
				CustomImageBounds_.OnDiff(path, diff);
				CustomImageAspectLocked_.OnDiff(path, diff);
				AlphaInverted_.OnDiff(path, diff);
				NativeRotation_.OnDiff(path, diff);
				SelectedEffectPresetUuid_.OnDiff(path, diff);
				Effects_.OnDiff(path, diff);
				CropEnable_.OnDiff(path, diff);
				CropInsets_.OnDiff(path, diff);
				AlphaType_.OnDiff(path, diff);
				IsBlurred_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IImageTypeProperties : IEntity, IDisposable
		{
			IComplexObservableProperty<IDrawingProperties> Drawing { get; }

			IComplexObservableProperty<IFileProperties> File { get; }
		}

		internal sealed class ImageTypeProperties : IImageTypeProperties, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<IDrawingProperties> Drawing_;

			private ComplexObservableProperty<IFileProperties> File_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IDrawingProperties> Drawing => Drawing_;

			public IComplexObservableProperty<IFileProperties> File => File_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Drawing_.UpdateMap(_map);
				File_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Drawing_.UpdateMapOnInternalMapUpdate(_map);
				File_.UpdateMapOnInternalMapUpdate(_map);
			}

			public ImageTypeProperties()
				: this(new LoroMap())
			{
			}

			public ImageTypeProperties(LoroMap values)
			{
				_map = values;
				Drawing_ = new ComplexObservableProperty<IDrawingProperties>("drawing__1", LoroMap, new EntityFactory());
				File_ = new ComplexObservableProperty<IFileProperties>("file__2", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Drawing_.WhenChangeHappens.Merge(File_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Drawing_.Dispose();
				File_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Drawing_.OnDiff(path, diff);
				File_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ILiveVideoProperties : IEntity, IDisposable
		{
			IObservableProperty<int> LiveVideoIndex { get; }
		}

		internal sealed class LiveVideoProperties : ILiveVideoProperties, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private IntObservableProperty LiveVideoIndex_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<int> LiveVideoIndex => LiveVideoIndex_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				LiveVideoIndex_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				LiveVideoIndex_.UpdateMapOnInternalMapUpdate(_map);
			}

			public LiveVideoProperties()
				: this(new LoroMap())
			{
			}

			public LiveVideoProperties(LoroMap values)
			{
				_map = values;
				LiveVideoIndex_ = new IntObservableProperty("live_video_index__3", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(LiveVideoIndex_.WhenChangeHappens);
			}

			public void Dispose()
			{
				LiveVideoIndex_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				LiveVideoIndex_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ILiveVideoTypeProperties : IEntity, IDisposable
		{
			IComplexObservableProperty<IDrawingProperties> Drawing { get; }

			IComplexObservableProperty<IAudioProperties> Audio { get; }

			IComplexObservableProperty<ILiveVideoProperties> LiveVideo { get; }
		}

		internal sealed class LiveVideoTypeProperties : ILiveVideoTypeProperties, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<IDrawingProperties> Drawing_;

			private ComplexObservableProperty<IAudioProperties> Audio_;

			private ComplexObservableProperty<ILiveVideoProperties> LiveVideo_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IDrawingProperties> Drawing => Drawing_;

			public IComplexObservableProperty<IAudioProperties> Audio => Audio_;

			public IComplexObservableProperty<ILiveVideoProperties> LiveVideo => LiveVideo_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Drawing_.UpdateMap(_map);
				Audio_.UpdateMap(_map);
				LiveVideo_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Drawing_.UpdateMapOnInternalMapUpdate(_map);
				Audio_.UpdateMapOnInternalMapUpdate(_map);
				LiveVideo_.UpdateMapOnInternalMapUpdate(_map);
			}

			public LiveVideoTypeProperties()
				: this(new LoroMap())
			{
			}

			public LiveVideoTypeProperties(LoroMap values)
			{
				_map = values;
				Drawing_ = new ComplexObservableProperty<IDrawingProperties>("drawing__1", LoroMap, new EntityFactory());
				Audio_ = new ComplexObservableProperty<IAudioProperties>("audio__2", LoroMap, new EntityFactory());
				LiveVideo_ = new ComplexObservableProperty<ILiveVideoProperties>("live_video__3", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Drawing_.WhenChangeHappens, Audio_.WhenChangeHappens, LiveVideo_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Drawing_.Dispose();
				Audio_.Dispose();
				LiveVideo_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Drawing_.OnDiff(path, diff);
				Audio_.OnDiff(path, diff);
				LiveVideo_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IMetadata : IEntity, IDisposable
		{
			public class Types
			{
				public enum ColorFormat
				{
					Unknown,
					Sdr,
					HdrRec2100Hlg,
					HdrRec2100Pq
				}
			}

			IObservableProperty<string?> ManufactureName { get; }

			IObservableProperty<Url?> ManufactureUrl { get; }

			IObservableProperty<string?> Information { get; }

			IObservableProperty<string?> Artist { get; }

			IObservableProperty<string> Format { get; }

			IObservableProperty<Types.ColorFormat> ColorFormat { get; }
		}

		internal sealed class Metadata : IMetadata, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private OptionalStringObservableProperty ManufactureName_;

			private OptionalAtomicObservableProperty<Url> ManufactureUrl_;

			private OptionalStringObservableProperty Information_;

			private OptionalStringObservableProperty Artist_;

			private StringObservableProperty Format_;

			private EnumObservableProperty<IMetadata.Types.ColorFormat> ColorFormat_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string?> ManufactureName => ManufactureName_;

			public IObservableProperty<Url?> ManufactureUrl => ManufactureUrl_;

			public IObservableProperty<string?> Information => Information_;

			public IObservableProperty<string?> Artist => Artist_;

			public IObservableProperty<string> Format => Format_;

			public IObservableProperty<IMetadata.Types.ColorFormat> ColorFormat => ColorFormat_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				ManufactureName_.UpdateMap(_map);
				ManufactureUrl_.UpdateMap(_map);
				Information_.UpdateMap(_map);
				Artist_.UpdateMap(_map);
				Format_.UpdateMap(_map);
				ColorFormat_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				ManufactureName_.UpdateMapOnInternalMapUpdate(_map);
				ManufactureUrl_.UpdateMapOnInternalMapUpdate(_map);
				Information_.UpdateMapOnInternalMapUpdate(_map);
				Artist_.UpdateMapOnInternalMapUpdate(_map);
				Format_.UpdateMapOnInternalMapUpdate(_map);
				ColorFormat_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Metadata()
				: this(new LoroMap())
			{
			}

			public Metadata(LoroMap values)
			{
				_map = values;
				ManufactureName_ = new OptionalStringObservableProperty("manufacture_name__1", LoroMap);
				ManufactureUrl_ = new OptionalAtomicObservableProperty<Url>("manufacture_url__2", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
				Information_ = new OptionalStringObservableProperty("information__3", LoroMap);
				Artist_ = new OptionalStringObservableProperty("artist__4", LoroMap);
				Format_ = new StringObservableProperty("format__5", LoroMap);
				ColorFormat_ = new EnumObservableProperty<IMetadata.Types.ColorFormat>("color_format__6", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(ManufactureName_.WhenChangeHappens, ManufactureUrl_.WhenChangeHappens, Information_.WhenChangeHappens, Artist_.WhenChangeHappens, Format_.WhenChangeHappens, ColorFormat_.WhenChangeHappens);
			}

			public void Dispose()
			{
				ManufactureName_.Dispose();
				ManufactureUrl_.Dispose();
				Information_.Dispose();
				Artist_.Dispose();
				Format_.Dispose();
				ColorFormat_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				ManufactureName_.OnDiff(path, diff);
				ManufactureUrl_.OnDiff(path, diff);
				Information_.OnDiff(path, diff);
				Artist_.OnDiff(path, diff);
				Format_.OnDiff(path, diff);
				ColorFormat_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ITransportProperties : IEntity, IDisposable
		{
			public class Types
			{
				public enum PlaybackBehavior
				{
					Stop,
					Loop,
					LoopForCount,
					LoopForTime
				}

				public enum RetriggerSetting
				{
					Unset,
					Always,
					Never,
					Automatic
				}
			}

			IObservableProperty<double> PlayRate { get; }

			IObservableProperty<double> InPoint { get; }

			IObservableProperty<double> OutPoint { get; }

			IObservableProperty<double> FadeInDuration { get; }

			IObservableProperty<double> FadeOutDuration { get; }

			IObservableProperty<double> EndPoint { get; }

			IObservableProperty<Types.PlaybackBehavior> PlaybackBehavior { get; }

			IObservableProperty<double> LoopTime { get; }

			IObservableProperty<uint> TimesToLoop { get; }

			IObservableProperty<Types.RetriggerSetting> Retrigger { get; }
		}

		internal sealed class TransportProperties : ITransportProperties, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private DoubleObservableProperty PlayRate_;

			private DoubleObservableProperty InPoint_;

			private DoubleObservableProperty OutPoint_;

			private DoubleObservableProperty FadeInDuration_;

			private DoubleObservableProperty FadeOutDuration_;

			private DoubleObservableProperty EndPoint_;

			private EnumObservableProperty<ITransportProperties.Types.PlaybackBehavior> PlaybackBehavior_;

			private DoubleObservableProperty LoopTime_;

			private UintObservableProperty TimesToLoop_;

			private EnumObservableProperty<ITransportProperties.Types.RetriggerSetting> Retrigger_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<double> PlayRate => PlayRate_;

			public IObservableProperty<double> InPoint => InPoint_;

			public IObservableProperty<double> OutPoint => OutPoint_;

			public IObservableProperty<double> FadeInDuration => FadeInDuration_;

			public IObservableProperty<double> FadeOutDuration => FadeOutDuration_;

			public IObservableProperty<double> EndPoint => EndPoint_;

			public IObservableProperty<ITransportProperties.Types.PlaybackBehavior> PlaybackBehavior => PlaybackBehavior_;

			public IObservableProperty<double> LoopTime => LoopTime_;

			public IObservableProperty<uint> TimesToLoop => TimesToLoop_;

			public IObservableProperty<ITransportProperties.Types.RetriggerSetting> Retrigger => Retrigger_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				PlayRate_.UpdateMap(_map);
				InPoint_.UpdateMap(_map);
				OutPoint_.UpdateMap(_map);
				FadeInDuration_.UpdateMap(_map);
				FadeOutDuration_.UpdateMap(_map);
				EndPoint_.UpdateMap(_map);
				PlaybackBehavior_.UpdateMap(_map);
				LoopTime_.UpdateMap(_map);
				TimesToLoop_.UpdateMap(_map);
				Retrigger_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				PlayRate_.UpdateMapOnInternalMapUpdate(_map);
				InPoint_.UpdateMapOnInternalMapUpdate(_map);
				OutPoint_.UpdateMapOnInternalMapUpdate(_map);
				FadeInDuration_.UpdateMapOnInternalMapUpdate(_map);
				FadeOutDuration_.UpdateMapOnInternalMapUpdate(_map);
				EndPoint_.UpdateMapOnInternalMapUpdate(_map);
				PlaybackBehavior_.UpdateMapOnInternalMapUpdate(_map);
				LoopTime_.UpdateMapOnInternalMapUpdate(_map);
				TimesToLoop_.UpdateMapOnInternalMapUpdate(_map);
				Retrigger_.UpdateMapOnInternalMapUpdate(_map);
			}

			public TransportProperties()
				: this(new LoroMap())
			{
			}

			public TransportProperties(LoroMap values)
			{
				_map = values;
				PlayRate_ = new DoubleObservableProperty("play_rate__1", LoroMap);
				InPoint_ = new DoubleObservableProperty("in_point__2", LoroMap);
				OutPoint_ = new DoubleObservableProperty("out_point__3", LoroMap);
				FadeInDuration_ = new DoubleObservableProperty("fade_in_duration__7", LoroMap);
				FadeOutDuration_ = new DoubleObservableProperty("fade_out_duration__8", LoroMap);
				EndPoint_ = new DoubleObservableProperty("end_point__11", LoroMap);
				PlaybackBehavior_ = new EnumObservableProperty<ITransportProperties.Types.PlaybackBehavior>("playback_behavior__12", LoroMap);
				LoopTime_ = new DoubleObservableProperty("loop_time__13", LoroMap);
				TimesToLoop_ = new UintObservableProperty("times_to_loop__14", LoroMap);
				Retrigger_ = new EnumObservableProperty<ITransportProperties.Types.RetriggerSetting>("retrigger__15", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(PlayRate_.WhenChangeHappens, InPoint_.WhenChangeHappens, OutPoint_.WhenChangeHappens, FadeInDuration_.WhenChangeHappens, FadeOutDuration_.WhenChangeHappens, EndPoint_.WhenChangeHappens, PlaybackBehavior_.WhenChangeHappens, LoopTime_.WhenChangeHappens, TimesToLoop_.WhenChangeHappens, Retrigger_.WhenChangeHappens);
			}

			public void Dispose()
			{
				PlayRate_.Dispose();
				InPoint_.Dispose();
				OutPoint_.Dispose();
				FadeInDuration_.Dispose();
				FadeOutDuration_.Dispose();
				EndPoint_.Dispose();
				PlaybackBehavior_.Dispose();
				LoopTime_.Dispose();
				TimesToLoop_.Dispose();
				Retrigger_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				PlayRate_.OnDiff(path, diff);
				InPoint_.OnDiff(path, diff);
				OutPoint_.OnDiff(path, diff);
				FadeInDuration_.OnDiff(path, diff);
				FadeOutDuration_.OnDiff(path, diff);
				EndPoint_.OnDiff(path, diff);
				PlaybackBehavior_.OnDiff(path, diff);
				LoopTime_.OnDiff(path, diff);
				TimesToLoop_.OnDiff(path, diff);
				Retrigger_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IVideoDevice : IEntity, IDisposable
		{
			public class Types
			{
				public interface IAirCast : IEntity, IDisposable
				{
					IObservableProperty<string?> ServiceName { get; }

					IObservableProperty<string?> Password { get; }

					IObservableProperty<bool?> PasswordEnabled { get; }
				}

				internal sealed class AirCast : IAirCast, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private OptionalStringObservableProperty ServiceName_;

					private OptionalStringObservableProperty Password_;

					private OptionalBoolObservableProperty PasswordEnabled_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<string?> ServiceName => ServiceName_;

					public IObservableProperty<string?> Password => Password_;

					public IObservableProperty<bool?> PasswordEnabled => PasswordEnabled_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						ServiceName_.UpdateMap(_map);
						Password_.UpdateMap(_map);
						PasswordEnabled_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						ServiceName_.UpdateMapOnInternalMapUpdate(_map);
						Password_.UpdateMapOnInternalMapUpdate(_map);
						PasswordEnabled_.UpdateMapOnInternalMapUpdate(_map);
					}

					public AirCast()
						: this(new LoroMap())
					{
					}

					public AirCast(LoroMap values)
					{
						_map = values;
						ServiceName_ = new OptionalStringObservableProperty("service_name__1", LoroMap);
						Password_ = new OptionalStringObservableProperty("password__2", LoroMap);
						PasswordEnabled_ = new OptionalBoolObservableProperty("password_enabled__3", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(ServiceName_.WhenChangeHappens, Password_.WhenChangeHappens, PasswordEnabled_.WhenChangeHappens);
					}

					public void Dispose()
					{
						ServiceName_.Dispose();
						Password_.Dispose();
						PasswordEnabled_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						ServiceName_.OnDiff(path, diff);
						Password_.OnDiff(path, diff);
						PasswordEnabled_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public enum Type
				{
					Generic,
					Directshow,
					Blackmagic,
					Aja,
					Av,
					Syphon,
					Ndi,
					Bluefish,
					Aircast
				}
			}

			IObservableProperty<Types.Type> Type { get; }

			IObservableProperty<string> Name { get; }

			IObservableProperty<string> UniqueId { get; }

			IObservableProperty<string> ModelId { get; }

			IObservableProperty<uint> FormatIndex { get; }

			IComplexObservableProperty<IDigitalAudio.Types.IDevice.Types.IRouting> AudioRouting { get; }

			IComplexObservableProperty<Types.IAirCast?> Aircast { get; }
		}

		internal sealed class VideoDevice : IVideoDevice, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private EnumObservableProperty<IVideoDevice.Types.Type> Type_;

			private StringObservableProperty Name_;

			private StringObservableProperty UniqueId_;

			private StringObservableProperty ModelId_;

			private UintObservableProperty FormatIndex_;

			private ComplexObservableProperty<IDigitalAudio.Types.IDevice.Types.IRouting> AudioRouting_;

			private OptionalComplexObservableProperty<IVideoDevice.Types.IAirCast> Aircast_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<IVideoDevice.Types.Type> Type => Type_;

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<string> UniqueId => UniqueId_;

			public IObservableProperty<string> ModelId => ModelId_;

			public IObservableProperty<uint> FormatIndex => FormatIndex_;

			public IComplexObservableProperty<IDigitalAudio.Types.IDevice.Types.IRouting> AudioRouting => AudioRouting_;

			public IComplexObservableProperty<IVideoDevice.Types.IAirCast?> Aircast => Aircast_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Type_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				UniqueId_.UpdateMap(_map);
				ModelId_.UpdateMap(_map);
				FormatIndex_.UpdateMap(_map);
				AudioRouting_.UpdateMap(_map);
				Aircast_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Type_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				UniqueId_.UpdateMapOnInternalMapUpdate(_map);
				ModelId_.UpdateMapOnInternalMapUpdate(_map);
				FormatIndex_.UpdateMapOnInternalMapUpdate(_map);
				AudioRouting_.UpdateMapOnInternalMapUpdate(_map);
				Aircast_.UpdateMapOnInternalMapUpdate(_map);
			}

			public VideoDevice()
				: this(new LoroMap())
			{
			}

			public VideoDevice(LoroMap values)
			{
				_map = values;
				Type_ = new EnumObservableProperty<IVideoDevice.Types.Type>("type__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				UniqueId_ = new StringObservableProperty("unique_id__3", LoroMap);
				ModelId_ = new StringObservableProperty("model_id__4", LoroMap);
				FormatIndex_ = new UintObservableProperty("format_index__5", LoroMap);
				AudioRouting_ = new ComplexObservableProperty<IDigitalAudio.Types.IDevice.Types.IRouting>("audio_routing__6", LoroMap, new EntityFactory());
				Aircast_ = new OptionalComplexObservableProperty<IVideoDevice.Types.IAirCast>("aircast__7", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Type_.WhenChangeHappens, Name_.WhenChangeHappens, UniqueId_.WhenChangeHappens, ModelId_.WhenChangeHappens, FormatIndex_.WhenChangeHappens, AudioRouting_.WhenChangeHappens, Aircast_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Type_.Dispose();
				Name_.Dispose();
				UniqueId_.Dispose();
				ModelId_.Dispose();
				FormatIndex_.Dispose();
				AudioRouting_.Dispose();
				Aircast_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Type_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				UniqueId_.OnDiff(path, diff);
				ModelId_.OnDiff(path, diff);
				FormatIndex_.OnDiff(path, diff);
				AudioRouting_.OnDiff(path, diff);
				Aircast_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IVideoProperties : IEntity, IDisposable
		{
			public class Types
			{
				public enum EndBehavior
				{
					Stop,
					StopOnBlack,
					StopOnClear,
					FadeToBlack,
					FadeToClear
				}

				public enum FieldType
				{
					Unknown,
					Progressive,
					InterlacedUpperFirst,
					InterlacedLowerFirst
				}

				public enum HardwareDecodingType
				{
					Automatic = 0,
					Disabled = 2
				}
			}

			IObservableProperty<double> FrameRate { get; }

			IObservableProperty<Types.FieldType> FieldType { get; }

			IObservableProperty<double> ThumbnailPosition { get; }

			IObservableProperty<Types.EndBehavior> EndBehavior { get; }

			IObservableProperty<bool> SoftLoop { get; }

			IObservableProperty<double> SoftLoopDuration { get; }

			IObservableProperty<Types.HardwareDecodingType> HardwareDecoding { get; }
		}

		internal sealed class VideoProperties : IVideoProperties, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private DoubleObservableProperty FrameRate_;

			private EnumObservableProperty<IVideoProperties.Types.FieldType> FieldType_;

			private DoubleObservableProperty ThumbnailPosition_;

			private EnumObservableProperty<IVideoProperties.Types.EndBehavior> EndBehavior_;

			private BoolObservableProperty SoftLoop_;

			private DoubleObservableProperty SoftLoopDuration_;

			private EnumObservableProperty<IVideoProperties.Types.HardwareDecodingType> HardwareDecoding_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<double> FrameRate => FrameRate_;

			public IObservableProperty<IVideoProperties.Types.FieldType> FieldType => FieldType_;

			public IObservableProperty<double> ThumbnailPosition => ThumbnailPosition_;

			public IObservableProperty<IVideoProperties.Types.EndBehavior> EndBehavior => EndBehavior_;

			public IObservableProperty<bool> SoftLoop => SoftLoop_;

			public IObservableProperty<double> SoftLoopDuration => SoftLoopDuration_;

			public IObservableProperty<IVideoProperties.Types.HardwareDecodingType> HardwareDecoding => HardwareDecoding_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				FrameRate_.UpdateMap(_map);
				FieldType_.UpdateMap(_map);
				ThumbnailPosition_.UpdateMap(_map);
				EndBehavior_.UpdateMap(_map);
				SoftLoop_.UpdateMap(_map);
				SoftLoopDuration_.UpdateMap(_map);
				HardwareDecoding_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				FrameRate_.UpdateMapOnInternalMapUpdate(_map);
				FieldType_.UpdateMapOnInternalMapUpdate(_map);
				ThumbnailPosition_.UpdateMapOnInternalMapUpdate(_map);
				EndBehavior_.UpdateMapOnInternalMapUpdate(_map);
				SoftLoop_.UpdateMapOnInternalMapUpdate(_map);
				SoftLoopDuration_.UpdateMapOnInternalMapUpdate(_map);
				HardwareDecoding_.UpdateMapOnInternalMapUpdate(_map);
			}

			public VideoProperties()
				: this(new LoroMap())
			{
			}

			public VideoProperties(LoroMap values)
			{
				_map = values;
				FrameRate_ = new DoubleObservableProperty("frame_rate__1", LoroMap);
				FieldType_ = new EnumObservableProperty<IVideoProperties.Types.FieldType>("field_type__2", LoroMap);
				ThumbnailPosition_ = new DoubleObservableProperty("thumbnail_position__3", LoroMap);
				EndBehavior_ = new EnumObservableProperty<IVideoProperties.Types.EndBehavior>("end_behavior__4", LoroMap);
				SoftLoop_ = new BoolObservableProperty("soft_loop__5", LoroMap);
				SoftLoopDuration_ = new DoubleObservableProperty("soft_loop_duration__6", LoroMap);
				HardwareDecoding_ = new EnumObservableProperty<IVideoProperties.Types.HardwareDecodingType>("hardware_decoding__7", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(FrameRate_.WhenChangeHappens, FieldType_.WhenChangeHappens, ThumbnailPosition_.WhenChangeHappens, EndBehavior_.WhenChangeHappens, SoftLoop_.WhenChangeHappens, SoftLoopDuration_.WhenChangeHappens, HardwareDecoding_.WhenChangeHappens);
			}

			public void Dispose()
			{
				FrameRate_.Dispose();
				FieldType_.Dispose();
				ThumbnailPosition_.Dispose();
				EndBehavior_.Dispose();
				SoftLoop_.Dispose();
				SoftLoopDuration_.Dispose();
				HardwareDecoding_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				FrameRate_.OnDiff(path, diff);
				FieldType_.OnDiff(path, diff);
				ThumbnailPosition_.OnDiff(path, diff);
				EndBehavior_.OnDiff(path, diff);
				SoftLoop_.OnDiff(path, diff);
				SoftLoopDuration_.OnDiff(path, diff);
				HardwareDecoding_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IVideoTypeProperties : IEntity, IDisposable
		{
			IComplexObservableProperty<IDrawingProperties> Drawing { get; }

			IComplexObservableProperty<IAudioProperties> Audio { get; }

			IComplexObservableProperty<ITransportProperties> Transport { get; }

			IComplexObservableProperty<IVideoProperties> Video { get; }

			IComplexObservableProperty<IFileProperties> File { get; }
		}

		internal sealed class VideoTypeProperties : IVideoTypeProperties, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<IDrawingProperties> Drawing_;

			private ComplexObservableProperty<IAudioProperties> Audio_;

			private ComplexObservableProperty<ITransportProperties> Transport_;

			private ComplexObservableProperty<IVideoProperties> Video_;

			private ComplexObservableProperty<IFileProperties> File_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IDrawingProperties> Drawing => Drawing_;

			public IComplexObservableProperty<IAudioProperties> Audio => Audio_;

			public IComplexObservableProperty<ITransportProperties> Transport => Transport_;

			public IComplexObservableProperty<IVideoProperties> Video => Video_;

			public IComplexObservableProperty<IFileProperties> File => File_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Drawing_.UpdateMap(_map);
				Audio_.UpdateMap(_map);
				Transport_.UpdateMap(_map);
				Video_.UpdateMap(_map);
				File_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Drawing_.UpdateMapOnInternalMapUpdate(_map);
				Audio_.UpdateMapOnInternalMapUpdate(_map);
				Transport_.UpdateMapOnInternalMapUpdate(_map);
				Video_.UpdateMapOnInternalMapUpdate(_map);
				File_.UpdateMapOnInternalMapUpdate(_map);
			}

			public VideoTypeProperties()
				: this(new LoroMap())
			{
			}

			public VideoTypeProperties(LoroMap values)
			{
				_map = values;
				Drawing_ = new ComplexObservableProperty<IDrawingProperties>("drawing__1", LoroMap, new EntityFactory());
				Audio_ = new ComplexObservableProperty<IAudioProperties>("audio__2", LoroMap, new EntityFactory());
				Transport_ = new ComplexObservableProperty<ITransportProperties>("transport__3", LoroMap, new EntityFactory());
				Video_ = new ComplexObservableProperty<IVideoProperties>("video__4", LoroMap, new EntityFactory());
				File_ = new ComplexObservableProperty<IFileProperties>("file__5", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Drawing_.WhenChangeHappens, Audio_.WhenChangeHappens, Transport_.WhenChangeHappens, Video_.WhenChangeHappens, File_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Drawing_.Dispose();
				Audio_.Dispose();
				Transport_.Dispose();
				Video_.Dispose();
				File_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Drawing_.OnDiff(path, diff);
				Audio_.OnDiff(path, diff);
				Transport_.OnDiff(path, diff);
				Video_.OnDiff(path, diff);
				File_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IWebContentTypeProperties : IEntity, IDisposable
		{
			IComplexObservableProperty<IDrawingProperties> Drawing { get; }

			IObservableProperty<Url> Url { get; }
		}

		internal sealed class WebContentTypeProperties : IWebContentTypeProperties, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<IDrawingProperties> Drawing_;

			private AtomicObservableProperty<Url> Url_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IDrawingProperties> Drawing => Drawing_;

			public IObservableProperty<Url> Url => Url_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Drawing_.UpdateMap(_map);
				Url_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Drawing_.UpdateMapOnInternalMapUpdate(_map);
				Url_.UpdateMapOnInternalMapUpdate(_map);
			}

			public WebContentTypeProperties()
				: this(new LoroMap())
			{
			}

			public WebContentTypeProperties(LoroMap values)
			{
				_map = values;
				Drawing_ = new ComplexObservableProperty<IDrawingProperties>("drawing__1", LoroMap, new EntityFactory());
				Url_ = new AtomicObservableProperty<Url>("url__2", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Drawing_.WhenChangeHappens.Merge(Url_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Drawing_.Dispose();
				Url_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Drawing_.OnDiff(path, diff);
				Url_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public enum ScaleAlignment
		{
			MiddleCenter,
			TopLeft,
			TopCenter,
			TopRight,
			MiddleRight,
			BottomRight,
			BottomCenter,
			BottomLeft,
			MiddleLeft
		}

		public enum ScaleBehavior
		{
			Fit,
			Fill,
			Stretch,
			Custom
		}

		public interface ITypeProperties : IEntity, IDisposable
		{
			public interface IAudio : ITypeProperties, IEntity, IDisposable, IObservableProperty<IAudioTypeProperties>
			{
			}

			public interface IImage : ITypeProperties, IEntity, IDisposable, IObservableProperty<IImageTypeProperties>
			{
			}

			public interface IVideo : ITypeProperties, IEntity, IDisposable, IObservableProperty<IVideoTypeProperties>
			{
			}

			public interface ILiveVideo : ITypeProperties, IEntity, IDisposable, IObservableProperty<ILiveVideoTypeProperties>
			{
			}

			public interface IWebContent : ITypeProperties, IEntity, IDisposable, IObservableProperty<IWebContentTypeProperties>
			{
			}

			internal class Audio : IAudio, ITypeProperties, IEntity, IDisposable, IObservableProperty<IAudioTypeProperties>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IAudioTypeProperties> _Audio_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Audio_.WhenChangeHappens;

				public IObservable<IAudioTypeProperties> WhenValueChanges => _Audio_.WhenValueChanges;

				public IAudioTypeProperties Value => _Audio_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Audio_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Audio_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "audio__4".ToLoroValueLike());
					return loroMap;
				}

				public Audio()
					: this(InitializeMap())
				{
				}

				public Audio(LoroMap values)
				{
					_map = values;
					_Audio_ = new ComplexObservableProperty<IAudioTypeProperties>("audio__4", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Audio_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Audio_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Audio_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IAudioTypeProperties value)
				{
					_Audio_.Set(value);
				}
			}

			internal class Image : IImage, ITypeProperties, IEntity, IDisposable, IObservableProperty<IImageTypeProperties>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IImageTypeProperties> _Image_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Image_.WhenChangeHappens;

				public IObservable<IImageTypeProperties> WhenValueChanges => _Image_.WhenValueChanges;

				public IImageTypeProperties Value => _Image_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Image_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Image_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "image__5".ToLoroValueLike());
					return loroMap;
				}

				public Image()
					: this(InitializeMap())
				{
				}

				public Image(LoroMap values)
				{
					_map = values;
					_Image_ = new ComplexObservableProperty<IImageTypeProperties>("image__5", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Image_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Image_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Image_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IImageTypeProperties value)
				{
					_Image_.Set(value);
				}
			}

			internal class Video : IVideo, ITypeProperties, IEntity, IDisposable, IObservableProperty<IVideoTypeProperties>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IVideoTypeProperties> _Video_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Video_.WhenChangeHappens;

				public IObservable<IVideoTypeProperties> WhenValueChanges => _Video_.WhenValueChanges;

				public IVideoTypeProperties Value => _Video_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Video_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Video_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "video__6".ToLoroValueLike());
					return loroMap;
				}

				public Video()
					: this(InitializeMap())
				{
				}

				public Video(LoroMap values)
				{
					_map = values;
					_Video_ = new ComplexObservableProperty<IVideoTypeProperties>("video__6", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Video_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Video_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Video_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IVideoTypeProperties value)
				{
					_Video_.Set(value);
				}
			}

			internal class LiveVideo : ILiveVideo, ITypeProperties, IEntity, IDisposable, IObservableProperty<ILiveVideoTypeProperties>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ILiveVideoTypeProperties> _LiveVideo_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _LiveVideo_.WhenChangeHappens;

				public IObservable<ILiveVideoTypeProperties> WhenValueChanges => _LiveVideo_.WhenValueChanges;

				public ILiveVideoTypeProperties Value => _LiveVideo_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_LiveVideo_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_LiveVideo_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "live_video__7".ToLoroValueLike());
					return loroMap;
				}

				public LiveVideo()
					: this(InitializeMap())
				{
				}

				public LiveVideo(LoroMap values)
				{
					_map = values;
					_LiveVideo_ = new ComplexObservableProperty<ILiveVideoTypeProperties>("live_video__7", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_LiveVideo_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_LiveVideo_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_LiveVideo_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ILiveVideoTypeProperties value)
				{
					_LiveVideo_.Set(value);
				}
			}

			internal class WebContent : IWebContent, ITypeProperties, IEntity, IDisposable, IObservableProperty<IWebContentTypeProperties>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<IWebContentTypeProperties> _WebContent_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _WebContent_.WhenChangeHappens;

				public IObservable<IWebContentTypeProperties> WhenValueChanges => _WebContent_.WhenValueChanges;

				public IWebContentTypeProperties Value => _WebContent_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_WebContent_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_WebContent_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "web_content__8".ToLoroValueLike());
					return loroMap;
				}

				public WebContent()
					: this(InitializeMap())
				{
				}

				public WebContent(LoroMap values)
				{
					_map = values;
					_WebContent_ = new ComplexObservableProperty<IWebContentTypeProperties>("web_content__8", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_WebContent_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_WebContent_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_WebContent_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(IWebContentTypeProperties value)
				{
					_WebContent_.Set(value);
				}
			}
		}

		internal class TypePropertiesFactory : IUnionValueFactory<ITypeProperties>
		{
			public string SelectionKey => "__tag";

			public ITypeProperties? CreateInstance(LoroMap map)
			{
				return map.Get("__tag").ToStringValue() switch
				{
					"audio__4" => new ITypeProperties.Audio(map), 
					"image__5" => new ITypeProperties.Image(map), 
					"video__6" => new ITypeProperties.Video(map), 
					"live_video__7" => new ITypeProperties.LiveVideo(map), 
					"web_content__8" => new ITypeProperties.WebContent(map), 
					_ => null, 
				};
			}

			public ITypeProperties CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "audio__4".ToLoroValueLike());
				return new ITypeProperties.Audio(map);
			}
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IComplexObservableProperty<Types.IMetadata> Metadata { get; }

	IComplexObservableProperty<Types.ITypeProperties> TypeProperties { get; }
}
