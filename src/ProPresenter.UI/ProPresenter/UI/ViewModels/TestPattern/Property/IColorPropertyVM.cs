using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace ProPresenter.UI.ViewModels.TestPattern.Property;

public interface IColorPropertyVM : ITestPatternPropertyVM, INotifyPropertyChanged
{
	Color Color { get; set; }

	bool AllowAlpha { get; }

	IEnumerable<Color> DefaultColors { get; }
}
