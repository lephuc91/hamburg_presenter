using System;

namespace Pro.Loro;

internal class FfiConverterTypeLocalEphemeralListener : FfiConverter<LocalEphemeralListener, IntPtr>
{
	public ConcurrentHandleMap<LocalEphemeralListener> handleMap = new ConcurrentHandleMap<LocalEphemeralListener>();

	public static FfiConverterTypeLocalEphemeralListener INSTANCE = new FfiConverterTypeLocalEphemeralListener();

	public override IntPtr Lower(LocalEphemeralListener value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override LocalEphemeralListener Lift(IntPtr value)
	{
		return new LocalEphemeralListenerImpl(value);
	}

	public override LocalEphemeralListener Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(LocalEphemeralListener value)
	{
		return 8;
	}

	public override void Write(LocalEphemeralListener value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
