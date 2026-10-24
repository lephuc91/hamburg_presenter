using System;
using Pro.Entity.Collections;

namespace Pro.Entity;

public interface ITimersDocument : IEntity, IDisposable
{
	IComplexCollection<ITimer> Timers { get; }
}
