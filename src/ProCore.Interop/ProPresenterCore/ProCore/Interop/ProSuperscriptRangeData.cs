using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProSuperscriptRangeData : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 36)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal uint rangeCount;

		[FieldOffset(4)]
		internal nint ranges;
	}

	internal static readonly ConcurrentDictionary<nint, ProSuperscriptRangeData> NativeToManagedMap = new ConcurrentDictionary<nint, ProSuperscriptRangeData>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe uint RangeCount
	{
		get
		{
			return ((__Internal*)__Instance)->rangeCount;
		}
		set
		{
			((__Internal*)__Instance)->rangeCount = value;
		}
	}

	public unsafe IReadOnlyList<ProSuperscriptRange> Ranges => new NativeFixedArray<ProSuperscriptRange, ProSuperscriptRange.__Internal>(ProSuperscriptRange.__CreateInstance, new IntPtr(&((__Internal*)__Instance)->ranges), 4);

	internal unsafe static ProSuperscriptRangeData __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProSuperscriptRangeData(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProSuperscriptRangeData __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProSuperscriptRangeData(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProSuperscriptRangeData(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProSuperscriptRangeData(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProSuperscriptRangeData()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProSuperscriptRangeData()
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
