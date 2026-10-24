using System;
using Pro.CoreApplication.Document.CollectionDocument;

namespace Pro.CoreApplication.Document.Theme;

public class LocalThemeDocument : LocalCollectionDocument<ThemeCollectionSelector>
{
	public LocalThemeDocument(string path, Guid id, DateTimeOffset fileTimestamp)
		: base(path, id, fileTimestamp)
	{
	}
}
