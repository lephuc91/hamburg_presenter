using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Editor.Canvas.Snapping.Lines;
using Pro.Editor.Canvas.Snapping.Sources.EqualSpacing;

namespace Pro.Editor.Canvas.Snapping;

public static class SnapFilter
{
	public static bool IsSourceValid(this ISnapLine sourceLine, ISnapLine targetLine)
	{
		return targetLine.SnapEdges.HasFlag(sourceLine.SnapEdges);
	}

	public static IEnumerable<ISnapLine> MergeLines(IEnumerable<ISnapLine> snapLines)
	{
		List<ISnapLine> list = new List<ISnapLine>(snapLines);
		List<ISnapLine> list2 = new List<ISnapLine>();
		while (list.Count() > 0)
		{
			ISnapLine snapLine = list.First();
			int num = 1;
			while (num < list.Count)
			{
				ISnapLine snapLine2 = list[num];
				bool flag = false;
				if (snapLine.IsHorizontal == snapLine2.IsHorizontal)
				{
					if (snapLine is ElementSL elementSL && snapLine2 is ElementSL elementSL2 && elementSL.Position == elementSL2.Position)
					{
						elementSL.NearestEdge = Math.Min(elementSL.NearestEdge, elementSL2.NearestEdge);
						elementSL.FarthestEdge = Math.Max(elementSL.FarthestEdge, elementSL2.FarthestEdge);
						flag = true;
					}
					else if (snapLine is EqualSpacingSL equalSpacingSL)
					{
						EqualSpacingSL etl = snapLine2 as EqualSpacingSL;
						if (etl != null && equalSpacingSL.SnapEdges == etl.SnapEdges)
						{
							flag = etl.MatchedSpace != equalSpacingSL.MatchedSpace;
							if (etl.MatchedSpace < equalSpacingSL.MatchedSpace)
							{
								snapLine = snapLine2;
							}
							else if (etl.MatchedSpace == equalSpacingSL.MatchedSpace)
							{
								IEnumerable<SpacingPair> pairs = equalSpacingSL.Pairs.Where((SpacingPair sp) => !etl.Pairs.Any((SpacingPair tp) => (sp.A == tp.A && sp.B == tp.B) || (sp.A == tp.B && sp.B == tp.A)));
								snapLine = new EqualSpacingSL(equalSpacingSL.Owner, pairs, equalSpacingSL.MatchedSpace, equalSpacingSL.ActualSpace)
								{
									IsHorizontal = equalSpacingSL.IsHorizontal,
									Position = equalSpacingSL.Position,
									SnapEdges = equalSpacingSL.SnapEdges
								};
							}
						}
					}
				}
				if (flag)
				{
					list.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
			list2.Add(snapLine);
			list.RemoveAt(0);
		}
		return list2;
	}
}
