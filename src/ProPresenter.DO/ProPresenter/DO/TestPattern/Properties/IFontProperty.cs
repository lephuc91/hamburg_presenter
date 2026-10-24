using System.ComponentModel;
using Pro.Text;

namespace ProPresenter.DO.TestPattern.Properties;

public interface IFontProperty : ITestPatternProperty, INotifyPropertyChanged
{
	FontInfo Font { get; set; }
}
