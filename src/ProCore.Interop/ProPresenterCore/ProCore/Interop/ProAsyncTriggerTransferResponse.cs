using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProAsyncTriggerTransferResponse : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProResult result;
	}

	internal static readonly ConcurrentDictionary<nint, ProAsyncTriggerTransferResponse> NativeToManagedMap = new ConcurrentDictionary<nint, ProAsyncTriggerTransferResponse>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProResult Result
	{
		get
		{
			return ((__Internal*)__Instance)->result;
		}
		set
		{
			((__Internal*)__Instance)->result = value;
		}
	}

	internal unsafe static ProAsyncTriggerTransferResponse __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProAsyncTriggerTransferResponse(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProAsyncTriggerTransferResponse __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProAsyncTriggerTransferResponse(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProAsyncTriggerTransferResponse(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProAsyncTriggerTransferResponse(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProAsyncTriggerTransferResponse()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProAsyncTriggerTransferResponse()
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
