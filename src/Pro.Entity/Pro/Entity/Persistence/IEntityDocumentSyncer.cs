using System;

namespace Pro.Entity.Persistence;

public interface IEntityDocumentSyncer<out TDocument> : IDisposable where TDocument : IEntityDocument
{
	TDocument Document { get; }

	Guid Id { get; }

	void RenameFile(string newBaseFileName);

	void MoveFile(string newContainingDirectory, string? newBaseFileName = null);

	void FileRenamed(string newBaseFileName);

	void FileMoved(string newContainingDirectory, string? newBaseFileName = null);

	void Delete();

	void AddToDocumentRegistry(string relativeDirectoryPath, DocumentType documentType);
}
