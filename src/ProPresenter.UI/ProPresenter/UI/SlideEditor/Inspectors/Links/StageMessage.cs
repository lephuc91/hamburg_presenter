using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace ProPresenter.UI.SlideEditor.Inspectors.Links;

public partial class StageMessage : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ShouldFlashProperty = DependencyProperty.Register("ShouldFlash", typeof(bool), typeof(StageMessage), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty FlashColorProperty = DependencyProperty.Register("FlashColor", typeof(Color), typeof(StageMessage), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Colors.Green, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public bool ShouldFlash
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShouldFlashProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShouldFlashProperty, (object)value);
		}
	}

	public Color FlashColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(FlashColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FlashColorProperty, (object)value);
		}
	}

	public StageMessage()
	{
		InitializeComponent();
	}
}
