using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.API.Version;

public class VersionInfo
{
	public const string TYPE_DISCRIMINATOR = "versionInfo";

	[JsonPropertyName("type")]
	public string Type { get; init; } = string.Empty;

	[JsonPropertyName("apiName")]
	public string ApiName { get; init; } = string.Empty;

	[JsonPropertyName("version")]
	public string Version { get; init; } = string.Empty;

	[JsonPropertyName("build")]
	public string Build { get; init; } = string.Empty;

	[JsonPropertyName("copyright")]
	public string Copyright { get; init; } = string.Empty;
}
