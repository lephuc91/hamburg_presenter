using System.Text.Json.Serialization;

namespace ProPresenter.DO.SongSelect.Model.Rights;

public class UserRights
{
	[JsonPropertyName("type")]
	public string Type { get; init; } = string.Empty;

	[JsonPropertyName("linkedOrganization")]
	public string LinkedOrganization { get; init; } = string.Empty;

	[JsonPropertyName("accountNumber")]
	public string AccountNumber { get; init; } = string.Empty;

	[JsonPropertyName("songMetadata")]
	public AccessRight SongMetadata { get; init; } = new AccessRight();

	[JsonPropertyName("lyrics")]
	public AccessRight Lyrics { get; init; } = new AccessRight();

	[JsonPropertyName("chordSheet")]
	public AccessRight ChordSheet { get; init; } = new AccessRight();
}
