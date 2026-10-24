using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

public class ProAsyncTriggerTransferRequest : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(8)]
		internal nint callback;

		[FieldOffset(16)]
		internal nint callbackUserData;

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "??0ProAsyncTriggerTransferRequest@@QEAA@W4ProTriggerTransferType@@P6AXPEBUProAsyncTriggerTransferResponse@@PEAX@Z2@Z")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern nint ctor(nint __instance, ProTriggerTransferType type, nint callback, nint userData);
	}

	internal static readonly ConcurrentDictionary<nint, ProAsyncTriggerTransferRequest> NativeToManagedMap = new ConcurrentDictionary<nint, ProAsyncTriggerTransferRequest>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProTriggerTransferType Type
	{
		get
		{
			return ((__Internal*)__Instance)->type;
		}
		set
		{
			((__Internal*)__Instance)->type = value;
		}
	}

	public unsafe ProAsyncTriggerTransferRequestCallback Callback
	{
		get
		{
			nint callback = ((__Internal*)__Instance)->callback;
			if (callback != IntPtr.Zero)
			{
				return (ProAsyncTriggerTransferRequestCallback)Marshal.GetDelegateForFunctionPointer(callback, typeof(ProAsyncTriggerTransferRequestCallback));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->callback = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	public unsafe nint CallbackUserData
	{
		get
		{
			return ((__Internal*)__Instance)->callbackUserData;
		}
		set
		{
			((__Internal*)__Instance)->callbackUserData = value;
		}
	}

	internal unsafe static ProAsyncTriggerTransferRequest __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProAsyncTriggerTransferRequest(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProAsyncTriggerTransferRequest __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProAsyncTriggerTransferRequest(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProAsyncTriggerTransferRequest(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProAsyncTriggerTransferRequest(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProAsyncTriggerTransferRequest(ProTriggerTransferType type, ProAsyncTriggerTransferRequestCallback callback, nint userData)
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
		nint callback2 = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		__Internal.ctor(__Instance, type, callback2, userData);
	}

	~ProAsyncTriggerTransferRequest()
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
