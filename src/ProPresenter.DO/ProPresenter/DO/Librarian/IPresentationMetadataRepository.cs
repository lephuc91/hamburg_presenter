using System;
using System.Diagnostics.CodeAnalysis;

namespace ProPresenter.DO.Librarian;

public interface IPresentationMetadataRepository : IDisposable
{
	bool TryGetCachedMetadata(string key, string fingerprint, [NotNullWhen(true)] out PresentationMetadata? presentationMetadata);

	void CacheMetadata(string key, string fingerprint, PresentationMetadata presentationMetadata);
}
