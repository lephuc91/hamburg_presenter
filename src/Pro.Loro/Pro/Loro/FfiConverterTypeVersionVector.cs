using System;

namespace Pro.Loro;

internal class FfiConverterTypeVersionVector : FfiConverter<VersionVector, IntPtr>
{
	public static FfiConverterTypeVersionVector INSTANCE = new FfiConverterTypeVersionVector();

	public override IntPtr Lower(VersionVector value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override VersionVector Lift(IntPtr value)
	{
		return new VersionVector(value);
	}

	public override VersionVector Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(VersionVector value)
	{
		return 8;
	}

	public override void Write(VersionVector value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
