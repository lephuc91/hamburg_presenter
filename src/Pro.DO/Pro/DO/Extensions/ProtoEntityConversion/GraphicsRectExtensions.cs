using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class GraphicsRectExtensions
{
	public static Graphics.Types.Rect ToProto(this IGraphics.Types.Rect source)
	{
		return new Graphics.Types.Rect
		{
			Origin = source.Origin.ToProto(),
			Size = source.Size.ToProto()
		};
	}

	public static IGraphics.Types.Rect ToEntity(this Graphics.Types.Rect source)
	{
		return new IGraphics.Types.Rect(source.Origin.ToEntity(), source.Size.ToEntity());
	}
}
