using System;

namespace Pro.Loro;

internal class FfiConverterTypeLoroMap : FfiConverter<LoroMap, IntPtr>
{
	public static FfiConverterTypeLoroMap INSTANCE = new FfiConverterTypeLoroMap();

	public override IntPtr Lower(LoroMap value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override LoroMap Lift(IntPtr value)
	{
		return new LoroMap(value);
	}

	public override LoroMap Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(LoroMap value)
	{
		return 8;
	}

	public override void Write(LoroMap value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
