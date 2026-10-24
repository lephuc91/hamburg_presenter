using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProAudioDevice : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 17296)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProDeviceType deviceType;

		[FieldOffset(4)]
		internal nint deviceID;

		[FieldOffset(260)]
		internal nint name;

		[FieldOffset(516)]
		internal ProAudioDeviceType audioDeviceType;

		[FieldOffset(520)]
		internal int channelCount;

		[FieldOffset(524)]
		internal int formatCount;

		[FieldOffset(528)]
		internal nint formats;

		[FieldOffset(912)]
		internal nint channels;
	}

	internal static readonly ConcurrentDictionary<nint, ProAudioDevice> NativeToManagedMap = new ConcurrentDictionary<nint, ProAudioDevice>();

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

	public unsafe ProAudioDeviceType AudioDeviceType
	{
		get
		{
			return ((__Internal*)__Instance)->audioDeviceType;
		}
		set
		{
			((__Internal*)__Instance)->audioDeviceType = value;
		}
	}

	public unsafe int ChannelCount
	{
		get
		{
			return ((__Internal*)__Instance)->channelCount;
		}
		set
		{
			((__Internal*)__Instance)->channelCount = value;
		}
	}

	public unsafe int FormatCount
	{
		get
		{
			return ((__Internal*)__Instance)->formatCount;
		}
		set
		{
			((__Internal*)__Instance)->formatCount = value;
		}
	}

	public unsafe IReadOnlyList<ProAudioFormat> Formats => new NativeFixedArray<ProAudioFormat, ProAudioFormat.__Internal>(ProAudioFormat.__CreateInstance, new IntPtr(&((__Internal*)__Instance)->formats), 32);

	public unsafe IReadOnlyList<ProAudioChannel> Channels => new NativeFixedArray<ProAudioChannel, ProAudioChannel.__Internal>(ProAudioChannel.__CreateInstance, new IntPtr(&((__Internal*)__Instance)->channels), 64);

	internal unsafe static ProAudioDevice __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProAudioDevice(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProAudioDevice __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProAudioDevice(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProAudioDevice(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProAudioDevice(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProAudioDevice()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProAudioDevice()
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
