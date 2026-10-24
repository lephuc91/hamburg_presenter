using System.Windows.Media.Imaging;
using ProPresenter.DO.Chords;

namespace ProPresenter.DO.MultiTracks;

public interface IMultiTracksSearchResult
{
	string Album { get; }

	string Artist { get; }

	bool HasAutomation { get; }

	bool HasChords { get; }

	bool HasLyrics { get; }

	long ID { get; }

	BitmapSource? Image { get; }

	string ImageURL { get; }

	string LyricsPreview { get; }

	Key? OriginalKey { get; }

	string Title { get; }
}
