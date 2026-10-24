using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProNetworkMessageField : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProUUID.__Internal id;

		[FieldOffset(16)]
		internal nint value;
	}

	internal static readonly ConcurrentDictionary<nint, ProNetworkMessageField> NativeToManagedMap = new ConcurrentDictionary<nint, ProNetworkMessageField>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProUUID Id
	{
		get
		{
			return ProUUID.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->id));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->id = *(ProUUID.__Internal*)value.__Instance;
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

	internal unsafe static ProNetworkMessageField __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProNetworkMessageField(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProNetworkMessageField __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProNetworkMessageField(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProNetworkMessageField(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProNetworkMessageField(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProNetworkMessageField()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProNetworkMessageField()
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
