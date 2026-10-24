using System.Text.Json.Serialization;
using ProPresenter.DO.PCO.RemoteDataModel.Relationship;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.ServiceType;

public class ServiceTypeRelationships
{
	[JsonPropertyName("parent")]
	public SingleRelationship? Parent { get; init; }
}
