using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProInsets : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal float left;

		[FieldOffset(4)]
		internal float right;

		[FieldOffset(8)]
		internal float top;

		[FieldOffset(12)]
		internal float bottom;
	}

	internal static readonly ConcurrentDictionary<nint, ProInsets> NativeToManagedMap = new ConcurrentDictionary<nint, ProInsets>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe float Left
	{
		get
		{
			return ((__Internal*)__Instance)->left;
		}
		set
		{
			((__Internal*)__Instance)->left = value;
		}
	}

	public unsafe float Right
	{
		get
		{
			return ((__Internal*)__Instance)->right;
		}
		set
		{
			((__Internal*)__Instance)->right = value;
		}
	}

	public unsafe float Top
	{
		get
		{
			return ((__Internal*)__Instance)->top;
		}
		set
		{
			((__Internal*)__Instance)->top = value;
		}
	}

	public unsafe float Bottom
	{
		get
		{
			return ((__Internal*)__Instance)->bottom;
		}
		set
		{
			((__Internal*)__Instance)->bottom = value;
		}
	}

	internal unsafe static ProInsets __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProInsets(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProInsets __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProInsets(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProInsets(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProInsets(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProInsets()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProInsets()
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
