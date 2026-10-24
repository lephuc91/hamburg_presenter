using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Song;

public class SongContentLinks
{
	[JsonPropertyName("songSelectSong")]
	public string Song { get; init; } = string.Empty;

	[JsonPropertyName("songSelectSongLyrics")]
	public string Lyrics { get; init; } = string.Empty;

	[JsonPropertyName("songSelectChordSheet")]
	public string ChordSheet { get; init; } = string.Empty;

	[JsonPropertyName("songSelectLeadSheet")]
	public string LeadSheet { get; init; } = string.Empty;

	[JsonPropertyName("songSelectVocalSheet")]
	public string VocalSheet { get; init; } = string.Empty;
}
