using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class ColorExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Color ToProtoColor(this Pro.Entity.Color source)
	{
		return new Pro.SerializationInterop.RVProtoData.Color
		{
			Red = source.Red,
			Green = source.Green,
			Blue = source.Blue,
			Alpha = source.Alpha
		};
	}

	public static Pro.Entity.Color ToEntityColor(this Pro.SerializationInterop.RVProtoData.Color source)
	{
		return new Pro.Entity.Color(source.Red, source.Green, source.Blue, source.Alpha);
	}
}
