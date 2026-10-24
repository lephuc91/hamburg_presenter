using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProClientImageTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(4)]
		internal uint width;

		[FieldOffset(8)]
		internal uint height;

		[FieldOffset(16)]
		internal nint pixels;
	}

	internal static readonly ConcurrentDictionary<nint, ProClientImageTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProClientImageTransfer>();

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

	public unsafe uint Width
	{
		get
		{
			return ((__Internal*)__Instance)->width;
		}
		set
		{
			((__Internal*)__Instance)->width = value;
		}
	}

	public unsafe uint Height
	{
		get
		{
			return ((__Internal*)__Instance)->height;
		}
		set
		{
			((__Internal*)__Instance)->height = value;
		}
	}

	public unsafe nint Pixels
	{
		get
		{
			return ((__Internal*)__Instance)->pixels;
		}
		set
		{
			((__Internal*)__Instance)->pixels = value;
		}
	}

	internal unsafe static ProClientImageTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProClientImageTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProClientImageTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProClientImageTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProClientImageTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProClientImageTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProClientImageTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProClientImageTransfer()
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
