using System.Collections.Generic;
using System.ComponentModel;

namespace ProPresenter.DO.TestPattern.Properties;

public interface ISelectorProperty : ITestPatternProperty, INotifyPropertyChanged
{
	int SelectedIndex { get; set; }

	IEnumerable<string> Values { get; set; }
}
