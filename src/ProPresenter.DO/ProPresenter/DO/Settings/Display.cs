using System.ComponentModel;
using System.IO;
using System.Windows.Media;
using Pro.Common.DataStore;
using Pro.DO.Effects;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace ProPresenter.DO.Settings;

public class Display : StoreBase, IDisplay, INotifyPropertyChanged
{
	private const string SettingsFile = "DisplayPreferences.proPref";

	public static Display Settings { get; } = new Display();

	public bool DisplayTopMost
	{
		get
		{
			return GetValue("DisplayTopMost", defaultValue: true);
		}
		set
		{
			SetValue("DisplayTopMost", value);
			OnPropertyChanged("DisplayTopMost");
		}
	}

	public bool ScaleToFit
	{
		get
		{
			return GetValue("ScaleToFit", defaultValue: false);
		}
		set
		{
			SetValue("ScaleToFit", value);
			OnPropertyChanged("ScaleToFit");
		}
	}

	public bool StageDisplayVisible
	{
		get
		{
			return GetValue("StageDisplayVisible", defaultValue: false);
		}
		set
		{
			SetValue("StageDisplayVisible", value);
			OnPropertyChanged("StageDisplayVisible");
		}
	}

	public string OutputDeviceID
	{
		get
		{
			return GetValue("OutputDeviceID", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("OutputDeviceID", value);
			OnPropertyChanged("OutputDeviceID");
		}
	}

	public string StageDisplayDeviceID
	{
		get
		{
			return GetValue("StageDisplayDeviceID", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("StageDisplayDeviceID", value);
			OnPropertyChanged("StageDisplayDeviceID");
		}
	}

	public System.Windows.Media.Color ScreenColor
	{
		get
		{
			return GetValue("ScreenColor", Colors.Black);
		}
		set
		{
			SetValue("ScreenColor", value);
			OnPropertyChanged("ScreenColor");
		}
	}

	public Direction ScreenPosition
	{
		get
		{
			return GetValue("ScreenPosition", Direction.Center);
		}
		set
		{
			SetValue("ScreenPosition", value);
			OnPropertyChanged("ScreenPosition");
		}
	}

	public bool EnableCornerPinning
	{
		get
		{
			return GetValue("EnableCornerPinning", defaultValue: false);
		}
		set
		{
			SetValue("EnableCornerPinning", value);
			OnPropertyChanged("EnableCornerPinning");
		}
	}

	public double BlackLevel
	{
		get
		{
			return GetValue("BlackLevel", 0.0);
		}
		set
		{
			SetValue("BlackLevel", value);
			OnPropertyChanged("BlackLevel");
		}
	}

	public double WhiteLevel
	{
		get
		{
			return GetValue("WhiteLevel", 1.0);
		}
		set
		{
			SetValue("WhiteLevel", value);
			OnPropertyChanged("WhiteLevel");
		}
	}

	public System.Windows.Media.Color CustomPatternColor
	{
		get
		{
			return GetValue("CustomPatternColor", Colors.Black);
		}
		set
		{
			SetValue("CustomPatternColor", value);
			OnPropertyChanged("CustomPatternColor");
		}
	}

	public bool CenterCircleOn
	{
		get
		{
			return GetValue("CenterCircleOn", defaultValue: true);
		}
		set
		{
			SetValue("CenterCircleOn", value);
			OnPropertyChanged("CenterCircleOn");
		}
	}

	public bool CenterLinesOn
	{
		get
		{
			return GetValue("CenterLinesOn", defaultValue: true);
		}
		set
		{
			SetValue("CenterLinesOn", value);
			OnPropertyChanged("CenterLinesOn");
		}
	}

	public bool GridOn
	{
		get
		{
			return GetValue("GridOn", defaultValue: true);
		}
		set
		{
			SetValue("GridOn", value);
			OnPropertyChanged("GridOn");
		}
	}

	public double GridSize
	{
		get
		{
			return GetValue("GridSize", 0.4);
		}
		set
		{
			SetValue("GridSize", value);
			OnPropertyChanged("GridSize");
		}
	}

	public bool InvertColors
	{
		get
		{
			return GetValue("InvertColors", defaultValue: false);
		}
		set
		{
			SetValue("InvertColors", value);
			OnPropertyChanged("InvertColors");
		}
	}

	public ProClockSource? SelectedClockSource
	{
		get
		{
			return GetValue("SelectedClockSource", ClockSource.Automatic.Serialize());
		}
		set
		{
			SetValue("SelectedClockSource", value);
			OnPropertyChanged("SelectedClockSource");
		}
	}

	private Display()
		: base(Path.Combine(CommonPaths.Preferences, "DisplayPreferences.proPref"))
	{
		RegisterEnumType<Direction>();
		RegisterCustomType(ProtoHelper.EncodeBase64, ProtoHelper.DecodeBase64<ProClockSource>);
	}
}
