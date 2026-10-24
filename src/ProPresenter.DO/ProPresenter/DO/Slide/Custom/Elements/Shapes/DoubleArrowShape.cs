using System.Collections.Generic;
using Pro.Common.Mathematics;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Shapes;

public class DoubleArrowShape : RightArrowShape
{
	private const double MinCornerX = 0.5;

	private const double MaxCornerX = 1.0;

	protected override string DisplayName => LocalizedStrings.Get("GLOBAL_SHAPE_DOUBLE_ARROW");

	public DoubleArrowShape(IProPresenterDOFactoryProvider factoryProvider, string containerId)
		: base(factoryProvider, containerId)
	{
	}

	private DoubleArrowShape(IMediaFactory mediaFactory, ITextDocumentFactory textDocumentFactory, string containerId)
		: base(mediaFactory, textDocumentFactory, containerId)
	{
	}

	protected override IEnumerable<BezierPoint> GeneratePoints()
	{
		Vector2<double> corner = base.Corner;
		return new global::_003C_003Ez__ReadOnlyArray<BezierPoint>(new BezierPoint[10]
		{
			new BezierPoint(new Vector2<double>(0.0, 0.5)),
			new BezierPoint(new Vector2<double>(1.0 - corner.X, 0.0)),
			new BezierPoint(new Vector2<double>(1.0 - corner.X, corner.Y)),
			new BezierPoint(new Vector2<double>(corner.X, corner.Y)),
			new BezierPoint(new Vector2<double>(corner.X, 0.0)),
			new BezierPoint(new Vector2<double>(1.0, 0.5)),
			new BezierPoint(new Vector2<double>(corner.X, 1.0)),
			new BezierPoint(new Vector2<double>(corner.X, 1.0 - corner.Y)),
			new BezierPoint(new Vector2<double>(1.0 - corner.X, 1.0 - corner.Y)),
			new BezierPoint(new Vector2<double>(1.0 - corner.X, 1.0))
		});
	}

	public override SlideElementBase Clone()
	{
		DoubleArrowShape doubleArrowShape = new DoubleArrowShape(base.MediaFactory, base.TextDocumentFactory, base.ContainerId);
		CopyProperties(doubleArrowShape);
		return doubleArrowShape;
	}

	protected override Vector2<double> ClampCorner(Vector2<double> corner)
	{
		return new Vector2<double>(corner.X.Clamp(0.5, 1.0), corner.Y.Clamp(0.0, 0.5));
	}

	protected override Graphics.Types.Path.Types.Shape SerializeShape()
	{
		Graphics.Types.Path.Types.Shape shape = base.SerializeShape();
		shape.Type = Graphics.Types.Path.Types.Shape.Types.Type.DoubleArrow;
		return shape;
	}

	protected override bool IsSyncCompatibleShape(IGraphics.Types.IPath.Types.Shape.Types.Type type)
	{
		return type == IGraphics.Types.IPath.Types.Shape.Types.Type.DoubleArrow;
	}
}
