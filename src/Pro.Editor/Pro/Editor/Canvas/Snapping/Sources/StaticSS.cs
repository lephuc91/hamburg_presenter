using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping.Lines;

namespace Pro.Editor.Canvas.Snapping.Sources;

public class StaticSS : ISnappingSource
{
	public Rect<double> Bounds => Rect<double>.Empty;

	public IEnumerable<ICanvasElement> Elements => Array.Empty<ICanvasElement>();

	public IEnumerable<ICanvasElement> IgnoredElements => Array.Empty<ICanvasElement>();

	public IEnumerable<StaticSL>? SlideGuides { get; set; }

	public bool IsEnabled { get; set; } = true;

	public bool IsTargetValid(ISnappingSource snappingSource)
	{
		return true;
	}

	public IEnumerable<ISnapLine> GenerateHorizontalSnapLines(ISnappingSource? targetSource)
	{
		return ProjectLines(isHorizontal: true);
	}

	public IEnumerable<ISnapLine> GenerateVerticalSnapLines(ISnappingSource? targetSource)
	{
		return ProjectLines(isHorizontal: false);
	}

	public void IgnoreElements(IEnumerable<ICanvasElement> elements)
	{
	}

	public void UnignoreElements()
	{
	}

	private IEnumerable<ISnapLine> ProjectLines(bool isHorizontal)
	{
		return SlideGuides?.Where((StaticSL g) => g.IsHorizontal == isHorizontal) ?? Array.Empty<StaticSL>();
	}
}
