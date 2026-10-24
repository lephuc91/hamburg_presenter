using System.ComponentModel;
using Pro.DO.Triggering;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.DO.Props;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.ViewModels.Props;

public interface IPropCueVMInternal : IPropCueVM, INotifyPropertyChanged, IUniformViewSource, ITriggerable
{
	IPropCue Source { get; }
}
