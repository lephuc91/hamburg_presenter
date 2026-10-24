using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Songs.Song;

public class SongContentDefinition
{
	[JsonPropertyName("exists")]
	public bool Exists { get; init; }

	[JsonPropertyName("isAuthorized")]
	public bool IsAuthorized { get; init; }
}
