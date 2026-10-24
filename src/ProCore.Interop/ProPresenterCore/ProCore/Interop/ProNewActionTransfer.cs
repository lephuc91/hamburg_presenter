using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProNewActionTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(4)]
		internal uint newActionDataSize;

		[FieldOffset(8)]
		internal nint newActionData;
	}

	internal static readonly ConcurrentDictionary<nint, ProNewActionTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProNewActionTransfer>();

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

	public unsafe uint NewActionDataSize
	{
		get
		{
			return ((__Internal*)__Instance)->newActionDataSize;
		}
		set
		{
			((__Internal*)__Instance)->newActionDataSize = value;
		}
	}

	public unsafe nint NewActionData
	{
		get
		{
			return ((__Internal*)__Instance)->newActionData;
		}
		set
		{
			((__Internal*)__Instance)->newActionData = value;
		}
	}

	internal unsafe static ProNewActionTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProNewActionTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProNewActionTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProNewActionTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProNewActionTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProNewActionTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProNewActionTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProNewActionTransfer()
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
