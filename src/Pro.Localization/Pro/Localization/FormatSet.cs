namespace Pro.Localization;

internal class FormatSet
{
	public FormatData? Date { get; }

	public FormatData? Time { get; }

	public FormatData? Combine { get; }

	public FormatSet(FormatData? date, FormatData? time, FormatData? combine)
	{
		Date = date;
		Time = time;
		Combine = combine;
	}
}
