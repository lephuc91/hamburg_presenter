using System;
using Pro.Entity.Properties;

namespace Pro.Entity.Merged.Entities;

public interface IMergedVideoInput : ICloudVideoInput, IEntity, IDisposable, IVideoInput
{
	new IObservableProperty<Guid> Uuid { get; }

	new IObservableProperty<string?> UserDescription { get; }

	internal ICloudVideoInput Remote { get; }

	internal IVideoInput Local { get; }
}
