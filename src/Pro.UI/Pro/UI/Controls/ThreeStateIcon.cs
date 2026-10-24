using System.Windows;
using System.Windows.Media;

namespace Pro.UI.Controls;

public class ThreeStateIcon : Icon
{
	public static readonly DependencyProperty IndeterminateStateSourceProperty = DependencyProperty.Register("IndeterminateStateSource", typeof(ImageSource), typeof(ThreeStateIcon));

	public static readonly DependencyProperty StateOneSourceProperty = DependencyProperty.Register("StateOneSource", typeof(ImageSource), typeof(ThreeStateIcon));

	public static readonly DependencyProperty StateProperty = DependencyProperty.Register("State", typeof(bool?), typeof(ThreeStateIcon), new PropertyMetadata((object)false, new PropertyChangedCallback(OnStateChanged)));

	public static readonly DependencyProperty StateTwoSourceProperty = DependencyProperty.Register("StateTwoSource", typeof(ImageSource), typeof(ThreeStateIcon));

	public ImageSource IndeterminateStateSource
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(IndeterminateStateSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IndeterminateStateSourceProperty, (object)value);
		}
	}

	public bool? State
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(StateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StateProperty, (object)value);
		}
	}

	public ImageSource StateOneSource
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(StateOneSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StateOneSourceProperty, (object)value);
		}
	}

	public ImageSource StateTwoSource
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(StateTwoSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StateTwoSourceProperty, (object)value);
		}
	}

	public ThreeStateIcon()
	{
		base.Loaded += delegate
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			OnStateChanged((DependencyObject)(object)this, new DependencyPropertyChangedEventArgs(StateProperty, (object)State, (object)State));
		};
	}

	private static void OnStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		ThreeStateIcon threeStateIcon = (ThreeStateIcon)(object)d;
		bool? flag = (bool?)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		if (flag.HasValue)
		{
			if (flag == true)
			{
				threeStateIcon.Source = threeStateIcon.StateOneSource;
			}
			else
			{
				threeStateIcon.Source = threeStateIcon.StateTwoSource;
			}
		}
		else
		{
			threeStateIcon.Source = threeStateIcon.IndeterminateStateSource;
		}
	}
}
