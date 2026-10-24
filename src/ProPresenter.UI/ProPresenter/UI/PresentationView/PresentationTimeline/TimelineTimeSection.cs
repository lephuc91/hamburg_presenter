using System.Windows;
using System.Windows.Controls;
using Pro.UI.Themes;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

[TemplatePart(Name = "PART_SubTicksPanel", Type = typeof(Panel))]
public class TimelineTimeSection : TimelineSection
{
	private const string PART_SUB_TICKS_PANEL = "PART_SubTicksPanel";

	private Panel? _subTicksPanel;

	public static readonly DependencyProperty SubTickCountProperty;

	public int SubTickCount
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(SubTickCountProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SubTickCountProperty, (object)value);
		}
	}

	static TimelineTimeSection()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		SubTickCountProperty = DependencyProperty.Register("SubTickCount", typeof(int), typeof(TimelineTimeSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSubTickCountPropertyChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelineTimeSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(TimelineTimeSection)));
		TimelineSection.AllowMoveProperty.OverrideMetadata(typeof(TimelineTimeSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		TimelineSection.AllowSelectProperty.OverrideMetadata(typeof(TimelineTimeSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
	}

	public override void OnApplyTemplate()
	{
		_subTicksPanel = GetTemplateChild("PART_SubTicksPanel") as Panel;
		UpdateSubTicks();
	}

	private static void OnSubTickCountPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TimelineTimeSection)(object)d).UpdateSubTicks();
	}

	private void UpdateSubTicks()
	{
		if (_subTicksPanel != null)
		{
			_subTicksPanel.Children.Clear();
			for (int i = 0; i < SubTickCount - 1; i++)
			{
				_subTicksPanel.Children.Add(new Border
				{
					HorizontalAlignment = HorizontalAlignment.Right,
					BorderThickness = new Thickness(1.0, 0.0, 0.0, 0.0),
					BorderBrush = Brushes.GetBrush(Brushes.TimelineTickMark)
				});
			}
		}
	}
}
