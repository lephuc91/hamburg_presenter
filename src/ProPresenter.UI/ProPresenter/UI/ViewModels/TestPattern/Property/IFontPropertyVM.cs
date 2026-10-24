using System.ComponentModel;
using Pro.Text;

namespace ProPresenter.UI.ViewModels.TestPattern.Property;

public interface IFontPropertyVM : ITestPatternPropertyVM, INotifyPropertyChanged
{
	FontInfo Font { get; set; }
}
