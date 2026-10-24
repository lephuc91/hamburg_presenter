using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Utility;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels.Editor;

public interface ITemplateSlideInspectorVM : INotifyPropertyChanged
{
	EditMode EditMode { get; set; }

	TemplateSlide? SelectedTemplate { get; set; }

	MediaAction? MediaAction { get; }

	string Name { get; set; }

	bool UseBackgroundColor { get; set; }

	Color BackgroundColor { get; set; }

	ICommand<ColorPair> ColorChangeFinishedCommand { get; }

	ICommand AddMediaActionCommand { get; }

	ICommand RemoveMediaActionCommand { get; }

	ICommand ChooseGraphicMediaFileCommand { get; }

	ICommand ShowInFileExplorerCommand { get; }

	ITransportMedia? TransportMedia { get; }
}
