using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

public class ProAsyncNetworkTriggerDataTransferRequest : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProAsyncTriggerTransferRequest.__Internal header;

		[FieldOffset(24)]
		internal ulong triggerHandle;

		[FieldOffset(32)]
		internal ProTriggerDataRequestType dataType;

		[FieldOffset(40)]
		internal nint data;

		[FieldOffset(48)]
		internal uint dataLength;

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "??0ProAsyncNetworkTriggerDataTransferRequest@@QEAA@P6AXPEBUProAsyncTriggerTransferResponse@@PEAX@Z1_KW4ProTriggerDataRequestType@@PEBXI@Z")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern nint ctor(nint __instance, nint callback, nint userData, ulong triggerHandle_, ProTriggerDataRequestType dataType_, nint data_, uint dataLength_);
	}

	internal static readonly ConcurrentDictionary<nint, ProAsyncNetworkTriggerDataTransferRequest> NativeToManagedMap = new ConcurrentDictionary<nint, ProAsyncNetworkTriggerDataTransferRequest>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProAsyncTriggerTransferRequest Header
	{
		get
		{
			return ProAsyncTriggerTransferRequest.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->header));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->header = *(ProAsyncTriggerTransferRequest.__Internal*)value.__Instance;
		}
	}

	public unsafe ulong TriggerHandle
	{
		get
		{
			return ((__Internal*)__Instance)->triggerHandle;
		}
		set
		{
			((__Internal*)__Instance)->triggerHandle = value;
		}
	}

	public unsafe ProTriggerDataRequestType DataType
	{
		get
		{
			return ((__Internal*)__Instance)->dataType;
		}
		set
		{
			((__Internal*)__Instance)->dataType = value;
		}
	}

	public unsafe nint Data => ((__Internal*)__Instance)->data;

	public unsafe uint DataLength
	{
		get
		{
			return ((__Internal*)__Instance)->dataLength;
		}
		set
		{
			((__Internal*)__Instance)->dataLength = value;
		}
	}

	internal unsafe static ProAsyncNetworkTriggerDataTransferRequest __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProAsyncNetworkTriggerDataTransferRequest(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProAsyncNetworkTriggerDataTransferRequest __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProAsyncNetworkTriggerDataTransferRequest(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProAsyncNetworkTriggerDataTransferRequest(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProAsyncNetworkTriggerDataTransferRequest(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProAsyncNetworkTriggerDataTransferRequest(ProAsyncTriggerTransferRequestCallback callback, nint userData, ulong triggerHandle_, ProTriggerDataRequestType dataType_, nint data_, uint dataLength_)
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		__Internal.ctor(__Instance, callback2, userData, triggerHandle_, dataType_, data_, dataLength_);
	}

	~ProAsyncNetworkTriggerDataTransferRequest()
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
