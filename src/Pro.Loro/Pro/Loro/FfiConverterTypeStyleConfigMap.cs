using System;

namespace Pro.Loro;

internal class FfiConverterTypeStyleConfigMap : FfiConverter<StyleConfigMap, IntPtr>
{
	public static FfiConverterTypeStyleConfigMap INSTANCE = new FfiConverterTypeStyleConfigMap();

	public override IntPtr Lower(StyleConfigMap value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override StyleConfigMap Lift(IntPtr value)
	{
		return new StyleConfigMap(value);
	}

	public override StyleConfigMap Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(StyleConfigMap value)
	{
		return 8;
	}

	public override void Write(StyleConfigMap value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
