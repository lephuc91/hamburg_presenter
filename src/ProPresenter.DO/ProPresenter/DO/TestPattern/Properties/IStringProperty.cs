using System.ComponentModel;

namespace ProPresenter.DO.TestPattern.Properties;

public interface IStringProperty : ITestPatternProperty, INotifyPropertyChanged
{
	string Value { get; set; }

	int MinChars { get; }

	int MaxChars { get; }
}
