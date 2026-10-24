using System;
using System.Reactive;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface ICommunicationDeviceLocal : IEntity, IDisposable
{
	public class Types
	{
		public interface IHardwareType : IEntity, IDisposable
		{
			public interface ISerial : IHardwareType, IEntity, IDisposable, IObservableProperty<ICommunicationDevice.Types.ISerialHardware>
			{
			}

			public interface ITcpNetwork : IHardwareType, IEntity, IDisposable, IObservableProperty<ICommunicationDevice.Types.ITcpHardware>
			{
			}

			public interface IUdpNetwork : IHardwareType, IEntity, IDisposable, IObservableProperty<ICommunicationDevice.Types.IUdpHardware>
			{
			}

			public interface IArtnet : IHardwareType, IEntity, IDisposable, IObservableProperty<ICommunicationDevice.Types.IArtnetHardware>
			{
			}

			public interface IMidi : IHardwareType, IEntity, IDisposable, IObservableProperty<ICommunicationDevice.Types.IMidiHardware>
			{
			}

			internal class Serial : ISerial, IHardwareType, IEntity, IDisposable, IObservableProperty<ICommunicationDevice.Types.ISerialHardware>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICommunicationDevice.Types.ISerialHardware> _Serial_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Serial_.WhenChangeHappens;

				public IObservable<ICommunicationDevice.Types.ISerialHardware> WhenValueChanges => _Serial_.WhenValueChanges;

				public ICommunicationDevice.Types.ISerialHardware Value => _Serial_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Serial_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Serial_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "serial__6".ToLoroValueLike());
					return loroMap;
				}

				public Serial()
					: this(InitializeMap())
				{
				}

				public Serial(LoroMap values)
				{
					_map = values;
					_Serial_ = new ComplexObservableProperty<ICommunicationDevice.Types.ISerialHardware>("serial__6", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Serial_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Serial_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Serial_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICommunicationDevice.Types.ISerialHardware value)
				{
					_Serial_.Set(value);
				}
			}

			internal class TcpNetwork : ITcpNetwork, IHardwareType, IEntity, IDisposable, IObservableProperty<ICommunicationDevice.Types.ITcpHardware>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICommunicationDevice.Types.ITcpHardware> _TcpNetwork_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _TcpNetwork_.WhenChangeHappens;

				public IObservable<ICommunicationDevice.Types.ITcpHardware> WhenValueChanges => _TcpNetwork_.WhenValueChanges;

				public ICommunicationDevice.Types.ITcpHardware Value => _TcpNetwork_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_TcpNetwork_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_TcpNetwork_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "tcp_network__7".ToLoroValueLike());
					return loroMap;
				}

				public TcpNetwork()
					: this(InitializeMap())
				{
				}

				public TcpNetwork(LoroMap values)
				{
					_map = values;
					_TcpNetwork_ = new ComplexObservableProperty<ICommunicationDevice.Types.ITcpHardware>("tcp_network__7", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_TcpNetwork_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_TcpNetwork_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_TcpNetwork_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICommunicationDevice.Types.ITcpHardware value)
				{
					_TcpNetwork_.Set(value);
				}
			}

			internal class UdpNetwork : IUdpNetwork, IHardwareType, IEntity, IDisposable, IObservableProperty<ICommunicationDevice.Types.IUdpHardware>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICommunicationDevice.Types.IUdpHardware> _UdpNetwork_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _UdpNetwork_.WhenChangeHappens;

				public IObservable<ICommunicationDevice.Types.IUdpHardware> WhenValueChanges => _UdpNetwork_.WhenValueChanges;

				public ICommunicationDevice.Types.IUdpHardware Value => _UdpNetwork_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_UdpNetwork_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_UdpNetwork_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "udp_network__8".ToLoroValueLike());
					return loroMap;
				}

				public UdpNetwork()
					: this(InitializeMap())
				{
				}

				public UdpNetwork(LoroMap values)
				{
					_map = values;
					_UdpNetwork_ = new ComplexObservableProperty<ICommunicationDevice.Types.IUdpHardware>("udp_network__8", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_UdpNetwork_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_UdpNetwork_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_UdpNetwork_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICommunicationDevice.Types.IUdpHardware value)
				{
					_UdpNetwork_.Set(value);
				}
			}

			internal class Artnet : IArtnet, IHardwareType, IEntity, IDisposable, IObservableProperty<ICommunicationDevice.Types.IArtnetHardware>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICommunicationDevice.Types.IArtnetHardware> _Artnet_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Artnet_.WhenChangeHappens;

				public IObservable<ICommunicationDevice.Types.IArtnetHardware> WhenValueChanges => _Artnet_.WhenValueChanges;

				public ICommunicationDevice.Types.IArtnetHardware Value => _Artnet_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Artnet_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Artnet_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "artnet__9".ToLoroValueLike());
					return loroMap;
				}

				public Artnet()
					: this(InitializeMap())
				{
				}

				public Artnet(LoroMap values)
				{
					_map = values;
					_Artnet_ = new ComplexObservableProperty<ICommunicationDevice.Types.IArtnetHardware>("artnet__9", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Artnet_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Artnet_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Artnet_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICommunicationDevice.Types.IArtnetHardware value)
				{
					_Artnet_.Set(value);
				}
			}

			internal class Midi : IMidi, IHardwareType, IEntity, IDisposable, IObservableProperty<ICommunicationDevice.Types.IMidiHardware>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICommunicationDevice.Types.IMidiHardware> _Midi_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _Midi_.WhenChangeHappens;

				public IObservable<ICommunicationDevice.Types.IMidiHardware> WhenValueChanges => _Midi_.WhenValueChanges;

				public ICommunicationDevice.Types.IMidiHardware Value => _Midi_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_Midi_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_Midi_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "midi__10".ToLoroValueLike());
					return loroMap;
				}

				public Midi()
					: this(InitializeMap())
				{
				}

				public Midi(LoroMap values)
				{
					_map = values;
					_Midi_ = new ComplexObservableProperty<ICommunicationDevice.Types.IMidiHardware>("midi__10", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_Midi_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_Midi_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_Midi_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICommunicationDevice.Types.IMidiHardware value)
				{
					_Midi_.Set(value);
				}
			}
		}

		internal class HardwareTypeFactory : IUnionValueFactory<IHardwareType>
		{
			public string SelectionKey => "__tag";

			public IHardwareType? CreateInstance(LoroMap map)
			{
				return map.Get("__tag").ToStringValue() switch
				{
					"serial__6" => new IHardwareType.Serial(map), 
					"tcp_network__7" => new IHardwareType.TcpNetwork(map), 
					"udp_network__8" => new IHardwareType.UdpNetwork(map), 
					"artnet__9" => new IHardwareType.Artnet(map), 
					"midi__10" => new IHardwareType.Midi(map), 
					_ => null, 
				};
			}

			public IHardwareType CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "serial__6".ToLoroValueLike());
				return new IHardwareType.Serial(map);
			}
		}
	}

	IObservableProperty<Guid> Id { get; }

	IObservableProperty<bool> Connected { get; }

	IObservableProperty<bool> AutoReconnect { get; }

	IObservableProperty<string?> BundleName { get; }

	IObservableProperty<string?> BundleIdentifier { get; }

	IComplexCollection<ICommunicationDeviceOption> Options { get; }

	IComplexObservableProperty<Types.IHardwareType> HardwareType { get; }
}
