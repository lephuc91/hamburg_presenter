using System;
using Pro.Entity.Collections;

namespace Pro.Entity;

public interface IMessageDocument : IEntity, IDisposable
{
	IComplexCollection<IMessage> Messages { get; }
}
