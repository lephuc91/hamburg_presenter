using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProPlaylistCueTransfer : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal ProTriggerTransferType type;

		[FieldOffset(4)]
		internal ProPlaylistSourceType playlistSource;

		[FieldOffset(8)]
		internal nint playlistID;

		[FieldOffset(16)]
		internal nint playlistName;

		[FieldOffset(24)]
		internal uint alwaysRetrigger;

		[FieldOffset(32)]
		internal ulong cueHandle;

		[FieldOffset(40)]
		internal uint cueSize;

		[FieldOffset(48)]
		internal nint cue;

		[FieldOffset(56)]
		internal nint clientData;
	}

	internal static readonly ConcurrentDictionary<nint, ProPlaylistCueTransfer> NativeToManagedMap = new ConcurrentDictionary<nint, ProPlaylistCueTransfer>();

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

	public unsafe ProPlaylistSourceType PlaylistSource
	{
		get
		{
			return ((__Internal*)__Instance)->playlistSource;
		}
		set
		{
			((__Internal*)__Instance)->playlistSource = value;
		}
	}

	public unsafe ProUUID PlaylistID
	{
		get
		{
			if (((__Internal*)__Instance)->playlistID == IntPtr.Zero)
			{
				return null;
			}
			if (ProUUID.NativeToManagedMap.ContainsKey(((__Internal*)__Instance)->playlistID))
			{
				return ProUUID.NativeToManagedMap[((__Internal*)__Instance)->playlistID];
			}
			return ProUUID.__CreateInstance(((__Internal*)__Instance)->playlistID);
		}
	}

	public unsafe string PlaylistName
	{
		get
		{
			if (((__Internal*)__Instance)->playlistName == IntPtr.Zero)
			{
				return null;
			}
			byte* playlistName = (byte*)((__Internal*)__Instance)->playlistName;
			int num = 0;
			while (*(playlistName++) != 0)
			{
				num++;
			}
			return Encoding.UTF8.GetString((byte*)((__Internal*)__Instance)->playlistName, num);
		}
		set
		{
			fixed (byte* bytes = Encoding.UTF8.GetBytes(value))
			{
				((__Internal*)__Instance)->playlistName = new IntPtr(bytes);
			}
		}
	}

	public unsafe bool AlwaysRetrigger
	{
		get
		{
			return ((__Internal*)__Instance)->alwaysRetrigger != 0;
		}
		set
		{
			((__Internal*)__Instance)->alwaysRetrigger = (value ? 1u : 0u);
		}
	}

	public unsafe ulong CueHandle
	{
		get
		{
			return ((__Internal*)__Instance)->cueHandle;
		}
		set
		{
			((__Internal*)__Instance)->cueHandle = value;
		}
	}

	public unsafe uint CueSize
	{
		get
		{
			return ((__Internal*)__Instance)->cueSize;
		}
		set
		{
			((__Internal*)__Instance)->cueSize = value;
		}
	}

	public unsafe nint Cue
	{
		get
		{
			return ((__Internal*)__Instance)->cue;
		}
		set
		{
			((__Internal*)__Instance)->cue = value;
		}
	}

	public unsafe nint ClientData
	{
		get
		{
			return ((__Internal*)__Instance)->clientData;
		}
		set
		{
			((__Internal*)__Instance)->clientData = value;
		}
	}

	internal unsafe static ProPlaylistCueTransfer __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProPlaylistCueTransfer(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProPlaylistCueTransfer __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProPlaylistCueTransfer(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProPlaylistCueTransfer(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProPlaylistCueTransfer(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProPlaylistCueTransfer()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProPlaylistCueTransfer()
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
