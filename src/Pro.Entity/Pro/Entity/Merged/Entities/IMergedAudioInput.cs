using System;
using Pro.Entity.Properties;

namespace Pro.Entity.Merged.Entities;

public interface IMergedAudioInput : ICloudAudioInput, IEntity, IDisposable, IAudioInput
{
	new IObservableProperty<Guid> Uuid { get; }

	new IObservableProperty<string> UserDescription { get; }

	internal ICloudAudioInput Remote { get; }

	internal IAudioInput Local { get; }
}
