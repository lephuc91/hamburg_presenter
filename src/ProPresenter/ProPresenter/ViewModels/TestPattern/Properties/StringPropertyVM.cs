using System.ComponentModel;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.UI.ViewModels.TestPattern.Property;

namespace ProPresenter.ViewModels.TestPattern.Properties;

public class StringPropertyVM : TestPatternPropertyVMBase, IStringPropertyVM, ITestPatternPropertyVM, INotifyPropertyChanged
{
	private readonly IStringProperty _property;

	public string Value
	{
		get
		{
			return _property.Value;
		}
		set
		{
			_property.Value = value;
		}
	}

	public int MinChars => _property.MinChars;

	public int MaxChars => _property.MaxChars;

	public StringPropertyVM(IStringProperty property)
		: base(property)
	{
		LinkProperties("Value", "Value");
		LinkProperties("MinChars", "MinChars");
		LinkProperties("MaxChars", "MaxChars");
		_property = property;
		_property.PropertyChanged += base.RaiseLinkedValues;
	}
}
