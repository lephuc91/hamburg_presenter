using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using Pro.DO.Storage;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;

namespace ProPresenter.Controller.Remote.Apps;

public class ProRemoteInteractor
{
	private readonly IProRemoteService _service;

	public LibraryCollection? Libraries { get; set; }

	public LibraryPlaylistCollection? PlaylistLibrary { get; set; }

	[GeneratedRegex("^(?:[0-9]+\\.)*[0-9]+\\:[0-9]+$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex PlaylistPathPattern()
	{
		return _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__PlaylistPathPattern_3.Instance;
	}

	public ProRemoteInteractor(IProRemoteService service)
	{
		_service = service;
	}

	public void HandleSlideTrigger(TriggerPresentationSlideRequest triggerRequest)
	{
		if (PlaylistPathPattern().IsMatch(triggerRequest.Path))
		{
			TriggerPlaylistItem(triggerRequest);
		}
		else
		{
			TriggerPresentationSlide(triggerRequest);
		}
	}

	private void TriggerPlaylistItem(TriggerPresentationSlideRequest triggerRequest)
	{
		if (PlaylistLibrary == null || !TryFindPlaylist(triggerRequest.Path, PlaylistLibrary.ToArray(), out IPlaylist<ProPresenterCue> playlist, out ProPresenterCue item))
		{
			return;
		}
		Playlist<ProPresenterCue> playlist2 = playlist as Playlist<ProPresenterCue>;
		if (playlist2 != null)
		{
			_service.SetActivePlaylist(playlist2);
			_service.SetActivePlaylistItem(item);
			CueHelper.TryExecute(item, delegate(IDocumentCue d, DocumentAction _)
			{
				TriggerPresentationSlide(d, triggerRequest.SlideIndex, activeItemChanged: true);
			}, delegate(IMediaCue c, MediaAction a)
			{
				_service.TriggerBackground((c is MediaCue mediaCue) ? mediaCue : a.ToCue(), playlist2, CueLocation.PlaylistLibrary);
			});
		}
	}

	private void TriggerPresentationSlide(TriggerPresentationSlideRequest triggerRequest, bool activeItemChanged = false)
	{
		if (Libraries == null)
		{
			return;
		}
		RelativePath path = new RelativePath(triggerRequest.Path);
		ILibrary library = Libraries.FirstOrDefault((ILibrary l) => l.Any((DocumentCue d) => d.DocumentAction.Presentation.SourceFile == path));
		DocumentCue cue = library?.FirstOrDefault((DocumentCue p) => p.DocumentAction.Presentation.SourceFile == path);
		if (library != null)
		{
			_service.SetActiveLibrary(library);
		}
		TriggerPresentationSlide(cue, triggerRequest.SlideIndex, activeItemChanged);
	}

	private void TriggerPresentationSlide(IDocumentCue? cue, int slideIndex, bool activeItemChanged = false)
	{
		if (cue != null)
		{
			if (!activeItemChanged)
			{
				_service.SetActivePlaylistItem((ProPresenterCue)cue);
			}
			IPresentation presentation = cue.DocumentAction?.Presentation;
			ArrangedCue arrangedCue = (cue.DocumentAction?.ActiveArrangement ?? presentation?.ActiveArrangement ?? presentation?.DefaultArrangement)?.ArrangedCues.ElementAtOrDefault(slideIndex);
			if (arrangedCue != null)
			{
				_service.TriggerSlide(arrangedCue);
			}
		}
	}

	private static bool TryFindPlaylist<T>(string path, IPlaylist<T>[] playlists, [NotNullWhen(true)] out IPlaylist<T>? playlist, [NotNullWhen(true)] out T? item) where T : ProPresenterCue
	{
		playlist = null;
		item = null;
		string[] array = path.Split(':');
		if (array.Length != 2)
		{
			return false;
		}
		string[] array2 = array[0].Split('.');
		if (!int.TryParse(array[1], out var result))
		{
			return false;
		}
		string[] array3 = array2;
		for (int j = 0; j < array3.Length; j++)
		{
			if (!int.TryParse(array3[j], out var result2))
			{
				return false;
			}
			if (result2 < 0 || result2 >= playlists.Length)
			{
				return false;
			}
			playlist = playlists[result2];
			if (playlist is GroupPlaylist<T> groupPlaylist)
			{
				playlists = groupPlaylist.Children.ToArray();
			}
		}
		Playlist<T> obj = playlist as Playlist<T>;
		item = ((obj != null) ? obj.Where((T i) => !i.IsHidden).ElementAtOrDefault(result) : null);
		return item != null;
	}
}
