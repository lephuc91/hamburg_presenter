using System;
using Pro.DO.Transitions;
using ProPresenter.DO.Actions;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide;

namespace ProPresenter.DO.Cues;

public static class CueHelper
{
	public static DocumentCue ToCue(this PresentationBase presentation)
	{
		return new DocumentCue(presentation);
	}

	public static DocumentCue ToCue(this IDocumentAction documentAction)
	{
		return new DocumentCue(documentAction);
	}

	public static SlideCue ToCue(this SlideBase slide, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		return new SlideCue(factoryProvider, slide, transitionDescriptions);
	}

	public static MediaCue ToCue(this MediaBase? media, IApp app, ITransitionDescriptionCollection transitionDescriptions, bool supportsPlaybackMarkers = true)
	{
		return new MediaCue(app, media, transitionDescriptions, supportsPlaybackMarkers);
	}

	public static MediaCue ToCue(this MediaAction mediaAction, bool supportsPlaybackMarkers = true)
	{
		return new MediaCue(mediaAction, supportsPlaybackMarkers);
	}

	public static HeaderCue ToCue(this HeaderAction headerAction)
	{
		return new HeaderCue(headerAction);
	}

	public static bool TryExecute(object item, Action<IDocumentCue, DocumentAction>? documentExecute = null, Action<IMediaCue, MediaAction>? mediaExecute = null, Action<IHeaderCue, HeaderAction>? headerExecute = null)
	{
		if (item is IDocumentCue { DocumentAction: DocumentAction documentAction } documentCue)
		{
			documentExecute?.Invoke(documentCue, documentAction);
			return true;
		}
		if (item is IMediaCue mediaCue)
		{
			MediaAction mediaAction = mediaCue.MediaAction;
			if (mediaAction != null)
			{
				mediaExecute?.Invoke(mediaCue, mediaAction);
				return true;
			}
		}
		if (item is IHeaderCue headerCue)
		{
			HeaderAction headerAction = headerCue.HeaderAction;
			if (headerAction != null)
			{
				headerExecute?.Invoke(headerCue, headerAction);
				return true;
			}
		}
		return false;
	}

	public static MediaCue? ToMediaCue(this IMediaCue cue)
	{
		if (!(cue is MediaCue result))
		{
			return cue?.MediaAction?.ToCue();
		}
		return result;
	}
}
