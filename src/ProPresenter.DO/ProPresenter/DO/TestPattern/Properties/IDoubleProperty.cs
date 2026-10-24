using System.ComponentModel;

namespace ProPresenter.DO.TestPattern.Properties;

public interface IDoubleProperty : ITestPatternProperty, INotifyPropertyChanged
{
	double Value { get; set; }

	double Min { get; }

	double Max { get; }

	double StepSize { get; }

	string Units { get; }

	DoublePropertyViewType ViewType { get; }
}
