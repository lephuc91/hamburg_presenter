using System.IO;
using System.Windows.Media;
using Pro.Common.DataStore;

namespace ProPresenter.DO.Settings;

public class TelestratorPreferences : StoreBase
{
	private const string SettingsFile = "Telestrator.proPref";

	private static TelestratorPreferences _settings = new TelestratorPreferences();

	public static TelestratorPreferences Settings => _settings;

	public TelestratorDrawType SelectedDrawType
	{
		get
		{
			return GetValue("SelectedDrawType", TelestratorDrawType.Pen);
		}
		set
		{
			SetValue("SelectedDrawType", value);
			OnPropertyChanged("SelectedDrawType");
		}
	}

	public double PenSize
	{
		get
		{
			return GetValue("PenSize", 1.0);
		}
		set
		{
			SetValue("PenSize", value);
			OnPropertyChanged("PenSize");
		}
	}

	public double CircleSize
	{
		get
		{
			return GetValue("CircleSize", 1.0);
		}
		set
		{
			SetValue("CircleSize", value);
			OnPropertyChanged("CircleSize");
		}
	}

	public double SpotlightSize
	{
		get
		{
			return GetValue("SpotlightSize", 1.0);
		}
		set
		{
			SetValue("SpotlightSize", value);
			OnPropertyChanged("SpotlightSize");
		}
	}

	public double LaserSize
	{
		get
		{
			return GetValue("LaserSize", 1.0);
		}
		set
		{
			SetValue("LaserSize", value);
			OnPropertyChanged("LaserSize");
		}
	}

	public Color PenColor
	{
		get
		{
			return GetValue("PenColor", Colors.Black);
		}
		set
		{
			SetValue("PenColor", value);
			OnPropertyChanged("PenColor");
		}
	}

	public Color CircleColor
	{
		get
		{
			return GetValue("CircleColor", Colors.Black);
		}
		set
		{
			SetValue("CircleColor", value);
			OnPropertyChanged("CircleColor");
		}
	}

	public Color SpotlightColor
	{
		get
		{
			return GetValue("SpotlightColor", Colors.Black);
		}
		set
		{
			SetValue("SpotlightColor", value);
			OnPropertyChanged("SpotlightColor");
		}
	}

	public Color LaserColor
	{
		get
		{
			return GetValue("LaserColor", Colors.Black);
		}
		set
		{
			SetValue("LaserColor", value);
			OnPropertyChanged("LaserColor");
		}
	}

	public bool ClearOnSlideChange
	{
		get
		{
			return GetValue("ClearOnSlideChange", defaultValue: false);
		}
		set
		{
			SetValue("ClearOnSlideChange", value);
			OnPropertyChanged("ClearOnSlideChange");
		}
	}

	public bool ShowPanel
	{
		get
		{
			return GetValue("ShowPanel", defaultValue: true);
		}
		set
		{
			SetValue("ShowPanel", value);
			OnPropertyChanged("ShowPanel");
		}
	}

	private TelestratorPreferences()
		: base(Path.Combine(CommonPaths.Preferences, "Telestrator.proPref"))
	{
		RegisterEnumType<TelestratorDrawType>();
	}
}
