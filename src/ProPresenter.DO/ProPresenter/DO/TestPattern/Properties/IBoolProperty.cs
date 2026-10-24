using System.Collections.Generic;
using System.ComponentModel;

namespace ProPresenter.DO.TestPattern.Properties;

public interface IBoolProperty : ITestPatternProperty, INotifyPropertyChanged
{
	bool Value { get; set; }

	IReadOnlyCollection<ITestPatternProperty> DependentProperties { get; }
}
