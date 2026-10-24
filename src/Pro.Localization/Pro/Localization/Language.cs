using System.Collections.Immutable;

namespace Pro.Localization;

internal sealed class Language : FormatSet
{
	public ImmutableDictionary<string, FormatSet> Regions { get; }

	public Language(FormatData? date, FormatData? time, FormatData? combine, ImmutableDictionary<string, FormatSet> regions)
		: base(date, time, combine)
	{
		Regions = regions;
	}
}
