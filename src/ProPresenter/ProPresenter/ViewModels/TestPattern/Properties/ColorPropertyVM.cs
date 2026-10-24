using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.UI.ViewModels.TestPattern.Property;

namespace ProPresenter.ViewModels.TestPattern.Properties;

public class ColorPropertyVM : TestPatternPropertyVMBase, IColorPropertyVM, ITestPatternPropertyVM, INotifyPropertyChanged
{
	private readonly IColorProperty _property;

	public Color Color
	{
		get
		{
			return _property.Color;
		}
		set
		{
			_property.Color = value;
		}
	}

	public bool AllowAlpha
	{
		get
		{
			return _property.AllowAlpha;
		}
		set
		{
			_property.AllowAlpha = value;
		}
	}

	public IEnumerable<Color> DefaultColors => _property.DefaultColors;

	public ColorPropertyVM(IColorProperty property)
		: base(property)
	{
		LinkProperties("Color", "Color");
		LinkProperties("AllowAlpha", "AllowAlpha");
		LinkProperties("DefaultColors", "DefaultColors");
		_property = property;
		_property.PropertyChanged += base.RaiseLinkedValues;
	}
}
