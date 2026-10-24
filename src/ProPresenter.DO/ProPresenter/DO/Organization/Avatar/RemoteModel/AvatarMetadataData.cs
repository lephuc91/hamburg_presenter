using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.Organization.Avatar.RemoteModel;

public sealed class AvatarMetadataData
{
	[JsonPropertyName("url")]
	public string? Url { get; init; }

	[JsonPropertyName("expires_at")]
	public DateTimeOffset? ExpiresAt { get; init; }

	[JsonPropertyName("last_modified_at")]
	public DateTimeOffset? LastModifiedAt { get; init; }
}
