using System;

namespace Pro.Loro;

internal class FfiConverterTypePreCommitCallback : FfiConverter<PreCommitCallback, IntPtr>
{
	public ConcurrentHandleMap<PreCommitCallback> handleMap = new ConcurrentHandleMap<PreCommitCallback>();

	public static FfiConverterTypePreCommitCallback INSTANCE = new FfiConverterTypePreCommitCallback();

	public override IntPtr Lower(PreCommitCallback value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override PreCommitCallback Lift(IntPtr value)
	{
		return new PreCommitCallbackImpl(value);
	}

	public override PreCommitCallback Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(PreCommitCallback value)
	{
		return 8;
	}

	public override void Write(PreCommitCallback value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
