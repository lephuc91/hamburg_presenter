using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProResiFileUploadStatus : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal int initialCount;

		[FieldOffset(4)]
		internal int currentCount;
	}

	internal static readonly ConcurrentDictionary<nint, ProResiFileUploadStatus> NativeToManagedMap = new ConcurrentDictionary<nint, ProResiFileUploadStatus>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe int InitialCount
	{
		get
		{
			return ((__Internal*)__Instance)->initialCount;
		}
		set
		{
			((__Internal*)__Instance)->initialCount = value;
		}
	}

	public unsafe int CurrentCount
	{
		get
		{
			return ((__Internal*)__Instance)->currentCount;
		}
		set
		{
			((__Internal*)__Instance)->currentCount = value;
		}
	}

	internal unsafe static ProResiFileUploadStatus __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProResiFileUploadStatus(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProResiFileUploadStatus __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProResiFileUploadStatus(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProResiFileUploadStatus(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProResiFileUploadStatus(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProResiFileUploadStatus()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProResiFileUploadStatus()
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
