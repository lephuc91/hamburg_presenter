using System;

namespace Pro.Entity;

public interface IMessageDocumentDoc : IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IMessageDocument
{
}
