using System.Text.Json.Serialization;

namespace ProPresenter.DO.ProContent.Consumer.Model.Content;

public class Pack : DownloadableAsset
{
	public const string TYPE_DISCRIMINATOR = "Pack";

	[JsonPropertyName("loop_count")]
	public int LoopCount { get; init; }

	[JsonPropertyName("image_count")]
	public int ImageCount { get; init; }

	[JsonPropertyName("countdown_count")]
	public int CountdownCount { get; init; }
}
