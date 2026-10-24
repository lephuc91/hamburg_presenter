using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Media;

public interface IMediaSearchRootVM : INotifyPropertyChanged
{
	bool IsActive { get; set; }

	string Name { get; }

	string Path { get; }
}
