using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProDataOut : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal nint data;

		[FieldOffset(8)]
		internal int dataSize;
	}

	internal static readonly ConcurrentDictionary<nint, ProDataOut> NativeToManagedMap = new ConcurrentDictionary<nint, ProDataOut>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe nint Data
	{
		get
		{
			return ((__Internal*)__Instance)->data;
		}
		set
		{
			((__Internal*)__Instance)->data = value;
		}
	}

	public unsafe int DataSize
	{
		get
		{
			return ((__Internal*)__Instance)->dataSize;
		}
		set
		{
			((__Internal*)__Instance)->dataSize = value;
		}
	}

	internal unsafe static ProDataOut __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProDataOut(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProDataOut __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProDataOut(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProDataOut(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProDataOut(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProDataOut()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProDataOut()
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
