using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProVersionInformation : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal int majorVersion;

		[FieldOffset(4)]
		internal int minorVersion;

		[FieldOffset(8)]
		internal int patchVersion;

		[FieldOffset(12)]
		internal int build;
	}

	internal static readonly ConcurrentDictionary<nint, ProVersionInformation> NativeToManagedMap = new ConcurrentDictionary<nint, ProVersionInformation>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe int MajorVersion
	{
		get
		{
			return ((__Internal*)__Instance)->majorVersion;
		}
		set
		{
			((__Internal*)__Instance)->majorVersion = value;
		}
	}

	public unsafe int MinorVersion
	{
		get
		{
			return ((__Internal*)__Instance)->minorVersion;
		}
		set
		{
			((__Internal*)__Instance)->minorVersion = value;
		}
	}

	public unsafe int PatchVersion
	{
		get
		{
			return ((__Internal*)__Instance)->patchVersion;
		}
		set
		{
			((__Internal*)__Instance)->patchVersion = value;
		}
	}

	public unsafe int Build
	{
		get
		{
			return ((__Internal*)__Instance)->build;
		}
		set
		{
			((__Internal*)__Instance)->build = value;
		}
	}

	internal unsafe static ProVersionInformation __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProVersionInformation(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProVersionInformation __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProVersionInformation(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProVersionInformation(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProVersionInformation(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProVersionInformation()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProVersionInformation()
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
