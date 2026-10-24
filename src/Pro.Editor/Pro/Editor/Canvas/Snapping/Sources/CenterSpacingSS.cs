using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping.Lines;
using Pro.Editor.Canvas.Snapping.Sources.CenterSpacing;

namespace Pro.Editor.Canvas.Snapping.Sources;

public class CenterSpacingSS : DynamicSS<ProjectedLine>
{
	private const double MaxProjectDistance = 75.0;

	private const int AIndex = 0;

	private const int BIndex = 1;

	private bool _isEnabled = true;

	public override DynamicSSType Type => DynamicSSType.CenterSpacing;

	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			_isEnabled = value;
		}
	}

	public CenterSpacingSS(ImmutableObservableCollection<ICanvasElement> sourceElements)
		: base(sourceElements)
	{
	}

	protected override void OnSourceElementAdded(ICanvasElement element)
	{
		Rect<double> snapBounds = element.SnapBounds;
		GenerateLines(isHorizontal: false, element, snapBounds);
		GenerateLines(isHorizontal: true, element, snapBounds);
	}

	private void GenerateLines(bool isHorizontal, ICanvasElement element, Rect<double> sourceBounds)
	{
		List<ProjectedLine> list = (isHorizontal ? base.HorizontalLines : base.VerticalLines);
		foreach (ICanvasElement item in base.Elements.Where((ICanvasElement e) => e != element))
		{
			Rect<double> snapBounds = item.SnapBounds;
			if (!IsSameRegion(!isHorizontal, sourceBounds, snapBounds))
			{
				double num = (isHorizontal ? sourceBounds.Center.Y : sourceBounds.Center.X);
				double num2 = (isHorizontal ? snapBounds.Center.Y : snapBounds.Center.X);
				double num3 = (isHorizontal ? sourceBounds.Top : sourceBounds.Left);
				double num4 = (isHorizontal ? snapBounds.Top : snapBounds.Left);
				double num5 = (isHorizontal ? sourceBounds.Bottom : sourceBounds.Right);
				double num6 = (isHorizontal ? snapBounds.Bottom : snapBounds.Right);
				double num7 = ((num3 < num4) ? num3 : num4);
				double num8 = ((num5 > num6) ? num5 : num6);
				ProjectedLine projectedLine = new ProjectedLine
				{
					Center = num + num2 - (num7 + num8) / 2.0
				};
				projectedLine.Owners.Add(element);
				projectedLine.Owners.Add(item);
				list.Add(projectedLine);
			}
		}
	}

	protected override IEnumerable<ISnapLine> ProjectLines(bool isHorizontal, ISnappingSource targetSource)
	{
		if (!IsEnabled)
		{
			return new ISnapLine[0];
		}
		List<ISnapLine> list = new List<ISnapLine>();
		List<ProjectedLine> source = (isHorizontal ? base.HorizontalLines : base.VerticalLines);
		Rect<double> bounds = targetSource.Bounds;
		double targetCenter = (isHorizontal ? bounds.Center.Y : bounds.Center.X);
		double num = (isHorizontal ? bounds.Height : bounds.Width);
		IEnumerable<ICanvasElement> targetElements = targetSource.Elements;
		foreach (ProjectedLine item in source.Where((ProjectedLine l) => Math.Abs(targetCenter - l.Center) <= 75.0 && IsValidLine(l, targetElements)))
		{
			Rect<double> snapBounds = item.Owners[0].SnapBounds;
			Rect<double> snapBounds2 = item.Owners[1].SnapBounds;
			if (IsSameRegion(isHorizontal, snapBounds, bounds) && IsSameRegion(isHorizontal, snapBounds2, bounds) && snapBounds.ClosestEdgeDistance(snapBounds2, isHorizontal) > num)
			{
				list.Add(new CenterSpacingSL(item.Owners)
				{
					IsHorizontal = isHorizontal,
					Position = item.Center,
					SnapEdges = SnapEdge.Center
				});
			}
		}
		return list;
	}

	private bool IsValidLine(ProjectedLine line, IEnumerable<ICanvasElement> elements)
	{
		if (line.Owners.Count == 2)
		{
			return !line.Owners.Any((ICanvasElement e) => elements.Contains(e) || (base.IgnoredElements != null && base.IgnoredElements.Contains(e)));
		}
		return false;
	}

	protected override void OnSourceElementRemoved(ICanvasElement element)
	{
		RemoveElementLines(element, base.VerticalLines);
		RemoveElementLines(element, base.HorizontalLines);
	}

	private void RemoveElementLines(ICanvasElement element, List<ProjectedLine> lines)
	{
		foreach (ProjectedLine line in lines)
		{
			line.Owners.Remove(element);
		}
	}
}
