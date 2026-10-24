using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IDigitalAudio : IEntity, IDisposable
{
	public class Types
	{
		public interface IBus : IEntity, IDisposable
		{
			IObservableProperty<string> Name { get; }

			IObservableProperty<bool> Muted { get; }

			IObservableProperty<bool> Solo { get; }

			IObservableProperty<bool> TestTone { get; }

			IObservableProperty<double> MasterLevel { get; }
		}

		internal sealed class Bus : IBus, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty Name_;

			private BoolObservableProperty Muted_;

			private BoolObservableProperty Solo_;

			private BoolObservableProperty TestTone_;

			private DoubleObservableProperty MasterLevel_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<bool> Muted => Muted_;

			public IObservableProperty<bool> Solo => Solo_;

			public IObservableProperty<bool> TestTone => TestTone_;

			public IObservableProperty<double> MasterLevel => MasterLevel_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Name_.UpdateMap(_map);
				Muted_.UpdateMap(_map);
				Solo_.UpdateMap(_map);
				TestTone_.UpdateMap(_map);
				MasterLevel_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Muted_.UpdateMapOnInternalMapUpdate(_map);
				Solo_.UpdateMapOnInternalMapUpdate(_map);
				TestTone_.UpdateMapOnInternalMapUpdate(_map);
				MasterLevel_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Bus()
				: this(new LoroMap())
			{
			}

			public Bus(LoroMap values)
			{
				_map = values;
				Name_ = new StringObservableProperty("name__1", LoroMap);
				Muted_ = new BoolObservableProperty("muted__2", LoroMap);
				Solo_ = new BoolObservableProperty("solo__3", LoroMap);
				TestTone_ = new BoolObservableProperty("test_tone__4", LoroMap);
				MasterLevel_ = new DoubleObservableProperty("master_level__5", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Name_.WhenChangeHappens, Muted_.WhenChangeHappens, Solo_.WhenChangeHappens, TestTone_.WhenChangeHappens, MasterLevel_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Name_.Dispose();
				Muted_.Dispose();
				Solo_.Dispose();
				TestTone_.Dispose();
				MasterLevel_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Name_.OnDiff(path, diff);
				Muted_.OnDiff(path, diff);
				Solo_.OnDiff(path, diff);
				TestTone_.OnDiff(path, diff);
				MasterLevel_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IDevice : IEntity, IDisposable
		{
			public class Types
			{
				public interface IChannel : IEntity, IDisposable
				{
					IObservableProperty<bool> MuteEnable { get; }

					IObservableProperty<bool> SoloEnable { get; }

					IObservableProperty<bool> ToneEnable { get; }

					IObservableProperty<double> AudioDelay { get; }

					IObservableProperty<double> Level { get; }
				}

				internal sealed class Channel : IChannel, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private BoolObservableProperty MuteEnable_;

					private BoolObservableProperty SoloEnable_;

					private BoolObservableProperty ToneEnable_;

					private DoubleObservableProperty AudioDelay_;

					private DoubleObservableProperty Level_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<bool> MuteEnable => MuteEnable_;

					public IObservableProperty<bool> SoloEnable => SoloEnable_;

					public IObservableProperty<bool> ToneEnable => ToneEnable_;

					public IObservableProperty<double> AudioDelay => AudioDelay_;

					public IObservableProperty<double> Level => Level_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						MuteEnable_.UpdateMap(_map);
						SoloEnable_.UpdateMap(_map);
						ToneEnable_.UpdateMap(_map);
						AudioDelay_.UpdateMap(_map);
						Level_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						MuteEnable_.UpdateMapOnInternalMapUpdate(_map);
						SoloEnable_.UpdateMapOnInternalMapUpdate(_map);
						ToneEnable_.UpdateMapOnInternalMapUpdate(_map);
						AudioDelay_.UpdateMapOnInternalMapUpdate(_map);
						Level_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Channel()
						: this(new LoroMap())
					{
					}

					public Channel(LoroMap values)
					{
						_map = values;
						MuteEnable_ = new BoolObservableProperty("mute_enable__1", LoroMap);
						SoloEnable_ = new BoolObservableProperty("solo_enable__2", LoroMap);
						ToneEnable_ = new BoolObservableProperty("tone_enable__3", LoroMap);
						AudioDelay_ = new DoubleObservableProperty("audio_delay__4", LoroMap);
						Level_ = new DoubleObservableProperty("level__5", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(MuteEnable_.WhenChangeHappens, SoloEnable_.WhenChangeHappens, ToneEnable_.WhenChangeHappens, AudioDelay_.WhenChangeHappens, Level_.WhenChangeHappens);
					}

					public void Dispose()
					{
						MuteEnable_.Dispose();
						SoloEnable_.Dispose();
						ToneEnable_.Dispose();
						AudioDelay_.Dispose();
						Level_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						MuteEnable_.OnDiff(path, diff);
						SoloEnable_.OnDiff(path, diff);
						ToneEnable_.OnDiff(path, diff);
						AudioDelay_.OnDiff(path, diff);
						Level_.OnDiff(path, diff);
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
						public enum Type
						{
							Int,
							Float
						}
					}

					IObservableProperty<uint> SampleRate { get; }

					IObservableProperty<uint> BitDepth { get; }

					IObservableProperty<Types.Type> Type { get; }
				}

				internal sealed class Format : IFormat, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private UintObservableProperty SampleRate_;

					private UintObservableProperty BitDepth_;

					private EnumObservableProperty<IFormat.Types.Type> Type_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<uint> SampleRate => SampleRate_;

					public IObservableProperty<uint> BitDepth => BitDepth_;

					public IObservableProperty<IFormat.Types.Type> Type => Type_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						SampleRate_.UpdateMap(_map);
						BitDepth_.UpdateMap(_map);
						Type_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						SampleRate_.UpdateMapOnInternalMapUpdate(_map);
						BitDepth_.UpdateMapOnInternalMapUpdate(_map);
						Type_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Format()
						: this(new LoroMap())
					{
					}

					public Format(LoroMap values)
					{
						_map = values;
						SampleRate_ = new UintObservableProperty("sample_rate__1", LoroMap);
						BitDepth_ = new UintObservableProperty("bit_depth__2", LoroMap);
						Type_ = new EnumObservableProperty<IFormat.Types.Type>("type__3", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(SampleRate_.WhenChangeHappens, BitDepth_.WhenChangeHappens, Type_.WhenChangeHappens);
					}

					public void Dispose()
					{
						SampleRate_.Dispose();
						BitDepth_.Dispose();
						Type_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						SampleRate_.OnDiff(path, diff);
						BitDepth_.OnDiff(path, diff);
						Type_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IMap : IEntity, IDisposable
				{
					IObservableProperty<uint> ChannelIndex { get; }

					ICollection<uint> MappedIndices { get; }
				}

				internal sealed class Map : IMap, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private UintObservableProperty ChannelIndex_;

					private UIntCollection MappedIndices_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<uint> ChannelIndex => ChannelIndex_;

					public ICollection<uint> MappedIndices => MappedIndices_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						ChannelIndex_.UpdateMap(_map);
						MappedIndices_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						ChannelIndex_.UpdateMapOnInternalMapUpdate(_map);
						MappedIndices_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Map()
						: this(new LoroMap())
					{
					}

					public Map(LoroMap values)
					{
						_map = values;
						ChannelIndex_ = new UintObservableProperty("channel_index__1", LoroMap);
						MappedIndices_ = new UIntCollection(LoroMap, "mapped_indices__2");
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = ChannelIndex_.WhenChangeHappens.Merge(MappedIndices_.WhenChangeHappens);
					}

					public void Dispose()
					{
						ChannelIndex_.Dispose();
						MappedIndices_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						ChannelIndex_.OnDiff(path, diff);
						MappedIndices_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}

				public interface IRouting : IEntity, IDisposable
				{
					IComplexCollection<IChannel> Channels { get; }

					IComplexCollection<IMap> Map { get; }

					IObservableProperty<bool> IsCustomMap { get; }

					IComplexObservableProperty<IChannel?> MasterChannel { get; }
				}

				internal sealed class Routing : IRouting, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private MapCollection<IChannel> Channels_;

					private MapCollection<IMap> Map_;

					private BoolObservableProperty IsCustomMap_;

					private OptionalComplexObservableProperty<IChannel> MasterChannel_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IComplexCollection<IChannel> Channels => Channels_;

					public IComplexCollection<IMap> Map => Map_;

					public IObservableProperty<bool> IsCustomMap => IsCustomMap_;

					public IComplexObservableProperty<IChannel?> MasterChannel => MasterChannel_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Channels_.UpdateMap(_map);
						Map_.UpdateMap(_map);
						IsCustomMap_.UpdateMap(_map);
						MasterChannel_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Channels_.UpdateMapOnInternalMapUpdate(_map);
						Map_.UpdateMapOnInternalMapUpdate(_map);
						IsCustomMap_.UpdateMapOnInternalMapUpdate(_map);
						MasterChannel_.UpdateMapOnInternalMapUpdate(_map);
					}

					public Routing()
						: this(new LoroMap())
					{
					}

					public Routing(LoroMap values)
					{
						_map = values;
						Channels_ = new MapCollection<IChannel>(LoroMap, "channels__1", new EntityFactory());
						Map_ = new MapCollection<IMap>(LoroMap, "map__2", new EntityFactory());
						IsCustomMap_ = new BoolObservableProperty("is_custom_map__3", LoroMap);
						MasterChannel_ = new OptionalComplexObservableProperty<IChannel>("master_channel__4", LoroMap, new EntityFactory());
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Channels_.WhenChangeHappens, Map_.WhenChangeHappens, IsCustomMap_.WhenChangeHappens, MasterChannel_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Channels_.Dispose();
						Map_.Dispose();
						IsCustomMap_.Dispose();
						MasterChannel_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Channels_.OnDiff(path, diff);
						Map_.OnDiff(path, diff);
						IsCustomMap_.OnDiff(path, diff);
						MasterChannel_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}
			}

			IObservableProperty<string> Name { get; }

			IObservableProperty<string> RenderId { get; }

			IComplexCollection<Types.IFormat> Formats { get; }

			IComplexObservableProperty<Types.IRouting> Routing { get; }
		}

		internal sealed class Device : IDevice, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty Name_;

			private StringObservableProperty RenderId_;

			private MapCollection<IDevice.Types.IFormat> Formats_;

			private ComplexObservableProperty<IDevice.Types.IRouting> Routing_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<string> RenderId => RenderId_;

			public IComplexCollection<IDevice.Types.IFormat> Formats => Formats_;

			public IComplexObservableProperty<IDevice.Types.IRouting> Routing => Routing_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Name_.UpdateMap(_map);
				RenderId_.UpdateMap(_map);
				Formats_.UpdateMap(_map);
				Routing_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Name_.UpdateMapOnInternalMapUpdate(_map);
				RenderId_.UpdateMapOnInternalMapUpdate(_map);
				Formats_.UpdateMapOnInternalMapUpdate(_map);
				Routing_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Device()
				: this(new LoroMap())
			{
			}

			public Device(LoroMap values)
			{
				_map = values;
				Name_ = new StringObservableProperty("name__1", LoroMap);
				RenderId_ = new StringObservableProperty("renderID__2", LoroMap);
				Formats_ = new MapCollection<IDevice.Types.IFormat>(LoroMap, "formats__3", new EntityFactory());
				Routing_ = new ComplexObservableProperty<IDevice.Types.IRouting>("routing__4", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Name_.WhenChangeHappens, RenderId_.WhenChangeHappens, Formats_.WhenChangeHappens, Routing_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Name_.Dispose();
				RenderId_.Dispose();
				Formats_.Dispose();
				Routing_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Name_.OnDiff(path, diff);
				RenderId_.OnDiff(path, diff);
				Formats_.OnDiff(path, diff);
				Routing_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ISetup : IEntity, IDisposable
		{
			IComplexCollection<IBus> Buses { get; }

			IComplexObservableProperty<IDevice?> MonitorDevice { get; }

			IComplexObservableProperty<IDevice?> MainOutputDevice { get; }

			IObservableProperty<bool> EnableSdiNdiDevice { get; }

			IComplexObservableProperty<IDevice?> SdiNdiDevice { get; }

			IObservableProperty<bool> MonitorOnMains { get; }

			IObservableProperty<bool> DisableMainOutputDevice { get; }
		}

		internal sealed class Setup : ISetup, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private MapCollection<IBus> Buses_;

			private OptionalComplexObservableProperty<IDevice> MonitorDevice_;

			private OptionalComplexObservableProperty<IDevice> MainOutputDevice_;

			private BoolObservableProperty EnableSdiNdiDevice_;

			private OptionalComplexObservableProperty<IDevice> SdiNdiDevice_;

			private BoolObservableProperty MonitorOnMains_;

			private BoolObservableProperty DisableMainOutputDevice_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexCollection<IBus> Buses => Buses_;

			public IComplexObservableProperty<IDevice?> MonitorDevice => MonitorDevice_;

			public IComplexObservableProperty<IDevice?> MainOutputDevice => MainOutputDevice_;

			public IObservableProperty<bool> EnableSdiNdiDevice => EnableSdiNdiDevice_;

			public IComplexObservableProperty<IDevice?> SdiNdiDevice => SdiNdiDevice_;

			public IObservableProperty<bool> MonitorOnMains => MonitorOnMains_;

			public IObservableProperty<bool> DisableMainOutputDevice => DisableMainOutputDevice_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Buses_.UpdateMap(_map);
				MonitorDevice_.UpdateMap(_map);
				MainOutputDevice_.UpdateMap(_map);
				EnableSdiNdiDevice_.UpdateMap(_map);
				SdiNdiDevice_.UpdateMap(_map);
				MonitorOnMains_.UpdateMap(_map);
				DisableMainOutputDevice_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Buses_.UpdateMapOnInternalMapUpdate(_map);
				MonitorDevice_.UpdateMapOnInternalMapUpdate(_map);
				MainOutputDevice_.UpdateMapOnInternalMapUpdate(_map);
				EnableSdiNdiDevice_.UpdateMapOnInternalMapUpdate(_map);
				SdiNdiDevice_.UpdateMapOnInternalMapUpdate(_map);
				MonitorOnMains_.UpdateMapOnInternalMapUpdate(_map);
				DisableMainOutputDevice_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Setup()
				: this(new LoroMap())
			{
			}

			public Setup(LoroMap values)
			{
				_map = values;
				Buses_ = new MapCollection<IBus>(LoroMap, "buses__1", new EntityFactory());
				MonitorDevice_ = new OptionalComplexObservableProperty<IDevice>("monitor_device__2", LoroMap, new EntityFactory());
				MainOutputDevice_ = new OptionalComplexObservableProperty<IDevice>("main_output_device__3", LoroMap, new EntityFactory());
				EnableSdiNdiDevice_ = new BoolObservableProperty("enable_sdi_ndi_device__4", LoroMap);
				SdiNdiDevice_ = new OptionalComplexObservableProperty<IDevice>("sdi_ndi_device__5", LoroMap, new EntityFactory());
				MonitorOnMains_ = new BoolObservableProperty("monitor_on_mains__6", LoroMap);
				DisableMainOutputDevice_ = new BoolObservableProperty("disable_main_output_device__7", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Buses_.WhenChangeHappens, MonitorDevice_.WhenChangeHappens, MainOutputDevice_.WhenChangeHappens, EnableSdiNdiDevice_.WhenChangeHappens, SdiNdiDevice_.WhenChangeHappens, MonitorOnMains_.WhenChangeHappens, DisableMainOutputDevice_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Buses_.Dispose();
				MonitorDevice_.Dispose();
				MainOutputDevice_.Dispose();
				EnableSdiNdiDevice_.Dispose();
				SdiNdiDevice_.Dispose();
				MonitorOnMains_.Dispose();
				DisableMainOutputDevice_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Buses_.OnDiff(path, diff);
				MonitorDevice_.OnDiff(path, diff);
				MainOutputDevice_.OnDiff(path, diff);
				EnableSdiNdiDevice_.OnDiff(path, diff);
				SdiNdiDevice_.OnDiff(path, diff);
				MonitorOnMains_.OnDiff(path, diff);
				DisableMainOutputDevice_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}
}
