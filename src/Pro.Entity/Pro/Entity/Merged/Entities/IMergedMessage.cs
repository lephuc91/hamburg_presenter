using System;
using Pro.Entity.Properties;

namespace Pro.Entity.Merged.Entities;

public interface IMergedMessage : IMessage, IEntity, IDisposable, ILocalMessage
{
	new IObservableProperty<Guid> Uuid { get; }

	internal IMessage Remote { get; }

	internal ILocalMessage Local { get; }
}
