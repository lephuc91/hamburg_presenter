using System;

namespace Pro.Loro;

internal class FfiConverterTypeConfigure : FfiConverter<Configure, IntPtr>
{
	public static FfiConverterTypeConfigure INSTANCE = new FfiConverterTypeConfigure();

	public override IntPtr Lower(Configure value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override Configure Lift(IntPtr value)
	{
		return new Configure(value);
	}

	public override Configure Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(Configure value)
	{
		return 8;
	}

	public override void Write(Configure value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
