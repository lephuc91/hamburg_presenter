using System.ComponentModel;
using Pro.Common.Components;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.UI.ViewModels.TestPattern.Property;

namespace ProPresenter.ViewModels.TestPattern.Properties;

public abstract class TestPatternPropertyVMBase : LinkedNotifyPropertyChangedBase, ITestPatternPropertyVM, INotifyPropertyChanged
{
	private bool _isShown = true;

	private readonly ITestPatternProperty _property;

	public string Name => _property.Name;

	public bool IsShown
	{
		get
		{
			return _isShown;
		}
		set
		{
			SetValue("IsShown", ref _isShown, value);
		}
	}

	protected TestPatternPropertyVMBase(ITestPatternProperty property)
	{
		_property = property;
	}
}
