using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.ProContent.Consumer.Model.Content;

public class DownloadableAsset : Asset
{
	[JsonPropertyName("formats")]
	public Format[] Formats { get; init; } = Array.Empty<Format>();

	[JsonPropertyName("is_navigatable")]
	public bool IsNavigatable { get; init; }
}
