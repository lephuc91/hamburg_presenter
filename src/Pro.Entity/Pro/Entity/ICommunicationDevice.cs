using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface ICommunicationDevice : IEntity, IDisposable
{
	public class Types
	{
		public interface IArtnetHardware : IEntity, IDisposable
		{
		}

		internal sealed class ArtnetHardware : IArtnetHardware, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

			public ArtnetHardware()
				: this(new LoroMap())
			{
			}

			public ArtnetHardware(LoroMap values)
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

		public interface IMidiHardware : IEntity, IDisposable
		{
		}

		internal sealed class MidiHardware : IMidiHardware, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
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

			public MidiHardware()
				: this(new LoroMap())
			{
			}

			public MidiHardware(LoroMap values)
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

		public interface ISerialHardware : IEntity, IDisposable
		{
			public class Types
			{
				public enum DataBits
				{
					_5,
					_6,
					_7,
					_8
				}

				public enum Hfci
				{
					None,
					Rts,
					Dtr
				}

				public enum Hfco
				{
					None,
					Cts,
					Dsr,
					Car
				}

				public enum Parity
				{
					None,
					Odd,
					Even
				}

				public enum Speed
				{
					_1200 = 0,
					_1800 = 1,
					_2400 = 2,
					_4800 = 3,
					_7200 = 4,
					_9600 = 5,
					_14400 = 7,
					_19200 = 8,
					_28800 = 9,
					_38400 = 10,
					_57600 = 11,
					_62500 = 12,
					_76800 = 13,
					_115200 = 14,
					_230400 = 15
				}

				public enum StopBits
				{
					_1,
					_2
				}
			}

			IObservableProperty<string> InterfaceId { get; }

			IObservableProperty<string> Name { get; }

			IObservableProperty<Types.Speed> Speed { get; }

			IObservableProperty<Types.DataBits> DataBits { get; }

			IObservableProperty<Types.Parity> Parity { get; }

			IObservableProperty<Types.StopBits> StopBits { get; }

			IObservableProperty<Types.Hfci> Hfci { get; }

			IObservableProperty<Types.Hfco> Hfco { get; }
		}

		internal sealed class SerialHardware : ISerialHardware, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty InterfaceId_;

			private StringObservableProperty Name_;

			private EnumObservableProperty<ISerialHardware.Types.Speed> Speed_;

			private EnumObservableProperty<ISerialHardware.Types.DataBits> DataBits_;

			private EnumObservableProperty<ISerialHardware.Types.Parity> Parity_;

			private EnumObservableProperty<ISerialHardware.Types.StopBits> StopBits_;

			private EnumObservableProperty<ISerialHardware.Types.Hfci> Hfci_;

			private EnumObservableProperty<ISerialHardware.Types.Hfco> Hfco_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> InterfaceId => InterfaceId_;

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<ISerialHardware.Types.Speed> Speed => Speed_;

			public IObservableProperty<ISerialHardware.Types.DataBits> DataBits => DataBits_;

			public IObservableProperty<ISerialHardware.Types.Parity> Parity => Parity_;

			public IObservableProperty<ISerialHardware.Types.StopBits> StopBits => StopBits_;

			public IObservableProperty<ISerialHardware.Types.Hfci> Hfci => Hfci_;

			public IObservableProperty<ISerialHardware.Types.Hfco> Hfco => Hfco_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				InterfaceId_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Speed_.UpdateMap(_map);
				DataBits_.UpdateMap(_map);
				Parity_.UpdateMap(_map);
				StopBits_.UpdateMap(_map);
				Hfci_.UpdateMap(_map);
				Hfco_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				InterfaceId_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Speed_.UpdateMapOnInternalMapUpdate(_map);
				DataBits_.UpdateMapOnInternalMapUpdate(_map);
				Parity_.UpdateMapOnInternalMapUpdate(_map);
				StopBits_.UpdateMapOnInternalMapUpdate(_map);
				Hfci_.UpdateMapOnInternalMapUpdate(_map);
				Hfco_.UpdateMapOnInternalMapUpdate(_map);
			}

			public SerialHardware()
				: this(new LoroMap())
			{
			}

			public SerialHardware(LoroMap values)
			{
				_map = values;
				InterfaceId_ = new StringObservableProperty("interface_id__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Speed_ = new EnumObservableProperty<ISerialHardware.Types.Speed>("speed__3", LoroMap);
				DataBits_ = new EnumObservableProperty<ISerialHardware.Types.DataBits>("data_bits__4", LoroMap);
				Parity_ = new EnumObservableProperty<ISerialHardware.Types.Parity>("parity__5", LoroMap);
				StopBits_ = new EnumObservableProperty<ISerialHardware.Types.StopBits>("stop_bits__6", LoroMap);
				Hfci_ = new EnumObservableProperty<ISerialHardware.Types.Hfci>("hfci__7", LoroMap);
				Hfco_ = new EnumObservableProperty<ISerialHardware.Types.Hfco>("hfco__8", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(InterfaceId_.WhenChangeHappens, Name_.WhenChangeHappens, Speed_.WhenChangeHappens, DataBits_.WhenChangeHappens, Parity_.WhenChangeHappens, StopBits_.WhenChangeHappens, Hfci_.WhenChangeHappens, Hfco_.WhenChangeHappens);
			}

			public void Dispose()
			{
				InterfaceId_.Dispose();
				Name_.Dispose();
				Speed_.Dispose();
				DataBits_.Dispose();
				Parity_.Dispose();
				StopBits_.Dispose();
				Hfci_.Dispose();
				Hfco_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				InterfaceId_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Speed_.OnDiff(path, diff);
				DataBits_.OnDiff(path, diff);
				Parity_.OnDiff(path, diff);
				StopBits_.OnDiff(path, diff);
				Hfci_.OnDiff(path, diff);
				Hfco_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ITcpHardware : IEntity, IDisposable
		{
			public class Types
			{
				public enum Mode
				{
					ConnectTo,
					AcceptOn
				}
			}

			IObservableProperty<string> InterfaceId { get; }

			IObservableProperty<string> Name { get; }

			IObservableProperty<string> Address { get; }

			IObservableProperty<uint> Port { get; }

			IObservableProperty<Types.Mode> Mode { get; }
		}

		internal sealed class TcpHardware : ITcpHardware, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty InterfaceId_;

			private StringObservableProperty Name_;

			private StringObservableProperty Address_;

			private UintObservableProperty Port_;

			private EnumObservableProperty<ITcpHardware.Types.Mode> Mode_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> InterfaceId => InterfaceId_;

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<string> Address => Address_;

			public IObservableProperty<uint> Port => Port_;

			public IObservableProperty<ITcpHardware.Types.Mode> Mode => Mode_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				InterfaceId_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Address_.UpdateMap(_map);
				Port_.UpdateMap(_map);
				Mode_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				InterfaceId_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Address_.UpdateMapOnInternalMapUpdate(_map);
				Port_.UpdateMapOnInternalMapUpdate(_map);
				Mode_.UpdateMapOnInternalMapUpdate(_map);
			}

			public TcpHardware()
				: this(new LoroMap())
			{
			}

			public TcpHardware(LoroMap values)
			{
				_map = values;
				InterfaceId_ = new StringObservableProperty("interface_id__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Address_ = new StringObservableProperty("address__3", LoroMap);
				Port_ = new UintObservableProperty("port__4", LoroMap);
				Mode_ = new EnumObservableProperty<ITcpHardware.Types.Mode>("mode__5", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(InterfaceId_.WhenChangeHappens, Name_.WhenChangeHappens, Address_.WhenChangeHappens, Port_.WhenChangeHappens, Mode_.WhenChangeHappens);
			}

			public void Dispose()
			{
				InterfaceId_.Dispose();
				Name_.Dispose();
				Address_.Dispose();
				Port_.Dispose();
				Mode_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				InterfaceId_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Address_.OnDiff(path, diff);
				Port_.OnDiff(path, diff);
				Mode_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IUdpHardware : IEntity, IDisposable
		{
			public class Types
			{
				public enum Mode
				{
					Connect,
					Listen,
					MulticastListen,
					Broadcast
				}
			}

			IObservableProperty<string> InterfaceId { get; }

			IObservableProperty<string> Name { get; }

			IObservableProperty<string> Address { get; }

			IObservableProperty<uint> Port { get; }

			IObservableProperty<Types.Mode> Mode { get; }
		}

		internal sealed class UdpHardware : IUdpHardware, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty InterfaceId_;

			private StringObservableProperty Name_;

			private StringObservableProperty Address_;

			private UintObservableProperty Port_;

			private EnumObservableProperty<IUdpHardware.Types.Mode> Mode_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> InterfaceId => InterfaceId_;

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<string> Address => Address_;

			public IObservableProperty<uint> Port => Port_;

			public IObservableProperty<IUdpHardware.Types.Mode> Mode => Mode_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				InterfaceId_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Address_.UpdateMap(_map);
				Port_.UpdateMap(_map);
				Mode_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				InterfaceId_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Address_.UpdateMapOnInternalMapUpdate(_map);
				Port_.UpdateMapOnInternalMapUpdate(_map);
				Mode_.UpdateMapOnInternalMapUpdate(_map);
			}

			public UdpHardware()
				: this(new LoroMap())
			{
			}

			public UdpHardware(LoroMap values)
			{
				_map = values;
				InterfaceId_ = new StringObservableProperty("interface_id__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Address_ = new StringObservableProperty("address__3", LoroMap);
				Port_ = new UintObservableProperty("port__4", LoroMap);
				Mode_ = new EnumObservableProperty<IUdpHardware.Types.Mode>("mode__5", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(InterfaceId_.WhenChangeHappens, Name_.WhenChangeHappens, Address_.WhenChangeHappens, Port_.WhenChangeHappens, Mode_.WhenChangeHappens);
			}

			public void Dispose()
			{
				InterfaceId_.Dispose();
				Name_.Dispose();
				Address_.Dispose();
				Port_.Dispose();
				Mode_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				InterfaceId_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Address_.OnDiff(path, diff);
				Port_.OnDiff(path, diff);
				Mode_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public enum Behavior
		{
			Controller,
			Device
		}

		public enum DeviceType
		{
			Dmx,
			Midi,
			Amp,
			Citp,
			GlobalCache,
			Gvg100,
			Rosstalk,
			SonyBvs,
			SonyBvw,
			Vdcp,
			AllAmerican8000,
			AllAmerican9000,
			Daktronics,
			DaktronicsTv,
			ElectroMech,
			Eversan,
			FairPlayMp70,
			Harris,
			Jugs,
			Oes,
			Scorebird,
			Scorebot,
			Stalker,
			StatCrew
		}
	}
}
