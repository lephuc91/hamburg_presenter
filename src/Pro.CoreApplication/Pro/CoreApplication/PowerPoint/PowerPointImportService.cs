using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using CoreApplication.PowerPointImport;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.CoreApplication.PowerPoint.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.PPTImport;

namespace Pro.CoreApplication.PowerPoint;

public class PowerPointImportService : IPowerPointImportService
{
	private readonly ICorePowerPointImportService _corePowerPointImportService;

	private readonly IFileSystem _fileService;

	public PowerPointImportService(ICorePowerPointImportService corePowerPointImportService, IFileSystem fileService)
	{
		_corePowerPointImportService = corePowerPointImportService;
		_fileService = fileService;
	}

	public bool TryCreatePresentationFromPPTX(string pptFileName, Vector2<double> slideSize, bool ignoreBackgrounds, [NotNullWhen(true)] out string? resultsFolder, out int errorCode)
	{
		resultsFolder = _fileService.Directory.CreateTempSubdirectory().FullName;
		PPTImportParams importParams = new PPTImportParams
		{
			PptxPath = pptFileName,
			ResultFolderPath = resultsFolder,
			SlideHeight = (uint)slideSize.Y,
			SlideWidth = (uint)slideSize.X,
			IgnoreBackgrounds = ignoreBackgrounds
		};
		ImportResult importResult = _corePowerPointImportService.ImportPPT(importParams);
		errorCode = importResult.ErrorCode;
		if (!importResult.Success)
		{
			Log.Error($"Failed to import PowerPoint file: {pptFileName}. Error: {importResult.ErrorCode}");
			_fileService.Directory.Delete(resultsFolder);
			resultsFolder = null;
		}
		return importResult.Success;
	}
}
