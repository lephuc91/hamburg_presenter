using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Rights;

public class AccessRight
{
	[JsonPropertyName("hasAccess")]
	public bool HasAccess { get; init; }

	[JsonPropertyName("explanationId")]
	public string? ExplanationId { get; init; }

	[JsonPropertyName("explanation")]
	public string? Explanation { get; init; }
}
