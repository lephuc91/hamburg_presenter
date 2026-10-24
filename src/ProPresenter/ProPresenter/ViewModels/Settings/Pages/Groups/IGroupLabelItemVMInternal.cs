using System.ComponentModel;
using Pro.DO.Label;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;

namespace ProPresenter.ViewModels.Settings.Pages.Groups;

public interface IGroupLabelItemVMInternal : IGroupLabelItemVM, INotifyPropertyChanged
{
	GroupLabel Label { get; }
}
