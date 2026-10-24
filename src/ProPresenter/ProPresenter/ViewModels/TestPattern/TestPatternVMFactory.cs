using Pro.Common.FileSystem;
using Pro.DO.Audio;
using Pro.UI.Utility;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.TestPattern;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.UI.ViewModels.TestPattern;
using ProPresenter.UI.ViewModels.TestPattern.Property;
using ProPresenter.ViewModels.TestPattern.Properties;

namespace ProPresenter.ViewModels.TestPattern;

public class TestPatternVMFactory : ITestPatternVMFactory
{
	private readonly ITestPatternService _testPatternService;

	private readonly IOutputService _outputService;

	private readonly IFileSelectorService _fileSelector;

	private readonly IAudioSetup _audioSetup;

	private readonly IFileFilterProvider _fileFilterProvider;

	public TestPatternVMFactory(ITestPatternService testPatternService, IOutputService outputService, IFileSelectorService fileSelector, IAudioSetup audioSetup, IFileFilterProvider fileFilterProvider)
	{
		_testPatternService = testPatternService;
		_outputService = outputService;
		_fileSelector = fileSelector;
		_audioSetup = audioSetup;
		_fileFilterProvider = fileFilterProvider;
	}

	public ITestPatternItemVM? Create(ITestPatternDefinition? pattern)
	{
		if (pattern == null)
		{
			return null;
		}
		return new TestPatternItemVM(pattern, _testPatternService, _outputService, this, _audioSetup);
	}

	public ITestPatternStateVM Create()
	{
		return new TestPatternStateVM(_testPatternService, _outputService, _fileSelector, _fileFilterProvider);
	}

	public ITestPatternPropertyVM? Create(ITestPatternProperty property)
	{
		if (!(property is IBoolProperty property2))
		{
			if (!(property is IColorProperty property3))
			{
				if (!(property is IDoubleProperty property4))
				{
					if (!(property is IIntProperty property5))
					{
						if (!(property is IFontProperty property6))
						{
							if (property is IStringProperty property7)
							{
								return new StringPropertyVM(property7);
							}
							return null;
						}
						return new FontPropertyVM(property6);
					}
					return new IntPropertyVM(property5);
				}
				return new DoublePropertyVM(property4);
			}
			return new ColorPropertyVM(property3);
		}
		return new BoolPropertyVM(property2, this);
	}
}
