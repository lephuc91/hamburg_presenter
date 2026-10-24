using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProSlideElementTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 88)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(8)]
		internal nint slideLink;

		[FieldOffset(16)]
		internal nint activePlaylistItemLink;

		[FieldOffset(24)]
		internal ProUUID.__Internal slideID;

		[FieldOffset(40)]
		internal ProUUID.__Internal elementID;

		[FieldOffset(56)]
		internal ProSlideElementLayer elementLayer;

		[FieldOffset(60)]
		internal uint textIndex;

		[FieldOffset(64)]
		internal nint triggerState;

		[FieldOffset(72)]
		internal uint triggerStateLength;

		[FieldOffset(80)]
		internal nint performTransfer;
	}

	internal static readonly ConcurrentDictionary<nint, ProSlideElementTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProSlideElementTransfer>();

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

	public unsafe ProResourceAddress SlideLink
	{
		get
		{
			if (((__Internal*)__Instance)->slideLink == IntPtr.Zero)
			{
				return null;
			}
			if (ProResourceAddress.NativeToManagedMap.ContainsKey(((__Internal*)__Instance)->slideLink))
			{
				return ProResourceAddress.NativeToManagedMap[((__Internal*)__Instance)->slideLink];
			}
			return ProResourceAddress.__CreateInstance(((__Internal*)__Instance)->slideLink);
		}
	}

	public unsafe ProResourceAddress ActivePlaylistItemLink
	{
		get
		{
			if (((__Internal*)__Instance)->activePlaylistItemLink == IntPtr.Zero)
			{
				return null;
			}
			if (ProResourceAddress.NativeToManagedMap.ContainsKey(((__Internal*)__Instance)->activePlaylistItemLink))
			{
				return ProResourceAddress.NativeToManagedMap[((__Internal*)__Instance)->activePlaylistItemLink];
			}
			return ProResourceAddress.__CreateInstance(((__Internal*)__Instance)->activePlaylistItemLink);
		}
	}

	public unsafe ProUUID SlideID
	{
		get
		{
			return ProUUID.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->slideID));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->slideID = *(ProUUID.__Internal*)value.__Instance;
		}
	}

	public unsafe ProUUID ElementID
	{
		get
		{
			return ProUUID.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->elementID));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->elementID = *(ProUUID.__Internal*)value.__Instance;
		}
	}

	public unsafe ProSlideElementLayer ElementLayer
	{
		get
		{
			return ((__Internal*)__Instance)->elementLayer;
		}
		set
		{
			((__Internal*)__Instance)->elementLayer = value;
		}
	}

	public unsafe uint TextIndex
	{
		get
		{
			return ((__Internal*)__Instance)->textIndex;
		}
		set
		{
			((__Internal*)__Instance)->textIndex = value;
		}
	}

	public unsafe nint TriggerState => ((__Internal*)__Instance)->triggerState;

	public unsafe uint TriggerStateLength
	{
		get
		{
			return ((__Internal*)__Instance)->triggerStateLength;
		}
		set
		{
			((__Internal*)__Instance)->triggerStateLength = value;
		}
	}

	public unsafe ProSlideElementTransferFunc PerformTransfer
	{
		get
		{
			nint performTransfer = ((__Internal*)__Instance)->performTransfer;
			if (performTransfer != IntPtr.Zero)
			{
				return (ProSlideElementTransferFunc)Marshal.GetDelegateForFunctionPointer(performTransfer, typeof(ProSlideElementTransferFunc));
			}
			return null;
		}
		set
		{
			((__Internal*)__Instance)->performTransfer = ((value == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value));
		}
	}

	internal unsafe static ProSlideElementTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProSlideElementTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProSlideElementTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProSlideElementTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProSlideElementTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProSlideElementTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProSlideElementTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProSlideElementTransfer()
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
