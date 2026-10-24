using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class TimestampExtensions
{
	public static Pro.Entity.Timestamp ToEntityTimestamp(this Pro.SerializationInterop.RVProtoData.Timestamp timestamp)
	{
		return new Pro.Entity.Timestamp(timestamp.Seconds, timestamp.Nanos);
	}

	public static Pro.SerializationInterop.RVProtoData.Timestamp ToProtoTimestamp(this Pro.Entity.Timestamp timestamp)
	{
		return new Pro.SerializationInterop.RVProtoData.Timestamp
		{
			Seconds = timestamp.Seconds,
			Nanos = timestamp.Nanos
		};
	}
}
