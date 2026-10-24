using System.ComponentModel;

namespace ProPresenter.DO.TestPattern.Properties;

public interface IIntProperty : ITestPatternProperty, INotifyPropertyChanged
{
	int Value { get; set; }

	int Min { get; }

	int Max { get; }

	string Units { get; }
}
