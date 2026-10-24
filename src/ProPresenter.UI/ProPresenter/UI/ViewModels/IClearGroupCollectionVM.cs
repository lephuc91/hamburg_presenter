using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.UI.Components;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.UI.ViewModels;

public interface IClearGroupCollectionVM : INotifyPropertyChanged
{
	ClearGroupCollection ClearGroupCollection { get; }

	INotifyEnumerableChanged<IClearGroupItemVM> ClearGroups { get; }

	IClearGroupItemVM? ActiveGroup { get; set; }

	ObservableCollection<IClearGroupItemVM> SelectedGroups { get; }

	BitmapSource? Icon { get; }

	string GroupName { get; set; }

	bool IsIconTinted { get; set; }

	Color IconFill { get; }

	Color IconTint { get; set; }

	bool ClearAudio { get; set; }

	bool ClearAudioEffects { get; set; }

	bool ClearMessages { get; set; }

	bool ClearProps { get; set; }

	bool ClearAnnouncements { get; set; }

	bool ClearPresentation { get; set; }

	bool ClearPresentationMedia { get; set; }

	bool ClearVideoInput { get; set; }

	bool StopAnnouncementsTimeline { get; set; }

	bool StopPresentationTimeline { get; set; }

	bool ClearPresentationNextSlide { get; set; }

	bool RenameNextItem { get; set; }

	bool IsPopupOpen { get; set; }

	ValidationRule NameValidationRule { get; }

	ICommand AddClearGroupCommand { get; }

	ICommand DeleteClearGroupCommand { get; }

	ICommand<bool> ToggleVisibilityCommand { get; }

	ICommand DuplicateClearGroupCommand { get; }

	ICommand GotFocusCommand { get; }

	ICommand<ImageType> SelectIconCommand { get; }

	ICommand CutCommand { get; }

	ICommand CopyCommand { get; }

	ICommand PasteCommand { get; }

	event Action<UndoStack?>? StackChanged;
}
