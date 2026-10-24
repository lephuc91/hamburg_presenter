using System.Collections.Generic;

namespace ProPresenter.Data;

public interface IDocumentDiagnosticsProvider
{
	IReadOnlyList<DocumentInfoEntry> GetDocumentInfoEntries();
}
