using System;

namespace Pro.Loro;

internal class FfiConverterTypeLoroMovableList : FfiConverter<LoroMovableList, IntPtr>
{
	public static FfiConverterTypeLoroMovableList INSTANCE = new FfiConverterTypeLoroMovableList();

	public override IntPtr Lower(LoroMovableList value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override LoroMovableList Lift(IntPtr value)
	{
		return new LoroMovableList(value);
	}

	public override LoroMovableList Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(LoroMovableList value)
	{
		return 8;
	}

	public override void Write(LoroMovableList value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
