using Pro.Common.Components;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.ssAPI.Devices;

public class ClockSource : NotifyPropertyChangedBase
{
	public static readonly ClockSource Automatic = new ClockSource
	{
		UUID = string.Empty,
		Name = LocalizedStrings.Get("SETTINGS_SCREENS_TIMING_SOURCE_AUTOMATIC_title"),
		Connected = true,
		Active = true,
		Type = ClockSourceType.Output
	};

	private string _uuid = string.Empty;

	private string _name = string.Empty;

	private bool _connected;

	private bool _active;

	private ClockSourceType _type;

	public string UUID
	{
		get
		{
			return _uuid;
		}
		private set
		{
			SetValue("UUID", ref _uuid, value);
		}
	}

	public string Name
	{
		get
		{
			return _name;
		}
		private set
		{
			SetValue("Name", ref _name, value, null, false, "DisplayName");
		}
	}

	public bool Connected
	{
		get
		{
			return _connected;
		}
		private set
		{
			SetValue("Connected", ref _connected, value);
		}
	}

	public bool Active
	{
		get
		{
			return _active;
		}
		private set
		{
			SetValue("Active", ref _active, value, null, false, "DisplayName");
		}
	}

	public string DisplayName => GetDisplayName();

	public ClockSourceType Type
	{
		get
		{
			return _type;
		}
		private set
		{
			SetValue("Type", ref _type, value);
		}
	}

	public ProClockSource Serialize()
	{
		ProClockSource proClockSource = new ProClockSource();
		proClockSource.Uuid = UUID;
		proClockSource.Name = Name;
		proClockSource.Connected = Connected;
		proClockSource.Active = Active;
		ProClockSource proClockSource2 = proClockSource;
		proClockSource2.Type = Type switch
		{
			ClockSourceType.Unknown => ProClockSource.Types.Type.Unkown, 
			ClockSourceType.Input => ProClockSource.Types.Type.Input, 
			ClockSourceType.Output => ProClockSource.Types.Type.Output, 
			_ => ProClockSource.Types.Type.Unkown, 
		};
		return proClockSource;
	}

	public void Deserialize(ProClockSource? protoClockSource)
	{
		if (protoClockSource != null)
		{
			UUID = protoClockSource.Uuid;
			Name = protoClockSource.Name;
			Connected = protoClockSource.Connected;
			Active = protoClockSource.Active;
			Type = protoClockSource.Type switch
			{
				ProClockSource.Types.Type.Input => ClockSourceType.Input, 
				ProClockSource.Types.Type.Output => ClockSourceType.Output, 
				_ => ClockSourceType.Unknown, 
			};
		}
	}

	private string GetDisplayName()
	{
		string text = (Active ? string.Empty : LocalizedStrings.Get("SETTINGS_SCREENS_TIMING_SOURCE_INACTIVE_label"));
		return Name + " " + text;
	}
}
