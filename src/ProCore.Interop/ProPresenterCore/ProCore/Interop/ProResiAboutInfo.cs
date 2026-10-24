using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProResiAboutInfo : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal nint customerName;

		[FieldOffset(8)]
		internal nint encoderName;

		[FieldOffset(16)]
		internal nint encoderVersion;

		[FieldOffset(24)]
		internal nint manageURL;
	}

	internal static readonly ConcurrentDictionary<nint, ProResiAboutInfo> NativeToManagedMap = new ConcurrentDictionary<nint, ProResiAboutInfo>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe string CustomerName
	{
		get
		{
			if (((__Internal*)__Instance)->customerName == IntPtr.Zero)
			{
				return null;
			}
			byte* customerName = (byte*)((__Internal*)__Instance)->customerName;
			int num = 0;
			while (*(customerName++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->customerName, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->customerName = new IntPtr(bytes);
			}
		}
	}

	public unsafe string EncoderName
	{
		get
		{
			if (((__Internal*)__Instance)->encoderName == IntPtr.Zero)
			{
				return null;
			}
			byte* encoderName = (byte*)((__Internal*)__Instance)->encoderName;
			int num = 0;
			while (*(encoderName++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->encoderName, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->encoderName = new IntPtr(bytes);
			}
		}
	}

	public unsafe string EncoderVersion
	{
		get
		{
			if (((__Internal*)__Instance)->encoderVersion == IntPtr.Zero)
			{
				return null;
			}
			byte* encoderVersion = (byte*)((__Internal*)__Instance)->encoderVersion;
			int num = 0;
			while (*(encoderVersion++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->encoderVersion, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->encoderVersion = new IntPtr(bytes);
			}
		}
	}

	public unsafe string ManageURL
	{
		get
		{
			if (((__Internal*)__Instance)->manageURL == IntPtr.Zero)
			{
				return null;
			}
			byte* manageURL = (byte*)((__Internal*)__Instance)->manageURL;
			int num = 0;
			while (*(manageURL++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->manageURL, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->manageURL = new IntPtr(bytes);
			}
		}
	}

	internal unsafe static ProResiAboutInfo __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProResiAboutInfo(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProResiAboutInfo __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProResiAboutInfo(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProResiAboutInfo(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProResiAboutInfo(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProResiAboutInfo()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProResiAboutInfo()
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
