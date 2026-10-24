using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Mathematics;
using Pro.Editor;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.DO.Slide.Custom;

public static class ElementHelper
{
	public static SlideElementBase GetElementFromGraphicsType(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element element, IProPresenterDOFactoryProvider factoryProvider, string containerId)
	{
		if (((AdditionalInfo)element.Info).HasFlag(AdditionalInfo.Text))
		{
			return new TextShape(factoryProvider, containerId);
		}
		Graphics.Types.Path path = element.Element_.Path;
		switch (path.Shape?.Type ?? Graphics.Types.Path.Types.Shape.Types.Type.Custom)
		{
		case Graphics.Types.Path.Types.Shape.Types.Type.Rectangle:
			return new RectangleShape(factoryProvider, containerId);
		case Graphics.Types.Path.Types.Shape.Types.Type.Ellipse:
			return new EllipseShape(factoryProvider, containerId);
		case Graphics.Types.Path.Types.Shape.Types.Type.IsoscelesTriangle:
			return new IsoscelesTriangleShape(factoryProvider, containerId);
		case Graphics.Types.Path.Types.Shape.Types.Type.RightTriangle:
			return new RightTriangleShape(factoryProvider, containerId);
		case Graphics.Types.Path.Types.Shape.Types.Type.Rhombus:
			return new RhombusShape(factoryProvider, containerId);
		case Graphics.Types.Path.Types.Shape.Types.Type.Star:
			return new StarShape(factoryProvider, containerId);
		case Graphics.Types.Path.Types.Shape.Types.Type.Polygon:
			return new PolygonShape(factoryProvider, containerId);
		case Graphics.Types.Path.Types.Shape.Types.Type.Custom:
			if (path.Closed)
			{
				return new CustomShape(factoryProvider.MediaFactory, factoryProvider.TextDocumentFactory, containerId);
			}
			return new OpenBezierPath();
		case Graphics.Types.Path.Types.Shape.Types.Type.RightArrow:
			return new RightArrowShape(factoryProvider, containerId);
		case Graphics.Types.Path.Types.Shape.Types.Type.DoubleArrow:
			return new DoubleArrowShape(factoryProvider, containerId);
		case Graphics.Types.Path.Types.Shape.Types.Type.RoundedRectangle:
			return new RoundedRectangleShape(factoryProvider, containerId);
		default:
			throw new NotSupportedException("Unknown graphic type");
		}
	}

	public static BezierPath ConstructShape(this ShapeType shapeType, IProPresenterDOFactoryProvider factoryProvider, Vector2<double> slideSize, string containerId)
	{
		object obj = shapeType switch
		{
			ShapeType.Text => new TextShape(factoryProvider, containerId), 
			ShapeType.Rhombus => new RhombusShape(factoryProvider, containerId), 
			ShapeType.DoubleArrow => new DoubleArrowShape(factoryProvider, containerId), 
			ShapeType.Ellipse => new EllipseShape(factoryProvider, containerId), 
			ShapeType.IsoscelesTriangle => new IsoscelesTriangleShape(factoryProvider, containerId), 
			ShapeType.Polygon => new PolygonShape(factoryProvider, containerId), 
			ShapeType.Rectangle => new RectangleShape(factoryProvider, containerId), 
			ShapeType.RightArrow => new RightArrowShape(factoryProvider, containerId), 
			ShapeType.RightTriangle => new RightTriangleShape(factoryProvider, containerId), 
			ShapeType.RoundedRectangle => new RoundedRectangleShape(factoryProvider, containerId), 
			ShapeType.Star => new StarShape(factoryProvider, containerId), 
			ShapeType.Custom => new CustomShape(factoryProvider.MediaFactory, factoryProvider.TextDocumentFactory, containerId), 
			_ => throw new NotSupportedException(), 
		};
		((SimpleCanvasElement)obj).CenterAndScaleIn(slideSize);
		return (BezierPath)obj;
	}

	internal static Graphics.Types.Element.Types.FlipMode ToProtoFlipMode(this ElementFlipMode flipMode)
	{
		return flipMode switch
		{
			ElementFlipMode.None => Graphics.Types.Element.Types.FlipMode.None, 
			ElementFlipMode.Horizontal => Graphics.Types.Element.Types.FlipMode.Horizontal, 
			ElementFlipMode.Vertical => Graphics.Types.Element.Types.FlipMode.Vertical, 
			ElementFlipMode.Both => Graphics.Types.Element.Types.FlipMode.Both, 
			_ => throw new NotSupportedException(), 
		};
	}

	internal static ElementFlipMode ToElementFlipMode(this Graphics.Types.Element.Types.FlipMode flipMode)
	{
		return flipMode switch
		{
			Graphics.Types.Element.Types.FlipMode.None => ElementFlipMode.None, 
			Graphics.Types.Element.Types.FlipMode.Horizontal => ElementFlipMode.Horizontal, 
			Graphics.Types.Element.Types.FlipMode.Vertical => ElementFlipMode.Vertical, 
			Graphics.Types.Element.Types.FlipMode.Both => ElementFlipMode.Both, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static Vector2<double> FlipPoint(this ElementFlipMode flipMode, Vector2<double> point)
	{
		if (flipMode.HasFlag(ElementFlipMode.Horizontal))
		{
			point = new Vector2<double>(1.0 - point.X, point.Y);
		}
		if (flipMode.HasFlag(ElementFlipMode.Vertical))
		{
			point = new Vector2<double>(point.X, 1.0 - point.Y);
		}
		return point;
	}

	public static void HandleRemovedElement(this SlideElementBase element, SlideElementBase removedElement)
	{
		foreach (LinkBase dataLink in element.GetDataLinks())
		{
			if (!(dataLink is FillLink fillLink))
			{
				if (!(dataLink is TextLink textLink))
				{
					if (!(dataLink is VisibilityLink visibilityLink))
					{
						continue;
					}
					foreach (VisibilityCondition condition in visibilityLink.Conditions)
					{
						if (condition.LinkedObject is ElementLinkedVisibilityObject elementLinkedVisibilityObject && elementLinkedVisibilityObject.Element == removedElement)
						{
							condition.LinkedObject = null;
						}
					}
				}
				else if (textLink.LinkedObject is ElementTextLinkedObject elementTextLinkedObject && elementTextLinkedObject.Element == removedElement)
				{
					textLink.LinkedObject = null;
				}
			}
			else if (fillLink.LinkedObject is ElementLinkedFillObject elementLinkedFillObject && elementLinkedFillObject.Element == removedElement)
			{
				fillLink.LinkedObject = null;
			}
		}
	}

	public static void UpdateElementLinks(this SlideElementBase element, Predicate<Guid>? canSet, Func<Guid, SlideElementBase>? newValue)
	{
		if (canSet == null || newValue == null)
		{
			return;
		}
		foreach (LinkBase dataLink in element.GetDataLinks())
		{
			if (!(dataLink is FillLink fillLink))
			{
				if (!(dataLink is TextLink textLink))
				{
					if (!(dataLink is VisibilityLink visibilityLink))
					{
						continue;
					}
					foreach (VisibilityCondition condition in visibilityLink.Conditions)
					{
						if (condition.LinkedObject is ElementLinkedVisibilityObject elementLinkedVisibilityObject && canSet(elementLinkedVisibilityObject.ElementID))
						{
							elementLinkedVisibilityObject.Element = newValue(elementLinkedVisibilityObject.ElementID);
						}
					}
				}
				else if (textLink.LinkedObject is ElementTextLinkedObject elementTextLinkedObject && canSet(elementTextLinkedObject.ElementID))
				{
					elementTextLinkedObject.Element = (ClosedBezierPath)newValue(elementTextLinkedObject.ElementID);
				}
			}
			else if (fillLink.LinkedObject is ElementLinkedFillObject elementLinkedFillObject && canSet(elementLinkedFillObject.ElementID))
			{
				elementLinkedFillObject.Element = (ClosedBezierPath)newValue(elementLinkedFillObject.ElementID);
			}
		}
	}

	public static void UpdateElementLinks(this SlideElementBase element, Func<Guid, string, bool>? canSet, Func<Guid, string, SlideElementBase?>? newValue)
	{
		if (canSet == null || newValue == null)
		{
			return;
		}
		foreach (LinkBase dataLink in element.GetDataLinks())
		{
			if (!(dataLink is FillLink fillLink))
			{
				if (!(dataLink is TextLink textLink))
				{
					if (!(dataLink is VisibilityLink visibilityLink))
					{
						continue;
					}
					foreach (VisibilityCondition condition in visibilityLink.Conditions)
					{
						if (condition.LinkedObject is ElementLinkedVisibilityObject elementLinkedVisibilityObject && canSet(elementLinkedVisibilityObject.ElementID, elementLinkedVisibilityObject.ElementName ?? string.Empty))
						{
							elementLinkedVisibilityObject.Element = newValue(elementLinkedVisibilityObject.ElementID, elementLinkedVisibilityObject.ElementName ?? string.Empty);
						}
					}
				}
				else if (textLink.LinkedObject is ElementTextLinkedObject elementTextLinkedObject && canSet(elementTextLinkedObject.ElementID, elementTextLinkedObject.ElementName))
				{
					SlideElementBase slideElementBase = newValue(elementTextLinkedObject.ElementID, elementTextLinkedObject.ElementName);
					if (slideElementBase != null)
					{
						elementTextLinkedObject.Element = (ClosedBezierPath)slideElementBase;
					}
				}
			}
			else if (fillLink.LinkedObject is ElementLinkedFillObject elementLinkedFillObject && canSet(elementLinkedFillObject.ElementID, elementLinkedFillObject.ElementName ?? string.Empty))
			{
				SlideElementBase slideElementBase2 = newValue(elementLinkedFillObject.ElementID, elementLinkedFillObject.ElementName ?? string.Empty);
				if (slideElementBase2 != null)
				{
					elementLinkedFillObject.Element = (ClosedBezierPath)slideElementBase2;
				}
			}
		}
	}

	private static IEnumerable<LinkBase> GetDataLinks(this SlideElementBase element)
	{
		if (!(element is ClosedBezierPath closedBezierPath))
		{
			return Enumerable.Empty<LinkBase>();
		}
		List<LinkBase> list = new List<LinkBase>();
		if (closedBezierPath.FillLink != null)
		{
			list.Add(closedBezierPath.FillLink);
		}
		if (closedBezierPath.TextLink != null)
		{
			list.Add(closedBezierPath.TextLink);
		}
		list.Add(element.VisibilityLink);
		return list;
	}
}
