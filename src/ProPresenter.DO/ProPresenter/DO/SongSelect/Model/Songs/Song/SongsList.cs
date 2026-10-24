using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Song;

public class SongsList
{
	public const string TYPE_DISCRIMINATOR = "songsList";

	[JsonPropertyName("listName")]
	public string ListName { get; init; } = string.Empty;

	[JsonPropertyName("territoryId")]
	public int TerritoryId { get; init; }

	[JsonPropertyName("results")]
	public SongListItem[] Results { get; init; } = Array.Empty<SongListItem>();
}
