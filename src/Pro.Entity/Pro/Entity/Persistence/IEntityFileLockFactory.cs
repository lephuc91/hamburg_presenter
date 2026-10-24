using System;

namespace Pro.Entity.Persistence;

public interface IEntityFileLockFactory
{
	IDisposable EnterRead(Guid fileId);

	IDisposable EnterWrite(Guid fileId);
}
