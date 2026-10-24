using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Files.File;

public class FileData
{
	[JsonPropertyName("attributes")]
	[JsonRequired]
	public FileAttributes? Attributes { get; init; }

	[JsonPropertyName("id")]
	[JsonRequired]
	public string? Id { get; init; }
}
