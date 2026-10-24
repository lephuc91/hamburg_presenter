using System.Text.Json.Serialization;
using ProPresenter.DO.PCO.RemoteDataModel.Relationship;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.PlanItem;

public class PlanItemRelationships
{
	[JsonPropertyName("plan")]
	public SingleRelationship? Plan { get; init; }

	[JsonPropertyName("song")]
	public SingleRelationship? Song { get; init; }

	[JsonPropertyName("arrangement")]
	public SingleRelationship? Arrangement { get; init; }

	[JsonPropertyName("media")]
	public MultiRelationship? Media { get; init; }
}
