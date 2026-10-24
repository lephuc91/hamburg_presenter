using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Collections;

namespace Pro.Text;

public static class RangeExtensions
{
	public static bool Contains(this Range lhs, int rhs)
	{
		return lhs.Contains(new Range(rhs));
	}

	public static bool Contains(this Range lhs, Range rhs)
	{
		if (rhs.Start >= lhs.Start)
		{
			return rhs.End <= lhs.End;
		}
		return false;
	}

	public static bool Intersects(this Range lhs, Range rhs)
	{
		if ((lhs.Start < rhs.Start || lhs.Start > rhs.End) && (lhs.End < rhs.Start || lhs.End > rhs.End) && !lhs.Contains(rhs))
		{
			return rhs.Contains(lhs);
		}
		return true;
	}

	public static bool IsEmpty([NotNullWhen(false)] this Range[]? ranges)
	{
		return ranges?.Empty() ?? true;
	}

	public static bool ContainsSelection(this Range[]? ranges)
	{
		if (!ranges.IsEmpty())
		{
			return ranges.Any((Range r) => r.IsSelection);
		}
		return false;
	}

	public static int FirstIndex(this Range[]? ranges)
	{
		if (ranges.IsEmpty())
		{
			return 0;
		}
		return ranges.Min((Range r) => Math.Max(r.Start, 0));
	}

	public static int LastIndex(this Range[]? ranges)
	{
		if (ranges.IsEmpty())
		{
			return 0;
		}
		return ranges.Max((Range r) => Math.Max(r.End, 0));
	}

	public static Range Merge(this Range lhs, Range rhs)
	{
		return new Range(Math.Min(lhs.Start, rhs.Start), Math.Max(lhs.End, rhs.End));
	}

	public static Range[] Join(this Range[] lhs, Range rhs)
	{
		return lhs.Join(rhs.ToEnumerable());
	}

	public static Range[] Join(this Range[]? lhs, IEnumerable<Range>? rhs)
	{
		bool flag = lhs.IsEmpty();
		bool flag2 = rhs?.Empty() ?? true;
		if (flag2 && flag)
		{
			return Array.Empty<Range>();
		}
		if (flag)
		{
			return rhs.ToArray();
		}
		if (flag2)
		{
			return lhs;
		}
		List<int> indicies = new List<int>();
		processRanges(lhs);
		processRanges(rhs);
		if (indicies.Empty())
		{
			return Array.Empty<Range>();
		}
		indicies.Sort();
		Range[] array = new Range[indicies.Count / 2];
		for (int i = 0; i < indicies.Count; i += 2)
		{
			array[i / 2] = new Range(indicies[i], indicies[i + 1]);
		}
		return array;
		void processRanges(IEnumerable<Range>? ranges)
		{
			if (ranges != null)
			{
				foreach (Range range in ranges)
				{
					if (range.IsSelection && !(range == Range.All))
					{
						toggleIndex(range.Start);
						toggleIndex(range.End);
					}
				}
			}
		}
		void toggleIndex(int index)
		{
			if (indicies.Contains(index))
			{
				indicies.Remove(index);
			}
			else
			{
				indicies.Add(index);
			}
		}
	}

	public static Range[] Sort(this Range[]? ranges)
	{
		return ranges?.OrderBy((Range r) => r.Start).ToArray() ?? Array.Empty<Range>();
	}

	public static Range[] Compact(this Range[]? ranges)
	{
		if (ranges.IsEmpty())
		{
			return Array.Empty<Range>();
		}
		if (ranges.Length == 1)
		{
			return ranges;
		}
		List<Range> list = new List<Range>();
		Range[] array = ranges.Sort();
		foreach (Range range in array)
		{
			if (range == Range.All)
			{
				continue;
			}
			bool flag = false;
			for (int j = 0; j < list.Count; j++)
			{
				Range lhs = list[j];
				if (lhs.Intersects(range))
				{
					list[j] = lhs.Merge(range);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(range);
			}
		}
		return list.ToArray();
	}

	public static Range OffSet(this Range range, int offset)
	{
		return new Range(range.Start + offset, range.End + offset);
	}
}
