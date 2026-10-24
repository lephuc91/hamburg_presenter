using System;

namespace Pro.Loro;

internal class FfiConverterTypeLoroTree : FfiConverter<LoroTree, IntPtr>
{
	public static FfiConverterTypeLoroTree INSTANCE = new FfiConverterTypeLoroTree();

	public override IntPtr Lower(LoroTree value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override LoroTree Lift(IntPtr value)
	{
		return new LoroTree(value);
	}

	public override LoroTree Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(LoroTree value)
	{
		return 8;
	}

	public override void Write(LoroTree value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
