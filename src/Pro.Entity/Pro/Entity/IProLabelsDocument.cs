using System;
using Pro.Entity.Collections;

namespace Pro.Entity;

public interface IProLabelsDocument : IEntity, IDisposable
{
	IComplexCollection<IAction.Types.ILabel> Labels { get; }
}
