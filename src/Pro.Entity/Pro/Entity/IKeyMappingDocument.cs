using System;
using Pro.Entity.Collections;

namespace Pro.Entity;

public interface IKeyMappingDocument : IEntity, IDisposable
{
	IComplexCollection<IKeyMapping> Keymappings { get; }

	IComplexCollection<IKeyMapping> MacosKeymappings { get; }

	IComplexCollection<IKeyMapping> WindowsKeymappings { get; }
}
