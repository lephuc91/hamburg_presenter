using System;

namespace Pro.Loro;

internal class FfiConverterTypeLoroText : FfiConverter<LoroText, IntPtr>
{
	public static FfiConverterTypeLoroText INSTANCE = new FfiConverterTypeLoroText();

	public override IntPtr Lower(LoroText value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override LoroText Lift(IntPtr value)
	{
		return new LoroText(value);
	}

	public override LoroText Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(LoroText value)
	{
		return 8;
	}

	public override void Write(LoroText value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
