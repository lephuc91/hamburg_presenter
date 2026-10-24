using System;
using System.Collections.Generic;
using System.Threading;

namespace Pro.Loro;

public class VersionVector : IVersionVector, IDisposable
{
	protected IntPtr pointer;

	private int _wasDestroyed;

	private long _callCounter = 1L;

	public VersionVector(IntPtr pointer)
	{
		this.pointer = pointer;
	}

	~VersionVector()
	{
		Destroy();
	}

	public VersionVector()
		: this(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_constructor_versionvector_new(ref _status);
		}))
	{
	}

	protected void FreeRustArcPtr()
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.uniffi_loro_ffi_fn_free_versionvector(pointer, ref status);
		});
	}

	protected IntPtr CloneRustArcPtr()
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_clone_versionvector(pointer, ref status);
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

	public VersionVectorDiff Diff(VersionVector rhs)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeVersionVectorDiff.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionvector_diff(thisPtr, FfiConverterTypeVersionVector.INSTANCE.Lower(rhs), ref _status);
		})));
	}

	public byte[] Encode()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterByteArray.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionvector_encode(thisPtr, ref _status);
		})));
	}

	public bool Eq(VersionVector other)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionvector_eq(thisPtr, FfiConverterTypeVersionVector.INSTANCE.Lower(other), ref _status);
		})));
	}

	public void ExtendToIncludeVv(VersionVector other)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_versionvector_extend_to_include_vv(thisPtr, FfiConverterTypeVersionVector.INSTANCE.Lower(other), ref _status);
			});
		});
	}

	public int? GetLast(ulong peer)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalInt32.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionvector_get_last(thisPtr, FfiConverterUInt64.INSTANCE.Lower(peer), ref _status);
		})));
	}

	public List<IdSpan> GetMissingSpan(VersionVector target)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceTypeIdSpan.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionvector_get_missing_span(thisPtr, FfiConverterTypeVersionVector.INSTANCE.Lower(target), ref _status);
		})));
	}

	public bool IncludesId(Id id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionvector_includes_id(thisPtr, FfiConverterTypeID.INSTANCE.Lower(id), ref _status);
		})));
	}

	public bool IncludesVv(VersionVector other)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionvector_includes_vv(thisPtr, FfiConverterTypeVersionVector.INSTANCE.Lower(other), ref _status);
		})));
	}

	public CounterSpan? IntersectSpan(IdSpan target)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeCounterSpan.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionvector_intersect_span(thisPtr, FfiConverterTypeIdSpan.INSTANCE.Lower(target), ref _status);
		})));
	}

	public void Merge(VersionVector other)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_versionvector_merge(thisPtr, FfiConverterTypeVersionVector.INSTANCE.Lower(other), ref _status);
			});
		});
	}

	public Ordering? PartialCmp(VersionVector other)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeOrdering.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionvector_partial_cmp(thisPtr, FfiConverterTypeVersionVector.INSTANCE.Lower(other), ref _status);
		})));
	}

	public void SetEnd(Id id)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_versionvector_set_end(thisPtr, FfiConverterTypeID.INSTANCE.Lower(id), ref _status);
			});
		});
	}

	public void SetLast(Id id)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_versionvector_set_last(thisPtr, FfiConverterTypeID.INSTANCE.Lower(id), ref _status);
			});
		});
	}

	public Dictionary<ulong, int> ToHashmap()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterDictionaryUInt64Int32.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionvector_to_hashmap(thisPtr, ref _status);
		})));
	}

	public bool TryUpdateLast(Id id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_versionvector_try_update_last(thisPtr, FfiConverterTypeID.INSTANCE.Lower(id), ref _status);
		})));
	}

	public static VersionVector Decode(byte[] bytes)
	{
		return new VersionVector(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_constructor_versionvector_decode(FfiConverterByteArray.INSTANCE.Lower(bytes), ref _status);
		}));
	}
}
