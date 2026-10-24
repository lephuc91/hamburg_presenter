using System.Collections.Generic;
using ProPresenter.DO.Communication;

namespace ProPresenter.UI.ViewModels;

public interface ICommunicationActionDialogService
{
	IEnumerable<IDevice> Devices { get; }
}
