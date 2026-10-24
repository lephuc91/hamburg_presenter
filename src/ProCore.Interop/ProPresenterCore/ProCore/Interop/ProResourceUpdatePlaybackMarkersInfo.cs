using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProResourceUpdatePlaybackMarkersInfo : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProResourceUpdateType type;

		[FieldOffset(4)]
		internal uint updateSuccess;
	}

	internal static readonly ConcurrentDictionary<nint, ProResourceUpdatePlaybackMarkersInfo> NativeToManagedMap = new ConcurrentDictionary<nint, ProResourceUpdatePlaybackMarkersInfo>();

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

	public unsafe bool UpdateSuccess
	{
		get
		{
			return ((__Internal*)__Instance)->updateSuccess != 0;
		}
		set
		{
			((__Internal*)__Instance)->updateSuccess = (value ? 1u : 0u);
		}
	}

	internal unsafe static ProResourceUpdatePlaybackMarkersInfo __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProResourceUpdatePlaybackMarkersInfo(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProResourceUpdatePlaybackMarkersInfo __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProResourceUpdatePlaybackMarkersInfo(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProResourceUpdatePlaybackMarkersInfo(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProResourceUpdatePlaybackMarkersInfo(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProResourceUpdatePlaybackMarkersInfo()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProResourceUpdatePlaybackMarkersInfo()
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
