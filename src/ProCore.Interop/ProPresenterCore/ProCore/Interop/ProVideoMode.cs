using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProVideoMode : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 80)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal int width;

		[FieldOffset(4)]
		internal int height;

		[FieldOffset(8)]
		internal float frameRate;

		[FieldOffset(12)]
		internal uint interlaced;

		[FieldOffset(16)]
		internal nint name;
	}

	internal static readonly ConcurrentDictionary<nint, ProVideoMode> NativeToManagedMap = new ConcurrentDictionary<nint, ProVideoMode>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe int Width
	{
		get
		{
			return ((__Internal*)__Instance)->width;
		}
		set
		{
			((__Internal*)__Instance)->width = value;
		}
	}

	public unsafe int Height
	{
		get
		{
			return ((__Internal*)__Instance)->height;
		}
		set
		{
			((__Internal*)__Instance)->height = value;
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
				Encoding.UTF8.GetBytes(chars, value.Length, (byte*)((__Internal*)__Instance)->name, 63);
				*(sbyte*)(((__Internal*)__Instance)->name + Math.Min(value.Length, 63)) = 0;
			}
		}
	}

	internal unsafe static ProVideoMode __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProVideoMode(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProVideoMode __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProVideoMode(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProVideoMode(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProVideoMode(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProVideoMode()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProVideoMode()
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
