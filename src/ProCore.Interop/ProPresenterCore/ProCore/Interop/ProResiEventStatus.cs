using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProResiEventStatus : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 28)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProResiStreamState currentState;

		[FieldOffset(4)]
		internal ProResiStreamState requestedState;

		[FieldOffset(8)]
		internal ProResiAccountStatus accountStatus;

		[FieldOffset(12)]
		internal ProResiFileUploadStatus.__Internal fileUploadStatus;

		[FieldOffset(20)]
		internal ProResiErrorCode errorCodes;

		[FieldOffset(24)]
		internal ProResiUploadHealth uploadHealth;
	}

	internal static readonly ConcurrentDictionary<nint, ProResiEventStatus> NativeToManagedMap = new ConcurrentDictionary<nint, ProResiEventStatus>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProResiStreamState CurrentState
	{
		get
		{
			return ((__Internal*)__Instance)->currentState;
		}
		set
		{
			((__Internal*)__Instance)->currentState = value;
		}
	}

	public unsafe ProResiStreamState RequestedState
	{
		get
		{
			return ((__Internal*)__Instance)->requestedState;
		}
		set
		{
			((__Internal*)__Instance)->requestedState = value;
		}
	}

	public unsafe ProResiAccountStatus AccountStatus
	{
		get
		{
			return ((__Internal*)__Instance)->accountStatus;
		}
		set
		{
			((__Internal*)__Instance)->accountStatus = value;
		}
	}

	public unsafe ProResiFileUploadStatus FileUploadStatus
	{
		get
		{
			return ProResiFileUploadStatus.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->fileUploadStatus));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->fileUploadStatus = *(ProResiFileUploadStatus.__Internal*)value.__Instance;
		}
	}

	public unsafe ProResiErrorCode ErrorCodes
	{
		get
		{
			return ((__Internal*)__Instance)->errorCodes;
		}
		set
		{
			((__Internal*)__Instance)->errorCodes = value;
		}
	}

	public unsafe ProResiUploadHealth UploadHealth
	{
		get
		{
			return ((__Internal*)__Instance)->uploadHealth;
		}
		set
		{
			((__Internal*)__Instance)->uploadHealth = value;
		}
	}

	internal unsafe static ProResiEventStatus __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProResiEventStatus(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProResiEventStatus __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProResiEventStatus(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProResiEventStatus(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProResiEventStatus(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProResiEventStatus()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProResiEventStatus()
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
