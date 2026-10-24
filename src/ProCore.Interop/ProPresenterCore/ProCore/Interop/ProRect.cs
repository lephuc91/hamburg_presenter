using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProRect : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProPoint.__Internal origin;

		[FieldOffset(8)]
		internal ProSize.__Internal size;
	}

	internal static readonly ConcurrentDictionary<nint, ProRect> NativeToManagedMap = new ConcurrentDictionary<nint, ProRect>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProPoint Origin
	{
		get
		{
			return ProPoint.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->origin));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->origin = *(ProPoint.__Internal*)value.__Instance;
		}
	}

	public unsafe ProSize Size
	{
		get
		{
			return ProSize.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->size));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->size = *(ProSize.__Internal*)value.__Instance;
		}
	}

	internal unsafe static ProRect __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProRect(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProRect __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProRect(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProRect(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProRect(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProRect()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProRect()
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
