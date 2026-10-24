using System;
using System.Collections.Generic;
using System.Threading;

namespace Pro.Loro;

public class VersionRange : IVersionRange, IDisposable
{
	protected IntPtr pointer;

	private int _wasDestroyed;

	private long _callCounter = 1L;

	public VersionRange(IntPtr pointer)
	{
		this.pointer = pointer;
	}

	~VersionRange()
	{
		Destroy();
	}

	public VersionRange()
		: this(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_constructor_versionrange_new(ref _status);
		}))
	{
	}

	protected void FreeRustArcPtr()
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.uniffi_loro_ffi_fn_free_versionrange(pointer, ref status);
		});
	}

	protected IntPtr CloneRustArcPtr()
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_clone_versionrange(pointer, ref status);
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

	public void Clear()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_versionrange_clear(thisPtr, ref _status);
			});
		});
	}

	public bool ContainsId(Id id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionrange_contains_id(thisPtr, FfiConverterTypeID.INSTANCE.Lower(id), ref _status);
		})));
	}

	public bool ContainsIdSpan(IdSpan span)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionrange_contains_id_span(thisPtr, FfiConverterTypeIdSpan.INSTANCE.Lower(span), ref _status);
		})));
	}

	public bool ContainsOpsBetween(VersionVector vvA, VersionVector vvB)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionrange_contains_ops_between(thisPtr, FfiConverterTypeVersionVector.INSTANCE.Lower(vvA), FfiConverterTypeVersionVector.INSTANCE.Lower(vvB), ref _status);
		})));
	}

	public void ExtendsToIncludeIdSpan(IdSpan span)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_versionrange_extends_to_include_id_span(thisPtr, FfiConverterTypeIdSpan.INSTANCE.Lower(span), ref _status);
			});
		});
	}

	public CounterSpan? Get(ulong peer)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeCounterSpan.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionrange_get(thisPtr, FfiConverterUInt64.INSTANCE.Lower(peer), ref _status);
		})));
	}

	public List<VersionRangeItem> GetAllRanges()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceTypeVersionRangeItem.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionrange_get_all_ranges(thisPtr, ref _status);
		})));
	}

	public List<ulong> GetPeers()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceUInt64.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionrange_get_peers(thisPtr, ref _status);
		})));
	}

	public bool HasOverlapWith(IdSpan span)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionrange_has_overlap_with(thisPtr, FfiConverterTypeIdSpan.INSTANCE.Lower(span), ref _status);
		})));
	}

	public void Insert(ulong peer, int start, int end)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_versionrange_insert(thisPtr, FfiConverterUInt64.INSTANCE.Lower(peer), FfiConverterInt32.INSTANCE.Lower(start), FfiConverterInt32.INSTANCE.Lower(end), ref _status);
			});
		});
	}

	public bool IsEmpty()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionrange_is_empty(thisPtr, ref _status);
		})));
	}

	public static VersionRange FromVv(VersionVector vv)
	{
		return new VersionRange(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_constructor_versionrange_from_vv(FfiConverterTypeVersionVector.INSTANCE.Lower(vv), ref _status);
		}));
	}
}
