using System;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVPreferencesDisplay
{
	private string _screenPositionStr = string.Empty;

	private ScreenColor? _screenColor;

	[Child]
	[Alias("EnableStageDisplay", typeof(bool), false)]
	public bool EnableStageDisplay { get; internal set; }

	[Child]
	[Alias("IsCornerPinningEnabled", typeof(bool), false)]
	public bool IsCornerPinningEnabled { get; internal set; }

	[Child]
	[Alias("IsExitScreenPrimary", typeof(bool), false)]
	public bool IsExitScreenPrimary { get; internal set; }

	[Child]
	[Alias("IsOnlySingleScreenAvailable", typeof(bool), false)]
	public bool IsOnlySingleScreenAvailable { get; internal set; }

	[Child]
	[Alias("OutputAtTopMostWindowLayer", typeof(bool), false)]
	public bool OutputAtTopMostWindowLayer { get; internal set; }

	[Child]
	[Alias("ScalePresentationToOutput", typeof(bool), false)]
	public bool ScalePresentationToOutput { get; internal set; }

	[Child]
	[Alias("ScreenHeight", typeof(int), false)]
	public int ScreenHeight { get; internal set; }

	[Child]
	[Alias("ScreenWidth", typeof(int), false)]
	public int ScreenWidth { get; internal set; }

	public Vector2<int> ScreenSize => new Vector2<int>(ScreenWidth, ScreenHeight);

	[Child]
	[Alias("ScreenPosition", typeof(string), false)]
	public string ScreenPositionStr
	{
		get
		{
			return _screenPositionStr;
		}
		internal set
		{
			_screenPositionStr = value;
			if (Enum.TryParse<ScreenPosition>(_screenPositionStr, out var result))
			{
				ScreenPosition = result;
			}
		}
	}

	public ScreenPosition ScreenPosition { get; private set; }

	[Child]
	[Alias("ShowOutputAtLaunch", typeof(bool), false)]
	public bool ShowOutputAtLaunch { get; set; }

	[Child]
	[Alias("SelectedScreen", typeof(int), false)]
	public int SelectedScreen { get; set; }

	[Child]
	[Alias("StageDisplayScreen", typeof(int), false)]
	public int StageDisplayScreen { get; set; }

	[Child]
	[Alias("ScreenColor", typeof(ScreenColor), false)]
	public ScreenColor? ScreenBg
	{
		get
		{
			return _screenColor;
		}
		internal set
		{
			_screenColor = value;
			if (_screenColor != null)
			{
				ScreenColor = Color.FromArgb(_screenColor.A, _screenColor.R, _screenColor.G, _screenColor.B);
			}
		}
	}

	public Color ScreenColor { get; private set; }

	[Child]
	[Alias("SingleScreenCornerPins", typeof(SingleScreenCornerPins), false)]
	public SingleScreenCornerPins? SingleScreenCornerPins { get; internal set; }

	[Child]
	[Alias("DualScreenCornerPins", typeof(DualScreenCornerPins), false)]
	public DualScreenCornerPins? DualScreenCornerPins { get; internal set; }

	[Child]
	[Alias("TripleScreenCornerPins", typeof(TripleScreenCornerPins), false)]
	public TripleScreenCornerPins? TripleScreenCornerPins { get; internal set; }
}
