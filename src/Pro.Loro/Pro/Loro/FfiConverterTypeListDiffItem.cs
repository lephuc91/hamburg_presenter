namespace Pro.Loro;

internal class FfiConverterTypeListDiffItem : FfiConverterRustBuffer<ListDiffItem>
{
	public static FfiConverterRustBuffer<ListDiffItem> INSTANCE = new FfiConverterTypeListDiffItem();

	public override ListDiffItem Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new ListDiffItem.Insert(FfiConverterSequenceTypeValueOrContainer.INSTANCE.Read(stream), FfiConverterBoolean.INSTANCE.Read(stream)), 
			2 => new ListDiffItem.Delete(FfiConverterUInt32.INSTANCE.Read(stream)), 
			3 => new ListDiffItem.Retain(FfiConverterUInt32.INSTANCE.Read(stream)), 
			_ => throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeListDiffItem.Read()"), 
		};
	}

	public override int AllocationSize(ListDiffItem value)
	{
		if (!(value is ListDiffItem.Insert insert))
		{
			if (!(value is ListDiffItem.Delete delete))
			{
				if (value is ListDiffItem.Retain retain)
				{
					return 4 + FfiConverterUInt32.INSTANCE.AllocationSize(retain.retain);
				}
				throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeListDiffItem.AllocationSize()");
			}
			return 4 + FfiConverterUInt32.INSTANCE.AllocationSize(delete.delete);
		}
		return 4 + FfiConverterSequenceTypeValueOrContainer.INSTANCE.AllocationSize(insert.insert) + FfiConverterBoolean.INSTANCE.AllocationSize(insert.isMove);
	}

	public override void Write(ListDiffItem value, BigEndianStream stream)
	{
		if (!(value is ListDiffItem.Insert insert))
		{
			if (!(value is ListDiffItem.Delete delete))
			{
				if (!(value is ListDiffItem.Retain retain))
				{
					throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeListDiffItem.Write()");
				}
				stream.WriteInt(3);
				FfiConverterUInt32.INSTANCE.Write(retain.retain, stream);
			}
			else
			{
				stream.WriteInt(2);
				FfiConverterUInt32.INSTANCE.Write(delete.delete, stream);
			}
		}
		else
		{
			stream.WriteInt(1);
			FfiConverterSequenceTypeValueOrContainer.INSTANCE.Write(insert.insert, stream);
			FfiConverterBoolean.INSTANCE.Write(insert.isMove, stream);
		}
	}
}
