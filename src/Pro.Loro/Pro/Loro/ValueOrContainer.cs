using System;
using System.Threading;

namespace Pro.Loro;

public class ValueOrContainer : IValueOrContainer, IDisposable
{
	protected IntPtr pointer;

	private int _wasDestroyed;

	private long _callCounter = 1L;

	public ValueOrContainer(IntPtr pointer)
	{
		this.pointer = pointer;
	}

	~ValueOrContainer()
	{
		Destroy();
	}

	protected void FreeRustArcPtr()
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.uniffi_loro_ffi_fn_free_valueorcontainer(pointer, ref status);
		});
	}

	protected IntPtr CloneRustArcPtr()
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_clone_valueorcontainer(pointer, ref status);
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

	public ContainerId? AsContainer()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeContainerID.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_valueorcontainer_as_container(thisPtr, ref _status);
		})));
	}

	public LoroCounter? AsLoroCounter()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroCounter.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_counter(thisPtr, ref _status);
		})));
	}

	public LoroList? AsLoroList()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroList.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_list(thisPtr, ref _status);
		})));
	}

	public LoroMap? AsLoroMap()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroMap.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_map(thisPtr, ref _status);
		})));
	}

	public LoroMovableList? AsLoroMovableList()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroMovableList.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_movable_list(thisPtr, ref _status);
		})));
	}

	public LoroText? AsLoroText()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroText.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_text(thisPtr, ref _status);
		})));
	}

	public LoroTree? AsLoroTree()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroTree.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_tree(thisPtr, ref _status);
		})));
	}

	public LoroUnknown? AsLoroUnknown()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroUnknown.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_valueorcontainer_as_loro_unknown(thisPtr, ref _status);
		})));
	}

	public LoroValue? AsValue()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeLoroValue.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_valueorcontainer_as_value(thisPtr, ref _status);
		})));
	}

	public ContainerType? ContainerType()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterOptionalTypeContainerType.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_valueorcontainer_container_type(thisPtr, ref _status);
		})));
	}

	public bool IsContainer()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_valueorcontainer_is_container(thisPtr, ref _status);
		})));
	}

	public bool IsValue()
	{
		return CallWithPointer((IntPtr thisPtr) => FfiConverterBoolean.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_method_valueorcontainer_is_value(thisPtr, ref _status);
		})));
	}
}
