namespace Pro.Loro;

internal class FfiConverterTypePeerInfo : FfiConverterRustBuffer<PeerInfo>
{
	public static FfiConverterTypePeerInfo INSTANCE = new FfiConverterTypePeerInfo();

	public override PeerInfo Read(BigEndianStream stream)
	{
		return new PeerInfo(FfiConverterTypeLoroValue.INSTANCE.Read(stream), FfiConverterInt32.INSTANCE.Read(stream), FfiConverterInt64.INSTANCE.Read(stream));
	}

	public override int AllocationSize(PeerInfo value)
	{
		return FfiConverterTypeLoroValue.INSTANCE.AllocationSize(value.state) + FfiConverterInt32.INSTANCE.AllocationSize(value.counter) + FfiConverterInt64.INSTANCE.AllocationSize(value.timestamp);
	}

	public override void Write(PeerInfo value, BigEndianStream stream)
	{
		FfiConverterTypeLoroValue.INSTANCE.Write(value.state, stream);
		FfiConverterInt32.INSTANCE.Write(value.counter, stream);
		FfiConverterInt64.INSTANCE.Write(value.timestamp, stream);
	}
}
