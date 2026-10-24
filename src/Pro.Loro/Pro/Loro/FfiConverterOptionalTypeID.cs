namespace Pro.Loro;

internal class FfiConverterOptionalTypeID : FfiConverterRustBuffer<Id?>
{
	public static FfiConverterOptionalTypeID INSTANCE = new FfiConverterOptionalTypeID();

	public override Id? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeID.INSTANCE.Read(stream);
	}

	public override int AllocationSize(Id? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeID.INSTANCE.AllocationSize(value);
	}

	public override void Write(Id? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeID.INSTANCE.Write(value, stream);
	}
}
