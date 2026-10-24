using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProScreenCaptureStatus : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 104)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProUUID.__Internal streamID;

		[FieldOffset(16)]
		internal ProScreenCaptureState state;

		[FieldOffset(20)]
		internal ProScreenCaptureStreamStatus streamStatus;

		[FieldOffset(24)]
		internal ProScreenCaptureDiskStatus diskStatus;

		[FieldOffset(32)]
		internal nint fileName;

		[FieldOffset(40)]
		internal double currentRecordTime;

		[FieldOffset(48)]
		internal int droppedFrames;

		[FieldOffset(56)]
		internal double percentDroppedFrames;

		[FieldOffset(64)]
		internal double bitRate;

		[FieldOffset(72)]
		internal ulong freeBytesOnDisk;

		[FieldOffset(80)]
		internal ulong totalBytesOnDisk;

		[FieldOffset(88)]
		internal ProUUID.__Internal presetID;
	}

	internal static readonly ConcurrentDictionary<nint, ProScreenCaptureStatus> NativeToManagedMap = new ConcurrentDictionary<nint, ProScreenCaptureStatus>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProUUID StreamID
	{
		get
		{
			return ProUUID.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->streamID));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->streamID = *(ProUUID.__Internal*)value.__Instance;
		}
	}

	public unsafe ProScreenCaptureState State
	{
		get
		{
			return ((__Internal*)__Instance)->state;
		}
		set
		{
			((__Internal*)__Instance)->state = value;
		}
	}

	public unsafe ProScreenCaptureStreamStatus StreamStatus
	{
		get
		{
			return ((__Internal*)__Instance)->streamStatus;
		}
		set
		{
			((__Internal*)__Instance)->streamStatus = value;
		}
	}

	public unsafe ProScreenCaptureDiskStatus DiskStatus
	{
		get
		{
			return ((__Internal*)__Instance)->diskStatus;
		}
		set
		{
			((__Internal*)__Instance)->diskStatus = value;
		}
	}

	public unsafe string FileName
	{
		get
		{
			if (((__Internal*)__Instance)->fileName == IntPtr.Zero)
			{
				return null;
			}
			byte* fileName = (byte*)((__Internal*)__Instance)->fileName;
			int num = 0;
			while (*(fileName++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->fileName, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->fileName = new IntPtr(bytes);
			}
		}
	}

	public unsafe double CurrentRecordTime
	{
		get
		{
			return ((__Internal*)__Instance)->currentRecordTime;
		}
		set
		{
			((__Internal*)__Instance)->currentRecordTime = value;
		}
	}

	public unsafe int DroppedFrames
	{
		get
		{
			return ((__Internal*)__Instance)->droppedFrames;
		}
		set
		{
			((__Internal*)__Instance)->droppedFrames = value;
		}
	}

	public unsafe double PercentDroppedFrames
	{
		get
		{
			return ((__Internal*)__Instance)->percentDroppedFrames;
		}
		set
		{
			((__Internal*)__Instance)->percentDroppedFrames = value;
		}
	}

	public unsafe double BitRate
	{
		get
		{
			return ((__Internal*)__Instance)->bitRate;
		}
		set
		{
			((__Internal*)__Instance)->bitRate = value;
		}
	}

	public unsafe ulong FreeBytesOnDisk
	{
		get
		{
			return ((__Internal*)__Instance)->freeBytesOnDisk;
		}
		set
		{
			((__Internal*)__Instance)->freeBytesOnDisk = value;
		}
	}

	public unsafe ulong TotalBytesOnDisk
	{
		get
		{
			return ((__Internal*)__Instance)->totalBytesOnDisk;
		}
		set
		{
			((__Internal*)__Instance)->totalBytesOnDisk = value;
		}
	}

	public unsafe ProUUID PresetID
	{
		get
		{
			return ProUUID.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->presetID));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->presetID = *(ProUUID.__Internal*)value.__Instance;
		}
	}

	internal unsafe static ProScreenCaptureStatus __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProScreenCaptureStatus(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProScreenCaptureStatus __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProScreenCaptureStatus(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProScreenCaptureStatus(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProScreenCaptureStatus(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProScreenCaptureStatus()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProScreenCaptureStatus()
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
