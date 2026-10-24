using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public class ProTransportStatus : IDisposable
{
	[StructLayout(LayoutKind.Explicit, Size = 1088)]
	public struct __Internal
	{
		[FieldOffset(0)]
		internal uint isTransportable;

		[FieldOffset(4)]
		internal uint isPlaying;

		[FieldOffset(8)]
		internal uint willAutoAdvance;

		[FieldOffset(12)]
		internal uint isOnStageScreensOnly;

		[FieldOffset(16)]
		internal uint isScrubbing;

		[FieldOffset(24)]
		internal double playbackRate;

		[FieldOffset(32)]
		internal double fps;

		[FieldOffset(40)]
		internal double timeElapsed;

		[FieldOffset(48)]
		internal double timeRemaining;

		[FieldOffset(56)]
		internal unsafe fixed double peakVolume[64];

		[FieldOffset(568)]
		internal unsafe fixed double rmsVolume[64];

		[FieldOffset(1080)]
		internal uint audioChannelCount;

		[FieldOffset(1084)]
		internal int loopCount;
	}

	internal static readonly ConcurrentDictionary<nint, ProTransportStatus> NativeToManagedMap = new ConcurrentDictionary<nint, ProTransportStatus>();

	protected bool __ownsNativeInstance;

	public nint __Instance { get; protected set; }

	public unsafe bool IsTransportable
	{
		get
		{
			return ((__Internal*)__Instance)->isTransportable != 0;
		}
		set
		{
			((__Internal*)__Instance)->isTransportable = (value ? 1u : 0u);
		}
	}

	public unsafe bool IsPlaying
	{
		get
		{
			return ((__Internal*)__Instance)->isPlaying != 0;
		}
		set
		{
			((__Internal*)__Instance)->isPlaying = (value ? 1u : 0u);
		}
	}

	public unsafe bool WillAutoAdvance
	{
		get
		{
			return ((__Internal*)__Instance)->willAutoAdvance != 0;
		}
		set
		{
			((__Internal*)__Instance)->willAutoAdvance = (value ? 1u : 0u);
		}
	}

	public unsafe bool IsOnStageScreensOnly
	{
		get
		{
			return ((__Internal*)__Instance)->isOnStageScreensOnly != 0;
		}
		set
		{
			((__Internal*)__Instance)->isOnStageScreensOnly = (value ? 1u : 0u);
		}
	}

	public unsafe bool IsScrubbing
	{
		get
		{
			return ((__Internal*)__Instance)->isScrubbing != 0;
		}
		set
		{
			((__Internal*)__Instance)->isScrubbing = (value ? 1u : 0u);
		}
	}

	public unsafe double PlaybackRate
	{
		get
		{
			return ((__Internal*)__Instance)->playbackRate;
		}
		set
		{
			((__Internal*)__Instance)->playbackRate = value;
		}
	}

	public unsafe double Fps
	{
		get
		{
			return ((__Internal*)__Instance)->fps;
		}
		set
		{
			((__Internal*)__Instance)->fps = value;
		}
	}

	public unsafe double TimeElapsed
	{
		get
		{
			return ((__Internal*)__Instance)->timeElapsed;
		}
		set
		{
			((__Internal*)__Instance)->timeElapsed = value;
		}
	}

	public unsafe double TimeRemaining
	{
		get
		{
			return ((__Internal*)__Instance)->timeRemaining;
		}
		set
		{
			((__Internal*)__Instance)->timeRemaining = value;
		}
	}

	public unsafe double[] PeakVolume
	{
		get
		{
			double[] array = null;
			if (((__Internal*)__Instance)->peakVolume != null)
			{
				array = new double[64];
				for (int i = 0; i < 64; i++)
				{
					array[i] = ((__Internal*)__Instance)->peakVolume[i];
				}
			}
			return array;
		}
		set
		{
			if (value != null)
			{
				for (int i = 0; i < 64; i++)
				{
					((__Internal*)__Instance)->peakVolume[i] = value[i];
				}
			}
		}
	}

	public unsafe double[] RmsVolume
	{
		get
		{
			double[] array = null;
			if (((__Internal*)__Instance)->rmsVolume != null)
			{
				array = new double[64];
				for (int i = 0; i < 64; i++)
				{
					array[i] = ((__Internal*)__Instance)->rmsVolume[i];
				}
			}
			return array;
		}
		set
		{
			if (value != null)
			{
				for (int i = 0; i < 64; i++)
				{
					((__Internal*)__Instance)->rmsVolume[i] = value[i];
				}
			}
		}
	}

	public unsafe uint AudioChannelCount
	{
		get
		{
			return ((__Internal*)__Instance)->audioChannelCount;
		}
		set
		{
			((__Internal*)__Instance)->audioChannelCount = value;
		}
	}

	public unsafe int LoopCount
	{
		get
		{
			return ((__Internal*)__Instance)->loopCount;
		}
		set
		{
			((__Internal*)__Instance)->loopCount = value;
		}
	}

	internal unsafe static ProTransportStatus __CreateInstance(nint native, bool skipVTables = false)
	{
		return new ProTransportStatus(((IntPtr)native).ToPointer(), skipVTables);
	}

	internal static ProTransportStatus __CreateInstance(__Internal native, bool skipVTables = false)
	{
		return new ProTransportStatus(native, skipVTables);
	}

	private unsafe static void* __CopyValue(__Internal native)
	{
		nint num = Marshal.AllocHGlobal(sizeof(__Internal));
		*(__Internal*)num = native;
		return ((IntPtr)num).ToPointer();
	}

	private unsafe ProTransportStatus(__Internal native, bool skipVTables = false)
		: this(__CopyValue(native), skipVTables)
	{
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	protected unsafe ProTransportStatus(void* native, bool skipVTables = false)
	{
		if (native != null)
		{
			__Instance = new IntPtr(native);
		}
	}

	public unsafe ProTransportStatus()
	{
		__Instance = Marshal.AllocHGlobal(sizeof(__Internal));
		__ownsNativeInstance = true;
		NativeToManagedMap[__Instance] = this;
	}

	~ProTransportStatus()
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
