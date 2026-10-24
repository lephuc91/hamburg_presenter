using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProAudioFormat : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 12)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal int sampleRate;

		[FieldOffset(4)]
		internal int bitDepth;

		[FieldOffset(8)]
		internal ProAudioFormatType type;
	}

	internal static readonly ConcurrentDictionary<nint, ProAudioFormat> NativeToManagedMap = new ConcurrentDictionary<nint, ProAudioFormat>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe int SampleRate
	{
		get
		{
			return ((__Internal*)__Instance)->sampleRate;
		}
		set
		{
			((__Internal*)__Instance)->sampleRate = value;
		}
	}

	public unsafe int BitDepth
	{
		get
		{
			return ((__Internal*)__Instance)->bitDepth;
		}
		set
		{
			((__Internal*)__Instance)->bitDepth = value;
		}
	}

	public unsafe ProAudioFormatType Type
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

	internal unsafe static ProAudioFormat __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProAudioFormat(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProAudioFormat __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProAudioFormat(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProAudioFormat(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProAudioFormat(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProAudioFormat()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProAudioFormat()
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
