using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProAudioInputStatus : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 1544)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal nint deviceID;

		[FieldOffset(256)]
		internal int channelCount;

		[FieldOffset(264)]
		internal unsafe fixed double rmsVolume[64];

		[FieldOffset(776)]
		internal unsafe fixed double peakVolume[64];

		[FieldOffset(1288)]
		internal unsafe fixed uint isClipped[64];
	}

	internal static readonly ConcurrentDictionary<nint, ProAudioInputStatus> NativeToManagedMap = new ConcurrentDictionary<nint, ProAudioInputStatus>();

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

	public unsafe double[] RmsVolume
	{
		get
		{
			double[] array = null;
			if (((__Internal*)__Instance)->rmsVolume != null)
			{
				array = new double[64];
				for (int i = 0; i < 64; i++)
				{
					array[i] = ((__Internal*)__Instance)->rmsVolume[i];
				}
			}
			return array;
		}
		set
		{
			if (value != null)
			{
				for (int i = 0; i < 64; i++)
				{
					((__Internal*)__Instance)->rmsVolume[i] = value[i];
				}
			}
		}
	}

	public unsafe double[] PeakVolume
	{
		get
		{
			double[] array = null;
			if (((__Internal*)__Instance)->peakVolume != null)
			{
				array = new double[64];
				for (int i = 0; i < 64; i++)
				{
					array[i] = ((__Internal*)__Instance)->peakVolume[i];
				}
			}
			return array;
		}
		set
		{
			if (value != null)
			{
				for (int i = 0; i < 64; i++)
				{
					((__Internal*)__Instance)->peakVolume[i] = value[i];
				}
			}
		}
	}

	public unsafe uint[] IsClipped
	{
		get
		{
			uint[] array = null;
			if (((__Internal*)__Instance)->isClipped != null)
			{
				array = new uint[64];
				for (int i = 0; i < 64; i++)
				{
					array[i] = ((__Internal*)__Instance)->isClipped[i];
				}
			}
			return array;
		}
		set
		{
			if (value != null)
			{
				for (int i = 0; i < 64; i++)
				{
					((__Internal*)__Instance)->isClipped[i] = value[i];
				}
			}
		}
	}

	internal unsafe static ProAudioInputStatus __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProAudioInputStatus(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProAudioInputStatus __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProAudioInputStatus(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProAudioInputStatus(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProAudioInputStatus(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProAudioInputStatus()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProAudioInputStatus()
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
