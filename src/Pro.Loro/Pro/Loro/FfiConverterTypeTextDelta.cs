namespace Pro.Loro;

internal class FfiConverterTypeTextDelta : FfiConverterRustBuffer<TextDelta>
{
	public static FfiConverterRustBuffer<TextDelta> INSTANCE = new FfiConverterTypeTextDelta();

	public override TextDelta Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new TextDelta.Retain(FfiConverterUInt32.INSTANCE.Read(stream), FfiConverterOptionalDictionaryStringTypeLoroValue.INSTANCE.Read(stream)), 
			2 => new TextDelta.Insert(FfiConverterString.INSTANCE.Read(stream), FfiConverterOptionalDictionaryStringTypeLoroValue.INSTANCE.Read(stream)), 
			3 => new TextDelta.Delete(FfiConverterUInt32.INSTANCE.Read(stream)), 
			_ => throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeTextDelta.Read()"), 
		};
	}

	public override int AllocationSize(TextDelta value)
	{
		if (!(value is TextDelta.Retain retain))
		{
			if (!(value is TextDelta.Insert insert))
			{
				if (value is TextDelta.Delete delete)
				{
					return 4 + FfiConverterUInt32.INSTANCE.AllocationSize(delete.delete);
				}
				throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeTextDelta.AllocationSize()");
			}
			return 4 + FfiConverterString.INSTANCE.AllocationSize(insert.insert) + FfiConverterOptionalDictionaryStringTypeLoroValue.INSTANCE.AllocationSize(insert.attributes);
		}
		return 4 + FfiConverterUInt32.INSTANCE.AllocationSize(retain.retain) + FfiConverterOptionalDictionaryStringTypeLoroValue.INSTANCE.AllocationSize(retain.attributes);
	}

	public override void Write(TextDelta value, BigEndianStream stream)
	{
		if (!(value is TextDelta.Retain retain))
		{
			if (!(value is TextDelta.Insert insert))
			{
				if (!(value is TextDelta.Delete delete))
				{
					throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeTextDelta.Write()");
				}
				stream.WriteInt(3);
				FfiConverterUInt32.INSTANCE.Write(delete.delete, stream);
			}
			else
			{
				stream.WriteInt(2);
				FfiConverterString.INSTANCE.Write(insert.insert, stream);
				FfiConverterOptionalDictionaryStringTypeLoroValue.INSTANCE.Write(insert.attributes, stream);
			}
		}
		else
		{
			stream.WriteInt(1);
			FfiConverterUInt32.INSTANCE.Write(retain.retain, stream);
			FfiConverterOptionalDictionaryStringTypeLoroValue.INSTANCE.Write(retain.attributes, stream);
		}
	}
}
