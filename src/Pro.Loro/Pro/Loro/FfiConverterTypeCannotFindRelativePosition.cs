namespace Pro.Loro;

internal class FfiConverterTypeCannotFindRelativePosition : FfiConverterRustBuffer<CannotFindRelativePosition>, CallStatusErrorHandler<CannotFindRelativePosition>
{
	public static FfiConverterTypeCannotFindRelativePosition INSTANCE = new FfiConverterTypeCannotFindRelativePosition();

	public override CannotFindRelativePosition Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new CannotFindRelativePosition.ContainerDeleted(FfiConverterString.INSTANCE.Read(stream)), 
			2 => new CannotFindRelativePosition.HistoryCleared(FfiConverterString.INSTANCE.Read(stream)), 
			3 => new CannotFindRelativePosition.IdNotFound(FfiConverterString.INSTANCE.Read(stream)), 
			_ => throw new InternalException($"invalid error value '{num}' in FfiConverterTypeCannotFindRelativePosition.Read()"), 
		};
	}

	public override int AllocationSize(CannotFindRelativePosition value)
	{
		return 4 + FfiConverterString.INSTANCE.AllocationSize(value.Message);
	}

	public override void Write(CannotFindRelativePosition value, BigEndianStream stream)
	{
		if (!(value is CannotFindRelativePosition.ContainerDeleted))
		{
			if (!(value is CannotFindRelativePosition.HistoryCleared))
			{
				if (!(value is CannotFindRelativePosition.IdNotFound))
				{
					throw new InternalException($"invalid error value '{value}' in FfiConverterTypeCannotFindRelativePosition.Write()");
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
