using System.Collections.Generic;
using Pro.Common.Mathematics;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Shapes;

public class EllipseShape : ClosedBezierPath
{
	public override string DefaultShapeName => LocalizedStrings.Get("GLOBAL_SHAPE_ELLIPSE");

	public EllipseShape(IProPresenterDOFactoryProvider factoryProvider, string containerId)
		: this(factoryProvider.MediaFactory, factoryProvider.TextDocumentFactory, containerId)
	{
	}

	private EllipseShape(IMediaFactory mediaFactory, ITextDocumentFactory textDocumentFactory, string containerId)
		: base(mediaFactory, textDocumentFactory, containerId)
	{
	}

	protected override IEnumerable<BezierPoint> GeneratePoints()
	{
		double num = 0.5 * Kappa.Value;
		return new global::_003C_003Ez__ReadOnlyArray<BezierPoint>(new BezierPoint[4]
		{
			new BezierPoint
			{
				IsCurved = true,
				Position = new Vector2<double>(0.5, 0.0),
				Q0 = new Vector2<double>(0.5 - num, 0.0),
				Q1 = new Vector2<double>(0.5 + num, 0.0)
			},
			new BezierPoint
			{
				IsCurved = true,
				Position = new Vector2<double>(1.0, 0.5),
				Q0 = new Vector2<double>(1.0, 0.5 - num),
				Q1 = new Vector2<double>(1.0, 0.5 + num)
			},
			new BezierPoint
			{
				IsCurved = true,
				Position = new Vector2<double>(0.5, 1.0),
				Q0 = new Vector2<double>(0.5 + num, 1.0),
				Q1 = new Vector2<double>(0.5 - num, 1.0)
			},
			new BezierPoint
			{
				IsCurved = true,
				Position = new Vector2<double>(0.0, 0.5),
				Q0 = new Vector2<double>(0.0, 0.5 + num),
				Q1 = new Vector2<double>(0.0, 0.5 - num)
			}
		});
	}

	public override SlideElementBase Clone()
	{
		EllipseShape ellipseShape = new EllipseShape(base.MediaFactory, base.TextDocumentFactory, base.ContainerId);
		CopyProperties(ellipseShape);
		return ellipseShape;
	}

	protected override Graphics.Types.Path.Types.Shape SerializeShape()
	{
		return new Graphics.Types.Path.Types.Shape
		{
			Type = Graphics.Types.Path.Types.Shape.Types.Type.Ellipse
		};
	}

	protected override bool IsSyncCompatibleShape(IGraphics.Types.IPath.Types.Shape.Types.Type type)
	{
		return type == IGraphics.Types.IPath.Types.Shape.Types.Type.Ellipse;
	}
}
