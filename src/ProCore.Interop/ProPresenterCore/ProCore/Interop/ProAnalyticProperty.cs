using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProAnalyticProperty : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal nint key;

		[FieldOffset(8)]
		internal nint value;
	}

	internal static readonly ConcurrentDictionary<nint, ProAnalyticProperty> NativeToManagedMap = new ConcurrentDictionary<nint, ProAnalyticProperty>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe string Key
	{
		get
		{
			if (((__Internal*)__Instance)->key == IntPtr.Zero)
			{
				return null;
			}
			byte* key = (byte*)((__Internal*)__Instance)->key;
			int num = 0;
			while (*(key++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->key, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->key = new IntPtr(bytes);
			}
		}
	}

	public unsafe string Value
	{
		get
		{
			if (((__Internal*)__Instance)->value == IntPtr.Zero)
			{
				return null;
			}
			byte* value = (byte*)((__Internal*)__Instance)->value;
			int num = 0;
			while (*(value++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->value, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->value = new IntPtr(bytes);
			}
		}
	}

	internal unsafe static ProAnalyticProperty __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProAnalyticProperty(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProAnalyticProperty __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProAnalyticProperty(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProAnalyticProperty(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProAnalyticProperty(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProAnalyticProperty()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProAnalyticProperty()
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
