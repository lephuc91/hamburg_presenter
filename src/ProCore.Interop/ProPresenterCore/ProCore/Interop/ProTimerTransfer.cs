using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProTimerTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(8)]
		internal nint timerID;

		[FieldOffset(16)]
		internal nint timerName;

		[FieldOffset(24)]
		internal uint timerConfigurationSize;

		[FieldOffset(32)]
		internal nint timerConfiguration;

		[FieldOffset(40)]
		internal ProTimerActionType timerAction;

		[FieldOffset(44)]
		internal uint timerSize;

		[FieldOffset(48)]
		internal nint timerData;

		[FieldOffset(56)]
		internal float timerIncrementAmount;
	}

	internal static readonly ConcurrentDictionary<nint, ProTimerTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProTimerTransfer>();

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

	public unsafe ProUUID TimerID
	{
		get
		{
			if (((__Internal*)__Instance)->timerID == IntPtr.Zero)
			{
				return null;
			}
			if (ProUUID.NativeToManagedMap.ContainsKey(((__Internal*)__Instance)->timerID))
			{
				return ProUUID.NativeToManagedMap[((__Internal*)__Instance)->timerID];
			}
			return ProUUID.__CreateInstance(((__Internal*)__Instance)->timerID);
		}
	}

	public unsafe string TimerName
	{
		get
		{
			if (((__Internal*)__Instance)->timerName == IntPtr.Zero)
			{
				return null;
			}
			byte* timerName = (byte*)((__Internal*)__Instance)->timerName;
			int num = 0;
			while (*(timerName++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->timerName, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->timerName = new IntPtr(bytes);
			}
		}
	}

	public unsafe uint TimerConfigurationSize
	{
		get
		{
			return ((__Internal*)__Instance)->timerConfigurationSize;
		}
		set
		{
			((__Internal*)__Instance)->timerConfigurationSize = value;
		}
	}

	public unsafe nint TimerConfiguration
	{
		get
		{
			return ((__Internal*)__Instance)->timerConfiguration;
		}
		set
		{
			((__Internal*)__Instance)->timerConfiguration = value;
		}
	}

	public unsafe ProTimerActionType TimerAction
	{
		get
		{
			return ((__Internal*)__Instance)->timerAction;
		}
		set
		{
			((__Internal*)__Instance)->timerAction = value;
		}
	}

	public unsafe uint TimerSize
	{
		get
		{
			return ((__Internal*)__Instance)->timerSize;
		}
		set
		{
			((__Internal*)__Instance)->timerSize = value;
		}
	}

	public unsafe nint TimerData
	{
		get
		{
			return ((__Internal*)__Instance)->timerData;
		}
		set
		{
			((__Internal*)__Instance)->timerData = value;
		}
	}

	public unsafe float TimerIncrementAmount
	{
		get
		{
			return ((__Internal*)__Instance)->timerIncrementAmount;
		}
		set
		{
			((__Internal*)__Instance)->timerIncrementAmount = value;
		}
	}

	internal unsafe static ProTimerTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProTimerTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProTimerTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProTimerTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProTimerTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProTimerTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProTimerTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProTimerTransfer()
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
