using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProResourceAddress : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 88)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProUUID.__Internal resource;

		[FieldOffset(16)]
		internal ProResourceType type;

		[FieldOffset(20)]
		internal ProLayerIndex layer;

		[FieldOffset(24)]
		internal ProUUID.__Internal slot;

		[FieldOffset(40)]
		internal ProTriggerAddress.__Internal trigger;
	}

	internal static readonly ConcurrentDictionary<nint, ProResourceAddress> NativeToManagedMap = new ConcurrentDictionary<nint, ProResourceAddress>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProUUID Resource
	{
		get
		{
			return ProUUID.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->resource));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->resource = *(ProUUID.__Internal*)value.__Instance;
		}
	}

	public unsafe ProResourceType Type
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

	public unsafe ProLayerIndex Layer
	{
		get
		{
			return ((__Internal*)__Instance)->layer;
		}
		set
		{
			((__Internal*)__Instance)->layer = value;
		}
	}

	public unsafe ProUUID Slot
	{
		get
		{
			return ProUUID.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->slot));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->slot = *(ProUUID.__Internal*)value.__Instance;
		}
	}

	public unsafe ProTriggerAddress Trigger
	{
		get
		{
			return ProTriggerAddress.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->trigger));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->trigger = *(ProTriggerAddress.__Internal*)value.__Instance;
		}
	}

	internal unsafe static ProResourceAddress __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProResourceAddress(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProResourceAddress __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProResourceAddress(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProResourceAddress(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProResourceAddress(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProResourceAddress()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProResourceAddress()
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
