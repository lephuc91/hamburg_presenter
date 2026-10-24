using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProVideoInputDevice : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 28588)]
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
		internal uint isActive;

		[FieldOffset(11796)]
		internal uint hasSignal;

		[FieldOffset(11800)]
		internal uint supportsAutoModeSelection;

		[FieldOffset(11804)]
		internal uint supportsAlphaKey;

		[FieldOffset(11808)]
		internal uint supportsAudio;

		[FieldOffset(11812)]
		internal int audioChannelCount;

		[FieldOffset(11816)]
		internal int audioFormatCount;

		[FieldOffset(11820)]
		internal nint audioFormats;

		[FieldOffset(12204)]
		internal nint audioChannels;
	}

	internal static readonly ConcurrentDictionary<nint, ProVideoInputDevice> NativeToManagedMap = new ConcurrentDictionary<nint, ProVideoInputDevice>();

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

	public unsafe bool IsActive
	{
		get
		{
			return ((__Internal*)__Instance)->isActive != 0;
		}
		set
		{
			((__Internal*)__Instance)->isActive = (value ? 1u : 0u);
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

	public unsafe bool SupportsAutoModeSelection
	{
		get
		{
			return ((__Internal*)__Instance)->supportsAutoModeSelection != 0;
		}
		set
		{
			((__Internal*)__Instance)->supportsAutoModeSelection = (value ? 1u : 0u);
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

	public unsafe bool SupportsAudio
	{
		get
		{
			return ((__Internal*)__Instance)->supportsAudio != 0;
		}
		set
		{
			((__Internal*)__Instance)->supportsAudio = (value ? 1u : 0u);
		}
	}

	public unsafe int AudioChannelCount
	{
		get
		{
			return ((__Internal*)__Instance)->audioChannelCount;
		}
		set
		{
			((__Internal*)__Instance)->audioChannelCount = value;
		}
	}

	public unsafe int AudioFormatCount
	{
		get
		{
			return ((__Internal*)__Instance)->audioFormatCount;
		}
		set
		{
			((__Internal*)__Instance)->audioFormatCount = value;
		}
	}

	public unsafe IReadOnlyList<ProAudioFormat> AudioFormats => new NativeFixedArray<ProAudioFormat, ProAudioFormat.__Internal>(ProAudioFormat.__CreateInstance, new IntPtr(&((__Internal*)__Instance)->audioFormats), 32);

	public unsafe IReadOnlyList<ProAudioChannel> AudioChannels => new NativeFixedArray<ProAudioChannel, ProAudioChannel.__Internal>(ProAudioChannel.__CreateInstance, new IntPtr(&((__Internal*)__Instance)->audioChannels), 64);

	internal unsafe static ProVideoInputDevice __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProVideoInputDevice(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProVideoInputDevice __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProVideoInputDevice(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProVideoInputDevice(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProVideoInputDevice(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProVideoInputDevice()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProVideoInputDevice()
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
