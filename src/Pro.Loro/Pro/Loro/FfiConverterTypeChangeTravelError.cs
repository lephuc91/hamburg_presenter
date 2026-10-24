namespace Pro.Loro;

internal class FfiConverterTypeChangeTravelError : FfiConverterRustBuffer<ChangeTravelException>, CallStatusErrorHandler<ChangeTravelException>
{
	public static FfiConverterTypeChangeTravelError INSTANCE = new FfiConverterTypeChangeTravelError();

	public override ChangeTravelException Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new ChangeTravelException.TargetIdNotFound(FfiConverterString.INSTANCE.Read(stream)), 
			2 => new ChangeTravelException.TargetVersionNotIncluded(FfiConverterString.INSTANCE.Read(stream)), 
			_ => throw new InternalException($"invalid error value '{num}' in FfiConverterTypeChangeTravelError.Read()"), 
		};
	}

	public override int AllocationSize(ChangeTravelException value)
	{
		return 4 + FfiConverterString.INSTANCE.AllocationSize(value.Message);
	}

	public override void Write(ChangeTravelException value, BigEndianStream stream)
	{
		if (!(value is ChangeTravelException.TargetIdNotFound))
		{
			if (!(value is ChangeTravelException.TargetVersionNotIncluded))
			{
				throw new InternalException($"invalid error value '{value}' in FfiConverterTypeChangeTravelError.Write()");
			}
			stream.WriteInt(2);
		}
		else
		{
			stream.WriteInt(1);
		}
	}
}
