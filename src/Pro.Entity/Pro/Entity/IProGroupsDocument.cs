using System;
using Pro.Entity.Collections;

namespace Pro.Entity;

public interface IProGroupsDocument : IEntity, IDisposable
{
	IComplexCollection<IGroup> Groups { get; }
}
