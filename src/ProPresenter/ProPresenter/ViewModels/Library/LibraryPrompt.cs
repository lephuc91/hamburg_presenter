using System;
using System.Text;
using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.ViewModels.Library;

public class LibraryPrompt : ILibraryPrompt
{
	public bool ConfirmDeleteLibraries()
	{
		return MessageDialogService.ShowSimpleContent(string.Empty, LocalizedStrings.Get("LIBRARY_PLAYLIST_ALERT_REMOVE_LIBRARIES_message") + "\r\n" + LocalizedStrings.Get("LIBRARY_PLAYLIST_ALERT_REMOVE_LIBRARIES_info"));
	}

	public bool ConfirmDeletePresentation(string[] presentationNames)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (presentationNames.Length == 1)
		{
			stringBuilder.Append(string.Format(LocalizedStrings.Get("LIBRARY_PLAYLIST_ALERT_REMOVE_PRESENTATION_message"), presentationNames[0]));
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append(LocalizedStrings.Get("LIBRARY_PLAYLIST_ALERT_REMOVE_PRESENTATION_info"));
		}
		else
		{
			stringBuilder.Append(string.Format(LocalizedStrings.Get("LIBRARY_PLAYLIST_ALERT_REMOVE_PRESENTATION_PLURAL_message"), presentationNames.Length));
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append(LocalizedStrings.Get("LIBRARY_PLAYLIST_ALERT_REMOVE_PRESENTATION_PLURAL_info"));
		}
		return MessageDialogService.ShowSimpleContent(string.Empty, stringBuilder.ToString());
	}

	public void ShowNoInternet()
	{
		MessageDialogService.ShowDialog(LocalizedStrings.Get("GLOBAL_NO_INTERNET_CONNECTION_message"), LocalizedStrings.Get("GLOBAL_NO_INTERNET_CONNECTION_info"), DefaultButtons.OK, DefaultButtons.OK);
	}

	public void ShowNoPlaylistSelected()
	{
		MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("LIBRARY_PLAYLIST_ALERT_NO_PLAYLIST_SELECTED_label"), DefaultButtons.OK, DefaultButtons.OK);
	}
}
