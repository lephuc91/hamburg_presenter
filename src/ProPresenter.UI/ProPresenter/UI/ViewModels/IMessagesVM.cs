using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.DO.Token;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.ViewModels;

public interface IMessagesVM : INotifyPropertyChanged
{
	IReadOnlyList<TimeSlice> RemoveTimes { get; }

	IEnumerable<Message> ActiveMessages { get; }

	bool IsEditing { get; set; }

	string Text { get; set; }

	bool IsVisibleOnNetwork { get; set; }

	MessageCollection Messages { get; }

	bool HasMessages { get; }

	TemplateSlide? SelectedTemplate { get; }

	TokenCollection<MessageTokenBase> AvailableTokens { get; }

	IEnumerable<TimerToken> Timers { get; }

	Message? ActiveMessage { get; set; }

	IEnumerable<MessageTokenBase>? ActiveMessageTokens { get; }

	Message? SelectedMessage { get; set; }

	ObservableCollection<Message> SelectedMessages { get; }

	TransitionHandler TransitionHandler { get; }

	TransitionParameters? SelectedTransition { get; set; }

	TimerCollection TimerCollection { get; }

	bool RenameNextItem { get; set; }

	string AddTokenText { get; set; }

	ICommand AddMessageCommand { get; }

	ICommand ShowMessageCommand { get; }

	ICommand ClearMessageCommand { get; }

	ICommand ClearSelectedMessagesCommand { get; }

	ICommand<TimerData?> StartCommand { get; }

	ICommand<TimerData?> StopCommand { get; }

	ICommand<TimerData?> ResetCommand { get; }

	ICommand<TemplateSlide> SelectTemplateCommand { get; }

	ICommand ClearAllMessagesCommand { get; }

	ICommand<MessageClearType> SetMessageClearTypeCommand { get; }

	ICommand<TimeSlice> SetMessageClearTimeCommand { get; }

	ICommand OpenNetworkMessagesCommand { get; }

	ICommand GotFocusCommand { get; }

	ICommand<bool> DocumentChangeStartedCommand { get; }

	ICommand<bool> DocumentChangeEndedCommand { get; }

	ICommand<Message?> SelectMessageCommand { get; }

	ICommand CutCommand { get; }

	ICommand CopyCommand { get; }

	ICommand PasteCommand { get; }

	ICommand DuplicateCommand { get; }

	ICommand DeleteCommand { get; }

	ICommand<MessageTokenBase> AddTokenCommand { get; }

	ICommand<string> AddCustomTokenCommand { get; }

	event Action<UndoStack?>? StackChanged;
}
