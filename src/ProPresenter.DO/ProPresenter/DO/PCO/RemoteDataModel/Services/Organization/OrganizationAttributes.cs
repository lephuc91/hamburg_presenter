using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.Organization;

public class OrganizationAttributes
{
	[JsonPropertyName("name")]
	public string? Name { get; init; }
}
