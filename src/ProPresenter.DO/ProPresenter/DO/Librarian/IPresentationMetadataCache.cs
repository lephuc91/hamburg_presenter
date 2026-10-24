using System;
using System.Diagnostics.CodeAnalysis;

namespace ProPresenter.DO.Librarian;

public interface IPresentationMetadataCache : IDisposable
{
	void CacheMetadata(string filename, PresentationMetadata presentationMetadata);

	bool TryGetCachedMetadata(string filename, [NotNullWhen(true)] out PresentationMetadata? presentationMetadata);
}
