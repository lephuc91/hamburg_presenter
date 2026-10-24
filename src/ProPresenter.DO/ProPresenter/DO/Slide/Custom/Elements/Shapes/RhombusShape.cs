using System.Collections.Generic;
using Pro.Common.Mathematics;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Shapes;

public class RhombusShape : ClosedBezierPath
{
	public override string DefaultShapeName => LocalizedStrings.Get("GLOBAL_SHAPE_RHOMBUS");

	public RhombusShape(IProPresenterDOFactoryProvider factoryProvider, string containerId)
		: base(factoryProvider.MediaFactory, factoryProvider.TextDocumentFactory, containerId)
	{
	}

	private RhombusShape(IMediaFactory mediaFactory, ITextDocumentFactory textDocumentFactory, string containerId)
		: base(mediaFactory, textDocumentFactory, containerId)
	{
	}

	protected override IEnumerable<BezierPoint> GeneratePoints()
	{
		return new global::_003C_003Ez__ReadOnlyArray<BezierPoint>(new BezierPoint[4]
		{
			new BezierPoint(new Vector2<double>(0.5, 0.0)),
			new BezierPoint(new Vector2<double>(1.0, 0.5)),
			new BezierPoint(new Vector2<double>(0.5, 1.0)),
			new BezierPoint(new Vector2<double>(0.0, 0.5))
		});
	}

	public override SlideElementBase Clone()
	{
		RhombusShape rhombusShape = new RhombusShape(base.MediaFactory, base.TextDocumentFactory, base.ContainerId);
		CopyProperties(rhombusShape);
		return rhombusShape;
	}

	protected override Graphics.Types.Path.Types.Shape SerializeShape()
	{
		return new Graphics.Types.Path.Types.Shape
		{
			Type = Graphics.Types.Path.Types.Shape.Types.Type.Rhombus
		};
	}

	protected override bool IsSyncCompatibleShape(IGraphics.Types.IPath.Types.Shape.Types.Type type)
	{
		return type == IGraphics.Types.IPath.Types.Shape.Types.Type.Rhombus;
	}
}
