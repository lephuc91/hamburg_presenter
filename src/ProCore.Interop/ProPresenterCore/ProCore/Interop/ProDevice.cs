using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProDevice : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 516)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProDeviceType deviceType;

		[FieldOffset(4)]
		internal nint deviceID;

		[FieldOffset(260)]
		internal nint name;
	}

	internal static readonly ConcurrentDictionary<nint, ProDevice> NativeToManagedMap = new ConcurrentDictionary<nint, ProDevice>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProDeviceType DeviceType
	{
		get
		{
			return ((__Internal*)__Instance)->deviceType;
		}
		set
		{
			((__Internal*)__Instance)->deviceType = value;
		}
	}

	public unsafe string DeviceID
	{
		get
		{
			sbyte* ptr;
			for (ptr = (sbyte*)new IntPtr(&((__Internal*)__Instance)->deviceID); *ptr != 0; ptr++)
			{
			}
			return new string((sbyte*)new IntPtr(&((__Internal*)__Instance)->deviceID), 0, (int)(ptr - (sbyte*)new IntPtr(&((__Internal*)__Instance)->deviceID)), Encoding.UTF8);
		}
		set
		{
			fixed (char* chars = value)
			{
				Encoding.UTF8.GetBytes(chars, value.Length, (byte*)((__Internal*)__Instance)->deviceID, 255);
				*(sbyte*)(((__Internal*)__Instance)->deviceID + Math.Min(value.Length, 255)) = 0;
			}
		}
	}

	public unsafe string Name
	{
		get
		{
			sbyte* ptr;
			for (ptr = (sbyte*)new IntPtr(&((__Internal*)__Instance)->name); *ptr != 0; ptr++)
			{
			}
			return new string((sbyte*)new IntPtr(&((__Internal*)__Instance)->name), 0, (int)(ptr - (sbyte*)new IntPtr(&((__Internal*)__Instance)->name)), Encoding.UTF8);
		}
		set
		{
			fixed (char* chars = value)
			{
				Encoding.UTF8.GetBytes(chars, value.Length, (byte*)((__Internal*)__Instance)->name, 255);
				*(sbyte*)(((__Internal*)__Instance)->name + Math.Min(value.Length, 255)) = 0;
			}
		}
	}

	internal unsafe static ProDevice __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProDevice(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProDevice __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProDevice(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProDevice(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProDevice(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProDevice()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProDevice()
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
