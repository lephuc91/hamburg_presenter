using System;
using System.ComponentModel;
using System.IO;
using Pro.Common.DataStore;
using Pro.Common.Time;
using Pro.DO.Triggering;
using Pro.ssAPI;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Settings;

public class Import : StoreBase, IImport, INotifyPropertyChanged
{
	private const string SettingsFile = "ImportPreferences.proPref";

	private static Import _settings = new Import();

	public static Import Settings => _settings;

	public ScaleBehavior BackgroundScaleBehavior
	{
		get
		{
			return ReadScaleBehavior("BackgroundScaleBehavior");
		}
		set
		{
			SetScaleBehavior("BackgroundScaleBehavior", value);
		}
	}

	public ScaleBehavior ForegroundScaleBehavior
	{
		get
		{
			return ReadScaleBehavior("ForegroundScaleBehavior");
		}
		set
		{
			SetScaleBehavior("ForegroundScaleBehavior", value);
		}
	}

	public ImportLayer ImageLayer
	{
		get
		{
			return GetValue("ImageLayer", ImportLayer.Background);
		}
		set
		{
			SetValue("ImageLayer", value);
			OnPropertyChanged("ImageLayer");
		}
	}

	public ImportDurationType ImportDurationType
	{
		get
		{
			return GetValue("ImportDurationType", ImportDurationType.None);
		}
		set
		{
			SetValue("ImportDurationType", value);
			OnPropertyChanged("ImportDurationType");
		}
	}

	public TimeSlice ImageDurationTime
	{
		get
		{
			return GetValue("ImageDurationTime", TimeSlice.FromSeconds(1.0));
		}
		set
		{
			SetValue("ImageDurationTime", value);
			OnPropertyChanged("ImageDurationTime");
		}
	}

	public int RandomMinTime
	{
		get
		{
			return GetValue("RandomMinTime", 1);
		}
		set
		{
			SetValue("RandomMinTime", value);
			OnPropertyChanged("RandomMinTime");
		}
	}

	public int RandomMaxTime
	{
		get
		{
			return GetValue("RandomMaxTime", 1);
		}
		set
		{
			SetValue("RandomMaxTime", value);
			OnPropertyChanged("RandomMaxTime");
		}
	}

	public CompletionTargetType ImageNextBehavior
	{
		get
		{
			return GetValue("ImageNextBehavior", CompletionTargetType.None);
		}
		set
		{
			SetValue("ImageNextBehavior", value);
			OnPropertyChanged("ImageNextBehavior");
		}
	}

	public ImportLayer VideoLayer
	{
		get
		{
			return GetValue("VideoLayer", ImportLayer.Background);
		}
		set
		{
			SetValue("VideoLayer", value);
			OnPropertyChanged("VideoLayer");
		}
	}

	public PlaybackBehaviorType VideoPlaybackBehavior
	{
		get
		{
			return GetValue("VideoPlaybackBehavior", PlaybackBehaviorType.Loop);
		}
		set
		{
			SetValue("VideoPlaybackBehavior", value);
			OnPropertyChanged("VideoPlaybackBehavior");
		}
	}

	public EndBehaviorType VideoEndBehavior
	{
		get
		{
			return GetValue("VideoEndBehavior", EndBehaviorType.HoldLastFrame);
		}
		set
		{
			SetValue("VideoEndBehavior", value);
			OnPropertyChanged("VideoEndBehavior");
		}
	}

	public CompletionTargetType VideoNextBehavior
	{
		get
		{
			return GetValue("VideoNextBehavior", CompletionTargetType.None);
		}
		set
		{
			SetValue("VideoNextBehavior", value);
			OnPropertyChanged("VideoNextBehavior");
		}
	}

	public AudioBehaviorType AudioPlaybackBehavior
	{
		get
		{
			return GetValue("AudioPlaybackBehavior", AudioBehaviorType.Next);
		}
		set
		{
			SetValue("AudioPlaybackBehavior", value);
			OnPropertyChanged("AudioPlaybackBehavior");
		}
	}

	private ScaleBehavior ReadScaleBehavior(string name)
	{
		int value = GetValue(name, 0);
		int value2 = GetValue(name + "_new", value);
		if (!Enum.IsDefined(typeof(ScaleBehavior), value2) || value2 == 3)
		{
			return ScaleBehavior.ScaleToFit;
		}
		return (ScaleBehavior)value2;
	}

	private void SetScaleBehavior(string name, ScaleBehavior value)
	{
		if (value != ScaleBehavior.CustomFit)
		{
			SetValue(name + "_new", (int)value);
			OnPropertyChanged(name);
		}
	}

	public Import()
		: base(Path.Combine(CommonPaths.Preferences, "ImportPreferences.proPref"))
	{
		RegisterEnumType<ScaleBehavior>();
		RegisterEnumType<ImportLayer>();
		RegisterEnumType<CompletionTargetType>();
		RegisterEnumType<EndBehaviorType>();
		RegisterEnumType<PlaybackBehaviorType>();
		RegisterEnumType<ImportDurationType>();
		RegisterEnumType<AudioBehaviorType>();
	}

	public void ApplyImportSettings(MediaCue mediaCue)
	{
		MediaHelper.ApplyImportSettings(mediaCue, this);
	}
}
