using System.Text.Json.Serialization;

namespace ProPresenter.DO.Organization.Avatar.RemoteModel;

public sealed class AvatarMetadataResult
{
	[JsonPropertyName("success")]
	public bool Success { get; init; }

	[JsonPropertyName("error")]
	public string Error { get; init; } = string.Empty;
}
