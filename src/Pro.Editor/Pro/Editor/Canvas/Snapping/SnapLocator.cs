using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.Snapping;

public class SnapLocator
{
	private IEnumerable<ISnappingSource> _snappingTargets;

	public IEnumerable<ISnappingSource> SnappingTargets
	{
		get
		{
			return _snappingTargets;
		}
		set
		{
			_snappingTargets = value;
		}
	}

	public SnapLocator(IEnumerable<ISnappingSource> snappingTargets)
	{
		_snappingTargets = snappingTargets;
	}

	public SnappingResult FindMatchingSnaps(Vector2<double> snappingOrigin, ISnappingSource snappingSource, double snappingThreshold)
	{
		List<ISnapLine> list = new List<ISnapLine>();
		List<ISnapLine> list2 = new List<ISnapLine>();
		foreach (ISnappingSource item in SnappingTargets.Where((ISnappingSource s) => snappingSource.IsTargetValid(s)))
		{
			list.AddRange(item.GenerateHorizontalSnapLines(snappingSource));
			list2.AddRange(item.GenerateVerticalSnapLines(snappingSource));
		}
		Tuple<IEnumerable<ISnapLine>, double> tuple = MatchSnapLines(snappingSource.GenerateHorizontalSnapLines(null), list, snappingThreshold);
		Tuple<IEnumerable<ISnapLine>, double> tuple2 = MatchSnapLines(snappingSource.GenerateVerticalSnapLines(null), list2, snappingThreshold);
		return new SnappingResult(tuple.Item1.Concat(tuple2.Item1), snappingOrigin, new Vector2<double>(tuple2.Item2, tuple.Item2));
	}

	private Tuple<IEnumerable<ISnapLine>, double> MatchSnapLines(IEnumerable<ISnapLine> sourceLines, IEnumerable<ISnapLine> targetLines, double snappingThreshold)
	{
		List<ISnapLine> list = new List<ISnapLine>();
		double num = double.MaxValue;
		double item = double.MaxValue;
		bool flag = false;
		IEnumerable<ISnapLine> disabledLines = sourceLines.Where((ISnapLine l) => !l.IsEnabled);
		foreach (ISnapLine sourceLine in sourceLines.Where((ISnapLine l) => l.IsEnabled))
		{
			foreach (ISnapLine item2 in targetLines.Where((ISnapLine l) => l.IsEnabled && sourceLine.IsSourceValid(l) && !disabledLines.Any((ISnapLine dl) => l.Position == dl.Position)))
			{
				double num2 = Math.Floor(item2.Position - sourceLine.Position);
				if (Math.Abs(num2) <= snappingThreshold && Math.Abs(num2) < Math.Abs(num))
				{
					flag = true;
					list.Clear();
					list.Add(item2);
					num = num2;
					item = item2.Position - sourceLine.Position;
				}
				else if (num2 == num)
				{
					list.Add(item2);
				}
			}
		}
		if (!flag)
		{
			item = 0.0;
		}
		return new Tuple<IEnumerable<ISnapLine>, double>(list, item);
	}
}
