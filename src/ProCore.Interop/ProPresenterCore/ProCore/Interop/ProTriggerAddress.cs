using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProTriggerAddress : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProUUID.__Internal cue;

		[FieldOffset(16)]
		internal ProUUID.__Internal action;

		[FieldOffset(32)]
		internal nint clientData;

		[FieldOffset(40)]
		internal ulong handle;
	}

	internal static readonly ConcurrentDictionary<nint, ProTriggerAddress> NativeToManagedMap = new ConcurrentDictionary<nint, ProTriggerAddress>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProUUID Cue
	{
		get
		{
			return ProUUID.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->cue));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->cue = *(ProUUID.__Internal*)value.__Instance;
		}
	}

	public unsafe ProUUID Action
	{
		get
		{
			return ProUUID.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->action));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->action = *(ProUUID.__Internal*)value.__Instance;
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

	public unsafe ulong Handle
	{
		get
		{
			return ((__Internal*)__Instance)->handle;
		}
		set
		{
			((__Internal*)__Instance)->handle = value;
		}
	}

	internal unsafe static ProTriggerAddress __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProTriggerAddress(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProTriggerAddress __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProTriggerAddress(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProTriggerAddress(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProTriggerAddress(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProTriggerAddress()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProTriggerAddress()
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
