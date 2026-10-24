using System;

namespace Pro.Loro;

internal abstract class FfiConverter<CsType, FfiType>
{
	public abstract CsType Lift(FfiType value);

	public abstract FfiType Lower(CsType value);

	public abstract CsType Read(BigEndianStream stream);

	public abstract int AllocationSize(CsType value);

	public abstract void Write(CsType value, BigEndianStream stream);

	public RustBuffer LowerIntoRustBuffer(CsType value)
	{
		RustBuffer rustBuffer = RustBuffer.Alloc(AllocationSize(value));
		try
		{
			BigEndianStream bigEndianStream = rustBuffer.AsWriteableStream();
			Write(value, bigEndianStream);
			rustBuffer.len = Convert.ToUInt64(bigEndianStream.Position);
			return rustBuffer;
		}
		catch
		{
			RustBuffer.Free(rustBuffer);
			throw;
		}
	}

	protected CsType LiftFromRustBuffer(RustBuffer rbuf)
	{
		BigEndianStream bigEndianStream = rbuf.AsStream();
		try
		{
			CsType result = Read(bigEndianStream);
			if (bigEndianStream.HasRemaining())
			{
				throw new InternalException("junk remaining in buffer after lifting, something is very wrong!!");
			}
			return result;
		}
		finally
		{
			RustBuffer.Free(rbuf);
		}
	}
}
