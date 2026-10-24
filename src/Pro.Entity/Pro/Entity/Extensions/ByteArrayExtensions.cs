using System.Linq;
using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class ByteArrayExtensions
{
	public static LoroValue ToLoroValue(this byte[]? value)
	{
		if (value != null)
		{
			return new LoroValue.Binary(value);
		}
		return new LoroValue.Null();
	}

	public static LoroValueLike ToLoroValueLike(this byte[]? value)
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static bool AreSame(this byte[]? left, byte[]? right)
	{
		if (left == null)
		{
			return right == null;
		}
		if (right == null)
		{
			return false;
		}
		return left.SequenceEqual(right);
	}

	public static LoroDoc ToLoroDoc(this byte[] value)
	{
		LoroDoc loroDoc = new LoroDoc();
		loroDoc.Import(value);
		return loroDoc;
	}
}
