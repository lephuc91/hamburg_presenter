using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Mathematics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels;

public interface INewPresentationVM : INotifyPropertyChanged
{
	string Name { get; set; }

	Vector2<double> Size { get; set; }

	ILibrary SelectedLibrary { get; }

	TemplateSlide SelectedTemplate { get; set; }

	IPlaylist<ProPresenterCue> SelectedPlaylist { get; }

	LibraryPlaylistCollection Playlists { get; }

	bool CanSelectPlaylist { get; set; }

	IRelayCommand<ILibrary> SelectLibraryCommand { get; }

	IRelayCommand<IPlaylist<ProPresenterCue>> SelectPlaylistCommand { get; }

	IRelayCommand SubmitCommand { get; }

	event Action CloseDialog;
}
