using Pro.Common.Components;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.ViewModels;
using ProPresenter.ViewModels.Library;

namespace ProPresenter.ViewModels;

public class PlaylistTemplateItemVM : LinkedNotifyPropertyChangedBase, IPlaylistTemplateItemVM
{
	private readonly IPlaylistTemplatesService _service;

	public GeneralPlaylist Template { get; }

	public string Name
	{
		get
		{
			return Template.Name;
		}
		set
		{
			if (!_service.Exist(value))
			{
				Template.Name = value;
			}
			else
			{
				OnPropertyChanged("Name");
			}
		}
	}

	public PlaylistTemplateItemVM(GeneralPlaylist template, IPlaylistTemplatesService playlistTemplatesService)
	{
		_service = playlistTemplatesService;
		Template = template;
		LinkProperties("Name", "Name");
		Template.PropertyChanged += base.RaiseLinkedValues;
	}
}
