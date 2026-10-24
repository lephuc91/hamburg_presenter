using System;
using System.Threading;

namespace Pro.Loro;

public class ChangeModifier : IChangeModifier, IDisposable
{
	protected IntPtr pointer;

	private int _wasDestroyed;

	private long _callCounter = 1L;

	public ChangeModifier(IntPtr pointer)
	{
		this.pointer = pointer;
	}

	~ChangeModifier()
	{
		Destroy();
	}

	protected void FreeRustArcPtr()
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.uniffi_loro_ffi_fn_free_changemodifier(pointer, ref status);
		});
	}

	protected IntPtr CloneRustArcPtr()
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_clone_changemodifier(pointer, ref status);
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

	public void SetMessage(string msg)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_changemodifier_set_message(thisPtr, FfiConverterString.INSTANCE.Lower(msg), ref _status);
			});
		});
	}

	public void SetTimestamp(long timestamp)
	{
		CallWithPointer(delegate(IntPtr thisPtr)
		{
			_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
			{
				_UniFFILib.uniffi_loro_ffi_fn_method_changemodifier_set_timestamp(thisPtr, FfiConverterInt64.INSTANCE.Lower(timestamp), ref _status);
			});
		});
	}
}
