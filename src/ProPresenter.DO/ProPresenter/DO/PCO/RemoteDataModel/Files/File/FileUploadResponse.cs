using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Files.File;

public class FileUploadResponse
{
	[JsonPropertyName("data")]
	[JsonRequired]
	public FileData[] Data { get; init; } = Array.Empty<FileData>();
}
