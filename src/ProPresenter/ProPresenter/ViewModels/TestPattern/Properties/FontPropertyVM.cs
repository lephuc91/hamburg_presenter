using System.ComponentModel;
using Pro.Text;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.UI.ViewModels.TestPattern.Property;

namespace ProPresenter.ViewModels.TestPattern.Properties;

public class FontPropertyVM : TestPatternPropertyVMBase, IFontPropertyVM, ITestPatternPropertyVM, INotifyPropertyChanged
{
	private readonly IFontProperty _property;

	public FontInfo Font
	{
		get
		{
			return _property.Font;
		}
		set
		{
			_property.Font = value;
		}
	}

	public FontPropertyVM(IFontProperty property)
		: base(property)
	{
		LinkProperties("Font", "Font");
		_property = property;
		_property.PropertyChanged += base.RaiseLinkedValues;
	}
}
