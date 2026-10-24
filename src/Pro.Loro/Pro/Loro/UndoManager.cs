using System;
using System.Threading;

namespace Pro.Loro;

public class UndoManager : IUndoManager, IDisposable
{
	protected IntPtr pointer;

	private int _wasDestroyed;

	private long _callCounter = 1L;

	public UndoManager(IntPtr pointer)
	{
		this.pointer = pointer;
	}

	~UndoManager()
	{
		Destroy();
	}

	public UndoManager(LoroDoc doc)
		: this(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_constructor_undomanager_new(FfiConverterTypeLoroDoc.INSTANCE.Lower(doc), ref _status);
		}))
	{
	}

	protected void FreeRustArcPtr()
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.uniffi_loro_ffi_fn_free_undomanager(pointer, ref status);
		});
	}

	protected IntPtr CloneRustArcPtr()
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_clone_undomanager(pointer, ref status);
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

	public void AddExcludeOriginPrefix(string prefix)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_undomanager_add_exclude_origin_prefix(thisPtr, FfiConverterString.INSTANCE.Lower(prefix), ref _status);
			});
		});
	}

	public bool CanRedo()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_undomanager_can_redo(thisPtr, ref _status);
		})));
	}

	public bool CanUndo()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_undomanager_can_undo(thisPtr, ref _status);
		})));
	}

	public void GroupEnd()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_undomanager_group_end(thisPtr, ref _status);
			});
		});
	}

	public void GroupStart()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_undomanager_group_start(thisPtr, ref _status);
			});
		});
	}

	public ulong Peer()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt64.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_undomanager_peer(thisPtr, ref _status);
		})));
	}

	public void RecordNewCheckpoint()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_undomanager_record_new_checkpoint(thisPtr, ref _status);
			});
		});
	}

	public bool Redo()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_undomanager_redo(thisPtr, ref _status);
		})));
	}

	public uint RedoCount()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt32.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_undomanager_redo_count(thisPtr, ref _status);
		})));
	}

	public void SetMaxUndoSteps(uint size)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_undomanager_set_max_undo_steps(thisPtr, FfiConverterUInt32.INSTANCE.Lower(size), ref _status);
			});
		});
	}

	public void SetMergeInterval(long interval)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_undomanager_set_merge_interval(thisPtr, FfiConverterInt64.INSTANCE.Lower(interval), ref _status);
			});
		});
	}

	public void SetOnPop(OnPop? onPop)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_undomanager_set_on_pop(thisPtr, FfiConverterOptionalTypeOnPop.INSTANCE.Lower(onPop), ref _status);
			});
		});
	}

	public void SetOnPush(OnPush? onPush)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_undomanager_set_on_push(thisPtr, FfiConverterOptionalTypeOnPush.INSTANCE.Lower(onPush), ref _status);
			});
		});
	}

	public UndoItemMeta? TopRedoMeta()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeUndoItemMeta.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_undomanager_top_redo_meta(thisPtr, ref _status);
		})));
	}

	public LoroValue? TopRedoValue()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_undomanager_top_redo_value(thisPtr, ref _status);
		})));
	}

	public UndoItemMeta? TopUndoMeta()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeUndoItemMeta.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_undomanager_top_undo_meta(thisPtr, ref _status);
		})));
	}

	public LoroValue? TopUndoValue()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_undomanager_top_undo_value(thisPtr, ref _status);
		})));
	}

	public bool Undo()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_undomanager_undo(thisPtr, ref _status);
		})));
	}

	public uint UndoCount()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt32.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_undomanager_undo_count(thisPtr, ref _status);
		})));
	}
}
