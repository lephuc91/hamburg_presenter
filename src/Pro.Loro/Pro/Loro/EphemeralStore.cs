using System;
using System.Collections.Generic;
using System.Threading;

namespace Pro.Loro;

public class EphemeralStore : IEphemeralStore, IDisposable
{
	protected IntPtr pointer;

	private int _wasDestroyed;

	private long _callCounter = 1L;

	public EphemeralStore(IntPtr pointer)
	{
		this.pointer = pointer;
	}

	~EphemeralStore()
	{
		Destroy();
	}

	public EphemeralStore(long timeout)
		: this(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_constructor_ephemeralstore_new(FfiConverterInt64.INSTANCE.Lower(timeout), ref _status);
		}))
	{
	}

	protected void FreeRustArcPtr()
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.uniffi_loro_ffi_fn_free_ephemeralstore(pointer, ref status);
		});
	}

	protected IntPtr CloneRustArcPtr()
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_clone_ephemeralstore(pointer, ref status);
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

	public void Apply(byte[] data)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_ephemeralstore_apply(thisPtr, FfiConverterByteArray.INSTANCE.Lower(data), ref _status);
			});
		});
	}

	public void Delete(string key)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_ephemeralstore_delete(thisPtr, FfiConverterString.INSTANCE.Lower(key), ref _status);
			});
		});
	}

	public byte[] Encode(string key)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterByteArray.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_ephemeralstore_encode(thisPtr, FfiConverterString.INSTANCE.Lower(key), ref _status);
		})));
	}

	public byte[] EncodeAll()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterByteArray.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_ephemeralstore_encode_all(thisPtr, ref _status);
		})));
	}

	public LoroValue? Get(string key)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_ephemeralstore_get(thisPtr, FfiConverterString.INSTANCE.Lower(key), ref _status);
		})));
	}

	public Dictionary<string, LoroValue> GetAllStates()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterDictionaryStringTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_ephemeralstore_get_all_states(thisPtr, ref _status);
		})));
	}

	public List<string> Keys()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceString.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_ephemeralstore_keys(thisPtr, ref _status);
		})));
	}

	public void RemoveOutdated()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_ephemeralstore_remove_outdated(thisPtr, ref _status);
			});
		});
	}

	public void Set(string key, LoroValueLike value)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_ephemeralstore_set(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroValueLike.INSTANCE.Lower(value), ref _status);
			});
		});
	}

	public Subscription Subscribe(EphemeralSubscriber listener)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeSubscription.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_ephemeralstore_subscribe(thisPtr, FfiConverterTypeEphemeralSubscriber.INSTANCE.Lower(listener), ref _status);
		})));
	}

	public Subscription SubscribeLocalUpdate(LocalEphemeralListener listener)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeSubscription.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_ephemeralstore_subscribe_local_update(thisPtr, FfiConverterTypeLocalEphemeralListener.INSTANCE.Lower(listener), ref _status);
		})));
	}
}
