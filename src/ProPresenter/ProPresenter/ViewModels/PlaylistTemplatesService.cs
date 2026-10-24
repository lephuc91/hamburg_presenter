using System.Linq;
using Pro.Common.Strings;
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.LibraryView;
using ProPresenter.ViewModels.Library;

namespace ProPresenter.ViewModels;

public class PlaylistTemplatesService : IPlaylistTemplatesService
{
	public PlaylistTemplateCollection Templates { get; }

	public PlaylistTemplatesService(PlaylistTemplateCollection templates)
	{
		Templates = templates;
	}

	public bool ShowSaveAsTemplateDialog(string name, out string newName)
	{
		newName = name;
		SaveAsTemplateWindow saveAsTemplateWindow = new SaveAsTemplateWindow
		{
			TemplateName = newName
		};
		if (saveAsTemplateWindow.ShowDialog() == true)
		{
			newName = saveAsTemplateWindow.TemplateName;
			return true;
		}
		return false;
	}

	public bool ResolveConflict(string name, out string newName)
	{
		newName = name;
		if (Templates.Any((IPlaylist<ProPresenterCue> p) => p.Name == name))
		{
			string message = LocalizedStrings.Get("LIBRARY_PLAYLIST_TEMPLATE_CONFLICT_ALERT_message", new object[1] { newName }) + "\n\n" + LocalizedStrings.Get("LIBRARY_PLAYLIST_TEMPLATE_CONFLICT_ALERT_info", new object[1] { newName });
			FileExistsResult? fileExistsResult = MessageDialogService.ShowDialog(string.Empty, message, FileExistsResult.AddNewVersion | FileExistsResult.WriteOver | FileExistsResult.Cancel, FileExistsResult.WriteOver);
			if (fileExistsResult.HasValue && fileExistsResult.Value != FileExistsResult.Cancel)
			{
				newName = ((fileExistsResult.Value == FileExistsResult.WriteOver) ? name : name.DuplicateName(Templates, (IPlaylist<ProPresenterCue> t) => t.Name));
				return true;
			}
			return false;
		}
		return true;
	}

	public bool Exist(string name)
	{
		bool flag = Templates.Any((IPlaylist<ProPresenterCue> p) => p.Name == name);
		if (flag)
		{
			MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("LIBRARY_PLAYLIST_TEMPLATE_CONFLICT_ALERT_message", new object[1] { name }), DefaultButtons.OK, DefaultButtons.OK);
		}
		return flag;
	}
}
