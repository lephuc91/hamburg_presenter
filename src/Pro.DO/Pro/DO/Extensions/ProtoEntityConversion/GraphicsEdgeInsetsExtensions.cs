using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class GraphicsEdgeInsetsExtensions
{
	public static Graphics.Types.EdgeInsets ToProto(this IGraphics.Types.IEdgeInsets source)
	{
		return new Graphics.Types.EdgeInsets
		{
			Top = source.Top.Value,
			Left = source.Left.Value,
			Bottom = source.Bottom.Value,
			Right = source.Right.Value
		};
	}

	public static IGraphics.Types.IEdgeInsets ToEntity(this Graphics.Types.EdgeInsets source, IEntityFactory entityFactory)
	{
		IGraphics.Types.IEdgeInsets edgeInsets = entityFactory.Create<IGraphics.Types.IEdgeInsets>();
		edgeInsets.Top.Set(source.Top);
		edgeInsets.Left.Set(source.Left);
		edgeInsets.Bottom.Set(source.Bottom);
		edgeInsets.Right.Set(source.Right);
		return edgeInsets;
	}
}
