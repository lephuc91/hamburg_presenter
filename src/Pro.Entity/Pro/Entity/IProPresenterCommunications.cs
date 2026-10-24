using System;
using Pro.Entity.Collections;

namespace Pro.Entity;

public interface IProPresenterCommunications : IEntity, IDisposable
{
	IComplexCollection<ICommunicationDeviceCloud> Devices { get; }
}
