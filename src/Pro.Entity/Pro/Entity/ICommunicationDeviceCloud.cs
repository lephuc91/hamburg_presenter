using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface ICommunicationDeviceCloud : IEntity, IDisposable
{
	IObservableProperty<Guid> Id { get; }

	IObservableProperty<string> Name { get; }

	IObservableProperty<ICommunicationDevice.Types.DeviceType> DeviceType { get; }

	IObservableProperty<ICommunicationDevice.Types.Behavior> Behavior { get; }
}
