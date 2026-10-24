using System.Collections.Generic;
using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.TestPattern.Property;

public interface IBoolPropertyVM : ITestPatternPropertyVM, INotifyPropertyChanged
{
	bool Value { get; set; }

	IEnumerable<ITestPatternPropertyVM> DependentProperties { get; }
}
