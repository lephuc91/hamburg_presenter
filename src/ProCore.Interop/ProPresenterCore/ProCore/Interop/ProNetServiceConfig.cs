using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProNetServiceConfig : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal uint remoteStageEnabled;

		[FieldOffset(8)]
		internal nint remoteStagePassword;

		[FieldOffset(16)]
		internal uint remoteWebEnabled;

		[FieldOffset(20)]
		internal uint slaveTriggerEnabled;
	}

	internal static readonly ConcurrentDictionary<nint, ProNetServiceConfig> NativeToManagedMap = new ConcurrentDictionary<nint, ProNetServiceConfig>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe bool RemoteStageEnabled
	{
		get
		{
			return ((__Internal*)__Instance)->remoteStageEnabled != 0;
		}
		set
		{
			((__Internal*)__Instance)->remoteStageEnabled = (value ? 1u : 0u);
		}
	}

	public unsafe string RemoteStagePassword
	{
		get
		{
			if (((__Internal*)__Instance)->remoteStagePassword == IntPtr.Zero)
			{
				return null;
			}
			byte* remoteStagePassword = (byte*)((__Internal*)__Instance)->remoteStagePassword;
			int num = 0;
			while (*(remoteStagePassword++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->remoteStagePassword, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->remoteStagePassword = new IntPtr(bytes);
			}
		}
	}

	public unsafe bool RemoteWebEnabled
	{
		get
		{
			return ((__Internal*)__Instance)->remoteWebEnabled != 0;
		}
		set
		{
			((__Internal*)__Instance)->remoteWebEnabled = (value ? 1u : 0u);
		}
	}

	public unsafe bool SlaveTriggerEnabled
	{
		get
		{
			return ((__Internal*)__Instance)->slaveTriggerEnabled != 0;
		}
		set
		{
			((__Internal*)__Instance)->slaveTriggerEnabled = (value ? 1u : 0u);
		}
	}

	internal unsafe static ProNetServiceConfig __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProNetServiceConfig(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProNetServiceConfig __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProNetServiceConfig(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProNetServiceConfig(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProNetServiceConfig(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProNetServiceConfig()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProNetServiceConfig()
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
