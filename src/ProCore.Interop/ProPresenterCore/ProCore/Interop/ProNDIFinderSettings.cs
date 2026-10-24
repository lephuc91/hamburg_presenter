using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProNDIFinderSettings : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal uint showLocalSources;

		[FieldOffset(8)]
		internal nint groups;

		[FieldOffset(16)]
		internal nint extraIPs;
	}

	internal static readonly ConcurrentDictionary<nint, ProNDIFinderSettings> NativeToManagedMap = new ConcurrentDictionary<nint, ProNDIFinderSettings>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe bool ShowLocalSources
	{
		get
		{
			return ((__Internal*)__Instance)->showLocalSources != 0;
		}
		set
		{
			((__Internal*)__Instance)->showLocalSources = (value ? 1u : 0u);
		}
	}

	public unsafe string Groups
	{
		get
		{
			if (((__Internal*)__Instance)->groups == IntPtr.Zero)
			{
				return null;
			}
			byte* groups = (byte*)((__Internal*)__Instance)->groups;
			int num = 0;
			while (*(groups++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->groups, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->groups = new IntPtr(bytes);
			}
		}
	}

	public unsafe string ExtraIPs
	{
		get
		{
			if (((__Internal*)__Instance)->extraIPs == IntPtr.Zero)
			{
				return null;
			}
			byte* extraIPs = (byte*)((__Internal*)__Instance)->extraIPs;
			int num = 0;
			while (*(extraIPs++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->extraIPs, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->extraIPs = new IntPtr(bytes);
			}
		}
	}

	internal unsafe static ProNDIFinderSettings __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProNDIFinderSettings(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProNDIFinderSettings __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProNDIFinderSettings(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProNDIFinderSettings(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProNDIFinderSettings(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProNDIFinderSettings()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProNDIFinderSettings()
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
