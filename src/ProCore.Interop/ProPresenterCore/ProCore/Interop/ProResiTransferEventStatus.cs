using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProResiTransferEventStatus : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 36)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProResiTransferType type;

		[FieldOffset(4)]
		internal uint success;

		[FieldOffset(8)]
		internal ProResiEventStatus.__Internal status;
	}

	internal static readonly ConcurrentDictionary<nint, ProResiTransferEventStatus> NativeToManagedMap = new ConcurrentDictionary<nint, ProResiTransferEventStatus>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProResiTransferType Type
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

	public unsafe bool Success
	{
		get
		{
			return ((__Internal*)__Instance)->success != 0;
		}
		set
		{
			((__Internal*)__Instance)->success = (value ? 1u : 0u);
		}
	}

	public unsafe ProResiEventStatus Status
	{
		get
		{
			return ProResiEventStatus.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->status));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->status = *(ProResiEventStatus.__Internal*)value.__Instance;
		}
	}

	internal unsafe static ProResiTransferEventStatus __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProResiTransferEventStatus(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProResiTransferEventStatus __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProResiTransferEventStatus(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProResiTransferEventStatus(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProResiTransferEventStatus(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProResiTransferEventStatus()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProResiTransferEventStatus()
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
