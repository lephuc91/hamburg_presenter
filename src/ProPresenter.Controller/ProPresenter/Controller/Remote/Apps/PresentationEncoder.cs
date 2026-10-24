using System;
using System.Linq;
using Pro.Common.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;

namespace ProPresenter.Controller.Remote.Apps;

public class PresentationEncoder : IPresentationEncoder
{
	private readonly ISlidePreviewEncoder _slidePreviewEncoder;

	private readonly IPresentationPathProvider _pathProvider;

	public PresentationEncoder(ISlidePreviewEncoder? slidePreviewEncoder = null, IPresentationPathProvider? pathProvider = null)
	{
		_slidePreviewEncoder = slidePreviewEncoder ?? new SlidePreviewEncoder();
		_pathProvider = pathProvider ?? new PresentationPathProvider();
	}

	public PresentationResponse Encode(IDocumentCue documentCue, string action, int slideQuality)
	{
		return Encode(documentCue, _pathProvider.GetPath(documentCue), action, slideQuality);
	}

	public PresentationResponse Encode(IDocumentCue documentCue, string path, string action, int slideQuality)
	{
		return new PresentationResponse
		{
			Action = action,
			Path = path,
			Presentation = EncodePresentation(documentCue, slideQuality)
		};
	}

	private Presentation EncodePresentation(IDocumentCue documentCue, int slideQuality, Arrangement? arrangement = null)
	{
		IDocumentAction documentAction = documentCue.DocumentAction;
		IPresentation presentation = documentAction?.Presentation;
		string path = _pathProvider.GetPath(documentCue);
		Presentation obj = new Presentation
		{
			Name = documentCue.GetEncodedName(arrangement),
			Path = path,
			CurrentLocation = path,
			HasTimeline = (presentation?.PresentationTimeline.Any() ?? false)
		};
		object slideGroups;
		if (!(documentAction?.Presentation?.IsAvailable ?? true))
		{
			slideGroups = Array.Empty<SlideGroup>();
		}
		else
		{
			slideGroups = (arrangement ?? documentAction?.ActiveArrangement)?.Select((CueGroup g) => EncodeSlideGroups(g, slideQuality)).ToArray();
		}
		obj.SlideGroups = (SlideGroup[]?)slideGroups;
		obj.Destination = documentAction.Destination.Encode();
		return obj;
	}

	private SlideGroup EncodeSlideGroups(CueGroup group, int slideQuality)
	{
		return new SlideGroup
		{
			Name = (group.Label?.Text ?? string.Empty),
			Color = (group.Label?.Color?.EncodeColor() ?? string.Empty),
			Slides = group.Cues.Select((SlideCue s) => EncodeSlide(s, slideQuality, group.Cues.IndexOf(s))).ToArray()
		};
	}

	private Slide EncodeSlide(SlideCue slide, int slideQuality, int index)
	{
		return new Slide
		{
			Enabled = slide.IsEnabled,
			Notes = slide.SlideAction?.Slide.Note?.AllText,
			Text = slide.SlideAction?.Slide.DisplayText?.AllText,
			Image = _slidePreviewEncoder.Encode(slide, slideQuality),
			Index = index,
			Label = (slide.SlideAction?.Label?.Text ?? string.Empty),
			Color = (slide.SlideAction?.Label?.Color?.EncodeColor() ?? string.Empty)
		};
	}
}
