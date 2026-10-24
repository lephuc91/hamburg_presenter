using System.Collections.Generic;
using System.Text;

namespace Pro.Common.Extensions;

public static class StringBuilderExtensions
{
	public static void AppendMany(this StringBuilder builder, params string[] values)
	{
		builder.AppendMany((IEnumerable<string>)values);
	}

	public static void AppendMany(this StringBuilder builder, IEnumerable<string> values)
	{
		foreach (string value in values)
		{
			builder.Append(value);
		}
	}
}
