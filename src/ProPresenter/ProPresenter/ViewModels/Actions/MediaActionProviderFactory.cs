using System.Collections.Generic;
using System.IO;
using Pro.DO.Transitions;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.ViewModels.Presentation;

namespace ProPresenter.ViewModels.Actions;

public static class MediaActionProviderFactory
{
	public static IMediaActionProvider Create(IEnumerable<MediaCue> mediaCues, bool shouldCloneAction)
	{
		return new PresentationMediaCueProvider(mediaCues, shouldCloneAction);
	}

	public static IMediaActionProvider Create(IEnumerable<FileInfo> files, IActionRepoContainer repoContainer, bool convertToForeground, IApp app, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, string containerId)
	{
		return Create(files, (repoContainer as IDocumentCue)?.DocumentAction?.Presentation, convertToForeground, app, importProcessFactory, mediaFactory, transitionDescriptions, containerId);
	}

	public static IMediaActionProvider Create(IEnumerable<FileInfo> files, IPresentation? presentation, bool convertToForeground, IApp app, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, string containerId)
	{
		return new PresentationMediaFileProvider(files, new PresentationMediaThumbnailUpdater(presentation), convertToForeground, app, importProcessFactory, mediaFactory, transitionDescriptions, containerId);
	}

	public static IMediaActionProvider Create(MediaType mediaType, IActionRepoContainer repoContainer, bool convertToForeground, IApp app, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, string containerId)
	{
		return new PresentationMediaTypeActionProvider(mediaType, (repoContainer as IDocumentCue)?.DocumentAction?.Presentation, convertToForeground, app, importProcessFactory, mediaFactory, transitionDescriptions, containerId);
	}
}
