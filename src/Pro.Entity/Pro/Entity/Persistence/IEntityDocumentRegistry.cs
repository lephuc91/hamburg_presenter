using System;
using System.Diagnostics.CodeAnalysis;

namespace Pro.Entity.Persistence;

public interface IEntityDocumentRegistry
{
	bool TryGet(Guid id, [NotNullWhen(true)] out IEntityDocument? document);

	void Add(Guid id, IEntityDocument document, string relativeFilePath, DocumentType documentType, Action<ICanExportSnapshot> saveDocument);

	void Remove(Guid id);

	void Register(Guid id, IEntityDocument document, Action<ICanExportSnapshot> saveDocument, string documentName = "");

	void Unregister(Guid id);

	void MarkDocumentAsKnownToCore(Guid id);

	void Reset();
}
