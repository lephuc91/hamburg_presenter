using Pro.Loro;

namespace Pro.Entity.Extensions;

internal static class StringExtensions
{
	public class ContainerId(string id) : ContainerIdLike
	{
		public Pro.Loro.ContainerId AsContainerId(ContainerType ty)
		{
			return new Pro.Loro.ContainerId.Root(id, ty);
		}
	}

	public static LoroValue ToLoroValue(this string? value)
	{
		if (value != null)
		{
			return new LoroValue.String(value);
		}
		return new LoroValue.Null();
	}

	public static LoroValueLike ToLoroValueLike(this string? value)
	{
		return value.ToLoroValue().AsValueLike();
	}

	public static ContainerIdLike ToLoroContainerIdLike(this string value)
	{
		return new ContainerId(value);
	}
}
