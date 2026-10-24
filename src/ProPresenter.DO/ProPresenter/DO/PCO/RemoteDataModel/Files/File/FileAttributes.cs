using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Files.File;

public class FileAttributes
{
	[JsonPropertyName("name")]
	public string? Name { get; init; }
}
