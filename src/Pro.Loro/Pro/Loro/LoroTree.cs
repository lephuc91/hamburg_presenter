using System;
using System.Collections.Generic;
using System.Threading;

namespace Pro.Loro;

public class LoroTree : ILoroTree, IDisposable
{
	protected IntPtr pointer;

	private int _wasDestroyed;

	private long _callCounter = 1L;

	public LoroTree(IntPtr pointer)
	{
		this.pointer = pointer;
	}

	~LoroTree()
	{
		Destroy();
	}

	public LoroTree()
		: this(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_constructor_lorotree_new(ref _status);
		}))
	{
	}

	protected void FreeRustArcPtr()
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.uniffi_loro_ffi_fn_free_lorotree(pointer, ref status);
		});
	}

	protected IntPtr CloneRustArcPtr()
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_clone_lorotree(pointer, ref status);
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

	public List<TreeId>? Children(TreeParentId parent)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalSequenceTypeTreeID.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_children(thisPtr, FfiConverterTypeTreeParentId.INSTANCE.Lower(parent), ref _status);
		})));
	}

	public uint? ChildrenNum(TreeParentId parent)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalUInt32.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_children_num(thisPtr, FfiConverterTypeTreeParentId.INSTANCE.Lower(parent), ref _status);
		})));
	}

	public bool Contains(TreeId target)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_contains(thisPtr, FfiConverterTypeTreeID.INSTANCE.Lower(target), ref _status);
		})));
	}

	public TreeId Create(TreeParentId parent)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeTreeID.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_create(thisPtr, FfiConverterTypeTreeParentId.INSTANCE.Lower(parent), ref _status);
		})));
	}

	public TreeId CreateAt(TreeParentId parent, uint index)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeTreeID.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_create_at(thisPtr, FfiConverterTypeTreeParentId.INSTANCE.Lower(parent), FfiConverterUInt32.INSTANCE.Lower(index), ref _status);
		})));
	}

	public void Delete(TreeId target)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotree_delete(thisPtr, FfiConverterTypeTreeID.INSTANCE.Lower(target), ref _status);
			});
		});
	}

	public void DisableFractionalIndex()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotree_disable_fractional_index(thisPtr, ref _status);
			});
		});
	}

	public LoroDoc? Doc()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroDoc.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_doc(thisPtr, ref _status);
		})));
	}

	public void EnableFractionalIndex(byte jitter)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotree_enable_fractional_index(thisPtr, FfiConverterUInt8.INSTANCE.Lower(jitter), ref _status);
			});
		});
	}

	public string? FractionalIndex(TreeId target)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalString.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_fractional_index(thisPtr, FfiConverterTypeTreeID.INSTANCE.Lower(target), ref _status);
		})));
	}

	public LoroTree? GetAttached()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroTree.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_get_attached(thisPtr, ref _status);
		})));
	}

	public Id? GetLastMoveId(TreeId target)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeID.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_get_last_move_id(thisPtr, FfiConverterTypeTreeID.INSTANCE.Lower(target), ref _status);
		})));
	}

	public LoroMap GetMeta(TreeId target)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroMap.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_get_meta(thisPtr, FfiConverterTypeTreeID.INSTANCE.Lower(target), ref _status);
		})));
	}

	public LoroValue GetValue()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_get_value(thisPtr, ref _status);
		})));
	}

	public LoroValue GetValueWithMeta()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_get_value_with_meta(thisPtr, ref _status);
		})));
	}

	public ContainerId Id()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeContainerID.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_id(thisPtr, ref _status);
		})));
	}

	public bool IsAttached()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_is_attached(thisPtr, ref _status);
		})));
	}

	public bool IsDeleted()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_is_deleted(thisPtr, ref _status);
		})));
	}

	public bool IsFractionalIndexEnabled()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_is_fractional_index_enabled(thisPtr, ref _status);
		})));
	}

	public bool IsNodeDeleted(TreeId target)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_is_node_deleted(thisPtr, FfiConverterTypeTreeID.INSTANCE.Lower(target), ref _status);
		})));
	}

	public void Mov(TreeId target, TreeParentId parent)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotree_mov(thisPtr, FfiConverterTypeTreeID.INSTANCE.Lower(target), FfiConverterTypeTreeParentId.INSTANCE.Lower(parent), ref _status);
			});
		});
	}

	public void MovAfter(TreeId target, TreeId after)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotree_mov_after(thisPtr, FfiConverterTypeTreeID.INSTANCE.Lower(target), FfiConverterTypeTreeID.INSTANCE.Lower(after), ref _status);
			});
		});
	}

	public void MovBefore(TreeId target, TreeId before)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotree_mov_before(thisPtr, FfiConverterTypeTreeID.INSTANCE.Lower(target), FfiConverterTypeTreeID.INSTANCE.Lower(before), ref _status);
			});
		});
	}

	public void MovTo(TreeId target, TreeParentId parent, uint to)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorotree_mov_to(thisPtr, FfiConverterTypeTreeID.INSTANCE.Lower(target), FfiConverterTypeTreeParentId.INSTANCE.Lower(parent), FfiConverterUInt32.INSTANCE.Lower(to), ref _status);
			});
		});
	}

	public List<TreeId> Nodes()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceTypeTreeID.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_nodes(thisPtr, ref _status);
		})));
	}

	public TreeParentId Parent(TreeId target)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeTreeParentId.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_parent(thisPtr, FfiConverterTypeTreeID.INSTANCE.Lower(target), ref _status);
		})));
	}

	public List<TreeId> Roots()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceTypeTreeID.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_roots(thisPtr, ref _status);
		})));
	}

	public Subscription? Subscribe(Subscriber subscriber)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeSubscription.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorotree_subscribe(thisPtr, FfiConverterTypeSubscriber.INSTANCE.Lower(subscriber), ref _status);
		})));
	}
}
