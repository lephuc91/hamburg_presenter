using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Relationship;

public class MultiRelationship
{
	[JsonPropertyName("data")]
	[JsonRequired]
	public RelationshipData[] Data { get; init; } = Array.Empty<RelationshipData>();
}
