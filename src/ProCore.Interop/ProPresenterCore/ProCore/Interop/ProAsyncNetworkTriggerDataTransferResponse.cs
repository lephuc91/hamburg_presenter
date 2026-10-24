using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProAsyncNetworkTriggerDataTransferResponse : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProAsyncTriggerTransferResponse.__Internal header;

		[FieldOffset(8)]
		internal nint data;

		[FieldOffset(16)]
		internal uint dataLength;

		[FieldOffset(24)]
		internal nint clientData;
	}

	internal static readonly ConcurrentDictionary<nint, ProAsyncNetworkTriggerDataTransferResponse> NativeToManagedMap = new ConcurrentDictionary<nint, ProAsyncNetworkTriggerDataTransferResponse>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProAsyncTriggerTransferResponse Header
	{
		get
		{
			return ProAsyncTriggerTransferResponse.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->header));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->header = *(ProAsyncTriggerTransferResponse.__Internal*)value.__Instance;
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

	public unsafe nint ClientData
	{
		get
		{
			return ((__Internal*)__Instance)->clientData;
		}
		set
		{
			((__Internal*)__Instance)->clientData = value;
		}
	}

	internal unsafe static ProAsyncNetworkTriggerDataTransferResponse __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProAsyncNetworkTriggerDataTransferResponse(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProAsyncNetworkTriggerDataTransferResponse __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProAsyncNetworkTriggerDataTransferResponse(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProAsyncNetworkTriggerDataTransferResponse(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProAsyncNetworkTriggerDataTransferResponse(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProAsyncNetworkTriggerDataTransferResponse()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProAsyncNetworkTriggerDataTransferResponse()
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
