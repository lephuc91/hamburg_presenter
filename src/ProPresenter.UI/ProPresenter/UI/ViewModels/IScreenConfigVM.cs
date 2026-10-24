using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Components.Reversibility;
using Pro.UI.Components;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.OutputConfiguration;

namespace ProPresenter.UI.ViewModels;

public interface IScreenConfigVM : INotifyPropertyChanged
{
	IOutputConfiguration OutputConfiguration { get; }

	AudienceScreenArrangementCollection AudienceArrangementScreens { get; }

	StageScreenArrangementCollection StageArrangementScreens { get; }

	IEnumerable<ScreenArrangementBase> Screens { get; }

	ScreenArrangementBase? SelectedScreenArrangement { get; set; }

	ScreenArrangementBase? SelectedAudienceScreenArrangement { get; set; }

	ScreenArrangementBase? SelectedStageScreenArrangement { get; set; }

	bool IdentifyScreensActive { get; set; }

	IEnumerable<PhysicalDevice?>? AttachedPhysicalDevices { get; }

	ICommand<ScreenArrangementBase> RemoveScreenArrangementCommand { get; }

	ICommand<ScreenArrangementType> ChangeArrangementTypeCommand { get; }

	ICommand<DeviceCommandParameter?> AssignDeviceCommand { get; }

	ICommand GotFocusCommand { get; }

	ICommand<ScreenArrangementBase> ActivateScreenArrangementCommand { get; }

	ICommand<PhysicalDevice> IdentifyScreenCommand { get; }

	ICommand ClearScreenIdentifyCommand { get; }

	ICommand AddCombinedScreenCommand { get; }

	ICommand AddEdgeBlendScreenCommand { get; }

	bool CanAddMoreScreens { get; }

	ICommand ShowHelpCommand { get; }

	event Action<UndoStack?>? StackChanged;
}
