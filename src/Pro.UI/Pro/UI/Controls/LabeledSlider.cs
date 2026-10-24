using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace Pro.UI.Controls;

[TemplatePart(Name = "PART_BottomTick", Type = typeof(LabeledTickBar))]
[TemplatePart(Name = "PART_Thumb", Type = typeof(Thumb))]
public class LabeledSlider : Slider
{
	public static readonly DependencyProperty LabelsProperty;

	private const string PartBottomTickBar = "PART_BottomTick";

	private const string PartThumb = "PART_Thumb";

	private LabeledTickBar? _bottomTickBar;

	public ObservableCollection<string> Labels
	{
		get
		{
			return (ObservableCollection<string>)((DependencyObject)this).GetValue(LabelsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LabelsProperty, (object)value);
		}
	}

	static LabeledSlider()
	{
		LabelsProperty = DependencyProperty.Register("Labels", typeof(ObservableCollection<string>), typeof(LabeledSlider));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(LabeledSlider)));
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		Thumb thumb = GetTemplateChild("PART_Thumb") as Thumb;
		_bottomTickBar = GetTemplateChild("PART_BottomTick") as LabeledTickBar;
		if (thumb != null && _bottomTickBar != null)
		{
			_bottomTickBar.SetBinding(TickBar.ReservedSpaceProperty, new Binding
			{
				Source = thumb,
				Path = ((base.Orientation != 0) ? new PropertyPath(FrameworkElement.ActualHeightProperty) : new PropertyPath(FrameworkElement.ActualWidthProperty))
			});
			_bottomTickBar.Minimum = base.Minimum;
			_bottomTickBar.Maximum = base.Maximum;
		}
	}

	protected override void OnMaximumChanged(double oldMaximum, double newMaximum)
	{
		base.OnMaximumChanged(oldMaximum, newMaximum);
		if (_bottomTickBar != null)
		{
			_bottomTickBar.Maximum = newMaximum;
		}
	}

	protected override void OnMinimumChanged(double oldMinimum, double newMinimum)
	{
		base.OnMinimumChanged(oldMinimum, newMinimum);
		if (_bottomTickBar != null)
		{
			_bottomTickBar.Minimum = newMinimum;
		}
	}
}
