using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProCCLISlideTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(4)]
		internal uint screenWidth;

		[FieldOffset(8)]
		internal uint screenHeight;

		[FieldOffset(16)]
		internal nint originalSlide;

		[FieldOffset(24)]
		internal uint ccliSlideDataSize;

		[FieldOffset(32)]
		internal nint ccliSlideData;
	}

	internal static readonly ConcurrentDictionary<nint, ProCCLISlideTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProCCLISlideTransfer>();

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

	public unsafe uint CcliSlideDataSize
	{
		get
		{
			return ((__Internal*)__Instance)->ccliSlideDataSize;
		}
		set
		{
			((__Internal*)__Instance)->ccliSlideDataSize = value;
		}
	}

	public unsafe nint CcliSlideData
	{
		get
		{
			return ((__Internal*)__Instance)->ccliSlideData;
		}
		set
		{
			((__Internal*)__Instance)->ccliSlideData = value;
		}
	}

	internal unsafe static ProCCLISlideTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProCCLISlideTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProCCLISlideTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProCCLISlideTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProCCLISlideTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProCCLISlideTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProCCLISlideTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProCCLISlideTransfer()
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
