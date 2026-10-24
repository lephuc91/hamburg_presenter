using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProVideoOutputDevice : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 11836)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProDeviceType deviceType;

		[FieldOffset(4)]
		internal nint deviceID;

		[FieldOffset(260)]
		internal nint name;

		[FieldOffset(516)]
		internal ProVideoDeviceType videoDeviceType;

		[FieldOffset(520)]
		internal int modeCount;

		[FieldOffset(524)]
		internal int currentMode;

		[FieldOffset(528)]
		internal nint deviceName;

		[FieldOffset(784)]
		internal nint vendorID;

		[FieldOffset(1040)]
		internal nint modelName;

		[FieldOffset(1296)]
		internal nint serialNumber;

		[FieldOffset(1552)]
		internal nint modes;

		[FieldOffset(11792)]
		internal uint isPrimaryMonitor;

		[FieldOffset(11796)]
		internal ProRect.__Internal systemFrame;

		[FieldOffset(11812)]
		internal uint systemID;

		[FieldOffset(11816)]
		internal uint supportsAlphaKey;

		[FieldOffset(11820)]
		internal uint supportsAlphaKeyBlending;

		[FieldOffset(11824)]
		internal uint supportsInternalAlphaKey;

		[FieldOffset(11828)]
		internal uint supportsExternalAlphaKey;

		[FieldOffset(11832)]
		internal uint supportsHdrOutput;
	}

	internal static readonly ConcurrentDictionary<nint, ProVideoOutputDevice> NativeToManagedMap = new ConcurrentDictionary<nint, ProVideoOutputDevice>();

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

	public unsafe ProVideoDeviceType VideoDeviceType
	{
		get
		{
			return ((__Internal*)__Instance)->videoDeviceType;
		}
		set
		{
			((__Internal*)__Instance)->videoDeviceType = value;
		}
	}

	public unsafe int ModeCount
	{
		get
		{
			return ((__Internal*)__Instance)->modeCount;
		}
		set
		{
			((__Internal*)__Instance)->modeCount = value;
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

	public unsafe string DeviceName
	{
		get
		{
			sbyte* ptr;
			for (ptr = (sbyte*)new IntPtr(&((__Internal*)__Instance)->deviceName); *ptr != 0; ptr++)
			{
			}
			return new string((sbyte*)new IntPtr(&((__Internal*)__Instance)->deviceName), 0, (int)(ptr - (sbyte*)new IntPtr(&((__Internal*)__Instance)->deviceName)), Encoding.UTF8);
		}
		set
		{
			fixed (char* chars = value)
			{
				Encoding.UTF8.GetBytes(chars, value.Length, (byte*)((__Internal*)__Instance)->deviceName, 255);
				*(sbyte*)(((__Internal*)__Instance)->deviceName + Math.Min(value.Length, 255)) = 0;
			}
		}
	}

	public unsafe string VendorID
	{
		get
		{
			sbyte* ptr;
			for (ptr = (sbyte*)new IntPtr(&((__Internal*)__Instance)->vendorID); *ptr != 0; ptr++)
			{
			}
			return new string((sbyte*)new IntPtr(&((__Internal*)__Instance)->vendorID), 0, (int)(ptr - (sbyte*)new IntPtr(&((__Internal*)__Instance)->vendorID)), Encoding.UTF8);
		}
		set
		{
			fixed (char* chars = value)
			{
				Encoding.UTF8.GetBytes(chars, value.Length, (byte*)((__Internal*)__Instance)->vendorID, 255);
				*(sbyte*)(((__Internal*)__Instance)->vendorID + Math.Min(value.Length, 255)) = 0;
			}
		}
	}

	public unsafe string ModelName
	{
		get
		{
			sbyte* ptr;
			for (ptr = (sbyte*)new IntPtr(&((__Internal*)__Instance)->modelName); *ptr != 0; ptr++)
			{
			}
			return new string((sbyte*)new IntPtr(&((__Internal*)__Instance)->modelName), 0, (int)(ptr - (sbyte*)new IntPtr(&((__Internal*)__Instance)->modelName)), Encoding.UTF8);
		}
		set
		{
			fixed (char* chars = value)
			{
				Encoding.UTF8.GetBytes(chars, value.Length, (byte*)((__Internal*)__Instance)->modelName, 255);
				*(sbyte*)(((__Internal*)__Instance)->modelName + Math.Min(value.Length, 255)) = 0;
			}
		}
	}

	public unsafe string SerialNumber
	{
		get
		{
			sbyte* ptr;
			for (ptr = (sbyte*)new IntPtr(&((__Internal*)__Instance)->serialNumber); *ptr != 0; ptr++)
			{
			}
			return new string((sbyte*)new IntPtr(&((__Internal*)__Instance)->serialNumber), 0, (int)(ptr - (sbyte*)new IntPtr(&((__Internal*)__Instance)->serialNumber)), Encoding.UTF8);
		}
		set
		{
			fixed (char* chars = value)
			{
				Encoding.UTF8.GetBytes(chars, value.Length, (byte*)((__Internal*)__Instance)->serialNumber, 255);
				*(sbyte*)(((__Internal*)__Instance)->serialNumber + Math.Min(value.Length, 255)) = 0;
			}
		}
	}

	public unsafe IReadOnlyList<ProVideoMode> Modes => new NativeFixedArray<ProVideoMode, ProVideoMode.__Internal>(ProVideoMode.__CreateInstance, new IntPtr(&((__Internal*)__Instance)->modes), 128);

	public unsafe bool IsPrimaryMonitor
	{
		get
		{
			return ((__Internal*)__Instance)->isPrimaryMonitor != 0;
		}
		set
		{
			((__Internal*)__Instance)->isPrimaryMonitor = (value ? 1u : 0u);
		}
	}

	public unsafe ProRect SystemFrame
	{
		get
		{
			return ProRect.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->systemFrame));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->systemFrame = *(ProRect.__Internal*)value.__Instance;
		}
	}

	public unsafe uint SystemID
	{
		get
		{
			return ((__Internal*)__Instance)->systemID;
		}
		set
		{
			((__Internal*)__Instance)->systemID = value;
		}
	}

	public unsafe bool SupportsAlphaKey
	{
		get
		{
			return ((__Internal*)__Instance)->supportsAlphaKey != 0;
		}
		set
		{
			((__Internal*)__Instance)->supportsAlphaKey = (value ? 1u : 0u);
		}
	}

	public unsafe bool SupportsAlphaKeyBlending
	{
		get
		{
			return ((__Internal*)__Instance)->supportsAlphaKeyBlending != 0;
		}
		set
		{
			((__Internal*)__Instance)->supportsAlphaKeyBlending = (value ? 1u : 0u);
		}
	}

	public unsafe bool SupportsInternalAlphaKey
	{
		get
		{
			return ((__Internal*)__Instance)->supportsInternalAlphaKey != 0;
		}
		set
		{
			((__Internal*)__Instance)->supportsInternalAlphaKey = (value ? 1u : 0u);
		}
	}

	public unsafe bool SupportsExternalAlphaKey
	{
		get
		{
			return ((__Internal*)__Instance)->supportsExternalAlphaKey != 0;
		}
		set
		{
			((__Internal*)__Instance)->supportsExternalAlphaKey = (value ? 1u : 0u);
		}
	}

	public unsafe bool SupportsHdrOutput
	{
		get
		{
			return ((__Internal*)__Instance)->supportsHdrOutput != 0;
		}
		set
		{
			((__Internal*)__Instance)->supportsHdrOutput = (value ? 1u : 0u);
		}
	}

	internal unsafe static ProVideoOutputDevice __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProVideoOutputDevice(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProVideoOutputDevice __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProVideoOutputDevice(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProVideoOutputDevice(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProVideoOutputDevice(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProVideoOutputDevice()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProVideoOutputDevice()
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
