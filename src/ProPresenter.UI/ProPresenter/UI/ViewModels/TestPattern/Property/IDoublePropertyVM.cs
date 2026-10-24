using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.TestPattern.Property;

public interface IDoublePropertyVM : ITestPatternPropertyVM, INotifyPropertyChanged
{
	double Value { get; set; }

	double Min { get; }

	double Max { get; }

	double StepSize { get; }

	string Units { get; }

	DoublePropertyVMViewType ViewType { get; }
}
