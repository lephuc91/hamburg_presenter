using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.SlideEditor.Inspectors.Links;

public partial class TimerFormatSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectedHourFormatProperty = DependencyProperty.Register("SelectedHourFormat", typeof(TimerFormatStyle), typeof(TimerFormatSelector));

	public static readonly DependencyProperty SelectedMinuteFormatProperty = DependencyProperty.Register("SelectedMinuteFormat", typeof(TimerFormatStyle), typeof(TimerFormatSelector));

	public static readonly DependencyProperty SelectedSecondFormatProperty = DependencyProperty.Register("SelectedSecondFormat", typeof(TimerFormatStyle), typeof(TimerFormatSelector));

	public static readonly DependencyProperty SelectedMillisecondFormatProperty = DependencyProperty.Register("SelectedMillisecondFormat", typeof(TimerFormatStyle), typeof(TimerFormatSelector));

	public static readonly DependencyProperty AvailableHourFormatsProperty = DependencyProperty.Register("AvailableHourFormats", typeof(IEnumerable<TimerFormatStyle>), typeof(TimerFormatSelector));

	public static readonly DependencyProperty AvailableMinuteFormatsProperty = DependencyProperty.Register("AvailableMinuteFormats", typeof(IEnumerable<TimerFormatStyle>), typeof(TimerFormatSelector));

	public static readonly DependencyProperty AvailableSecondFormatsProperty = DependencyProperty.Register("AvailableSecondFormats", typeof(IEnumerable<TimerFormatStyle>), typeof(TimerFormatSelector));

	public static readonly DependencyProperty AvailableMillisecondFormatsProperty = DependencyProperty.Register("AvailableMillisecondFormats", typeof(IEnumerable<TimerFormatStyle>), typeof(TimerFormatSelector));

	public static readonly DependencyProperty SecondsEnabledProperty = DependencyProperty.Register("SecondsEnabled", typeof(bool), typeof(TimerFormatSelector));

	public static readonly DependencyProperty SupportsMillisecondsProperty = DependencyProperty.Register("SupportsMilliseconds", typeof(bool), typeof(TimerFormatSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty SelectHourFormatCommandProperty = DependencyProperty.Register("SelectHourFormatCommand", typeof(ICommand<TimerFormatStyle>), typeof(TimerFormatSelector));

	public static readonly DependencyProperty SelectMinuteFormatCommandProperty = DependencyProperty.Register("SelectMinuteFormatCommand", typeof(ICommand<TimerFormatStyle>), typeof(TimerFormatSelector));

	public static readonly DependencyProperty SelectSecondFormatCommandProperty = DependencyProperty.Register("SelectSecondFormatCommand", typeof(ICommand<TimerFormatStyle>), typeof(TimerFormatSelector));

	public static readonly DependencyProperty SelectMillisecondFormatCommandProperty = DependencyProperty.Register("SelectMillisecondFormatCommand", typeof(ICommand<TimerFormatStyle>), typeof(TimerFormatSelector));

	public TimerFormatStyle? SelectedHourFormat
	{
		get
		{
			return (TimerFormatStyle?)((DependencyObject)this).GetValue(SelectedHourFormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedHourFormatProperty, (object)value);
		}
	}

	public TimerFormatStyle? SelectedMinuteFormat
	{
		get
		{
			return (TimerFormatStyle?)((DependencyObject)this).GetValue(SelectedMinuteFormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedMinuteFormatProperty, (object)value);
		}
	}

	public TimerFormatStyle? SelectedSecondFormat
	{
		get
		{
			return (TimerFormatStyle?)((DependencyObject)this).GetValue(SelectedSecondFormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedSecondFormatProperty, (object)value);
		}
	}

	public TimerFormatStyle? SelectedMillisecondFormat
	{
		get
		{
			return (TimerFormatStyle?)((DependencyObject)this).GetValue(SelectedMillisecondFormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedMillisecondFormatProperty, (object)value);
		}
	}

	public IEnumerable<TimerFormatStyle>? AvailableHourFormats
	{
		get
		{
			return (IEnumerable<TimerFormatStyle>)((DependencyObject)this).GetValue(AvailableHourFormatsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableHourFormatsProperty, (object)value);
		}
	}

	public IEnumerable<TimerFormatStyle>? AvailableMinuteFormats
	{
		get
		{
			return (IEnumerable<TimerFormatStyle>)((DependencyObject)this).GetValue(AvailableMinuteFormatsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableMinuteFormatsProperty, (object)value);
		}
	}

	public IEnumerable<TimerFormatStyle>? AvailableSecondFormats
	{
		get
		{
			return (IEnumerable<TimerFormatStyle>)((DependencyObject)this).GetValue(AvailableSecondFormatsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableSecondFormatsProperty, (object)value);
		}
	}

	public IEnumerable<TimerFormatStyle>? AvailableMillisecondFormats
	{
		get
		{
			return (IEnumerable<TimerFormatStyle>)((DependencyObject)this).GetValue(AvailableMillisecondFormatsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableMillisecondFormatsProperty, (object)value);
		}
	}

	public bool SecondsEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SecondsEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SecondsEnabledProperty, (object)value);
		}
	}

	public bool SupportsMilliseconds
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SupportsMillisecondsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SupportsMillisecondsProperty, (object)value);
		}
	}

	public static IEnumerable<TimerFormatStyle> AvailableStyles => Enum.GetValues<TimerFormatStyle>();

	public ICommand<TimerFormatStyle> SelectHourFormatCommand
	{
		get
		{
			return (ICommand<TimerFormatStyle>)((DependencyObject)this).GetValue(SelectHourFormatCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectHourFormatCommandProperty, (object)value);
		}
	}

	public ICommand<TimerFormatStyle> SelectMinuteFormatCommand
	{
		get
		{
			return (ICommand<TimerFormatStyle>)((DependencyObject)this).GetValue(SelectMinuteFormatCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectMinuteFormatCommandProperty, (object)value);
		}
	}

	public ICommand<TimerFormatStyle> SelectSecondFormatCommand
	{
		get
		{
			return (ICommand<TimerFormatStyle>)((DependencyObject)this).GetValue(SelectSecondFormatCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectSecondFormatCommandProperty, (object)value);
		}
	}

	public ICommand<TimerFormatStyle> SelectMillisecondFormatCommand
	{
		get
		{
			return (ICommand<TimerFormatStyle>)((DependencyObject)this).GetValue(SelectMillisecondFormatCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectMillisecondFormatCommandProperty, (object)value);
		}
	}

	public TimerFormatSelector()
	{
		SelectHourFormatCommand = new RelayCommand<TimerFormatStyle>(delegate(TimerFormatStyle s)
		{
			SelectedHourFormat = s;
		});
		SelectMinuteFormatCommand = new RelayCommand<TimerFormatStyle>(delegate(TimerFormatStyle s)
		{
			SelectedMinuteFormat = s;
		});
		SelectSecondFormatCommand = new RelayCommand<TimerFormatStyle>(delegate(TimerFormatStyle s)
		{
			SelectedSecondFormat = s;
		});
		SelectMillisecondFormatCommand = new RelayCommand<TimerFormatStyle>(delegate(TimerFormatStyle s)
		{
			SelectedMillisecondFormat = s;
		});
		InitializeComponent();
	}

	private void MenuItem_Click(object? sender, RoutedEventArgs e)
	{
		SelectedHourFormat = (TimerFormatStyle?)(sender as MenuItem)?.DataContext;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
