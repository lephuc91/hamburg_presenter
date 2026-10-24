using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Pro.Common.Time;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.TestPattern.Property;

namespace ProPresenter.UI.ViewModels.TestPattern;

public interface ITestPatternItemVM : INotifyPropertyChanged
{
	string Name { get; }

	IEnumerable<ITestPatternPropertyVM> Properties { get; }

	bool ShowDelaySettings { get; set; }

	TimeSlice MainDelay { get; set; }

	bool DisableMainOutputDevice { get; }

	TimeSlice SdiNdiDelay { get; set; }

	bool SdiNdiOutputActive { get; set; }

	BitmapSource? Thumbnail { get; }

	bool IsSelected { get; }

	IEnumerable<HardwareScreenRectangleOptions> VideoOutputs { get; }

	ICommand SelectPatternCommand { get; }
}
