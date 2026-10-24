using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.Stage;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.UI.ViewModels;

public interface IStageVM : INotifyPropertyChanged
{
	ScreenArrangementBase? ActiveItem { get; set; }

	ObservableCollection<ScreenArrangementBase> SelectedItems { get; }

	ScreenArrangementBase? SelectedItem { get; set; }

	StageScreenArrangementCollection StageScreens { get; }

	IEnumerable<SlideCue> StageLayouts { get; }

	StageScreenLayoutMap ScreenLayoutMap { get; }

	string StageMessage { get; set; }

	IDeviceSelectorVM DeviceSelectorVM { get; }

	ICommand ShowMessageCommand { get; }

	ICommand HideMessageCommand { get; }

	ICommand<StageCueAssignmentParameter> ChangeLayoutCommand { get; }

	ICommand ConfigureScreensCommand { get; }

	ICommand<ScreenArrangementBase> EditLayoutsCommand { get; }

	ICommand DeleteStageScreenCommand { get; }
}
