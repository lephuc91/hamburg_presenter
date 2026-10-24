using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.Time;
using Pro.Common.Versioning;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.Resi;
using ProPresenterCore.ProCore.Interop.Resi.Types;
using ProPresenterCore.ProCore.Interop.Triggering.AsyncTransfers;
using ProPresenterCore.ProCore.Interop.Triggering.Transfers;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop;

public class ProCoreInstance : ProCoreInstanceBase, IProCoreInstance
{
	private const int PreviewBitmapDPI = 96;

	private static readonly PixelFormat PreviewBitmapPixelFormat = PixelFormats.Pbgra32;

	private readonly HashSet<Delegate> _delegateHandles = new HashSet<Delegate>();

	private readonly ProMessageCallback _messageCallback;

	private readonly Action<Exception> _exceptionHandler;

	private readonly Dispatcher _dispatcher;

	private readonly ProCoreInstanceCreateInfo _createInfo;

	private readonly Dictionary<ProDeviceType, ProDeviceChangedCallback> _deviceCallbacks = new Dictionary<ProDeviceType, ProDeviceChangedCallback>();

	private bool _hasCoreShutDown;

	private uint _sendDataIdCounter;

	public TriggerTransferDelegate? TriggerTransferHandler { get; set; }

	public AsyncTriggerTransferDelegate? AsyncTriggerTransferHandler { get; set; }

	public OperationStateChangedDelegate? OperationHandler { get; set; }

	public ResourceStateChangedDelegate? ResourceHandler { get; set; }

	public TransportStatusChangedDelegate? TransportStatusChanged { get; set; }

	public AudioInputStatusChangedDelegate? AudioInputStatusChanged { get; set; }

	public ResiTransferDelegate? ResiTransferHandler { get; set; }

	public ImageRequestTransferDelegate? ImageRequestTransferHandler { get; set; }

	public CloseDisplayButtonClickedDelegate? CloseDisplayButtonClicked { get; set; }

	public SendCommunicationDelegate? SendCommunication { get; set; }

	public VideoInputStatusChangedDelegate? VideoInputStatusChanged { get; set; }

	public UpdateAudioInputDelegate? UpdateAudioInput { get; set; }

	public Func<ulong, ProNetworkEndpointType, bool>? ConnectedWSCallback { get; set; }

	public Action<ulong>? DisconnectedWSCallback { get; set; }

	public Func<ulong, string, string>? MessagesWSCallback { get; set; }

	public Action<NetworkAPI>? NetworkAPICallback { get; set; }

	public Func<NetworkAPI_v1, ProApiOut?>? APIV1Callback { get; set; }

	public Func<ProLink.Types.HandlerIn, ProApiOut?>? LinkCallback { get; set; }

	public event EventHandler<SendDataResponseEventArgs>? SendDataResponseReceived;

	public event EventHandler<ScreenCaptureStatusEventArgs>? ScreenCaptureStatusChanged;

	public unsafe ProCoreInstance(Dispatcher dispatcher, ProMessageCallback messageHandler, Action<Exception> exceptionHandler, IFlagService flagService, string installPath, bool showAdvancedOnScreenStats, bool ndiShowLocalSources, string ndiInputGroups, string ndiExtraIPs, ProCoreRenderMode renderMode, ProCoreRenderBitDepth renderBitDepth)
		: base(null)
	{
		_dispatcher = dispatcher;
		ProCoreInstanceCreateInfo proCoreInstanceCreateInfo = new ProCoreInstanceCreateInfo();
		byte* _Instance = (byte*)proCoreInstanceCreateInfo.__Instance;
		for (int i = 0; i < Marshal.SizeOf<ProCoreInstanceCreateInfo.__Internal>(); i++)
		{
			*(_Instance++) = 0;
		}
		proCoreInstanceCreateInfo.VersionInformation = new ProVersionInformation
		{
			MajorVersion = VersionInfo.AppVersion.Major,
			MinorVersion = VersionInfo.AppVersion.Minor,
			PatchVersion = VersionInfo.AppVersion.Revision,
			Build = VersionInfo.AppVersion.Build
		};
		proCoreInstanceCreateInfo.NdiFinderSettings.ShowLocalSources = ndiShowLocalSources;
		proCoreInstanceCreateInfo.NdiFinderSettings.Groups = ndiInputGroups;
		proCoreInstanceCreateInfo.NdiFinderSettings.ExtraIPs = ndiExtraIPs;
		proCoreInstanceCreateInfo.RenderMode = renderMode;
		proCoreInstanceCreateInfo.RenderBitDepth = renderBitDepth;
		proCoreInstanceCreateInfo.RenderStatsLevel = (showAdvancedOnScreenStats ? ProCoreRenderStatsLevel.Advanced : ProCoreRenderStatsLevel.Normal);
		_messageCallback = messageHandler ?? ((ProMessageCallback)delegate
		{
		});
		_exceptionHandler = exceptionHandler;
		proCoreInstanceCreateInfo.MessageCallback = _messageCallback;
		proCoreInstanceCreateInfo.MessageCallbackUserData = IntPtr.Zero;
		ProTriggerTransferCallback item = (proCoreInstanceCreateInfo.TriggerTransferCallback = TriggerTransferCallback);
		proCoreInstanceCreateInfo.TriggerTransferUserData = IntPtr.Zero;
		_delegateHandles.Add(item);
		ProAsyncTriggerTransferCallback item2 = (proCoreInstanceCreateInfo.AsyncTriggerTransferCallback = AsyncTriggerTransferCallback);
		proCoreInstanceCreateInfo.AsyncTriggerTransferUserData = IntPtr.Zero;
		_delegateHandles.Add(item2);
		ProOperationStateChangedCallback item3 = (proCoreInstanceCreateInfo.OperationStateCallback = OperationStateChangedCallback);
		proCoreInstanceCreateInfo.OperationStateUserData = IntPtr.Zero;
		_delegateHandles.Add(item3);
		ProResourceStateChangedCallback item4 = (proCoreInstanceCreateInfo.ResourceStateCallback = ResourceStateChangedCallback);
		proCoreInstanceCreateInfo.ResourceStateUserData = IntPtr.Zero;
		_delegateHandles.Add(item4);
		ProTransportStatusChangedCallback item5 = (proCoreInstanceCreateInfo.TransportStatusCallback = TransportStatusChangedCallback);
		proCoreInstanceCreateInfo.TransportStatusUserData = IntPtr.Zero;
		_delegateHandles.Add(item5);
		ProAudioInputStatusChangedCallback item6 = (proCoreInstanceCreateInfo.AudioInputStatusCallback = AudioInStatusChangedCallback);
		proCoreInstanceCreateInfo.AudioInputStatusUserData = IntPtr.Zero;
		_delegateHandles.Add(item6);
		ProScreenCaptureStatusChangedCallback item7 = (proCoreInstanceCreateInfo.ScreenCaptureStatusCallback = OutputRecordingStatusChangedCallback);
		proCoreInstanceCreateInfo.ScreenCaptureStatusUserData = IntPtr.Zero;
		_delegateHandles.Add(item7);
		ProCloseDisplayButtonClickedCallback item8 = (proCoreInstanceCreateInfo.CloseDisplayButtonCallback = CloseDisplayButtonClickedCallback);
		proCoreInstanceCreateInfo.CloseDisplayButtonUserData = IntPtr.Zero;
		_delegateHandles.Add(item8);
		ProCommunicationCallback item9 = (proCoreInstanceCreateInfo.CommunicationCallback = CommunicationCallback);
		proCoreInstanceCreateInfo.CommunicationUserData = IntPtr.Zero;
		_delegateHandles.Add(item9);
		ProVideoInputStatusChangedCallback item10 = (proCoreInstanceCreateInfo.VideoInputCallback = VideoInputStatusChangedCallback);
		proCoreInstanceCreateInfo.VideoInputUserData = IntPtr.Zero;
		_delegateHandles.Add(item10);
		ProAudioInputActionCallback item11 = (proCoreInstanceCreateInfo.AudioInputActionCallback = AudioInputActionCallback);
		proCoreInstanceCreateInfo.AudioInputActionUserData = IntPtr.Zero;
		_delegateHandles.Add(item11);
		ProResiCallback item12 = (proCoreInstanceCreateInfo.ResiCallback = ResiTransferCallback);
		proCoreInstanceCreateInfo.ResiCallbackUserData = IntPtr.Zero;
		_delegateHandles.Add(item12);
		ProImageRequestCallback item13 = (proCoreInstanceCreateInfo.ImageRequestCallback = ImageRequestCallback);
		proCoreInstanceCreateInfo.ImageRequestCallbackUserData = IntPtr.Zero;
		_delegateHandles.Add(item13);
		ProSendDataResponseCallback item14 = (proCoreInstanceCreateInfo.SendDataResponseCallback = SendDataResponseCallback);
		proCoreInstanceCreateInfo.SendDataResponseCallbackUserData = IntPtr.Zero;
		_delegateHandles.Add(item14);
		byte[] array = new ResolvedFeatureFlags
		{
			CoreNetworkapiPlaylist = flagService.IsFlagEnabled(Flag.CoreNetworkapiPlaylist),
			CoreNetworkapiPresentation = flagService.IsFlagEnabled(Flag.CoreNetworkapiPresentation),
			HdrRenderingEnabled = true,
			ServerDrivenFeatureFlags = flagService.IsFlagEnabled(Flag.ServerDrivenFeatureFlags)
		}.ToByteArray();
		fixed (byte* bytes = Encoding.UTF8.GetBytes(installPath))
		{
			fixed (byte* featureFlagsData = array)
			{
				proCoreInstanceCreateInfo.FeatureFlagsData = (nint)featureFlagsData;
				proCoreInstanceCreateInfo.FeatureFlagsDataSize = array.Length;
				nint _Instance2 = default(nint);
				ProResult proResult = __Internal.CreateInstance(proCoreInstanceCreateInfo.__Instance, (nint)bytes, new IntPtr(&_Instance2));
				if (proResult < ProResult.Success)
				{
					throw new ProResultException(proResult);
				}
				base.__Instance = _Instance2;
			}
		}
		_createInfo = proCoreInstanceCreateInfo;
	}

	public override void Dispose(bool disposing)
	{
		DestroyInstance();
		_hasCoreShutDown = true;
		if (_createInfo != null)
		{
			_createInfo.Dispose();
		}
		_delegateHandles.Clear();
		base.Dispose(disposing);
	}

	public unsafe ProResult MigrateDocument(string oldFilePath, string newFilePath, ProMigrationType migrationType)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		fixed (byte* bytes = Encoding.UTF8.GetBytes(oldFilePath))
		{
			fixed (byte* bytes2 = Encoding.UTF8.GetBytes(newFilePath))
			{
				return MigrateDocument((nint)bytes, (nint)bytes2, migrationType);
			}
		}
	}

	public unsafe ProResult UpdateDisplaySettings(TriggerHandle handle, ProPresenterWorkspace workspace, object clientObject)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = workspace.ToByteArray();
		fixed (byte* value = array)
		{
			return TriggerWorkspace(handle.RawValue, new IntPtr(value), array.Length, (clientObject != null) ? GCHandle.ToIntPtr(GCHandle.Alloc(clientObject)) : IntPtr.Zero);
		}
	}

	public unsafe ProResult UpdateAudioInputs(AudioInputSettings settings)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = settings.ToByteArray();
		fixed (byte* value = array)
		{
			return UpdateAudioInputs(new IntPtr(value), array.Length);
		}
	}

	public unsafe ProResult UpdateVideoInputs(VideoInputSettings settings)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = settings.ToByteArray();
		fixed (byte* value = array)
		{
			return UpdateVideoInputs(new IntPtr(value), array.Length);
		}
	}

	public void UpdateNDIFinderSettings(bool nDIShowSources, string nDIReceiveGroups, string nDIAdditionalSearchIPs)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		ProNDIFinderSettings settings = new ProNDIFinderSettings
		{
			ShowLocalSources = nDIShowSources,
			Groups = nDIReceiveGroups,
			ExtraIPs = nDIAdditionalSearchIPs
		};
		UpdateNDIFinderSettings(settings);
	}

	public unsafe ProResult ShowIdentificationOverlay(string deviceID)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		fixed (byte* bytes = Encoding.UTF8.GetBytes(deviceID))
		{
			return ShowIdentificationOverlay((nint)bytes);
		}
	}

	public ProResult AddDeviceChangedCallback(ProDeviceType deviceType, System.Action action)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		if (_deviceCallbacks.ContainsKey(deviceType))
		{
			return ProResult.Duplicate;
		}
		_deviceCallbacks.Add(deviceType, delegate
		{
			action();
		});
		return AddDeviceChangedCallback(deviceType, IntPtr.Zero, _deviceCallbacks[deviceType]);
	}

	public unsafe ProResult AddDeviceChangedCallback(ProDeviceType deviceType, Action<object, ProDeviceAction> action)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		if (_deviceCallbacks.ContainsKey(deviceType))
		{
			return ProResult.Duplicate;
		}
		_deviceCallbacks.Add(deviceType, delegate(nint device, ProDeviceAction deviceAction, nint userData)
		{
			switch (deviceType)
			{
			case ProDeviceType.VideoOutput:
				action(ProVideoOutputDevice.__CreateInstance(*(ProVideoOutputDevice.__Internal*)device), deviceAction);
				break;
			case ProDeviceType.VideoInput:
				action(ProVideoInputDevice.__CreateInstance(*(ProVideoInputDevice.__Internal*)device), deviceAction);
				break;
			case ProDeviceType.AudioOutput:
			case ProDeviceType.AudioInput:
				action(ProAudioDevice.__CreateInstance(*(ProAudioDevice.__Internal*)device), deviceAction);
				break;
			}
		});
		return AddDeviceChangedCallback(deviceType, IntPtr.Zero, _deviceCallbacks[deviceType]);
	}

	public ProResult RemoveDeviceChangedCallback(ProDeviceType deviceType)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		if (!_deviceCallbacks.ContainsKey(deviceType))
		{
			return ProResult.Success;
		}
		ProResult result = RemoveDeviceChangedCallback(deviceType, IntPtr.Zero, _deviceCallbacks[deviceType]);
		_deviceCallbacks.Remove(deviceType);
		return result;
	}

	public ProResult EnumerateVideoOutputs(Action<ProVideoOutputDevice> deviceAction)
	{
		ProEnumerateDevicesCallback callback = delegate(nint nativePtr, nint userData)
		{
			using ProVideoOutputDevice obj = ProVideoOutputDevice.__CreateInstance(nativePtr);
			deviceAction(obj);
		};
		return InvokeWithCallbacks(() => EnumerateDevices(ProDeviceType.VideoOutput, IntPtr.Zero, callback), callback);
	}

	public ProResult EnumerateVideoInputs(Action<ProVideoInputDevice> deviceAction)
	{
		ProEnumerateDevicesCallback callback = delegate(nint nativePtr, nint userData)
		{
			using ProVideoInputDevice obj = ProVideoInputDevice.__CreateInstance(nativePtr);
			deviceAction(obj);
		};
		return InvokeWithCallbacks(() => EnumerateDevices(ProDeviceType.VideoInput, IntPtr.Zero, callback), callback);
	}

	public ProResult EnumerateAudioOutputs(Action<ProAudioDevice> deviceAction)
	{
		ProEnumerateDevicesCallback callback = delegate(nint nativePtr, nint userData)
		{
			using ProAudioDevice obj = ProAudioDevice.__CreateInstance(nativePtr);
			deviceAction(obj);
		};
		return InvokeWithCallbacks(() => EnumerateDevices(ProDeviceType.AudioOutput, IntPtr.Zero, callback), callback);
	}

	public ProResult EnumerateAudioInputs(Action<ProAudioDevice> deviceAction)
	{
		ProEnumerateDevicesCallback callback = delegate(nint nativePtr, nint userData)
		{
			using ProAudioDevice obj = ProAudioDevice.__CreateInstance(nativePtr);
			deviceAction(obj);
		};
		return InvokeWithCallbacks(() => EnumerateDevices(ProDeviceType.AudioInput, IntPtr.Zero, callback), callback);
	}

	public ProResult EnumerateAvailableNDIModes(Action<ProVideoMode> modeAction)
	{
		ProEnumerateNDIModesCallback callback = delegate(nint nativePtr, nint userData)
		{
			using ProVideoMode obj = ProVideoMode.__CreateInstance(nativePtr);
			modeAction(obj);
		};
		return InvokeWithCallbacks(() => EnumerateAvailableNDIModes(IntPtr.Zero, callback), callback);
	}

	public unsafe ProResult EnumerateAvailableEffects(Action<Effect> effectAction)
	{
		ProEnumerateEffectsCallback callback = delegate(nint effectDataPointer, int effectDataSize, nint userData)
		{
			Effect effect = new Effect();
			UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)((IntPtr)effectDataPointer).ToPointer(), effectDataSize);
			((IMessage)effect).MergeFrom((Stream)input);
			effectAction(effect);
		};
		return InvokeWithCallbacks(() => EnumerateAvailableEffects(IntPtr.Zero, callback), callback);
	}

	public unsafe ProResult EnumerateAvailableTransitions(Action<Transition> effectTransition)
	{
		ProEnumerateTransitionsCallback callback = delegate(nint transitionDataPointer, int transitionDataSize, nint userData)
		{
			Transition transition = new Transition();
			UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)((IntPtr)transitionDataPointer).ToPointer(), transitionDataSize);
			((IMessage)transition).MergeFrom((Stream)input);
			effectTransition(transition);
		};
		return InvokeWithCallbacks(() => EnumerateAvailableTransitions(IntPtr.Zero, callback), callback);
	}

	public unsafe ProResult GenerateTransitionImages(Transition transition, BitmapSource srcImageA, BitmapSource srcImageB, int width, int height, int frameCount, out BitmapSource[] renderedBitmaps)
	{
		byte[] transitionBuffer = transition.ToByteArray();
		byte[] array = CreateBitmapBuffer(srcImageA);
		byte[] array2 = CreateBitmapBuffer(srcImageB);
		fixed (byte* value3 = transitionBuffer)
		{
			fixed (byte* value = array)
			{
				fixed (byte* value2 = array2)
				{
					ProClientImageTransfer aImgTranser = new ProClientImageTransfer
					{
						Width = (uint)srcImageA.PixelWidth,
						Height = (uint)srcImageA.PixelHeight,
						Pixels = new IntPtr(value)
					};
					ProClientImageTransfer bImgTranser = new ProClientImageTransfer
					{
						Width = (uint)srcImageB.PixelWidth,
						Height = (uint)srcImageB.PixelHeight,
						Pixels = new IntPtr(value2)
					};
					BitmapSource[] resultBitmaps = Array.Empty<BitmapSource>();
					ProTransitionImagesCallback callback = delegate(nint resultPtr, int imageBufferSize, nint userData)
					{
						resultBitmaps = new BitmapSource[frameCount];
						int num = width * height * 4;
						for (int i = 0; i < frameCount; i++)
						{
							BitmapSource bitmapSource = BitmapSource.Create(width, height, 96.0, 96.0, PreviewBitmapPixelFormat, null, resultPtr + i * num, num, width * 4);
							((Freezable)bitmapSource).Freeze();
							resultBitmaps[i] = bitmapSource;
						}
					};
					nint transitionDataPtr = new IntPtr(value3);
					ProResult result = InvokeWithCallbacks(() => GenerateTransitionImages(transitionDataPtr, transitionBuffer.Length, aImgTranser, bImgTranser, width, height, frameCount, IntPtr.Zero, callback), callback);
					renderedBitmaps = resultBitmaps;
					return result;
				}
			}
		}
	}

	public unsafe ProResult EnumerateClockSources(Action<ProClockSource> clockSourceAction)
	{
		ProEnumerateClockSourcesCallback callback = delegate(nint clockSourceDataPointer, int clockSourceDataSize, nint userData)
		{
			ProClockSource proClockSource = new ProClockSource();
			UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)((IntPtr)clockSourceDataPointer).ToPointer(), clockSourceDataSize);
			((IMessage)proClockSource).MergeFrom((Stream)input);
			clockSourceAction(proClockSource);
		};
		return InvokeWithCallbacks(() => EnumerateClockSources(IntPtr.Zero, callback), callback);
	}

	public ProResult AddClockSourceChangedCallback(System.Action action)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		ProClockSourceChangedCallback proClockSourceChangedCallback = delegate
		{
			action();
		};
		RetainCallbacks(proClockSourceChangedCallback);
		return AddClockSourceChangedCallback(IntPtr.Zero, proClockSourceChangedCallback);
	}

	public unsafe ProResult SetClockSource(ProClockSource clockSource)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = clockSource.ToByteArray();
		fixed (byte* value = array)
		{
			return SetClockSource(new IntPtr(value), array.Length);
		}
	}

	public unsafe ProResult EnableWatermark(BitmapSource logoBitmap, BitmapSource textBitmap)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = CreateBitmapBuffer(logoBitmap);
		byte[] array2 = CreateBitmapBuffer(textBitmap);
		fixed (byte* imageData = array)
		{
			fixed (byte* textData = array2)
			{
				return EnableWatermark((nint)imageData, logoBitmap.PixelWidth, logoBitmap.PixelHeight, (nint)textData, textBitmap.PixelWidth, textBitmap.PixelHeight);
			}
		}
	}

	public unsafe MediaMetadataRequestResponse? GetMediaMetadata(string filename, int width, int height, double insetLeft, double insetTop, double insetRight, double insetBottom, TimeSlice time, bool flipVertically, bool flipHorizontally, Media.Types.DrawingProperties.Types.NativeRotationType nativeRotation, IEnumerable<Effect> effects, bool isImport, bool useDefaultNativeRotation, AlphaType alphaType, out BitmapSource? thumbnail)
	{
		MediaMetadataRequestInfo mediaMetadataRequestInfo = new MediaMetadataRequestInfo
		{
			FilePath = filename,
			Width = (uint)width,
			Height = (uint)height,
			Time = (float)time.TotalSeconds,
			FlippedVertically = flipVertically,
			FlippedHorizontally = flipHorizontally,
			NativeRotation = nativeRotation,
			AlphaType = alphaType
		};
		if (effects != null)
		{
			mediaMetadataRequestInfo.Effects.AddRange(effects);
		}
		mediaMetadataRequestInfo.CropInsets = new Graphics.Types.EdgeInsets
		{
			Left = insetLeft,
			Top = insetTop,
			Right = insetRight,
			Bottom = insetBottom
		};
		MediaMetadataRequestResponse response = null;
		BitmapSource resultBitmap = null;
		ProMediaMetadataRequestCallback callback = delegate(nint rawResponse, int responseSize, nint rawBitmap, nint userData)
		{
			UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)((IntPtr)rawResponse).ToPointer(), responseSize);
			response = MediaMetadataRequestResponse.Parser.ParseFrom((Stream)input);
			MediaMetadataRequestResponse.Types.BitmapInfo generatedBitmapInfo = response.GeneratedBitmapInfo;
			if (generatedBitmapInfo != null && generatedBitmapInfo.Width != 0 && generatedBitmapInfo != null && generatedBitmapInfo.Height != 0)
			{
				int width2 = (int)generatedBitmapInfo.Width;
				int height2 = (int)generatedBitmapInfo.Height;
				int num = width2 * 4;
				int bufferSize = num * height2;
				resultBitmap = BitmapSource.Create(width2, height2, 96.0, 96.0, PreviewBitmapPixelFormat, null, rawBitmap, bufferSize, num);
			}
		};
		byte[] requestBuffer = mediaMetadataRequestInfo.ToByteArray();
		fixed (byte* value = requestBuffer)
		{
			nint ptr = new IntPtr(value);
			InvokeWithCallbacks(() => GetMediaMetadata(ptr, requestBuffer.Length, isImport, useDefaultNativeRotation, IntPtr.Zero, callback), callback);
		}
		thumbnail = resultBitmap;
		BitmapSource? obj = thumbnail;
		if (obj != null)
		{
			((Freezable)obj).Freeze();
		}
		return response;
	}

	public BitmapSource? GetCIMediaSnapshot(int width, int height, double cropTop, double cropLeft, double cropRight, double cropBottom, Media.Types.DrawingProperties.Types.NativeRotationType nativeRotation)
	{
		return GetSnapshot(ProRenderViewType.Inspector, width, height, cropTop, cropLeft, cropRight, cropBottom, nativeRotation);
	}

	public BitmapSource? GetVideoInputPreviewSnapshot(int width, int height)
	{
		return GetSnapshot(ProRenderViewType.VideoInputPreferenceTab, width, height, 0.0, 0.0, 0.0, 0.0, Media.Types.DrawingProperties.Types.NativeRotationType.RotateStandard);
	}

	private BitmapSource? GetSnapshot(ProRenderViewType viewType, int width, int height, double cropTop, double cropLeft, double cropRight, double cropBottom, Media.Types.DrawingProperties.Types.NativeRotationType nativeRotation)
	{
		BitmapSource resultBitmap = null;
		ProMediaSnapshotRequestCallback callback = delegate(nint rawBitmap, int rawWidth, int rawHeight, nint userData)
		{
			if (rawWidth > 0 && rawHeight > 0)
			{
				int num = rawWidth * 4;
				int bufferSize = num * rawHeight;
				resultBitmap = BitmapSource.Create(rawWidth, rawHeight, 96.0, 96.0, PreviewBitmapPixelFormat, null, rawBitmap, bufferSize, num);
			}
		};
		ProInsets nativeInsets = new ProInsets
		{
			Left = (float)cropLeft,
			Right = (float)cropRight,
			Top = (float)cropTop,
			Bottom = (float)cropBottom
		};
		try
		{
			InvokeWithCallbacks(() => GetPreviewSnapshot(viewType, width, height, nativeInsets, (int)nativeRotation, IntPtr.Zero, callback), callback);
		}
		finally
		{
			if (nativeInsets != null)
			{
				((IDisposable)nativeInsets).Dispose();
			}
		}
		BitmapSource bitmapSource = resultBitmap;
		if (bitmapSource != null)
		{
			((Freezable)bitmapSource).Freeze();
		}
		return resultBitmap;
	}

	private static byte[] CreateBitmapBuffer(BitmapSource bitmap)
	{
		byte[] array = new byte[bitmap.PixelWidth * bitmap.PixelHeight * 4];
		bitmap.CopyPixels(array, bitmap.PixelWidth * 4, 0);
		return array;
	}

	public new TriggerHandle AcquireTriggerHandle()
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		return new TriggerHandle(base.AcquireTriggerHandle());
	}

	public unsafe ProResult TriggerAction(TriggerHandle handle, Pro.SerializationInterop.RVProtoData.Action action, TriggerOptions? triggerOptions, object clientObject)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = action.ToByteArray();
		fixed (byte* value = array)
		{
			if (triggerOptions != null)
			{
				byte[] array2 = triggerOptions.ToByteArray();
				fixed (byte* value2 = array2)
				{
					return TriggerPrerollAction(handle.RawValue, new IntPtr(value), array.Length, new IntPtr(value2), array2.Length, (clientObject != null) ? GCHandle.ToIntPtr(GCHandle.Alloc(clientObject)) : IntPtr.Zero);
				}
			}
			return TriggerPrerollAction(handle.RawValue, new IntPtr(value), array.Length, IntPtr.Zero, 0, (clientObject != null) ? GCHandle.ToIntPtr(GCHandle.Alloc(clientObject)) : IntPtr.Zero);
		}
	}

	public ProResult TriggerCue(TriggerHandle handle, Cue cue, object clientObject)
	{
		return TriggerCue(handle, cue, null, clientObject);
	}

	public unsafe ProResult TriggerCue(TriggerHandle handle, Cue cue, TriggerOptions? triggerOptions, object clientObject)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = cue.ToByteArray();
		fixed (byte* value = array)
		{
			if (triggerOptions != null)
			{
				byte[] array2 = triggerOptions.ToByteArray();
				fixed (byte* value2 = array2)
				{
					return TriggerPrerollCue(handle.RawValue, new IntPtr(value), array.Length, new IntPtr(value2), array2.Length, (clientObject != null) ? GCHandle.ToIntPtr(GCHandle.Alloc(clientObject)) : IntPtr.Zero);
				}
			}
			return TriggerPrerollCue(handle.RawValue, new IntPtr(value), array.Length, IntPtr.Zero, 0, (clientObject != null) ? GCHandle.ToIntPtr(GCHandle.Alloc(clientObject)) : IntPtr.Zero);
		}
	}

	public ProResult TriggerActivate(TriggerHandle handle)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		return TriggerActivateWithHandle(handle.RawValue);
	}

	public unsafe ProResult GetAvailableCodecs(Action<ProScreenCaptureCodec[]> callback)
	{
		ProScreenCaptureCodecCallback codecsCallback = delegate(ProScreenCaptureCodec* nativePtr, int count, nint _)
		{
			List<ProScreenCaptureCodec> list = new List<ProScreenCaptureCodec>();
			if (nativePtr != null)
			{
				for (int i = 0; i < count; i++)
				{
					try
					{
						list.Add(nativePtr[i]);
					}
					catch (Exception value)
					{
						Log.Error($"Could not add codec: {value}");
					}
				}
			}
			callback?.Invoke(list.ToArray());
		};
		return InvokeWithCallbacks(() => EnumerateAvailableCodecs(codecsCallback, IntPtr.Zero), codecsCallback);
	}

	public unsafe ProResult StartScreenCapture(RecordRequest protoStream, out int errorCode)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		errorCode = 0;
		byte[] array = protoStream.ToByteArray();
		fixed (byte* value = array)
		{
			return StartScreenCapture(new IntPtr(value), array.Length, ref errorCode);
		}
	}

	public ProResult StopScreenCapture(Guid streamID)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		ProUUID streamID2 = new ProUUID
		{
			Bytes = streamID.ToByteArray()
		};
		return StopScreenCapture(streamID2);
	}

	public ProResult StopLocalScreenCapture(Guid streamID)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		ProUUID streamID2 = new ProUUID
		{
			Bytes = streamID.ToByteArray()
		};
		return StopLocalScreenCapture(streamID2);
	}

	public unsafe ProResult ResiSetProcessLocation(string processLocation)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		fixed (byte* bytes = Encoding.UTF8.GetBytes(processLocation))
		{
			return ResiSetProcessLocation(new IntPtr(bytes));
		}
	}

	public unsafe ProResult ResiSetAccessToken(string accessToken)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		fixed (byte* bytes = Encoding.UTF8.GetBytes(accessToken))
		{
			return ResiSetAccessToken(new IntPtr(bytes));
		}
	}

	public ProResult RefreshDestinationGroups()
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		return ResiRefreshDestinationGroups();
	}

	public unsafe ProResult ResiEnumerateDestinationGroups(Action<DestinationGroup> callback)
	{
		ProEnumerateResiDestinationGroups destinatioGroupsCallback = delegate(nint nativePtr, nint _)
		{
			DestinationGroup obj = new DestinationGroup((ProResiDestinationGroup.__Internal*)nativePtr);
			callback(obj);
		};
		return InvokeWithCallbacks(() => ResiEnumerateDestinationGroups(IntPtr.Zero, destinatioGroupsCallback), destinatioGroupsCallback);
	}

	public unsafe ProResult ResiEnumerateEncoderProfiles(Action<EncoderProfile> callback)
	{
		ProEnumerateResiEncoderProfiles encoderProfilesCallback = delegate(nint nativePtr, nint _)
		{
			EncoderProfile obj = new EncoderProfile((ProResiEncoderProfile.__Internal*)nativePtr);
			callback(obj);
		};
		return InvokeWithCallbacks(() => ResiEnumerateEncoderProfiles(IntPtr.Zero, encoderProfilesCallback), encoderProfilesCallback);
	}

	public ProResult TriggerTestPattern(TriggerHandle handle, object clientObject)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		return TriggerTestPattern(handle.RawValue, GCHandle.ToIntPtr(GCHandle.Alloc(clientObject)));
	}

	public unsafe ProResult TriggerBuildIndex(TriggerHandle handle, Guid slideID, int buildIndex)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		return __Internal.TriggerBuildIndex(base.__Instance, handle.RawValue, new IntPtr(&slideID), buildIndex);
	}

	public unsafe ProResult TriggerLogo(TriggerHandle handle, Pro.SerializationInterop.RVProtoData.Action action)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = action.ToByteArray();
		fixed (byte* value = array)
		{
			return TriggerLogo(handle.RawValue, new IntPtr(value), array.Length);
		}
	}

	public unsafe ProResult ControlTransport(ProLayerIndex layer, ControlTransport controlTransport)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = controlTransport.ToByteArray();
		fixed (byte* value = array)
		{
			return ControlTransport(layer, new IntPtr(value), array.Length);
		}
	}

	public unsafe ProResult InspectAction(Pro.SerializationInterop.RVProtoData.Action action)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = action.ToByteArray();
		fixed (byte* value = array)
		{
			return InspectAction(new IntPtr(value), array.Length);
		}
	}

	public unsafe ProResult SetSidebarPreviewScreenID(Guid screenID)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		return __Internal.SetSidebarPreviewScreenID(base.__Instance, new IntPtr(&screenID));
	}

	public unsafe ProResult SendStageMessage(string stageMessage)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		fixed (byte* bytes = Encoding.UTF8.GetBytes(stageMessage))
		{
			return SendStageMessage((nint)bytes);
		}
	}

	public unsafe void InitializeWSCallbacks()
	{
		ProWSConnectedCallback proWSConnectedCallback = (ulong h, nint e, ProNetworkEndpointType u, void** uc) => (ConnectedWSCallback?.Invoke(h, u) ?? false) ? 1u : 0u;
		ProWSDisconnectedCallback proWSDisconnectedCallback = delegate(ulong h, ProNetworkEndpointType e, nint u, nint uc)
		{
			DisconnectedWSCallback?.Invoke(h);
		};
		ProWSMessageCallback proWSMessageCallback = delegate(ulong h, ProNetworkEndpointType e, nint u, nint uc, nint m, nint r)
		{
			ProWSMessageData.__Internal* messageData = (ProWSMessageData.__Internal*)m;
			var (dataType, array) = messageData->dataType switch
			{
				ProWSDataType.Text => (ProWSDataType.Text, messages()), 
				ProWSDataType.Binary => (ProWSDataType.Binary, networkapi()), 
				_ => default((ProWSDataType, byte[])), 
			};
			if (array != null)
			{
				((ProWSMessageData.__Internal*)r)->dataType = dataType;
				((ProWSMessageData.__Internal*)r)->buffer = ProCore.DataTransferAlloc((uint)array.Length);
				((ProWSMessageData.__Internal*)r)->length = (ulong)array.Length;
				Marshal.Copy(array, 0, ((ProWSMessageData.__Internal*)r)->buffer, array.Length);
				return 1u;
			}
			return 0u;
			unsafe byte[] messages()
			{
				if (!_hasCoreShutDown && e.IsAnyOf(ProNetworkEndpointType.kProNetworkEndpointWebMessage, ProNetworkEndpointType.kProNetworkEndpointRemote, ProNetworkEndpointType.kProNetworkEndpointStage))
				{
					string @string = Encoding.UTF8.GetString((byte*)messageData->buffer, (int)messageData->length);
					string text = MessagesWSCallback?.Invoke(h, @string);
					if (text != null)
					{
						return Encoding.UTF8.GetBytes(text);
					}
				}
				return Array.Empty<byte>();
			}
			unsafe byte[] networkapi()
			{
				if (!_hasCoreShutDown && e == ProNetworkEndpointType.kProNetworkEndpointNetworkAPI)
				{
					UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)messageData->buffer, (int)messageData->length);
					ProApiIn proApiIn = ProApiIn.Parser.ParseFrom((Stream)input);
					if (proApiIn.NetworkApi != null)
					{
						NetworkAPICallback?.Invoke(proApiIn.NetworkApi);
					}
					else
					{
						if (proApiIn.NetworkApiV1 != null)
						{
							return APIV1Callback?.Invoke(proApiIn.NetworkApiV1)?.ToByteArray() ?? Array.Empty<byte>();
						}
						if (proApiIn.HandlerIn != null)
						{
							return LinkCallback?.Invoke(proApiIn.HandlerIn)?.ToByteArray() ?? Array.Empty<byte>();
						}
					}
				}
				return Array.Empty<byte>();
			}
		};
		RetainCallbacks(proWSConnectedCallback, proWSDisconnectedCallback, proWSMessageCallback);
		NetSetWSCallbacks(IntPtr.Zero, proWSConnectedCallback, proWSDisconnectedCallback, proWSMessageCallback);
	}

	public ProResult SendNetworkAPICommand(NetworkAPI? command)
	{
		return SendProtoAPIOut(new ProApiOut
		{
			NetworkApi = command
		});
	}

	public ProResult SendNetworkAPICommand(NetworkAPI_v1? v1)
	{
		return SendProtoAPIOut(new ProApiOut
		{
			NetworkApiV1 = v1
		});
	}

	public ProResult SendLinkAction(ProLink.Types.ClientAction protoClientAction)
	{
		return SendProtoAPIOut(new ProApiOut
		{
			ClientAction = protoClientAction
		});
	}

	private ProResult SendProtoAPIOut(ProApiOut protoApiOut)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = protoApiOut.ToByteArray();
		using ProWSMessageData proWSMessageData = new ProWSMessageData
		{
			DataType = ProWSDataType.Binary,
			Buffer = ProCore.DataTransferAlloc((uint)array.Length),
			Length = (ulong)array.Length
		};
		Marshal.Copy(array, 0, proWSMessageData.Buffer, array.Length);
		return NetSendNetworkAPIMessage(proWSMessageData);
	}

	public void SendLinkActionResponse(ProLink.Types.HandlerOut response)
	{
	}

	public unsafe ProResult NetSetNetworkMessageData(MessageDocument messageDocument)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = messageDocument.ToByteArray();
		fixed (byte* messageData = array)
		{
			return NetSetNetworkMessageData((nint)messageData, array.Length);
		}
	}

	public unsafe ProResult NetSendConfigurationMessage(ProNetworkConfigurationMessage config)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = config.ToByteArray();
		fixed (byte* messageData = array)
		{
			return NetSendConfigurationMessage((nint)messageData, array.Length);
		}
	}

	public ProResult NetWSSendClient(ulong clientHandle, string message)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] bytes = Encoding.UTF8.GetBytes(message);
		using ProWSMessageData proWSMessageData = new ProWSMessageData
		{
			DataType = ProWSDataType.Text,
			Buffer = ProCore.DataTransferAlloc((uint)bytes.Length),
			Length = (ulong)bytes.Length
		};
		Marshal.Copy(bytes, 0, proWSMessageData.Buffer, bytes.Length);
		return NetWSSendClient(clientHandle, proWSMessageData);
	}

	public unsafe TriggerHandle CreateTimedPlaybackSession(TimedPlayback timedPlayback)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = timedPlayback.ToByteArray();
		fixed (byte* sessionInfoData = array)
		{
			return new TriggerHandle(CreateTimedPlaybackSession((nint)sessionInfoData, array.Length));
		}
	}

	public ProResult DestroyTimedPlaybackSession(TriggerHandle handle)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		ulong sessionHandle = handle?.RawValue ?? TriggerHandle.Invalid.RawValue;
		return DestroyTimedPlaybackSession(sessionHandle);
	}

	public unsafe ProResult UpdateTimedPlaybackSession(TriggerHandle handle, TimedPlayback.Types.Update update)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = update.ToByteArray();
		ulong sessionHandle = handle?.RawValue ?? TriggerHandle.Invalid.RawValue;
		fixed (byte* sessionUpdateData = array)
		{
			return UpdateTimedPlaybackSession(sessionHandle, (nint)sessionUpdateData, array.Length);
		}
	}

	public TimedPlaybackStatus GetTimedPlaybackSessionStatus(TriggerHandle? handle)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		ulong sessionHandle = handle?.RawValue ?? TriggerHandle.Invalid.RawValue;
		TimedPlaybackStatus timedPlaybackStatus = new TimedPlaybackStatus();
		GetTimedPlaybackSessionStatus(sessionHandle, timedPlaybackStatus);
		return timedPlaybackStatus;
	}

	public unsafe ProResult TriggerClearSlotAction(ProLayerIndex layerIndex, Guid slotID, ProContentDestination contentDestination = ProContentDestination.Global)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		return __Internal.TriggerClearSlotAction(base.__Instance, contentDestination, layerIndex, new IntPtr(&slotID));
	}

	public ProResult TriggerClearLayerAction(ProLayerIndex layerIndex, ProContentDestination contentDestination = ProContentDestination.Global)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		return __Internal.TriggerClearLayerAction(base.__Instance, contentDestination, layerIndex);
	}

	public ProResult TriggerSlideElementUpdate(TriggerHandle trigger, Guid slideID, Guid elementID)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		return TriggerSlideElementUpdate(trigger.RawValue, new ProUUID
		{
			Bytes = slideID.ToByteArray()
		}, new ProUUID
		{
			Bytes = elementID.ToByteArray()
		});
	}

	public unsafe ProResult UpdateClearGroups(ClearGroupsDocument protoClearGroupsDocument)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = protoClearGroupsDocument.ToByteArray();
		fixed (byte* value = array)
		{
			return UpdateClearGroups(new IntPtr(value), array.Length);
		}
	}

	public unsafe ProResult UpdateMediaPlaybackMarkers(TriggerHandle handle, ProLayerIndex layer, Pro.SerializationInterop.RVProtoData.Action action)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		byte[] array = action.ToByteArray();
		fixed (byte* markerUpdateData = array)
		{
			return UpdateMediaPlaybackMarkers(handle.RawValue, layer, (nint)markerUpdateData, array.Length);
		}
	}

	private void InvokeOnDispatcherAsync(System.Action action)
	{
		if (_dispatcher.Thread.ManagedThreadId == Dispatcher.CurrentDispatcher.Thread.ManagedThreadId)
		{
			action();
		}
		else
		{
			_dispatcher.InvokeAsync(action);
		}
	}

	private void HandleCallbackSafe(System.Action body)
	{
		if (_hasCoreShutDown)
		{
			return;
		}
		try
		{
			body?.Invoke();
		}
		catch (Exception obj)
		{
			_exceptionHandler?.Invoke(obj);
		}
	}

	private unsafe void OperationStateChangedCallback(nint rawAddress, ProOperationState opState, nint userData)
	{
		HandleCallbackSafe(delegate
		{
			TriggerAddress triggerAddress = new TriggerAddress(rawAddress);
			OperationHandler?.Invoke(triggerAddress, opState);
			if (opState == ProOperationState.Released && triggerAddress.ClientObject != null)
			{
				ProTriggerAddress.__Internal* ptr = (ProTriggerAddress.__Internal*)((IntPtr)rawAddress).ToPointer();
				GCHandle.FromIntPtr(ptr->clientData).Free();
			}
		});
	}

	private unsafe void ResourceStateChangedCallback(nint rawAddress, ProResourceState resourceState, nint rawUpdateInfo, nint userData)
	{
		HandleCallbackSafe(delegate
		{
			ResourceAddress address = new ResourceAddress(rawAddress);
			ResourceUpdateInfo updateInfo = null;
			if (rawUpdateInfo != IntPtr.Zero && resourceState == ProResourceState.Updated)
			{
				updateInfo = ResourceUpdateInfo.FromNative((ProResourceUpdateInfo.__Internal*)((IntPtr)rawUpdateInfo).ToPointer());
			}
			ResourceHandler?.Invoke(address, resourceState, updateInfo);
		});
	}

	private unsafe void TransportStatusChangedCallback(nint rawResourceAddress, nint rawTransportStatus, nint userData)
	{
		HandleCallbackSafe(delegate
		{
			ProTransportStatus.__Internal copyForDispatch = *(ProTransportStatus.__Internal*)rawTransportStatus;
			ResourceAddress resourceAddress = new ResourceAddress(rawResourceAddress);
			InvokeOnDispatcherAsync(delegate
			{
				using ProTransportStatus transportStatus = ProTransportStatus.__CreateInstance(copyForDispatch);
				TransportStatusChanged?.Invoke(resourceAddress, transportStatus);
			});
		});
	}

	private unsafe void AudioInStatusChangedCallback(nint rawInputStatus, nint userData)
	{
		HandleCallbackSafe(delegate
		{
			ProAudioInputStatus.__Internal copyForDispatch = *(ProAudioInputStatus.__Internal*)rawInputStatus;
			InvokeOnDispatcherAsync(delegate
			{
				using ProAudioInputStatus audioInputStatus = ProAudioInputStatus.__CreateInstance(copyForDispatch);
				AudioInputStatusChanged?.Invoke(audioInputStatus);
			});
		});
	}

	private unsafe void OutputRecordingStatusChangedCallback(nint rawStatus, nint userData)
	{
		HandleCallbackSafe(delegate
		{
			ProScreenCaptureStatus.__Internal copyForDispatch = *(ProScreenCaptureStatus.__Internal*)rawStatus;
			InvokeOnDispatcherAsync(delegate
			{
				using ProScreenCaptureStatus screenCaptureStatus = ProScreenCaptureStatus.__CreateInstance(copyForDispatch);
				this.ScreenCaptureStatusChanged?.Invoke(this, new ScreenCaptureStatusEventArgs(screenCaptureStatus));
			});
		});
	}

	private unsafe void ResiTransferCallback(nint rawTransfer, nint userData)
	{
		HandleCallbackSafe(delegate
		{
			Transfer transfer = Transfer.FromNative((ProResiTransfer.__Internal*)rawTransfer);
			InvokeOnDispatcherAsync(delegate
			{
				ResiTransferHandler?.Invoke(transfer);
			});
		});
	}

	private unsafe void ImageRequestCallback(nint rawTransfer, nint userData)
	{
		HandleCallbackSafe(delegate
		{
			using ImageRequestTransfer imageRequestTransfer = new ImageRequestTransfer((ProImageRequestTransfer.__Internal*)rawTransfer);
			ImageRequestTransferHandler?.Invoke(imageRequestTransfer);
			imageRequestTransfer.Apply();
		});
	}

	private unsafe void SendDataResponseCallback(nint userData, nint responseProto, int size)
	{
		HandleCallbackSafe(delegate
		{
			if (responseProto != IntPtr.Zero)
			{
				UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)responseProto, size);
				SendDataResponse sendDataResponse = new SendDataResponse();
				((IMessage)sendDataResponse).MergeFrom((Stream)input);
				this.SendDataResponseReceived?.Invoke(this, new SendDataResponseEventArgs(sendDataResponse));
			}
		});
	}

	private void CloseDisplayButtonClickedCallback(ProScreenType screenType, nint userData)
	{
		HandleCallbackSafe(delegate
		{
			InvokeOnDispatcherAsync(delegate
			{
				CloseDisplayButtonClicked?.Invoke(screenType);
			});
		});
	}

	private unsafe void CommunicationCallback(nint communicationData, uint size, nint communicationUserData)
	{
		HandleCallbackSafe(delegate
		{
			if (communicationData != IntPtr.Zero)
			{
				UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)communicationData, size);
				Pro.SerializationInterop.RVProtoData.Action.Types.CommunicationType communicationType = new Pro.SerializationInterop.RVProtoData.Action.Types.CommunicationType();
				((IMessage)communicationType).MergeFrom((Stream)input);
				InvokeOnDispatcherAsync(delegate
				{
					SendCommunication?.Invoke(communicationType);
				});
			}
		});
	}

	private unsafe void VideoInputStatusChangedCallback(nint rawInputStatus, nint userData)
	{
		HandleCallbackSafe(delegate
		{
			ProVideoInputStatus.__Internal copyForDispatch = *(ProVideoInputStatus.__Internal*)rawInputStatus;
			InvokeOnDispatcherAsync(delegate
			{
				using ProVideoInputStatus videoInputStatus = ProVideoInputStatus.__CreateInstance(copyForDispatch);
				VideoInputStatusChanged?.Invoke(videoInputStatus);
			});
		});
	}

	private unsafe void AudioInputActionCallback(nint audioInputData, uint size, nint userData)
	{
		HandleCallbackSafe(delegate
		{
			if (audioInputData != IntPtr.Zero)
			{
				UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)audioInputData, size);
				Pro.SerializationInterop.RVProtoData.Action.Types.AudioInputType audioInputAction = new Pro.SerializationInterop.RVProtoData.Action.Types.AudioInputType();
				((IMessage)audioInputAction).MergeFrom((Stream)input);
				InvokeOnDispatcherAsync(delegate
				{
					UpdateAudioInput?.Invoke(audioInputAction);
				});
			}
		});
	}

	private unsafe void TriggerTransferCallback(nint rawAddress, nint rawRequest, nint userData)
	{
		HandleCallbackSafe(delegate
		{
			TriggerTransfer transfer = TriggerTransfer.FromNative((ProTriggerTransfer.__Internal*)rawRequest);
			try
			{
				if (transfer == null)
				{
					string message = $"Unhandled trigger transfer of type '{((ProTriggerTransfer.__Internal*)rawRequest)->type}'; trigger is likely incomplete or incorrect.";
					_messageCallback(ProMessageType.Warning, message, IntPtr.Zero);
				}
				else
				{
					TriggerAddress address = new TriggerAddress(rawAddress);
					Dispatcher.CurrentDispatcher.Invoke((System.Action)delegate
					{
						TriggerTransferHandler?.Invoke(address, transfer);
					});
					transfer.Apply();
				}
			}
			finally
			{
				if (transfer != null)
				{
					((IDisposable)transfer).Dispose();
				}
			}
		});
	}

	private unsafe void AsyncTriggerTransferCallback(nint rawAddress, nint rawRequest, nint userData)
	{
		HandleCallbackSafe(delegate
		{
			AsyncTriggerTransfer transfer = AsyncTriggerTransfer.FromNative((ProAsyncTriggerTransferRequest.__Internal*)rawRequest);
			if (transfer == null)
			{
				string message = $"Unhandled async trigger transfer of type '{((ProAsyncTriggerTransferRequest.__Internal*)rawRequest)->type}'; trigger is likely incomplete or incorrect.";
				_messageCallback(ProMessageType.Warning, message, IntPtr.Zero);
			}
			else
			{
				TriggerAddress address = new TriggerAddress(rawAddress);
				InvokeOnDispatcherAsync(delegate
				{
					AsyncTriggerTransferHandler?.Invoke(address, transfer);
				});
			}
		});
	}

	private void RetainCallbacks(params Delegate[] callbacks)
	{
		lock (_delegateHandles)
		{
			_delegateHandles.AddRange(callbacks);
		}
	}

	private void ReleaseCallbacks(params Delegate[] callbacks)
	{
		lock (_delegateHandles)
		{
			_delegateHandles.RemoveRange(callbacks);
		}
	}

	private T InvokeWithCallbacks<T>(Func<T> call, params Delegate[] callbacks)
	{
		ObjectDisposedException.ThrowIf(_hasCoreShutDown, this);
		RetainCallbacks(callbacks);
		T result = call();
		ReleaseCallbacks(callbacks);
		return result;
	}

	public unsafe ProResult SendData(SendData data, out int messageId)
	{
		if (data.MessageId == 0)
		{
			uint messageId2 = Interlocked.Increment(ref _sendDataIdCounter) % 16777216 + 1;
			data.MessageId = (int)messageId2;
		}
		messageId = data.MessageId;
		byte[] array = data.ToByteArray();
		fixed (byte* value = array)
		{
			return SendData(new IntPtr(value), array.Length);
		}
	}

	public unsafe ProResult RenderTestPatternPreview(TestPatternState testPattern, nint texture, int textureWidth, int textureHeight)
	{
		byte[] array = testPattern.ToByteArray();
		fixed (byte* value = array)
		{
			return RenderTestPatternPreview(new IntPtr(value), array.Length, texture, textureWidth, textureHeight);
		}
	}

	public ProResult RenderVideoInputPreview(nint texture, int textureWidth, int textureHeight)
	{
		return RenderPreview(ProRenderViewType.VideoInputPreferenceTab, texture, textureWidth, textureHeight);
	}

	public ProResult RenderOutputPreview(ProRenderViewType viewType, nint texture, int textureWidth, int textureHeight)
	{
		return RenderPreview(viewType, texture, textureWidth, textureHeight);
	}

	public bool DirectXVersionMeetsMinimumRequirements()
	{
		int meetsMinReq = 0;
		if (GpuMeetsMinRequirement(ref meetsMinReq) == ProResult.Success)
		{
			return meetsMinReq != 0;
		}
		return false;
	}

	public void CreateOutputWindow(Guid screenID)
	{
		ProUUID screenID2 = new ProUUID
		{
			Bytes = screenID.ToByteArray()
		};
		CreateOutputWindow(screenID2);
	}
}
