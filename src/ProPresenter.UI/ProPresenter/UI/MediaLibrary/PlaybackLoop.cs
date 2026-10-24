using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Time;
using Pro.ssAPI;

namespace ProPresenter.UI.MediaLibrary;

public partial class PlaybackLoop : UserControl, IComponentConnector
{
	public static readonly DependencyProperty PlaybackBehaviorProperty = DependencyProperty.Register("PlaybackBehavior", typeof(PlaybackBehaviorType), typeof(PlaybackLoop), new PropertyMetadata((object)PlaybackBehaviorType.Stop));

	public static readonly DependencyProperty PlaylbackTimeProperty = DependencyProperty.Register("PlaylbackTime", typeof(TimeSlice), typeof(PlaybackLoop), new PropertyMetadata((object)TimeSlice.Zero));

	public static readonly DependencyProperty PlaylbackCountProperty = DependencyProperty.Register("PlaylbackCount", typeof(int), typeof(PlaybackLoop), new PropertyMetadata((object)0));

	public PlaybackBehaviorType PlaybackBehavior
	{
		get
		{
			return (PlaybackBehaviorType)((DependencyObject)this).GetValue(PlaybackBehaviorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlaybackBehaviorProperty, (object)value);
		}
	}

	public TimeSlice PlaylbackTime
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(PlaylbackTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlaylbackTimeProperty, (object)value);
		}
	}

	public int PlaylbackCount
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(PlaylbackCountProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlaylbackCountProperty, (object)value);
		}
	}

	public PlaybackLoop()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(PlaybackLoop_IsVisibleChanged);
	}

	private void PlaybackLoop_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		base.IsVisibleChanged -= new DependencyPropertyChangedEventHandler(PlaybackLoop_IsVisibleChanged);
		if (base.IsVisible)
		{
			if (PlaybackBehavior == PlaybackBehaviorType.LoopForCount)
			{
				Count.Focus();
			}
			else if (PlaybackBehavior == PlaybackBehaviorType.LoopForTime)
			{
				Time.SelectAll();
				Time.Focus();
			}
		}
	}
}
