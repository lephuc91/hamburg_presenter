using System.Text.Json.Serialization;

namespace ProPresenter.DO.Organization.Avatar.RemoteModel;

public sealed class AvatarMetadata
{
	[JsonPropertyName("result")]
	public AvatarMetadataResult? Result { get; init; }

	[JsonPropertyName("data")]
	public AvatarMetadataData? Data { get; init; }
}
