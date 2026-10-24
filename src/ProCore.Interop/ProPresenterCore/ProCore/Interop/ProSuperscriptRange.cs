using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProSuperscriptRange : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal uint startIndex;

		[FieldOffset(4)]
		internal uint endIndex;
	}

	internal static readonly ConcurrentDictionary<nint, ProSuperscriptRange> NativeToManagedMap = new ConcurrentDictionary<nint, ProSuperscriptRange>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe uint StartIndex
	{
		get
		{
			return ((__Internal*)__Instance)->startIndex;
		}
		set
		{
			((__Internal*)__Instance)->startIndex = value;
		}
	}

	public unsafe uint EndIndex
	{
		get
		{
			return ((__Internal*)__Instance)->endIndex;
		}
		set
		{
			((__Internal*)__Instance)->endIndex = value;
		}
	}

	internal unsafe static ProSuperscriptRange __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProSuperscriptRange(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProSuperscriptRange __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProSuperscriptRange(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProSuperscriptRange(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProSuperscriptRange(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProSuperscriptRange()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProSuperscriptRange()
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
