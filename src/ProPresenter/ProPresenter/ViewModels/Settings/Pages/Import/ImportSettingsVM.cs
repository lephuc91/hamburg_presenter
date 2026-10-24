using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.DO.Triggering;
using Pro.Localization.Services;
using Pro.UI.Themes;
using Pro.ssAPI;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Import;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Import;

public class ImportSettingsVM : LinkedNotifyPropertyChangedBase, IImportSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly IImport _import;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; } = Enumerable.Empty<ISettingsSearchPage>();

	public ScaleBehavior ForegroundScaleBehavior
	{
		get
		{
			return _import.ForegroundScaleBehavior;
		}
		set
		{
			_import.ForegroundScaleBehavior = value;
		}
	}

	public ScaleBehavior BackgroundScaleBehavior
	{
		get
		{
			return _import.BackgroundScaleBehavior;
		}
		set
		{
			_import.BackgroundScaleBehavior = value;
		}
	}

	public ImportLayerInternal ImageLayer
	{
		get
		{
			return _import.ImageLayer.ToImportLayerInternal();
		}
		set
		{
			_import.ImageLayer = value.ToImportLayer();
		}
	}

	public ImportDurationTypeInternal ImportDurationType
	{
		get
		{
			return _import.ImportDurationType.ToImportDurationTypeInternal();
		}
		set
		{
			_import.ImportDurationType = value.ToImportDurationType();
			if (value == ImportDurationTypeInternal.None)
			{
				ImageNextBehavior = CompletionTargetType.None;
			}
		}
	}

	public bool IsImageNextBehaviorEnabled => ImportDurationType != ImportDurationTypeInternal.None;

	public TimeSlice ImageDurationTime
	{
		get
		{
			return _import.ImageDurationTime;
		}
		set
		{
			_import.ImageDurationTime = value;
		}
	}

	public int RandomMinTime
	{
		get
		{
			return _import.RandomMinTime;
		}
		set
		{
			_import.RandomMinTime = value;
		}
	}

	public int RandomMaxTime
	{
		get
		{
			return _import.RandomMaxTime;
		}
		set
		{
			_import.RandomMaxTime = value;
		}
	}

	public CompletionTargetType ImageNextBehavior
	{
		get
		{
			return _import.ImageNextBehavior;
		}
		set
		{
			_import.ImageNextBehavior = value;
		}
	}

	public ImportLayerInternal VideoLayer
	{
		get
		{
			return _import.VideoLayer.ToImportLayerInternal();
		}
		set
		{
			_import.VideoLayer = value.ToImportLayer();
		}
	}

	public PlaybackBehaviorType VideoPlaybackBehavior
	{
		get
		{
			return _import.VideoPlaybackBehavior;
		}
		set
		{
			_import.VideoPlaybackBehavior = value;
		}
	}

	public bool IsVideoEndAndNextBehaviorEnabled => VideoPlaybackBehavior == PlaybackBehaviorType.Stop;

	public EndBehaviorType VideoEndBehavior
	{
		get
		{
			return _import.VideoEndBehavior;
		}
		set
		{
			_import.VideoEndBehavior = value;
		}
	}

	public CompletionTargetType VideoNextBehavior
	{
		get
		{
			return _import.VideoNextBehavior;
		}
		set
		{
			_import.VideoNextBehavior = value;
		}
	}

	public AudioBehaviorType AudioPlaybackBehavior
	{
		get
		{
			return _import.AudioPlaybackBehavior;
		}
		set
		{
			_import.AudioPlaybackBehavior = value;
		}
	}

	public ISettingsItemVM? Parent => null;

	public string Name { get; }

	public Brush? Background => SettingsListItemConstants.Green;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsImport);

	public bool IsNavigable => true;

	public bool CanExit => true;

	public ImportSettingsVM(IImport import, ILocalization localization, ISettingsSearchFactory settingsSearchFactory)
	{
		_import = import;
		Name = localization.Get("SETTINGS_IMPORT_PAGE_title");
		LinkProperties("ForegroundScaleBehavior", "ForegroundScaleBehavior");
		LinkProperties("BackgroundScaleBehavior", "BackgroundScaleBehavior");
		LinkProperties("ImageLayer", "ImageLayer");
		LinkProperties("ImportDurationType", new string[2] { "ImportDurationType", "IsImageNextBehaviorEnabled" });
		LinkProperties("ImageDurationTime", "ImageDurationTime");
		LinkProperties("RandomMinTime", "RandomMinTime");
		LinkProperties("RandomMaxTime", "RandomMaxTime");
		LinkProperties("ImageNextBehavior", "ImageNextBehavior");
		LinkProperties("VideoLayer", "VideoLayer");
		LinkProperties("VideoPlaybackBehavior", new string[2] { "VideoPlaybackBehavior", "IsVideoEndAndNextBehaviorEnabled" });
		LinkProperties("VideoEndBehavior", "VideoEndBehavior");
		LinkProperties("VideoNextBehavior", "VideoNextBehavior");
		LinkProperties("AudioPlaybackBehavior", "AudioPlaybackBehavior");
		_import.PropertyChanged += base.RaiseLinkedValues;
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_IMPORT_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_SCALING_SECTION_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_SCALING_FOREGROUND_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_SCALING_BACKGROUND_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_IMAGE_SECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_IMAGE_BEHAVIOR_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_IMAGE_DURATION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_IMAGE_NEXT_BEHAVIOR_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_VIDEO_SECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_VIDEO_PLAYBACK_BEHAVIOR_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_VIDEO_END_BEHAVIOR_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_VIDEO_NEXT_BEHAVIOR_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_AUDIO_SECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_IMPORT_AUDIO_PLAYBACK_BEHAVIOR_title", this, isComponent: true));
	}

	public void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}
}
