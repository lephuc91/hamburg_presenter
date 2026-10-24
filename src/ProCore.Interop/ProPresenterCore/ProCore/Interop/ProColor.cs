using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

public class ProColor : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal float r;

		[FieldOffset(4)]
		internal float g;

		[FieldOffset(8)]
		internal float b;

		[FieldOffset(12)]
		internal float a;

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "??8ProColor@@QEBA_NAEBU0@@Z")]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool OperatorEqualEqual(nint __instance, nint o);
	}

	internal static readonly ConcurrentDictionary<nint, ProColor> NativeToManagedMap = new ConcurrentDictionary<nint, ProColor>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe float R
	{
		get
		{
			return ((__Internal*)__Instance)->r;
		}
		set
		{
			((__Internal*)__Instance)->r = value;
		}
	}

	public unsafe float G
	{
		get
		{
			return ((__Internal*)__Instance)->g;
		}
		set
		{
			((__Internal*)__Instance)->g = value;
		}
	}

	public unsafe float B
	{
		get
		{
			return ((__Internal*)__Instance)->b;
		}
		set
		{
			((__Internal*)__Instance)->b = value;
		}
	}

	public unsafe float A
	{
		get
		{
			return ((__Internal*)__Instance)->a;
		}
		set
		{
			((__Internal*)__Instance)->a = value;
		}
	}

	internal unsafe static ProColor __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProColor(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProColor __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProColor(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProColor(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProColor(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProColor()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProColor()
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

	public static bool operator !=(ProColor __op, ProColor o)
	{
		return !(__op == o);
	}

	public static bool operator ==(ProColor __op, ProColor o)
	{
		bool flag = (object)__op == null;
		bool flag2 = (object)o == null;
		if (flag || flag2)
		{
			return flag && flag2;
		}
		nint _Instance = __op.__Instance;
		nint _Instance2 = o.__Instance;
		return __Internal.OperatorEqualEqual(_Instance, _Instance2);
	}

	public override bool Equals(object obj)
	{
		return this == obj as ProColor;
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
