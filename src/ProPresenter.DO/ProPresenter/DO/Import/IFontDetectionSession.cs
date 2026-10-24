using System;
using System.Collections.Generic;

namespace ProPresenter.DO.Import;

public interface IFontDetectionSession : IDisposable
{
	IObservable<IEnumerable<MissingFontInfo>> WhenMissingFontsDetected { get; }

	IReadOnlyCollection<MissingFontInfo> DetectedMissingFonts { get; }

	bool HasMissingFonts { get; }

	bool IsDetectionComplete { get; }

	void TrackPresentation(IImportRequest request, IImportResult? result);

	void Cancel();
}
