namespace Pro.Loro;

internal class FfiConverterOptionalTypeLoroMovableList : FfiConverterRustBuffer<LoroMovableList?>
{
	public static FfiConverterOptionalTypeLoroMovableList INSTANCE = new FfiConverterOptionalTypeLoroMovableList();

	public override LoroMovableList? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeLoroMovableList.INSTANCE.Read(stream);
	}

	public override int AllocationSize(LoroMovableList? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeLoroMovableList.INSTANCE.AllocationSize(value);
	}

	public override void Write(LoroMovableList? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeLoroMovableList.INSTANCE.Write(value, stream);
	}
}
