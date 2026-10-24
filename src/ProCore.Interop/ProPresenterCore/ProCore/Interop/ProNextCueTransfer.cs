using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProNextCueTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(8)]
		internal ulong nextHandle;

		[FieldOffset(16)]
		internal uint nextCueSize;

		[FieldOffset(24)]
		internal nint nextCueData;

		[FieldOffset(32)]
		internal nint clientData;

		[FieldOffset(40)]
		internal uint triggerOptionsSize;

		[FieldOffset(48)]
		internal nint triggerOptionsData;
	}

	internal static readonly ConcurrentDictionary<nint, ProNextCueTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProNextCueTransfer>();

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

	public unsafe ulong NextHandle
	{
		get
		{
			return ((__Internal*)__Instance)->nextHandle;
		}
		set
		{
			((__Internal*)__Instance)->nextHandle = value;
		}
	}

	public unsafe uint NextCueSize
	{
		get
		{
			return ((__Internal*)__Instance)->nextCueSize;
		}
		set
		{
			((__Internal*)__Instance)->nextCueSize = value;
		}
	}

	public unsafe nint NextCueData
	{
		get
		{
			return ((__Internal*)__Instance)->nextCueData;
		}
		set
		{
			((__Internal*)__Instance)->nextCueData = value;
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

	public unsafe uint TriggerOptionsSize
	{
		get
		{
			return ((__Internal*)__Instance)->triggerOptionsSize;
		}
		set
		{
			((__Internal*)__Instance)->triggerOptionsSize = value;
		}
	}

	public unsafe nint TriggerOptionsData
	{
		get
		{
			return ((__Internal*)__Instance)->triggerOptionsData;
		}
		set
		{
			((__Internal*)__Instance)->triggerOptionsData = value;
		}
	}

	internal unsafe static ProNextCueTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProNextCueTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProNextCueTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProNextCueTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProNextCueTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProNextCueTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProNextCueTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProNextCueTransfer()
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
