using System;
using System.Text.Json.Serialization;
using Pro.Common.Serialization;

namespace ProPresenter.DO.PCO.RemoteDataModel.Services.Song;

public class SongAttributes
{
	[JsonPropertyName("title")]
	public string Title { get; init; } = string.Empty;

	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; init; }

	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; init; }

	[JsonPropertyName("admin")]
	public string Admin { get; init; } = string.Empty;

	[JsonPropertyName("author")]
	public string Author { get; init; } = string.Empty;

	[JsonPropertyName("copyright")]
	public string Copyright { get; init; } = string.Empty;

	[JsonPropertyName("hidden")]
	public bool Hidden { get; init; }

	[JsonPropertyName("ccli_number")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	[JsonConverter(typeof(MayBeNullValueConverter<uint>))]
	public uint CcliNumber { get; init; }
}
