namespace Pro.Loro;

internal class FfiConverterOptionalTypeSubscription : FfiConverterRustBuffer<Subscription?>
{
	public static FfiConverterOptionalTypeSubscription INSTANCE = new FfiConverterOptionalTypeSubscription();

	public override Subscription? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeSubscription.INSTANCE.Read(stream);
	}

	public override int AllocationSize(Subscription? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeSubscription.INSTANCE.AllocationSize(value);
	}

	public override void Write(Subscription? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeSubscription.INSTANCE.Write(value, stream);
	}
}
