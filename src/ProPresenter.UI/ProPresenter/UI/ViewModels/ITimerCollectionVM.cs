using System;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.UI.Components;

namespace ProPresenter.UI.ViewModels;

public interface ITimerCollectionVM : INotifyPropertyChanged
{
	INotifyEnumerableChanged<ITimerVM> Timers { get; }

	ICommand AddTimerItemCommand { get; }

	ICommand<Guid> RemoveTimerCommand { get; }

	ICommand<Guid> StartCommand { get; }

	ICommand<Guid> StopCommand { get; }

	ICommand<Guid> ResetCommand { get; }

	ICommand StartAllCommand { get; }

	ICommand ResetAllCommand { get; }

	ICommand StopAllCommand { get; }

	ICommand GotFocusCommand { get; }

	event Action<UndoStack?> StackChanged;
}
