using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.DO.Storage;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.TestPattern;
using ProPresenter.DO.TestPattern.State;
using ProPresenter.UI.ViewModels.TestPattern;

namespace ProPresenter.ViewModels.TestPattern;

public class TestPatternStateVM : LinkedNotifyPropertyChangedBase, ITestPatternStateVM, INotifyPropertyChanged
{
	private readonly string LOGO_BOUNCE_PATTERN_NAME = "LOGO_BOUNCE_TEST_PATTERN_title";

	private ITestPatternState? _state;

	private readonly ITestPatternService _testPatternService;

	private readonly IOutputService _outputService;

	private readonly IFileSelectorService _fileSelector;

	private readonly IFileFilterProvider _fileFilterProvider;

	public DisplayLocation DisplayLocation
	{
		get
		{
			return _state?.DisplayLocation ?? DisplayLocation.AllScreens;
		}
		set
		{
			if (_state != null)
			{
				_state.DisplayLocation = value;
			}
		}
	}

	public Guid SpecificScreen
	{
		get
		{
			return _state?.SpecificScreen ?? Guid.Empty;
		}
		set
		{
			if (_state != null)
			{
				_state.SpecificScreen = value;
			}
		}
	}

	public ScreenArrangementBase? TargetScreen => AudienceScreens.FirstOrDefault((ScreenArrangementBase s) => s.ID == SpecificScreen) ?? StageScreens.FirstOrDefault((ScreenArrangementBase s) => s.ID == SpecificScreen);

	public bool IdentifyScreens
	{
		get
		{
			return _state?.IdentifyScreens ?? false;
		}
		set
		{
			if (_state != null)
			{
				_state.IdentifyScreens = value;
			}
		}
	}

	public LogoType LogoType
	{
		get
		{
			LogoType logoType = _state?.LogoType ?? LogoType.None;
			if (logoType == LogoType.None && !CanDeselectLogo)
			{
				return LogoType.Propresenter;
			}
			return logoType;
		}
		set
		{
			if (_state != null)
			{
				_state.LogoType = value;
			}
		}
	}

	public RelativePath? UserLogoLocation
	{
		get
		{
			return _state?.UserLogoLocation ?? null;
		}
		[param: DisallowNull]
		set
		{
			if (_state != null)
			{
				_state.UserLogoLocation = value;
			}
		}
	}

	public bool CanDeselectLogo
	{
		get
		{
			if (_state?.Pattern != null)
			{
				return _state.Pattern.Name != LOGO_BOUNCE_PATTERN_NAME;
			}
			return true;
		}
	}

	public INotifyEnumerableChanged<ScreenArrangementBase> AudienceScreens => _outputService.OutputConfiguration.AudienceArrangementScreens;

	public INotifyEnumerableChanged<ScreenArrangementBase> StageScreens => _outputService.OutputConfiguration.StageArrangementScreens;

	public IRelayCommand ShowPatternCommand => _testPatternService.ShowPatternCommand;

	public IRelayCommand HidePatternCommand => _testPatternService.HidePatternCommand;

	public ICommand<DisplayLocation> SelectDisplayLocationCommand => new Pro.UI.Components.RelayCommand<DisplayLocation>(SelectDisplayLocationCommandExecuted, (DisplayLocation d) => d != DisplayLocation.SpecificScreen);

	public ICommand<ScreenArrangementBase> SelectScreenCommand => new Pro.UI.Components.RelayCommand<ScreenArrangementBase>(SelectScreenCommandExecuted, (ScreenArrangementBase s) => s != null);

	public ICommand<LogoType> SelectLogoTypeCommand => new Pro.UI.Components.RelayCommand<LogoType>(SelectLogoTypeCommandExecute);

	public ICommand<RelativePath> SelectCustomLogoCommand => new Pro.UI.Components.RelayCommand<RelativePath>(SelectCustomLogoCommandExecute, (RelativePath r) => r != null && !r.IsEmpty && LogoType != LogoType.User);

	public TestPatternStateVM(ITestPatternService testPatternService, IOutputService outputService, IFileSelectorService fileSelector, IFileFilterProvider fileFilterProvider)
	{
		LinkProperties("DisplayLocation", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "DisplayLocation", "TargetScreen" }));
		LinkProperties("SpecificScreen", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "SpecificScreen", "TargetScreen" }));
		LinkProperties("IdentifyScreens", "IdentifyScreens");
		LinkProperties("LogoType", "LogoType");
		LinkProperties("UserLogoLocation", "UserLogoLocation");
		LinkProperties("Pattern", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "CanDeselectLogo", "LogoType" }));
		_testPatternService = testPatternService;
		_outputService = outputService;
		_fileSelector = fileSelector;
		_fileFilterProvider = fileFilterProvider;
	}

	public void SetState(ITestPatternState state)
	{
		if (_state != null)
		{
			_state.PropertyChanged -= base.RaiseLinkedValues;
		}
		_state = state;
		_state.PropertyChanged += base.RaiseLinkedValues;
		NotifyPropertyChanged();
	}

	private void SelectDisplayLocationCommandExecuted(DisplayLocation displayLocation)
	{
		DisplayLocation = displayLocation;
		SpecificScreen = Guid.Empty;
	}

	private void SelectScreenCommandExecuted(ScreenArrangementBase screen)
	{
		DisplayLocation = DisplayLocation.SpecificScreen;
		SpecificScreen = screen.ID;
	}

	private void SelectLogoTypeCommandExecute(LogoType type)
	{
		switch (type)
		{
		case LogoType.None:
		case LogoType.Propresenter:
			LogoType = type;
			break;
		case LogoType.User:
		{
			if (_fileSelector.SelectFile(out string selectedFile, _fileFilterProvider.CustomizeFilextension(FileExtensions.ImageExtensions, false, "*.svg")))
			{
				UserLogoLocation = new RelativePath(selectedFile);
				LogoType = LogoType.User;
			}
			break;
		}
		}
	}

	private void SelectCustomLogoCommandExecute(RelativePath path)
	{
		UserLogoLocation = path;
		LogoType = LogoType.User;
	}

	private void NotifyPropertyChanged()
	{
		OnPropertyChanged("DisplayLocation");
		OnPropertyChanged("SpecificScreen");
		OnPropertyChanged("IdentifyScreens");
		OnPropertyChanged("LogoType");
		OnPropertyChanged("UserLogoLocation");
		OnPropertyChanged("CanDeselectLogo");
	}
}
