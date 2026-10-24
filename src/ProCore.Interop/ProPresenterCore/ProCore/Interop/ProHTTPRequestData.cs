using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProHTTPRequestData : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProHTTPRequestMethod method;

		[FieldOffset(8)]
		internal nint url;

		[FieldOffset(16)]
		internal nint body;
	}

	internal static readonly ConcurrentDictionary<nint, ProHTTPRequestData> NativeToManagedMap = new ConcurrentDictionary<nint, ProHTTPRequestData>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProHTTPRequestMethod Method
	{
		get
		{
			return ((__Internal*)__Instance)->method;
		}
		set
		{
			((__Internal*)__Instance)->method = value;
		}
	}

	public unsafe string Url
	{
		get
		{
			if (((__Internal*)__Instance)->url == IntPtr.Zero)
			{
				return null;
			}
			byte* url = (byte*)((__Internal*)__Instance)->url;
			int num = 0;
			while (*(url++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->url, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->url = new IntPtr(bytes);
			}
		}
	}

	public unsafe string Body
	{
		get
		{
			if (((__Internal*)__Instance)->body == IntPtr.Zero)
			{
				return null;
			}
			byte* body = (byte*)((__Internal*)__Instance)->body;
			int num = 0;
			while (*(body++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->body, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->body = new IntPtr(bytes);
			}
		}
	}

	internal unsafe static ProHTTPRequestData __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProHTTPRequestData(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProHTTPRequestData __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProHTTPRequestData(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProHTTPRequestData(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProHTTPRequestData(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProHTTPRequestData()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProHTTPRequestData()
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
