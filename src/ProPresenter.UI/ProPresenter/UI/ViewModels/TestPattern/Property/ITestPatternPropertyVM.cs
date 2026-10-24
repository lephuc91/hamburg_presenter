using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.TestPattern.Property;

public interface ITestPatternPropertyVM : INotifyPropertyChanged
{
	string Name { get; }

	bool IsShown { get; set; }
}
