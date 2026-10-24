using System;
using Pro.Entity.Collections;

namespace Pro.Entity;

public interface IProPresenterLocalCommunications : IEntity, IDisposable
{
	IComplexCollection<ICommunicationDeviceLocal> Devices { get; }
}
