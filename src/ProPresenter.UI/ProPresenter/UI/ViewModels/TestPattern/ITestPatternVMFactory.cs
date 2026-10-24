using ProPresenter.DO.TestPattern;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.UI.ViewModels.TestPattern.Property;

namespace ProPresenter.UI.ViewModels.TestPattern;

public interface ITestPatternVMFactory
{
	ITestPatternItemVM? Create(ITestPatternDefinition? pattern);

	ITestPatternStateVM Create();

	ITestPatternPropertyVM? Create(ITestPatternProperty property);
}
