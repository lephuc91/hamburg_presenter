using System;

namespace Pro.Loro;

internal class FfiConverterTypeLoroList : FfiConverter<LoroList, IntPtr>
{
	public static FfiConverterTypeLoroList INSTANCE = new FfiConverterTypeLoroList();

	public override IntPtr Lower(LoroList value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override LoroList Lift(IntPtr value)
	{
		return new LoroList(value);
	}

	public override LoroList Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(LoroList value)
	{
		return 8;
	}

	public override void Write(LoroList value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
