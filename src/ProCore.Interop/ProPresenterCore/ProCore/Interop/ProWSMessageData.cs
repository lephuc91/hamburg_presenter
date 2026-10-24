using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProWSMessageData : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal nint buffer;

		[FieldOffset(8)]
		internal ulong length;

		[FieldOffset(16)]
		internal ProWSDataType dataType;
	}

	internal static readonly ConcurrentDictionary<nint, ProWSMessageData> NativeToManagedMap = new ConcurrentDictionary<nint, ProWSMessageData>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe nint Buffer
	{
		get
		{
			return ((__Internal*)__Instance)->buffer;
		}
		set
		{
			((__Internal*)__Instance)->buffer = value;
		}
	}

	public unsafe ulong Length
	{
		get
		{
			return ((__Internal*)__Instance)->length;
		}
		set
		{
			((__Internal*)__Instance)->length = value;
		}
	}

	public unsafe ProWSDataType DataType
	{
		get
		{
			return ((__Internal*)__Instance)->dataType;
		}
		set
		{
			((__Internal*)__Instance)->dataType = value;
		}
	}

	internal unsafe static ProWSMessageData __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProWSMessageData(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProWSMessageData __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProWSMessageData(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProWSMessageData(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProWSMessageData(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProWSMessageData()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProWSMessageData()
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
