using System;

namespace Pro.Loro;

internal class FfiConverterTypeFirstCommitFromPeerCallback : FfiConverter<FirstCommitFromPeerCallback, IntPtr>
{
	public ConcurrentHandleMap<FirstCommitFromPeerCallback> handleMap = new ConcurrentHandleMap<FirstCommitFromPeerCallback>();

	public static FfiConverterTypeFirstCommitFromPeerCallback INSTANCE = new FfiConverterTypeFirstCommitFromPeerCallback();

	public override IntPtr Lower(FirstCommitFromPeerCallback value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override FirstCommitFromPeerCallback Lift(IntPtr value)
	{
		return new FirstCommitFromPeerCallbackImpl(value);
	}

	public override FirstCommitFromPeerCallback Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(FirstCommitFromPeerCallback value)
	{
		return 8;
	}

	public override void Write(FirstCommitFromPeerCallback value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
