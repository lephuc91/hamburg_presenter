using System.Diagnostics.CodeAnalysis;
using Pro.Common.Mathematics;

namespace Pro.CoreApplication.PowerPoint;

public interface IPowerPointImportService
{
	bool TryCreatePresentationFromPPTX(string pptFileName, Vector2<double> slideSize, bool ignoreBackgrounds, [NotNullWhen(true)] out string? resultsFolder, out int errorCode);
}
