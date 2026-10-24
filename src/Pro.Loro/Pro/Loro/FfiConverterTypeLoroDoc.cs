using System;

namespace Pro.Loro;

internal class FfiConverterTypeLoroDoc : FfiConverter<LoroDoc, IntPtr>
{
	public static FfiConverterTypeLoroDoc INSTANCE = new FfiConverterTypeLoroDoc();

	public override IntPtr Lower(LoroDoc value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override LoroDoc Lift(IntPtr value)
	{
		return new LoroDoc(value);
	}

	public override LoroDoc Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(LoroDoc value)
	{
		return 8;
	}

	public override void Write(LoroDoc value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
