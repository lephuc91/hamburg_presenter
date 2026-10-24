using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace ProPresenter.DO.TestPattern.Properties;

public interface IColorProperty : ITestPatternProperty, INotifyPropertyChanged
{
	Color Color { get; set; }

	bool AllowAlpha { get; set; }

	IEnumerable<Color> DefaultColors { get; }
}
