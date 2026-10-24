using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Snapping.Lines;
using Pro.Editor.Canvas.Snapping.Sources.EqualSizing;

namespace Pro.Editor.Canvas.Snapping.Sources;

public class EqualSizingSS : DynamicSS<ProjectedLine>
{
	private bool _isEnabled = true;

	public override DynamicSSType Type => DynamicSSType.EqualSizing;

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

	public EqualSizingSS(ImmutableObservableCollection<ICanvasElement> sourceElements)
		: base(sourceElements)
	{
	}

	protected override void OnSourceElementAdded(ICanvasElement element)
	{
		if (element.Rotation.Value % 90.0 == 0.0)
		{
			Rect<double> snapBounds = element.SnapBounds;
			GenerateLines(isHorizontal: false, element, snapBounds);
			GenerateLines(isHorizontal: true, element, snapBounds);
		}
	}

	private void GenerateLines(bool isHorizontal, ICanvasElement element, Rect<double> sourceBounds)
	{
		List<ProjectedLine> list = (isHorizontal ? base.HorizontalLines : base.VerticalLines);
		double num = Math.Abs(isHorizontal ? sourceBounds.Height : sourceBounds.Width);
		double num2 = Math.Floor(num);
		if (!(num2 > 0.0))
		{
			return;
		}
		bool flag = false;
		foreach (ProjectedLine item in list)
		{
			if (item.MatchedSize == num2)
			{
				flag = true;
				if (!item.Owners.Contains(element))
				{
					item.Owners.Add(element);
				}
			}
		}
		if (!flag)
		{
			ProjectedLine projectedLine = new ProjectedLine
			{
				MatchedSize = num2,
				ActualSize = num
			};
			projectedLine.Owners.Add(element);
			list.Add(projectedLine);
		}
	}

	protected override IEnumerable<ISnapLine> ProjectLines(bool isHorizontal, ISnappingSource targetSource)
	{
		List<ISnapLine> list = new List<ISnapLine>();
		if (!IsEnabled)
		{
			return list;
		}
		Rect<double> bounds = targetSource.Bounds;
		IEnumerable<ICanvasElement> targetElements = targetSource.Elements;
		double num = (isHorizontal ? bounds.Top : bounds.Left);
		double num2 = (isHorizontal ? bounds.Bottom : bounds.Right);
		foreach (ProjectedLine item in (isHorizontal ? base.HorizontalLines : base.VerticalLines).Where((ProjectedLine l) => IsValidLine(l, targetElements)))
		{
			list.Add(new EqualSizingSL(item.Owners, item.ActualSize)
			{
				IsHorizontal = isHorizontal,
				Position = num2 - item.ActualSize,
				SnapEdges = SnapEdge.Near
			});
			list.Add(new EqualSizingSL(item.Owners, item.ActualSize)
			{
				IsHorizontal = isHorizontal,
				Position = num + item.ActualSize,
				SnapEdges = SnapEdge.Far
			});
		}
		return list;
	}

	private bool IsValidLine(ProjectedLine line, IEnumerable<ICanvasElement> elements)
	{
		return line.Owners.Any((ICanvasElement e) => !elements.Contains(e) && (base.IgnoredElements == null || !base.IgnoredElements.Contains(e)));
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
