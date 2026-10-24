using System;

namespace Pro.Entity;

public interface ICcliDocumentDoc : IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, ICcliDocument
{
}
