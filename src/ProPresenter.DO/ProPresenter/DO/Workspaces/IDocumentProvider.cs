using System;
using Pro.CoreApplication.Document;

namespace ProPresenter.DO.Workspaces;

public interface IDocumentProvider
{
	Guid DocumentId { get; }

	IDocument? GetDocument();
}
