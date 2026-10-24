using System.IO;
using Pro.DO.Storage;
using ProPresenter.DO.Cues;

namespace ProPresenter.Controller.Remote.Apps;

internal class PresentationPathProvider : IPresentationPathProvider
{
	public string GetPath(IDocumentCue documentCue)
	{
		RelativePath relativePath = documentCue?.DocumentAction?.Presentation?.SourceFile;
		return (((object)relativePath != null) ? ((string)relativePath) : string.Empty).Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
	}
}
