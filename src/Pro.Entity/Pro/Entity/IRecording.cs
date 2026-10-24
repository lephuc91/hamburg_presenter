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

public interface IRecording : IEntity, IDisposable
{
	public class Types
	{
		public interface IPreset : IEntity, IDisposable
		{
			IObservableProperty<Guid> Id { get; }

			IObservableProperty<string> Name { get; }

			IComplexCollection<IStream> Streams { get; }
		}

		internal sealed class Preset : IPreset, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Id_;

			private StringObservableProperty Name_;

			private MapCollection<IStream> Streams_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Id => Id_;

			public IObservableProperty<string> Name => Name_;

			public IComplexCollection<IStream> Streams => Streams_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Id_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Streams_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Id_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Streams_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Preset()
				: this(new LoroMap())
			{
			}

			public Preset(LoroMap values)
			{
				_map = values;
				Id_ = new GuidObservableProperty("id__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Streams_ = new MapCollection<IStream>(LoroMap, "streams__3", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Id_.WhenChangeHappens, Name_.WhenChangeHappens, Streams_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Id_.Dispose();
				Name_.Dispose();
				Streams_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Id_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Streams_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ISettingsDocument : IEntity, IDisposable
		{
			IComplexCollection<IPreset> Presets { get; }

			IComplexObservableProperty<IPreset?> ActivePreset { get; }
		}

		internal sealed class SettingsDocument : ISettingsDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private MapCollection<IPreset> Presets_;

			private OptionalComplexObservableProperty<IPreset> ActivePreset_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexCollection<IPreset> Presets => Presets_;

			public IComplexObservableProperty<IPreset?> ActivePreset => ActivePreset_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Presets_.UpdateMap(_map);
				ActivePreset_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Presets_.UpdateMapOnInternalMapUpdate(_map);
				ActivePreset_.UpdateMapOnInternalMapUpdate(_map);
			}

			public SettingsDocument()
				: this(new LoroMap())
			{
			}

			public SettingsDocument(LoroMap values)
			{
				_map = values;
				Presets_ = new MapCollection<IPreset>(LoroMap, "presets__2", new EntityFactory());
				ActivePreset_ = new OptionalComplexObservableProperty<IPreset>("active_preset__3", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Presets_.WhenChangeHappens.Merge(ActivePreset_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Presets_.Dispose();
				ActivePreset_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Presets_.OnDiff(path, diff);
				ActivePreset_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IStream : IEntity, IDisposable
		{
			public class Types
			{
				public interface IDestination : IEntity, IDisposable
				{
					public class Types
					{
						public interface IResi : IEntity, IDisposable
						{
							IObservableProperty<Guid?> DestinationGroupId { get; }

							IObservableProperty<Guid?> EncoderProfileId { get; }
						}

						internal sealed class Resi : IResi, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
						{
							private LoroMap _map;

							private CompositeDisposable _linkedDisposables;

							private OptionalGuidObservableProperty DestinationGroupId_;

							private OptionalGuidObservableProperty EncoderProfileId_;

							public LoroMap LoroMap => _map;

							public IObservable<Unit> WhenChangeHappens { get; }

							public IObservableProperty<Guid?> DestinationGroupId => DestinationGroupId_;

							public IObservableProperty<Guid?> EncoderProfileId => EncoderProfileId_;

							public void UpdateMap(LoroMap value)
							{
								_map = value;
								DestinationGroupId_.UpdateMap(_map);
								EncoderProfileId_.UpdateMap(_map);
							}

							public void UpdateMapOnInternalMapUpdate(LoroMap value)
							{
								_map = value;
								DestinationGroupId_.UpdateMapOnInternalMapUpdate(_map);
								EncoderProfileId_.UpdateMapOnInternalMapUpdate(_map);
							}

							public Resi()
								: this(new LoroMap())
							{
							}

							public Resi(LoroMap values)
							{
								_map = values;
								DestinationGroupId_ = new OptionalGuidObservableProperty("destination_group_id__1", LoroMap);
								EncoderProfileId_ = new OptionalGuidObservableProperty("encoder_profile_id__2", LoroMap);
								_linkedDisposables = new CompositeDisposable();
								WhenChangeHappens = DestinationGroupId_.WhenChangeHappens.Merge(EncoderProfileId_.WhenChangeHappens);
							}

							public void Dispose()
							{
								DestinationGroupId_.Dispose();
								EncoderProfileId_.Dispose();
								LoroMap.Dispose();
								_linkedDisposables.Dispose();
							}

							public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
							{
								DestinationGroupId_.OnDiff(path, diff);
								EncoderProfileId_.OnDiff(path, diff);
							}

							public void RegisterLinkedDisposable(IDisposable disposable)
							{
								_linkedDisposables.Add(disposable);
							}
						}

						public interface IDestination : IEntity, IDisposable
						{
							public interface IDisk : IDestination, IEntity, IDisposable, IObservableProperty<IDiskDestination>
							{
							}

							public interface IRtmp : IDestination, IEntity, IDisposable, IObservableProperty<IRtmpDestination>
							{
							}

							public interface IResi : IDestination, IEntity, IDisposable, IObservableProperty<Types.IResi>
							{
							}

							internal class Disk : IDisk, IDestination, IEntity, IDisposable, IObservableProperty<IDiskDestination>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<IDiskDestination> _Disk_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _Disk_.WhenChangeHappens;

								public IObservable<IDiskDestination> WhenValueChanges => _Disk_.WhenValueChanges;

								public IDiskDestination Value => _Disk_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_Disk_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_Disk_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "disk__1".ToLoroValueLike());
									return loroMap;
								}

								public Disk()
									: this(InitializeMap())
								{
								}

								public Disk(LoroMap values)
								{
									_map = values;
									_Disk_ = new ComplexObservableProperty<IDiskDestination>("disk__1", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_Disk_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_Disk_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_Disk_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(IDiskDestination value)
								{
									_Disk_.Set(value);
								}
							}

							internal class Rtmp : IRtmp, IDestination, IEntity, IDisposable, IObservableProperty<IRtmpDestination>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<IRtmpDestination> _Rtmp_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _Rtmp_.WhenChangeHappens;

								public IObservable<IRtmpDestination> WhenValueChanges => _Rtmp_.WhenValueChanges;

								public IRtmpDestination Value => _Rtmp_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_Rtmp_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_Rtmp_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "rtmp__2".ToLoroValueLike());
									return loroMap;
								}

								public Rtmp()
									: this(InitializeMap())
								{
								}

								public Rtmp(LoroMap values)
								{
									_map = values;
									_Rtmp_ = new ComplexObservableProperty<IRtmpDestination>("rtmp__2", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_Rtmp_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_Rtmp_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_Rtmp_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(IRtmpDestination value)
								{
									_Rtmp_.Set(value);
								}
							}

							internal class Resi : IResi, IDestination, IEntity, IDisposable, IObservableProperty<Types.IResi>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
							{
								private LoroMap _map;

								private ComplexObservableProperty<Types.IResi> _Resi_;

								public LoroMap LoroMap => _map;

								public IObservable<Unit> WhenChangeHappens => _Resi_.WhenChangeHappens;

								public IObservable<Types.IResi> WhenValueChanges => _Resi_.WhenValueChanges;

								public Types.IResi Value => _Resi_.Value;

								public void UpdateMap(LoroMap value)
								{
									_map = value;
									_Resi_.UpdateMap(_map);
								}

								public void UpdateMapOnInternalMapUpdate(LoroMap value)
								{
									_map = value;
									_Resi_.UpdateMapOnInternalMapUpdate(_map);
								}

								private static LoroMap InitializeMap()
								{
									LoroMap loroMap = new LoroMap();
									loroMap.Insert("__tag", "resi__3".ToLoroValueLike());
									return loroMap;
								}

								public Resi()
									: this(InitializeMap())
								{
								}

								public Resi(LoroMap values)
								{
									_map = values;
									_Resi_ = new ComplexObservableProperty<Types.IResi>("resi__3", LoroMap, new EntityFactory());
								}

								public void Dispose()
								{
									_Resi_.Dispose();
									LoroMap.Dispose();
								}

								public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
								{
									_Resi_.OnDiff(path, diff);
								}

								public void RegisterLinkedDisposable(IDisposable disposable)
								{
									_Resi_.Value.RegisterLinkedDisposable(disposable);
								}

								public void Set(Types.IResi value)
								{
									_Resi_.Set(value);
								}
							}
						}

						internal class DestinationFactory : IUnionValueFactory<IDestination>
						{
							public string SelectionKey => "__tag";

							public IDestination? CreateInstance(LoroMap map)
							{
								return map.Get("__tag").ToStringValue() switch
								{
									"disk__1" => new IDestination.Disk(map), 
									"rtmp__2" => new IDestination.Rtmp(map), 
									"resi__3" => new IDestination.Resi(map), 
									_ => null, 
								};
							}

							public IDestination CreateDefault(LoroMap map)
							{
								map.Insert("__tag", "disk__1".ToLoroValueLike());
								return new IDestination.Disk(map);
							}
						}
					}

					IComplexObservableProperty<Types.IDestination> _Destination { get; }
				}

				internal sealed class Destination : IDestination, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private UnionObservableProperty<IDestination.Types.IDestination> _Destination_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IComplexObservableProperty<IDestination.Types.IDestination> _Destination => _Destination_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						_Destination_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						_Destination_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Destination()
						: this(new LoroMap())
					{
					}

					public Destination(LoroMap values)
					{
						_map = values;
						_Destination_ = new UnionObservableProperty<IDestination.Types.IDestination>("Destination__union", LoroMap, new IDestination.Types.DestinationFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(_Destination_.WhenChangeHappens);
					}

					public void Dispose()
					{
						_Destination_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						_Destination_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IDiskDestination : IEntity, IDisposable
				{
					IObservableProperty<Url> Location { get; }

					IObservableProperty<Container> Container { get; }
				}

				internal sealed class DiskDestination : IDiskDestination, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private AtomicObservableProperty<Url> Location_;

					private EnumObservableProperty<Container> Container_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<Url> Location => Location_;

					public IObservableProperty<Container> Container => Container_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Location_.UpdateMap(_map);
						Container_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Location_.UpdateMapOnInternalMapUpdate(_map);
						Container_.UpdateMapOnInternalMapUpdate(_map);
					}

					public DiskDestination()
						: this(new LoroMap())
					{
					}

					public DiskDestination(LoroMap values)
					{
						_map = values;
						Location_ = new AtomicObservableProperty<Url>("location__1", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
						Container_ = new EnumObservableProperty<Container>("container__2", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Location_.WhenChangeHappens.Merge(Container_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Location_.Dispose();
						Container_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Location_.OnDiff(path, diff);
						Container_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IEncoder : IEntity, IDisposable
				{
					IObservableProperty<Codec> Codec { get; }

					IObservableProperty<uint> VideoWidth { get; }

					IObservableProperty<uint> VideoHeight { get; }

					IObservableProperty<bool> IsInterlaced { get; }

					IObservableProperty<FrameRate> FrameRate { get; }

					IObservableProperty<uint> VideoBitrate { get; }

					IObservableProperty<uint> AudioBitrate { get; }
				}

				internal sealed class Encoder : IEncoder, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private EnumObservableProperty<Codec> Codec_;

					private UintObservableProperty VideoWidth_;

					private UintObservableProperty VideoHeight_;

					private BoolObservableProperty IsInterlaced_;

					private EnumObservableProperty<FrameRate> FrameRate_;

					private UintObservableProperty VideoBitrate_;

					private UintObservableProperty AudioBitrate_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<Codec> Codec => Codec_;

					public IObservableProperty<uint> VideoWidth => VideoWidth_;

					public IObservableProperty<uint> VideoHeight => VideoHeight_;

					public IObservableProperty<bool> IsInterlaced => IsInterlaced_;

					public IObservableProperty<FrameRate> FrameRate => FrameRate_;

					public IObservableProperty<uint> VideoBitrate => VideoBitrate_;

					public IObservableProperty<uint> AudioBitrate => AudioBitrate_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Codec_.UpdateMap(_map);
						VideoWidth_.UpdateMap(_map);
						VideoHeight_.UpdateMap(_map);
						IsInterlaced_.UpdateMap(_map);
						FrameRate_.UpdateMap(_map);
						VideoBitrate_.UpdateMap(_map);
						AudioBitrate_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Codec_.UpdateMapOnInternalMapUpdate(_map);
						VideoWidth_.UpdateMapOnInternalMapUpdate(_map);
						VideoHeight_.UpdateMapOnInternalMapUpdate(_map);
						IsInterlaced_.UpdateMapOnInternalMapUpdate(_map);
						FrameRate_.UpdateMapOnInternalMapUpdate(_map);
						VideoBitrate_.UpdateMapOnInternalMapUpdate(_map);
						AudioBitrate_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Encoder()
						: this(new LoroMap())
					{
					}

					public Encoder(LoroMap values)
					{
						_map = values;
						Codec_ = new EnumObservableProperty<Codec>("codec__1", LoroMap);
						VideoWidth_ = new UintObservableProperty("video_width__2", LoroMap);
						VideoHeight_ = new UintObservableProperty("video_height__3", LoroMap);
						IsInterlaced_ = new BoolObservableProperty("is_interlaced__4", LoroMap);
						FrameRate_ = new EnumObservableProperty<FrameRate>("frameRate__5", LoroMap);
						VideoBitrate_ = new UintObservableProperty("video_bitrate__6", LoroMap);
						AudioBitrate_ = new UintObservableProperty("audio_bitrate__7", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Codec_.WhenChangeHappens, VideoWidth_.WhenChangeHappens, VideoHeight_.WhenChangeHappens, IsInterlaced_.WhenChangeHappens, FrameRate_.WhenChangeHappens, VideoBitrate_.WhenChangeHappens, AudioBitrate_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Codec_.Dispose();
						VideoWidth_.Dispose();
						VideoHeight_.Dispose();
						IsInterlaced_.Dispose();
						FrameRate_.Dispose();
						VideoBitrate_.Dispose();
						AudioBitrate_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Codec_.OnDiff(path, diff);
						VideoWidth_.OnDiff(path, diff);
						VideoHeight_.OnDiff(path, diff);
						IsInterlaced_.OnDiff(path, diff);
						FrameRate_.OnDiff(path, diff);
						VideoBitrate_.OnDiff(path, diff);
						AudioBitrate_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IOutputScreenSource : IEntity, IDisposable
				{
					IObservableProperty<Guid?> ScreenId { get; }

					IObservableProperty<string?> ScreenName { get; }
				}

				internal sealed class OutputScreenSource : IOutputScreenSource, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private OptionalGuidObservableProperty ScreenId_;

					private OptionalStringObservableProperty ScreenName_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<Guid?> ScreenId => ScreenId_;

					public IObservableProperty<string?> ScreenName => ScreenName_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						ScreenId_.UpdateMap(_map);
						ScreenName_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						ScreenId_.UpdateMapOnInternalMapUpdate(_map);
						ScreenName_.UpdateMapOnInternalMapUpdate(_map);
					}

					public OutputScreenSource()
						: this(new LoroMap())
					{
					}

					public OutputScreenSource(LoroMap values)
					{
						_map = values;
						ScreenId_ = new OptionalGuidObservableProperty("screen_id__1", LoroMap);
						ScreenName_ = new OptionalStringObservableProperty("screen_name__2", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = ScreenId_.WhenChangeHappens.Merge(ScreenName_.WhenChangeHappens);
					}

					public void Dispose()
					{
						ScreenId_.Dispose();
						ScreenName_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						ScreenId_.OnDiff(path, diff);
						ScreenName_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IRtmpDestination : IEntity, IDisposable
				{
					IObservableProperty<string> Address { get; }

					IObservableProperty<string> Key { get; }
				}

				internal sealed class RtmpDestination : IRtmpDestination, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private StringObservableProperty Address_;

					private StringObservableProperty Key_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<string> Address => Address_;

					public IObservableProperty<string> Key => Key_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Address_.UpdateMap(_map);
						Key_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Address_.UpdateMapOnInternalMapUpdate(_map);
						Key_.UpdateMapOnInternalMapUpdate(_map);
					}

					public RtmpDestination()
						: this(new LoroMap())
					{
					}

					public RtmpDestination(LoroMap values)
					{
						_map = values;
						Address_ = new StringObservableProperty("address__1", LoroMap);
						Key_ = new StringObservableProperty("key__2", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Address_.WhenChangeHappens.Merge(Key_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Address_.Dispose();
						Key_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Address_.OnDiff(path, diff);
						Key_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public enum Codec
				{
					Automatic,
					H264,
					H265,
					Prores422Proxy,
					Prores422Lt,
					Prores422,
					Prores422Hq,
					Prores4444,
					Prores4444Xq,
					Hap,
					HapAlpha,
					HapQ,
					HapQAlpha,
					Notch,
					H264Software,
					H265Software
				}

				public enum Container
				{
					Unknown,
					Mov,
					Mp4
				}

				public enum FrameRate
				{
					Unknown,
					_24,
					_25,
					_2997,
					_30,
					_50,
					_5994,
					_60
				}

				public interface ISource : IEntity, IDisposable
				{
					public interface IOutputScreen : ISource, IEntity, IDisposable, IObservableProperty<IOutputScreenSource>
					{
					}

					internal class OutputScreen : IOutputScreen, ISource, IEntity, IDisposable, IObservableProperty<IOutputScreenSource>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
					{
						private LoroMap _map;

						private ComplexObservableProperty<IOutputScreenSource> _OutputScreen_;

						public LoroMap LoroMap => _map;

						public IObservable<Unit> WhenChangeHappens => _OutputScreen_.WhenChangeHappens;

						public IObservable<IOutputScreenSource> WhenValueChanges => _OutputScreen_.WhenValueChanges;

						public IOutputScreenSource Value => _OutputScreen_.Value;

						public void UpdateMap(LoroMap value)
						{
							_map = value;
							_OutputScreen_.UpdateMap(_map);
						}

						public void UpdateMapOnInternalMapUpdate(LoroMap value)
						{
							_map = value;
							_OutputScreen_.UpdateMapOnInternalMapUpdate(_map);
						}

						private static LoroMap InitializeMap()
						{
							LoroMap loroMap = new LoroMap();
							loroMap.Insert("__tag", "output_screen__2".ToLoroValueLike());
							return loroMap;
						}

						public OutputScreen()
							: this(InitializeMap())
						{
						}

						public OutputScreen(LoroMap values)
						{
							_map = values;
							_OutputScreen_ = new ComplexObservableProperty<IOutputScreenSource>("output_screen__2", LoroMap, new EntityFactory());
						}

						public void Dispose()
						{
							_OutputScreen_.Dispose();
							LoroMap.Dispose();
						}

						public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
						{
							_OutputScreen_.OnDiff(path, diff);
						}

						public void RegisterLinkedDisposable(IDisposable disposable)
						{
							_OutputScreen_.Value.RegisterLinkedDisposable(disposable);
						}

						public void Set(IOutputScreenSource value)
						{
							_OutputScreen_.Set(value);
						}
					}
				}

				internal class SourceFactory : IUnionValueFactory<ISource>
				{
					public string SelectionKey => "__tag";

					public ISource? CreateInstance(LoroMap map)
					{
						if (map.Get("__tag").ToStringValue() == "output_screen__2")
						{
							return new ISource.OutputScreen(map);
						}
						return null;
					}

					public ISource CreateDefault(LoroMap map)
					{
						map.Insert("__tag", "output_screen__2".ToLoroValueLike());
						return new ISource.OutputScreen(map);
					}
				}
			}

			IObservableProperty<Guid> Id { get; }

			IComplexObservableProperty<Types.IEncoder> Encoder { get; }

			IComplexCollection<Types.IDestination> Destinations { get; }

			IComplexCollection<IDigitalAudio.Types.IDevice.Types.IMap> AudioMap { get; }

			IObservableProperty<bool> IsAudioCustomMapped { get; }

			IComplexObservableProperty<Types.ISource> Source { get; }
		}

		internal sealed class Stream : IStream, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Id_;

			private ComplexObservableProperty<IStream.Types.IEncoder> Encoder_;

			private MapCollection<IStream.Types.IDestination> Destinations_;

			private MapCollection<IDigitalAudio.Types.IDevice.Types.IMap> AudioMap_;

			private BoolObservableProperty IsAudioCustomMapped_;

			private UnionObservableProperty<IStream.Types.ISource> Source_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Id => Id_;

			public IComplexObservableProperty<IStream.Types.IEncoder> Encoder => Encoder_;

			public IComplexCollection<IStream.Types.IDestination> Destinations => Destinations_;

			public IComplexCollection<IDigitalAudio.Types.IDevice.Types.IMap> AudioMap => AudioMap_;

			public IObservableProperty<bool> IsAudioCustomMapped => IsAudioCustomMapped_;

			public IComplexObservableProperty<IStream.Types.ISource> Source => Source_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Id_.UpdateMap(_map);
				Encoder_.UpdateMap(_map);
				Destinations_.UpdateMap(_map);
				AudioMap_.UpdateMap(_map);
				IsAudioCustomMapped_.UpdateMap(_map);
				Source_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Id_.UpdateMapOnInternalMapUpdate(_map);
				Encoder_.UpdateMapOnInternalMapUpdate(_map);
				Destinations_.UpdateMapOnInternalMapUpdate(_map);
				AudioMap_.UpdateMapOnInternalMapUpdate(_map);
				IsAudioCustomMapped_.UpdateMapOnInternalMapUpdate(_map);
				Source_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Stream()
				: this(new LoroMap())
			{
			}

			public Stream(LoroMap values)
			{
				_map = values;
				Id_ = new GuidObservableProperty("id__1", LoroMap);
				Encoder_ = new ComplexObservableProperty<IStream.Types.IEncoder>("encoder__3", LoroMap, new EntityFactory());
				Destinations_ = new MapCollection<IStream.Types.IDestination>(LoroMap, "destinations__4", new EntityFactory());
				AudioMap_ = new MapCollection<IDigitalAudio.Types.IDevice.Types.IMap>(LoroMap, "audio_map__5", new EntityFactory());
				IsAudioCustomMapped_ = new BoolObservableProperty("isAudioCustomMapped__6", LoroMap);
				Source_ = new UnionObservableProperty<IStream.Types.ISource>("Source__union", LoroMap, new IStream.Types.SourceFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Id_.WhenChangeHappens, Encoder_.WhenChangeHappens, Destinations_.WhenChangeHappens, AudioMap_.WhenChangeHappens, IsAudioCustomMapped_.WhenChangeHappens, Source_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Id_.Dispose();
				Encoder_.Dispose();
				Destinations_.Dispose();
				AudioMap_.Dispose();
				IsAudioCustomMapped_.Dispose();
				Source_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Id_.OnDiff(path, diff);
				Encoder_.OnDiff(path, diff);
				Destinations_.OnDiff(path, diff);
				AudioMap_.OnDiff(path, diff);
				IsAudioCustomMapped_.OnDiff(path, diff);
				Source_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}
}
