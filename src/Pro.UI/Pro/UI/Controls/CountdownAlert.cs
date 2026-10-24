using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;

namespace Pro.UI.Controls;

public partial class CountdownAlert : UserControl, IComponentConnector
{
	private readonly DispatcherTimer _timer = new DispatcherTimer
	{
		Interval = TimeSpan.FromSeconds(1.0)
	};

	public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(CountdownAlert));

	public static readonly DependencyProperty SubtextProperty = DependencyProperty.Register("Subtext", typeof(string), typeof(CountdownAlert));

	public static readonly DependencyProperty StartingSecondsProperty = DependencyProperty.Register("StartingSeconds", typeof(int), typeof(CountdownAlert));

	public static readonly DependencyProperty CountdownForegroundProperty = DependencyProperty.Register("CountdownForeground", typeof(Brush), typeof(CountdownAlert), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Red));

	public string Message
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(MessageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MessageProperty, (object)value);
		}
	}

	public string Subtext
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SubtextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SubtextProperty, (object)value);
		}
	}

	public int StartingSeconds
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(StartingSecondsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartingSecondsProperty, (object)value);
		}
	}

	public Brush CountdownForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(CountdownForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CountdownForegroundProperty, (object)value);
		}
	}

	public event Action? CountdownComplete;

	public CountdownAlert()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		InitializeComponent();
		base.Loaded += OnLoad;
	}

	private void OnLoad(object? sender, RoutedEventArgs e)
	{
		base.Loaded -= OnLoad;
		if (StartingSeconds != 0)
		{
			_timer.Tick += OnTick;
			_timer.Start();
		}
	}

	private void OnTick(object? sender, EventArgs e)
	{
		StartingSeconds--;
		if (StartingSeconds <= 0)
		{
			_timer.Stop();
			_timer.Tick -= OnTick;
			this.CountdownComplete?.Invoke();
		}
	}
}
