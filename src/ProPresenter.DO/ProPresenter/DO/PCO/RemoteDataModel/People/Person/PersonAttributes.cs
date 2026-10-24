using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.People.Person;

public class PersonAttributes
{
	[JsonPropertyName("name")]
	public string? Name { get; init; }
}
