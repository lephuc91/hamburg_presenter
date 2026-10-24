using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.UI.DialogService;
using Pro.ssAPI;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;
using ProPresenter.UI.Transitions;

namespace ProPresenter.UI.MediaLibrary;

public class MediaActionService : IMediaActionService
{
	private readonly ssAPIOutput _outputController;

	private readonly IProPresenterResourceService _resources;

	private TransitionHandler? _transitionHandler;

	private Action<TransitionParameters>? _setTransitionCallback;

	public MediaActionService(ssAPIOutput outputController, IProPresenterResourceService resources)
	{
		_outputController = outputController;
		_resources = resources;
	}

	public void SetMediaScaleBehavior(IEnumerable<MediaAction> mediaActions, ScaleBehavior scaleBehavior)
	{
		mediaActions.Select((MediaAction a) => a.Media).OfType<IDrawMedia>().ForEach(delegate(IDrawMedia m)
		{
			m.Drawing.ScaleBehavior = scaleBehavior;
		});
	}

	public void SetPlayback(MediaAction target, IEnumerable<MediaAction> others, PlaybackBehaviorType playback)
	{
		TransportProperties transportProperties = target?.VideoMedia?.Transport;
		TimeSlice timeSlice = ((others.Count() > 1) ? TimeSlice.Zero : (transportProperties?.LoopTime ?? TimeSlice.Zero));
		if (timeSlice == TimeSlice.FromSeconds(1.0))
		{
			timeSlice = TimeSlice.Zero;
		}
		int playlbackCount = ((others.Count() > 1) ? 1 : (transportProperties?.LoopCount ?? 1));
		PlaybackLoop playbackLoop = new PlaybackLoop
		{
			PlaybackBehavior = playback,
			PlaylbackTime = timeSlice,
			PlaylbackCount = playlbackCount
		};
		if (playback == PlaybackBehaviorType.LoopForCount || playback == PlaybackBehaviorType.LoopForTime)
		{
			DefaultButtons? defaultButtons = MessageDialogService.ShowDialog(string.Empty, (DependencyObject)(object)playbackLoop, DefaultButtons.OK | DefaultButtons.CANCEL, DefaultButtons.OK);
			if (!defaultButtons.HasValue || defaultButtons.Value == DefaultButtons.CANCEL)
			{
				return;
			}
		}
		foreach (VideoMedia item in from c in others
			where c.Media.MediaType == MediaType.Video
			select c into a
			select a.VideoMedia)
		{
			item.Transport.PlaybackBehaviorType = playback;
			switch (playback)
			{
			case PlaybackBehaviorType.LoopForCount:
				item.Transport.LoopCount = playbackLoop.PlaylbackCount;
				break;
			case PlaybackBehaviorType.LoopForTime:
				item.Transport.LoopTime = playbackLoop.PlaylbackTime;
				break;
			}
			item.Video.SoftLoop = false;
		}
	}

	public void SetSoftLoopDuration(IEnumerable<MediaAction> mediaActions, TimeSlice? time)
	{
		foreach (VideoMedia item in from c in mediaActions
			where c.Media.MediaType == MediaType.Video
			select c into a
			select a.VideoMedia)
		{
			item.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Loop;
			item.Video.SoftLoop = time.HasValue;
			item.Video.SoftLoopDuration = time ?? TimeSlice.Zero;
		}
	}

	public void SetEndBehaviorType(IEnumerable<MediaAction> mediaActions, EndBehaviorType endBehavior)
	{
		foreach (VideoProperties item in from c in mediaActions
			where c.Media.MediaType == MediaType.Video
			select c into a
			select a.VideoMedia.Video)
		{
			item.EndBehavior = endBehavior;
		}
	}

	public void SetTransition(TransitionParameters? currentTransition, UIElement? placementTarget, Action<TransitionParameters> setTransitionCallback)
	{
		_setTransitionCallback = setTransitionCallback;
		EnsureTransitionHandlerInitialized();
		new SelectorPopup
		{
			OutputController = _outputController,
			SelectedTransition = currentTransition,
			TransitionHandler = _transitionHandler,
			IsGlobalAllowed = true,
			PlacementTarget = placementTarget,
			StaysOpen = false,
			IsOpen = true
		};
	}

	private void EnsureTransitionHandlerInitialized()
	{
		if (_transitionHandler == null)
		{
			_transitionHandler = new TransitionHandler(_resources.Transitions);
			_transitionHandler.TransitionFinalized += TransitionHandler_TransitionFinalized;
		}
	}

	private void TransitionHandler_TransitionFinalized(TransitionParameters? transition)
	{
		if ((object)transition != null)
		{
			_setTransitionCallback?.Invoke(transition);
		}
		_setTransitionCallback = null;
	}

	public void SetAudioPlayback(IEnumerable<MediaAction> mediaActions, AudioBehaviorType audioBehaviorType)
	{
		switch (audioBehaviorType)
		{
		case AudioBehaviorType.Stop:
			mediaActions.Select((MediaAction p) => p.AudioMedia).NotNull().ForEach(delegate(AudioMedia m)
			{
				m.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
			});
			break;
		case AudioBehaviorType.Loop:
			mediaActions.Select((MediaAction p) => p.AudioMedia).NotNull().ForEach(delegate(AudioMedia m)
			{
				m.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Loop;
			});
			break;
		case AudioBehaviorType.Next:
			mediaActions.Select((MediaAction p) => p.AudioMedia).NotNull().ForEach(delegate(AudioMedia m)
			{
				m.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
			});
			break;
		}
	}

	public void SetAlphaType(IEnumerable<MediaAction> mediaActions, AlphaType alphaType)
	{
		foreach (MediaAction mediaAction in mediaActions)
		{
			if (mediaAction.Media is IDrawMedia drawMedia)
			{
				drawMedia.Drawing.AlphaType = alphaType;
			}
		}
	}
}
