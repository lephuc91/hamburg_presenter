using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProCoreInstanceCreateInfo : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 328)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProVersionInformation.__Internal versionInformation;

		[FieldOffset(16)]
		internal ProCoreRenderMode renderMode;

		[FieldOffset(20)]
		internal ProCoreRenderStatsLevel renderStatsLevel;

		[FieldOffset(24)]
		internal ProNDIFinderSettings.__Internal ndiFinderSettings;

		[FieldOffset(48)]
		internal ProCoreRenderBitDepth renderBitDepth;

		[FieldOffset(56)]
		internal nint messageCallback;

		[FieldOffset(64)]
		internal nint messageCallbackUserData;

		[FieldOffset(72)]
		internal nint triggerTransferCallback;

		[FieldOffset(80)]
		internal nint triggerTransferUserData;

		[FieldOffset(88)]
		internal nint asyncTriggerTransferCallback;

		[FieldOffset(96)]
		internal nint asyncTriggerTransferUserData;

		[FieldOffset(104)]
		internal nint operationStateCallback;

		[FieldOffset(112)]
		internal nint operationStateUserData;

		[FieldOffset(120)]
		internal nint resourceStateCallback;

		[FieldOffset(128)]
		internal nint resourceStateUserData;

		[FieldOffset(136)]
		internal nint transportStatusCallback;

		[FieldOffset(144)]
		internal nint transportStatusUserData;

		[FieldOffset(152)]
		internal nint audioInputStatusCallback;

		[FieldOffset(160)]
		internal nint audioInputStatusUserData;

		[FieldOffset(168)]
		internal nint screenCaptureStatusCallback;

		[FieldOffset(176)]
		internal nint screenCaptureStatusUserData;

		[FieldOffset(184)]
		internal nint resiCallback;

		[FieldOffset(192)]
		internal nint resiCallbackUserData;

		[FieldOffset(200)]
		internal nint closeDisplayButtonCallback;

		[FieldOffset(208)]
		internal nint closeDisplayButtonUserData;

		[FieldOffset(216)]
		internal nint communicationCallback;

		[FieldOffset(224)]
		internal nint communicationUserData;

		[FieldOffset(232)]
		internal nint videoInputCallback;

		[FieldOffset(240)]
		internal nint videoInputUserData;

		[FieldOffset(248)]
		internal nint audioInputActionCallback;

		[FieldOffset(256)]
		internal nint audioInputActionUserData;

		[FieldOffset(264)]
		internal nint imageRequestCallback;

		[FieldOffset(272)]
		internal nint imageRequestCallbackUserData;

		[FieldOffset(280)]
		internal nint sendDataResponseCallback;

		[FieldOffset(288)]
		internal nint sendDataResponseCallbackUserData;

		[FieldOffset(296)]
		internal nint rendererMock;

		[FieldOffset(304)]
		internal nint featureFlagsData;

		[FieldOffset(312)]
		internal int featureFlagsDataSize;

		[FieldOffset(320)]
		internal nint advertisementsLogLocation;
	}

	internal static readonly ConcurrentDictionary<nint, ProCoreInstanceCreateInfo> NativeToManagedMap = new ConcurrentDictionary<nint, ProCoreInstanceCreateInfo>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProVersionInformation VersionInformation
	{
		get
		{
			return ProVersionInformation.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->versionInformation));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->versionInformation = *(ProVersionInformation.__Internal*)value.__Instance;
		}
	}

	public unsafe ProCoreRenderMode RenderMode
	{
		get
		{
			return ((__Internal*)__Instance)->renderMode;
		}
		set
		{
			((__Internal*)__Instance)->renderMode = value;
		}
	}

	public unsafe ProCoreRenderStatsLevel RenderStatsLevel
	{
		get
		{
			return ((__Internal*)__Instance)->renderStatsLevel;
		}
		set
		{
			((__Internal*)__Instance)->renderStatsLevel = value;
		}
	}

	public unsafe ProNDIFinderSettings NdiFinderSettings
	{
		get
		{
			return ProNDIFinderSettings.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->ndiFinderSettings));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->ndiFinderSettings = *(ProNDIFinderSettings.__Internal*)value.__Instance;
		}
	}

	public unsafe ProCoreRenderBitDepth RenderBitDepth
	{
		get
		{
			return ((__Internal*)__Instance)->renderBitDepth;
		}
		set
		{
			((__Internal*)__Instance)->renderBitDepth = value;
		}
	}

	public unsafe ProMessageCallback MessageCallback
	{
		get
		{
			nint messageCallback = ((__Internal*)__Instance)->messageCallback;
			if (messageCallback != IntPtr.Zero)
			{
				return (ProMessageCallback)Marshal.GetDelegateForFunctionPointer(messageCallback, typeof(ProMessageCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->messageCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint MessageCallbackUserData
	{
		get
		{
			return ((__Internal*)__Instance)->messageCallbackUserData;
		}
		set
		{
			((__Internal*)__Instance)->messageCallbackUserData = value;
		}
	}

	public unsafe ProTriggerTransferCallback TriggerTransferCallback
	{
		get
		{
			nint triggerTransferCallback = ((__Internal*)__Instance)->triggerTransferCallback;
			if (triggerTransferCallback != IntPtr.Zero)
			{
				return (ProTriggerTransferCallback)Marshal.GetDelegateForFunctionPointer(triggerTransferCallback, typeof(ProTriggerTransferCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->triggerTransferCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint TriggerTransferUserData
	{
		get
		{
			return ((__Internal*)__Instance)->triggerTransferUserData;
		}
		set
		{
			((__Internal*)__Instance)->triggerTransferUserData = value;
		}
	}

	public unsafe ProAsyncTriggerTransferCallback AsyncTriggerTransferCallback
	{
		get
		{
			nint asyncTriggerTransferCallback = ((__Internal*)__Instance)->asyncTriggerTransferCallback;
			if (asyncTriggerTransferCallback != IntPtr.Zero)
			{
				return (ProAsyncTriggerTransferCallback)Marshal.GetDelegateForFunctionPointer(asyncTriggerTransferCallback, typeof(ProAsyncTriggerTransferCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->asyncTriggerTransferCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint AsyncTriggerTransferUserData
	{
		get
		{
			return ((__Internal*)__Instance)->asyncTriggerTransferUserData;
		}
		set
		{
			((__Internal*)__Instance)->asyncTriggerTransferUserData = value;
		}
	}

	public unsafe ProOperationStateChangedCallback OperationStateCallback
	{
		get
		{
			nint operationStateCallback = ((__Internal*)__Instance)->operationStateCallback;
			if (operationStateCallback != IntPtr.Zero)
			{
				return (ProOperationStateChangedCallback)Marshal.GetDelegateForFunctionPointer(operationStateCallback, typeof(ProOperationStateChangedCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->operationStateCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint OperationStateUserData
	{
		get
		{
			return ((__Internal*)__Instance)->operationStateUserData;
		}
		set
		{
			((__Internal*)__Instance)->operationStateUserData = value;
		}
	}

	public unsafe ProResourceStateChangedCallback ResourceStateCallback
	{
		get
		{
			nint resourceStateCallback = ((__Internal*)__Instance)->resourceStateCallback;
			if (resourceStateCallback != IntPtr.Zero)
			{
				return (ProResourceStateChangedCallback)Marshal.GetDelegateForFunctionPointer(resourceStateCallback, typeof(ProResourceStateChangedCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->resourceStateCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint ResourceStateUserData
	{
		get
		{
			return ((__Internal*)__Instance)->resourceStateUserData;
		}
		set
		{
			((__Internal*)__Instance)->resourceStateUserData = value;
		}
	}

	public unsafe ProTransportStatusChangedCallback TransportStatusCallback
	{
		get
		{
			nint transportStatusCallback = ((__Internal*)__Instance)->transportStatusCallback;
			if (transportStatusCallback != IntPtr.Zero)
			{
				return (ProTransportStatusChangedCallback)Marshal.GetDelegateForFunctionPointer(transportStatusCallback, typeof(ProTransportStatusChangedCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->transportStatusCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint TransportStatusUserData
	{
		get
		{
			return ((__Internal*)__Instance)->transportStatusUserData;
		}
		set
		{
			((__Internal*)__Instance)->transportStatusUserData = value;
		}
	}

	public unsafe ProAudioInputStatusChangedCallback AudioInputStatusCallback
	{
		get
		{
			nint audioInputStatusCallback = ((__Internal*)__Instance)->audioInputStatusCallback;
			if (audioInputStatusCallback != IntPtr.Zero)
			{
				return (ProAudioInputStatusChangedCallback)Marshal.GetDelegateForFunctionPointer(audioInputStatusCallback, typeof(ProAudioInputStatusChangedCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->audioInputStatusCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint AudioInputStatusUserData
	{
		get
		{
			return ((__Internal*)__Instance)->audioInputStatusUserData;
		}
		set
		{
			((__Internal*)__Instance)->audioInputStatusUserData = value;
		}
	}

	public unsafe ProScreenCaptureStatusChangedCallback ScreenCaptureStatusCallback
	{
		get
		{
			nint screenCaptureStatusCallback = ((__Internal*)__Instance)->screenCaptureStatusCallback;
			if (screenCaptureStatusCallback != IntPtr.Zero)
			{
				return (ProScreenCaptureStatusChangedCallback)Marshal.GetDelegateForFunctionPointer(screenCaptureStatusCallback, typeof(ProScreenCaptureStatusChangedCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->screenCaptureStatusCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint ScreenCaptureStatusUserData
	{
		get
		{
			return ((__Internal*)__Instance)->screenCaptureStatusUserData;
		}
		set
		{
			((__Internal*)__Instance)->screenCaptureStatusUserData = value;
		}
	}

	public unsafe ProResiCallback ResiCallback
	{
		get
		{
			nint resiCallback = ((__Internal*)__Instance)->resiCallback;
			if (resiCallback != IntPtr.Zero)
			{
				return (ProResiCallback)Marshal.GetDelegateForFunctionPointer(resiCallback, typeof(ProResiCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->resiCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint ResiCallbackUserData
	{
		get
		{
			return ((__Internal*)__Instance)->resiCallbackUserData;
		}
		set
		{
			((__Internal*)__Instance)->resiCallbackUserData = value;
		}
	}

	public unsafe ProCloseDisplayButtonClickedCallback CloseDisplayButtonCallback
	{
		get
		{
			nint closeDisplayButtonCallback = ((__Internal*)__Instance)->closeDisplayButtonCallback;
			if (closeDisplayButtonCallback != IntPtr.Zero)
			{
				return (ProCloseDisplayButtonClickedCallback)Marshal.GetDelegateForFunctionPointer(closeDisplayButtonCallback, typeof(ProCloseDisplayButtonClickedCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->closeDisplayButtonCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint CloseDisplayButtonUserData
	{
		get
		{
			return ((__Internal*)__Instance)->closeDisplayButtonUserData;
		}
		set
		{
			((__Internal*)__Instance)->closeDisplayButtonUserData = value;
		}
	}

	public unsafe ProCommunicationCallback CommunicationCallback
	{
		get
		{
			nint communicationCallback = ((__Internal*)__Instance)->communicationCallback;
			if (communicationCallback != IntPtr.Zero)
			{
				return (ProCommunicationCallback)Marshal.GetDelegateForFunctionPointer(communicationCallback, typeof(ProCommunicationCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->communicationCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint CommunicationUserData
	{
		get
		{
			return ((__Internal*)__Instance)->communicationUserData;
		}
		set
		{
			((__Internal*)__Instance)->communicationUserData = value;
		}
	}

	public unsafe ProVideoInputStatusChangedCallback VideoInputCallback
	{
		get
		{
			nint videoInputCallback = ((__Internal*)__Instance)->videoInputCallback;
			if (videoInputCallback != IntPtr.Zero)
			{
				return (ProVideoInputStatusChangedCallback)Marshal.GetDelegateForFunctionPointer(videoInputCallback, typeof(ProVideoInputStatusChangedCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->videoInputCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint VideoInputUserData
	{
		get
		{
			return ((__Internal*)__Instance)->videoInputUserData;
		}
		set
		{
			((__Internal*)__Instance)->videoInputUserData = value;
		}
	}

	public unsafe ProAudioInputActionCallback AudioInputActionCallback
	{
		get
		{
			nint audioInputActionCallback = ((__Internal*)__Instance)->audioInputActionCallback;
			if (audioInputActionCallback != IntPtr.Zero)
			{
				return (ProAudioInputActionCallback)Marshal.GetDelegateForFunctionPointer(audioInputActionCallback, typeof(ProAudioInputActionCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->audioInputActionCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint AudioInputActionUserData
	{
		get
		{
			return ((__Internal*)__Instance)->audioInputActionUserData;
		}
		set
		{
			((__Internal*)__Instance)->audioInputActionUserData = value;
		}
	}

	public unsafe ProImageRequestCallback ImageRequestCallback
	{
		get
		{
			nint imageRequestCallback = ((__Internal*)__Instance)->imageRequestCallback;
			if (imageRequestCallback != IntPtr.Zero)
			{
				return (ProImageRequestCallback)Marshal.GetDelegateForFunctionPointer(imageRequestCallback, typeof(ProImageRequestCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->imageRequestCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint ImageRequestCallbackUserData
	{
		get
		{
			return ((__Internal*)__Instance)->imageRequestCallbackUserData;
		}
		set
		{
			((__Internal*)__Instance)->imageRequestCallbackUserData = value;
		}
	}

	public unsafe ProSendDataResponseCallback SendDataResponseCallback
	{
		get
		{
			nint sendDataResponseCallback = ((__Internal*)__Instance)->sendDataResponseCallback;
			if (sendDataResponseCallback != IntPtr.Zero)
			{
				return (ProSendDataResponseCallback)Marshal.GetDelegateForFunctionPointer(sendDataResponseCallback, typeof(ProSendDataResponseCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->sendDataResponseCallback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint SendDataResponseCallbackUserData
	{
		get
		{
			return ((__Internal*)__Instance)->sendDataResponseCallbackUserData;
		}
		set
		{
			((__Internal*)__Instance)->sendDataResponseCallbackUserData = value;
		}
	}

	public unsafe nint RendererMock
	{
		get
		{
			return ((__Internal*)__Instance)->rendererMock;
		}
		set
		{
			((__Internal*)__Instance)->rendererMock = value;
		}
	}

	public unsafe nint FeatureFlagsData
	{
		get
		{
			return ((__Internal*)__Instance)->featureFlagsData;
		}
		set
		{
			((__Internal*)__Instance)->featureFlagsData = value;
		}
	}

	public unsafe int FeatureFlagsDataSize
	{
		get
		{
			return ((__Internal*)__Instance)->featureFlagsDataSize;
		}
		set
		{
			((__Internal*)__Instance)->featureFlagsDataSize = value;
		}
	}

	public unsafe string AdvertisementsLogLocation
	{
		get
		{
			if (((__Internal*)__Instance)->advertisementsLogLocation == IntPtr.Zero)
			{
				return null;
			}
			byte* advertisementsLogLocation = (byte*)((__Internal*)__Instance)->advertisementsLogLocation;
			int num = 0;
			while (*(advertisementsLogLocation++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->advertisementsLogLocation, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->advertisementsLogLocation = new IntPtr(bytes);
			}
		}
	}

	internal unsafe static ProCoreInstanceCreateInfo __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProCoreInstanceCreateInfo(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProCoreInstanceCreateInfo __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProCoreInstanceCreateInfo(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProCoreInstanceCreateInfo(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProCoreInstanceCreateInfo(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProCoreInstanceCreateInfo()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProCoreInstanceCreateInfo()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public virtual void Dispose(bool disposing)
	{
		if (__Instance != IntPtr.Zero)
		{
			NativeToManagedMap.TryRemove(__Instance, out var _);
			if (__ownsNativeInstance)
			{
				Marshal.FreeHGlobal(__Instance);
			}
			__Instance = IntPtr.Zero;
		}
	}
}
