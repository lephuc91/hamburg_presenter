using System;

namespace Pro.Loro;

internal class FfiConverterTypeFractionalIndex : FfiConverter<FractionalIndex, IntPtr>
{
	public static FfiConverterTypeFractionalIndex INSTANCE = new FfiConverterTypeFractionalIndex();

	public override IntPtr Lower(FractionalIndex value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override FractionalIndex Lift(IntPtr value)
	{
		return new FractionalIndex(value);
	}

	public override FractionalIndex Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(FractionalIndex value)
	{
		return 8;
	}

	public override void Write(FractionalIndex value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
