namespace Pro.Loro;

internal class FfiConverterTypeJsonPathError : FfiConverterRustBuffer<JsonPathException>, CallStatusErrorHandler<JsonPathException>
{
	public static FfiConverterTypeJsonPathError INSTANCE = new FfiConverterTypeJsonPathError();

	public override JsonPathException Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new JsonPathException.InvalidJsonPath(FfiConverterString.INSTANCE.Read(stream)), 
			2 => new JsonPathException.EvaluationException(FfiConverterString.INSTANCE.Read(stream)), 
			_ => throw new InternalException($"invalid error value '{num}' in FfiConverterTypeJsonPathError.Read()"), 
		};
	}

	public override int AllocationSize(JsonPathException value)
	{
		return 4 + FfiConverterString.INSTANCE.AllocationSize(value.Message);
	}

	public override void Write(JsonPathException value, BigEndianStream stream)
	{
		if (!(value is JsonPathException.InvalidJsonPath))
		{
			if (!(value is JsonPathException.EvaluationException))
			{
				throw new InternalException($"invalid error value '{value}' in FfiConverterTypeJsonPathError.Write()");
			}
			stream.WriteInt(2);
		}
		else
		{
			stream.WriteInt(1);
		}
	}
}
