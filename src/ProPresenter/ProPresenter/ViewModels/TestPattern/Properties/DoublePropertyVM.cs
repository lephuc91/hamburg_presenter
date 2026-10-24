using System.ComponentModel;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.UI.ViewModels.TestPattern.Property;

namespace ProPresenter.ViewModels.TestPattern.Properties;

public class DoublePropertyVM : TestPatternPropertyVMBase, IDoublePropertyVM, ITestPatternPropertyVM, INotifyPropertyChanged
{
	private readonly IDoubleProperty _property;

	public double Value
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

	public double Min => _property.Min;

	public double Max => _property.Max;

	public double StepSize => _property.StepSize;

	public string Units => _property.Units;

	public DoublePropertyVMViewType ViewType => ToViewType(_property.ViewType);

	public DoublePropertyVM(IDoubleProperty property)
		: base(property)
	{
		LinkProperties("Value", "Value");
		LinkProperties("Min", "Min");
		LinkProperties("Max", "Max");
		LinkProperties("Units", "Units");
		LinkProperties("ViewType", "ViewType");
		_property = property;
		_property.PropertyChanged += base.RaiseLinkedValues;
	}

	private DoublePropertyVMViewType ToViewType(DoublePropertyViewType viewType)
	{
		return viewType switch
		{
			DoublePropertyViewType.Slider => DoublePropertyVMViewType.Slider, 
			DoublePropertyViewType.SpeedSlider => DoublePropertyVMViewType.SpeedSlider, 
			_ => DoublePropertyVMViewType.Stepper, 
		};
	}
}
