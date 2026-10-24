using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProStopMonitoringTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(8)]
		internal nint slideID;

		[FieldOffset(16)]
		internal nint elementID;

		[FieldOffset(24)]
		internal ulong handle;
	}

	internal static readonly ConcurrentDictionary<nint, ProStopMonitoringTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProStopMonitoringTransfer>();

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

	public unsafe ProUUID SlideID
	{
		get
		{
			if (((__Internal*)__Instance)->slideID == IntPtr.Zero)
			{
				return null;
			}
			if (ProUUID.NativeToManagedMap.ContainsKey(((__Internal*)__Instance)->slideID))
			{
				return ProUUID.NativeToManagedMap[((__Internal*)__Instance)->slideID];
			}
			return ProUUID.__CreateInstance(((__Internal*)__Instance)->slideID);
		}
	}

	public unsafe ProUUID ElementID
	{
		get
		{
			if (((__Internal*)__Instance)->elementID == IntPtr.Zero)
			{
				return null;
			}
			if (ProUUID.NativeToManagedMap.ContainsKey(((__Internal*)__Instance)->elementID))
			{
				return ProUUID.NativeToManagedMap[((__Internal*)__Instance)->elementID];
			}
			return ProUUID.__CreateInstance(((__Internal*)__Instance)->elementID);
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

	internal unsafe static ProStopMonitoringTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProStopMonitoringTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProStopMonitoringTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProStopMonitoringTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProStopMonitoringTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProStopMonitoringTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProStopMonitoringTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProStopMonitoringTransfer()
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
