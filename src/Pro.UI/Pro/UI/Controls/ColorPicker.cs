using System.Windows;
using System.Windows.Media;
using Pro.Common.Utility;
using Pro.UI.Components;
using Pro.UI.Utility;
using Xceed.Wpf.Toolkit;

namespace Pro.UI.Controls;

public class ColorPicker : Xceed.Wpf.Toolkit.ColorPicker
{
	private bool _sentStartCommand;

	private Color? _originalColor;

	public static readonly DependencyProperty ColorChangeStartedCommandProperty;

	public static readonly DependencyProperty ColorChangeFinishedCommandProperty;

	public ICommand<ColorPair>? ColorChangeStartedCommand
	{
		get
		{
			return (ICommand<ColorPair>)((DependencyObject)this).GetValue(ColorChangeStartedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ColorChangeStartedCommandProperty, (object)value);
		}
	}

	public ICommand<ColorPair>? ColorChangeFinishedCommand
	{
		get
		{
			return (ICommand<ColorPair>)((DependencyObject)this).GetValue(ColorChangeFinishedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ColorChangeFinishedCommandProperty, (object)value);
		}
	}

	private static object SelectedColor_CoerceValueCallback(DependencyObject d, object baseValue)
	{
		if (baseValue == null)
		{
			return Colors.Transparent;
		}
		return baseValue;
	}

	static ColorPicker()
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		ColorChangeStartedCommandProperty = DependencyProperty.Register("ColorChangeStartedCommand", typeof(ICommand<ColorPair>), typeof(ColorPicker));
		ColorChangeFinishedCommandProperty = DependencyProperty.Register("ColorChangeFinishedCommand", typeof(ICommand<ColorPair>), typeof(ColorPicker));
		Xceed.Wpf.Toolkit.ColorPicker.SelectedColorProperty.OverrideMetadata(typeof(ColorPicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new CoerceValueCallback(SelectedColor_CoerceValueCallback)));
	}

	public ColorPicker()
	{
		base.AvailableColorsSortingMode = ColorSortingMode.HueSaturationBrightness;
		base.Opened += OnOpened;
		base.Closed += OnClosed;
		base.SelectedColorChanged += OnSelectedColorChanged;
	}

	private void OnOpened(object? sender, RoutedEventArgs e)
	{
		_sentStartCommand = false;
		_originalColor = base.SelectedColor;
	}

	private void OnClosed(object? sender, RoutedEventArgs e)
	{
		if (_originalColor.HasValue)
		{
			ColorChangeFinishedCommand?.Invoke(new ColorPair(_originalColor, base.SelectedColor));
			_originalColor = null;
		}
	}

	private void OnSelectedColorChanged(object? sender, RoutedPropertyChangedEventArgs<Color?> e)
	{
		if (!_sentStartCommand)
		{
			ColorChangeStartedCommand?.Invoke(new ColorPair(_originalColor, base.SelectedColor));
			_sentStartCommand = true;
		}
	}
}
