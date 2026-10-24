using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProHTTPResponseData : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProHTTPResponseStatusCode status;

		[FieldOffset(4)]
		internal ProHTTPContentType contentType;

		[FieldOffset(8)]
		internal nint response;
	}

	internal static readonly ConcurrentDictionary<nint, ProHTTPResponseData> NativeToManagedMap = new ConcurrentDictionary<nint, ProHTTPResponseData>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProHTTPResponseStatusCode Status
	{
		get
		{
			return ((__Internal*)__Instance)->status;
		}
		set
		{
			((__Internal*)__Instance)->status = value;
		}
	}

	public unsafe ProHTTPContentType ContentType
	{
		get
		{
			return ((__Internal*)__Instance)->contentType;
		}
		set
		{
			((__Internal*)__Instance)->contentType = value;
		}
	}

	public unsafe sbyte* Response
	{
		get
		{
			return (sbyte*)((__Internal*)__Instance)->response;
		}
		set
		{
			((__Internal*)__Instance)->response = (nint)value;
		}
	}

	internal unsafe static ProHTTPResponseData __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProHTTPResponseData(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProHTTPResponseData __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProHTTPResponseData(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProHTTPResponseData(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProHTTPResponseData(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProHTTPResponseData()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProHTTPResponseData()
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
