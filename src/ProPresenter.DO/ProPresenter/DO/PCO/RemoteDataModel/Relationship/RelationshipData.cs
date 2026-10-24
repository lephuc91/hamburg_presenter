using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Relationship;

public class RelationshipData
{
	[JsonPropertyName("type")]
	[JsonRequired]
	public string? Type { get; init; }

	[JsonPropertyName("id")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	[JsonRequired]
	public string? Id { get; init; }
}
