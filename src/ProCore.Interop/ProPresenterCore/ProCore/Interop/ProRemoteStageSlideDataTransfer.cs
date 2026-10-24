using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProRemoteStageSlideDataTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 80)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(8)]
		internal nint slideAddress;

		[FieldOffset(16)]
		internal nint currentText;

		[FieldOffset(24)]
		internal nint currentNotes;

		[FieldOffset(32)]
		internal nint currentRTFNotes;

		[FieldOffset(40)]
		internal ProUUID.__Internal nextID;

		[FieldOffset(56)]
		internal nint nextText;

		[FieldOffset(64)]
		internal nint nextNotes;

		[FieldOffset(72)]
		internal nint nextRTFNotes;
	}

	internal static readonly ConcurrentDictionary<nint, ProRemoteStageSlideDataTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProRemoteStageSlideDataTransfer>();

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

	public unsafe ProResourceAddress SlideAddress
	{
		get
		{
			if (((__Internal*)__Instance)->slideAddress == IntPtr.Zero)
			{
				return null;
			}
			if (ProResourceAddress.NativeToManagedMap.ContainsKey(((__Internal*)__Instance)->slideAddress))
			{
				return ProResourceAddress.NativeToManagedMap[((__Internal*)__Instance)->slideAddress];
			}
			return ProResourceAddress.__CreateInstance(((__Internal*)__Instance)->slideAddress);
		}
	}

	public unsafe string CurrentText
	{
		get
		{
			if (((__Internal*)__Instance)->currentText == IntPtr.Zero)
			{
				return null;
			}
			byte* currentText = (byte*)((__Internal*)__Instance)->currentText;
			int num = 0;
			while (*(currentText++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->currentText, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->currentText = new IntPtr(bytes);
			}
		}
	}

	public unsafe string CurrentNotes
	{
		get
		{
			if (((__Internal*)__Instance)->currentNotes == IntPtr.Zero)
			{
				return null;
			}
			byte* currentNotes = (byte*)((__Internal*)__Instance)->currentNotes;
			int num = 0;
			while (*(currentNotes++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->currentNotes, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->currentNotes = new IntPtr(bytes);
			}
		}
	}

	public unsafe string CurrentRTFNotes
	{
		get
		{
			if (((__Internal*)__Instance)->currentRTFNotes == IntPtr.Zero)
			{
				return null;
			}
			byte* currentRTFNotes = (byte*)((__Internal*)__Instance)->currentRTFNotes;
			int num = 0;
			while (*(currentRTFNotes++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->currentRTFNotes, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->currentRTFNotes = new IntPtr(bytes);
			}
		}
	}

	public unsafe ProUUID NextID
	{
		get
		{
			return ProUUID.__CreateInstance(new IntPtr(&((__Internal*)__Instance)->nextID));
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value", "Cannot be null because it is passed by value.");
			}
			((__Internal*)__Instance)->nextID = *(ProUUID.__Internal*)value.__Instance;
		}
	}

	public unsafe string NextText
	{
		get
		{
			if (((__Internal*)__Instance)->nextText == IntPtr.Zero)
			{
				return null;
			}
			byte* nextText = (byte*)((__Internal*)__Instance)->nextText;
			int num = 0;
			while (*(nextText++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->nextText, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->nextText = new IntPtr(bytes);
			}
		}
	}

	public unsafe string NextNotes
	{
		get
		{
			if (((__Internal*)__Instance)->nextNotes == IntPtr.Zero)
			{
				return null;
			}
			byte* nextNotes = (byte*)((__Internal*)__Instance)->nextNotes;
			int num = 0;
			while (*(nextNotes++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->nextNotes, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->nextNotes = new IntPtr(bytes);
			}
		}
	}

	public unsafe string NextRTFNotes
	{
		get
		{
			if (((__Internal*)__Instance)->nextRTFNotes == IntPtr.Zero)
			{
				return null;
			}
			byte* nextRTFNotes = (byte*)((__Internal*)__Instance)->nextRTFNotes;
			int num = 0;
			while (*(nextRTFNotes++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->nextRTFNotes, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->nextRTFNotes = new IntPtr(bytes);
			}
		}
	}

	internal unsafe static ProRemoteStageSlideDataTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProRemoteStageSlideDataTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProRemoteStageSlideDataTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProRemoteStageSlideDataTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProRemoteStageSlideDataTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProRemoteStageSlideDataTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProRemoteStageSlideDataTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProRemoteStageSlideDataTransfer()
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
