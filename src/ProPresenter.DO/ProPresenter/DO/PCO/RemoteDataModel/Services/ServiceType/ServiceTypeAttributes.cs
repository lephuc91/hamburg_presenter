using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.ServiceType;

public class ServiceTypeAttributes
{
	[JsonPropertyName("name")]
	public string? Name { get; init; }
}
