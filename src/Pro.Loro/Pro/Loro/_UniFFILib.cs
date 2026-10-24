using System;
using System.Runtime.InteropServices;

namespace Pro.Loro;

internal static class _UniFFILib
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiRustFutureContinuationCallback(ulong data, sbyte pollResult);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureFree(ulong handle);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceFree(ulong handle);

	public struct UniffiForeignFuture
	{
		public ulong handle;

		public IntPtr free;
	}

	public struct UniffiForeignFutureStructU8
	{
		public byte returnValue;

		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompleteU8(ulong callbackData, UniffiForeignFutureStructU8 result);

	public struct UniffiForeignFutureStructI8
	{
		public sbyte returnValue;

		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompleteI8(ulong callbackData, UniffiForeignFutureStructI8 result);

	public struct UniffiForeignFutureStructU16
	{
		public ushort returnValue;

		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompleteU16(ulong callbackData, UniffiForeignFutureStructU16 result);

	public struct UniffiForeignFutureStructI16
	{
		public short returnValue;

		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompleteI16(ulong callbackData, UniffiForeignFutureStructI16 result);

	public struct UniffiForeignFutureStructU32
	{
		public uint returnValue;

		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompleteU32(ulong callbackData, UniffiForeignFutureStructU32 result);

	public struct UniffiForeignFutureStructI32
	{
		public int returnValue;

		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompleteI32(ulong callbackData, UniffiForeignFutureStructI32 result);

	public struct UniffiForeignFutureStructU64
	{
		public ulong returnValue;

		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompleteU64(ulong callbackData, UniffiForeignFutureStructU64 result);

	public struct UniffiForeignFutureStructI64
	{
		public long returnValue;

		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompleteI64(ulong callbackData, UniffiForeignFutureStructI64 result);

	public struct UniffiForeignFutureStructF32
	{
		public float returnValue;

		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompleteF32(ulong callbackData, UniffiForeignFutureStructF32 result);

	public struct UniffiForeignFutureStructF64
	{
		public double returnValue;

		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompleteF64(ulong callbackData, UniffiForeignFutureStructF64 result);

	public struct UniffiForeignFutureStructPointer
	{
		public IntPtr returnValue;

		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompletePointer(ulong callbackData, UniffiForeignFutureStructPointer result);

	public struct UniffiForeignFutureStructRustBuffer
	{
		public RustBuffer returnValue;

		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompleteRustBuffer(ulong callbackData, UniffiForeignFutureStructRustBuffer result);

	public struct UniffiForeignFutureStructVoid
	{
		public UniffiRustCallStatus callStatus;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiForeignFutureCompleteVoid(ulong callbackData, UniffiForeignFutureStructVoid result);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceChangeAncestorsTravelerMethod0(ulong uniffiHandle, RustBuffer change, ref sbyte uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceContainerIdLikeMethod0(ulong uniffiHandle, RustBuffer ty, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceEphemeralSubscriberMethod0(ulong uniffiHandle, RustBuffer @event, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceFirstCommitFromPeerCallbackMethod0(ulong uniffiHandle, RustBuffer payload, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceJsonPathSubscriberMethod0(ulong uniffiHandle, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceLocalEphemeralListenerMethod0(ulong uniffiHandle, RustBuffer update, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceLocalUpdateCallbackMethod0(ulong uniffiHandle, RustBuffer update, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceLoroValueLikeMethod0(ulong uniffiHandle, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceOnPopMethod0(ulong uniffiHandle, RustBuffer undoOrRedo, RustBuffer span, RustBuffer undoMeta, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceOnPushMethod0(ulong uniffiHandle, RustBuffer undoOrRedo, RustBuffer span, RustBuffer diffEvent, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfacePreCommitCallbackMethod0(ulong uniffiHandle, RustBuffer payload, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceSubscriberMethod0(ulong uniffiHandle, RustBuffer diff, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceUnsubscriberMethod0(ulong uniffiHandle, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceValueOrContainerMethod0(ulong uniffiHandle, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceValueOrContainerMethod1(ulong uniffiHandle, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceValueOrContainerMethod2(ulong uniffiHandle, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceValueOrContainerMethod3(ulong uniffiHandle, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceValueOrContainerMethod4(ulong uniffiHandle, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceValueOrContainerMethod5(ulong uniffiHandle, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceValueOrContainerMethod6(ulong uniffiHandle, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceValueOrContainerMethod7(ulong uniffiHandle, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceValueOrContainerMethod8(ulong uniffiHandle, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceValueOrContainerMethod9(ulong uniffiHandle, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceValueOrContainerMethod10(ulong uniffiHandle, ref sbyte uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UniffiCallbackInterfaceValueOrContainerMethod11(ulong uniffiHandle, ref sbyte uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err);

	public struct UniffiVTableCallbackInterfaceChangeAncestorsTraveler
	{
		public IntPtr travel;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfaceContainerIdLike
	{
		public IntPtr asContainerId;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfaceEphemeralSubscriber
	{
		public IntPtr onEphemeralEvent;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfaceFirstCommitFromPeerCallback
	{
		public IntPtr onFirstCommitFromPeer;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfaceJsonPathSubscriber
	{
		public IntPtr onJsonpathChanged;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfaceLocalEphemeralListener
	{
		public IntPtr onEphemeralUpdate;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfaceLocalUpdateCallback
	{
		public IntPtr onLocalUpdate;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfaceLoroValueLike
	{
		public IntPtr asLoroValue;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfaceOnPop
	{
		public IntPtr onPop;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfaceOnPush
	{
		public IntPtr onPush;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfacePreCommitCallback
	{
		public IntPtr onPreCommit;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfaceSubscriber
	{
		public IntPtr onDiff;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfaceUnsubscriber
	{
		public IntPtr onUnsubscribe;

		public IntPtr uniffiFree;
	}

	public struct UniffiVTableCallbackInterfaceValueOrContainer
	{
		public IntPtr asContainer;

		public IntPtr asLoroCounter;

		public IntPtr asLoroList;

		public IntPtr asLoroMap;

		public IntPtr asLoroMovableList;

		public IntPtr asLoroText;

		public IntPtr asLoroTree;

		public IntPtr asLoroUnknown;

		public IntPtr asValue;

		public IntPtr containerType;

		public IntPtr isContainer;

		public IntPtr isValue;

		public IntPtr uniffiFree;
	}

	static _UniFFILib()
	{
		uniffiCheckContractApiVersion();
		uniffiCheckApiChecksums();
		UniffiCallbackInterfaceChangeAncestorsTraveler.Register();
		UniffiCallbackInterfaceContainerIdLike.Register();
		UniffiCallbackInterfaceEphemeralSubscriber.Register();
		UniffiCallbackInterfaceFirstCommitFromPeerCallback.Register();
		UniffiCallbackInterfaceJsonPathSubscriber.Register();
		UniffiCallbackInterfaceLocalEphemeralListener.Register();
		UniffiCallbackInterfaceLocalUpdateCallback.Register();
		UniffiCallbackInterfaceLoroValueLike.Register();
		UniffiCallbackInterfaceOnPop.Register();
		UniffiCallbackInterfaceOnPush.Register();
		UniffiCallbackInterfacePreCommitCallback.Register();
		UniffiCallbackInterfaceSubscriber.Register();
		UniffiCallbackInterfaceUnsubscriber.Register();
	}

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_awareness(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_awareness(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_awareness_new(ulong peer, long timeout, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_awareness_apply(IntPtr ptr, RustBuffer encodedPeersInfo, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_awareness_encode(IntPtr ptr, RustBuffer peers, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_awareness_encode_all(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_awareness_get_all_states(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_awareness_get_local_state(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ulong uniffi_loro_ffi_fn_method_awareness_peer(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_awareness_remove_outdated(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_awareness_set_local_state(IntPtr ptr, IntPtr value, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_changeancestorstraveler(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_changeancestorstraveler(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_changeancestorstraveler(ref UniffiVTableCallbackInterfaceChangeAncestorsTraveler vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_changeancestorstraveler_travel(IntPtr ptr, RustBuffer change, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_changemodifier(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_changemodifier(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_changemodifier_set_message(IntPtr ptr, RustBuffer msg, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_changemodifier_set_timestamp(IntPtr ptr, long timestamp, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_configure(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_configure(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_configure_fork(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern long uniffi_loro_ffi_fn_method_configure_merge_interval(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_configure_record_timestamp(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_configure_set_merge_interval(IntPtr ptr, long interval, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_configure_set_record_timestamp(IntPtr ptr, sbyte record, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_configure_text_style_config(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_containeridlike(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_containeridlike(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_containeridlike(ref UniffiVTableCallbackInterfaceContainerIdLike vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_containeridlike_as_container_id(IntPtr ptr, RustBuffer ty, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_cursor(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_cursor(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_cursor_decode(RustBuffer data, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_cursor_new(RustBuffer id, RustBuffer container, RustBuffer side, uint originPos, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_cursor_encode(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_diffbatch(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_diffbatch(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_diffbatch_new(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_diffbatch_get_diff(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_diffbatch_push(IntPtr ptr, RustBuffer cid, RustBuffer diff, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_ephemeralstore(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_ephemeralstore(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_ephemeralstore_new(long timeout, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_ephemeralstore_apply(IntPtr ptr, RustBuffer data, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_ephemeralstore_delete(IntPtr ptr, RustBuffer key, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_ephemeralstore_encode(IntPtr ptr, RustBuffer key, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_ephemeralstore_encode_all(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_ephemeralstore_get(IntPtr ptr, RustBuffer key, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_ephemeralstore_get_all_states(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_ephemeralstore_keys(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_ephemeralstore_remove_outdated(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_ephemeralstore_set(IntPtr ptr, RustBuffer key, IntPtr value, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_ephemeralstore_subscribe(IntPtr ptr, IntPtr listener, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_ephemeralstore_subscribe_local_update(IntPtr ptr, IntPtr listener, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_ephemeralsubscriber(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_ephemeralsubscriber(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_ephemeralsubscriber(ref UniffiVTableCallbackInterfaceEphemeralSubscriber vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_ephemeralsubscriber_on_ephemeral_event(IntPtr ptr, RustBuffer @event, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_firstcommitfrompeercallback(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_firstcommitfrompeercallback(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_firstcommitfrompeercallback(ref UniffiVTableCallbackInterfaceFirstCommitFromPeerCallback vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_firstcommitfrompeercallback_on_first_commit_from_peer(IntPtr ptr, RustBuffer payload, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_fractionalindex(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_fractionalindex(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_fractionalindex_from_bytes(RustBuffer bytes, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_fractionalindex_from_hex_string(RustBuffer str, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_fractionalindex_uniffi_trait_display(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_frontiers(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_frontiers(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_frontiers_decode(RustBuffer bytes, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_frontiers_from_id(RustBuffer id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_frontiers_from_ids(RustBuffer ids, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_frontiers_new(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_frontiers_encode(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_frontiers_eq(IntPtr ptr, IntPtr other, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_frontiers_is_empty(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_frontiers_to_vec(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_jsonpathsubscriber(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_jsonpathsubscriber(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_jsonpathsubscriber(ref UniffiVTableCallbackInterfaceJsonPathSubscriber vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_jsonpathsubscriber_on_jsonpath_changed(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_localephemerallistener(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_localephemerallistener(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_localephemerallistener(ref UniffiVTableCallbackInterfaceLocalEphemeralListener vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_localephemerallistener_on_ephemeral_update(IntPtr ptr, RustBuffer update, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_localupdatecallback(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_localupdatecallback(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_localupdatecallback(ref UniffiVTableCallbackInterfaceLocalUpdateCallback vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_localupdatecallback_on_local_update(IntPtr ptr, RustBuffer update, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_lorocounter(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_lorocounter(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_lorocounter_new(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorocounter_decrement(IntPtr ptr, double value, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorocounter_doc(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorocounter_get_attached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern double uniffi_loro_ffi_fn_method_lorocounter_get_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorocounter_id(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorocounter_increment(IntPtr ptr, double value, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorocounter_is_attached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorocounter_is_deleted(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorocounter_subscribe(IntPtr ptr, IntPtr subscriber, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_lorodoc(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_lorodoc(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_lorodoc_new(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_apply_diff(IntPtr ptr, IntPtr diff, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_attach(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_check_state_correctness_slow(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_checkout(IntPtr ptr, IntPtr frontiers, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_checkout_to_latest(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_clear_next_commit_options(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_cmp_with_frontiers(IntPtr ptr, IntPtr other, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_commit(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_commit_with(IntPtr ptr, RustBuffer options, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_compact_change_store(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_config(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_config_default_text_style(IntPtr ptr, RustBuffer textStyle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_config_text_style(IntPtr ptr, IntPtr textStyle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_delete_root_container(IntPtr ptr, RustBuffer cid, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_detach(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_diff(IntPtr ptr, IntPtr a, IntPtr b, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_export_json_in_id_span(IntPtr ptr, RustBuffer idSpan, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_export_json_updates(IntPtr ptr, IntPtr startVv, IntPtr endVv, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_export_json_updates_without_peer_compression(IntPtr ptr, IntPtr startVv, IntPtr endVv, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_export_shallow_snapshot(IntPtr ptr, IntPtr frontiers, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_export_snapshot(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_export_snapshot_at(IntPtr ptr, IntPtr frontiers, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_export_state_only(IntPtr ptr, RustBuffer frontiers, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_export_updates(IntPtr ptr, IntPtr vv, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_export_updates_in_range(IntPtr ptr, RustBuffer spans, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_find_id_spans_between(IntPtr ptr, IntPtr from, IntPtr to, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_fork(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_fork_at(IntPtr ptr, IntPtr frontiers, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_free_diff_calculator(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_free_history_cache(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_frontiers_to_vv(IntPtr ptr, IntPtr frontiers, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_get_by_path(IntPtr ptr, RustBuffer path, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_get_by_str_path(IntPtr ptr, RustBuffer path, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_get_change(IntPtr ptr, RustBuffer id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_get_changed_containers_in(IntPtr ptr, RustBuffer id, uint len, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_get_container(IntPtr ptr, RustBuffer id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_get_counter(IntPtr ptr, IntPtr id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_get_cursor_pos(IntPtr ptr, IntPtr cursor, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_get_deep_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_get_deep_value_with_id(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_get_list(IntPtr ptr, IntPtr id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_get_map(IntPtr ptr, IntPtr id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_get_movable_list(IntPtr ptr, IntPtr id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_get_path_to_container(IntPtr ptr, RustBuffer id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint uniffi_loro_ffi_fn_method_lorodoc_get_pending_txn_len(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_get_text(IntPtr ptr, IntPtr id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_get_tree(IntPtr ptr, IntPtr id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_get_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorodoc_has_container(IntPtr ptr, RustBuffer id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorodoc_has_history_cache(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_import(IntPtr ptr, RustBuffer bytes, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_import_batch(IntPtr ptr, RustBuffer bytes, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_import_json_updates(IntPtr ptr, RustBuffer json, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_import_with(IntPtr ptr, RustBuffer bytes, RustBuffer origin, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorodoc_is_detached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorodoc_is_shallow(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_jsonpath(IntPtr ptr, RustBuffer path, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ulong uniffi_loro_ffi_fn_method_lorodoc_len_changes(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ulong uniffi_loro_ffi_fn_method_lorodoc_len_ops(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_minimize_frontiers(IntPtr ptr, IntPtr frontiers, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_oplog_frontiers(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_oplog_vv(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ulong uniffi_loro_ffi_fn_method_lorodoc_peer_id(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorodoc_redact_json_updates(IntPtr ptr, RustBuffer json, IntPtr versionRange, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_revert_to(IntPtr ptr, IntPtr version, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_set_change_merge_interval(IntPtr ptr, long interval, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_set_hide_empty_root_containers(IntPtr ptr, sbyte hide, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_set_next_commit_message(IntPtr ptr, RustBuffer msg, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_set_next_commit_options(IntPtr ptr, RustBuffer options, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_set_next_commit_origin(IntPtr ptr, RustBuffer origin, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_set_next_commit_timestamp(IntPtr ptr, long timestamp, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_set_peer_id(IntPtr ptr, ulong peer, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_set_record_timestamp(IntPtr ptr, sbyte record, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_shallow_since_vv(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_state_frontiers(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_state_vv(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_subscribe(IntPtr ptr, RustBuffer containerId, IntPtr subscriber, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_subscribe_first_commit_from_peer(IntPtr ptr, IntPtr callback, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_subscribe_jsonpath(IntPtr ptr, RustBuffer path, IntPtr callback, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_subscribe_local_update(IntPtr ptr, IntPtr callback, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_subscribe_pre_commit(IntPtr ptr, IntPtr callback, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_subscribe_root(IntPtr ptr, IntPtr subscriber, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorodoc_travel_change_ancestors(IntPtr ptr, RustBuffer ids, IntPtr f, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorodoc_vv_to_frontiers(IntPtr ptr, IntPtr vv, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_lorolist(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_lorolist(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_lorolist_new(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorolist_clear(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorolist_delete(IntPtr ptr, uint pos, uint len, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorolist_doc(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorolist_get(IntPtr ptr, uint index, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorolist_get_attached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorolist_get_cursor(IntPtr ptr, uint pos, RustBuffer side, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorolist_get_deep_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorolist_get_id_at(IntPtr ptr, uint pos, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorolist_get_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorolist_id(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorolist_insert(IntPtr ptr, uint pos, IntPtr v, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorolist_insert_counter_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorolist_insert_list_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorolist_insert_map_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorolist_insert_movable_list_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorolist_insert_text_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorolist_insert_tree_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorolist_is_attached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorolist_is_deleted(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorolist_is_empty(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint uniffi_loro_ffi_fn_method_lorolist_len(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorolist_pop(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorolist_push(IntPtr ptr, IntPtr v, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorolist_subscribe(IntPtr ptr, IntPtr subscriber, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorolist_to_vec(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_loromap(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_loromap(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_loromap_new(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_loromap_clear(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_loromap_delete(IntPtr ptr, RustBuffer key, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromap_doc(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromap_get(IntPtr ptr, RustBuffer key, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromap_get_attached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromap_get_deep_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromap_get_last_editor(IntPtr ptr, RustBuffer key, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromap_get_or_create_counter_container(IntPtr ptr, RustBuffer key, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromap_get_or_create_list_container(IntPtr ptr, RustBuffer key, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromap_get_or_create_map_container(IntPtr ptr, RustBuffer key, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromap_get_or_create_movable_list_container(IntPtr ptr, RustBuffer key, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromap_get_or_create_text_container(IntPtr ptr, RustBuffer key, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromap_get_or_create_tree_container(IntPtr ptr, RustBuffer key, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromap_get_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromap_id(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_loromap_insert(IntPtr ptr, RustBuffer key, IntPtr v, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromap_insert_counter_container(IntPtr ptr, RustBuffer key, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromap_insert_list_container(IntPtr ptr, RustBuffer key, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromap_insert_map_container(IntPtr ptr, RustBuffer key, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromap_insert_movable_list_container(IntPtr ptr, RustBuffer key, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromap_insert_text_container(IntPtr ptr, RustBuffer key, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromap_insert_tree_container(IntPtr ptr, RustBuffer key, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_loromap_is_attached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_loromap_is_deleted(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_loromap_is_empty(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromap_keys(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint uniffi_loro_ffi_fn_method_loromap_len(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromap_subscribe(IntPtr ptr, IntPtr subscriber, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromap_values(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_loromovablelist(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_loromovablelist(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_loromovablelist_new(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_loromovablelist_clear(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_loromovablelist_delete(IntPtr ptr, uint pos, uint len, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_doc(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_get(IntPtr ptr, uint index, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_get_attached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_get_creator_at(IntPtr ptr, uint pos, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_get_cursor(IntPtr ptr, uint pos, RustBuffer side, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_get_deep_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_get_last_editor_at(IntPtr ptr, uint pos, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_get_last_mover_at(IntPtr ptr, uint pos, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_get_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_id(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_loromovablelist_insert(IntPtr ptr, uint pos, IntPtr v, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromovablelist_insert_counter_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromovablelist_insert_list_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromovablelist_insert_map_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromovablelist_insert_movable_list_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromovablelist_insert_text_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromovablelist_insert_tree_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_loromovablelist_is_attached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_loromovablelist_is_deleted(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_loromovablelist_is_empty(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint uniffi_loro_ffi_fn_method_loromovablelist_len(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_loromovablelist_mov(IntPtr ptr, uint from, uint to, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_pop(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_loromovablelist_push(IntPtr ptr, IntPtr v, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_loromovablelist_set(IntPtr ptr, uint pos, IntPtr value, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromovablelist_set_counter_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromovablelist_set_list_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromovablelist_set_map_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromovablelist_set_movable_list_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromovablelist_set_text_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_loromovablelist_set_tree_container(IntPtr ptr, uint pos, IntPtr child, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_subscribe(IntPtr ptr, IntPtr subscriber, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_loromovablelist_to_vec(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_lorotext(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_lorotext(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_lorotext_new(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_apply_delta(IntPtr ptr, RustBuffer delta, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_char_at(IntPtr ptr, uint pos, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_convert_pos(IntPtr ptr, uint index, RustBuffer from, RustBuffer to, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_delete(IntPtr ptr, uint pos, uint len, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_delete_utf16(IntPtr ptr, uint pos, uint len, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_delete_utf8(IntPtr ptr, uint pos, uint len, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_doc(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_get_attached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_get_cursor(IntPtr ptr, uint pos, RustBuffer side, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_get_editor_at_unicode_pos(IntPtr ptr, uint pos, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_get_richtext_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_id(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_insert(IntPtr ptr, uint pos, RustBuffer s, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_insert_utf16(IntPtr ptr, uint pos, RustBuffer s, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_insert_utf8(IntPtr ptr, uint pos, RustBuffer s, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorotext_is_attached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorotext_is_deleted(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorotext_is_empty(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint uniffi_loro_ffi_fn_method_lorotext_len_unicode(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint uniffi_loro_ffi_fn_method_lorotext_len_utf16(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint uniffi_loro_ffi_fn_method_lorotext_len_utf8(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_mark(IntPtr ptr, uint from, uint to, RustBuffer key, IntPtr value, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_mark_utf16(IntPtr ptr, uint from, uint to, RustBuffer key, IntPtr value, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_mark_utf8(IntPtr ptr, uint from, uint to, RustBuffer key, IntPtr value, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_push_str(IntPtr ptr, RustBuffer s, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_slice(IntPtr ptr, uint startIndex, uint endIndex, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_slice_delta(IntPtr ptr, uint startIndex, uint endIndex, RustBuffer posType, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_slice_utf16(IntPtr ptr, uint startIndex, uint endIndex, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_splice(IntPtr ptr, uint pos, uint len, RustBuffer s, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_splice_utf16(IntPtr ptr, uint pos, uint len, RustBuffer s, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_subscribe(IntPtr ptr, IntPtr subscriber, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_to_delta(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_unmark(IntPtr ptr, uint from, uint to, RustBuffer key, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_unmark_utf16(IntPtr ptr, uint from, uint to, RustBuffer key, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_update(IntPtr ptr, RustBuffer s, RustBuffer options, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotext_update_by_line(IntPtr ptr, RustBuffer s, RustBuffer options, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotext_uniffi_trait_display(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_lorotree(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_lorotree(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_lorotree_new(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_children(IntPtr ptr, RustBuffer parent, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_children_num(IntPtr ptr, RustBuffer parent, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorotree_contains(IntPtr ptr, RustBuffer target, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_create(IntPtr ptr, RustBuffer parent, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_create_at(IntPtr ptr, RustBuffer parent, uint index, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotree_delete(IntPtr ptr, RustBuffer target, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotree_disable_fractional_index(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_doc(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotree_enable_fractional_index(IntPtr ptr, byte jitter, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_fractional_index(IntPtr ptr, RustBuffer target, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_get_attached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_get_last_move_id(IntPtr ptr, RustBuffer target, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_method_lorotree_get_meta(IntPtr ptr, RustBuffer target, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_get_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_get_value_with_meta(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_id(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorotree_is_attached(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorotree_is_deleted(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorotree_is_fractional_index_enabled(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_lorotree_is_node_deleted(IntPtr ptr, RustBuffer target, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotree_mov(IntPtr ptr, RustBuffer target, RustBuffer parent, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotree_mov_after(IntPtr ptr, RustBuffer target, RustBuffer after, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotree_mov_before(IntPtr ptr, RustBuffer target, RustBuffer before, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_lorotree_mov_to(IntPtr ptr, RustBuffer target, RustBuffer parent, uint to, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_nodes(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_parent(IntPtr ptr, RustBuffer target, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_roots(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorotree_subscribe(IntPtr ptr, IntPtr subscriber, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_lorounknown(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_lorounknown(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorounknown_id(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_lorovaluelike(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_lorovaluelike(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_lorovaluelike(ref UniffiVTableCallbackInterfaceLoroValueLike vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_lorovaluelike_as_loro_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_onpop(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_onpop(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_onpop(ref UniffiVTableCallbackInterfaceOnPop vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_onpop_on_pop(IntPtr ptr, RustBuffer undoOrRedo, RustBuffer span, RustBuffer undoMeta, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_onpush(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_onpush(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_onpush(ref UniffiVTableCallbackInterfaceOnPush vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_onpush_on_push(IntPtr ptr, RustBuffer undoOrRedo, RustBuffer span, RustBuffer diffEvent, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_precommitcallback(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_precommitcallback(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_precommitcallback(ref UniffiVTableCallbackInterfacePreCommitCallback vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_precommitcallback_on_pre_commit(IntPtr ptr, RustBuffer payload, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_styleconfigmap(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_styleconfigmap(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_styleconfigmap_default_rich_text_config(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_styleconfigmap_new(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_styleconfigmap_get(IntPtr ptr, RustBuffer key, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_styleconfigmap_insert(IntPtr ptr, RustBuffer key, RustBuffer value, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_subscriber(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_subscriber(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_subscriber(ref UniffiVTableCallbackInterfaceSubscriber vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_subscriber_on_diff(IntPtr ptr, RustBuffer diff, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_subscription(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_subscription(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_subscription_detach(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_subscription_unsubscribe(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_undomanager(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_undomanager(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_undomanager_new(IntPtr doc, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_undomanager_add_exclude_origin_prefix(IntPtr ptr, RustBuffer prefix, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_undomanager_can_redo(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_undomanager_can_undo(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_undomanager_group_end(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_undomanager_group_start(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ulong uniffi_loro_ffi_fn_method_undomanager_peer(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_undomanager_record_new_checkpoint(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_undomanager_redo(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint uniffi_loro_ffi_fn_method_undomanager_redo_count(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_undomanager_set_max_undo_steps(IntPtr ptr, uint size, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_undomanager_set_merge_interval(IntPtr ptr, long interval, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_undomanager_set_on_pop(IntPtr ptr, RustBuffer onPop, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_undomanager_set_on_push(IntPtr ptr, RustBuffer onPush, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_undomanager_top_redo_meta(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_undomanager_top_redo_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_undomanager_top_undo_meta(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_undomanager_top_undo_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_undomanager_undo(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint uniffi_loro_ffi_fn_method_undomanager_undo_count(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_unsubscriber(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_unsubscriber(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_init_callback_vtable_unsubscriber(ref UniffiVTableCallbackInterfaceUnsubscriber vtable);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_unsubscriber_on_unsubscribe(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_valueorcontainer(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_valueorcontainer(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_valueorcontainer_as_container(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_counter(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_list(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_map(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_movable_list(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_text(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_tree(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_unknown(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_valueorcontainer_as_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_valueorcontainer_container_type(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_valueorcontainer_is_container(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_valueorcontainer_is_value(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_versionrange(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_versionrange(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_versionrange_from_vv(IntPtr vv, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_versionrange_new(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_versionrange_clear(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_versionrange_contains_id(IntPtr ptr, RustBuffer id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_versionrange_contains_id_span(IntPtr ptr, RustBuffer span, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_versionrange_contains_ops_between(IntPtr ptr, IntPtr vvA, IntPtr vvB, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_versionrange_extends_to_include_id_span(IntPtr ptr, RustBuffer span, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_versionrange_get(IntPtr ptr, ulong peer, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_versionrange_get_all_ranges(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_versionrange_get_peers(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_versionrange_has_overlap_with(IntPtr ptr, RustBuffer span, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_versionrange_insert(IntPtr ptr, ulong peer, int start, int end, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_versionrange_is_empty(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_clone_versionvector(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_free_versionvector(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_versionvector_decode(RustBuffer bytes, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr uniffi_loro_ffi_fn_constructor_versionvector_new(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_versionvector_diff(IntPtr ptr, IntPtr rhs, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_versionvector_encode(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_versionvector_eq(IntPtr ptr, IntPtr other, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_versionvector_extend_to_include_vv(IntPtr ptr, IntPtr other, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_versionvector_get_last(IntPtr ptr, ulong peer, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_versionvector_get_missing_span(IntPtr ptr, IntPtr target, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_versionvector_includes_id(IntPtr ptr, RustBuffer id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_versionvector_includes_vv(IntPtr ptr, IntPtr other, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_versionvector_intersect_span(IntPtr ptr, RustBuffer target, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_versionvector_merge(IntPtr ptr, IntPtr other, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_versionvector_partial_cmp(IntPtr ptr, IntPtr other, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_versionvector_set_end(IntPtr ptr, RustBuffer id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void uniffi_loro_ffi_fn_method_versionvector_set_last(IntPtr ptr, RustBuffer id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_method_versionvector_to_hashmap(IntPtr ptr, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte uniffi_loro_ffi_fn_method_versionvector_try_update_last(IntPtr ptr, RustBuffer id, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_func_decode_import_blob_meta(RustBuffer bytes, sbyte checkChecksum, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer uniffi_loro_ffi_fn_func_get_version(ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer ffi_loro_ffi_rustbuffer_alloc(ulong size, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer ffi_loro_ffi_rustbuffer_from_bytes(ForeignBytes bytes, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rustbuffer_free(RustBuffer buf, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer ffi_loro_ffi_rustbuffer_reserve(RustBuffer buf, ulong additional, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_u8(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_u8(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_u8(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern byte ffi_loro_ffi_rust_future_complete_u8(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_i8(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_i8(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_i8(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern sbyte ffi_loro_ffi_rust_future_complete_i8(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_u16(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_u16(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_u16(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort ffi_loro_ffi_rust_future_complete_u16(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_i16(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_i16(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_i16(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern short ffi_loro_ffi_rust_future_complete_i16(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_u32(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_u32(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_u32(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint ffi_loro_ffi_rust_future_complete_u32(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_i32(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_i32(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_i32(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern int ffi_loro_ffi_rust_future_complete_i32(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_u64(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_u64(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_u64(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ulong ffi_loro_ffi_rust_future_complete_u64(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_i64(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_i64(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_i64(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern long ffi_loro_ffi_rust_future_complete_i64(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_f32(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_f32(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_f32(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern float ffi_loro_ffi_rust_future_complete_f32(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_f64(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_f64(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_f64(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern double ffi_loro_ffi_rust_future_complete_f64(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_pointer(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_pointer(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_pointer(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr ffi_loro_ffi_rust_future_complete_pointer(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_rust_buffer(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_rust_buffer(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_rust_buffer(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern RustBuffer ffi_loro_ffi_rust_future_complete_rust_buffer(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_poll_void(IntPtr handle, IntPtr callback, IntPtr callbackData);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_cancel_void(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_free_void(IntPtr handle);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ffi_loro_ffi_rust_future_complete_void(IntPtr handle, ref UniffiRustCallStatus _uniffi_out_err);

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_func_decode_import_blob_meta();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_func_get_version();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_awareness_apply();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_awareness_encode();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_awareness_encode_all();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_awareness_get_all_states();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_awareness_get_local_state();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_awareness_peer();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_awareness_remove_outdated();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_awareness_set_local_state();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_changeancestorstraveler_travel();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_changemodifier_set_message();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_changemodifier_set_timestamp();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_configure_fork();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_configure_merge_interval();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_configure_record_timestamp();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_configure_set_merge_interval();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_configure_set_record_timestamp();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_configure_text_style_config();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_containeridlike_as_container_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_cursor_encode();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_diffbatch_get_diff();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_diffbatch_push();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_ephemeralstore_apply();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_ephemeralstore_delete();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_ephemeralstore_encode();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_ephemeralstore_encode_all();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_ephemeralstore_get();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_ephemeralstore_get_all_states();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_ephemeralstore_keys();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_ephemeralstore_remove_outdated();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_ephemeralstore_set();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_ephemeralstore_subscribe();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_ephemeralstore_subscribe_local_update();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_ephemeralsubscriber_on_ephemeral_event();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_firstcommitfrompeercallback_on_first_commit_from_peer();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_frontiers_encode();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_frontiers_eq();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_frontiers_is_empty();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_frontiers_to_vec();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_jsonpathsubscriber_on_jsonpath_changed();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_localephemerallistener_on_ephemeral_update();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_localupdatecallback_on_local_update();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorocounter_decrement();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorocounter_doc();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorocounter_get_attached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorocounter_get_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorocounter_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorocounter_increment();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorocounter_is_attached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorocounter_is_deleted();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorocounter_subscribe();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_apply_diff();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_attach();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_check_state_correctness_slow();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_checkout();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_checkout_to_latest();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_clear_next_commit_options();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_cmp_with_frontiers();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_commit();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_commit_with();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_compact_change_store();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_config();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_config_default_text_style();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_config_text_style();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_delete_root_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_detach();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_diff();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_export_json_in_id_span();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_export_json_updates();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_export_json_updates_without_peer_compression();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_export_shallow_snapshot();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_export_snapshot();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_export_snapshot_at();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_export_state_only();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_export_updates();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_export_updates_in_range();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_find_id_spans_between();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_fork();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_fork_at();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_free_diff_calculator();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_free_history_cache();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_frontiers_to_vv();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_by_path();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_by_str_path();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_change();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_changed_containers_in();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_counter();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_cursor_pos();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_deep_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_deep_value_with_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_list();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_map();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_movable_list();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_path_to_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_pending_txn_len();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_text();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_tree();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_get_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_has_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_has_history_cache();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_import();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_import_batch();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_import_json_updates();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_import_with();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_is_detached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_is_shallow();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_jsonpath();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_len_changes();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_len_ops();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_minimize_frontiers();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_oplog_frontiers();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_oplog_vv();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_peer_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_redact_json_updates();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_revert_to();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_set_change_merge_interval();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_set_hide_empty_root_containers();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_set_next_commit_message();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_set_next_commit_options();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_set_next_commit_origin();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_set_next_commit_timestamp();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_set_peer_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_set_record_timestamp();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_shallow_since_vv();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_state_frontiers();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_state_vv();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_subscribe();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_subscribe_first_commit_from_peer();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_subscribe_jsonpath();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_subscribe_local_update();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_subscribe_pre_commit();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_subscribe_root();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_travel_change_ancestors();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorodoc_vv_to_frontiers();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_clear();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_delete();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_doc();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_get();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_get_attached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_get_cursor();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_get_deep_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_get_id_at();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_get_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_insert();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_insert_counter_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_insert_list_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_insert_map_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_insert_movable_list_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_insert_text_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_insert_tree_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_is_attached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_is_deleted();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_is_empty();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_len();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_pop();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_push();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_subscribe();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorolist_to_vec();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_clear();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_delete();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_doc();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_get();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_get_attached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_get_deep_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_get_last_editor();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_get_or_create_counter_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_get_or_create_list_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_get_or_create_map_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_get_or_create_movable_list_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_get_or_create_text_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_get_or_create_tree_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_get_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_insert();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_insert_counter_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_insert_list_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_insert_map_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_insert_movable_list_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_insert_text_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_insert_tree_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_is_attached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_is_deleted();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_is_empty();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_keys();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_len();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_subscribe();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromap_values();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_clear();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_delete();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_doc();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_get();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_get_attached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_get_creator_at();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_get_cursor();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_get_deep_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_get_last_editor_at();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_get_last_mover_at();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_get_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_insert();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_insert_counter_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_insert_list_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_insert_map_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_insert_movable_list_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_insert_text_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_insert_tree_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_is_attached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_is_deleted();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_is_empty();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_len();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_mov();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_pop();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_push();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_set();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_set_counter_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_set_list_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_set_map_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_set_movable_list_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_set_text_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_set_tree_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_subscribe();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_loromovablelist_to_vec();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_apply_delta();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_char_at();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_convert_pos();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_delete();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_delete_utf16();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_delete_utf8();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_doc();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_get_attached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_get_cursor();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_get_editor_at_unicode_pos();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_get_richtext_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_insert();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_insert_utf16();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_insert_utf8();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_is_attached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_is_deleted();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_is_empty();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_len_unicode();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_len_utf16();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_len_utf8();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_mark();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_mark_utf16();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_mark_utf8();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_push_str();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_slice();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_slice_delta();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_slice_utf16();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_splice();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_splice_utf16();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_subscribe();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_to_delta();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_unmark();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_unmark_utf16();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_update();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotext_update_by_line();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_children();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_children_num();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_contains();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_create();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_create_at();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_delete();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_disable_fractional_index();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_doc();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_enable_fractional_index();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_fractional_index();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_get_attached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_get_last_move_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_get_meta();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_get_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_get_value_with_meta();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_is_attached();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_is_deleted();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_is_fractional_index_enabled();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_is_node_deleted();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_mov();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_mov_after();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_mov_before();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_mov_to();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_nodes();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_parent();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_roots();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorotree_subscribe();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorounknown_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_lorovaluelike_as_loro_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_onpop_on_pop();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_onpush_on_push();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_precommitcallback_on_pre_commit();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_styleconfigmap_get();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_styleconfigmap_insert();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_subscriber_on_diff();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_subscription_detach();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_subscription_unsubscribe();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_add_exclude_origin_prefix();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_can_redo();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_can_undo();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_group_end();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_group_start();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_peer();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_record_new_checkpoint();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_redo();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_redo_count();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_set_max_undo_steps();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_set_merge_interval();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_set_on_pop();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_set_on_push();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_top_redo_meta();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_top_redo_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_top_undo_meta();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_top_undo_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_undo();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_undomanager_undo_count();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_unsubscriber_on_unsubscribe();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_valueorcontainer_as_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_counter();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_list();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_map();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_movable_list();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_text();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_tree();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_unknown();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_valueorcontainer_as_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_valueorcontainer_container_type();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_valueorcontainer_is_container();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_valueorcontainer_is_value();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionrange_clear();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionrange_contains_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionrange_contains_id_span();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionrange_contains_ops_between();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionrange_extends_to_include_id_span();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionrange_get();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionrange_get_all_ranges();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionrange_get_peers();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionrange_has_overlap_with();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionrange_insert();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionrange_is_empty();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_diff();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_encode();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_eq();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_extend_to_include_vv();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_get_last();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_get_missing_span();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_includes_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_includes_vv();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_intersect_span();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_merge();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_partial_cmp();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_set_end();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_set_last();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_to_hashmap();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_method_versionvector_try_update_last();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_awareness_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_cursor_decode();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_cursor_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_diffbatch_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_ephemeralstore_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_fractionalindex_from_bytes();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_fractionalindex_from_hex_string();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_frontiers_decode();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_frontiers_from_id();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_frontiers_from_ids();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_frontiers_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_lorocounter_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_lorodoc_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_lorolist_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_loromap_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_loromovablelist_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_lorotext_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_lorotree_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_styleconfigmap_default_rich_text_config();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_styleconfigmap_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_undomanager_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_versionrange_from_vv();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_versionrange_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_versionvector_decode();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern ushort uniffi_loro_ffi_checksum_constructor_versionvector_new();

	[DllImport("loro_cs", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint ffi_loro_ffi_uniffi_contract_version();

	private static void uniffiCheckContractApiVersion()
	{
		uint num = ffi_loro_ffi_uniffi_contract_version();
		if (26 != num)
		{
			throw new UniffiContractVersionException($"Pro.Loro: uniffi bindings expected version `26`, library returned `{num}`");
		}
	}

	private static void uniffiCheckApiChecksums()
	{
		ushort num = uniffi_loro_ffi_checksum_func_decode_import_blob_meta();
		if (num != 59767)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_func_decode_import_blob_meta` checksum `59767`, library returned `{num}`");
		}
		ushort num2 = uniffi_loro_ffi_checksum_func_get_version();
		if (num2 != 39468)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_func_get_version` checksum `39468`, library returned `{num2}`");
		}
		ushort num3 = uniffi_loro_ffi_checksum_method_awareness_apply();
		if (num3 != 32695)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_awareness_apply` checksum `32695`, library returned `{num3}`");
		}
		ushort num4 = uniffi_loro_ffi_checksum_method_awareness_encode();
		if (num4 != 4426)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_awareness_encode` checksum `4426`, library returned `{num4}`");
		}
		ushort num5 = uniffi_loro_ffi_checksum_method_awareness_encode_all();
		if (num5 != 29690)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_awareness_encode_all` checksum `29690`, library returned `{num5}`");
		}
		ushort num6 = uniffi_loro_ffi_checksum_method_awareness_get_all_states();
		if (num6 != 24946)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_awareness_get_all_states` checksum `24946`, library returned `{num6}`");
		}
		ushort num7 = uniffi_loro_ffi_checksum_method_awareness_get_local_state();
		if (num7 != 47648)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_awareness_get_local_state` checksum `47648`, library returned `{num7}`");
		}
		ushort num8 = uniffi_loro_ffi_checksum_method_awareness_peer();
		if (num8 != 7626)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_awareness_peer` checksum `7626`, library returned `{num8}`");
		}
		ushort num9 = uniffi_loro_ffi_checksum_method_awareness_remove_outdated();
		if (num9 != 59591)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_awareness_remove_outdated` checksum `59591`, library returned `{num9}`");
		}
		ushort num10 = uniffi_loro_ffi_checksum_method_awareness_set_local_state();
		if (num10 != 12712)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_awareness_set_local_state` checksum `12712`, library returned `{num10}`");
		}
		ushort num11 = uniffi_loro_ffi_checksum_method_changeancestorstraveler_travel();
		if (num11 != 43603)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_changeancestorstraveler_travel` checksum `43603`, library returned `{num11}`");
		}
		ushort num12 = uniffi_loro_ffi_checksum_method_changemodifier_set_message();
		if (num12 != 11943)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_changemodifier_set_message` checksum `11943`, library returned `{num12}`");
		}
		ushort num13 = uniffi_loro_ffi_checksum_method_changemodifier_set_timestamp();
		if (num13 != 5014)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_changemodifier_set_timestamp` checksum `5014`, library returned `{num13}`");
		}
		ushort num14 = uniffi_loro_ffi_checksum_method_configure_fork();
		if (num14 != 3880)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_configure_fork` checksum `3880`, library returned `{num14}`");
		}
		ushort num15 = uniffi_loro_ffi_checksum_method_configure_merge_interval();
		if (num15 != 19914)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_configure_merge_interval` checksum `19914`, library returned `{num15}`");
		}
		ushort num16 = uniffi_loro_ffi_checksum_method_configure_record_timestamp();
		if (num16 != 47148)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_configure_record_timestamp` checksum `47148`, library returned `{num16}`");
		}
		ushort num17 = uniffi_loro_ffi_checksum_method_configure_set_merge_interval();
		if (num17 != 59151)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_configure_set_merge_interval` checksum `59151`, library returned `{num17}`");
		}
		ushort num18 = uniffi_loro_ffi_checksum_method_configure_set_record_timestamp();
		if (num18 != 41593)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_configure_set_record_timestamp` checksum `41593`, library returned `{num18}`");
		}
		ushort num19 = uniffi_loro_ffi_checksum_method_configure_text_style_config();
		if (num19 != 13969)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_configure_text_style_config` checksum `13969`, library returned `{num19}`");
		}
		ushort num20 = uniffi_loro_ffi_checksum_method_containeridlike_as_container_id();
		if (num20 != 5805)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_containeridlike_as_container_id` checksum `5805`, library returned `{num20}`");
		}
		ushort num21 = uniffi_loro_ffi_checksum_method_cursor_encode();
		if (num21 != 36128)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_cursor_encode` checksum `36128`, library returned `{num21}`");
		}
		ushort num22 = uniffi_loro_ffi_checksum_method_diffbatch_get_diff();
		if (num22 != 5540)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_diffbatch_get_diff` checksum `5540`, library returned `{num22}`");
		}
		ushort num23 = uniffi_loro_ffi_checksum_method_diffbatch_push();
		if (num23 != 17472)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_diffbatch_push` checksum `17472`, library returned `{num23}`");
		}
		ushort num24 = uniffi_loro_ffi_checksum_method_ephemeralstore_apply();
		if (num24 != 1107)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_ephemeralstore_apply` checksum `1107`, library returned `{num24}`");
		}
		ushort num25 = uniffi_loro_ffi_checksum_method_ephemeralstore_delete();
		if (num25 != 9629)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_ephemeralstore_delete` checksum `9629`, library returned `{num25}`");
		}
		ushort num26 = uniffi_loro_ffi_checksum_method_ephemeralstore_encode();
		if (num26 != 27800)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_ephemeralstore_encode` checksum `27800`, library returned `{num26}`");
		}
		ushort num27 = uniffi_loro_ffi_checksum_method_ephemeralstore_encode_all();
		if (num27 != 45592)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_ephemeralstore_encode_all` checksum `45592`, library returned `{num27}`");
		}
		ushort num28 = uniffi_loro_ffi_checksum_method_ephemeralstore_get();
		if (num28 != 23330)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_ephemeralstore_get` checksum `23330`, library returned `{num28}`");
		}
		ushort num29 = uniffi_loro_ffi_checksum_method_ephemeralstore_get_all_states();
		if (num29 != 26188)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_ephemeralstore_get_all_states` checksum `26188`, library returned `{num29}`");
		}
		ushort num30 = uniffi_loro_ffi_checksum_method_ephemeralstore_keys();
		if (num30 != 19682)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_ephemeralstore_keys` checksum `19682`, library returned `{num30}`");
		}
		ushort num31 = uniffi_loro_ffi_checksum_method_ephemeralstore_remove_outdated();
		if (num31 != 55398)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_ephemeralstore_remove_outdated` checksum `55398`, library returned `{num31}`");
		}
		ushort num32 = uniffi_loro_ffi_checksum_method_ephemeralstore_set();
		if (num32 != 7799)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_ephemeralstore_set` checksum `7799`, library returned `{num32}`");
		}
		ushort num33 = uniffi_loro_ffi_checksum_method_ephemeralstore_subscribe();
		if (num33 != 1473)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_ephemeralstore_subscribe` checksum `1473`, library returned `{num33}`");
		}
		ushort num34 = uniffi_loro_ffi_checksum_method_ephemeralstore_subscribe_local_update();
		if (num34 != 1506)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_ephemeralstore_subscribe_local_update` checksum `1506`, library returned `{num34}`");
		}
		ushort num35 = uniffi_loro_ffi_checksum_method_ephemeralsubscriber_on_ephemeral_event();
		if (num35 != 21232)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_ephemeralsubscriber_on_ephemeral_event` checksum `21232`, library returned `{num35}`");
		}
		ushort num36 = uniffi_loro_ffi_checksum_method_firstcommitfrompeercallback_on_first_commit_from_peer();
		if (num36 != 54327)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_firstcommitfrompeercallback_on_first_commit_from_peer` checksum `54327`, library returned `{num36}`");
		}
		ushort num37 = uniffi_loro_ffi_checksum_method_frontiers_encode();
		if (num37 != 14564)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_frontiers_encode` checksum `14564`, library returned `{num37}`");
		}
		ushort num38 = uniffi_loro_ffi_checksum_method_frontiers_eq();
		if (num38 != 19191)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_frontiers_eq` checksum `19191`, library returned `{num38}`");
		}
		ushort num39 = uniffi_loro_ffi_checksum_method_frontiers_is_empty();
		if (num39 != 14722)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_frontiers_is_empty` checksum `14722`, library returned `{num39}`");
		}
		ushort num40 = uniffi_loro_ffi_checksum_method_frontiers_to_vec();
		if (num40 != 15210)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_frontiers_to_vec` checksum `15210`, library returned `{num40}`");
		}
		ushort num41 = uniffi_loro_ffi_checksum_method_jsonpathsubscriber_on_jsonpath_changed();
		if (num41 != 36440)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_jsonpathsubscriber_on_jsonpath_changed` checksum `36440`, library returned `{num41}`");
		}
		ushort num42 = uniffi_loro_ffi_checksum_method_localephemerallistener_on_ephemeral_update();
		if (num42 != 58755)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_localephemerallistener_on_ephemeral_update` checksum `58755`, library returned `{num42}`");
		}
		ushort num43 = uniffi_loro_ffi_checksum_method_localupdatecallback_on_local_update();
		if (num43 != 56990)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_localupdatecallback_on_local_update` checksum `56990`, library returned `{num43}`");
		}
		ushort num44 = uniffi_loro_ffi_checksum_method_lorocounter_decrement();
		if (num44 != 56450)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorocounter_decrement` checksum `56450`, library returned `{num44}`");
		}
		ushort num45 = uniffi_loro_ffi_checksum_method_lorocounter_doc();
		if (num45 != 18968)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorocounter_doc` checksum `18968`, library returned `{num45}`");
		}
		ushort num46 = uniffi_loro_ffi_checksum_method_lorocounter_get_attached();
		if (num46 != 28917)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorocounter_get_attached` checksum `28917`, library returned `{num46}`");
		}
		ushort num47 = uniffi_loro_ffi_checksum_method_lorocounter_get_value();
		if (num47 != 43671)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorocounter_get_value` checksum `43671`, library returned `{num47}`");
		}
		ushort num48 = uniffi_loro_ffi_checksum_method_lorocounter_id();
		if (num48 != 35406)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorocounter_id` checksum `35406`, library returned `{num48}`");
		}
		ushort num49 = uniffi_loro_ffi_checksum_method_lorocounter_increment();
		if (num49 != 60293)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorocounter_increment` checksum `60293`, library returned `{num49}`");
		}
		ushort num50 = uniffi_loro_ffi_checksum_method_lorocounter_is_attached();
		if (num50 != 28676)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorocounter_is_attached` checksum `28676`, library returned `{num50}`");
		}
		ushort num51 = uniffi_loro_ffi_checksum_method_lorocounter_is_deleted();
		if (num51 != 38594)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorocounter_is_deleted` checksum `38594`, library returned `{num51}`");
		}
		ushort num52 = uniffi_loro_ffi_checksum_method_lorocounter_subscribe();
		if (num52 != 60261)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorocounter_subscribe` checksum `60261`, library returned `{num52}`");
		}
		ushort num53 = uniffi_loro_ffi_checksum_method_lorodoc_apply_diff();
		if (num53 != 15296)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_apply_diff` checksum `15296`, library returned `{num53}`");
		}
		ushort num54 = uniffi_loro_ffi_checksum_method_lorodoc_attach();
		if (num54 != 48074)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_attach` checksum `48074`, library returned `{num54}`");
		}
		ushort num55 = uniffi_loro_ffi_checksum_method_lorodoc_check_state_correctness_slow();
		if (num55 != 53663)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_check_state_correctness_slow` checksum `53663`, library returned `{num55}`");
		}
		ushort num56 = uniffi_loro_ffi_checksum_method_lorodoc_checkout();
		if (num56 != 61916)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_checkout` checksum `61916`, library returned `{num56}`");
		}
		ushort num57 = uniffi_loro_ffi_checksum_method_lorodoc_checkout_to_latest();
		if (num57 != 62670)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_checkout_to_latest` checksum `62670`, library returned `{num57}`");
		}
		ushort num58 = uniffi_loro_ffi_checksum_method_lorodoc_clear_next_commit_options();
		if (num58 != 21764)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_clear_next_commit_options` checksum `21764`, library returned `{num58}`");
		}
		ushort num59 = uniffi_loro_ffi_checksum_method_lorodoc_cmp_with_frontiers();
		if (num59 != 41551)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_cmp_with_frontiers` checksum `41551`, library returned `{num59}`");
		}
		ushort num60 = uniffi_loro_ffi_checksum_method_lorodoc_commit();
		if (num60 != 25168)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_commit` checksum `25168`, library returned `{num60}`");
		}
		ushort num61 = uniffi_loro_ffi_checksum_method_lorodoc_commit_with();
		if (num61 != 65138)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_commit_with` checksum `65138`, library returned `{num61}`");
		}
		ushort num62 = uniffi_loro_ffi_checksum_method_lorodoc_compact_change_store();
		if (num62 != 59461)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_compact_change_store` checksum `59461`, library returned `{num62}`");
		}
		ushort num63 = uniffi_loro_ffi_checksum_method_lorodoc_config();
		if (num63 != 33471)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_config` checksum `33471`, library returned `{num63}`");
		}
		ushort num64 = uniffi_loro_ffi_checksum_method_lorodoc_config_default_text_style();
		if (num64 != 10240)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_config_default_text_style` checksum `10240`, library returned `{num64}`");
		}
		ushort num65 = uniffi_loro_ffi_checksum_method_lorodoc_config_text_style();
		if (num65 != 17307)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_config_text_style` checksum `17307`, library returned `{num65}`");
		}
		ushort num66 = uniffi_loro_ffi_checksum_method_lorodoc_delete_root_container();
		if (num66 != 4559)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_delete_root_container` checksum `4559`, library returned `{num66}`");
		}
		ushort num67 = uniffi_loro_ffi_checksum_method_lorodoc_detach();
		if (num67 != 24925)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_detach` checksum `24925`, library returned `{num67}`");
		}
		ushort num68 = uniffi_loro_ffi_checksum_method_lorodoc_diff();
		if (num68 != 53647)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_diff` checksum `53647`, library returned `{num68}`");
		}
		ushort num69 = uniffi_loro_ffi_checksum_method_lorodoc_export_json_in_id_span();
		if (num69 != 4524)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_export_json_in_id_span` checksum `4524`, library returned `{num69}`");
		}
		ushort num70 = uniffi_loro_ffi_checksum_method_lorodoc_export_json_updates();
		if (num70 != 27055)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_export_json_updates` checksum `27055`, library returned `{num70}`");
		}
		ushort num71 = uniffi_loro_ffi_checksum_method_lorodoc_export_json_updates_without_peer_compression();
		if (num71 != 42286)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_export_json_updates_without_peer_compression` checksum `42286`, library returned `{num71}`");
		}
		ushort num72 = uniffi_loro_ffi_checksum_method_lorodoc_export_shallow_snapshot();
		if (num72 != 20071)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_export_shallow_snapshot` checksum `20071`, library returned `{num72}`");
		}
		ushort num73 = uniffi_loro_ffi_checksum_method_lorodoc_export_snapshot();
		if (num73 != 28510)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_export_snapshot` checksum `28510`, library returned `{num73}`");
		}
		ushort num74 = uniffi_loro_ffi_checksum_method_lorodoc_export_snapshot_at();
		if (num74 != 37996)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_export_snapshot_at` checksum `37996`, library returned `{num74}`");
		}
		ushort num75 = uniffi_loro_ffi_checksum_method_lorodoc_export_state_only();
		if (num75 != 29117)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_export_state_only` checksum `29117`, library returned `{num75}`");
		}
		ushort num76 = uniffi_loro_ffi_checksum_method_lorodoc_export_updates();
		if (num76 != 2490)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_export_updates` checksum `2490`, library returned `{num76}`");
		}
		ushort num77 = uniffi_loro_ffi_checksum_method_lorodoc_export_updates_in_range();
		if (num77 != 62352)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_export_updates_in_range` checksum `62352`, library returned `{num77}`");
		}
		ushort num78 = uniffi_loro_ffi_checksum_method_lorodoc_find_id_spans_between();
		if (num78 != 1704)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_find_id_spans_between` checksum `1704`, library returned `{num78}`");
		}
		ushort num79 = uniffi_loro_ffi_checksum_method_lorodoc_fork();
		if (num79 != 42814)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_fork` checksum `42814`, library returned `{num79}`");
		}
		ushort num80 = uniffi_loro_ffi_checksum_method_lorodoc_fork_at();
		if (num80 != 26280)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_fork_at` checksum `26280`, library returned `{num80}`");
		}
		ushort num81 = uniffi_loro_ffi_checksum_method_lorodoc_free_diff_calculator();
		if (num81 != 59630)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_free_diff_calculator` checksum `59630`, library returned `{num81}`");
		}
		ushort num82 = uniffi_loro_ffi_checksum_method_lorodoc_free_history_cache();
		if (num82 != 3470)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_free_history_cache` checksum `3470`, library returned `{num82}`");
		}
		ushort num83 = uniffi_loro_ffi_checksum_method_lorodoc_frontiers_to_vv();
		if (num83 != 11507)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_frontiers_to_vv` checksum `11507`, library returned `{num83}`");
		}
		ushort num84 = uniffi_loro_ffi_checksum_method_lorodoc_get_by_path();
		if (num84 != 41531)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_by_path` checksum `41531`, library returned `{num84}`");
		}
		ushort num85 = uniffi_loro_ffi_checksum_method_lorodoc_get_by_str_path();
		if (num85 != 12043)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_by_str_path` checksum `12043`, library returned `{num85}`");
		}
		ushort num86 = uniffi_loro_ffi_checksum_method_lorodoc_get_change();
		if (num86 != 11256)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_change` checksum `11256`, library returned `{num86}`");
		}
		ushort num87 = uniffi_loro_ffi_checksum_method_lorodoc_get_changed_containers_in();
		if (num87 != 34378)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_changed_containers_in` checksum `34378`, library returned `{num87}`");
		}
		ushort num88 = uniffi_loro_ffi_checksum_method_lorodoc_get_container();
		if (num88 != 29566)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_container` checksum `29566`, library returned `{num88}`");
		}
		ushort num89 = uniffi_loro_ffi_checksum_method_lorodoc_get_counter();
		if (num89 != 60124)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_counter` checksum `60124`, library returned `{num89}`");
		}
		ushort num90 = uniffi_loro_ffi_checksum_method_lorodoc_get_cursor_pos();
		if (num90 != 47)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_cursor_pos` checksum `47`, library returned `{num90}`");
		}
		ushort num91 = uniffi_loro_ffi_checksum_method_lorodoc_get_deep_value();
		if (num91 != 38910)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_deep_value` checksum `38910`, library returned `{num91}`");
		}
		ushort num92 = uniffi_loro_ffi_checksum_method_lorodoc_get_deep_value_with_id();
		if (num92 != 64810)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_deep_value_with_id` checksum `64810`, library returned `{num92}`");
		}
		ushort num93 = uniffi_loro_ffi_checksum_method_lorodoc_get_list();
		if (num93 != 55819)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_list` checksum `55819`, library returned `{num93}`");
		}
		ushort num94 = uniffi_loro_ffi_checksum_method_lorodoc_get_map();
		if (num94 != 4871)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_map` checksum `4871`, library returned `{num94}`");
		}
		ushort num95 = uniffi_loro_ffi_checksum_method_lorodoc_get_movable_list();
		if (num95 != 17784)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_movable_list` checksum `17784`, library returned `{num95}`");
		}
		ushort num96 = uniffi_loro_ffi_checksum_method_lorodoc_get_path_to_container();
		if (num96 != 13102)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_path_to_container` checksum `13102`, library returned `{num96}`");
		}
		ushort num97 = uniffi_loro_ffi_checksum_method_lorodoc_get_pending_txn_len();
		if (num97 != 37770)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_pending_txn_len` checksum `37770`, library returned `{num97}`");
		}
		ushort num98 = uniffi_loro_ffi_checksum_method_lorodoc_get_text();
		if (num98 != 15375)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_text` checksum `15375`, library returned `{num98}`");
		}
		ushort num99 = uniffi_loro_ffi_checksum_method_lorodoc_get_tree();
		if (num99 != 30197)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_tree` checksum `30197`, library returned `{num99}`");
		}
		ushort num100 = uniffi_loro_ffi_checksum_method_lorodoc_get_value();
		if (num100 != 14086)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_get_value` checksum `14086`, library returned `{num100}`");
		}
		ushort num101 = uniffi_loro_ffi_checksum_method_lorodoc_has_container();
		if (num101 != 21303)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_has_container` checksum `21303`, library returned `{num101}`");
		}
		ushort num102 = uniffi_loro_ffi_checksum_method_lorodoc_has_history_cache();
		if (num102 != 18486)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_has_history_cache` checksum `18486`, library returned `{num102}`");
		}
		ushort num103 = uniffi_loro_ffi_checksum_method_lorodoc_import();
		if (num103 != 35043)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_import` checksum `35043`, library returned `{num103}`");
		}
		ushort num104 = uniffi_loro_ffi_checksum_method_lorodoc_import_batch();
		if (num104 != 39938)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_import_batch` checksum `39938`, library returned `{num104}`");
		}
		ushort num105 = uniffi_loro_ffi_checksum_method_lorodoc_import_json_updates();
		if (num105 != 58091)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_import_json_updates` checksum `58091`, library returned `{num105}`");
		}
		ushort num106 = uniffi_loro_ffi_checksum_method_lorodoc_import_with();
		if (num106 != 21187)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_import_with` checksum `21187`, library returned `{num106}`");
		}
		ushort num107 = uniffi_loro_ffi_checksum_method_lorodoc_is_detached();
		if (num107 != 19296)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_is_detached` checksum `19296`, library returned `{num107}`");
		}
		ushort num108 = uniffi_loro_ffi_checksum_method_lorodoc_is_shallow();
		if (num108 != 52920)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_is_shallow` checksum `52920`, library returned `{num108}`");
		}
		ushort num109 = uniffi_loro_ffi_checksum_method_lorodoc_jsonpath();
		if (num109 != 58280)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_jsonpath` checksum `58280`, library returned `{num109}`");
		}
		ushort num110 = uniffi_loro_ffi_checksum_method_lorodoc_len_changes();
		if (num110 != 43389)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_len_changes` checksum `43389`, library returned `{num110}`");
		}
		ushort num111 = uniffi_loro_ffi_checksum_method_lorodoc_len_ops();
		if (num111 != 1966)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_len_ops` checksum `1966`, library returned `{num111}`");
		}
		ushort num112 = uniffi_loro_ffi_checksum_method_lorodoc_minimize_frontiers();
		if (num112 != 47301)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_minimize_frontiers` checksum `47301`, library returned `{num112}`");
		}
		ushort num113 = uniffi_loro_ffi_checksum_method_lorodoc_oplog_frontiers();
		if (num113 != 35760)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_oplog_frontiers` checksum `35760`, library returned `{num113}`");
		}
		ushort num114 = uniffi_loro_ffi_checksum_method_lorodoc_oplog_vv();
		if (num114 != 35992)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_oplog_vv` checksum `35992`, library returned `{num114}`");
		}
		ushort num115 = uniffi_loro_ffi_checksum_method_lorodoc_peer_id();
		if (num115 != 5346)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_peer_id` checksum `5346`, library returned `{num115}`");
		}
		ushort num116 = uniffi_loro_ffi_checksum_method_lorodoc_redact_json_updates();
		if (num116 != 33049)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_redact_json_updates` checksum `33049`, library returned `{num116}`");
		}
		ushort num117 = uniffi_loro_ffi_checksum_method_lorodoc_revert_to();
		if (num117 != 13908)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_revert_to` checksum `13908`, library returned `{num117}`");
		}
		ushort num118 = uniffi_loro_ffi_checksum_method_lorodoc_set_change_merge_interval();
		if (num118 != 35421)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_set_change_merge_interval` checksum `35421`, library returned `{num118}`");
		}
		ushort num119 = uniffi_loro_ffi_checksum_method_lorodoc_set_hide_empty_root_containers();
		if (num119 != 61757)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_set_hide_empty_root_containers` checksum `61757`, library returned `{num119}`");
		}
		ushort num120 = uniffi_loro_ffi_checksum_method_lorodoc_set_next_commit_message();
		if (num120 != 47832)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_set_next_commit_message` checksum `47832`, library returned `{num120}`");
		}
		ushort num121 = uniffi_loro_ffi_checksum_method_lorodoc_set_next_commit_options();
		if (num121 != 53420)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_set_next_commit_options` checksum `53420`, library returned `{num121}`");
		}
		ushort num122 = uniffi_loro_ffi_checksum_method_lorodoc_set_next_commit_origin();
		if (num122 != 17826)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_set_next_commit_origin` checksum `17826`, library returned `{num122}`");
		}
		ushort num123 = uniffi_loro_ffi_checksum_method_lorodoc_set_next_commit_timestamp();
		if (num123 != 12708)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_set_next_commit_timestamp` checksum `12708`, library returned `{num123}`");
		}
		ushort num124 = uniffi_loro_ffi_checksum_method_lorodoc_set_peer_id();
		if (num124 != 59162)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_set_peer_id` checksum `59162`, library returned `{num124}`");
		}
		ushort num125 = uniffi_loro_ffi_checksum_method_lorodoc_set_record_timestamp();
		if (num125 != 30166)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_set_record_timestamp` checksum `30166`, library returned `{num125}`");
		}
		ushort num126 = uniffi_loro_ffi_checksum_method_lorodoc_shallow_since_vv();
		if (num126 != 62947)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_shallow_since_vv` checksum `62947`, library returned `{num126}`");
		}
		ushort num127 = uniffi_loro_ffi_checksum_method_lorodoc_state_frontiers();
		if (num127 != 3671)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_state_frontiers` checksum `3671`, library returned `{num127}`");
		}
		ushort num128 = uniffi_loro_ffi_checksum_method_lorodoc_state_vv();
		if (num128 != 14064)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_state_vv` checksum `14064`, library returned `{num128}`");
		}
		ushort num129 = uniffi_loro_ffi_checksum_method_lorodoc_subscribe();
		if (num129 != 33289)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_subscribe` checksum `33289`, library returned `{num129}`");
		}
		ushort num130 = uniffi_loro_ffi_checksum_method_lorodoc_subscribe_first_commit_from_peer();
		if (num130 != 65444)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_subscribe_first_commit_from_peer` checksum `65444`, library returned `{num130}`");
		}
		ushort num131 = uniffi_loro_ffi_checksum_method_lorodoc_subscribe_jsonpath();
		if (num131 != 58559)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_subscribe_jsonpath` checksum `58559`, library returned `{num131}`");
		}
		ushort num132 = uniffi_loro_ffi_checksum_method_lorodoc_subscribe_local_update();
		if (num132 != 46483)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_subscribe_local_update` checksum `46483`, library returned `{num132}`");
		}
		ushort num133 = uniffi_loro_ffi_checksum_method_lorodoc_subscribe_pre_commit();
		if (num133 != 8982)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_subscribe_pre_commit` checksum `8982`, library returned `{num133}`");
		}
		ushort num134 = uniffi_loro_ffi_checksum_method_lorodoc_subscribe_root();
		if (num134 != 64208)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_subscribe_root` checksum `64208`, library returned `{num134}`");
		}
		ushort num135 = uniffi_loro_ffi_checksum_method_lorodoc_travel_change_ancestors();
		if (num135 != 39975)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_travel_change_ancestors` checksum `39975`, library returned `{num135}`");
		}
		ushort num136 = uniffi_loro_ffi_checksum_method_lorodoc_vv_to_frontiers();
		if (num136 != 45843)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorodoc_vv_to_frontiers` checksum `45843`, library returned `{num136}`");
		}
		ushort num137 = uniffi_loro_ffi_checksum_method_lorolist_clear();
		if (num137 != 59547)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_clear` checksum `59547`, library returned `{num137}`");
		}
		ushort num138 = uniffi_loro_ffi_checksum_method_lorolist_delete();
		if (num138 != 34888)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_delete` checksum `34888`, library returned `{num138}`");
		}
		ushort num139 = uniffi_loro_ffi_checksum_method_lorolist_doc();
		if (num139 != 53175)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_doc` checksum `53175`, library returned `{num139}`");
		}
		ushort num140 = uniffi_loro_ffi_checksum_method_lorolist_get();
		if (num140 != 5256)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_get` checksum `5256`, library returned `{num140}`");
		}
		ushort num141 = uniffi_loro_ffi_checksum_method_lorolist_get_attached();
		if (num141 != 45494)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_get_attached` checksum `45494`, library returned `{num141}`");
		}
		ushort num142 = uniffi_loro_ffi_checksum_method_lorolist_get_cursor();
		if (num142 != 37701)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_get_cursor` checksum `37701`, library returned `{num142}`");
		}
		ushort num143 = uniffi_loro_ffi_checksum_method_lorolist_get_deep_value();
		if (num143 != 41115)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_get_deep_value` checksum `41115`, library returned `{num143}`");
		}
		ushort num144 = uniffi_loro_ffi_checksum_method_lorolist_get_id_at();
		if (num144 != 29299)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_get_id_at` checksum `29299`, library returned `{num144}`");
		}
		ushort num145 = uniffi_loro_ffi_checksum_method_lorolist_get_value();
		if (num145 != 35537)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_get_value` checksum `35537`, library returned `{num145}`");
		}
		ushort num146 = uniffi_loro_ffi_checksum_method_lorolist_id();
		if (num146 != 43156)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_id` checksum `43156`, library returned `{num146}`");
		}
		ushort num147 = uniffi_loro_ffi_checksum_method_lorolist_insert();
		if (num147 != 8265)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_insert` checksum `8265`, library returned `{num147}`");
		}
		ushort num148 = uniffi_loro_ffi_checksum_method_lorolist_insert_counter_container();
		if (num148 != 32924)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_insert_counter_container` checksum `32924`, library returned `{num148}`");
		}
		ushort num149 = uniffi_loro_ffi_checksum_method_lorolist_insert_list_container();
		if (num149 != 3124)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_insert_list_container` checksum `3124`, library returned `{num149}`");
		}
		ushort num150 = uniffi_loro_ffi_checksum_method_lorolist_insert_map_container();
		if (num150 != 8686)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_insert_map_container` checksum `8686`, library returned `{num150}`");
		}
		ushort num151 = uniffi_loro_ffi_checksum_method_lorolist_insert_movable_list_container();
		if (num151 != 61399)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_insert_movable_list_container` checksum `61399`, library returned `{num151}`");
		}
		ushort num152 = uniffi_loro_ffi_checksum_method_lorolist_insert_text_container();
		if (num152 != 58385)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_insert_text_container` checksum `58385`, library returned `{num152}`");
		}
		ushort num153 = uniffi_loro_ffi_checksum_method_lorolist_insert_tree_container();
		if (num153 != 39269)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_insert_tree_container` checksum `39269`, library returned `{num153}`");
		}
		ushort num154 = uniffi_loro_ffi_checksum_method_lorolist_is_attached();
		if (num154 != 51464)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_is_attached` checksum `51464`, library returned `{num154}`");
		}
		ushort num155 = uniffi_loro_ffi_checksum_method_lorolist_is_deleted();
		if (num155 != 17142)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_is_deleted` checksum `17142`, library returned `{num155}`");
		}
		ushort num156 = uniffi_loro_ffi_checksum_method_lorolist_is_empty();
		if (num156 != 3297)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_is_empty` checksum `3297`, library returned `{num156}`");
		}
		ushort num157 = uniffi_loro_ffi_checksum_method_lorolist_len();
		if (num157 != 31562)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_len` checksum `31562`, library returned `{num157}`");
		}
		ushort num158 = uniffi_loro_ffi_checksum_method_lorolist_pop();
		if (num158 != 46637)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_pop` checksum `46637`, library returned `{num158}`");
		}
		ushort num159 = uniffi_loro_ffi_checksum_method_lorolist_push();
		if (num159 != 48242)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_push` checksum `48242`, library returned `{num159}`");
		}
		ushort num160 = uniffi_loro_ffi_checksum_method_lorolist_subscribe();
		if (num160 != 37781)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_subscribe` checksum `37781`, library returned `{num160}`");
		}
		ushort num161 = uniffi_loro_ffi_checksum_method_lorolist_to_vec();
		if (num161 != 48551)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorolist_to_vec` checksum `48551`, library returned `{num161}`");
		}
		ushort num162 = uniffi_loro_ffi_checksum_method_loromap_clear();
		if (num162 != 36823)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_clear` checksum `36823`, library returned `{num162}`");
		}
		ushort num163 = uniffi_loro_ffi_checksum_method_loromap_delete();
		if (num163 != 1727)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_delete` checksum `1727`, library returned `{num163}`");
		}
		ushort num164 = uniffi_loro_ffi_checksum_method_loromap_doc();
		if (num164 != 23666)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_doc` checksum `23666`, library returned `{num164}`");
		}
		ushort num165 = uniffi_loro_ffi_checksum_method_loromap_get();
		if (num165 != 3814)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_get` checksum `3814`, library returned `{num165}`");
		}
		ushort num166 = uniffi_loro_ffi_checksum_method_loromap_get_attached();
		if (num166 != 56597)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_get_attached` checksum `56597`, library returned `{num166}`");
		}
		ushort num167 = uniffi_loro_ffi_checksum_method_loromap_get_deep_value();
		if (num167 != 63734)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_get_deep_value` checksum `63734`, library returned `{num167}`");
		}
		ushort num168 = uniffi_loro_ffi_checksum_method_loromap_get_last_editor();
		if (num168 != 57747)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_get_last_editor` checksum `57747`, library returned `{num168}`");
		}
		ushort num169 = uniffi_loro_ffi_checksum_method_loromap_get_or_create_counter_container();
		if (num169 != 54451)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_get_or_create_counter_container` checksum `54451`, library returned `{num169}`");
		}
		ushort num170 = uniffi_loro_ffi_checksum_method_loromap_get_or_create_list_container();
		if (num170 != 65040)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_get_or_create_list_container` checksum `65040`, library returned `{num170}`");
		}
		ushort num171 = uniffi_loro_ffi_checksum_method_loromap_get_or_create_map_container();
		if (num171 != 8641)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_get_or_create_map_container` checksum `8641`, library returned `{num171}`");
		}
		ushort num172 = uniffi_loro_ffi_checksum_method_loromap_get_or_create_movable_list_container();
		if (num172 != 43140)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_get_or_create_movable_list_container` checksum `43140`, library returned `{num172}`");
		}
		ushort num173 = uniffi_loro_ffi_checksum_method_loromap_get_or_create_text_container();
		if (num173 != 26168)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_get_or_create_text_container` checksum `26168`, library returned `{num173}`");
		}
		ushort num174 = uniffi_loro_ffi_checksum_method_loromap_get_or_create_tree_container();
		if (num174 != 3661)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_get_or_create_tree_container` checksum `3661`, library returned `{num174}`");
		}
		ushort num175 = uniffi_loro_ffi_checksum_method_loromap_get_value();
		if (num175 != 22622)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_get_value` checksum `22622`, library returned `{num175}`");
		}
		ushort num176 = uniffi_loro_ffi_checksum_method_loromap_id();
		if (num176 != 57881)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_id` checksum `57881`, library returned `{num176}`");
		}
		ushort num177 = uniffi_loro_ffi_checksum_method_loromap_insert();
		if (num177 != 34158)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_insert` checksum `34158`, library returned `{num177}`");
		}
		ushort num178 = uniffi_loro_ffi_checksum_method_loromap_insert_counter_container();
		if (num178 != 6141)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_insert_counter_container` checksum `6141`, library returned `{num178}`");
		}
		ushort num179 = uniffi_loro_ffi_checksum_method_loromap_insert_list_container();
		if (num179 != 42123)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_insert_list_container` checksum `42123`, library returned `{num179}`");
		}
		ushort num180 = uniffi_loro_ffi_checksum_method_loromap_insert_map_container();
		if (num180 != 17066)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_insert_map_container` checksum `17066`, library returned `{num180}`");
		}
		ushort num181 = uniffi_loro_ffi_checksum_method_loromap_insert_movable_list_container();
		if (num181 != 57381)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_insert_movable_list_container` checksum `57381`, library returned `{num181}`");
		}
		ushort num182 = uniffi_loro_ffi_checksum_method_loromap_insert_text_container();
		if (num182 != 28951)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_insert_text_container` checksum `28951`, library returned `{num182}`");
		}
		ushort num183 = uniffi_loro_ffi_checksum_method_loromap_insert_tree_container();
		if (num183 != 57059)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_insert_tree_container` checksum `57059`, library returned `{num183}`");
		}
		ushort num184 = uniffi_loro_ffi_checksum_method_loromap_is_attached();
		if (num184 != 41489)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_is_attached` checksum `41489`, library returned `{num184}`");
		}
		ushort num185 = uniffi_loro_ffi_checksum_method_loromap_is_deleted();
		if (num185 != 32195)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_is_deleted` checksum `32195`, library returned `{num185}`");
		}
		ushort num186 = uniffi_loro_ffi_checksum_method_loromap_is_empty();
		if (num186 != 41904)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_is_empty` checksum `41904`, library returned `{num186}`");
		}
		ushort num187 = uniffi_loro_ffi_checksum_method_loromap_keys();
		if (num187 != 52242)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_keys` checksum `52242`, library returned `{num187}`");
		}
		ushort num188 = uniffi_loro_ffi_checksum_method_loromap_len();
		if (num188 != 39413)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_len` checksum `39413`, library returned `{num188}`");
		}
		ushort num189 = uniffi_loro_ffi_checksum_method_loromap_subscribe();
		if (num189 != 52134)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_subscribe` checksum `52134`, library returned `{num189}`");
		}
		ushort num190 = uniffi_loro_ffi_checksum_method_loromap_values();
		if (num190 != 59291)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromap_values` checksum `59291`, library returned `{num190}`");
		}
		ushort num191 = uniffi_loro_ffi_checksum_method_loromovablelist_clear();
		if (num191 != 12048)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_clear` checksum `12048`, library returned `{num191}`");
		}
		ushort num192 = uniffi_loro_ffi_checksum_method_loromovablelist_delete();
		if (num192 != 9110)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_delete` checksum `9110`, library returned `{num192}`");
		}
		ushort num193 = uniffi_loro_ffi_checksum_method_loromovablelist_doc();
		if (num193 != 61310)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_doc` checksum `61310`, library returned `{num193}`");
		}
		ushort num194 = uniffi_loro_ffi_checksum_method_loromovablelist_get();
		if (num194 != 8877)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_get` checksum `8877`, library returned `{num194}`");
		}
		ushort num195 = uniffi_loro_ffi_checksum_method_loromovablelist_get_attached();
		if (num195 != 42721)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_get_attached` checksum `42721`, library returned `{num195}`");
		}
		ushort num196 = uniffi_loro_ffi_checksum_method_loromovablelist_get_creator_at();
		if (num196 != 27128)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_get_creator_at` checksum `27128`, library returned `{num196}`");
		}
		ushort num197 = uniffi_loro_ffi_checksum_method_loromovablelist_get_cursor();
		if (num197 != 62502)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_get_cursor` checksum `62502`, library returned `{num197}`");
		}
		ushort num198 = uniffi_loro_ffi_checksum_method_loromovablelist_get_deep_value();
		if (num198 != 8622)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_get_deep_value` checksum `8622`, library returned `{num198}`");
		}
		ushort num199 = uniffi_loro_ffi_checksum_method_loromovablelist_get_last_editor_at();
		if (num199 != 37091)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_get_last_editor_at` checksum `37091`, library returned `{num199}`");
		}
		ushort num200 = uniffi_loro_ffi_checksum_method_loromovablelist_get_last_mover_at();
		if (num200 != 63909)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_get_last_mover_at` checksum `63909`, library returned `{num200}`");
		}
		ushort num201 = uniffi_loro_ffi_checksum_method_loromovablelist_get_value();
		if (num201 != 33102)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_get_value` checksum `33102`, library returned `{num201}`");
		}
		ushort num202 = uniffi_loro_ffi_checksum_method_loromovablelist_id();
		if (num202 != 25848)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_id` checksum `25848`, library returned `{num202}`");
		}
		ushort num203 = uniffi_loro_ffi_checksum_method_loromovablelist_insert();
		if (num203 != 47936)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_insert` checksum `47936`, library returned `{num203}`");
		}
		ushort num204 = uniffi_loro_ffi_checksum_method_loromovablelist_insert_counter_container();
		if (num204 != 38234)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_insert_counter_container` checksum `38234`, library returned `{num204}`");
		}
		ushort num205 = uniffi_loro_ffi_checksum_method_loromovablelist_insert_list_container();
		if (num205 != 50065)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_insert_list_container` checksum `50065`, library returned `{num205}`");
		}
		ushort num206 = uniffi_loro_ffi_checksum_method_loromovablelist_insert_map_container();
		if (num206 != 61365)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_insert_map_container` checksum `61365`, library returned `{num206}`");
		}
		ushort num207 = uniffi_loro_ffi_checksum_method_loromovablelist_insert_movable_list_container();
		if (num207 != 23331)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_insert_movable_list_container` checksum `23331`, library returned `{num207}`");
		}
		ushort num208 = uniffi_loro_ffi_checksum_method_loromovablelist_insert_text_container();
		if (num208 != 57512)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_insert_text_container` checksum `57512`, library returned `{num208}`");
		}
		ushort num209 = uniffi_loro_ffi_checksum_method_loromovablelist_insert_tree_container();
		if (num209 != 12645)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_insert_tree_container` checksum `12645`, library returned `{num209}`");
		}
		ushort num210 = uniffi_loro_ffi_checksum_method_loromovablelist_is_attached();
		if (num210 != 58545)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_is_attached` checksum `58545`, library returned `{num210}`");
		}
		ushort num211 = uniffi_loro_ffi_checksum_method_loromovablelist_is_deleted();
		if (num211 != 34830)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_is_deleted` checksum `34830`, library returned `{num211}`");
		}
		ushort num212 = uniffi_loro_ffi_checksum_method_loromovablelist_is_empty();
		if (num212 != 37813)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_is_empty` checksum `37813`, library returned `{num212}`");
		}
		ushort num213 = uniffi_loro_ffi_checksum_method_loromovablelist_len();
		if (num213 != 30817)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_len` checksum `30817`, library returned `{num213}`");
		}
		ushort num214 = uniffi_loro_ffi_checksum_method_loromovablelist_mov();
		if (num214 != 19397)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_mov` checksum `19397`, library returned `{num214}`");
		}
		ushort num215 = uniffi_loro_ffi_checksum_method_loromovablelist_pop();
		if (num215 != 7553)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_pop` checksum `7553`, library returned `{num215}`");
		}
		ushort num216 = uniffi_loro_ffi_checksum_method_loromovablelist_push();
		if (num216 != 61369)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_push` checksum `61369`, library returned `{num216}`");
		}
		ushort num217 = uniffi_loro_ffi_checksum_method_loromovablelist_set();
		if (num217 != 26682)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_set` checksum `26682`, library returned `{num217}`");
		}
		ushort num218 = uniffi_loro_ffi_checksum_method_loromovablelist_set_counter_container();
		if (num218 != 47882)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_set_counter_container` checksum `47882`, library returned `{num218}`");
		}
		ushort num219 = uniffi_loro_ffi_checksum_method_loromovablelist_set_list_container();
		if (num219 != 48467)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_set_list_container` checksum `48467`, library returned `{num219}`");
		}
		ushort num220 = uniffi_loro_ffi_checksum_method_loromovablelist_set_map_container();
		if (num220 != 18279)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_set_map_container` checksum `18279`, library returned `{num220}`");
		}
		ushort num221 = uniffi_loro_ffi_checksum_method_loromovablelist_set_movable_list_container();
		if (num221 != 58356)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_set_movable_list_container` checksum `58356`, library returned `{num221}`");
		}
		ushort num222 = uniffi_loro_ffi_checksum_method_loromovablelist_set_text_container();
		if (num222 != 17337)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_set_text_container` checksum `17337`, library returned `{num222}`");
		}
		ushort num223 = uniffi_loro_ffi_checksum_method_loromovablelist_set_tree_container();
		if (num223 != 10601)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_set_tree_container` checksum `10601`, library returned `{num223}`");
		}
		ushort num224 = uniffi_loro_ffi_checksum_method_loromovablelist_subscribe();
		if (num224 != 31212)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_subscribe` checksum `31212`, library returned `{num224}`");
		}
		ushort num225 = uniffi_loro_ffi_checksum_method_loromovablelist_to_vec();
		if (num225 != 22764)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_loromovablelist_to_vec` checksum `22764`, library returned `{num225}`");
		}
		ushort num226 = uniffi_loro_ffi_checksum_method_lorotext_apply_delta();
		if (num226 != 31013)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_apply_delta` checksum `31013`, library returned `{num226}`");
		}
		ushort num227 = uniffi_loro_ffi_checksum_method_lorotext_char_at();
		if (num227 != 49891)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_char_at` checksum `49891`, library returned `{num227}`");
		}
		ushort num228 = uniffi_loro_ffi_checksum_method_lorotext_convert_pos();
		if (num228 != 51289)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_convert_pos` checksum `51289`, library returned `{num228}`");
		}
		ushort num229 = uniffi_loro_ffi_checksum_method_lorotext_delete();
		if (num229 != 50707)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_delete` checksum `50707`, library returned `{num229}`");
		}
		ushort num230 = uniffi_loro_ffi_checksum_method_lorotext_delete_utf16();
		if (num230 != 1418)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_delete_utf16` checksum `1418`, library returned `{num230}`");
		}
		ushort num231 = uniffi_loro_ffi_checksum_method_lorotext_delete_utf8();
		if (num231 != 47178)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_delete_utf8` checksum `47178`, library returned `{num231}`");
		}
		ushort num232 = uniffi_loro_ffi_checksum_method_lorotext_doc();
		if (num232 != 37119)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_doc` checksum `37119`, library returned `{num232}`");
		}
		ushort num233 = uniffi_loro_ffi_checksum_method_lorotext_get_attached();
		if (num233 != 36679)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_get_attached` checksum `36679`, library returned `{num233}`");
		}
		ushort num234 = uniffi_loro_ffi_checksum_method_lorotext_get_cursor();
		if (num234 != 14735)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_get_cursor` checksum `14735`, library returned `{num234}`");
		}
		ushort num235 = uniffi_loro_ffi_checksum_method_lorotext_get_editor_at_unicode_pos();
		if (num235 != 20823)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_get_editor_at_unicode_pos` checksum `20823`, library returned `{num235}`");
		}
		ushort num236 = uniffi_loro_ffi_checksum_method_lorotext_get_richtext_value();
		if (num236 != 41287)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_get_richtext_value` checksum `41287`, library returned `{num236}`");
		}
		ushort num237 = uniffi_loro_ffi_checksum_method_lorotext_id();
		if (num237 != 15221)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_id` checksum `15221`, library returned `{num237}`");
		}
		ushort num238 = uniffi_loro_ffi_checksum_method_lorotext_insert();
		if (num238 != 28264)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_insert` checksum `28264`, library returned `{num238}`");
		}
		ushort num239 = uniffi_loro_ffi_checksum_method_lorotext_insert_utf16();
		if (num239 != 39579)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_insert_utf16` checksum `39579`, library returned `{num239}`");
		}
		ushort num240 = uniffi_loro_ffi_checksum_method_lorotext_insert_utf8();
		if (num240 != 16771)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_insert_utf8` checksum `16771`, library returned `{num240}`");
		}
		ushort num241 = uniffi_loro_ffi_checksum_method_lorotext_is_attached();
		if (num241 != 58046)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_is_attached` checksum `58046`, library returned `{num241}`");
		}
		ushort num242 = uniffi_loro_ffi_checksum_method_lorotext_is_deleted();
		if (num242 != 31785)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_is_deleted` checksum `31785`, library returned `{num242}`");
		}
		ushort num243 = uniffi_loro_ffi_checksum_method_lorotext_is_empty();
		if (num243 != 46465)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_is_empty` checksum `46465`, library returned `{num243}`");
		}
		ushort num244 = uniffi_loro_ffi_checksum_method_lorotext_len_unicode();
		if (num244 != 20282)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_len_unicode` checksum `20282`, library returned `{num244}`");
		}
		ushort num245 = uniffi_loro_ffi_checksum_method_lorotext_len_utf16();
		if (num245 != 31093)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_len_utf16` checksum `31093`, library returned `{num245}`");
		}
		ushort num246 = uniffi_loro_ffi_checksum_method_lorotext_len_utf8();
		if (num246 != 7703)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_len_utf8` checksum `7703`, library returned `{num246}`");
		}
		ushort num247 = uniffi_loro_ffi_checksum_method_lorotext_mark();
		if (num247 != 24092)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_mark` checksum `24092`, library returned `{num247}`");
		}
		ushort num248 = uniffi_loro_ffi_checksum_method_lorotext_mark_utf16();
		if (num248 != 54485)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_mark_utf16` checksum `54485`, library returned `{num248}`");
		}
		ushort num249 = uniffi_loro_ffi_checksum_method_lorotext_mark_utf8();
		if (num249 != 20536)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_mark_utf8` checksum `20536`, library returned `{num249}`");
		}
		ushort num250 = uniffi_loro_ffi_checksum_method_lorotext_push_str();
		if (num250 != 46599)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_push_str` checksum `46599`, library returned `{num250}`");
		}
		ushort num251 = uniffi_loro_ffi_checksum_method_lorotext_slice();
		if (num251 != 10385)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_slice` checksum `10385`, library returned `{num251}`");
		}
		ushort num252 = uniffi_loro_ffi_checksum_method_lorotext_slice_delta();
		if (num252 != 46224)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_slice_delta` checksum `46224`, library returned `{num252}`");
		}
		ushort num253 = uniffi_loro_ffi_checksum_method_lorotext_slice_utf16();
		if (num253 != 25024)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_slice_utf16` checksum `25024`, library returned `{num253}`");
		}
		ushort num254 = uniffi_loro_ffi_checksum_method_lorotext_splice();
		if (num254 != 53391)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_splice` checksum `53391`, library returned `{num254}`");
		}
		ushort num255 = uniffi_loro_ffi_checksum_method_lorotext_splice_utf16();
		if (num255 != 30121)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_splice_utf16` checksum `30121`, library returned `{num255}`");
		}
		ushort num256 = uniffi_loro_ffi_checksum_method_lorotext_subscribe();
		if (num256 != 55608)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_subscribe` checksum `55608`, library returned `{num256}`");
		}
		ushort num257 = uniffi_loro_ffi_checksum_method_lorotext_to_delta();
		if (num257 != 49666)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_to_delta` checksum `49666`, library returned `{num257}`");
		}
		ushort num258 = uniffi_loro_ffi_checksum_method_lorotext_unmark();
		if (num258 != 47537)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_unmark` checksum `47537`, library returned `{num258}`");
		}
		ushort num259 = uniffi_loro_ffi_checksum_method_lorotext_unmark_utf16();
		if (num259 != 39405)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_unmark_utf16` checksum `39405`, library returned `{num259}`");
		}
		ushort num260 = uniffi_loro_ffi_checksum_method_lorotext_update();
		if (num260 != 25715)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_update` checksum `25715`, library returned `{num260}`");
		}
		ushort num261 = uniffi_loro_ffi_checksum_method_lorotext_update_by_line();
		if (num261 != 58900)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotext_update_by_line` checksum `58900`, library returned `{num261}`");
		}
		ushort num262 = uniffi_loro_ffi_checksum_method_lorotree_children();
		if (num262 != 34358)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_children` checksum `34358`, library returned `{num262}`");
		}
		ushort num263 = uniffi_loro_ffi_checksum_method_lorotree_children_num();
		if (num263 != 8923)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_children_num` checksum `8923`, library returned `{num263}`");
		}
		ushort num264 = uniffi_loro_ffi_checksum_method_lorotree_contains();
		if (num264 != 37670)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_contains` checksum `37670`, library returned `{num264}`");
		}
		ushort num265 = uniffi_loro_ffi_checksum_method_lorotree_create();
		if (num265 != 38374)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_create` checksum `38374`, library returned `{num265}`");
		}
		ushort num266 = uniffi_loro_ffi_checksum_method_lorotree_create_at();
		if (num266 != 47251)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_create_at` checksum `47251`, library returned `{num266}`");
		}
		ushort num267 = uniffi_loro_ffi_checksum_method_lorotree_delete();
		if (num267 != 46062)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_delete` checksum `46062`, library returned `{num267}`");
		}
		ushort num268 = uniffi_loro_ffi_checksum_method_lorotree_disable_fractional_index();
		if (num268 != 6413)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_disable_fractional_index` checksum `6413`, library returned `{num268}`");
		}
		ushort num269 = uniffi_loro_ffi_checksum_method_lorotree_doc();
		if (num269 != 46210)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_doc` checksum `46210`, library returned `{num269}`");
		}
		ushort num270 = uniffi_loro_ffi_checksum_method_lorotree_enable_fractional_index();
		if (num270 != 60734)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_enable_fractional_index` checksum `60734`, library returned `{num270}`");
		}
		ushort num271 = uniffi_loro_ffi_checksum_method_lorotree_fractional_index();
		if (num271 != 14495)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_fractional_index` checksum `14495`, library returned `{num271}`");
		}
		ushort num272 = uniffi_loro_ffi_checksum_method_lorotree_get_attached();
		if (num272 != 59293)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_get_attached` checksum `59293`, library returned `{num272}`");
		}
		ushort num273 = uniffi_loro_ffi_checksum_method_lorotree_get_last_move_id();
		if (num273 != 40233)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_get_last_move_id` checksum `40233`, library returned `{num273}`");
		}
		ushort num274 = uniffi_loro_ffi_checksum_method_lorotree_get_meta();
		if (num274 != 33850)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_get_meta` checksum `33850`, library returned `{num274}`");
		}
		ushort num275 = uniffi_loro_ffi_checksum_method_lorotree_get_value();
		if (num275 != 1865)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_get_value` checksum `1865`, library returned `{num275}`");
		}
		ushort num276 = uniffi_loro_ffi_checksum_method_lorotree_get_value_with_meta();
		if (num276 != 15594)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_get_value_with_meta` checksum `15594`, library returned `{num276}`");
		}
		ushort num277 = uniffi_loro_ffi_checksum_method_lorotree_id();
		if (num277 != 16524)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_id` checksum `16524`, library returned `{num277}`");
		}
		ushort num278 = uniffi_loro_ffi_checksum_method_lorotree_is_attached();
		if (num278 != 57971)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_is_attached` checksum `57971`, library returned `{num278}`");
		}
		ushort num279 = uniffi_loro_ffi_checksum_method_lorotree_is_deleted();
		if (num279 != 34560)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_is_deleted` checksum `34560`, library returned `{num279}`");
		}
		ushort num280 = uniffi_loro_ffi_checksum_method_lorotree_is_fractional_index_enabled();
		if (num280 != 28969)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_is_fractional_index_enabled` checksum `28969`, library returned `{num280}`");
		}
		ushort num281 = uniffi_loro_ffi_checksum_method_lorotree_is_node_deleted();
		if (num281 != 16024)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_is_node_deleted` checksum `16024`, library returned `{num281}`");
		}
		ushort num282 = uniffi_loro_ffi_checksum_method_lorotree_mov();
		if (num282 != 20249)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_mov` checksum `20249`, library returned `{num282}`");
		}
		ushort num283 = uniffi_loro_ffi_checksum_method_lorotree_mov_after();
		if (num283 != 21386)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_mov_after` checksum `21386`, library returned `{num283}`");
		}
		ushort num284 = uniffi_loro_ffi_checksum_method_lorotree_mov_before();
		if (num284 != 13866)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_mov_before` checksum `13866`, library returned `{num284}`");
		}
		ushort num285 = uniffi_loro_ffi_checksum_method_lorotree_mov_to();
		if (num285 != 32503)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_mov_to` checksum `32503`, library returned `{num285}`");
		}
		ushort num286 = uniffi_loro_ffi_checksum_method_lorotree_nodes();
		if (num286 != 19191)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_nodes` checksum `19191`, library returned `{num286}`");
		}
		ushort num287 = uniffi_loro_ffi_checksum_method_lorotree_parent();
		if (num287 != 19692)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_parent` checksum `19692`, library returned `{num287}`");
		}
		ushort num288 = uniffi_loro_ffi_checksum_method_lorotree_roots();
		if (num288 != 6925)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_roots` checksum `6925`, library returned `{num288}`");
		}
		ushort num289 = uniffi_loro_ffi_checksum_method_lorotree_subscribe();
		if (num289 != 4481)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorotree_subscribe` checksum `4481`, library returned `{num289}`");
		}
		ushort num290 = uniffi_loro_ffi_checksum_method_lorounknown_id();
		if (num290 != 45333)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorounknown_id` checksum `45333`, library returned `{num290}`");
		}
		ushort num291 = uniffi_loro_ffi_checksum_method_lorovaluelike_as_loro_value();
		if (num291 != 45291)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_lorovaluelike_as_loro_value` checksum `45291`, library returned `{num291}`");
		}
		ushort num292 = uniffi_loro_ffi_checksum_method_onpop_on_pop();
		if (num292 != 48967)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_onpop_on_pop` checksum `48967`, library returned `{num292}`");
		}
		ushort num293 = uniffi_loro_ffi_checksum_method_onpush_on_push();
		if (num293 != 12923)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_onpush_on_push` checksum `12923`, library returned `{num293}`");
		}
		ushort num294 = uniffi_loro_ffi_checksum_method_precommitcallback_on_pre_commit();
		if (num294 != 57839)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_precommitcallback_on_pre_commit` checksum `57839`, library returned `{num294}`");
		}
		ushort num295 = uniffi_loro_ffi_checksum_method_styleconfigmap_get();
		if (num295 != 5813)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_styleconfigmap_get` checksum `5813`, library returned `{num295}`");
		}
		ushort num296 = uniffi_loro_ffi_checksum_method_styleconfigmap_insert();
		if (num296 != 64615)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_styleconfigmap_insert` checksum `64615`, library returned `{num296}`");
		}
		ushort num297 = uniffi_loro_ffi_checksum_method_subscriber_on_diff();
		if (num297 != 37249)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_subscriber_on_diff` checksum `37249`, library returned `{num297}`");
		}
		ushort num298 = uniffi_loro_ffi_checksum_method_subscription_detach();
		if (num298 != 63099)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_subscription_detach` checksum `63099`, library returned `{num298}`");
		}
		ushort num299 = uniffi_loro_ffi_checksum_method_subscription_unsubscribe();
		if (num299 != 46858)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_subscription_unsubscribe` checksum `46858`, library returned `{num299}`");
		}
		ushort num300 = uniffi_loro_ffi_checksum_method_undomanager_add_exclude_origin_prefix();
		if (num300 != 63740)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_add_exclude_origin_prefix` checksum `63740`, library returned `{num300}`");
		}
		ushort num301 = uniffi_loro_ffi_checksum_method_undomanager_can_redo();
		if (num301 != 35475)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_can_redo` checksum `35475`, library returned `{num301}`");
		}
		ushort num302 = uniffi_loro_ffi_checksum_method_undomanager_can_undo();
		if (num302 != 42348)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_can_undo` checksum `42348`, library returned `{num302}`");
		}
		ushort num303 = uniffi_loro_ffi_checksum_method_undomanager_group_end();
		if (num303 != 37541)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_group_end` checksum `37541`, library returned `{num303}`");
		}
		ushort num304 = uniffi_loro_ffi_checksum_method_undomanager_group_start();
		if (num304 != 64372)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_group_start` checksum `64372`, library returned `{num304}`");
		}
		ushort num305 = uniffi_loro_ffi_checksum_method_undomanager_peer();
		if (num305 != 45180)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_peer` checksum `45180`, library returned `{num305}`");
		}
		ushort num306 = uniffi_loro_ffi_checksum_method_undomanager_record_new_checkpoint();
		if (num306 != 12209)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_record_new_checkpoint` checksum `12209`, library returned `{num306}`");
		}
		ushort num307 = uniffi_loro_ffi_checksum_method_undomanager_redo();
		if (num307 != 52607)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_redo` checksum `52607`, library returned `{num307}`");
		}
		ushort num308 = uniffi_loro_ffi_checksum_method_undomanager_redo_count();
		if (num308 != 12383)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_redo_count` checksum `12383`, library returned `{num308}`");
		}
		ushort num309 = uniffi_loro_ffi_checksum_method_undomanager_set_max_undo_steps();
		if (num309 != 20261)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_set_max_undo_steps` checksum `20261`, library returned `{num309}`");
		}
		ushort num310 = uniffi_loro_ffi_checksum_method_undomanager_set_merge_interval();
		if (num310 != 34577)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_set_merge_interval` checksum `34577`, library returned `{num310}`");
		}
		ushort num311 = uniffi_loro_ffi_checksum_method_undomanager_set_on_pop();
		if (num311 != 54502)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_set_on_pop` checksum `54502`, library returned `{num311}`");
		}
		ushort num312 = uniffi_loro_ffi_checksum_method_undomanager_set_on_push();
		if (num312 != 23722)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_set_on_push` checksum `23722`, library returned `{num312}`");
		}
		ushort num313 = uniffi_loro_ffi_checksum_method_undomanager_top_redo_meta();
		if (num313 != 15306)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_top_redo_meta` checksum `15306`, library returned `{num313}`");
		}
		ushort num314 = uniffi_loro_ffi_checksum_method_undomanager_top_redo_value();
		if (num314 != 57224)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_top_redo_value` checksum `57224`, library returned `{num314}`");
		}
		ushort num315 = uniffi_loro_ffi_checksum_method_undomanager_top_undo_meta();
		if (num315 != 26343)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_top_undo_meta` checksum `26343`, library returned `{num315}`");
		}
		ushort num316 = uniffi_loro_ffi_checksum_method_undomanager_top_undo_value();
		if (num316 != 42818)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_top_undo_value` checksum `42818`, library returned `{num316}`");
		}
		ushort num317 = uniffi_loro_ffi_checksum_method_undomanager_undo();
		if (num317 != 51407)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_undo` checksum `51407`, library returned `{num317}`");
		}
		ushort num318 = uniffi_loro_ffi_checksum_method_undomanager_undo_count();
		if (num318 != 43432)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_undomanager_undo_count` checksum `43432`, library returned `{num318}`");
		}
		ushort num319 = uniffi_loro_ffi_checksum_method_unsubscriber_on_unsubscribe();
		if (num319 != 64065)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_unsubscriber_on_unsubscribe` checksum `64065`, library returned `{num319}`");
		}
		ushort num320 = uniffi_loro_ffi_checksum_method_valueorcontainer_as_container();
		if (num320 != 16799)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_valueorcontainer_as_container` checksum `16799`, library returned `{num320}`");
		}
		ushort num321 = uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_counter();
		if (num321 != 36547)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_counter` checksum `36547`, library returned `{num321}`");
		}
		ushort num322 = uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_list();
		if (num322 != 46429)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_list` checksum `46429`, library returned `{num322}`");
		}
		ushort num323 = uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_map();
		if (num323 != 40964)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_map` checksum `40964`, library returned `{num323}`");
		}
		ushort num324 = uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_movable_list();
		if (num324 != 56652)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_movable_list` checksum `56652`, library returned `{num324}`");
		}
		ushort num325 = uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_text();
		if (num325 != 7756)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_text` checksum `7756`, library returned `{num325}`");
		}
		ushort num326 = uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_tree();
		if (num326 != 13237)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_tree` checksum `13237`, library returned `{num326}`");
		}
		ushort num327 = uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_unknown();
		if (num327 != 3157)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_valueorcontainer_as_loro_unknown` checksum `3157`, library returned `{num327}`");
		}
		ushort num328 = uniffi_loro_ffi_checksum_method_valueorcontainer_as_value();
		if (num328 != 16217)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_valueorcontainer_as_value` checksum `16217`, library returned `{num328}`");
		}
		ushort num329 = uniffi_loro_ffi_checksum_method_valueorcontainer_container_type();
		if (num329 != 14339)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_valueorcontainer_container_type` checksum `14339`, library returned `{num329}`");
		}
		ushort num330 = uniffi_loro_ffi_checksum_method_valueorcontainer_is_container();
		if (num330 != 13147)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_valueorcontainer_is_container` checksum `13147`, library returned `{num330}`");
		}
		ushort num331 = uniffi_loro_ffi_checksum_method_valueorcontainer_is_value();
		if (num331 != 20846)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_valueorcontainer_is_value` checksum `20846`, library returned `{num331}`");
		}
		ushort num332 = uniffi_loro_ffi_checksum_method_versionrange_clear();
		if (num332 != 22575)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionrange_clear` checksum `22575`, library returned `{num332}`");
		}
		ushort num333 = uniffi_loro_ffi_checksum_method_versionrange_contains_id();
		if (num333 != 4971)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionrange_contains_id` checksum `4971`, library returned `{num333}`");
		}
		ushort num334 = uniffi_loro_ffi_checksum_method_versionrange_contains_id_span();
		if (num334 != 52504)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionrange_contains_id_span` checksum `52504`, library returned `{num334}`");
		}
		ushort num335 = uniffi_loro_ffi_checksum_method_versionrange_contains_ops_between();
		if (num335 != 61529)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionrange_contains_ops_between` checksum `61529`, library returned `{num335}`");
		}
		ushort num336 = uniffi_loro_ffi_checksum_method_versionrange_extends_to_include_id_span();
		if (num336 != 16625)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionrange_extends_to_include_id_span` checksum `16625`, library returned `{num336}`");
		}
		ushort num337 = uniffi_loro_ffi_checksum_method_versionrange_get();
		if (num337 != 50783)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionrange_get` checksum `50783`, library returned `{num337}`");
		}
		ushort num338 = uniffi_loro_ffi_checksum_method_versionrange_get_all_ranges();
		if (num338 != 20760)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionrange_get_all_ranges` checksum `20760`, library returned `{num338}`");
		}
		ushort num339 = uniffi_loro_ffi_checksum_method_versionrange_get_peers();
		if (num339 != 40505)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionrange_get_peers` checksum `40505`, library returned `{num339}`");
		}
		ushort num340 = uniffi_loro_ffi_checksum_method_versionrange_has_overlap_with();
		if (num340 != 65383)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionrange_has_overlap_with` checksum `65383`, library returned `{num340}`");
		}
		ushort num341 = uniffi_loro_ffi_checksum_method_versionrange_insert();
		if (num341 != 44262)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionrange_insert` checksum `44262`, library returned `{num341}`");
		}
		ushort num342 = uniffi_loro_ffi_checksum_method_versionrange_is_empty();
		if (num342 != 60658)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionrange_is_empty` checksum `60658`, library returned `{num342}`");
		}
		ushort num343 = uniffi_loro_ffi_checksum_method_versionvector_diff();
		if (num343 != 2647)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_diff` checksum `2647`, library returned `{num343}`");
		}
		ushort num344 = uniffi_loro_ffi_checksum_method_versionvector_encode();
		if (num344 != 6292)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_encode` checksum `6292`, library returned `{num344}`");
		}
		ushort num345 = uniffi_loro_ffi_checksum_method_versionvector_eq();
		if (num345 != 43362)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_eq` checksum `43362`, library returned `{num345}`");
		}
		ushort num346 = uniffi_loro_ffi_checksum_method_versionvector_extend_to_include_vv();
		if (num346 != 31287)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_extend_to_include_vv` checksum `31287`, library returned `{num346}`");
		}
		ushort num347 = uniffi_loro_ffi_checksum_method_versionvector_get_last();
		if (num347 != 2350)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_get_last` checksum `2350`, library returned `{num347}`");
		}
		ushort num348 = uniffi_loro_ffi_checksum_method_versionvector_get_missing_span();
		if (num348 != 31140)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_get_missing_span` checksum `31140`, library returned `{num348}`");
		}
		ushort num349 = uniffi_loro_ffi_checksum_method_versionvector_includes_id();
		if (num349 != 60251)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_includes_id` checksum `60251`, library returned `{num349}`");
		}
		ushort num350 = uniffi_loro_ffi_checksum_method_versionvector_includes_vv();
		if (num350 != 39671)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_includes_vv` checksum `39671`, library returned `{num350}`");
		}
		ushort num351 = uniffi_loro_ffi_checksum_method_versionvector_intersect_span();
		if (num351 != 53818)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_intersect_span` checksum `53818`, library returned `{num351}`");
		}
		ushort num352 = uniffi_loro_ffi_checksum_method_versionvector_merge();
		if (num352 != 25828)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_merge` checksum `25828`, library returned `{num352}`");
		}
		ushort num353 = uniffi_loro_ffi_checksum_method_versionvector_partial_cmp();
		if (num353 != 25946)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_partial_cmp` checksum `25946`, library returned `{num353}`");
		}
		ushort num354 = uniffi_loro_ffi_checksum_method_versionvector_set_end();
		if (num354 != 54771)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_set_end` checksum `54771`, library returned `{num354}`");
		}
		ushort num355 = uniffi_loro_ffi_checksum_method_versionvector_set_last();
		if (num355 != 28435)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_set_last` checksum `28435`, library returned `{num355}`");
		}
		ushort num356 = uniffi_loro_ffi_checksum_method_versionvector_to_hashmap();
		if (num356 != 56398)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_to_hashmap` checksum `56398`, library returned `{num356}`");
		}
		ushort num357 = uniffi_loro_ffi_checksum_method_versionvector_try_update_last();
		if (num357 != 58412)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_method_versionvector_try_update_last` checksum `58412`, library returned `{num357}`");
		}
		ushort num358 = uniffi_loro_ffi_checksum_constructor_awareness_new();
		if (num358 != 18821)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_awareness_new` checksum `18821`, library returned `{num358}`");
		}
		ushort num359 = uniffi_loro_ffi_checksum_constructor_cursor_decode();
		if (num359 != 31913)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_cursor_decode` checksum `31913`, library returned `{num359}`");
		}
		ushort num360 = uniffi_loro_ffi_checksum_constructor_cursor_new();
		if (num360 != 32460)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_cursor_new` checksum `32460`, library returned `{num360}`");
		}
		ushort num361 = uniffi_loro_ffi_checksum_constructor_diffbatch_new();
		if (num361 != 22613)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_diffbatch_new` checksum `22613`, library returned `{num361}`");
		}
		ushort num362 = uniffi_loro_ffi_checksum_constructor_ephemeralstore_new();
		if (num362 != 38977)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_ephemeralstore_new` checksum `38977`, library returned `{num362}`");
		}
		ushort num363 = uniffi_loro_ffi_checksum_constructor_fractionalindex_from_bytes();
		if (num363 != 9241)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_fractionalindex_from_bytes` checksum `9241`, library returned `{num363}`");
		}
		ushort num364 = uniffi_loro_ffi_checksum_constructor_fractionalindex_from_hex_string();
		if (num364 != 44261)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_fractionalindex_from_hex_string` checksum `44261`, library returned `{num364}`");
		}
		ushort num365 = uniffi_loro_ffi_checksum_constructor_frontiers_decode();
		if (num365 != 45600)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_frontiers_decode` checksum `45600`, library returned `{num365}`");
		}
		ushort num366 = uniffi_loro_ffi_checksum_constructor_frontiers_from_id();
		if (num366 != 7560)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_frontiers_from_id` checksum `7560`, library returned `{num366}`");
		}
		ushort num367 = uniffi_loro_ffi_checksum_constructor_frontiers_from_ids();
		if (num367 != 62627)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_frontiers_from_ids` checksum `62627`, library returned `{num367}`");
		}
		ushort num368 = uniffi_loro_ffi_checksum_constructor_frontiers_new();
		if (num368 != 15591)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_frontiers_new` checksum `15591`, library returned `{num368}`");
		}
		ushort num369 = uniffi_loro_ffi_checksum_constructor_lorocounter_new();
		if (num369 != 21553)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_lorocounter_new` checksum `21553`, library returned `{num369}`");
		}
		ushort num370 = uniffi_loro_ffi_checksum_constructor_lorodoc_new();
		if (num370 != 34555)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_lorodoc_new` checksum `34555`, library returned `{num370}`");
		}
		ushort num371 = uniffi_loro_ffi_checksum_constructor_lorolist_new();
		if (num371 != 41972)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_lorolist_new` checksum `41972`, library returned `{num371}`");
		}
		ushort num372 = uniffi_loro_ffi_checksum_constructor_loromap_new();
		if (num372 != 27269)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_loromap_new` checksum `27269`, library returned `{num372}`");
		}
		ushort num373 = uniffi_loro_ffi_checksum_constructor_loromovablelist_new();
		if (num373 != 1821)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_loromovablelist_new` checksum `1821`, library returned `{num373}`");
		}
		ushort num374 = uniffi_loro_ffi_checksum_constructor_lorotext_new();
		if (num374 != 9497)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_lorotext_new` checksum `9497`, library returned `{num374}`");
		}
		ushort num375 = uniffi_loro_ffi_checksum_constructor_lorotree_new();
		if (num375 != 27388)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_lorotree_new` checksum `27388`, library returned `{num375}`");
		}
		ushort num376 = uniffi_loro_ffi_checksum_constructor_styleconfigmap_default_rich_text_config();
		if (num376 != 65451)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_styleconfigmap_default_rich_text_config` checksum `65451`, library returned `{num376}`");
		}
		ushort num377 = uniffi_loro_ffi_checksum_constructor_styleconfigmap_new();
		if (num377 != 63349)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_styleconfigmap_new` checksum `63349`, library returned `{num377}`");
		}
		ushort num378 = uniffi_loro_ffi_checksum_constructor_undomanager_new();
		if (num378 != 31025)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_undomanager_new` checksum `31025`, library returned `{num378}`");
		}
		ushort num379 = uniffi_loro_ffi_checksum_constructor_versionrange_from_vv();
		if (num379 != 10426)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_versionrange_from_vv` checksum `10426`, library returned `{num379}`");
		}
		ushort num380 = uniffi_loro_ffi_checksum_constructor_versionrange_new();
		if (num380 != 7136)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_versionrange_new` checksum `7136`, library returned `{num380}`");
		}
		ushort num381 = uniffi_loro_ffi_checksum_constructor_versionvector_decode();
		if (num381 != 54438)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_versionvector_decode` checksum `54438`, library returned `{num381}`");
		}
		ushort num382 = uniffi_loro_ffi_checksum_constructor_versionvector_new();
		if (num382 != 28341)
		{
			throw new UniffiContractChecksumException($"Pro.Loro: uniffi bindings expected function `uniffi_loro_ffi_checksum_constructor_versionvector_new` checksum `28341`, library returned `{num382}`");
		}
	}
}
