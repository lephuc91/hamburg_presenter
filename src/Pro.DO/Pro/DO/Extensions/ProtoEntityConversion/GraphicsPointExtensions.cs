using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class GraphicsPointExtensions
{
	public static Graphics.Types.Point ToProto(this IGraphics.Types.Point source)
	{
		return new Graphics.Types.Point
		{
			X = source.X,
			Y = source.Y
		};
	}

	public static IGraphics.Types.Point ToEntity(this Graphics.Types.Point source)
	{
		return new IGraphics.Types.Point(source.X, source.Y);
	}
}
