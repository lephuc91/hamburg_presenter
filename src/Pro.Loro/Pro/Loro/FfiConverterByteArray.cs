namespace Pro.Loro;

internal class FfiConverterByteArray : FfiConverterRustBuffer<byte[]>
{
	public static FfiConverterByteArray INSTANCE = new FfiConverterByteArray();

	public override byte[] Read(BigEndianStream stream)
	{
		int length = stream.ReadInt();
		return stream.ReadBytes(length);
	}

	public override int AllocationSize(byte[] value)
	{
		return 4 + value.Length;
	}

	public override void Write(byte[] value, BigEndianStream stream)
	{
		stream.WriteInt(value.Length);
		stream.WriteBytes(value);
	}
}
