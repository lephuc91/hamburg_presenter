using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Print;

namespace ProPresenter.UI.ViewModels;

public interface IPrintVM : INotifyPropertyChanged
{
	PrintOptions PrintOptions { get; }

	PrintManager PrintManager { get; }

	ICommand OpenPrintSettingCommand { get; }

	ICommand OpenPreviewCommand { get; }

	ICommand PrintCommand { get; }

	ICommand<IEnumerable<IDocumentCue>> SetPrintTargetCommmand { get; }
}
