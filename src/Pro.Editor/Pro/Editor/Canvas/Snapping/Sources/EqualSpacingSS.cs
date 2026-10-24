using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping.Lines;
using Pro.Editor.Canvas.Snapping.Sources.EqualSpacing;

namespace Pro.Editor.Canvas.Snapping.Sources;

public class EqualSpacingSS : DynamicSS<ProjectedLine>
{
	private bool _isEnabled = true;

	public override DynamicSSType Type => DynamicSSType.EqualSpacing;

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

	public EqualSpacingSS(ImmutableObservableCollection<ICanvasElement> sourceElements)
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
		foreach (ICanvasElement targetElement in base.Elements.Where((ICanvasElement e) => e != element))
		{
			Rect<double> snapBounds = targetElement.SnapBounds;
			if (!IsSameRegion(isHorizontal, sourceBounds, snapBounds))
			{
				continue;
			}
			double num = sourceBounds.ClosestEdgeDistance(snapBounds, isHorizontal);
			double num2 = Math.Floor(num);
			if (!(num2 > 0.0))
			{
				continue;
			}
			bool flag = false;
			foreach (ProjectedLine item in list)
			{
				if (item.MatchedSpace != num2)
				{
					continue;
				}
				flag = true;
				if (!item.SpacingPairs.Any((SpacingPair p) => (p.A == element || p.B == element) && (p.A == targetElement || p.B == targetElement)))
				{
					item.SpacingPairs.Add(new SpacingPair(element, targetElement));
					if (!item.Owners.Contains(element))
					{
						item.Owners.Add(element);
					}
					if (!item.Owners.Contains(targetElement))
					{
						item.Owners.Add(targetElement);
					}
				}
			}
			if (!flag)
			{
				ProjectedLine projectedLine = new ProjectedLine
				{
					MatchedSpace = num2,
					ActualSpace = num
				};
				projectedLine.Owners.Add(element);
				projectedLine.Owners.Add(targetElement);
				projectedLine.SpacingPairs.Add(new SpacingPair(element, targetElement));
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
		IEnumerable<ICanvasElement> targetElements = targetSource.Elements;
		foreach (ICanvasElement item in base.Elements.Where((ICanvasElement e) => !targetElements.Contains(e) && (base.IgnoredElements == null || !base.IgnoredElements.Contains(e))))
		{
			Rect<double> snapBounds = item.SnapBounds;
			if (!IsSameRegion(isHorizontal, snapBounds, bounds))
			{
				continue;
			}
			foreach (ProjectedLine item2 in source.Where((ProjectedLine l) => IsValidLine(l, targetElements)))
			{
				double num = (isHorizontal ? snapBounds.Top : snapBounds.Left);
				double num2 = (isHorizontal ? snapBounds.Bottom : snapBounds.Right);
				IEnumerable<SpacingPair> pairs = item2.SpacingPairs.Where((SpacingPair p) => !base.IgnoredElements.Contains(p.A) && !base.IgnoredElements.Contains(p.B));
				list.Add(new EqualSpacingSL(item, pairs, item2.MatchedSpace, item2.ActualSpace)
				{
					IsHorizontal = isHorizontal,
					Position = num - item2.ActualSpace,
					SnapEdges = SnapEdge.Far
				});
				list.Add(new EqualSpacingSL(item, pairs, item2.MatchedSpace, item2.ActualSpace)
				{
					IsHorizontal = isHorizontal,
					Position = num2 + item2.ActualSpace,
					SnapEdges = SnapEdge.Near
				});
			}
		}
		return list;
	}

	private bool IsValidLine(ProjectedLine line, IEnumerable<ICanvasElement> elements)
	{
		return line.SpacingPairs.Any((SpacingPair p) => !elements.Contains(p.A) && !elements.Contains(p.B));
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
			if (line.Owners.Count <= 0)
			{
				continue;
			}
			List<ICanvasElement> list = new List<ICanvasElement>();
			int num = 0;
			while (num < line.SpacingPairs.Count)
			{
				SpacingPair spacingPair = line.SpacingPairs[num];
				if (spacingPair.A == element || spacingPair.B == element)
				{
					ICanvasElement canvasElement = null;
					canvasElement = ((spacingPair.A == element) ? spacingPair.B : spacingPair.A);
					if (!list.Contains(canvasElement))
					{
						list.Add(canvasElement);
					}
					line.SpacingPairs.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
			foreach (ICanvasElement checkElement in list)
			{
				if (!line.SpacingPairs.Any((SpacingPair p) => p.A == checkElement || p.B == checkElement))
				{
					line.Owners.Remove(checkElement);
				}
			}
		}
	}
}
