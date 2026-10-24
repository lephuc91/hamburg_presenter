namespace Pro.Loro;

internal class FfiConverterTypeLoroEncodeError : FfiConverterRustBuffer<LoroEncodeException>, CallStatusErrorHandler<LoroEncodeException>
{
	public static FfiConverterTypeLoroEncodeError INSTANCE = new FfiConverterTypeLoroEncodeError();

	public override LoroEncodeException Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new LoroEncodeException.FrontiersNotFound(FfiConverterString.INSTANCE.Read(stream)), 
			2 => new LoroEncodeException.ShallowSnapshotIncompatibleWithOldFormat(FfiConverterString.INSTANCE.Read(stream)), 
			3 => new LoroEncodeException.UnknownContainer(FfiConverterString.INSTANCE.Read(stream)), 
			_ => throw new InternalException($"invalid error value '{num}' in FfiConverterTypeLoroEncodeError.Read()"), 
		};
	}

	public override int AllocationSize(LoroEncodeException value)
	{
		return 4 + FfiConverterString.INSTANCE.AllocationSize(value.Message);
	}

	public override void Write(LoroEncodeException value, BigEndianStream stream)
	{
		if (!(value is LoroEncodeException.FrontiersNotFound))
		{
			if (!(value is LoroEncodeException.ShallowSnapshotIncompatibleWithOldFormat))
			{
				if (!(value is LoroEncodeException.UnknownContainer))
				{
					throw new InternalException($"invalid error value '{value}' in FfiConverterTypeLoroEncodeError.Write()");
				}
				stream.WriteInt(3);
			}
			else
			{
				stream.WriteInt(2);
			}
		}
		else
		{
			stream.WriteInt(1);
		}
	}
}
