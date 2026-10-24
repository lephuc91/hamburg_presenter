using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProAudioChannel : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 256)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal nint name;
	}

	internal static readonly ConcurrentDictionary<nint, ProAudioChannel> NativeToManagedMap = new ConcurrentDictionary<nint, ProAudioChannel>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe string Name
	{
		get
		{
			sbyte* ptr;
			for (ptr = (sbyte*)new IntPtr(&((__Internal*)__Instance)->name); *ptr != 0; ptr++)
			{
			}
			return new string((sbyte*)new IntPtr(&((__Internal*)__Instance)->name), 0, (int)(ptr - (sbyte*)new IntPtr(&((__Internal*)__Instance)->name)), Encoding.UTF8);
		}
		set
		{
			fixed (char* chars = value)
			{
				Encoding.UTF8.GetBytes(chars, value.Length, (byte*)((__Internal*)__Instance)->name, 255);
				*(sbyte*)(((__Internal*)__Instance)->name + Math.Min(value.Length, 255)) = 0;
			}
		}
	}

	internal unsafe static ProAudioChannel __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProAudioChannel(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProAudioChannel __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProAudioChannel(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProAudioChannel(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProAudioChannel(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProAudioChannel()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProAudioChannel()
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
