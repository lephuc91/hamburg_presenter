using System;
using Pro.Serialization.Control;
using Pro.ssAPI;

namespace ProPresenter.DO.Migration.RVData;

public class RVPreferencesAdvanced
{
	private string? _backgroundScaleBehaviorStr;

	private string? _foregroundScaleBehaviorStr;

	[Child]
	[Alias("AudioChannels", typeof(int), false)]
	public int AudioChannels { get; internal set; }

	[Child]
	[Alias("AudioDelay", typeof(int), false)]
	public int AudioDelay { get; internal set; }

	[Child]
	[Alias("BackgroundScaleBehavior", typeof(string), false)]
	public string BackgroundScaleBehaviorStr
	{
		get
		{
			return _backgroundScaleBehaviorStr ?? string.Empty;
		}
		internal set
		{
			_backgroundScaleBehaviorStr = value;
			if (Enum.TryParse<ScaleBehavior>(value, out var result))
			{
				BackgroundScaleBehavior = result;
			}
		}
	}

	public ScaleBehavior BackgroundScaleBehavior { get; private set; }

	[Child]
	[Alias("ForegroundScaleBehavior", typeof(string), false)]
	public string ForegroundScaleBehaviorStr
	{
		get
		{
			return _foregroundScaleBehaviorStr ?? string.Empty;
		}
		internal set
		{
			_foregroundScaleBehaviorStr = value;
			if (Enum.TryParse<ScaleBehavior>(value, out var result))
			{
				ForegroundScaleBehavior = result;
			}
		}
	}

	public ScaleBehavior ForegroundScaleBehavior { get; private set; }

	[Child]
	[Alias("IsAnamorphicOutputEnabled", typeof(bool), false)]
	public bool IsAnamorphicOutputEnabled { get; internal set; }

	[Child]
	[Alias("KeyClickSuppressVideo", typeof(bool), false)]
	public bool KeyClickSuppressVideo { get; internal set; }
}
