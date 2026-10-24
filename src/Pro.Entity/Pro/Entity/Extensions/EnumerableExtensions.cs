using System.Collections.Generic;
using System.Linq;
using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class EnumerableExtensions
{
	public static LoroValue ToLoroValue(this IEnumerable<LoroValue> values)
	{
		return new LoroValue.List(values.ToList());
	}

	public static LoroValueLike ToLoroValueLike(this IEnumerable<LoroValue> values)
	{
		return values.ToLoroValue().AsValueLike();
	}

	public static bool SequenceBinaryEqual(this IEnumerable<byte[]> first, IEnumerable<byte[]> second)
	{
		using IEnumerator<byte[]> enumerator = first.GetEnumerator();
		using IEnumerator<byte[]> enumerator2 = second.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (!enumerator2.MoveNext())
			{
				return false;
			}
			if (!enumerator.Current.SequenceEqual(enumerator2.Current))
			{
				return false;
			}
		}
		return !enumerator2.MoveNext();
	}
}
