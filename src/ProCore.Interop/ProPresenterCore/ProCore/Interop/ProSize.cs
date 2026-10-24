using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProSize : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal float width;

		[FieldOffset(4)]
		internal float height;
	}

	internal static readonly ConcurrentDictionary<nint, ProSize> NativeToManagedMap = new ConcurrentDictionary<nint, ProSize>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe float Width
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

	public unsafe float Height
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

	internal unsafe static ProSize __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProSize(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProSize __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProSize(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProSize(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProSize(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProSize()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProSize()
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
