using System;
using System.Text;

namespace Pro.Loro;

internal class FfiConverterString : FfiConverter<string, RustBuffer>
{
	public static FfiConverterString INSTANCE = new FfiConverterString();

	public override string Lift(RustBuffer value)
	{
		try
		{
			byte[] bytes = value.AsStream().ReadBytes(Convert.ToInt32(value.len));
			return Encoding.UTF8.GetString(bytes);
		}
		finally
		{
			RustBuffer.Free(value);
		}
	}

	public override string Read(BigEndianStream stream)
	{
		int length = stream.ReadInt();
		byte[] bytes = stream.ReadBytes(length);
		return Encoding.UTF8.GetString(bytes);
	}

	public override RustBuffer Lower(string value)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(value);
		RustBuffer result = RustBuffer.Alloc(bytes.Length);
		result.AsWriteableStream().WriteBytes(bytes);
		return result;
	}

	public override int AllocationSize(string value)
	{
		int byteCount = Encoding.UTF8.GetByteCount(value);
		return 4 + byteCount;
	}

	public override void Write(string value, BigEndianStream stream)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(value);
		stream.WriteInt(bytes.Length);
		stream.WriteBytes(bytes);
	}
}
