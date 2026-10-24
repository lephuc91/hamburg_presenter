using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.HTTP;
using Pro.Common.Time;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.Themes;
using ProPresenter.Controller.NetworkAPI;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public class InputsSettingsVM : LinkedNotifyPropertyChangedBase, IInputsSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly IOutputConfiguration _outputConfiguration;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	private readonly IAirCastPluginDownload _airCastPluginDownload;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IAirCastPrompt _prompt;

	private readonly IAirCastConfiguration _airCastConfiguration;

	private int _selectedIndex;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; }

	public string Name { get; }

	public bool IsActive
	{
		get
		{
			if (AudioInputsSettingsVM.IsActive)
			{
				return VideoInputsSettingsVM.IsActive;
			}
			return false;
		}
		set
		{
			bool isActive = IsActive;
			AudioInputsSettingsVM.IsActive = value;
			VideoInputsSettingsVM.IsActive = value;
			if (isActive != IsActive)
			{
				OnPropertyChanged("IsActive");
				OnIsActiveChanged();
			}
		}
	}

	public int SelectedIndex
	{
		get
		{
			return _selectedIndex;
		}
		set
		{
			_selectedIndex = value;
			OnPropertyChanged("SelectedIndex");
		}
	}

	public IVideoInputsSettingsVM VideoInputsSettingsVM { get; }

	public IAudioInputsSettingsVM AudioInputsSettingsVM { get; }

	public INdiInputsSettingsVM NdiInputsSettingsVM { get; }

	public TimeSlice AudioInputTransitionTime
	{
		get
		{
			return _outputConfiguration.AudioInputTransitionTime;
		}
		set
		{
			_outputConfiguration.AudioInputTransitionTime = value;
		}
	}

	public ISettingsItemVM? Parent => null;

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpSettingUpInputs));
	});

	public ICommand GotFocusCommand => new RelayCommand(GotFocusCommandExecuted);

	public Brush Background => SettingsListItemConstants.Blue;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsInputs);

	public bool IsNavigable => true;

	public bool CanExit => !_airCastConfiguration.GetShouldRequirePassword();

	public event Action<UndoStack>? StackChanged;

	public InputsSettingsVM(IVideoInputsSettingsVM videoInputsSettingsVM, IAudioInputsSettingsVM audioInputsSettingsVM, INdiInputsSettingsVM ndiInputsSettingsVM, IOutputConfiguration outputConfiguration, ILocalization localization, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory, IAirCastPluginDownload airCastPluginDownload, IAsyncExecutor asyncExecutor, IAirCastPrompt prompt, IAirCastConfiguration airCastConfiguration)
	{
		Name = localization.Get("SETTINGS_INPUTS_PAGE_title");
		VideoInputsSettingsVM = videoInputsSettingsVM;
		AudioInputsSettingsVM = audioInputsSettingsVM;
		NdiInputsSettingsVM = ndiInputsSettingsVM;
		_outputConfiguration = outputConfiguration;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		_airCastPluginDownload = airCastPluginDownload;
		_asyncExecutor = asyncExecutor;
		_prompt = prompt;
		_airCastConfiguration = airCastConfiguration;
		LinkProperties("AudioInputTransitionTime", "AudioInputTransitionTime");
		_outputConfiguration.PropertyChanged += base.RaiseLinkedValues;
		NdiInputsSettingsVM.SetParent(this);
		videoInputsSettingsVM.StackChanged += OnStackChanged;
		audioInputsSettingsVM.StackChanged += OnStackChanged;
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		SubPages = NdiInputsSettingsVM.ToEnumerable();
		Fields = settingsSearchFactory.GetFields("SETTINGS_INPUTS_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_VIDEO_INPUT_NAME_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_VIDEO_INPUT_DEVICE_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("VIDEO_INPUT_ALPHA_TYPE_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("VIDEO_INPUT_ALPHA_TYPE_STRAIGHT_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("VIDEO_INPUT_ALPHA_TYPE_PREMULTIPLIED_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_VIDEO_INPUT_AUDIO_SOURCE_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_VIDEO_INPUT_AUDIO_DELAY_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_VIDEO_INPUT_AUDIO_LEVEL_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_VIDEO_INPUT_AUDIO_CHANNELS_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_VIDEO_INPUT_AUDIO_ROUTING_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_AUDIO_INPUT_NAME_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_AUDIO_INPUT_MODE_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_AUDIO_INPUT_SOURCE_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_AUDIO_INPUT_DELAY_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_AUDIO_INPUT_MASTER_LEVEL_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_AUDIO_INPUT_CHANNELS_SECTION_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_AUDIO_INPUT_ROUTING_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_AUDIO_TRANSITION_DURATION_title", this, isComponent: true));
	}

	private void OnStackChanged(UndoStack u)
	{
		this.StackChanged?.Invoke(u);
	}

	private void GotFocusCommandExecuted()
	{
		if (SelectedIndex == (int)VideoInputsSettingsVM.Index)
		{
			VideoInputsSettingsVM.GotFocusCommand.Execute(null);
		}
		else if (SelectedIndex == (int)AudioInputsSettingsVM.Index)
		{
			AudioInputsSettingsVM.GotFocusCommand.Execute(null);
		}
	}

	public void PromptUnableToExit()
	{
		_prompt.ShowPasswordRequired();
	}

	private void OnIsActiveChanged()
	{
		if (IsActive && _airCastConfiguration.Enabled)
		{
			_asyncExecutor.ExecuteAsync(_airCastPluginDownload.CheckAvailabilityAsync);
		}
	}
}
