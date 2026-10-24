using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class TimedPlaybackStatus : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal double time;

		[FieldOffset(8)]
		internal TimedPlaybackState state;

		[FieldOffset(16)]
		internal double framerate;
	}

	internal static readonly ConcurrentDictionary<nint, TimedPlaybackStatus> NativeToManagedMap = new ConcurrentDictionary<nint, TimedPlaybackStatus>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe double Time
	{
		get
		{
			return ((__Internal*)__Instance)->time;
		}
		set
		{
			((__Internal*)__Instance)->time = value;
		}
	}

	public unsafe TimedPlaybackState State
	{
		get
		{
			return ((__Internal*)__Instance)->state;
		}
		set
		{
			((__Internal*)__Instance)->state = value;
		}
	}

	public unsafe double Framerate
	{
		get
		{
			return ((__Internal*)__Instance)->framerate;
		}
		set
		{
			((__Internal*)__Instance)->framerate = value;
		}
	}

	internal unsafe static TimedPlaybackStatus __CreateInstance(nint native, bool skipVTables = false)
	{
		return new TimedPlaybackStatus(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static TimedPlaybackStatus __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new TimedPlaybackStatus(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe TimedPlaybackStatus(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe TimedPlaybackStatus(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe TimedPlaybackStatus()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~TimedPlaybackStatus()
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
