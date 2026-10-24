using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProImageRequestTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProImageRequestTransferType type;

		[FieldOffset(8)]
		internal nint image;

		[FieldOffset(16)]
		internal uint imageSize;
	}

	internal static readonly ConcurrentDictionary<nint, ProImageRequestTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProImageRequestTransfer>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProImageRequestTransferType Type
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

	public unsafe nint Image
	{
		get
		{
			return ((__Internal*)__Instance)->image;
		}
		set
		{
			((__Internal*)__Instance)->image = value;
		}
	}

	public unsafe uint ImageSize
	{
		get
		{
			return ((__Internal*)__Instance)->imageSize;
		}
		set
		{
			((__Internal*)__Instance)->imageSize = value;
		}
	}

	internal unsafe static ProImageRequestTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProImageRequestTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProImageRequestTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProImageRequestTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProImageRequestTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProImageRequestTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProImageRequestTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProImageRequestTransfer()
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
