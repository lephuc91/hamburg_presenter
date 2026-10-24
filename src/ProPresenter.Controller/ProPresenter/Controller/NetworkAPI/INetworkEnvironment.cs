using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public interface INetworkEnvironment : INotifyEnumerableChanged<INetworkEntity>, IEnumerable<INetworkEntity>, IEnumerable, INotifyCollectionChanged
{
	void Update(ProLink.Types.ZeroConfig.Types.NetworkEnvironment proto);
}
