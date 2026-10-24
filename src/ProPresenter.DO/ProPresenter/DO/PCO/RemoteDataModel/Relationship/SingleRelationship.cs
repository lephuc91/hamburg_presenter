using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Relationship;

public class SingleRelationship
{
	[JsonPropertyName("data")]
	[JsonRequired]
	public RelationshipData? Data { get; init; }
}
