namespace ProPresenter.ViewModels.Library;

public interface ILibraryPrompt
{
	void ShowNoPlaylistSelected();

	bool ConfirmDeleteLibraries();

	bool ConfirmDeletePresentation(string[] presentationNames);

	void ShowNoInternet();
}
