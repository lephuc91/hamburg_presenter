using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProAltSlideTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(8)]
		internal nint lookID;

		[FieldOffset(16)]
		internal nint screenID;

		[FieldOffset(24)]
		internal uint screenWidth;

		[FieldOffset(28)]
		internal uint screenHeight;

		[FieldOffset(32)]
		internal nint originalSlide;

		[FieldOffset(40)]
		internal uint altSlideDataSize;

		[FieldOffset(48)]
		internal nint altSlideData;
	}

	internal static readonly ConcurrentDictionary<nint, ProAltSlideTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProAltSlideTransfer>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProTriggerTransferType Type
	{
		get
		{
			return ((__Internal*)__Instance)->type;
		}
		set
		{
			((__Internal*)__Instance)->type = value;
		}
	}

	public unsafe ProUUID LookID
	{
		get
		{
			if (((__Internal*)__Instance)->lookID == IntPtr.Zero)
			{
				return null;
			}
			if (ProUUID.NativeToManagedMap.ContainsKey(((__Internal*)__Instance)->lookID))
			{
				return ProUUID.NativeToManagedMap[((__Internal*)__Instance)->lookID];
			}
			return ProUUID.__CreateInstance(((__Internal*)__Instance)->lookID);
		}
	}

	public unsafe ProUUID ScreenID
	{
		get
		{
			if (((__Internal*)__Instance)->screenID == IntPtr.Zero)
			{
				return null;
			}
			if (ProUUID.NativeToManagedMap.ContainsKey(((__Internal*)__Instance)->screenID))
			{
				return ProUUID.NativeToManagedMap[((__Internal*)__Instance)->screenID];
			}
			return ProUUID.__CreateInstance(((__Internal*)__Instance)->screenID);
		}
	}

	public unsafe uint ScreenWidth
	{
		get
		{
			return ((__Internal*)__Instance)->screenWidth;
		}
		set
		{
			((__Internal*)__Instance)->screenWidth = value;
		}
	}

	public unsafe uint ScreenHeight
	{
		get
		{
			return ((__Internal*)__Instance)->screenHeight;
		}
		set
		{
			((__Internal*)__Instance)->screenHeight = value;
		}
	}

	public unsafe ProResourceAddress OriginalSlide
	{
		get
		{
			if (((__Internal*)__Instance)->originalSlide == IntPtr.Zero)
			{
				return null;
			}
			if (ProResourceAddress.NativeToManagedMap.ContainsKey(((__Internal*)__Instance)->originalSlide))
			{
				return ProResourceAddress.NativeToManagedMap[((__Internal*)__Instance)->originalSlide];
			}
			return ProResourceAddress.__CreateInstance(((__Internal*)__Instance)->originalSlide);
		}
	}

	public unsafe uint AltSlideDataSize
	{
		get
		{
			return ((__Internal*)__Instance)->altSlideDataSize;
		}
		set
		{
			((__Internal*)__Instance)->altSlideDataSize = value;
		}
	}

	public unsafe nint AltSlideData
	{
		get
		{
			return ((__Internal*)__Instance)->altSlideData;
		}
		set
		{
			((__Internal*)__Instance)->altSlideData = value;
		}
	}

	internal unsafe static ProAltSlideTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProAltSlideTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProAltSlideTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProAltSlideTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProAltSlideTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProAltSlideTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProAltSlideTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProAltSlideTransfer()
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
