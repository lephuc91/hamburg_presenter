using System;

namespace Pro.Loro;

internal class FfiConverterTypeLocalUpdateCallback : FfiConverter<LocalUpdateCallback, IntPtr>
{
	public ConcurrentHandleMap<LocalUpdateCallback> handleMap = new ConcurrentHandleMap<LocalUpdateCallback>();

	public static FfiConverterTypeLocalUpdateCallback INSTANCE = new FfiConverterTypeLocalUpdateCallback();

	public override IntPtr Lower(LocalUpdateCallback value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override LocalUpdateCallback Lift(IntPtr value)
	{
		return new LocalUpdateCallbackImpl(value);
	}

	public override LocalUpdateCallback Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(LocalUpdateCallback value)
	{
		return 8;
	}

	public override void Write(LocalUpdateCallback value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
