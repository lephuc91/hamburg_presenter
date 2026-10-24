namespace Pro.Loro;

internal class FfiConverterTypeTreeExternalDiff : FfiConverterRustBuffer<TreeExternalDiff>
{
	public static FfiConverterRustBuffer<TreeExternalDiff> INSTANCE = new FfiConverterTypeTreeExternalDiff();

	public override TreeExternalDiff Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new TreeExternalDiff.Create(FfiConverterTypeTreeParentId.INSTANCE.Read(stream), FfiConverterUInt32.INSTANCE.Read(stream), FfiConverterString.INSTANCE.Read(stream)), 
			2 => new TreeExternalDiff.Move(FfiConverterTypeTreeParentId.INSTANCE.Read(stream), FfiConverterUInt32.INSTANCE.Read(stream), FfiConverterString.INSTANCE.Read(stream), FfiConverterTypeTreeParentId.INSTANCE.Read(stream), FfiConverterUInt32.INSTANCE.Read(stream)), 
			3 => new TreeExternalDiff.Delete(FfiConverterTypeTreeParentId.INSTANCE.Read(stream), FfiConverterUInt32.INSTANCE.Read(stream)), 
			_ => throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeTreeExternalDiff.Read()"), 
		};
	}

	public override int AllocationSize(TreeExternalDiff value)
	{
		if (!(value is TreeExternalDiff.Create create))
		{
			if (!(value is TreeExternalDiff.Move move))
			{
				if (value is TreeExternalDiff.Delete delete)
				{
					return 4 + FfiConverterTypeTreeParentId.INSTANCE.AllocationSize(delete.oldParent) + FfiConverterUInt32.INSTANCE.AllocationSize(delete.oldIndex);
				}
				throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeTreeExternalDiff.AllocationSize()");
			}
			return 4 + FfiConverterTypeTreeParentId.INSTANCE.AllocationSize(move.parent) + FfiConverterUInt32.INSTANCE.AllocationSize(move.index) + FfiConverterString.INSTANCE.AllocationSize(move.fractionalIndex) + FfiConverterTypeTreeParentId.INSTANCE.AllocationSize(move.oldParent) + FfiConverterUInt32.INSTANCE.AllocationSize(move.oldIndex);
		}
		return 4 + FfiConverterTypeTreeParentId.INSTANCE.AllocationSize(create.parent) + FfiConverterUInt32.INSTANCE.AllocationSize(create.index) + FfiConverterString.INSTANCE.AllocationSize(create.fractionalIndex);
	}

	public override void Write(TreeExternalDiff value, BigEndianStream stream)
	{
		if (!(value is TreeExternalDiff.Create create))
		{
			if (!(value is TreeExternalDiff.Move move))
			{
				if (!(value is TreeExternalDiff.Delete delete))
				{
					throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeTreeExternalDiff.Write()");
				}
				stream.WriteInt(3);
				FfiConverterTypeTreeParentId.INSTANCE.Write(delete.oldParent, stream);
				FfiConverterUInt32.INSTANCE.Write(delete.oldIndex, stream);
			}
			else
			{
				stream.WriteInt(2);
				FfiConverterTypeTreeParentId.INSTANCE.Write(move.parent, stream);
				FfiConverterUInt32.INSTANCE.Write(move.index, stream);
				FfiConverterString.INSTANCE.Write(move.fractionalIndex, stream);
				FfiConverterTypeTreeParentId.INSTANCE.Write(move.oldParent, stream);
				FfiConverterUInt32.INSTANCE.Write(move.oldIndex, stream);
			}
		}
		else
		{
			stream.WriteInt(1);
			FfiConverterTypeTreeParentId.INSTANCE.Write(create.parent, stream);
			FfiConverterUInt32.INSTANCE.Write(create.index, stream);
			FfiConverterString.INSTANCE.Write(create.fractionalIndex, stream);
		}
	}
}
