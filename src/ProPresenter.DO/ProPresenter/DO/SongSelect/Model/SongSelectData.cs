using System.Text.Json.Serialization;
using ProPresenter.DO.SongSelect.Model.API.Version;
using ProPresenter.DO.SongSelect.Model.Songs.ChordPro;
using ProPresenter.DO.SongSelect.Model.Songs.Lyrics;
using ProPresenter.DO.SongSelect.Model.Songs.Song;

namespace ProPresenter.DO.SongSelect.Model;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(SongDetail), "songDetail")]
[JsonDerivedType(typeof(SongLyrics), "songLyrics")]
[JsonDerivedType(typeof(SongLyricsPreview), "songLyricsPreview")]
[JsonDerivedType(typeof(SongChordPro), "songChordPro")]
[JsonDerivedType(typeof(VersionInfo), "versionInfo")]
public class SongSelectData
{
}
