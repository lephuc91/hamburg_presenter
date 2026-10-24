using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.TestPattern.Property;

public interface IStringPropertyVM : ITestPatternPropertyVM, INotifyPropertyChanged
{
	string Value { get; set; }

	int MinChars { get; }

	int MaxChars { get; }
}
