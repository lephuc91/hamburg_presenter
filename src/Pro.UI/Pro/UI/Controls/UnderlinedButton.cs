using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Pro.UI.Controls;

public class UnderlinedButton : BorderlessButton
{
	public static readonly DependencyProperty ShowHoverEffectProperty = DependencyProperty.Register("ShowHoverEffect", typeof(bool), typeof(UnderlinedButton), new PropertyMetadata((object)true, new PropertyChangedCallback(OnEffectPropertyChanged)));

	public static readonly DependencyProperty ShowPressedEffectProperty = DependencyProperty.Register("ShowPressedEffect", typeof(bool), typeof(UnderlinedButton), new PropertyMetadata((object)true, new PropertyChangedCallback(OnEffectPropertyChanged)));

	public bool ShowHoverEffect
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowHoverEffectProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowHoverEffectProperty, (object)value);
		}
	}

	public bool ShowPressedEffect
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowPressedEffectProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowPressedEffectProperty, (object)value);
		}
	}

	public UnderlinedButton()
	{
		base.Background = Brushes.Transparent;
		base.BorderThickness = new Thickness(0.0);
		base.Cursor = Cursors.Hand;
		ControlTemplate controlTemplate = new ControlTemplate(typeof(UnderlinedButton));
		FrameworkElementFactory frameworkElementFactory = new FrameworkElementFactory(typeof(Border));
		frameworkElementFactory.SetBinding(Border.PaddingProperty, new Binding("Padding")
		{
			RelativeSource = RelativeSource.TemplatedParent
		});
		frameworkElementFactory.SetBinding(Border.BackgroundProperty, new Binding("Background")
		{
			RelativeSource = RelativeSource.TemplatedParent
		});
		FrameworkElementFactory frameworkElementFactory2 = new FrameworkElementFactory(typeof(TextBlock));
		frameworkElementFactory2.SetBinding(TextBlock.ForegroundProperty, new Binding("Foreground")
		{
			RelativeSource = RelativeSource.TemplatedParent
		});
		frameworkElementFactory2.SetBinding(TextBlock.TextProperty, new Binding("Content")
		{
			RelativeSource = RelativeSource.TemplatedParent
		});
		frameworkElementFactory2.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding("HorizontalContentAlignment")
		{
			RelativeSource = RelativeSource.TemplatedParent
		});
		frameworkElementFactory2.SetBinding(FrameworkElement.VerticalAlignmentProperty, new Binding("VerticalContentAlignment")
		{
			RelativeSource = RelativeSource.TemplatedParent
		});
		frameworkElementFactory2.SetValue(TextBlock.TextDecorationsProperty, TextDecorations.Underline);
		frameworkElementFactory.AppendChild(frameworkElementFactory2);
		controlTemplate.VisualTree = frameworkElementFactory;
		base.Template = controlTemplate;
		ApplyEffectStyle();
	}

	private static void OnEffectPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is UnderlinedButton underlinedButton)
		{
			underlinedButton.ApplyEffectStyle();
		}
	}

	private void ApplyEffectStyle()
	{
		Style style = new Style(typeof(UnderlinedButton));
		if (ShowHoverEffect)
		{
			Trigger trigger = new Trigger
			{
				Property = UIElement.IsMouseOverProperty,
				Value = true
			};
			trigger.Setters.Add(new Setter(UIElement.OpacityProperty, 0.8));
			style.Triggers.Add(trigger);
		}
		if (ShowPressedEffect)
		{
			Trigger trigger2 = new Trigger
			{
				Property = ButtonBase.IsPressedProperty,
				Value = true
			};
			trigger2.Setters.Add(new Setter(UIElement.OpacityProperty, 0.6));
			style.Triggers.Add(trigger2);
		}
		base.Style = style;
	}
}
