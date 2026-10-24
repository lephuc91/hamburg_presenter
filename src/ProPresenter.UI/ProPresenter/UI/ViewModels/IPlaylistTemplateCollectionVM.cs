using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.ViewModels;

public interface IPlaylistTemplateCollectionVM : INotifyPropertyChanged
{
	ICollectionView Templates { get; }

	ICollectionView TemplatesView { get; }

	IPlaylistTemplateItemVM? SelectedTemplate { get; }

	ObservableCollection<IPlaylistTemplateItemVM> SelectedTemplates { get; }

	ICommand<Playlist<ProPresenterCue>> SaveAsTemplateCommand { get; }

	ICommand EditTemplatesCommand { get; }

	ICommand DeleteTemplateCommand { get; }
}
