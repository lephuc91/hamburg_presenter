using System;

namespace Pro.Entity;

public interface ITestPatternDocumentDoc : IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, ITestPatternDocument
{
}
