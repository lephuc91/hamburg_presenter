namespace Pro.Loro;

internal class FfiConverterTypeDiff : FfiConverterRustBuffer<Diff>
{
	public static FfiConverterRustBuffer<Diff> INSTANCE = new FfiConverterTypeDiff();

	public override Diff Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new Diff.List(FfiConverterSequenceTypeListDiffItem.INSTANCE.Read(stream)), 
			2 => new Diff.Text(FfiConverterSequenceTypeTextDelta.INSTANCE.Read(stream)), 
			3 => new Diff.Map(FfiConverterTypeMapDelta.INSTANCE.Read(stream)), 
			4 => new Diff.Tree(FfiConverterTypeTreeDiff.INSTANCE.Read(stream)), 
			5 => new Diff.Counter(FfiConverterDouble.INSTANCE.Read(stream)), 
			6 => new Diff.Unknown(), 
			_ => throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeDiff.Read()"), 
		};
	}

	public override int AllocationSize(Diff value)
	{
		if (!(value is Diff.List list))
		{
			if (!(value is Diff.Text text))
			{
				if (!(value is Diff.Map map))
				{
					if (!(value is Diff.Tree tree))
					{
						if (!(value is Diff.Counter counter))
						{
							if (value is Diff.Unknown)
							{
								return 4;
							}
							throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeDiff.AllocationSize()");
						}
						return 4 + FfiConverterDouble.INSTANCE.AllocationSize(counter.diff);
					}
					return 4 + FfiConverterTypeTreeDiff.INSTANCE.AllocationSize(tree.diff);
				}
				return 4 + FfiConverterTypeMapDelta.INSTANCE.AllocationSize(map.diff);
			}
			return 4 + FfiConverterSequenceTypeTextDelta.INSTANCE.AllocationSize(text.diff);
		}
		return 4 + FfiConverterSequenceTypeListDiffItem.INSTANCE.AllocationSize(list.diff);
	}

	public override void Write(Diff value, BigEndianStream stream)
	{
		if (!(value is Diff.List list))
		{
			if (!(value is Diff.Text text))
			{
				if (!(value is Diff.Map map))
				{
					if (!(value is Diff.Tree tree))
					{
						if (!(value is Diff.Counter counter))
						{
							if (!(value is Diff.Unknown))
							{
								throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeDiff.Write()");
							}
							stream.WriteInt(6);
						}
						else
						{
							stream.WriteInt(5);
							FfiConverterDouble.INSTANCE.Write(counter.diff, stream);
						}
					}
					else
					{
						stream.WriteInt(4);
						FfiConverterTypeTreeDiff.INSTANCE.Write(tree.diff, stream);
					}
				}
				else
				{
					stream.WriteInt(3);
					FfiConverterTypeMapDelta.INSTANCE.Write(map.diff, stream);
				}
			}
			else
			{
				stream.WriteInt(2);
				FfiConverterSequenceTypeTextDelta.INSTANCE.Write(text.diff, stream);
			}
		}
		else
		{
			stream.WriteInt(1);
			FfiConverterSequenceTypeListDiffItem.INSTANCE.Write(list.diff, stream);
		}
	}
}
