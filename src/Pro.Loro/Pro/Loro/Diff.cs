using System;
using System.Collections.Generic;

namespace Pro.Loro;

public record Diff : IDisposable
{
	public record List(List<ListDiffItem> diff) : Diff();

	public record Text(List<TextDelta> diff) : Diff();

	public record Map(MapDelta diff) : Diff();

	public record Tree(TreeDiff diff) : Diff();

	public record Counter(double diff) : Diff();

	public record Unknown : Diff;

	public void Dispose()
	{
		if (!(this is List list))
		{
			if (!(this is Text text))
			{
				if (!(this is Map map))
				{
					if (!(this is Tree tree))
					{
						if (!(this is Counter counter))
						{
							if (!(this is Unknown))
							{
								throw new InternalException($"invalid enum value '{this}' in Diff.Dispose()");
							}
						}
						else
						{
							FFIObjectUtil.DisposeAll(counter.diff);
						}
					}
					else
					{
						FFIObjectUtil.DisposeAll(tree.diff);
					}
				}
				else
				{
					FFIObjectUtil.DisposeAll(map.diff);
				}
			}
			else
			{
				FFIObjectUtil.DisposeAll(text.diff);
			}
		}
		else
		{
			FFIObjectUtil.DisposeAll(list.diff);
		}
	}
}
