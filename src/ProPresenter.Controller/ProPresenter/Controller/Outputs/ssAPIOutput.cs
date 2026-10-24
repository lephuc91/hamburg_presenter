using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Transitions;
using Pro.DO.Transitions.Descriptions;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;
using ProPresenter.Controller.Outputs.ssAPI;
using ProPresenter.DO.OutputConfiguration;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller.Outputs;

public class ssAPIOutput : NotifyPropertyChangedBase
{
	private static readonly TimeSlice MediaSnapShotDelay = TimeSlice.FromSeconds(1.0);

	private readonly IProCoreInstance _proCore;

	private readonly TransitionPreviewCache _transitionPreviewCache;

	private bool _identifyScreens;

	private bool _identifyLook;

	private readonly DispatcherTimer _mediaSnapShotTimer = new DispatcherTimer((DispatcherPriority)4);

	private System.Action? _mediaSnapShotRequest;

	public VideoOutputDeviceCollection AvailableVideoOutputs { get; } = new VideoOutputDeviceCollection();

	public VideoInputDeviceCollection AvailableVideoInputs { get; }

	public AudioOutputDeviceCollection AvailableAudioOutputs { get; } = new AudioOutputDeviceCollection();

	public AudioInputDeviceCollection AvailableAudioInputs { get; } = new AudioInputDeviceCollection();

	public IReadOnlyList<EffectDescription> AvailableEffects { get; }

	public TransitionDescriptionCollection AvailableTransitions { get; }

	public bool IdentifyScreens
	{
		get
		{
			return _identifyScreens;
		}
		set
		{
			SetValue("IdentifyScreens", ref _identifyScreens, value, delegate(bool _, bool val)
			{
				if (val)
				{
					_proCore.IdentifyScreens();
				}
				else
				{
					_proCore.DisableScreenIdentification();
				}
			});
		}
	}

	public bool IdentifyLook
	{
		get
		{
			return _identifyLook;
		}
		set
		{
			SetValue("IdentifyLook", ref _identifyLook, value, delegate(bool _, bool val)
			{
				if (val)
				{
					_proCore.IdentifyLook();
				}
				else
				{
					_proCore.DisableLookIdentification();
				}
			});
		}
	}

	public ssAPIOutput(IProCoreInstance proCore, IFlagService flagService)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		_proCore = proCore;
		AvailableVideoInputs = new VideoInputDeviceCollection();
		Log.Info("Loading video outputs...");
		proCore.EnumerateVideoOutputs(AvailableVideoOutputs.AddDevice);
		Log.Info("Done loading video outputs");
		Log.Info("Loading video inputs...");
		proCore.EnumerateVideoInputs(delegate(ProVideoInputDevice device)
		{
			AvailableVideoInputs.AddDevice(device);
		});
		Log.Info("Done loading video inputs");
		Log.Info("Loading audio outputs...");
		proCore.EnumerateAudioOutputs(AvailableAudioOutputs.AddDevice);
		Log.Info("Done loading audio outputs");
		Log.Info("Loading audio inputs...");
		proCore.EnumerateAudioInputs(delegate(ProAudioDevice device)
		{
			AvailableAudioInputs.AddDevice(device);
		});
		Log.Info("Done loading audio inputs");
		Log.Info("Loading NDI modes...");
		VideoModeCollection videoModeCollection = new VideoModeCollection();
		proCore.EnumerateAvailableNDIModes(videoModeCollection.AddMode);
		SoftDevice.SetAvailableNDIModes(videoModeCollection);
		Log.Info("Done loading NDI modes");
		List<EffectDescription> effects = new List<EffectDescription>();
		List<TransitionDescription> transitions = new List<TransitionDescription>();
		Log.Info("Loading available effects...");
		proCore.EnumerateAvailableEffects(delegate(Effect e)
		{
			effects.Add(new EffectDescription(e));
		});
		Log.Info("Done loading available effects");
		Log.Info("Loading available transitions...");
		proCore.EnumerateAvailableTransitions(delegate(Transition t)
		{
			transitions.Add(new TransitionDescription(t));
		});
		Log.Info("Done loading available transitions");
		AvailableEffects = effects;
		AvailableTransitions = new TransitionDescriptionCollection(transitions);
		_transitionPreviewCache = new TransitionPreviewCache(Dispatcher.CurrentDispatcher, _proCore);
		_mediaSnapShotTimer.Interval = MediaSnapShotDelay;
		_mediaSnapShotTimer.Tick += MediaSnapShotTimer_Tick;
	}

	internal void RefreshVideoOutputs()
	{
		List<IVideoOutputDevice> stillAvailableOutputs = new List<IVideoOutputDevice>();
		_proCore.EnumerateVideoOutputs(delegate(ProVideoOutputDevice device)
		{
			IVideoOutputDevice videoOutputDevice = AvailableVideoOutputs.FirstOrDefault((IVideoOutputDevice o) => o.UUID == device.DeviceID);
			if (videoOutputDevice == null)
			{
				AvailableVideoOutputs.AddDevice(device);
				videoOutputDevice = AvailableVideoOutputs.Last();
			}
			stillAvailableOutputs.Add(videoOutputDevice);
		});
		AvailableVideoOutputs.Except(stillAvailableOutputs).ToArray().ForEach(AvailableVideoOutputs.Remove);
	}

	internal void RefreshVideoInputs()
	{
	}

	internal void VideoInputChanged(ProVideoInputDevice? device, ProDeviceAction action)
	{
		if (device != null)
		{
			switch (action)
			{
			case ProDeviceAction.Added:
				AvailableVideoInputs.AddDevice(device);
				break;
			case ProDeviceAction.Removed:
				AvailableVideoInputs.Remove(device.DeviceID);
				break;
			case ProDeviceAction.Changed:
				AvailableVideoInputs.UpdateOrAddDevice(device);
				break;
			}
		}
	}

	internal void RefreshAudioOutputs()
	{
		List<IAudioOutputDevice> stillAvailableOutputs = new List<IAudioOutputDevice>();
		_proCore.EnumerateAudioOutputs(delegate(ProAudioDevice device)
		{
			IAudioOutputDevice audioOutputDevice = AvailableAudioOutputs.FirstOrDefault((IAudioOutputDevice o) => o.UUID == device.DeviceID);
			if (audioOutputDevice == null)
			{
				AvailableAudioOutputs.AddDevice(device);
				audioOutputDevice = AvailableAudioOutputs.Last();
			}
			else
			{
				AvailableAudioOutputs.UpdateDevice(device);
			}
			stillAvailableOutputs.Add(audioOutputDevice);
		});
		AvailableAudioOutputs.Except(stillAvailableOutputs).ToArray().ForEach(AvailableAudioOutputs.Remove);
	}

	internal void RefreshAudioInputs()
	{
		List<IAudioInputDevice> stillAvailableInputs = new List<IAudioInputDevice>();
		_proCore.EnumerateAudioInputs(delegate(ProAudioDevice device)
		{
			stillAvailableInputs.Add(AvailableAudioInputs.UpdateOrAddDevice(device));
		});
		AvailableAudioInputs.Except(stillAvailableInputs).ToArray().ForEach(AvailableAudioInputs.Remove);
	}

	internal void AudioInputChanged(ProAudioDevice? device, ProDeviceAction action)
	{
		if (device != null)
		{
			switch (action)
			{
			case ProDeviceAction.Added:
				AvailableAudioInputs.AddDevice(device);
				break;
			case ProDeviceAction.Removed:
				AvailableAudioInputs.Remove(device.DeviceID);
				break;
			case ProDeviceAction.Changed:
				AvailableAudioInputs.UpdateOrAddDevice(device);
				break;
			}
		}
	}

	public TransitionPreview? GetTransitionPreview(TransitionParameters transition, BitmapSource startImage, BitmapSource endImage, Vector2<int> targetSize)
	{
		return _transitionPreviewCache?.Get(new TransitionPreviewKey(transition, startImage, endImage, targetSize));
	}

	public void UpdateElement(TriggerHandle handle, Guid slideID, Guid elementID)
	{
		_proCore.TriggerSlideElementUpdate(handle, slideID, elementID);
	}

	private void MediaSnapShotTimer_Tick(object? sender, EventArgs e)
	{
		_mediaSnapShotRequest?.Invoke();
		_mediaSnapShotRequest = null;
		_mediaSnapShotTimer.Stop();
	}
}
