using System;

namespace Pro.Loro;

internal class FfiConverterTypeChangeAncestorsTraveler : FfiConverter<ChangeAncestorsTraveler, IntPtr>
{
	public ConcurrentHandleMap<ChangeAncestorsTraveler> handleMap = new ConcurrentHandleMap<ChangeAncestorsTraveler>();

	public static FfiConverterTypeChangeAncestorsTraveler INSTANCE = new FfiConverterTypeChangeAncestorsTraveler();

	public override IntPtr Lower(ChangeAncestorsTraveler value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override ChangeAncestorsTraveler Lift(IntPtr value)
	{
		return new ChangeAncestorsTravelerImpl(value);
	}

	public override ChangeAncestorsTraveler Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(ChangeAncestorsTraveler value)
	{
		return 8;
	}

	public override void Write(ChangeAncestorsTraveler value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
