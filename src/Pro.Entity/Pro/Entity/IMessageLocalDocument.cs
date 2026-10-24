using System;
using Pro.Entity.Collections;

namespace Pro.Entity;

public interface IMessageLocalDocument : IEntity, IDisposable
{
	IComplexCollection<ILocalMessage> Messages { get; }
}
