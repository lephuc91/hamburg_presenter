using System.Collections.ObjectModel;
using System.ComponentModel;
using ProPresenter.DO.Masks;
using ProPresenter.UI.SlideEditor;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IMaskEditorVM : ISlideEditorVM, INotifyPropertyChanged
{
	IMaskCollection Masks { get; }

	ObservableCollection<SlideContainerBase> SlideContainers { get; }
}
