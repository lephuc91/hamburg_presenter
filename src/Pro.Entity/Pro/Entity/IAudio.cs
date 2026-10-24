using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IAudio : IEntity, IDisposable
{
	public class Types
	{
		public interface IDevice : IEntity, IDisposable
		{
			public class Types
			{
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
			}

			IObservableProperty<string> Name { get; }

			IObservableProperty<string> RenderId { get; }

			IObservableProperty<uint> InputChannelCount { get; }

			IObservableProperty<uint> OutputChannelCount { get; }

			IComplexCollection<Types.IFormat> Formats { get; }
		}

		internal sealed class Device : IDevice, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty Name_;

			private StringObservableProperty RenderId_;

			private UintObservableProperty InputChannelCount_;

			private UintObservableProperty OutputChannelCount_;

			private MapCollection<IDevice.Types.IFormat> Formats_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<string> RenderId => RenderId_;

			public IObservableProperty<uint> InputChannelCount => InputChannelCount_;

			public IObservableProperty<uint> OutputChannelCount => OutputChannelCount_;

			public IComplexCollection<IDevice.Types.IFormat> Formats => Formats_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Name_.UpdateMap(_map);
				RenderId_.UpdateMap(_map);
				InputChannelCount_.UpdateMap(_map);
				OutputChannelCount_.UpdateMap(_map);
				Formats_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Name_.UpdateMapOnInternalMapUpdate(_map);
				RenderId_.UpdateMapOnInternalMapUpdate(_map);
				InputChannelCount_.UpdateMapOnInternalMapUpdate(_map);
				OutputChannelCount_.UpdateMapOnInternalMapUpdate(_map);
				Formats_.UpdateMapOnInternalMapUpdate(_map);
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
				InputChannelCount_ = new UintObservableProperty("input_channel_count__3", LoroMap);
				OutputChannelCount_ = new UintObservableProperty("output_channel_count__4", LoroMap);
				Formats_ = new MapCollection<IDevice.Types.IFormat>(LoroMap, "formats__5", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Name_.WhenChangeHappens, RenderId_.WhenChangeHappens, InputChannelCount_.WhenChangeHappens, OutputChannelCount_.WhenChangeHappens, Formats_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Name_.Dispose();
				RenderId_.Dispose();
				InputChannelCount_.Dispose();
				OutputChannelCount_.Dispose();
				Formats_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Name_.OnDiff(path, diff);
				RenderId_.OnDiff(path, diff);
				InputChannelCount_.OnDiff(path, diff);
				OutputChannelCount_.OnDiff(path, diff);
				Formats_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ILogicalChannel : IEntity, IDisposable
		{
			public class Types
			{
				public interface IOutputChannel : IEntity, IDisposable
				{
					IObservableProperty<uint> Index { get; }

					IObservableProperty<bool> Muted { get; }

					IObservableProperty<bool> Solo { get; }

					IObservableProperty<bool> TestTone { get; }
				}

				internal sealed class OutputChannel : IOutputChannel, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private UintObservableProperty Index_;

					private BoolObservableProperty Muted_;

					private BoolObservableProperty Solo_;

					private BoolObservableProperty TestTone_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<uint> Index => Index_;

					public IObservableProperty<bool> Muted => Muted_;

					public IObservableProperty<bool> Solo => Solo_;

					public IObservableProperty<bool> TestTone => TestTone_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						Index_.UpdateMap(_map);
						Muted_.UpdateMap(_map);
						Solo_.UpdateMap(_map);
						TestTone_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						Index_.UpdateMapOnInternalMapUpdate(_map);
						Muted_.UpdateMapOnInternalMapUpdate(_map);
						Solo_.UpdateMapOnInternalMapUpdate(_map);
						TestTone_.UpdateMapOnInternalMapUpdate(_map);
					}

					public OutputChannel()
						: this(new LoroMap())
					{
					}

					public OutputChannel(LoroMap values)
					{
						_map = values;
						Index_ = new UintObservableProperty("index__1", LoroMap);
						Muted_ = new BoolObservableProperty("muted__2", LoroMap);
						Solo_ = new BoolObservableProperty("solo__3", LoroMap);
						TestTone_ = new BoolObservableProperty("test_tone__4", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(Index_.WhenChangeHappens, Muted_.WhenChangeHappens, Solo_.WhenChangeHappens, TestTone_.WhenChangeHappens);
					}

					public void Dispose()
					{
						Index_.Dispose();
						Muted_.Dispose();
						Solo_.Dispose();
						TestTone_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						Index_.OnDiff(path, diff);
						Muted_.OnDiff(path, diff);
						Solo_.OnDiff(path, diff);
						TestTone_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}
			}

			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<string> Name { get; }

			IObservableProperty<uint> Index { get; }

			IObservableProperty<bool> Muted { get; }

			IComplexCollection<Types.IOutputChannel> PhysicalAudioChannels { get; }

			IObservableProperty<bool> Solo { get; }

			IObservableProperty<bool> TestTone { get; }
		}

		internal sealed class LogicalChannel : ILogicalChannel, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private StringObservableProperty Name_;

			private UintObservableProperty Index_;

			private BoolObservableProperty Muted_;

			private MapCollection<ILogicalChannel.Types.IOutputChannel> PhysicalAudioChannels_;

			private BoolObservableProperty Solo_;

			private BoolObservableProperty TestTone_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<uint> Index => Index_;

			public IObservableProperty<bool> Muted => Muted_;

			public IComplexCollection<ILogicalChannel.Types.IOutputChannel> PhysicalAudioChannels => PhysicalAudioChannels_;

			public IObservableProperty<bool> Solo => Solo_;

			public IObservableProperty<bool> TestTone => TestTone_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Index_.UpdateMap(_map);
				Muted_.UpdateMap(_map);
				PhysicalAudioChannels_.UpdateMap(_map);
				Solo_.UpdateMap(_map);
				TestTone_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Index_.UpdateMapOnInternalMapUpdate(_map);
				Muted_.UpdateMapOnInternalMapUpdate(_map);
				PhysicalAudioChannels_.UpdateMapOnInternalMapUpdate(_map);
				Solo_.UpdateMapOnInternalMapUpdate(_map);
				TestTone_.UpdateMapOnInternalMapUpdate(_map);
			}

			public LogicalChannel()
				: this(new LoroMap())
			{
			}

			public LogicalChannel(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Index_ = new UintObservableProperty("index__3", LoroMap);
				Muted_ = new BoolObservableProperty("muted__4", LoroMap);
				PhysicalAudioChannels_ = new MapCollection<ILogicalChannel.Types.IOutputChannel>(LoroMap, "physical_audio_channels__5", new EntityFactory());
				Solo_ = new BoolObservableProperty("solo__6", LoroMap);
				TestTone_ = new BoolObservableProperty("test_tone__7", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Index_.WhenChangeHappens, Muted_.WhenChangeHappens, PhysicalAudioChannels_.WhenChangeHappens, Solo_.WhenChangeHappens, TestTone_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				Name_.Dispose();
				Index_.Dispose();
				Muted_.Dispose();
				PhysicalAudioChannels_.Dispose();
				Solo_.Dispose();
				TestTone_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Index_.OnDiff(path, diff);
				Muted_.OnDiff(path, diff);
				PhysicalAudioChannels_.OnDiff(path, diff);
				Solo_.OnDiff(path, diff);
				TestTone_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IOutputSetup : IEntity, IDisposable
		{
			IObservableProperty<Guid> Uuid { get; }

			IComplexObservableProperty<IDevice> AudioDevice { get; }

			IComplexCollection<ILogicalChannel> LogicalChannels { get; }

			IObservableProperty<double> AudioDelay { get; }

			IObservableProperty<double> MasterLevel { get; }

			IComplexCollection<IPhysicalChannel> PhysicalChanels { get; }
		}

		internal sealed class OutputSetup : IOutputSetup, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private ComplexObservableProperty<IDevice> AudioDevice_;

			private MapCollection<ILogicalChannel> LogicalChannels_;

			private DoubleObservableProperty AudioDelay_;

			private DoubleObservableProperty MasterLevel_;

			private MapCollection<IPhysicalChannel> PhysicalChanels_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IComplexObservableProperty<IDevice> AudioDevice => AudioDevice_;

			public IComplexCollection<ILogicalChannel> LogicalChannels => LogicalChannels_;

			public IObservableProperty<double> AudioDelay => AudioDelay_;

			public IObservableProperty<double> MasterLevel => MasterLevel_;

			public IComplexCollection<IPhysicalChannel> PhysicalChanels => PhysicalChanels_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				AudioDevice_.UpdateMap(_map);
				LogicalChannels_.UpdateMap(_map);
				AudioDelay_.UpdateMap(_map);
				MasterLevel_.UpdateMap(_map);
				PhysicalChanels_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				AudioDevice_.UpdateMapOnInternalMapUpdate(_map);
				LogicalChannels_.UpdateMapOnInternalMapUpdate(_map);
				AudioDelay_.UpdateMapOnInternalMapUpdate(_map);
				MasterLevel_.UpdateMapOnInternalMapUpdate(_map);
				PhysicalChanels_.UpdateMapOnInternalMapUpdate(_map);
			}

			public OutputSetup()
				: this(new LoroMap())
			{
			}

			public OutputSetup(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				AudioDevice_ = new ComplexObservableProperty<IDevice>("audio_device__2", LoroMap, new EntityFactory());
				LogicalChannels_ = new MapCollection<ILogicalChannel>(LoroMap, "logical_channels__3", new EntityFactory());
				AudioDelay_ = new DoubleObservableProperty("audio_delay__4", LoroMap);
				MasterLevel_ = new DoubleObservableProperty("master_level__5", LoroMap);
				PhysicalChanels_ = new MapCollection<IPhysicalChannel>(LoroMap, "physical_chanels__6", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, AudioDevice_.WhenChangeHappens, LogicalChannels_.WhenChangeHappens, AudioDelay_.WhenChangeHappens, MasterLevel_.WhenChangeHappens, PhysicalChanels_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				AudioDevice_.Dispose();
				LogicalChannels_.Dispose();
				AudioDelay_.Dispose();
				MasterLevel_.Dispose();
				PhysicalChanels_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				AudioDevice_.OnDiff(path, diff);
				LogicalChannels_.OnDiff(path, diff);
				AudioDelay_.OnDiff(path, diff);
				MasterLevel_.OnDiff(path, diff);
				PhysicalChanels_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IPhysicalChannel : IEntity, IDisposable
		{
			IObservableProperty<uint> Index { get; }

			IObservableProperty<bool> MuteEnable { get; }

			IObservableProperty<bool> SoloEnable { get; }

			IObservableProperty<bool> ToneEnable { get; }
		}

		internal sealed class PhysicalChannel : IPhysicalChannel, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private UintObservableProperty Index_;

			private BoolObservableProperty MuteEnable_;

			private BoolObservableProperty SoloEnable_;

			private BoolObservableProperty ToneEnable_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<uint> Index => Index_;

			public IObservableProperty<bool> MuteEnable => MuteEnable_;

			public IObservableProperty<bool> SoloEnable => SoloEnable_;

			public IObservableProperty<bool> ToneEnable => ToneEnable_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Index_.UpdateMap(_map);
				MuteEnable_.UpdateMap(_map);
				SoloEnable_.UpdateMap(_map);
				ToneEnable_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Index_.UpdateMapOnInternalMapUpdate(_map);
				MuteEnable_.UpdateMapOnInternalMapUpdate(_map);
				SoloEnable_.UpdateMapOnInternalMapUpdate(_map);
				ToneEnable_.UpdateMapOnInternalMapUpdate(_map);
			}

			public PhysicalChannel()
				: this(new LoroMap())
			{
			}

			public PhysicalChannel(LoroMap values)
			{
				_map = values;
				Index_ = new UintObservableProperty("index__1", LoroMap);
				MuteEnable_ = new BoolObservableProperty("mute_enable__2", LoroMap);
				SoloEnable_ = new BoolObservableProperty("solo_enable__3", LoroMap);
				ToneEnable_ = new BoolObservableProperty("tone_enable__4", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Index_.WhenChangeHappens, MuteEnable_.WhenChangeHappens, SoloEnable_.WhenChangeHappens, ToneEnable_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Index_.Dispose();
				MuteEnable_.Dispose();
				SoloEnable_.Dispose();
				ToneEnable_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Index_.OnDiff(path, diff);
				MuteEnable_.OnDiff(path, diff);
				SoloEnable_.OnDiff(path, diff);
				ToneEnable_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ISettingsDocument : IEntity, IDisposable
		{
			IComplexObservableProperty<IOutputSetup> OutputSetup { get; }

			IComplexObservableProperty<IDevice> MonitorDevice { get; }

			IObservableProperty<bool> MonitorOnMains { get; }
		}

		internal sealed class SettingsDocument : ISettingsDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<IOutputSetup> OutputSetup_;

			private ComplexObservableProperty<IDevice> MonitorDevice_;

			private BoolObservableProperty MonitorOnMains_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IOutputSetup> OutputSetup => OutputSetup_;

			public IComplexObservableProperty<IDevice> MonitorDevice => MonitorDevice_;

			public IObservableProperty<bool> MonitorOnMains => MonitorOnMains_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				OutputSetup_.UpdateMap(_map);
				MonitorDevice_.UpdateMap(_map);
				MonitorOnMains_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				OutputSetup_.UpdateMapOnInternalMapUpdate(_map);
				MonitorDevice_.UpdateMapOnInternalMapUpdate(_map);
				MonitorOnMains_.UpdateMapOnInternalMapUpdate(_map);
			}

			public SettingsDocument()
				: this(new LoroMap())
			{
			}

			public SettingsDocument(LoroMap values)
			{
				_map = values;
				OutputSetup_ = new ComplexObservableProperty<IOutputSetup>("output_setup__1", LoroMap, new EntityFactory());
				MonitorDevice_ = new ComplexObservableProperty<IDevice>("monitor_device__2", LoroMap, new EntityFactory());
				MonitorOnMains_ = new BoolObservableProperty("monitor_on_mains__3", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(OutputSetup_.WhenChangeHappens, MonitorDevice_.WhenChangeHappens, MonitorOnMains_.WhenChangeHappens);
			}

			public void Dispose()
			{
				OutputSetup_.Dispose();
				MonitorDevice_.Dispose();
				MonitorOnMains_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				OutputSetup_.OnDiff(path, diff);
				MonitorDevice_.OnDiff(path, diff);
				MonitorOnMains_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}
}
