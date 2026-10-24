using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Localization.Services;
using Pro.UI.Themes;
using ProPresenter.Controller;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Settings.AppSettings;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Screens;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Screens;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class ScreenSettingsVM : ObservableObject, IScreenSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem, IDisposable
{
	private readonly ICoreManager _manager;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("RenderBitDepth", "SelectedBitDepth")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("RenderBitDepth", "OnSelectedBitDepthChanged")]
	private readonly IApp _app;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ShowScreenStats", "ShowScreenStats")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("IgnoreBackgroundColors", "IgnoreBackgroundColors")]
	private readonly IAdvanced _advanced;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ShowOutputAtLaunch", "ShowOutputAtLaunch")]
	private readonly IGeneral _general;

	private readonly IOutputRepository _outputRepository;

	private readonly BitDepth _startupBitDepth;

	[ObservableProperty]
	private bool _bitDepthChanged;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; } = Enumerable.Empty<ISettingsSearchPage>();

	public string Name { get; }

	public bool ShowOutputAtLaunch
	{
		get
		{
			return _general.ShowOutputAtLaunch;
		}
		set
		{
			_general.ShowOutputAtLaunch = value;
		}
	}

	public bool ShowScreenStats
	{
		get
		{
			return _advanced.ShowScreenStats;
		}
		set
		{
			_advanced.ShowScreenStats = value;
			_manager.ShowOnScreenStats(value);
		}
	}

	public bool IgnoreBackgroundColors
	{
		get
		{
			return _advanced.IgnoreBackgroundColors;
		}
		set
		{
			_advanced.IgnoreBackgroundColors = value;
		}
	}

	public IClockSourceVM ClockSourceVM { get; }

	public ISettingsItemVM? Parent => null;

	public Brush Background => SettingsListItemConstants.Orange;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsScreen);

	public bool IsNavigable => true;

	public bool CanExit => true;

	public IReadOnlyCollection<BitDepths> BitDepths => (IReadOnlyCollection<BitDepths>)(object)Enum.GetValues<BitDepths>();

	public BitDepths SelectedBitDepth
	{
		get
		{
			return _app.RenderBitDepth.ToUi();
		}
		set
		{
			_app.RenderBitDepth = value.ToDo();
		}
	}

	public bool CanSelectBitDepth { get; private set; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool BitDepthChanged
	{
		get
		{
			return _bitDepthChanged;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_bitDepthChanged, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.BitDepthChanged);
				_bitDepthChanged = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.BitDepthChanged);
			}
		}
	}

	public ScreenSettingsVM(ICoreManager manager, IApp app, IAdvanced advanced, IGeneral general, ILocalization localization, IClockSourceVM clockSourceVM, ISettingsSearchFactory settingsSearchFactory, IOutputRepository outputRepository)
	{
		_manager = manager;
		_app = app;
		_advanced = advanced;
		_general = general;
		ClockSourceVM = clockSourceVM;
		_outputRepository = outputRepository;
		_startupBitDepth = _app.RenderBitDepth;
		CanSelectBitDepth = GetCanSelectBitDepth();
		AddPropertyLinks();
		Name = localization.Get("SETTINGS_SCREENS_PAGE_title");
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_SCREENS_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_SCREENS_RENDERING_HEADER_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_SCREENS_SHOW_OUTPUT_AT_LAUNCH_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SCREENS_SHOW_SCREEN_STATS_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SCREENS_IGNORE_BACKGROUND_COLORS_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SCREENS_TIMING_SOURCE_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SCREENS_CONFIGURE_SCREENS_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SCREENS_RENDER_MODE_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_SCREENS_BIT_DEPTH_title", this, isComponent: true));
		_outputRepository.AudienceScreenArrangementCollection.CollectionModified += OnOutputArrangementsChanged;
		_outputRepository.StageScreenArrangementCollection.CollectionModified += OnOutputArrangementsChanged;
	}

	public void RefreshClockSource()
	{
		ClockSourceVM.RefreshClockSources();
	}

	public void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}

	private void OnSelectedBitDepthChanged()
	{
		BitDepthChanged = _startupBitDepth != _app.RenderBitDepth;
	}

	private void OnOutputArrangementsChanged(ScreenArrangementCollectionBase @base)
	{
		CanSelectBitDepth = GetCanSelectBitDepth();
		OnPropertyChanged("CanSelectBitDepth");
	}

	private bool GetCanSelectBitDepth()
	{
		return _outputRepository.AudienceScreenArrangementCollection.SelectMany((ScreenArrangementBase c) => c.Screens.SelectMany((Screen s) => s.HardwareRectangles.Select((HardwareScreenRectangleOptions r) => r.OutputDevice))).Concat(_outputRepository.StageScreenArrangementCollection.SelectMany((ScreenArrangementBase c) => c.Screens.SelectMany((Screen s) => s.HardwareRectangles.Select((HardwareScreenRectangleOptions r) => r.OutputDevice)))).All((IDevice o) => o == null || o.SelectedHdrFormat == HdrFormats.Sdr);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_outputRepository.AudienceScreenArrangementCollection.CollectionModified -= OnOutputArrangementsChanged;
		_outputRepository.StageScreenArrangementCollection.CollectionModified -= OnOutputArrangementsChanged;
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _app_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "RenderBitDepth")
		{
			OnPropertyChanged("SelectedBitDepth");
			OnSelectedBitDepthChanged();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _advanced_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "ShowScreenStats"))
		{
			if (propertyName == "IgnoreBackgroundColors")
			{
				OnPropertyChanged("IgnoreBackgroundColors");
			}
		}
		else
		{
			OnPropertyChanged("ShowScreenStats");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _general_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ShowOutputAtLaunch")
		{
			OnPropertyChanged("ShowOutputAtLaunch");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_app.PropertyChanged += _app_PropertyChanged;
		_advanced.PropertyChanged += _advanced_PropertyChanged;
		_general.PropertyChanged += _general_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_app.PropertyChanged -= _app_PropertyChanged;
		_advanced.PropertyChanged -= _advanced_PropertyChanged;
		_general.PropertyChanged -= _general_PropertyChanged;
	}
}
