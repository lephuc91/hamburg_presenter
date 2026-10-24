using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProResiEncoderProfile : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal nint id;

		[FieldOffset(8)]
		internal nint format;

		[FieldOffset(16)]
		internal uint resolution;

		[FieldOffset(20)]
		internal float frameRate;

		[FieldOffset(24)]
		internal uint interlaced;

		[FieldOffset(28)]
		internal float videoBitRate;

		[FieldOffset(32)]
		internal uint videoBufSize;

		[FieldOffset(36)]
		internal uint videoMinRate;

		[FieldOffset(40)]
		internal uint videoMaxRate;

		[FieldOffset(44)]
		internal uint gop;

		[FieldOffset(48)]
		internal uint segmentSize;
	}

	internal static readonly ConcurrentDictionary<nint, ProResiEncoderProfile> NativeToManagedMap = new ConcurrentDictionary<nint, ProResiEncoderProfile>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe string Id
	{
		get
		{
			if (((__Internal*)__Instance)->id == IntPtr.Zero)
			{
				return null;
			}
			byte* id = (byte*)((__Internal*)__Instance)->id;
			int num = 0;
			while (*(id++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->id, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->id = new IntPtr(bytes);
			}
		}
	}

	public unsafe string Format
	{
		get
		{
			if (((__Internal*)__Instance)->format == IntPtr.Zero)
			{
				return null;
			}
			byte* format = (byte*)((__Internal*)__Instance)->format;
			int num = 0;
			while (*(format++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->format, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->format = new IntPtr(bytes);
			}
		}
	}

	public unsafe uint Resolution
	{
		get
		{
			return ((__Internal*)__Instance)->resolution;
		}
		set
		{
			((__Internal*)__Instance)->resolution = value;
		}
	}

	public unsafe float FrameRate
	{
		get
		{
			return ((__Internal*)__Instance)->frameRate;
		}
		set
		{
			((__Internal*)__Instance)->frameRate = value;
		}
	}

	public unsafe bool Interlaced
	{
		get
		{
			return ((__Internal*)__Instance)->interlaced != 0;
		}
		set
		{
			((__Internal*)__Instance)->interlaced = (value ? 1u : 0u);
		}
	}

	public unsafe float VideoBitRate
	{
		get
		{
			return ((__Internal*)__Instance)->videoBitRate;
		}
		set
		{
			((__Internal*)__Instance)->videoBitRate = value;
		}
	}

	public unsafe uint VideoBufSize
	{
		get
		{
			return ((__Internal*)__Instance)->videoBufSize;
		}
		set
		{
			((__Internal*)__Instance)->videoBufSize = value;
		}
	}

	public unsafe uint VideoMinRate
	{
		get
		{
			return ((__Internal*)__Instance)->videoMinRate;
		}
		set
		{
			((__Internal*)__Instance)->videoMinRate = value;
		}
	}

	public unsafe uint VideoMaxRate
	{
		get
		{
			return ((__Internal*)__Instance)->videoMaxRate;
		}
		set
		{
			((__Internal*)__Instance)->videoMaxRate = value;
		}
	}

	public unsafe uint Gop
	{
		get
		{
			return ((__Internal*)__Instance)->gop;
		}
		set
		{
			((__Internal*)__Instance)->gop = value;
		}
	}

	public unsafe uint SegmentSize
	{
		get
		{
			return ((__Internal*)__Instance)->segmentSize;
		}
		set
		{
			((__Internal*)__Instance)->segmentSize = value;
		}
	}

	internal unsafe static ProResiEncoderProfile __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProResiEncoderProfile(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProResiEncoderProfile __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProResiEncoderProfile(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProResiEncoderProfile(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProResiEncoderProfile(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProResiEncoderProfile()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProResiEncoderProfile()
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
