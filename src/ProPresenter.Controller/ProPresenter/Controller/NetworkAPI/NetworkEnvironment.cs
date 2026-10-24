using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public class NetworkEnvironment : ImmutableObservableCollection<INetworkEntity>, INetworkEnvironment, INotifyEnumerableChanged<INetworkEntity>, IEnumerable<INetworkEntity>, IEnumerable, INotifyCollectionChanged
{
	private readonly Dictionary<IMessage, INetworkEntity> _entities = new Dictionary<IMessage, INetworkEntity>();

	public void Update(ProLink.Types.ZeroConfig.Types.NetworkEnvironment proto)
	{
		IEnumerable<IMessage> all = ((IEnumerable<IMessage>)proto.AvailableGroups).Concat((IEnumerable<IMessage>)proto.AvailableDevices);
		(from k in _entities.Keys.ToArray()
			where !all.Contains(k)
			select k).ForEach(Remove);
		all.Except(_entities.Keys).ForEach(Add);
	}

	private void Add(IMessage proto)
	{
		INetworkEntity networkEntity;
		if (!(proto is ProLink.Types.GroupDefinition group))
		{
			if (!(proto is ProLink.Types.MemberStatus device))
			{
				throw new NotSupportedException();
			}
			networkEntity = new AvailableDevice(device);
		}
		else
		{
			networkEntity = new AvailableGroup(group);
		}
		INetworkEntity networkEntity2 = networkEntity;
		base.Collection.Add(networkEntity2);
		_entities.Add(proto, networkEntity2);
	}

	private void Remove(IMessage proto)
	{
		if (_entities.TryGetValue(proto, out INetworkEntity value))
		{
			base.Collection.Remove(value);
			_entities.Remove(proto);
		}
	}
}
