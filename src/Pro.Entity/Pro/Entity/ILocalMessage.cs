using System;
using Pro.Entity.Collections;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface ILocalMessage : IEntity, IDisposable
{
	IObservableProperty<Guid> Uuid { get; }

	IComplexCollection<IMessage.Types.ITokenValue> TokenValues { get; }
}
