using System.Collections.Generic;
using System.ComponentModel;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.UI.ViewModels.TestPattern;
using ProPresenter.UI.ViewModels.TestPattern.Property;

namespace ProPresenter.ViewModels.TestPattern.Properties;

public class BoolPropertyVM : TestPatternPropertyVMBase, IBoolPropertyVM, ITestPatternPropertyVM, INotifyPropertyChanged
{
	private readonly IBoolProperty _property;

	private readonly ITestPatternVMFactory _factory;

	public bool Value
	{
		get
		{
			return _property.Value;
		}
		set
		{
			_property.Value = value;
			foreach (ITestPatternPropertyVM dependentProperty in DependentProperties)
			{
				dependentProperty.IsShown = value;
			}
		}
	}

	public IEnumerable<ITestPatternPropertyVM> DependentProperties { get; }

	public BoolPropertyVM(IBoolProperty property, ITestPatternVMFactory factory)
		: base(property)
	{
		LinkProperties("Value", "Value");
		LinkProperties("DependentProperties", "DependentProperties");
		_property = property;
		_factory = factory;
		DependentProperties = GetDependentProperties();
		_property.PropertyChanged += base.RaiseLinkedValues;
	}

	private IEnumerable<ITestPatternPropertyVM> GetDependentProperties()
	{
		List<ITestPatternPropertyVM> list = new List<ITestPatternPropertyVM>();
		foreach (ITestPatternProperty dependentProperty in _property.DependentProperties)
		{
			ITestPatternPropertyVM testPatternPropertyVM = _factory.Create(dependentProperty);
			if (testPatternPropertyVM != null)
			{
				testPatternPropertyVM.IsShown = Value;
				list.Add(testPatternPropertyVM);
			}
		}
		return list;
	}
}
