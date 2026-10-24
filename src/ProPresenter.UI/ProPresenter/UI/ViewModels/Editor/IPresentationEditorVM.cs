using System.Collections.ObjectModel;
using System.ComponentModel;
using Pro.UI.Components;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Themes;
using ProPresenter.UI.SlideEditor;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IPresentationEditorVM : ISlideEditorVM, INotifyPropertyChanged
{
	CustomPresentation? Presentation { get; set; }

	Theme StageTheme { get; }

	IDocumentInspectorVM DocumentInspectorVM { get; }

	ObservableCollection<CueGroupKey> CueGroupKeys { get; }

	ICommand<ScreenArrangementBase> ShowStageLayoutToTargetScreenCommand { get; }

	ICommand<TemplateSlide> ApplyTemplateToSelectedSlidesCommand { get; }
}
