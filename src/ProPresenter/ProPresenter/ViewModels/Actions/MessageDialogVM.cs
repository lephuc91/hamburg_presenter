using System.Collections.Generic;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Timer;

namespace ProPresenter.ViewModels.Actions;

public class MessageDialogVM : ActionDialogContentVM
{
	public TimerCollection Timers => DataVault.TimerDocument.Timers;

	public IEnumerable<Message> Messages => DataVault.Messages;

	public ICommand<Message> SelectMessageCommand => new RelayCommand<Message>(OnSelectMessageCommand, (Message m) => base.ActionStore.CanAssignData(m, base.Action));

	private void OnSelectMessageCommand(Message message)
	{
		((MessageAction)base.Action).SetMessage(message);
	}
}
