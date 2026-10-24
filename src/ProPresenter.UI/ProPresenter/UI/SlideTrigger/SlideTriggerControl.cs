using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;

namespace ProPresenter.UI.SlideTrigger;

public partial class SlideTriggerControl : UserControl, IComponentConnector
{
	private const double PopupLifespan = 1.0;

	private const int MaxDigits = 4;

	private DispatcherTimer _closePopupTimer = new DispatcherTimer
	{
		Interval = TimeSpan.FromSeconds(1.0)
	};

	public static readonly DependencyProperty CanShowPopupProperty = DependencyProperty.Register("CanShowPopup", typeof(bool), typeof(SlideTriggerControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SlideTriggerControl)(object)s).OnCanShowPopupChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public static readonly DependencyProperty HotkeyBackgroundProperty = DependencyProperty.Register("HotkeyBackground", typeof(Brush), typeof(SlideTriggerControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Orange));

	public static readonly DependencyProperty NumberBackgroundProperty = DependencyProperty.Register("NumberBackground", typeof(Brush), typeof(SlideTriggerControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Purple));

	private static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(SlideTriggerControl));

	private static readonly DependencyProperty BorderBackgroundProperty = DependencyProperty.Register("BorderBackground", typeof(Brush), typeof(SlideTriggerControl));

	public string SlideNumber { get; private set; } = string.Empty;

	public Key SlideHotkey { get; private set; }

	public bool CanShowPopup
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanShowPopupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanShowPopupProperty, (object)value);
		}
	}

	public Brush HotkeyBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(HotkeyBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HotkeyBackgroundProperty, (object)value);
		}
	}

	public Brush NumberBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(NumberBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NumberBackgroundProperty, (object)value);
		}
	}

	private string Text
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextProperty, (object)value);
		}
	}

	private Brush BorderBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(BorderBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BorderBackgroundProperty, (object)value);
		}
	}

	public SlideTriggerControl()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		InitializeComponent();
		_closePopupTimer.Tick += delegate
		{
			CanShowPopup = false;
		};
	}

	public void UpdateSlideNumber(int value, int slideCount)
	{
		if (slideCount != 0)
		{
			ResetPopupTimer();
			if (SlideNumber.Length < 4)
			{
				SlideNumber += value;
				Text = SlideNumber;
				BorderBackground = NumberBackground;
				CanShowPopup = true;
			}
		}
	}

	public void UpdateSlideHotkey(Key key, int slideCount)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (slideCount != 0)
		{
			Text = ((object)(Key)(ref key)/*cast due to .constrained prefix*/).ToString();
			BorderBackground = HotkeyBackground;
			SlideHotkey = key;
			CanShowPopup = true;
			ResetPopupTimer();
		}
	}

	public void StartPopupTimer()
	{
		_closePopupTimer.Start();
	}

	private void StopPopupTimer()
	{
		_closePopupTimer.Stop();
	}

	private void ResetPopupTimer()
	{
		StopPopupTimer();
		StartPopupTimer();
	}

	private void OnCanShowPopupChanged(bool canShow)
	{
		if (!canShow)
		{
			StopPopupTimer();
			SlideNumber = string.Empty;
			SlideHotkey = (Key)0;
		}
	}
}
