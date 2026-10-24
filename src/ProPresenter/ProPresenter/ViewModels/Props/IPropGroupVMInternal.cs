using System.ComponentModel;
using ProPresenter.DO.Props;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.ViewModels.Props;

public interface IPropGroupVMInternal : IPropGroupVM, INotifyPropertyChanged
{
	IPropGroup Source { get; }
}
