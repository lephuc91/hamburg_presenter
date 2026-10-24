using System;

namespace Pro.Loro;

internal class FfiConverterTypeLoroUnknown : FfiConverter<LoroUnknown, IntPtr>
{
	public static FfiConverterTypeLoroUnknown INSTANCE = new FfiConverterTypeLoroUnknown();

	public override IntPtr Lower(LoroUnknown value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override LoroUnknown Lift(IntPtr value)
	{
		return new LoroUnknown(value);
	}

	public override LoroUnknown Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(LoroUnknown value)
	{
		return 8;
	}

	public override void Write(LoroUnknown value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
