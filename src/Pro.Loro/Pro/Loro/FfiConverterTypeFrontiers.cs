using System;

namespace Pro.Loro;

internal class FfiConverterTypeFrontiers : FfiConverter<Frontiers, IntPtr>
{
	public static FfiConverterTypeFrontiers INSTANCE = new FfiConverterTypeFrontiers();

	public override IntPtr Lower(Frontiers value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override Frontiers Lift(IntPtr value)
	{
		return new Frontiers(value);
	}

	public override Frontiers Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(Frontiers value)
	{
		return 8;
	}

	public override void Write(Frontiers value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
