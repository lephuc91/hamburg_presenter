using System;
using System.Collections.Generic;
using System.Threading;

namespace Pro.Loro;

public class LoroMovableList : ILoroMovableList, IDisposable
{
	protected IntPtr pointer;

	private int _wasDestroyed;

	private long _callCounter = 1L;

	public LoroMovableList(IntPtr pointer)
	{
		this.pointer = pointer;
	}

	~LoroMovableList()
	{
		Destroy();
	}

	public LoroMovableList()
		: this(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_constructor_loromovablelist_new(ref _status);
		}))
	{
	}

	protected void FreeRustArcPtr()
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.uniffi_loro_ffi_fn_free_loromovablelist(pointer, ref status);
		});
	}

	protected IntPtr CloneRustArcPtr()
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_clone_loromovablelist(pointer, ref status);
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
				_UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_clear(thisPtr, ref _status);
			});
		});
	}

	public void Delete(uint pos, uint len)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_delete(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterUInt32.INSTANCE.Lower(len), ref _status);
			});
		});
	}

	public LoroDoc? Doc()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroDoc.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_doc(thisPtr, ref _status);
		})));
	}

	public ValueOrContainer? Get(uint index)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeValueOrContainer.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_get(thisPtr, FfiConverterUInt32.INSTANCE.Lower(index), ref _status);
		})));
	}

	public LoroMovableList? GetAttached()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroMovableList.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_get_attached(thisPtr, ref _status);
		})));
	}

	public ulong? GetCreatorAt(uint pos)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalUInt64.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_get_creator_at(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), ref _status);
		})));
	}

	public Cursor? GetCursor(uint pos, Side side)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeCursor.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_get_cursor(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeSide.INSTANCE.Lower(side), ref _status);
		})));
	}

	public LoroValue GetDeepValue()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_get_deep_value(thisPtr, ref _status);
		})));
	}

	public ulong? GetLastEditorAt(uint pos)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalUInt64.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_get_last_editor_at(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), ref _status);
		})));
	}

	public ulong? GetLastMoverAt(uint pos)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalUInt64.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_get_last_mover_at(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), ref _status);
		})));
	}

	public LoroValue GetValue()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_get_value(thisPtr, ref _status);
		})));
	}

	public ContainerId Id()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeContainerID.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_id(thisPtr, ref _status);
		})));
	}

	public void Insert(uint pos, LoroValueLike v)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_insert(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroValueLike.INSTANCE.Lower(v), ref _status);
			});
		});
	}

	public LoroCounter InsertCounterContainer(uint pos, LoroCounter child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroCounter.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_insert_counter_container(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroCounter.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroList InsertListContainer(uint pos, LoroList child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroList.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_insert_list_container(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroList.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroMap InsertMapContainer(uint pos, LoroMap child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroMap.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_insert_map_container(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroMap.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroMovableList InsertMovableListContainer(uint pos, LoroMovableList child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroMovableList.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_insert_movable_list_container(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroMovableList.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroText InsertTextContainer(uint pos, LoroText child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroText.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_insert_text_container(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroText.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroTree InsertTreeContainer(uint pos, LoroTree child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroTree.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_insert_tree_container(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroTree.INSTANCE.Lower(child), ref _status);
		})));
	}

	public bool IsAttached()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_is_attached(thisPtr, ref _status);
		})));
	}

	public bool IsDeleted()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_is_deleted(thisPtr, ref _status);
		})));
	}

	public bool IsEmpty()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_is_empty(thisPtr, ref _status);
		})));
	}

	public uint Len()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt32.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_len(thisPtr, ref _status);
		})));
	}

	public void Mov(uint from, uint to)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_mov(thisPtr, FfiConverterUInt32.INSTANCE.Lower(from), FfiConverterUInt32.INSTANCE.Lower(to), ref _status);
			});
		});
	}

	public ValueOrContainer? Pop()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeValueOrContainer.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_pop(thisPtr, ref _status);
		})));
	}

	public void Push(LoroValueLike v)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_push(thisPtr, FfiConverterTypeLoroValueLike.INSTANCE.Lower(v), ref _status);
			});
		});
	}

	public void Set(uint pos, LoroValueLike value)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_set(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroValueLike.INSTANCE.Lower(value), ref _status);
			});
		});
	}

	public LoroCounter SetCounterContainer(uint pos, LoroCounter child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroCounter.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_set_counter_container(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroCounter.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroList SetListContainer(uint pos, LoroList child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroList.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_set_list_container(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroList.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroMap SetMapContainer(uint pos, LoroMap child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroMap.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_set_map_container(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroMap.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroMovableList SetMovableListContainer(uint pos, LoroMovableList child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroMovableList.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_set_movable_list_container(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroMovableList.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroText SetTextContainer(uint pos, LoroText child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroText.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_set_text_container(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroText.INSTANCE.Lower(child), ref _status);
		})));
	}

	public LoroTree SetTreeContainer(uint pos, LoroTree child)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroTree.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_set_tree_container(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeLoroTree.INSTANCE.Lower(child), ref _status);
		})));
	}

	public Subscription? Subscribe(Subscriber subscriber)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeSubscription.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_subscribe(thisPtr, FfiConverterTypeSubscriber.INSTANCE.Lower(subscriber), ref _status);
		})));
	}

	public List<LoroValue> ToVec()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_loromovablelist_to_vec(thisPtr, ref _status);
		})));
	}
}
