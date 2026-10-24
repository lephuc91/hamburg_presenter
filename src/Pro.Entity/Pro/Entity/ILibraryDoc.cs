using System;

namespace Pro.Entity;

public interface ILibraryDoc : IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, ILibrary
{
}
