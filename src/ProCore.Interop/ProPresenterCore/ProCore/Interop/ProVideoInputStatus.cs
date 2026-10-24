using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProVideoInputStatus : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 524)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal nint deviceID;

		[FieldOffset(256)]
		internal uint hasSignal;

		[FieldOffset(260)]
		internal int currentMode;

		[FieldOffset(264)]
		internal nint modeDescription;

		[FieldOffset(520)]
		internal ProMediaColorFormat colorFormat;
	}

	internal static readonly ConcurrentDictionary<nint, ProVideoInputStatus> NativeToManagedMap = new ConcurrentDictionary<nint, ProVideoInputStatus>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

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

	public unsafe bool HasSignal
	{
		get
		{
			return ((__Internal*)__Instance)->hasSignal != 0;
		}
		set
		{
			((__Internal*)__Instance)->hasSignal = (value ? 1u : 0u);
		}
	}

	public unsafe int CurrentMode
	{
		get
		{
			return ((__Internal*)__Instance)->currentMode;
		}
		set
		{
			((__Internal*)__Instance)->currentMode = value;
		}
	}

	public unsafe string ModeDescription
	{
		get
		{
			sbyte* ptr;
			for (ptr = (sbyte*)new IntPtr(&((__Internal*)__Instance)->modeDescription); *ptr != 0; ptr++)
			{
			}
			return new string((sbyte*)new IntPtr(&((__Internal*)__Instance)->modeDescription), 0, (int)(ptr - (sbyte*)new IntPtr(&((__Internal*)__Instance)->modeDescription)), Encoding.UTF8);
		}
		set
		{
			fixed (char* chars = value)
			{
				Encoding.UTF8.GetBytes(chars, value.Length, (byte*)((__Internal*)__Instance)->modeDescription, 255);
				*(sbyte*)(((__Internal*)__Instance)->modeDescription + Math.Min(value.Length, 255)) = 0;
			}
		}
	}

	public unsafe ProMediaColorFormat ColorFormat
	{
		get
		{
			return ((__Internal*)__Instance)->colorFormat;
		}
		set
		{
			((__Internal*)__Instance)->colorFormat = value;
		}
	}

	internal unsafe static ProVideoInputStatus __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProVideoInputStatus(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProVideoInputStatus __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProVideoInputStatus(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProVideoInputStatus(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProVideoInputStatus(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProVideoInputStatus()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProVideoInputStatus()
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
