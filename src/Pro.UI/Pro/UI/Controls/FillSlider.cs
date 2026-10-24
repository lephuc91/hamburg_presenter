using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

[TemplatePart(Name = "PART_ElapsedFill", Type = typeof(FrameworkElement))]
public class FillSlider : Slider
{
	private const string TrackName = "PART_Track";

	private const string ElapsedFillName = "PART_ElapsedFill";

	protected Track? Track { get; private set; }

	protected FrameworkElement? ElapsedFill { get; private set; }

	public FillSlider()
	{
		base.Loaded += delegate
		{
			UpdateMarkers();
		};
		base.SizeChanged += delegate
		{
			UpdateMarkers();
		};
		((PropertyDescriptor)(object)DependencyPropertyDescriptor.FromProperty(Slider.SelectionStartProperty, typeof(FillSlider)))?.AddValueChanged((object)this, (EventHandler)delegate
		{
			UpdateMarkers();
		});
		((PropertyDescriptor)(object)DependencyPropertyDescriptor.FromProperty(Slider.SelectionEndProperty, typeof(FillSlider)))?.AddValueChanged((object)this, (EventHandler)delegate
		{
			UpdateMarkers();
		});
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		Track = GetTemplateChild("PART_Track") as Track;
		ElapsedFill = GetTemplateChild("PART_ElapsedFill") as FrameworkElement;
	}

	protected override void OnValueChanged(double oldValue, double newValue)
	{
		base.OnValueChanged(oldValue, newValue);
		UpdateMarkers();
	}

	private void UpdateMarkers()
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		if (Track != null && ElapsedFill != null)
		{
			if (base.Orientation != 0)
			{
				throw new NotSupportedException();
			}
			double num = (base.IsDirectionReversed ? base.Maximum : base.Minimum);
			double num2 = (base.IsDirectionReversed ? base.Minimum : base.Maximum);
			double num3 = (base.IsDirectionReversed ? base.SelectionEnd : base.SelectionStart);
			double num4 = (base.IsDirectionReversed ? base.SelectionStart : base.SelectionEnd);
			Canvas? canvas = ((DependencyObject)(object)ElapsedFill).FindVisualParent<Canvas>();
			double num5;
			if (canvas == null)
			{
				num5 = 0.0;
			}
			else
			{
				Size renderSize = canvas.RenderSize;
				num5 = ((Size)(ref renderSize)).Width;
			}
			double num6 = num5 / (num2 - num);
			double fillWidth = Math.Max((base.IsSelectionRangeEnabled ? Math.Min(base.Value - num3, num4 - num3) : (base.Value - num)) * num6, 0.0);
			double startPosition = (base.IsSelectionRangeEnabled ? (num3 - num) : 0.0) * num6;
			double endPosition = (base.IsSelectionRangeEnabled ? (num4 - num) : (num2 - num)) * num6;
			OnUpdateMarkers(fillWidth, startPosition, endPosition);
		}
	}

	protected virtual void OnUpdateMarkers(double fillWidth, double startPosition, double endPosition)
	{
		if (ElapsedFill != null)
		{
			ElapsedFill.Width = fillWidth;
			Canvas.SetLeft(ElapsedFill, startPosition);
		}
	}
}
