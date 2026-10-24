using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ProPresenter.DO.Media.Sample;

public class SampleData
{
	[JsonConverter(typeof(StringEnumConverter))]
	public SampleType Type { get; set; }

	public string? Name { get; set; }

	public string? Description { get; set; }

	public string? InfoUrl { get; set; }

	public long DownloadSize { get; set; }

	public string? ResourceKey { get; set; }

	public SampleData[]? Children { get; set; }
}
