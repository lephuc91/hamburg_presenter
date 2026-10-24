using System;
using System.Collections.Generic;
using System.Threading;

namespace Pro.Loro;

public class LoroMap : ILoroMap, IDisposable
{
	protected IntPtr pointer;

	private int _wasDestroyed;

	private long _callCounter = 1L;

	public LoroMap(IntPtr pointer)
	{
		this.pointer = pointer;
	}

	~LoroMap()
	{
		Destroy();
	}

	public LoroMap()
		: this(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_constructor_loromap_new(ref _status);
		}))
	{
	}

	protected void FreeRustArcPtr()
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.uniffi_loro_ffi_fn_free_loromap(pointer, ref status);
		});
	}

	protected IntPtr CloneRustArcPtr()
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_clone_loromap(pointer, ref status);
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
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_loromap_clear(thisPtr, ref _status);
			});
		});
	}

	public void Delete(string key)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_loromap_delete(thisPtr, FfiConverterString.INSTANCE.Lower(key), ref _status);
			});
		});
	}

	public LoroDoc? Doc()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroDoc.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_doc(thisPtr, ref _status);
		})));
	}

	public ValueOrContainer? Get(string key)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeValueOrContainer.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_get(thisPtr, FfiConverterString.INSTANCE.Lower(key), ref _status);
		})));
	}

	public LoroMap? GetAttached()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroMap.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_get_attached(thisPtr, ref _status);
		})));
	}

	public LoroValue GetDeepValue()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_get_deep_value(thisPtr, ref _status);
		})));
	}

	public ulong? GetLastEditor(string key)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalUInt64.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_get_last_editor(thisPtr, FfiConverterString.INSTANCE.Lower(key), ref _status);
		})));
	}

	public LoroCounter GetOrCreateCounterContainer(string key, LoroCounter child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroCounter.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_get_or_create_counter_container(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroCounter.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroList GetOrCreateListContainer(string key, LoroList child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroList.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_get_or_create_list_container(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroList.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroMap GetOrCreateMapContainer(string key, LoroMap child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroMap.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_get_or_create_map_container(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroMap.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroMovableList GetOrCreateMovableListContainer(string key, LoroMovableList child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroMovableList.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_get_or_create_movable_list_container(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroMovableList.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroText GetOrCreateTextContainer(string key, LoroText child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroText.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_get_or_create_text_container(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroText.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroTree GetOrCreateTreeContainer(string key, LoroTree child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroTree.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_get_or_create_tree_container(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroTree.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroValue GetValue()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_get_value(thisPtr, ref _status);
		})));
	}

	public ContainerId Id()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeContainerID.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_id(thisPtr, ref _status);
		})));
	}

	public void Insert(string key, LoroValueLike v)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_loromap_insert(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroValueLike.INSTANCE.Lower(v), ref _status);
			});
		});
	}

	public LoroCounter InsertCounterContainer(string key, LoroCounter child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroCounter.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_insert_counter_container(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroCounter.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroList InsertListContainer(string key, LoroList child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroList.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_insert_list_container(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroList.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroMap InsertMapContainer(string key, LoroMap child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroMap.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_insert_map_container(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroMap.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroMovableList InsertMovableListContainer(string key, LoroMovableList child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroMovableList.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_insert_movable_list_container(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroMovableList.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroText InsertTextContainer(string key, LoroText child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroText.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_insert_text_container(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroText.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroTree InsertTreeContainer(string key, LoroTree child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroTree.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_insert_tree_container(thisPtr, FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroTree.INSTANCE.Lower(child), ref _status);
		})));
	}

	public bool IsAttached()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_is_attached(thisPtr, ref _status);
		})));
	}

	public bool IsDeleted()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_is_deleted(thisPtr, ref _status);
		})));
	}

	public bool IsEmpty()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_is_empty(thisPtr, ref _status);
		})));
	}

	public List<string> Keys()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceString.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_keys(thisPtr, ref _status);
		})));
	}

	public uint Len()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt32.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_len(thisPtr, ref _status);
		})));
	}

	public Subscription? Subscribe(Subscriber subscriber)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeSubscription.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_subscribe(thisPtr, FfiConverterTypeSubscriber.INSTANCE.Lower(subscriber), ref _status);
		})));
	}

	public List<ValueOrContainer> Values()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceTypeValueOrContainer.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromap_values(thisPtr, ref _status);
		})));
	}
}
