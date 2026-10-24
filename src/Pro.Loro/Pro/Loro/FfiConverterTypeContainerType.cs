namespace Pro.Loro;

internal class FfiConverterTypeContainerType : FfiConverterRustBuffer<ContainerType>
{
	public static FfiConverterRustBuffer<ContainerType> INSTANCE = new FfiConverterTypeContainerType();

	public override ContainerType Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new ContainerType.Text(), 
			2 => new ContainerType.Map(), 
			3 => new ContainerType.List(), 
			4 => new ContainerType.MovableList(), 
			5 => new ContainerType.Tree(), 
			6 => new ContainerType.Counter(), 
			7 => new ContainerType.Unknown(FfiConverterUInt8.INSTANCE.Read(stream)), 
			_ => throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeContainerType.Read()"), 
		};
	}

	public override int AllocationSize(ContainerType value)
	{
		if (!(value is ContainerType.Text))
		{
			if (!(value is ContainerType.Map))
			{
				if (!(value is ContainerType.List))
				{
					if (!(value is ContainerType.MovableList))
					{
						if (!(value is ContainerType.Tree))
						{
							if (!(value is ContainerType.Counter))
							{
								if (value is ContainerType.Unknown unknown)
								{
									return 4 + FfiConverterUInt8.INSTANCE.AllocationSize(unknown.kind);
								}
								throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeContainerType.AllocationSize()");
							}
							return 4;
						}
						return 4;
					}
					return 4;
				}
				return 4;
			}
			return 4;
		}
		return 4;
	}

	public override void Write(ContainerType value, BigEndianStream stream)
	{
		if (!(value is ContainerType.Text))
		{
			if (!(value is ContainerType.Map))
			{
				if (!(value is ContainerType.List))
				{
					if (!(value is ContainerType.MovableList))
					{
						if (!(value is ContainerType.Tree))
						{
							if (!(value is ContainerType.Counter))
							{
								if (!(value is ContainerType.Unknown unknown))
								{
									throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeContainerType.Write()");
								}
								stream.WriteInt(7);
								FfiConverterUInt8.INSTANCE.Write(unknown.kind, stream);
							}
							else
							{
								stream.WriteInt(6);
							}
						}
						else
						{
							stream.WriteInt(5);
						}
					}
					else
					{
						stream.WriteInt(4);
					}
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
		}
	}
}
