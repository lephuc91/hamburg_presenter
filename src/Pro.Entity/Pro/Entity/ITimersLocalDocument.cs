using System;
using Pro.Entity.Collections;

namespace Pro.Entity;

public interface ITimersLocalDocument : IEntity, IDisposable
{
	IComplexCollection<ILocalTimer> Timers { get; }
}
