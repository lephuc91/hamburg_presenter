using System.Collections.ObjectModel;
using System.ComponentModel;
using ProPresenter.DO.Themes;
using ProPresenter.UI.SlideEditor;

namespace ProPresenter.UI.ViewModels.Editor;

public interface ITemplateEditorVM : ISlideEditorVM, INotifyPropertyChanged
{
	ThemeCollection Themes { get; }

	Theme? Theme { get; set; }

	TemplateSlide? SelectedTemplate { get; }

	ObservableCollection<SlideContainerBase> SlideContainers { get; }
}
