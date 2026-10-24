using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProRequestCueData : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal nint cueBuffer;

		[FieldOffset(8)]
		internal int cueSize;
	}

	internal static readonly ConcurrentDictionary<nint, ProRequestCueData> NativeToManagedMap = new ConcurrentDictionary<nint, ProRequestCueData>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe nint CueBuffer
	{
		get
		{
			return ((__Internal*)__Instance)->cueBuffer;
		}
		set
		{
			((__Internal*)__Instance)->cueBuffer = value;
		}
	}

	public unsafe int CueSize
	{
		get
		{
			return ((__Internal*)__Instance)->cueSize;
		}
		set
		{
			((__Internal*)__Instance)->cueSize = value;
		}
	}

	internal unsafe static ProRequestCueData __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProRequestCueData(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProRequestCueData __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProRequestCueData(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProRequestCueData(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProRequestCueData(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProRequestCueData()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProRequestCueData()
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
