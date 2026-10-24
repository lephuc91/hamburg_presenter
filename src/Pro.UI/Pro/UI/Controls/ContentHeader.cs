using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Pro.UI.Controls;

public partial class ContentHeader : UserControl, IComponentConnector
{
	public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof(string), typeof(ContentHeader), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty));

	public static readonly DependencyProperty DividerColorProperty = DependencyProperty.Register("DividerColor", typeof(Brush), typeof(ContentHeader), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.DarkGray));

	public string HeaderText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(HeaderTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HeaderTextProperty, (object)value);
		}
	}

	public Brush DividerColor
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(DividerColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DividerColorProperty, (object)value);
		}
	}

	public ContentHeader()
	{
		InitializeComponent();
	}
}
