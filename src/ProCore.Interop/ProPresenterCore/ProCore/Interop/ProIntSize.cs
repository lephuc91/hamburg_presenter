using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

public class ProIntSize : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal int width;

		[FieldOffset(4)]
		internal int height;

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "??8ProIntSize@@QEBA_NAEBU0@@Z")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool OperatorEqualEqual(nint __instance, nint _0);
	}

	internal static readonly ConcurrentDictionary<nint, ProIntSize> NativeToManagedMap = new ConcurrentDictionary<nint, ProIntSize>();

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

	internal unsafe static ProIntSize __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProIntSize(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProIntSize __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProIntSize(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProIntSize(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProIntSize(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProIntSize()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProIntSize()
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

	public static bool operator !=(ProIntSize __op, ProIntSize _0)
	{
		return !(__op == _0);
	}

	public static bool operator ==(ProIntSize __op, ProIntSize _0)
	{
		bool flag = (object)__op == null;
		bool flag2 = (object)_0 == null;
		if (flag || flag2)
		{
			return flag && flag2;
		}
		nint _Instance = __op.__Instance;
		nint _Instance2 = _0.__Instance;
		return __Internal.OperatorEqualEqual(_Instance, _Instance2);
	}

	public override bool Equals(object obj)
	{
		return this == obj as ProIntSize;
	}

	public unsafe override int GetHashCode()
	{
		if (__Instance == IntPtr.Zero)
		{
			return ((IntPtr)IntPtr.Zero).GetHashCode();
		}
		return ((__Internal*)__Instance)->GetHashCode();
	}
}
