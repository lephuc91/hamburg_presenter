using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping.Lines;

namespace Pro.Editor.Canvas.Snapping.Sources;

public class ElementSS : ISnappingSource
{
	protected const int NearEdge = 0;

	protected const int CenterEdge = 1;

	protected const int FarEdge = 2;

	private bool _isBoundsValid;

	private Rect<double> _elementBounds;

	private bool _isSnapLinesValid;

	public Rect<double> Bounds
	{
		get
		{
			UpdateBounds();
			return _elementBounds;
		}
	}

	public ICanvasElement Element { get; }

	public IEnumerable<ICanvasElement> Elements => new ICanvasElement[1] { Element };

	public IEnumerable<ICanvasElement>? IgnoredElements { get; private set; }

	protected ElementSL[] HorizontalLines { get; }

	protected ElementSL[] VerticalLines { get; }

	public bool IsEdgeEnabled { get; set; } = true;

	public bool IsCenterEnabled { get; set; } = true;

	public bool IsParent { get; set; }

	public ElementSS(ICanvasElement sourceElement, bool isParent = false)
	{
		Element = sourceElement;
		Element.PropertyChanged += Element_PropertyChanged;
		IsParent = isParent;
		HorizontalLines = new ElementSL[3]
		{
			new ElementSL
			{
				IsHorizontal = true,
				IsParent = IsParent
			},
			new ElementSL
			{
				IsHorizontal = true,
				IsParent = IsParent
			},
			new ElementSL
			{
				IsHorizontal = true,
				IsParent = IsParent
			}
		};
		VerticalLines = new ElementSL[3]
		{
			new ElementSL
			{
				IsHorizontal = false,
				IsParent = IsParent
			},
			new ElementSL
			{
				IsHorizontal = false,
				IsParent = IsParent
			},
			new ElementSL
			{
				IsHorizontal = false,
				IsParent = IsParent
			}
		};
	}

	public IEnumerable<ISnapLine> GenerateHorizontalSnapLines(ISnappingSource? targetSource)
	{
		CalculateLines();
		return HorizontalLines;
	}

	public IEnumerable<ISnapLine> GenerateVerticalSnapLines(ISnappingSource? targetSource)
	{
		CalculateLines();
		return VerticalLines;
	}

	public void IgnoreElements(IEnumerable<ICanvasElement> elements)
	{
		IgnoredElements = elements;
		InvalidateBounds();
	}

	public void UnignoreElements()
	{
		IgnoredElements = null;
		InvalidateBounds();
	}

	private void UpdateBounds()
	{
		if (!_isBoundsValid)
		{
			_elementBounds = OnUpdateBounds();
			_isBoundsValid = true;
		}
	}

	protected virtual Rect<double> OnUpdateBounds()
	{
		return Element.SnapBounds;
	}

	private void CalculateLines()
	{
		if (!_isSnapLinesValid && (IgnoredElements == null || !IgnoredElements.Contains(Element)))
		{
			UpdateBounds();
			OnCalculateLines();
			_isSnapLinesValid = true;
		}
	}

	protected virtual void OnCalculateLines()
	{
		HorizontalLines[0].Position = Bounds.Top;
		HorizontalLines[1].Position = Bounds.Center.Y;
		HorizontalLines[2].Position = Bounds.Bottom;
		VerticalLines[0].Position = Bounds.Left;
		VerticalLines[1].Position = Bounds.Center.X;
		VerticalLines[2].Position = Bounds.Right;
		HorizontalLines[0].IsEnabled = IsEdgeEnabled && Element.IsSnappingSource;
		HorizontalLines[1].IsEnabled = IsCenterEnabled && Element.IsSnappingSource;
		HorizontalLines[2].IsEnabled = IsEdgeEnabled && Element.IsSnappingSource;
		VerticalLines[0].IsEnabled = IsEdgeEnabled && Element.IsSnappingSource;
		VerticalLines[1].IsEnabled = IsCenterEnabled && Element.IsSnappingSource;
		VerticalLines[2].IsEnabled = IsEdgeEnabled && Element.IsSnappingSource;
		ElementSL[] horizontalLines = HorizontalLines;
		foreach (ElementSL obj in horizontalLines)
		{
			obj.NearestEdge = Bounds.Left;
			obj.FarthestEdge = Bounds.Right;
		}
		horizontalLines = VerticalLines;
		foreach (ElementSL obj2 in horizontalLines)
		{
			obj2.NearestEdge = Bounds.Top;
			obj2.FarthestEdge = Bounds.Bottom;
		}
	}

	public bool IsTargetValid(ISnappingSource snappingSource)
	{
		if (snappingSource is ElementSS)
		{
			return (snappingSource as ElementSS)?.Element != Element;
		}
		return true;
	}

	protected void InvalidateBounds()
	{
		_isBoundsValid = false;
		InvaldiateSnapLines();
	}

	protected void InvaldiateSnapLines()
	{
		_isSnapLinesValid = false;
	}

	private void Element_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (IgnoredElements == null || !IgnoredElements.Contains(sender as ICanvasElement))
		{
			switch (e.PropertyName)
			{
			case "Position":
			case "Size":
			case "Rotation":
				InvalidateBounds();
				break;
			case "IsSnappingSource":
				InvaldiateSnapLines();
				break;
			}
		}
	}
}
