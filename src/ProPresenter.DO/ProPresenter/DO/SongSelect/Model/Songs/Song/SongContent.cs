using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Song;

public class SongContent
{
	[JsonPropertyName("lyrics")]
	public SongContentDefinition Lyrics { get; init; } = new SongContentDefinition();

	[JsonPropertyName("chordSheet")]
	public SongContentDefinition ChordSheet { get; init; } = new SongContentDefinition();

	[JsonPropertyName("vocalSheet")]
	public SongContentDefinition VocalSheet { get; init; } = new SongContentDefinition();

	[JsonPropertyName("leadSheet")]
	public SongContentDefinition LeadSheet { get; init; } = new SongContentDefinition();
}
