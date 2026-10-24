namespace Pro.Loro;

internal class FfiConverterTypeAbsolutePosition : FfiConverterRustBuffer<AbsolutePosition>
{
	public static FfiConverterTypeAbsolutePosition INSTANCE = new FfiConverterTypeAbsolutePosition();

	public override AbsolutePosition Read(BigEndianStream stream)
	{
		return new AbsolutePosition(FfiConverterUInt32.INSTANCE.Read(stream), FfiConverterTypeSide.INSTANCE.Read(stream));
	}

	public override int AllocationSize(AbsolutePosition value)
	{
		return FfiConverterUInt32.INSTANCE.AllocationSize(value.pos) + FfiConverterTypeSide.INSTANCE.AllocationSize(value.side);
	}

	public override void Write(AbsolutePosition value, BigEndianStream stream)
	{
		FfiConverterUInt32.INSTANCE.Write(value.pos, stream);
		FfiConverterTypeSide.INSTANCE.Write(value.side, stream);
	}
}
