using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.UI.Components;
using ProPresenter.UI.Commands;

namespace ProPresenter.UI.ViewModels.LooksDialog;

public interface ILooksDialogVM : INotifyPropertyChanged
{
	LiveAudienceLookVM LiveAudienceLook { get; }

	ImmutableObservableCollection<AudienceLookVM> AudienceLooks { get; }

	AudienceLookVM? ActiveLook { get; set; }

	LiveAudienceLookVM? SelectedLiveLook { get; set; }

	AudienceLookVM? SelectedLook { get; set; }

	ObservableCollection<AudienceLookVM> SelectedLooks { get; }

	bool EnableIdentify { get; set; }

	ICommand EditLooksCommand { get; }

	ICommand MakeLiveCommand { get; }

	ICommand AddLookCommand { get; }

	ICommand RemoveLookCommand { get; }

	ICommand DuplicateLookCommand { get; }

	ICommand SaveAsCommand { get; }

	ICommand<ShowSource> EditMasksCommand { get; }

	ICommand AddNewMaskCommand { get; }

	ICommand<AudienceLookVM> MakeSelectedLookLiveCommand { get; }

	event Action<bool> EditMasks;
}
