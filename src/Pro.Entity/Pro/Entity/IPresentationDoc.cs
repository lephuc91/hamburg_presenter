using System;

namespace Pro.Entity;

public interface IPresentationDoc : IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IPresentation
{
}
