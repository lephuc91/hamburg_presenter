using System;
using System.Threading.Tasks;
using Pro.CoreApplication.Document.Interaction;

namespace Pro.CoreApplication.Document;

public interface IDocumentService
{
	IObservable<DocumentPatch> WhenPatchReceived { get; }

	IObservable<Guid> WhenDocumentRequested { get; }

	IObservable<DocumentAdd> WhenDocumentAdded { get; }

	IObservable<DocumentAvailable> WhenDocumentAvailable { get; }

	IObservable<DocumentRelocate> WhenDocumentRelocated { get; }

	IObservable<DocumentRemove> WhenDocumentRemoved { get; }

	Task LoadAsync(Guid documentId, byte[] data);

	Task PatchAsync(DocumentPatch patch);

	Task AddAsync(Guid documentId, byte[] data, string relativeFilePath, DocumentType documentType);

	Task RelocateAsync(Guid documentId, DocumentType documentType, string toRelativeFilePath);

	Task RemoveAsync(Guid documentId);
}
