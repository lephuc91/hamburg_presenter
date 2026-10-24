using System.Collections;
using Pro.Common.Utility;

namespace ProPresenter.DO;

public static class RenderHashCodeHelper
{
	public static int GenerateHashCode(params object?[] fields)
	{
		return HashCodeHelper.GenerateHashCode(HashProvider, fields);
	}

	public static int GenerateHashCode(IEnumerable[] collections, params object?[] fields)
	{
		return HashCodeHelper.GenerateHashCode(HashProvider, collections, fields);
	}

	private static int HashProvider(object obj)
	{
		if (!(obj is IRenderHashable renderHashable))
		{
			return obj.GetHashCode();
		}
		return renderHashable.GetRenderHashCode();
	}
}
