using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Reporting.SongUsage;

public class UsageReport
{
	[JsonPropertyName("usage")]
	public UsageReportData[] Usage { get; init; } = Array.Empty<UsageReportData>();
}
