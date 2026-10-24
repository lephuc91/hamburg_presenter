using System;
using Pro.Entity;
using ProPresenter.DO.DependencyInjection;

namespace ProPresenter.DO.Slide.Custom.Elements.Shapes;

public static class ShapeHelper
{
	public static BezierPath CreateShape(this IGraphics.Types.IPath path, IProPresenterDOFactoryProvider factoryProvider, string containerId)
	{
		return CreateShape(path.Shape.Value, path.Closed.Value, factoryProvider, containerId);
	}

	public static BezierPath CreateShape(IGraphics.Types.IPath.Types.Shape shape, bool closed, IProPresenterDOFactoryProvider factoryProvider, string containerId)
	{
		BezierPath result = shape.Type switch
		{
			IGraphics.Types.IPath.Types.Shape.Types.Type.Rectangle => new RectangleShape(factoryProvider, containerId), 
			IGraphics.Types.IPath.Types.Shape.Types.Type.Ellipse => new EllipseShape(factoryProvider, containerId), 
			IGraphics.Types.IPath.Types.Shape.Types.Type.IsoscelesTriangle => new IsoscelesTriangleShape(factoryProvider, containerId), 
			IGraphics.Types.IPath.Types.Shape.Types.Type.RightTriangle => new RightTriangleShape(factoryProvider, containerId), 
			IGraphics.Types.IPath.Types.Shape.Types.Type.Rhombus => new RhombusShape(factoryProvider, containerId), 
			IGraphics.Types.IPath.Types.Shape.Types.Type.Star => new StarShape(factoryProvider, containerId)
			{
				CenterRadius = ((IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Star)shape.AdditionalData)._Star.InnerRadius,
				PointCount = (int)((IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Star)shape.AdditionalData)._Star.NumberPoints
			}, 
			IGraphics.Types.IPath.Types.Shape.Types.Type.Polygon => new PolygonShape(factoryProvider, containerId)
			{
				PointCount = (int)((IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Polygon)shape.AdditionalData)._Polygon.NumberSides
			}, 
			IGraphics.Types.IPath.Types.Shape.Types.Type.Custom => new CustomShape(factoryProvider.MediaFactory, factoryProvider.TextDocumentFactory, containerId), 
			IGraphics.Types.IPath.Types.Shape.Types.Type.RightArrow => new RightArrowShape(factoryProvider, containerId)
			{
				Corner = ((IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Arrow)shape.AdditionalData)._Arrow.Corner.ToVector2d()
			}, 
			IGraphics.Types.IPath.Types.Shape.Types.Type.DoubleArrow => new DoubleArrowShape(factoryProvider, containerId)
			{
				Corner = ((IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Arrow)shape.AdditionalData)._Arrow.Corner.ToVector2d()
			}, 
			IGraphics.Types.IPath.Types.Shape.Types.Type.RoundedRectangle => new RoundedRectangleShape(factoryProvider, containerId)
			{
				CornerRadius = ((IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.RoundedRectangle)shape.AdditionalData)._RoundedRectangle.Roundness
			}, 
			_ => throw new NotSupportedException($"Unsupported shape type {shape.Type}"), 
		};
		if (!closed)
		{
			result = new OpenBezierPath();
		}
		return result;
	}

	public static IGraphics.Types.IPath.Types.Shape CreateEntityShape(this SlideElementBase element)
	{
		if (!(element is RectangleShape))
		{
			if (!(element is EllipseShape))
			{
				if (!(element is IsoscelesTriangleShape))
				{
					if (!(element is RightTriangleShape))
					{
						if (!(element is RhombusShape))
						{
							if (!(element is StarShape starShape))
							{
								if (!(element is PolygonShape polygonShape))
								{
									if (!(element is DoubleArrowShape doubleArrowShape))
									{
										if (!(element is CustomShape))
										{
											if (!(element is RightArrowShape rightArrowShape))
											{
												if (element is RoundedRectangleShape roundedRectangleShape)
												{
													return new IGraphics.Types.IPath.Types.Shape(IGraphics.Types.IPath.Types.Shape.Types.Type.RoundedRectangle, new IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.RoundedRectangle(new IGraphics.Types.IPath.Types.Shape.Types.RoundedRectangle(roundedRectangleShape.CornerRadius)));
												}
												return new IGraphics.Types.IPath.Types.Shape(IGraphics.Types.IPath.Types.Shape.Types.Type.Custom, new IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Polygon(new IGraphics.Types.IPath.Types.Shape.Types.Polygon(0u)));
											}
											return new IGraphics.Types.IPath.Types.Shape(IGraphics.Types.IPath.Types.Shape.Types.Type.RightArrow, new IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Arrow(new IGraphics.Types.IPath.Types.Shape.Types.Arrow(rightArrowShape.Corner.ToPoint())));
										}
										return new IGraphics.Types.IPath.Types.Shape(IGraphics.Types.IPath.Types.Shape.Types.Type.Custom, new IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Polygon(new IGraphics.Types.IPath.Types.Shape.Types.Polygon(0u)));
									}
									return new IGraphics.Types.IPath.Types.Shape(IGraphics.Types.IPath.Types.Shape.Types.Type.DoubleArrow, new IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Arrow(new IGraphics.Types.IPath.Types.Shape.Types.Arrow(doubleArrowShape.Corner.ToPoint())));
								}
								return new IGraphics.Types.IPath.Types.Shape(IGraphics.Types.IPath.Types.Shape.Types.Type.Polygon, new IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Polygon(new IGraphics.Types.IPath.Types.Shape.Types.Polygon((uint)polygonShape.PointCount)));
							}
							return new IGraphics.Types.IPath.Types.Shape(IGraphics.Types.IPath.Types.Shape.Types.Type.Star, new IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Star(new IGraphics.Types.IPath.Types.Shape.Types.Star(1.0 - starShape.CenterRadius, (uint)starShape.PointCount)));
						}
						return new IGraphics.Types.IPath.Types.Shape(IGraphics.Types.IPath.Types.Shape.Types.Type.Rhombus, new IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Polygon(new IGraphics.Types.IPath.Types.Shape.Types.Polygon(4u)));
					}
					return new IGraphics.Types.IPath.Types.Shape(IGraphics.Types.IPath.Types.Shape.Types.Type.RightTriangle, new IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Polygon(new IGraphics.Types.IPath.Types.Shape.Types.Polygon(3u)));
				}
				return new IGraphics.Types.IPath.Types.Shape(IGraphics.Types.IPath.Types.Shape.Types.Type.IsoscelesTriangle, new IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Polygon(new IGraphics.Types.IPath.Types.Shape.Types.Polygon(3u)));
			}
			return new IGraphics.Types.IPath.Types.Shape(IGraphics.Types.IPath.Types.Shape.Types.Type.Ellipse, new IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Polygon(new IGraphics.Types.IPath.Types.Shape.Types.Polygon(0u)));
		}
		return new IGraphics.Types.IPath.Types.Shape(IGraphics.Types.IPath.Types.Shape.Types.Type.Rectangle, new IGraphics.Types.IPath.Types.Shape.Types.AdditionalData.Polygon(new IGraphics.Types.IPath.Types.Shape.Types.Polygon(4u)));
	}
}
