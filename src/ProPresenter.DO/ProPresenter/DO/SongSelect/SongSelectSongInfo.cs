using System.Collections.Generic;
using System.Linq;

namespace ProPresenter.DO.SongSelect;

public class SongSelectSongInfo
{
	public IEnumerable<SongSelectSongPart> Lyrics { get; init; } = Enumerable.Empty<SongSelectSongPart>();

	public string Title { get; init; } = string.Empty;

	public string Author { get; init; } = string.Empty;

	public string Publisher { get; init; } = string.Empty;

	public int SongId { get; init; }

	public string Copyright { get; init; } = string.Empty;
}
