using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping.Lines;

namespace Pro.Editor.Canvas.Snapping.Sources;

public class GroupedSS : ISnappingSource
{
	private const int NearEdge = 0;

	private const int CenterEdge = 1;

	private const int FarEdge = 2;

	private List<ICanvasElement> _sourceElements = new List<ICanvasElement>();

	private bool _isBoundsValid;

	private Rect<double> _groupBounds;

	private bool _isSnapLinesValid;

	private ElementSL[] _horizontalLines;

	private ElementSL[] _verticalLines;

	public Rect<double> Bounds
	{
		get
		{
			UpdateBounds();
			return _groupBounds;
		}
	}

	public IEnumerable<ICanvasElement> Elements => _sourceElements;

	public IEnumerable<ICanvasElement>? IgnoredElements { get; private set; }

	public GroupedSS()
	{
		_horizontalLines = new ElementSL[3]
		{
			new ElementSL
			{
				IsHorizontal = true
			},
			new ElementSL
			{
				IsHorizontal = true
			},
			new ElementSL
			{
				IsHorizontal = true
			}
		};
		_verticalLines = new ElementSL[3]
		{
			new ElementSL
			{
				IsHorizontal = false
			},
			new ElementSL
			{
				IsHorizontal = false
			},
			new ElementSL
			{
				IsHorizontal = false
			}
		};
		_horizontalLines[0].SnapEdges = SnapEdge.Near;
		_horizontalLines[1].SnapEdges = SnapEdge.Center;
		_horizontalLines[2].SnapEdges = SnapEdge.Far;
		_verticalLines[0].SnapEdges = SnapEdge.Near;
		_verticalLines[1].SnapEdges = SnapEdge.Center;
		_verticalLines[2].SnapEdges = SnapEdge.Far;
	}

	public GroupedSS(IEnumerable<ICanvasElement> sourceElements)
		: this()
	{
		foreach (ICanvasElement sourceElement in sourceElements)
		{
			AddElement(sourceElement);
		}
	}

	public IEnumerable<ISnapLine> GenerateHorizontalSnapLines(ISnappingSource? targetSource)
	{
		CalculateLines();
		return _horizontalLines;
	}

	public IEnumerable<ISnapLine> GenerateVerticalSnapLines(ISnappingSource? targetSource)
	{
		CalculateLines();
		return _verticalLines;
	}

	public void IgnoreElements(IEnumerable<ICanvasElement> elements)
	{
		IgnoredElements = elements;
		InvalidateData();
	}

	public void UnignoreElements()
	{
		IgnoredElements = null;
		InvalidateData();
	}

	private void InvalidateData()
	{
		_isBoundsValid = false;
		_isSnapLinesValid = false;
	}

	public void AddElement(ICanvasElement sourceElement)
	{
		if (!_sourceElements.Contains(sourceElement))
		{
			_sourceElements.Add(sourceElement);
			_isBoundsValid = false;
			_isSnapLinesValid = false;
			sourceElement.PropertyChanged += Element_PropertyChanged;
		}
	}

	public void RemoveElement(ICanvasElement sourceElement)
	{
		if (_sourceElements.Contains(sourceElement))
		{
			_sourceElements.Remove(sourceElement);
			_isBoundsValid = false;
			_isSnapLinesValid = false;
			sourceElement.PropertyChanged -= Element_PropertyChanged;
		}
	}

	private void UpdateBounds()
	{
		if (!_isBoundsValid)
		{
			_groupBounds = _sourceElements.Select((ICanvasElement e) => e.SnapBounds).GetBoundingBox();
			_isBoundsValid = true;
		}
	}

	private void CalculateLines()
	{
		if (!_isSnapLinesValid)
		{
			UpdateBounds();
			_horizontalLines[0].Position = Bounds.Top;
			_horizontalLines[1].Position = Bounds.Center.Y;
			_horizontalLines[2].Position = Bounds.Bottom;
			_verticalLines[0].Position = Bounds.Left;
			_verticalLines[1].Position = Bounds.Center.X;
			_verticalLines[2].Position = Bounds.Right;
			ElementSL[] horizontalLines = _horizontalLines;
			foreach (ElementSL obj in horizontalLines)
			{
				obj.NearestEdge = Bounds.Left;
				obj.FarthestEdge = Bounds.Right;
			}
			horizontalLines = _verticalLines;
			foreach (ElementSL obj2 in horizontalLines)
			{
				obj2.NearestEdge = Bounds.Top;
				obj2.FarthestEdge = Bounds.Bottom;
			}
		}
	}

	public bool IsTargetValid(ISnappingSource snappingSource)
	{
		Type baseType = snappingSource.GetType().BaseType;
		if (baseType != null)
		{
			if (!(snappingSource is GroupedSS) && (!baseType.IsGenericType || !(baseType.GetGenericTypeDefinition() == typeof(DynamicSS<>))))
			{
				return !snappingSource.Elements.Any((ICanvasElement e) => Elements.Contains(e));
			}
			return true;
		}
		return false;
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
				InvalidateData();
				break;
			}
		}
	}
}
