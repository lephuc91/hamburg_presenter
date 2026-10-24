using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProSlideBuildIndexUpdateInfo : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProResourceUpdateType type;

		[FieldOffset(4)]
		internal int buildIndex;
	}

	internal static readonly ConcurrentDictionary<nint, ProSlideBuildIndexUpdateInfo> NativeToManagedMap = new ConcurrentDictionary<nint, ProSlideBuildIndexUpdateInfo>();

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

	public unsafe int BuildIndex
	{
		get
		{
			return ((__Internal*)__Instance)->buildIndex;
		}
		set
		{
			((__Internal*)__Instance)->buildIndex = value;
		}
	}

	internal unsafe static ProSlideBuildIndexUpdateInfo __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProSlideBuildIndexUpdateInfo(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProSlideBuildIndexUpdateInfo __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProSlideBuildIndexUpdateInfo(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProSlideBuildIndexUpdateInfo(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProSlideBuildIndexUpdateInfo(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProSlideBuildIndexUpdateInfo()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProSlideBuildIndexUpdateInfo()
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
