using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongUsage;

public class UsageReportData
{
	[JsonPropertyName("date")]
	public string Date { get; init; } = string.Empty;

	[JsonPropertyName("songs")]
	public string[] Songs { get; init; } = Array.Empty<string>();
}
