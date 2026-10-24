using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.PresentationView.GoToNext;

public partial class SlideTimerCueDialog : UserControl, IComponentConnector
{
	public const double DefaultDuration = 5.0;

	public const bool DefaultLoopToBeginning = false;

	public static readonly DependencyProperty DurationProperty = DependencyProperty.Register("Duration", typeof(double), typeof(SlideTimerCueDialog));

	public static readonly DependencyProperty LoopToBeginningProperty = DependencyProperty.Register("LoopToBeginning", typeof(bool), typeof(SlideTimerCueDialog));

	public static readonly DependencyProperty LoopToBeginningAvailableProperty = DependencyProperty.Register("LoopToBeginningAvailable", typeof(bool), typeof(SlideTimerCueDialog));

	public double Duration
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(DurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DurationProperty, (object)value);
		}
	}

	public bool LoopToBeginningAvailable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(LoopToBeginningAvailableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LoopToBeginningAvailableProperty, (object)value);
		}
	}

	public bool LoopToBeginning
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(LoopToBeginningProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LoopToBeginningProperty, (object)value);
		}
	}

	public SlideTimerCueDialog()
	{
		base.Loaded += SlideTimerCueDialog_Loaded;
		InitializeComponent();
	}

	private void SlideTimerCueDialog_Loaded(object sender, RoutedEventArgs e)
	{
		TimerDuration.Focus();
	}
}
