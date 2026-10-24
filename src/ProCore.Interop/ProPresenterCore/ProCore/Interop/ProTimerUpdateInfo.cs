using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProTimerUpdateInfo : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProResourceUpdateType type;

		[FieldOffset(8)]
		internal nint updatingTrigger;
	}

	internal static readonly ConcurrentDictionary<nint, ProTimerUpdateInfo> NativeToManagedMap = new ConcurrentDictionary<nint, ProTimerUpdateInfo>();

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

	public unsafe ProTriggerAddress UpdatingTrigger
	{
		get
		{
			if (((__Internal*)__Instance)->updatingTrigger == IntPtr.Zero)
			{
				return null;
			}
			if (ProTriggerAddress.NativeToManagedMap.ContainsKey(((__Internal*)__Instance)->updatingTrigger))
			{
				return ProTriggerAddress.NativeToManagedMap[((__Internal*)__Instance)->updatingTrigger];
			}
			return ProTriggerAddress.__CreateInstance(((__Internal*)__Instance)->updatingTrigger);
		}
	}

	internal unsafe static ProTimerUpdateInfo __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProTimerUpdateInfo(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProTimerUpdateInfo __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProTimerUpdateInfo(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProTimerUpdateInfo(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProTimerUpdateInfo(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProTimerUpdateInfo()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProTimerUpdateInfo()
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
