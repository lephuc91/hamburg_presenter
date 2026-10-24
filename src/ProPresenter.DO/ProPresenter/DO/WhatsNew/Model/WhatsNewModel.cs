using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.WhatsNew.Model;

internal class WhatsNewModel
{
	[JsonPropertyName("version")]
	public string Version { get; set; } = string.Empty;

	[JsonPropertyName("accentColor")]
	public AccentColor? AccentColor { get; set; }

	[JsonPropertyName("features")]
	public List<FeatureItem> Features { get; set; } = new List<FeatureItem>();
}
