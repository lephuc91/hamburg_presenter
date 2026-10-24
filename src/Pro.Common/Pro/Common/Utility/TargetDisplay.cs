using System;
using System.Linq;
using System.Windows;
using WpfScreenHelper;

namespace Pro.Common.Utility;

public class TargetDisplay
{
	private static bool _screensLoaded;

	private static TargetDisplay[]? _allDisplays;

	private static TargetDisplay? _primaryDisplay;

	private readonly int _index;

	private readonly Screen? _screen;

	public static TargetDisplay[] AllDisplays
	{
		get
		{
			if (!_screensLoaded)
			{
				LoadScreens();
			}
			return _allDisplays ?? Array.Empty<TargetDisplay>();
		}
	}

	public static TargetDisplay PrimaryDisplay
	{
		get
		{
			if (!_screensLoaded)
			{
				LoadScreens();
			}
			return _primaryDisplay ?? new TargetDisplay(0, null);
		}
	}

	public int Index => _index;

	public string DeviceName => _screen?.DeviceName ?? string.Empty;

	public bool IsPrimary => _screen?.Primary ?? false;

	public int Left
	{
		get
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			Screen? screen = _screen;
			double num;
			if (screen == null)
			{
				num = 0.0;
			}
			else
			{
				Rect bounds = screen.Bounds;
				num = ((Rect)(ref bounds)).Left;
			}
			return (int)num;
		}
	}

	public int Top
	{
		get
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			Screen? screen = _screen;
			double num;
			if (screen == null)
			{
				num = 0.0;
			}
			else
			{
				Rect bounds = screen.Bounds;
				num = ((Rect)(ref bounds)).Top;
			}
			return (int)num;
		}
	}

	public int Width
	{
		get
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			Screen? screen = _screen;
			double num;
			if (screen == null)
			{
				num = 0.0;
			}
			else
			{
				Rect bounds = screen.Bounds;
				num = ((Rect)(ref bounds)).Width;
			}
			return (int)num;
		}
	}

	public int Height
	{
		get
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			Screen? screen = _screen;
			double num;
			if (screen == null)
			{
				num = 0.0;
			}
			else
			{
				Rect bounds = screen.Bounds;
				num = ((Rect)(ref bounds)).Height;
			}
			return (int)num;
		}
	}

	private TargetDisplay(int index, Screen? screen)
	{
		_index = index;
		_screen = screen;
	}

	private static void LoadScreens()
	{
		Screen[] array = Screen.AllScreens.ToArray();
		_allDisplays = new TargetDisplay[array.Length];
		_primaryDisplay = null;
		for (int i = 0; i < array.Length; i++)
		{
			Screen screen = array[i];
			_allDisplays[i] = new TargetDisplay(i, screen);
			if (screen.Primary)
			{
				_primaryDisplay = _allDisplays[i];
			}
		}
		_screensLoaded = true;
	}
}
