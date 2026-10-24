using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.DO.Audio;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.TestPattern;
using ProPresenter.DO.TestPattern.Properties;
using ProPresenter.UI.ViewModels.TestPattern;
using ProPresenter.UI.ViewModels.TestPattern.Property;

namespace ProPresenter.ViewModels.TestPattern;

public class TestPatternItemVM : LinkedNotifyPropertyChangedBase, ITestPatternItemVMInternal, ITestPatternItemVM, INotifyPropertyChanged
{
	private readonly ITestPatternDefinition _pattern;

	private readonly ITestPatternService _testPatternService;

	private readonly IOutputService _outputService;

	private readonly ITestPatternVMFactory _factory;

	private readonly IAudioSetup _audioSetup;

	private IEnumerable<ITestPatternPropertyVM> _properties;

	public string Name => _pattern.Name;

	public IEnumerable<ITestPatternPropertyVM> Properties
	{
		get
		{
			return _properties;
		}
		[MemberNotNull("_properties")]
		private set
		{
			SetValue("Properties", ref _properties, value);
		}
	}

	public bool ShowDelaySettings
	{
		get
		{
			return _pattern.ShowDelaySettings;
		}
		set
		{
			if (_pattern != null)
			{
				_pattern.ShowDelaySettings = value;
			}
		}
	}

	public TimeSlice MainDelay
	{
		get
		{
			return _audioSetup.MainDelay;
		}
		set
		{
			_audioSetup.MainDelay = value;
		}
	}

	public bool DisableMainOutputDevice => _audioSetup.DisableMainOutputDevice;

	public TimeSlice SdiNdiDelay
	{
		get
		{
			return _audioSetup.SdiNdiDelay;
		}
		set
		{
			_audioSetup.SdiNdiDelay = value;
		}
	}

	public bool SdiNdiOutputActive
	{
		get
		{
			return _audioSetup.SdiNdiOutputActive;
		}
		set
		{
			_audioSetup.SdiNdiOutputActive = value;
		}
	}

	public BitmapSource? Thumbnail => _pattern.Thumbnail;

	public bool IsSelected => _pattern == _testPatternService?.SelectedPattern;

	public IEnumerable<HardwareScreenRectangleOptions> VideoOutputs => GetScreens().NonNull();

	public ICommand SelectPatternCommand => new RelayCommand(SelectPatternCommandExecute);

	public ITestPatternDefinition Pattern => _pattern;

	public TestPatternItemVM(ITestPatternDefinition pattern, ITestPatternService testPatternService, IOutputService outputService, ITestPatternVMFactory factory, IAudioSetup audioSetup)
	{
		LinkProperties("Name", "Name");
		LinkAction("Properties", CreatePropertyList);
		LinkProperties("ShowDelaySettings", "ShowDelaySettings");
		LinkProperties("Thumbnail", "Thumbnail");
		LinkProperties("SelectedPattern", "IsSelected");
		LinkProperties("Screens", "VideoOutputs");
		LinkProperties("MainDelay", "MainDelay");
		LinkProperties("DisableMainOutputDevice", "DisableMainOutputDevice");
		LinkProperties("SdiNdiDelay", "SdiNdiDelay");
		LinkProperties("SdiNdiOutputActive", "SdiNdiOutputActive");
		_pattern = pattern;
		_pattern.PropertyChanged += base.RaiseLinkedValues;
		_testPatternService = testPatternService;
		_testPatternService.PropertyChanged += base.RaiseLinkedValues;
		_outputService = outputService;
		_factory = factory;
		_audioSetup = audioSetup;
		_audioSetup.PropertyChanged += base.RaiseLinkedValues;
		SetupScreenArrangements(_outputService.OutputConfiguration.AudienceArrangementScreens);
		SetupScreenArrangements(_outputService.OutputConfiguration.StageArrangementScreens);
		CreatePropertyList();
	}

	private void SetupScreenArrangements(ScreenArrangementCollectionBase screenArrangementCollection)
	{
		if (screenArrangementCollection == null)
		{
			return;
		}
		screenArrangementCollection.CollectionChanged += ScreenArrangementCollection_CollectionChanged;
		foreach (ScreenArrangementBase item in screenArrangementCollection)
		{
			item.PropertyChanged += base.RaiseLinkedValues;
		}
	}

	private void ScreenArrangementCollection_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ScreenArrangementBase>().ForEach(delegate(ScreenArrangementBase s)
		{
			s.PropertyChanged -= base.RaiseLinkedValues;
		});
		e.NewItems?.OfType<ScreenArrangementBase>().ForEach(delegate(ScreenArrangementBase s)
		{
			s.PropertyChanged += base.RaiseLinkedValues;
		});
		OnPropertyChanged("VideoOutputs");
	}

	private IEnumerable<HardwareScreenRectangleOptions> GetScreens()
	{
		if (_outputService?.OutputConfiguration != null)
		{
			return _outputService.OutputConfiguration.AudienceArrangementScreens.Concat(_outputService.OutputConfiguration.StageArrangementScreens).SelectMany((ScreenArrangementBase s) => s.Screens).SelectMany((Screen s) => s.HardwareRectangles);
		}
		return Array.Empty<HardwareScreenRectangleOptions>();
	}

	private void SelectPatternCommandExecute()
	{
		_testPatternService.SelectedPattern = _pattern;
	}

	[MemberNotNull("Properties")]
	[MemberNotNull("_properties")]
	private void CreatePropertyList()
	{
		List<ITestPatternPropertyVM> list = new List<ITestPatternPropertyVM>();
		CreatePropertyList(list, _pattern.Properties);
		Properties = list;
	}

	private void CreatePropertyList(List<ITestPatternPropertyVM> propertyVms, IEnumerable<ITestPatternProperty> properties)
	{
		foreach (ITestPatternProperty property in properties)
		{
			ITestPatternPropertyVM testPatternPropertyVM = _factory.Create(property);
			if (testPatternPropertyVM != null)
			{
				propertyVms.Add(testPatternPropertyVM);
				if (testPatternPropertyVM is IBoolPropertyVM boolPropertyVM)
				{
					propertyVms.AddRange(boolPropertyVM.DependentProperties);
				}
			}
		}
	}
}
