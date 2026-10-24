using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface ICloudVideoInput : IEntity, IDisposable
{
	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string?> UserDescription { get; }

	IObservableProperty<Url?> ThumbnailPath { get; }
}
