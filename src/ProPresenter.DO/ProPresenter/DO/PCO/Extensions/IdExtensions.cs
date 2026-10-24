using Pro.Common.Nullability;

namespace ProPresenter.DO.PCO.Extensions;

public static class IdExtensions
{
	public static uint ToUintId(this string? id)
	{
		if (uint.TryParse(id, out var result))
		{
			return result;
		}
		return 0u;
	}

	public static string FromProto(string? idStr, uint idNum)
	{
		if (!idStr.NullableIsNullOrEmpty())
		{
			return idStr;
		}
		return idNum.ToString();
	}
}
