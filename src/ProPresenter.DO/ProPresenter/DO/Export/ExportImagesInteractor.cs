using System;
using System.Collections.Generic;
using System.Linq;
using Pro.DO.Triggering;
using Pro.Localization;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Export;

public class ExportImagesInteractor : IExportImagesInteractor
{
	private readonly Func<IEnumerable<IDocumentCue>> _getTargetCues;

	private readonly IExportProcessFactory _exportProcessFactory;

	public ExportImagesInteractor(Func<IEnumerable<IDocumentCue>> getTargetCues, IExportProcessFactory exportProcessFactory)
	{
		_getTargetCues = getTargetCues;
		_exportProcessFactory = exportProcessFactory;
	}

	public string GetInitialExportName()
	{
		return GetPresentationExportName(LocalizedStrings.Get("EXPORT_IMAGES_FILENAME_placeholder"));
	}

	public bool CanExecute()
	{
		List<IDocumentCue> source = _getTargetCues().ToList();
		List<IDocumentCue> source2 = source.Where((IDocumentCue c) => c.DocumentAction?.Presentation is MultiTracksPresentation).ToList();
		if (source2.Any())
		{
			if (source.Any())
			{
				return source2.All((IDocumentCue c) => ((MultiTracksPresentation)(c.DocumentAction?.Presentation))?.IsAvailable ?? false);
			}
			return false;
		}
		return _getTargetCues().Any();
	}

	public void Execute(IExportImageSettings settings)
	{
		_exportProcessFactory.Create(_getTargetCues(), settings).StartExport();
	}

	private string GetPresentationExportName(string nameForMultipleCues)
	{
		IEnumerable<IDocumentCue> source = _getTargetCues();
		if (source.Count() != 1)
		{
			return nameForMultipleCues;
		}
		return (source.First() as Cue)?.Name ?? string.Empty;
	}
}
