using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProResiTransferAboutInfo : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProResiTransferType type;

		[FieldOffset(4)]
		internal uint success;

		[FieldOffset(8)]
		internal ProResiAboutInfo.__Internal aboutInfo;
	}

	internal static readonly ConcurrentDictionary<nint, ProResiTransferAboutInfo> NativeToManagedMap = new ConcurrentDictionary<nint, ProResiTransferAboutInfo>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProResiTransferType Type
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

	public unsafe bool Success
	{
		get
		{
			return ((__Internal*)__Instance)->success != 0;
		}
		set
		{
			((__Internal*)__Instance)->success = (value ? 1u : 0u);
		}
	}

	public unsafe ProResiAboutInfo AboutInfo
	{
		get
		{
			return ProResiAboutInfo.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->aboutInfo));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->aboutInfo = *(ProResiAboutInfo.__Internal*)value.__Instance;
		}
	}

	internal unsafe static ProResiTransferAboutInfo __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProResiTransferAboutInfo(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProResiTransferAboutInfo __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProResiTransferAboutInfo(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProResiTransferAboutInfo(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProResiTransferAboutInfo(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProResiTransferAboutInfo()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProResiTransferAboutInfo()
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
