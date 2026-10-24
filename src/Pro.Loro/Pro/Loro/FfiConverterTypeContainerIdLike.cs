using System;

namespace Pro.Loro;

internal class FfiConverterTypeContainerIdLike : FfiConverter<ContainerIdLike, IntPtr>
{
	public ConcurrentHandleMap<ContainerIdLike> handleMap = new ConcurrentHandleMap<ContainerIdLike>();

	public static FfiConverterTypeContainerIdLike INSTANCE = new FfiConverterTypeContainerIdLike();

	public override IntPtr Lower(ContainerIdLike value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override ContainerIdLike Lift(IntPtr value)
	{
		return new ContainerIdLikeImpl(value);
	}

	public override ContainerIdLike Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(ContainerIdLike value)
	{
		return 8;
	}

	public override void Write(ContainerIdLike value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
