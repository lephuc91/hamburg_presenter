using System;
using System.Collections.Generic;
using System.Threading;

namespace Pro.Loro;

public class LoroText : ILoroText, IDisposable
{
	protected IntPtr pointer;

	private int _wasDestroyed;

	private long _callCounter = 1L;

	public LoroText(IntPtr pointer)
	{
		this.pointer = pointer;
	}

	~LoroText()
	{
		Destroy();
	}

	public LoroText()
		: this(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_constructor_lorotext_new(ref _status);
		}))
	{
	}

	protected void FreeRustArcPtr()
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.uniffi_loro_ffi_fn_free_lorotext(pointer, ref status);
		});
	}

	protected IntPtr CloneRustArcPtr()
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_clone_lorotext(pointer, ref status);
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

	public void ApplyDelta(List<TextDelta> delta)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_apply_delta(thisPtr, FfiConverterSequenceTypeTextDelta.INSTANCE.Lower(delta), ref _status);
			});
		});
	}

	public string CharAt(uint pos)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterString.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_char_at(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), ref _status);
		})));
	}

	public uint? ConvertPos(uint index, PosType from, PosType to)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalUInt32.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_convert_pos(thisPtr, FfiConverterUInt32.INSTANCE.Lower(index), FfiConverterTypePosType.INSTANCE.Lower(from), FfiConverterTypePosType.INSTANCE.Lower(to), ref _status);
		})));
	}

	public void Delete(uint pos, uint len)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_delete(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterUInt32.INSTANCE.Lower(len), ref _status);
			});
		});
	}

	public void DeleteUtf16(uint pos, uint len)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_delete_utf16(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterUInt32.INSTANCE.Lower(len), ref _status);
			});
		});
	}

	public void DeleteUtf8(uint pos, uint len)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_delete_utf8(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterUInt32.INSTANCE.Lower(len), ref _status);
			});
		});
	}

	public LoroDoc? Doc()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroDoc.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_doc(thisPtr, ref _status);
		})));
	}

	public LoroText? GetAttached()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroText.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_get_attached(thisPtr, ref _status);
		})));
	}

	public Cursor? GetCursor(uint pos, Side side)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeCursor.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_get_cursor(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterTypeSide.INSTANCE.Lower(side), ref _status);
		})));
	}

	public ulong? GetEditorAtUnicodePos(uint pos)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalUInt64.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_get_editor_at_unicode_pos(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), ref _status);
		})));
	}

	public LoroValue GetRichtextValue()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_get_richtext_value(thisPtr, ref _status);
		})));
	}

	public ContainerId Id()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeContainerID.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_id(thisPtr, ref _status);
		})));
	}

	public void Insert(uint pos, string s)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_insert(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterString.INSTANCE.Lower(s), ref _status);
			});
		});
	}

	public void InsertUtf16(uint pos, string s)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_insert_utf16(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterString.INSTANCE.Lower(s), ref _status);
			});
		});
	}

	public void InsertUtf8(uint pos, string s)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_insert_utf8(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterString.INSTANCE.Lower(s), ref _status);
			});
		});
	}

	public bool IsAttached()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_is_attached(thisPtr, ref _status);
		})));
	}

	public bool IsDeleted()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_is_deleted(thisPtr, ref _status);
		})));
	}

	public bool IsEmpty()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_is_empty(thisPtr, ref _status);
		})));
	}

	public uint LenUnicode()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt32.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_len_unicode(thisPtr, ref _status);
		})));
	}

	public uint LenUtf16()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt32.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_len_utf16(thisPtr, ref _status);
		})));
	}

	public uint LenUtf8()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt32.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_len_utf8(thisPtr, ref _status);
		})));
	}

	public void Mark(uint from, uint to, string key, LoroValueLike value)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_mark(thisPtr, FfiConverterUInt32.INSTANCE.Lower(from), FfiConverterUInt32.INSTANCE.Lower(to), FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroValueLike.INSTANCE.Lower(value), ref _status);
			});
		});
	}

	public void MarkUtf16(uint from, uint to, string key, LoroValueLike value)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_mark_utf16(thisPtr, FfiConverterUInt32.INSTANCE.Lower(from), FfiConverterUInt32.INSTANCE.Lower(to), FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroValueLike.INSTANCE.Lower(value), ref _status);
			});
		});
	}

	public void MarkUtf8(uint from, uint to, string key, LoroValueLike value)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_mark_utf8(thisPtr, FfiConverterUInt32.INSTANCE.Lower(from), FfiConverterUInt32.INSTANCE.Lower(to), FfiConverterString.INSTANCE.Lower(key), FfiConverterTypeLoroValueLike.INSTANCE.Lower(value), ref _status);
			});
		});
	}

	public void PushStr(string s)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_push_str(thisPtr, FfiConverterString.INSTANCE.Lower(s), ref _status);
			});
		});
	}

	public string Slice(uint startIndex, uint endIndex)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterString.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_slice(thisPtr, FfiConverterUInt32.INSTANCE.Lower(startIndex), FfiConverterUInt32.INSTANCE.Lower(endIndex), ref _status);
		})));
	}

	public List<TextDelta> SliceDelta(uint startIndex, uint endIndex, PosType posType)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceTypeTextDelta.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_slice_delta(thisPtr, FfiConverterUInt32.INSTANCE.Lower(startIndex), FfiConverterUInt32.INSTANCE.Lower(endIndex), FfiConverterTypePosType.INSTANCE.Lower(posType), ref _status);
		})));
	}

	public string SliceUtf16(uint startIndex, uint endIndex)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterString.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_slice_utf16(thisPtr, FfiConverterUInt32.INSTANCE.Lower(startIndex), FfiConverterUInt32.INSTANCE.Lower(endIndex), ref _status);
		})));
	}

	public string Splice(uint pos, uint len, string s)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterString.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_splice(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterUInt32.INSTANCE.Lower(len), FfiConverterString.INSTANCE.Lower(s), ref _status);
		})));
	}

	public void SpliceUtf16(uint pos, uint len, string s)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_splice_utf16(thisPtr, FfiConverterUInt32.INSTANCE.Lower(pos), FfiConverterUInt32.INSTANCE.Lower(len), FfiConverterString.INSTANCE.Lower(s), ref _status);
			});
		});
	}

	public Subscription? Subscribe(Subscriber subscriber)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeSubscription.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_subscribe(thisPtr, FfiConverterTypeSubscriber.INSTANCE.Lower(subscriber), ref _status);
		})));
	}

	public List<TextDelta> ToDelta()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceTypeTextDelta.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_to_delta(thisPtr, ref _status);
		})));
	}

	public void Unmark(uint from, uint to, string key)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_unmark(thisPtr, FfiConverterUInt32.INSTANCE.Lower(from), FfiConverterUInt32.INSTANCE.Lower(to), FfiConverterString.INSTANCE.Lower(key), ref _status);
			});
		});
	}

	public void UnmarkUtf16(uint from, uint to, string key)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_unmark_utf16(thisPtr, FfiConverterUInt32.INSTANCE.Lower(from), FfiConverterUInt32.INSTANCE.Lower(to), FfiConverterString.INSTANCE.Lower(key), ref _status);
			});
		});
	}

	public void Update(string s, UpdateOptions options)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeUpdateTimeoutError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_update(thisPtr, FfiConverterString.INSTANCE.Lower(s), FfiConverterTypeUpdateOptions.INSTANCE.Lower(options), ref _status);
			});
		});
	}

	public void UpdateByLine(string s, UpdateOptions options)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeUpdateTimeoutError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotext_update_by_line(thisPtr, FfiConverterString.INSTANCE.Lower(s), FfiConverterTypeUpdateOptions.INSTANCE.Lower(options), ref _status);
			});
		});
	}

	public override string ToString()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterString.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotext_uniffi_trait_display(thisPtr, ref _status);
		})));
	}
}
