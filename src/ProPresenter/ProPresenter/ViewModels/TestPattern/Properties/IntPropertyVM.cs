using System.ComponentModel;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.UI.ViewModels.TestPattern.Property;

namespace ProPresenter.ViewModels.TestPattern.Properties;

public class IntPropertyVM : TestPatternPropertyVMBase, IIntPropertyVM, ITestPatternPropertyVM, INotifyPropertyChanged
{
	private readonly IIntProperty _property;

	public int Value
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

	public int Min => _property.Min;

	public int Max => _property.Max;

	public string Units => _property.Units;

	public IntPropertyVM(IIntProperty property)
		: base(property)
	{
		LinkProperties("Value", "Value");
		LinkProperties("Min", "Min");
		LinkProperties("Max", "Max");
		LinkProperties("Units", "Units");
		_property = property;
		_property.PropertyChanged += base.RaiseLinkedValues;
	}
}
