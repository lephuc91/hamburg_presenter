using System;

namespace Pro.Loro;

internal class FfiConverterTypeSubscription : FfiConverter<Subscription, IntPtr>
{
	public static FfiConverterTypeSubscription INSTANCE = new FfiConverterTypeSubscription();

	public override IntPtr Lower(Subscription value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override Subscription Lift(IntPtr value)
	{
		return new Subscription(value);
	}

	public override Subscription Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(Subscription value)
	{
		return 8;
	}

	public override void Write(Subscription value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
