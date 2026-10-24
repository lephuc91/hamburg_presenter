using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProSlideOnStageDisplayOnlyUpdateInfo : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProResourceUpdateType type;

		[FieldOffset(4)]
		internal uint stageOnly;
	}

	internal static readonly ConcurrentDictionary<nint, ProSlideOnStageDisplayOnlyUpdateInfo> NativeToManagedMap = new ConcurrentDictionary<nint, ProSlideOnStageDisplayOnlyUpdateInfo>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe ProResourceUpdateType Type
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

	public unsafe bool StageOnly
	{
		get
		{
			return ((__Internal*)__Instance)->stageOnly != 0;
		}
		set
		{
			((__Internal*)__Instance)->stageOnly = (value ? 1u : 0u);
		}
	}

	internal unsafe static ProSlideOnStageDisplayOnlyUpdateInfo __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProSlideOnStageDisplayOnlyUpdateInfo(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProSlideOnStageDisplayOnlyUpdateInfo __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProSlideOnStageDisplayOnlyUpdateInfo(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProSlideOnStageDisplayOnlyUpdateInfo(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProSlideOnStageDisplayOnlyUpdateInfo(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProSlideOnStageDisplayOnlyUpdateInfo()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProSlideOnStageDisplayOnlyUpdateInfo()
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
