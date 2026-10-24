using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProUUID : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal unsafe fixed byte bytes[16];
	}

	internal static readonly ConcurrentDictionary<nint, ProUUID> NativeToManagedMap = new ConcurrentDictionary<nint, ProUUID>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe byte[] Bytes
	{
		get
		{
			byte[] array = null;
			if (((__Internal*)__Instance)->bytes != null)
			{
				array = new byte[16];
				for (int i = 0; i < 16; i++)
				{
					array[i] = ((__Internal*)__Instance)->bytes[i];
				}
			}
			return array;
		}
		set
		{
			if (value != null)
			{
				for (int i = 0; i < 16; i++)
				{
					((__Internal*)__Instance)->bytes[i] = value[i];
				}
			}
		}
	}

	internal unsafe static ProUUID __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProUUID(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProUUID __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProUUID(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProUUID(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProUUID(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProUUID()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProUUID()
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
