using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class GraphicsSizeExtensions
{
	public static Graphics.Types.Size ToProto(this IGraphics.Types.Size source)
	{
		return new Graphics.Types.Size
		{
			Width = source.Width,
			Height = source.Height
		};
	}

	public static IGraphics.Types.Size ToEntity(this Graphics.Types.Size source)
	{
		return new IGraphics.Types.Size(source.Width, source.Height);
	}
}
