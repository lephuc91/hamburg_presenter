using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.Plan;

public class PlanAttributes
{
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; init; }

	[JsonPropertyName("dates")]
	public string? Dates { get; init; }

	[JsonPropertyName("series_title")]
	public string? SeriesTitle { get; init; }

	[JsonPropertyName("title")]
	public string? Title { get; init; }

	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; init; }
}
