using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.PlanItem;

public class PlanItemAttributes
{
	[JsonPropertyName("title")]
	public string? Title { get; init; }

	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; init; }

	[JsonPropertyName("item_type")]
	public PlanItemType ItemType { get; init; }

	[JsonPropertyName("custom_arrangement_sequence")]
	public string[]? CustomArrangementSequence { get; init; }
}
