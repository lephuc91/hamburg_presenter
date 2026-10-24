namespace Pro.Loro;

internal class FfiConverterTypeIndex : FfiConverterRustBuffer<Index>
{
	public static FfiConverterRustBuffer<Index> INSTANCE = new FfiConverterTypeIndex();

	public override Index Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new Index.Key(FfiConverterString.INSTANCE.Read(stream)), 
			2 => new Index.Seq(FfiConverterUInt32.INSTANCE.Read(stream)), 
			3 => new Index.Node(FfiConverterTypeTreeID.INSTANCE.Read(stream)), 
			_ => throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeIndex.Read()"), 
		};
	}

	public override int AllocationSize(Index value)
	{
		if (!(value is Index.Key key))
		{
			if (!(value is Index.Seq seq))
			{
				if (value is Index.Node node)
				{
					return 4 + FfiConverterTypeTreeID.INSTANCE.AllocationSize(node.target);
				}
				throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeIndex.AllocationSize()");
			}
			return 4 + FfiConverterUInt32.INSTANCE.AllocationSize(seq.index);
		}
		return 4 + FfiConverterString.INSTANCE.AllocationSize(key.key);
	}

	public override void Write(Index value, BigEndianStream stream)
	{
		if (!(value is Index.Key key))
		{
			if (!(value is Index.Seq seq))
			{
				if (!(value is Index.Node node))
				{
					throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeIndex.Write()");
				}
				stream.WriteInt(3);
				FfiConverterTypeTreeID.INSTANCE.Write(node.target, stream);
			}
			else
			{
				stream.WriteInt(2);
				FfiConverterUInt32.INSTANCE.Write(seq.index, stream);
			}
		}
		else
		{
			stream.WriteInt(1);
			FfiConverterString.INSTANCE.Write(key.key, stream);
		}
	}
}
