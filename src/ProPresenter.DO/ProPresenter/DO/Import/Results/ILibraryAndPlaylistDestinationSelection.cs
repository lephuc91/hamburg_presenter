using System.Diagnostics.CodeAnalysis;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Import.Results;

public interface ILibraryAndPlaylistDestinationSelection
{
	[MemberNotNullWhen(false, "Library")]
	bool IsCancel
	{
		[MemberNotNullWhen(false, "Library")]
		get;
	}

	ILibrary? Library { get; }

	IPlaylist<ProPresenterCue>? Playlist { get; }
}
