using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.Folder;

public class FolderAttributes
{
	[JsonPropertyName("name")]
	public string? Name { get; init; }
}
