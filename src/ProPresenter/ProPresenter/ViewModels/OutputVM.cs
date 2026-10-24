using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class OutputVM : LinkedNotifyPropertyChangedBase, IOutputVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly IApp _app;

	private readonly ITriggering _service;

	public ICommand ToggleAudienceScreensCommand => new RelayCommand(delegate
	{
		if (_manager.AudienceEnable)
		{
			_manager.HideAudienceScreens();
		}
		else
		{
			_manager.ShowAudienceScreens();
		}
	});

	public ICommand ToggleStageScreensCommand => new RelayCommand(delegate
	{
		if (_manager.StageEnable)
		{
			_manager.HideStageScreens();
		}
		else
		{
			_manager.ShowStageScreens();
		}
	});

	public ICommand ToggleSlideOnStageDisplayOnlyCommand => new RelayCommand(delegate
	{
		_manager.TriggerSlideOnStageDisplayOnly(!_manager.SlideOnStageDisplayOnly);
	});

	public ICommand<ClearGroup?> TriggerClearGroupCommand => new RelayCommand<ClearGroup>(OnTriggerClearGroupCommand, (ClearGroup? c) => c != null);

	public ICommand TriggerFirstClearGroupCommand => new RelayCommand(delegate
	{
		_service.TriggerClearGroup(DataVault.ClearGroups.First());
	}, () => DataVault.ClearGroups.Any());

	public ICommand ClearAllCommand => new RelayCommand(_manager.ClearAll);

	public ICommand ClearAudioCommand => new RelayCommand(_service.ClearAudio);

	public ICommand ClearMessagesCommand => new RelayCommand(_service.ClearMessages);

	public ICommand ClearPropsCommand => new RelayCommand(_service.ClearProps);

	public ICommand ClearAnnouncementCommand => new RelayCommand(_service.ClearAnnouncement);

	public ICommand ClearSlideCommand => new RelayCommand(_service.ClearSlide);

	public ICommand ClearBackgroundCommand => new RelayCommand(_service.ClearBackground);

	public ICommand ClearVideoInputCommand => new RelayCommand(_service.ClearVideoInput);

	public ICommand ClearTelestratorCommand => new RelayCommand(_manager.ClearTelestrator);

	public ICommand DisplayLogoCommand => new RelayCommand(_manager.TriggerLogo, () => _manager.Logo != null);

	public OutputVM(ICoreManager manager, IApp app, ITriggeringFactory triggeringFactory)
	{
		_manager = manager;
		_app = app;
		_service = triggeringFactory.Create();
	}

	private void OnTriggerClearGroupCommand(ClearGroup? clearGroup)
	{
		clearGroup.ThrowWhenNull("clearGroup");
		_service.TriggerClearGroup(clearGroup);
		PreviewAreaClearGroupTriggerEvent.Publish();
	}

	public void ShowScreensOnStartup()
	{
		if ((General.Settings.ShowOutputAtLaunch || General.Settings.AudienceScreensEnabled) && !_app.IsFirstLaunch)
		{
			if (canShowScreen(_manager.OutputConfiguration.AudienceArrangementScreens))
			{
				_manager.ShowAudienceScreens(persistState: false);
			}
			else
			{
				Log.Warning("Skipping enabling audience outputs at launch because one of the attached screens is the primary desktop screen.");
			}
		}
		if ((General.Settings.ShowOutputAtLaunch || General.Settings.StageScreensEnabled) && !_app.IsFirstLaunch)
		{
			if (canShowScreen(_manager.OutputConfiguration.StageArrangementScreens))
			{
				_manager.ShowStageScreens(persistState: false);
			}
			else
			{
				Log.Warning("Skipping enabling stage outputs at launch because one of the attached screens is the primary desktop screen.");
			}
		}
		static bool canShowScreen(IEnumerable<ScreenArrangementBase> arrangements)
		{
			return !arrangements.SelectMany((ScreenArrangementBase a) => a.Screens).SelectMany((Screen s) => s.HardwareRectangles).Any((HardwareScreenRectangleOptions r) => r?.OutputDevice?.IsPrimaryMonitor == true);
		}
	}
}
