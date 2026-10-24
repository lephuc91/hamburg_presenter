using System;

namespace Pro.Entity;

public interface IEntityDocument : IEntity, IDisposable, IDocument, ICanExportSnapshot
{
}
