using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProAutoAdvanceUpdateInfo : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProResourceUpdateType type;

		[FieldOffset(4)]
		internal uint willAutoAdvance;

		[FieldOffset(8)]
		internal float progress;

		[FieldOffset(12)]
		internal float timeRemaining;
	}

	internal static readonly ConcurrentDictionary<nint, ProAutoAdvanceUpdateInfo> NativeToManagedMap = new ConcurrentDictionary<nint, ProAutoAdvanceUpdateInfo>();

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

	public unsafe bool WillAutoAdvance
	{
		get
		{
			return ((__Internal*)__Instance)->willAutoAdvance != 0;
		}
		set
		{
			((__Internal*)__Instance)->willAutoAdvance = (value ? 1u : 0u);
		}
	}

	public unsafe float Progress
	{
		get
		{
			return ((__Internal*)__Instance)->progress;
		}
		set
		{
			((__Internal*)__Instance)->progress = value;
		}
	}

	public unsafe float TimeRemaining
	{
		get
		{
			return ((__Internal*)__Instance)->timeRemaining;
		}
		set
		{
			((__Internal*)__Instance)->timeRemaining = value;
		}
	}

	internal unsafe static ProAutoAdvanceUpdateInfo __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProAutoAdvanceUpdateInfo(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProAutoAdvanceUpdateInfo __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProAutoAdvanceUpdateInfo(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProAutoAdvanceUpdateInfo(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProAutoAdvanceUpdateInfo(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProAutoAdvanceUpdateInfo()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProAutoAdvanceUpdateInfo()
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
