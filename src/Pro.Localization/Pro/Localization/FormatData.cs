namespace Pro.Localization;

internal class FormatData
{
	public string? ShortPattern { get; }

	public string? MediumPattern { get; }

	public string? LongPattern { get; }

	public string? FullPattern { get; }

	public FormatData(string? shortPattern, string? mediumPattern, string? longPattern, string? fullPattern)
	{
		ShortPattern = shortPattern;
		MediumPattern = mediumPattern;
		LongPattern = longPattern;
		FullPattern = fullPattern;
	}
}
