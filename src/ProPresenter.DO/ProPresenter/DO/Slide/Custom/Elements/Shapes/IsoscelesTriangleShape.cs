using System.Collections.Generic;
using Pro.Common.Mathematics;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Shapes;

public class IsoscelesTriangleShape : ClosedBezierPath
{
	public override string DefaultShapeName => LocalizedStrings.Get("GLOBAL_SHAPE_ISOSCELES_TRIANGLE");

	public IsoscelesTriangleShape(IProPresenterDOFactoryProvider factoryProvider, string containerId)
		: this(factoryProvider.MediaFactory, factoryProvider.TextDocumentFactory, containerId)
	{
	}

	private IsoscelesTriangleShape(IMediaFactory mediaFactory, ITextDocumentFactory textDocumentFactory, string containerId)
		: base(mediaFactory, textDocumentFactory, containerId)
	{
	}

	protected override IEnumerable<BezierPoint> GeneratePoints()
	{
		return new global::_003C_003Ez__ReadOnlyArray<BezierPoint>(new BezierPoint[3]
		{
			new BezierPoint(new Vector2<double>(0.5, 0.0)),
			new BezierPoint(new Vector2<double>(1.0, 1.0)),
			new BezierPoint(new Vector2<double>(0.0, 1.0))
		});
	}

	public override SlideElementBase Clone()
	{
		IsoscelesTriangleShape isoscelesTriangleShape = new IsoscelesTriangleShape(base.MediaFactory, base.TextDocumentFactory, base.ContainerId);
		CopyProperties(isoscelesTriangleShape);
		return isoscelesTriangleShape;
	}

	protected override Graphics.Types.Path.Types.Shape SerializeShape()
	{
		return new Graphics.Types.Path.Types.Shape
		{
			Type = Graphics.Types.Path.Types.Shape.Types.Type.IsoscelesTriangle
		};
	}

	protected override bool IsSyncCompatibleShape(IGraphics.Types.IPath.Types.Shape.Types.Type type)
	{
		return type == IGraphics.Types.IPath.Types.Shape.Types.Type.IsoscelesTriangle;
	}
}
