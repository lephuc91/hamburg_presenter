using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.UI;
using ProPresenter.UI.CueInspector;
using ProPresenter.UI.ViewModels.CueInspector;

namespace ProPresenter.ViewModels.CueInspector;

public class InspectedMediaCueVM : NotifyPropertyChangedBase, IInspectedMediaCueVM, INotifyPropertyChanged
{
	public MediaCue MediaCue { get; }

	public bool ShowTransitionTab { get; }

	public bool ShowEffectsTab { get; }

	public bool ShowAudioTab { get; }

	public bool ShowMarkersTab { get; }

	public bool SupportsAudioNextBehavior { get; }

	public bool ShowRetriggeringBehaviorField { get; }

	public InlineType ActiveInlineView { get; }

	public InspectedMediaCueVM(MediaCue mediaCue, InlineType activeInlineView, InspectorOptions options)
	{
		MediaCue = mediaCue;
		MediaType? mediaType = mediaCue.MediaAction?.Media?.MediaType;
		int valueOrDefault = (mediaCue.MediaAction?.FileMedia?.Metadata?.AudioChannelCount).GetValueOrDefault();
		bool flag = options.HasFlag(InspectorOptions.SupportsTransition);
		bool flag2 = options.HasFlag(InspectorOptions.SupportsAudioNextBehavior);
		bool flag3 = options.HasFlag(InspectorOptions.SupportsRetriggerBehavior);
		ShowTransitionTab = flag && (mediaType == MediaType.Image || mediaType == MediaType.Video);
		ShowEffectsTab = mediaType != MediaType.Audio;
		int num;
		if (valueOrDefault > 0)
		{
			if (mediaType == MediaType.Video)
			{
				VisualMedia obj = mediaCue.MediaAction?.Media as VisualMedia;
				if (obj != null && obj.SupportsAudio)
				{
					num = 1;
					goto IL_015a;
				}
			}
			num = ((mediaType == MediaType.Audio) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		goto IL_015a;
		IL_015a:
		ShowAudioTab = (byte)num != 0;
		ShowMarkersTab = mediaCue.SupportsPlaybackMarkers;
		SupportsAudioNextBehavior = flag2;
		ActiveInlineView = activeInlineView;
		ShowRetriggeringBehaviorField = flag3 && MediaCue.Actions.AnyOf((MediaAction a) => a.TriggerLayer == TriggerLayer.Background);
	}
}
