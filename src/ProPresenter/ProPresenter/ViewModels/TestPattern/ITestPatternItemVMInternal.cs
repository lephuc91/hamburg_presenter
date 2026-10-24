using System.ComponentModel;
using ProPresenter.DO.TestPattern;
using ProPresenter.UI.ViewModels.TestPattern;

namespace ProPresenter.ViewModels.TestPattern;

public interface ITestPatternItemVMInternal : ITestPatternItemVM, INotifyPropertyChanged
{
	ITestPatternDefinition Pattern { get; }
}
