using System;
using System.Collections.Generic;
using System.Threading;

namespace Pro.Loro;

public class LoroDoc : ILoroDoc, IDisposable
{
	protected IntPtr pointer;

	private int _wasDestroyed;

	private long _callCounter = 1L;

	public LoroDoc(IntPtr pointer)
	{
		this.pointer = pointer;
	}

	~LoroDoc()
	{
		Destroy();
	}

	public LoroDoc()
		: this(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_constructor_lorodoc_new(ref _status);
		}))
	{
	}

	protected void FreeRustArcPtr()
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.uniffi_loro_ffi_fn_free_lorodoc(pointer, ref status);
		});
	}

	protected IntPtr CloneRustArcPtr()
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_clone_lorodoc(pointer, ref status);
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

	public void ApplyDiff(DiffBatch diff)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_apply_diff(thisPtr, FfiConverterTypeDiffBatch.INSTANCE.Lower(diff), ref _status);
			});
		});
	}

	public void Attach()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_attach(thisPtr, ref _status);
			});
		});
	}

	public void CheckStateCorrectnessSlow()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_check_state_correctness_slow(thisPtr, ref _status);
			});
		});
	}

	public void Checkout(Frontiers frontiers)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_checkout(thisPtr, FfiConverterTypeFrontiers.INSTANCE.Lower(frontiers), ref _status);
			});
		});
	}

	public void CheckoutToLatest()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_checkout_to_latest(thisPtr, ref _status);
			});
		});
	}

	public void ClearNextCommitOptions()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_clear_next_commit_options(thisPtr, ref _status);
			});
		});
	}

	public Ordering CmpWithFrontiers(Frontiers other)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeOrdering.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_cmp_with_frontiers(thisPtr, FfiConverterTypeFrontiers.INSTANCE.Lower(other), ref _status);
		})));
	}

	public void Commit()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_commit(thisPtr, ref _status);
			});
		});
	}

	public void CommitWith(CommitOptions options)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_commit_with(thisPtr, FfiConverterTypeCommitOptions.INSTANCE.Lower(options), ref _status);
			});
		});
	}

	public void CompactChangeStore()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_compact_change_store(thisPtr, ref _status);
			});
		});
	}

	public Configure Config()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeConfigure.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_config(thisPtr, ref _status);
		})));
	}

	public void ConfigDefaultTextStyle(StyleConfig? textStyle)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_config_default_text_style(thisPtr, FfiConverterOptionalTypeStyleConfig.INSTANCE.Lower(textStyle), ref _status);
			});
		});
	}

	public void ConfigTextStyle(StyleConfigMap textStyle)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_config_text_style(thisPtr, FfiConverterTypeStyleConfigMap.INSTANCE.Lower(textStyle), ref _status);
			});
		});
	}

	public void DeleteRootContainer(ContainerId cid)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_delete_root_container(thisPtr, FfiConverterTypeContainerID.INSTANCE.Lower(cid), ref _status);
			});
		});
	}

	public void Detach()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_detach(thisPtr, ref _status);
			});
		});
	}

	public DiffBatch Diff(Frontiers a, Frontiers b)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeDiffBatch.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_diff(thisPtr, FfiConverterTypeFrontiers.INSTANCE.Lower(a), FfiConverterTypeFrontiers.INSTANCE.Lower(b), ref _status);
		})));
	}

	public List<string> ExportJsonInIdSpan(IdSpan idSpan)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceString.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_export_json_in_id_span(thisPtr, FfiConverterTypeIdSpan.INSTANCE.Lower(idSpan), ref _status);
		})));
	}

	public string ExportJsonUpdates(VersionVector startVv, VersionVector endVv)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterString.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_export_json_updates(thisPtr, FfiConverterTypeVersionVector.INSTANCE.Lower(startVv), FfiConverterTypeVersionVector.INSTANCE.Lower(endVv), ref _status);
		})));
	}

	public string ExportJsonUpdatesWithoutPeerCompression(VersionVector startVv, VersionVector endVv)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterString.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_export_json_updates_without_peer_compression(thisPtr, FfiConverterTypeVersionVector.INSTANCE.Lower(startVv), FfiConverterTypeVersionVector.INSTANCE.Lower(endVv), ref _status);
		})));
	}

	public byte[] ExportShallowSnapshot(Frontiers frontiers)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterByteArray.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroEncodeError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_export_shallow_snapshot(thisPtr, FfiConverterTypeFrontiers.INSTANCE.Lower(frontiers), ref _status);
		})));
	}

	public byte[] ExportSnapshot()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterByteArray.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroEncodeError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_export_snapshot(thisPtr, ref _status);
		})));
	}

	public byte[] ExportSnapshotAt(Frontiers frontiers)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterByteArray.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroEncodeError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_export_snapshot_at(thisPtr, FfiConverterTypeFrontiers.INSTANCE.Lower(frontiers), ref _status);
		})));
	}

	public byte[] ExportStateOnly(Frontiers? frontiers)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterByteArray.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroEncodeError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_export_state_only(thisPtr, FfiConverterOptionalTypeFrontiers.INSTANCE.Lower(frontiers), ref _status);
		})));
	}

	public byte[] ExportUpdates(VersionVector vv)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterByteArray.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroEncodeError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_export_updates(thisPtr, FfiConverterTypeVersionVector.INSTANCE.Lower(vv), ref _status);
		})));
	}

	public byte[] ExportUpdatesInRange(List<IdSpan> spans)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterByteArray.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroEncodeError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_export_updates_in_range(thisPtr, FfiConverterSequenceTypeIdSpan.INSTANCE.Lower(spans), ref _status);
		})));
	}

	public VersionVectorDiff FindIdSpansBetween(Frontiers from, Frontiers to)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeVersionVectorDiff.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_find_id_spans_between(thisPtr, FfiConverterTypeFrontiers.INSTANCE.Lower(from), FfiConverterTypeFrontiers.INSTANCE.Lower(to), ref _status);
		})));
	}

	public LoroDoc Fork()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroDoc.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_fork(thisPtr, ref _status);
		})));
	}

	public LoroDoc ForkAt(Frontiers frontiers)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroDoc.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_fork_at(thisPtr, FfiConverterTypeFrontiers.INSTANCE.Lower(frontiers), ref _status);
		})));
	}

	public void FreeDiffCalculator()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_free_diff_calculator(thisPtr, ref _status);
			});
		});
	}

	public void FreeHistoryCache()
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_free_history_cache(thisPtr, ref _status);
			});
		});
	}

	public VersionVector? FrontiersToVv(Frontiers frontiers)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeVersionVector.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_frontiers_to_vv(thisPtr, FfiConverterTypeFrontiers.INSTANCE.Lower(frontiers), ref _status);
		})));
	}

	public ValueOrContainer? GetByPath(List<Index> path)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeValueOrContainer.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_by_path(thisPtr, FfiConverterSequenceTypeIndex.INSTANCE.Lower(path), ref _status);
		})));
	}

	public ValueOrContainer? GetByStrPath(string path)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeValueOrContainer.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_by_str_path(thisPtr, FfiConverterString.INSTANCE.Lower(path), ref _status);
		})));
	}

	public ChangeMeta? GetChange(Id id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeChangeMeta.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_change(thisPtr, FfiConverterTypeID.INSTANCE.Lower(id), ref _status);
		})));
	}

	public List<ContainerId> GetChangedContainersIn(Id id, uint len)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceTypeContainerID.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_changed_containers_in(thisPtr, FfiConverterTypeID.INSTANCE.Lower(id), FfiConverterUInt32.INSTANCE.Lower(len), ref _status);
		})));
	}

	public ValueOrContainer? GetContainer(ContainerId id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeValueOrContainer.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_container(thisPtr, FfiConverterTypeContainerID.INSTANCE.Lower(id), ref _status);
		})));
	}

	public LoroCounter GetCounter(ContainerIdLike id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroCounter.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_counter(thisPtr, FfiConverterTypeContainerIdLike.INSTANCE.Lower(id), ref _status);
		})));
	}

	public PosQueryResult GetCursorPos(Cursor cursor)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypePosQueryResult.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeCannotFindRelativePosition.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_cursor_pos(thisPtr, FfiConverterTypeCursor.INSTANCE.Lower(cursor), ref _status);
		})));
	}

	public LoroValue GetDeepValue()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_deep_value(thisPtr, ref _status);
		})));
	}

	public LoroValue GetDeepValueWithId()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_deep_value_with_id(thisPtr, ref _status);
		})));
	}

	public LoroList GetList(ContainerIdLike id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroList.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_list(thisPtr, FfiConverterTypeContainerIdLike.INSTANCE.Lower(id), ref _status);
		})));
	}

	public LoroMap GetMap(ContainerIdLike id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroMap.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_map(thisPtr, FfiConverterTypeContainerIdLike.INSTANCE.Lower(id), ref _status);
		})));
	}

	public LoroMovableList GetMovableList(ContainerIdLike id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroMovableList.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_movable_list(thisPtr, FfiConverterTypeContainerIdLike.INSTANCE.Lower(id), ref _status);
		})));
	}

	public List<ContainerPath>? GetPathToContainer(ContainerId id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalSequenceTypeContainerPath.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_path_to_container(thisPtr, FfiConverterTypeContainerID.INSTANCE.Lower(id), ref _status);
		})));
	}

	public uint GetPendingTxnLen()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt32.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_pending_txn_len(thisPtr, ref _status);
		})));
	}

	public LoroText GetText(ContainerIdLike id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroText.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_text(thisPtr, FfiConverterTypeContainerIdLike.INSTANCE.Lower(id), ref _status);
		})));
	}

	public LoroTree GetTree(ContainerIdLike id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroTree.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_tree(thisPtr, FfiConverterTypeContainerIdLike.INSTANCE.Lower(id), ref _status);
		})));
	}

	public LoroValue GetValue()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_get_value(thisPtr, ref _status);
		})));
	}

	public bool HasContainer(ContainerId id)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_has_container(thisPtr, FfiConverterTypeContainerID.INSTANCE.Lower(id), ref _status);
		})));
	}

	public bool HasHistoryCache()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_has_history_cache(thisPtr, ref _status);
		})));
	}

	public ImportStatus Import(byte[] bytes)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeImportStatus.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_import(thisPtr, FfiConverterByteArray.INSTANCE.Lower(bytes), ref _status);
		})));
	}

	public ImportStatus ImportBatch(List<byte[]> bytes)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeImportStatus.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_import_batch(thisPtr, FfiConverterSequenceByteArray.INSTANCE.Lower(bytes), ref _status);
		})));
	}

	public ImportStatus ImportJsonUpdates(string json)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeImportStatus.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_import_json_updates(thisPtr, FfiConverterString.INSTANCE.Lower(json), ref _status);
		})));
	}

	public ImportStatus ImportWith(byte[] bytes, string origin)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeImportStatus.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_import_with(thisPtr, FfiConverterByteArray.INSTANCE.Lower(bytes), FfiConverterString.INSTANCE.Lower(origin), ref _status);
		})));
	}

	public bool IsDetached()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_is_detached(thisPtr, ref _status);
		})));
	}

	public bool IsShallow()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_is_shallow(thisPtr, ref _status);
		})));
	}

	public List<ValueOrContainer> Jsonpath(string path)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterSequenceTypeValueOrContainer.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeJsonPathError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_jsonpath(thisPtr, FfiConverterString.INSTANCE.Lower(path), ref _status);
		})));
	}

	public ulong LenChanges()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt64.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_len_changes(thisPtr, ref _status);
		})));
	}

	public ulong LenOps()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt64.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_len_ops(thisPtr, ref _status);
		})));
	}

	public FrontiersOrId MinimizeFrontiers(Frontiers frontiers)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeFrontiersOrID.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_minimize_frontiers(thisPtr, FfiConverterTypeFrontiers.INSTANCE.Lower(frontiers), ref _status);
		})));
	}

	public Frontiers OplogFrontiers()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeFrontiers.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_oplog_frontiers(thisPtr, ref _status);
		})));
	}

	public VersionVector OplogVv()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeVersionVector.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_oplog_vv(thisPtr, ref _status);
		})));
	}

	public ulong PeerId()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterUInt64.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_peer_id(thisPtr, ref _status);
		})));
	}

	public string RedactJsonUpdates(string json, VersionRange versionRange)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterString.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_redact_json_updates(thisPtr, FfiConverterString.INSTANCE.Lower(json), FfiConverterTypeVersionRange.INSTANCE.Lower(versionRange), ref _status);
		})));
	}

	public void RevertTo(Frontiers version)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_revert_to(thisPtr, FfiConverterTypeFrontiers.INSTANCE.Lower(version), ref _status);
			});
		});
	}

	public void SetChangeMergeInterval(long interval)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_set_change_merge_interval(thisPtr, FfiConverterInt64.INSTANCE.Lower(interval), ref _status);
			});
		});
	}

	public void SetHideEmptyRootContainers(bool hide)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_set_hide_empty_root_containers(thisPtr, FfiConverterBoolean.INSTANCE.Lower(hide), ref _status);
			});
		});
	}

	public void SetNextCommitMessage(string msg)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_set_next_commit_message(thisPtr, FfiConverterString.INSTANCE.Lower(msg), ref _status);
			});
		});
	}

	public void SetNextCommitOptions(CommitOptions options)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_set_next_commit_options(thisPtr, FfiConverterTypeCommitOptions.INSTANCE.Lower(options), ref _status);
			});
		});
	}

	public void SetNextCommitOrigin(string origin)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_set_next_commit_origin(thisPtr, FfiConverterString.INSTANCE.Lower(origin), ref _status);
			});
		});
	}

	public void SetNextCommitTimestamp(long timestamp)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_set_next_commit_timestamp(thisPtr, FfiConverterInt64.INSTANCE.Lower(timestamp), ref _status);
			});
		});
	}

	public void SetPeerId(ulong peer)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_set_peer_id(thisPtr, FfiConverterUInt64.INSTANCE.Lower(peer), ref _status);
			});
		});
	}

	public void SetRecordTimestamp(bool record)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_set_record_timestamp(thisPtr, FfiConverterBoolean.INSTANCE.Lower(record), ref _status);
			});
		});
	}

	public VersionVector ShallowSinceVv()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeVersionVector.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_shallow_since_vv(thisPtr, ref _status);
		})));
	}

	public Frontiers StateFrontiers()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeFrontiers.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_state_frontiers(thisPtr, ref _status);
		})));
	}

	public VersionVector StateVv()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeVersionVector.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_state_vv(thisPtr, ref _status);
		})));
	}

	public Subscription Subscribe(ContainerId containerId, Subscriber subscriber)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeSubscription.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_subscribe(thisPtr, FfiConverterTypeContainerID.INSTANCE.Lower(containerId), FfiConverterTypeSubscriber.INSTANCE.Lower(subscriber), ref _status);
		})));
	}

	public Subscription SubscribeFirstCommitFromPeer(FirstCommitFromPeerCallback callback)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeSubscription.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_subscribe_first_commit_from_peer(thisPtr, FfiConverterTypeFirstCommitFromPeerCallback.INSTANCE.Lower(callback), ref _status);
		})));
	}

	public Subscription SubscribeJsonpath(string path, JsonPathSubscriber callback)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeSubscription.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_subscribe_jsonpath(thisPtr, FfiConverterString.INSTANCE.Lower(path), FfiConverterTypeJsonPathSubscriber.INSTANCE.Lower(callback), ref _status);
		})));
	}

	public Subscription SubscribeLocalUpdate(LocalUpdateCallback callback)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeSubscription.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_subscribe_local_update(thisPtr, FfiConverterTypeLocalUpdateCallback.INSTANCE.Lower(callback), ref _status);
		})));
	}

	public Subscription SubscribePreCommit(PreCommitCallback callback)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeSubscription.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_subscribe_pre_commit(thisPtr, FfiConverterTypePreCommitCallback.INSTANCE.Lower(callback), ref _status);
		})));
	}

	public Subscription SubscribeRoot(Subscriber subscriber)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeSubscription.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_subscribe_root(thisPtr, FfiConverterTypeSubscriber.INSTANCE.Lower(subscriber), ref _status);
		})));
	}

	public void TravelChangeAncestors(List<Id> ids, ChangeAncestorsTraveler f)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCallWithError(FfiConverterTypeChangeTravelError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_travel_change_ancestors(thisPtr, FfiConverterSequenceTypeID.INSTANCE.Lower(ids), FfiConverterTypeChangeAncestorsTraveler.INSTANCE.Lower(f), ref _status);
			});
		});
	}

	public Frontiers VvToFrontiers(VersionVector vv)
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterTypeFrontiers.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_lorodoc_vv_to_frontiers(thisPtr, FfiConverterTypeVersionVector.INSTANCE.Lower(vv), ref _status);
		})));
	}
}
