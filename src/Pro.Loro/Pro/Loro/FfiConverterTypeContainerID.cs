namespace Pro.Loro;

internal class FfiConverterTypeContainerID : FfiConverterRustBuffer<ContainerId>
{
	public static FfiConverterRustBuffer<ContainerId> INSTANCE = new FfiConverterTypeContainerID();

	public override ContainerId Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new ContainerId.Root(FfiConverterString.INSTANCE.Read(stream), FfiConverterTypeContainerType.INSTANCE.Read(stream)), 
			2 => new ContainerId.Normal(FfiConverterUInt64.INSTANCE.Read(stream), FfiConverterInt32.INSTANCE.Read(stream), FfiConverterTypeContainerType.INSTANCE.Read(stream)), 
			_ => throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeContainerID.Read()"), 
		};
	}

	public override int AllocationSize(ContainerId value)
	{
		if (!(value is ContainerId.Root root))
		{
			if (value is ContainerId.Normal normal)
			{
				return 4 + FfiConverterUInt64.INSTANCE.AllocationSize(normal.peer) + FfiConverterInt32.INSTANCE.AllocationSize(normal.counter) + FfiConverterTypeContainerType.INSTANCE.AllocationSize(normal.containerType);
			}
			throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeContainerID.AllocationSize()");
		}
		return 4 + FfiConverterString.INSTANCE.AllocationSize(root.name) + FfiConverterTypeContainerType.INSTANCE.AllocationSize(root.containerType);
	}

	public override void Write(ContainerId value, BigEndianStream stream)
	{
		if (!(value is ContainerId.Root root))
		{
			if (!(value is ContainerId.Normal normal))
			{
				throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeContainerID.Write()");
			}
			stream.WriteInt(2);
			FfiConverterUInt64.INSTANCE.Write(normal.peer, stream);
			FfiConverterInt32.INSTANCE.Write(normal.counter, stream);
			FfiConverterTypeContainerType.INSTANCE.Write(normal.containerType, stream);
		}
		else
		{
			stream.WriteInt(1);
			FfiConverterString.INSTANCE.Write(root.name, stream);
			FfiConverterTypeContainerType.INSTANCE.Write(root.containerType, stream);
		}
	}
}
