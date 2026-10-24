using System;
using System.Collections.Generic;
using System.Windows;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.ssAPI;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.MediaLibrary;

public interface IMediaActionService
{
	void SetMediaScaleBehavior(IEnumerable<MediaAction> mediaActions, ScaleBehavior scaleBehavior);

	void SetPlayback(MediaAction target, IEnumerable<MediaAction> others, PlaybackBehaviorType playback);

	void SetSoftLoopDuration(IEnumerable<MediaAction> mediaActions, TimeSlice? time);

	void SetEndBehaviorType(IEnumerable<MediaAction> mediaActions, EndBehaviorType endBehavior);

	void SetTransition(TransitionParameters? currentTransition, UIElement? placementTarget, Action<TransitionParameters> setTransitionCallback);

	void SetAudioPlayback(IEnumerable<MediaAction> mediaActions, AudioBehaviorType audioBehaviorType);

	void SetAlphaType(IEnumerable<MediaAction> mediaActions, AlphaType alphaType);
}
