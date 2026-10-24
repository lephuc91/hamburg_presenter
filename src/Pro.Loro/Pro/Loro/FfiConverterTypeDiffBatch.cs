using System;

namespace Pro.Loro;

internal class FfiConverterTypeDiffBatch : FfiConverter<DiffBatch, IntPtr>
{
	public static FfiConverterTypeDiffBatch INSTANCE = new FfiConverterTypeDiffBatch();

	public override IntPtr Lower(DiffBatch value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override DiffBatch Lift(IntPtr value)
	{
		return new DiffBatch(value);
	}

	public override DiffBatch Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(DiffBatch value)
	{
		return 8;
	}

	public override void Write(DiffBatch value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
