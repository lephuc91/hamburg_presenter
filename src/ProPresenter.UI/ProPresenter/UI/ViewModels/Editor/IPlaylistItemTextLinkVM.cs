using System.ComponentModel;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IPlaylistItemTextLinkVM : INotifyPropertyChanged
{
	PlaylistItemSource PlaylistItemSource { get; set; }

	bool ShowArrangement { get; set; }
}
