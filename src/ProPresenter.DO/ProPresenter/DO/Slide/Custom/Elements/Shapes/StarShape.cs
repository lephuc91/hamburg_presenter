using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.DO.Utility;
using Pro.Editor.Canvas.Handles;
using Pro.Editor.Canvas.ToolTips;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Shapes;

public class StarShape : PolygonShape
{
	private const double MinRadius = 0.0;

	private const double MaxRadius = 1.0;

	private double _centerRadius = 0.5;

	private readonly ShapeToolTip _toolTip = new ShapeToolTip();

	public override string SlidePopoverLabel => LocalizedStrings.Get("EDITOR_POPOVER_STAR_POINT_COUNT_title");

	public override string DefaultShapeName => LocalizedStrings.Get("GLOBAL_SHAPE_STAR");

	public double CenterRadius
	{
		get
		{
			return _centerRadius;
		}
		set
		{
			double num = value.Clamp(0.0, 1.0);
			if (_centerRadius != num)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementCenterRadius), this, "CenterRadius", _centerRadius, num);
				_centerRadius = num;
				InvalidatePoints();
				OnDataModified();
				OnPropertyChanged("CenterRadius");
			}
		}
	}

	public StarShape(IProPresenterDOFactoryProvider factoryProvider, string containerId)
		: this(factoryProvider.MediaFactory, factoryProvider.TextDocumentFactory, containerId)
	{
	}

	private StarShape(IMediaFactory mediaFactory, ITextDocumentFactory textDocumentFactory, string containerId)
		: base(mediaFactory, textDocumentFactory, containerId)
	{
		base.CustomHandlesCollection.Add(new ControlHandleData(GetCenterRadiusHandlePosition, CenterRadiusHandleDragged, DidCenterRadiusHandleMove, _toolTip));
	}

	protected override IEnumerable<BezierPoint> GeneratePoints()
	{
		List<BezierPoint> list = new List<BezierPoint>();
		double num = 360.0 / ((double)base.PointCount * 2.0);
		Vector2<double> vector = new Vector2<double>(0.5, 0.0);
		Vector2<double> vector2 = new Vector2<double>(0.5, CenterRadius / 2.0);
		bool flag = true;
		for (double num2 = 0.0; num2 < 360.0; num2 += num)
		{
			list.Add(new BezierPoint((flag ? vector : vector2).Rotate(PolygonShape.Origin, num2)));
			flag = !flag;
		}
		return list;
	}

	public override SlideElementBase Clone()
	{
		StarShape starShape = new StarShape(base.MediaFactory, base.TextDocumentFactory, base.ContainerId);
		CopyProperties(starShape);
		return starShape;
	}

	protected internal override void CopyProperties(SlideElementBase slideElement)
	{
		if (slideElement is StarShape starShape)
		{
			starShape.CenterRadius = CenterRadius;
			base.CopyProperties((SlideElementBase)starShape);
		}
		else
		{
			base.CopyProperties(slideElement);
		}
	}

	private Vector2<double> GetCenterRadiusHandlePosition()
	{
		double a = 360.0 / ((double)base.PointCount * 2.0);
		Vector2<double> point = new Vector2<double>(0.5, CenterRadius / 2.0).Rotate(PolygonShape.Origin, a);
		return base.FlipMode.FlipPoint(point);
	}

	private void CenterRadiusHandleDragged(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint)
	{
		double num = 360.0 / ((double)base.PointCount * 2.0);
		if (base.FlipMode.HasFlag(ElementFlipMode.Horizontal))
		{
			num -= 2.0 * num;
		}
		if (base.FlipMode.HasFlag(ElementFlipMode.Vertical))
		{
			num += 2.0 * num;
		}
		CenterRadius = currentPoint.Rotate(PolygonShape.Origin, 0.0 - num).Y * 2.0;
		_toolTip.TooltipLabel = LocalizedStrings.Get("EDITOR_POPOVER_RADIUS_label", new object[1] { (int)((1.0 - CenterRadius) * 100.0) });
	}

	protected override Graphics.Types.Path.Types.Shape SerializeShape()
	{
		return new Graphics.Types.Path.Types.Shape
		{
			Type = Graphics.Types.Path.Types.Shape.Types.Type.Star,
			Star = new Graphics.Types.Path.Types.Shape.Types.Star
			{
				InnerRadius = 1.0 - CenterRadius,
				NumberPoints = (uint)base.PointCount
			}
		};
	}

	protected override void DeserializeShape(Graphics.Types.Path.Types.Shape shape)
	{
		base.PointCount = (int)shape.Star.NumberPoints;
		CenterRadius = shape.Star.InnerRadius;
	}

	protected override void OnPointsDeserialized(BezierPoint[] points)
	{
		base.PointCount = points.Length / 2;
		CenterRadius = CalculateInnerRadiusForStar(points);
	}

	private static bool DidCenterRadiusHandleMove(PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "FlipMode":
		case "CenterRadius":
		case "PointCount":
			return true;
		default:
			return false;
		}
	}

	private static double CalculateInnerRadiusForStar(BezierPoint[] points)
	{
		double num = 1.0;
		for (int i = 0; i < points.Length; i++)
		{
			num = Math.Min(points[i].Position.Distance(PolygonShape.Origin), num);
		}
		return 1.0 - num * 2.0;
	}

	protected override bool IsSyncCompatibleShape(IGraphics.Types.IPath.Types.Shape.Types.Type type)
	{
		return type == IGraphics.Types.IPath.Types.Shape.Types.Type.Star;
	}
}
