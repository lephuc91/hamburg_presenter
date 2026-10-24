using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface ICloudAudioInput : IEntity, IDisposable
{
	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string> UserDescription { get; }
}
