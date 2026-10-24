using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProMessageSlideTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(4)]
		internal uint messageSize;

		[FieldOffset(8)]
		internal nint messageAction;

		[FieldOffset(16)]
		internal uint slideSize;

		[FieldOffset(24)]
		internal nint slide;

		[FieldOffset(32)]
		internal uint messageDataSize;

		[FieldOffset(40)]
		internal nint messageData;
	}

	internal static readonly ConcurrentDictionary<nint, ProMessageSlideTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProMessageSlideTransfer>();

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

	public unsafe uint MessageSize
	{
		get
		{
			return ((__Internal*)__Instance)->messageSize;
		}
		set
		{
			((__Internal*)__Instance)->messageSize = value;
		}
	}

	public unsafe nint MessageAction
	{
		get
		{
			return ((__Internal*)__Instance)->messageAction;
		}
		set
		{
			((__Internal*)__Instance)->messageAction = value;
		}
	}

	public unsafe uint SlideSize
	{
		get
		{
			return ((__Internal*)__Instance)->slideSize;
		}
		set
		{
			((__Internal*)__Instance)->slideSize = value;
		}
	}

	public unsafe nint Slide
	{
		get
		{
			return ((__Internal*)__Instance)->slide;
		}
		set
		{
			((__Internal*)__Instance)->slide = value;
		}
	}

	public unsafe uint MessageDataSize
	{
		get
		{
			return ((__Internal*)__Instance)->messageDataSize;
		}
		set
		{
			((__Internal*)__Instance)->messageDataSize = value;
		}
	}

	public unsafe nint MessageData
	{
		get
		{
			return ((__Internal*)__Instance)->messageData;
		}
		set
		{
			((__Internal*)__Instance)->messageData = value;
		}
	}

	internal unsafe static ProMessageSlideTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProMessageSlideTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProMessageSlideTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProMessageSlideTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProMessageSlideTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProMessageSlideTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProMessageSlideTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProMessageSlideTransfer()
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
