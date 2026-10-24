using System;
using System.Collections.Generic;
using System.Linq;
using Pro.DO.Transitions;
using Pro.UI.Converters;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.UI.CueInspector;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Timeline;

namespace ProPresenter.UI.Converters;

public class MediaInspectorConverter : BoxCommandParameterConverter<InspectorParameter>
{
	private readonly IApp _app;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public MediaInspectorConverter(IApp app, ITransitionDescriptionCollection transitionDescriptions)
	{
		_app = app;
		_transitionDescriptions = transitionDescriptions;
	}

	protected override InspectorParameter Box(object?[] data)
	{
		IEnumerable<MediaCue> cues = null;
		if (data.Length != 0)
		{
			object obj = data[0];
			if (!(obj is IEnumerable<MediaCue> enumerable))
			{
				if (!(obj is MediaCue item))
				{
					if (!(obj is MediaAction mediaAction))
					{
						if (obj is IEnumerable<IMediaCueThumbnailVM> source)
						{
							cues = source.Select((IMediaCueThumbnailVM t) => t.MediaCue);
						}
					}
					else
					{
						cues = new global::_003C_003Ez__ReadOnlySingleElementList<MediaCue>(mediaAction.ToCue());
					}
				}
				else
				{
					cues = new global::_003C_003Ez__ReadOnlySingleElementList<MediaCue>(item);
				}
			}
			else
			{
				cues = enumerable;
			}
		}
		InspectorOptions inspectorOptions = InspectorOptions.Default;
		if (data.Length > 1)
		{
			inspectorOptions = InspectorOptions.None;
			for (int i = 1; i < data.Length; i++)
			{
				if (data[i] is InspectorOptions inspectorOptions2)
				{
					inspectorOptions |= inspectorOptions2;
				}
			}
		}
		return new InspectorParameter(cues, inspectorOptions);
	}

	protected override InspectorParameter Box(object? data)
	{
		IEnumerable<MediaCue> cues = Array.Empty<MediaCue>();
		if (data is IEnumerable<MediaCue> enumerable)
		{
			cues = enumerable;
		}
		else if (data is IActionRepository actionRepository)
		{
			List<MediaCue> list = new List<MediaCue>();
			list.AddRange(from a in actionRepository.Actions.OfType<MediaAction>()
				select a.ToCue());
			cues = new global::_003C_003Ez__ReadOnlyList<MediaCue>(list);
		}
		else
		{
			MediaCue mediaCue = GetMediaCue(data, _app, _transitionDescriptions);
			if (mediaCue != null)
			{
				cues = new global::_003C_003Ez__ReadOnlySingleElementList<MediaCue>(mediaCue);
			}
		}
		return new InspectorParameter(cues);
	}

	private static MediaCue? GetMediaCue(object? value, IApp app, ITransitionDescriptionCollection transitionDescriptions)
	{
		if (!(value is MediaBase media))
		{
			if (!(value is MediaAction mediaAction))
			{
				if (!(value is MediaFill mediaFill))
				{
					if (!(value is ITimelineItemVM timelineItemVM))
					{
						if (value is IMediaCueThumbnailVM mediaCueThumbnailVM)
						{
							return mediaCueThumbnailVM.MediaCue;
						}
						return null;
					}
					return (timelineItemVM.Item?.Item as MediaAction)?.ToCue();
				}
				return mediaFill.Media?.ToCue(app, transitionDescriptions);
			}
			return mediaAction.ToCue();
		}
		return media.ToCue(app, transitionDescriptions);
	}
}
