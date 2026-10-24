using System;

namespace Pro.Loro;

internal class FfiConverterTypeVersionRange : FfiConverter<VersionRange, IntPtr>
{
	public static FfiConverterTypeVersionRange INSTANCE = new FfiConverterTypeVersionRange();

	public override IntPtr Lower(VersionRange value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override VersionRange Lift(IntPtr value)
	{
		return new VersionRange(value);
	}

	public override VersionRange Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(VersionRange value)
	{
		return 8;
	}

	public override void Write(VersionRange value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
