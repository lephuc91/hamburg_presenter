using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Text;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Media;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.UI.Commands;
using ProPresenter.UI.SlideEditor.Inspectors;

namespace ProPresenter.UI.ViewModels.Editor;

public interface ITextInspectorVM : INotifyPropertyChanged
{
	Range[] SelectionRanges { get; }

	int CaretIndex { get; }

	EditMode EditMode { get; set; }

	RunSettings ActiveRunSettings { get; }

	TextDocument? ActiveDocument { get; }

	LineFillMask? ActiveLineFillMask { get; }

	IEnumerable<ListPreset> AvailableListPresets { get; }

	bool ShowTextStyleControls { get; }

	CustomSlide? SelectedSlide { get; set; }

	ICommand<TextFillType> ChangeTextFillTypeCommand { get; }

	ICommand<DocumentSettingsCommandParameters> ApplyDocumentSettingsCommand { get; }

	ICommand<ParagraphSettingsCommandParameters> ApplyParagraphSettingsCommand { get; }

	ICommand<RunSettingsCommandParameters> ApplyRunSettingsCommand { get; }

	ICommand<LineFillMaskCommandParameters> ApplyLineFillMaskSettingsCommand { get; }

	ICommand FocusTextBoxCommand { get; }

	CommandTargetType CommandTargetType { get; set; }

	IScrollingTextInspectorVM ScrollingTextInspectorVM { get; }

	IMediaProvider MediaProvider { get; }

	IEnumerable<TextDocument> GetActiveDocuments(out bool editModeActive);
}
