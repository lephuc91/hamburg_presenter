using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProPoint : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal float x;

		[FieldOffset(4)]
		internal float y;
	}

	internal static readonly ConcurrentDictionary<nint, ProPoint> NativeToManagedMap = new ConcurrentDictionary<nint, ProPoint>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe float X
	{
		get
		{
			return ((__Internal*)__Instance)->x;
		}
		set
		{
			((__Internal*)__Instance)->x = value;
		}
	}

	public unsafe float Y
	{
		get
		{
			return ((__Internal*)__Instance)->y;
		}
		set
		{
			((__Internal*)__Instance)->y = value;
		}
	}

	internal unsafe static ProPoint __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProPoint(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProPoint __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProPoint(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProPoint(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProPoint(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProPoint()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProPoint()
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
