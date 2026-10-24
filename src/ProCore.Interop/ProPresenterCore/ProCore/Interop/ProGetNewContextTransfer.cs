using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProGetNewContextTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(8)]
		internal ulong triggerHandle;

		[FieldOffset(16)]
		internal double activateTime;

		[FieldOffset(24)]
		internal uint actionSize;

		[FieldOffset(32)]
		internal nint action;

		[FieldOffset(40)]
		internal nint clientContext;

		[FieldOffset(48)]
		internal uint triggerSourceSize;

		[FieldOffset(56)]
		internal nint triggerSourceData;
	}

	internal static readonly ConcurrentDictionary<nint, ProGetNewContextTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProGetNewContextTransfer>();

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

	public unsafe ulong TriggerHandle
	{
		get
		{
			return ((__Internal*)__Instance)->triggerHandle;
		}
		set
		{
			((__Internal*)__Instance)->triggerHandle = value;
		}
	}

	public unsafe double ActivateTime
	{
		get
		{
			return ((__Internal*)__Instance)->activateTime;
		}
		set
		{
			((__Internal*)__Instance)->activateTime = value;
		}
	}

	public unsafe uint ActionSize
	{
		get
		{
			return ((__Internal*)__Instance)->actionSize;
		}
		set
		{
			((__Internal*)__Instance)->actionSize = value;
		}
	}

	public unsafe nint Action
	{
		get
		{
			return ((__Internal*)__Instance)->action;
		}
		set
		{
			((__Internal*)__Instance)->action = value;
		}
	}

	public unsafe nint ClientContext
	{
		get
		{
			return ((__Internal*)__Instance)->clientContext;
		}
		set
		{
			((__Internal*)__Instance)->clientContext = value;
		}
	}

	public unsafe uint TriggerSourceSize
	{
		get
		{
			return ((__Internal*)__Instance)->triggerSourceSize;
		}
		set
		{
			((__Internal*)__Instance)->triggerSourceSize = value;
		}
	}

	public unsafe nint TriggerSourceData
	{
		get
		{
			return ((__Internal*)__Instance)->triggerSourceData;
		}
		set
		{
			((__Internal*)__Instance)->triggerSourceData = value;
		}
	}

	internal unsafe static ProGetNewContextTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProGetNewContextTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProGetNewContextTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProGetNewContextTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProGetNewContextTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProGetNewContextTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProGetNewContextTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProGetNewContextTransfer()
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
