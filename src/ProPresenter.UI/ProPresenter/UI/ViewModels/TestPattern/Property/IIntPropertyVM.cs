using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.TestPattern.Property;

public interface IIntPropertyVM : ITestPatternPropertyVM, INotifyPropertyChanged
{
	int Value { get; set; }

	int Min { get; }

	int Max { get; }

	string Units { get; }
}
