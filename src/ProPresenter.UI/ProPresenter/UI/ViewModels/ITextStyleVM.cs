using System;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Text;
using Pro.Text.Reversibility;
using Pro.UI.Components;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels;

public interface ITextStyleVM : INotifyPropertyChanged
{
	bool CanShowTextStylePopover { get; }

	ICommand<TargetStrategy> CopyTextStyleCommand { get; }

	ICommand<TargetStrategy> PasteTextStyleCommand { get; }

	ICommand ApplyTextStyleToAllSlidesCommand { get; }

	ICommand<TemplateSlide> ApplyTemplateCommand { get; }

	ICommand<(Action<TextDocumentSettings>, UndoActionTypes, bool)> ApplyDocumentSettingsCommand { get; }

	ICommand<(Action<ParagraphSettings>, UndoActionTypes, bool)> ApplyParagraphSettingsCommand { get; }

	ICommand<(Action<RunSettings>, UndoActionTypes, bool)> ApplyRunSettingsCommand { get; }
}
