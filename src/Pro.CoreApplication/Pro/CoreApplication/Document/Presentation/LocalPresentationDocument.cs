using System;
using Pro.CoreApplication.Document.CollectionDocument;

namespace Pro.CoreApplication.Document.Presentation;

public class LocalPresentationDocument : LocalCollectionDocument<PresentationCollectionSelector>
{
	public LocalPresentationDocument(string path, Guid id, DateTimeOffset fileTimestamp)
		: base(path, id, fileTimestamp)
	{
	}
}
