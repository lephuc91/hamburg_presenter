using System;
using System.Collections.Generic;
using System.Threading;

namespace Pro.Loro;

public class Awareness : IAwareness, IDisposable
{
	protected IntPtr pointer;

	private int _wasDestroyed;

	private long _callCounter = 1L;

	public Awareness(IntPtr pointer)
	{
		this.pointer = pointer;
	}

	~Awareness()
	{
		Destroy();
	}

	public Awareness(ulong peer, long timeout)
		: this(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_constructor_awareness_new(FfiConverterUInt64.INSTANCE.Lower(peer), FfiConverterInt64.INSTANCE.Lower(timeout), ref _status);
		}))
	{
	}

	protected void FreeRustArcPtr()
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.uniffi_loro_ffi_fn_free_awareness(pointer, ref status);
		});
	}

	protected IntPtr CloneRustArcPtr()
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_clone_awareness(pointer, ref status);
		});
	}

	public void Destroy()
	{
		if (Interlocked.CompareExchange(ref _wasDestroyed, 1, 0) == 0 && Interlocked.Decrement(ref _callCounter) == 0L)
		{
			FreeRustArcPtr();
		}
	}

	public void Dispose()
	{
		Destroy();
		GC.SuppressFinalize(this);
	}

	private void IncrementCallCounter()
	{
		long num;
		do
		{
			num = Interlocked.Read(in _callCounter);
			switch (num)
			{
			case 0L:
				throw new ObjectDisposedException($"'{GetType().Name}' object has already been destroyed");
			case long.MaxValue:
				throw new OverflowException($"'{GetType().Name}' call counter would overflow");
			}
		}
		while (Interlocked.CompareExchange(ref _callCounter, num + 1, num) != num);
	}

	private void DecrementCallCounter()
	{
		if (Interlocked.Decrement(ref _callCounter) == 0L)
		{
			FreeRustArcPtr();
		}
	}

	internal void CallWithPointer(Action<IntPtr> action)
	{
		IncrementCallCounter();
		try
		{
			action(CloneRustArcPtr());
		}
		finally
		{
			DecrementCallCounter();
		}
	}

	internal T CallWithPointer<T>(Func<IntPtr, T> func)
	{
		IncrementCallCounter();
		try
		{
			return func(CloneRustArcPtr());
		}
		finally
		{
			DecrementCallCounter();
		}
	}

	public AwarenessPeerUpdate Apply(byte[] encodedPeersInfo)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeAwarenessPeerUpdate.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_awareness_apply(thisPtr, FfiConverterByteArray.INSTANCE.Lower(encodedPeersInfo), ref _status);
		})));
	}

	public byte[] Encode(List<ulong> peers)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterByteArray.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_awareness_encode(thisPtr, FfiConverterSequenceUInt64.INSTANCE.Lower(peers), ref _status);
		})));
	}

	public byte[] EncodeAll()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterByteArray.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_awareness_encode_all(thisPtr, ref _status);
		})));
	}

	public Dictionary<ulong, PeerInfo> GetAllStates()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterDictionaryUInt64TypePeerInfo.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_awareness_get_all_states(thisPtr, ref _status);
		})));
	}

	public LoroValue? GetLocalState()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_awareness_get_local_state(thisPtr, ref _status);
		})));
	}

	public ulong Peer()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt64.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_awareness_peer(thisPtr, ref _status);
		})));
	}

	public List<ulong> RemoveOutdated()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceUInt64.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_awareness_remove_outdated(thisPtr, ref _status);
		})));
	}

	public void SetLocalState(LoroValueLike value)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_awareness_set_local_state(thisPtr, FfiConverterTypeLoroValueLike.INSTANCE.Lower(value), ref _status);
			});
		});
	}
}
