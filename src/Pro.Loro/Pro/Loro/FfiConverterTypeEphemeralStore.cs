using System;

namespace Pro.Loro;

internal class FfiConverterTypeEphemeralStore : FfiConverter<EphemeralStore, IntPtr>
{
	public static FfiConverterTypeEphemeralStore INSTANCE = new FfiConverterTypeEphemeralStore();

	public override IntPtr Lower(EphemeralStore value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override EphemeralStore Lift(IntPtr value)
	{
		return new EphemeralStore(value);
	}

	public override EphemeralStore Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(EphemeralStore value)
	{
		return 8;
	}

	public override void Write(EphemeralStore value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
