using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProResiDestinationGroup : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal nint id;

		[FieldOffset(8)]
		internal nint name;
	}

	internal static readonly ConcurrentDictionary<nint, ProResiDestinationGroup> NativeToManagedMap = new ConcurrentDictionary<nint, ProResiDestinationGroup>();

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

	public unsafe string Name
	{
		get
		{
			if (((__Internal*)__Instance)->name == IntPtr.Zero)
			{
				return null;
			}
			byte* name = (byte*)((__Internal*)__Instance)->name;
			int num = 0;
			while (*(name++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->name, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->name = new IntPtr(bytes);
			}
		}
	}

	internal unsafe static ProResiDestinationGroup __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProResiDestinationGroup(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProResiDestinationGroup __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProResiDestinationGroup(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProResiDestinationGroup(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProResiDestinationGroup(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProResiDestinationGroup()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProResiDestinationGroup()
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
