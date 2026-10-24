namespace Pro.Loro;

internal class FfiConverterTypeFirstCommitFromPeerPayload : FfiConverterRustBuffer<FirstCommitFromPeerPayload>
{
	public static FfiConverterTypeFirstCommitFromPeerPayload INSTANCE = new FfiConverterTypeFirstCommitFromPeerPayload();

	public override FirstCommitFromPeerPayload Read(BigEndianStream stream)
	{
		return new FirstCommitFromPeerPayload(FfiConverterUInt64.INSTANCE.Read(stream));
	}

	public override int AllocationSize(FirstCommitFromPeerPayload value)
	{
		return FfiConverterUInt64.INSTANCE.AllocationSize(value.peer);
	}

	public override void Write(FirstCommitFromPeerPayload value, BigEndianStream stream)
	{
		FfiConverterUInt64.INSTANCE.Write(value.peer, stream);
	}
}
