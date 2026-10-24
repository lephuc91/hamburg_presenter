using System;

namespace Pro.Loro;

internal class FfiConverterTypeLoroValueLike : FfiConverter<LoroValueLike, IntPtr>
{
	public ConcurrentHandleMap<LoroValueLike> handleMap = new ConcurrentHandleMap<LoroValueLike>();

	public static FfiConverterTypeLoroValueLike INSTANCE = new FfiConverterTypeLoroValueLike();

	public override IntPtr Lower(LoroValueLike value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override LoroValueLike Lift(IntPtr value)
	{
		return new LoroValueLikeImpl(value);
	}

	public override LoroValueLike Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(LoroValueLike value)
	{
		return 8;
	}

	public override void Write(LoroValueLike value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
