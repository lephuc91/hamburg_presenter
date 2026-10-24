using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProResourceUpdateInfo : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProResourceUpdateType type;
	}

	internal static readonly ConcurrentDictionary<nint, ProResourceUpdateInfo> NativeToManagedMap = new ConcurrentDictionary<nint, ProResourceUpdateInfo>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProResourceUpdateType Type
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

	internal unsafe static ProResourceUpdateInfo __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProResourceUpdateInfo(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProResourceUpdateInfo __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProResourceUpdateInfo(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProResourceUpdateInfo(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProResourceUpdateInfo(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProResourceUpdateInfo()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProResourceUpdateInfo()
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
