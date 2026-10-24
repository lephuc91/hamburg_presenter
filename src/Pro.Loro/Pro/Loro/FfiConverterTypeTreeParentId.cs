namespace Pro.Loro;

internal class FfiConverterTypeTreeParentId : FfiConverterRustBuffer<TreeParentId>
{
	public static FfiConverterRustBuffer<TreeParentId> INSTANCE = new FfiConverterTypeTreeParentId();

	public override TreeParentId Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new TreeParentId.Node(FfiConverterTypeTreeID.INSTANCE.Read(stream)), 
			2 => new TreeParentId.Root(), 
			3 => new TreeParentId.Deleted(), 
			4 => new TreeParentId.Unexist(), 
			_ => throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeTreeParentId.Read()"), 
		};
	}

	public override int AllocationSize(TreeParentId value)
	{
		if (!(value is TreeParentId.Node node))
		{
			if (!(value is TreeParentId.Root))
			{
				if (!(value is TreeParentId.Deleted))
				{
					if (value is TreeParentId.Unexist)
					{
						return 4;
					}
					throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeTreeParentId.AllocationSize()");
				}
				return 4;
			}
			return 4;
		}
		return 4 + FfiConverterTypeTreeID.INSTANCE.AllocationSize(node.id);
	}

	public override void Write(TreeParentId value, BigEndianStream stream)
	{
		if (!(value is TreeParentId.Node node))
		{
			if (!(value is TreeParentId.Root))
			{
				if (!(value is TreeParentId.Deleted))
				{
					if (!(value is TreeParentId.Unexist))
					{
						throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeTreeParentId.Write()");
					}
					stream.WriteInt(4);
				}
				else
				{
					stream.WriteInt(3);
				}
			}
			else
			{
				stream.WriteInt(2);
			}
		}
		else
		{
			stream.WriteInt(1);
			FfiConverterTypeTreeID.INSTANCE.Write(node.id, stream);
		}
	}
}
