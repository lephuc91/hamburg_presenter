using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI;

public partial class WarningSignSizeSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TargetProperty = DependencyProperty.Register("Target", typeof(ISizeableTarget), typeof(WarningSignSizeSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((WarningSignSizeSelector)(object)s).VM.Target = (ISizeableTarget)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}));

	private SizeSelectorVM VM => (SizeSelectorVM)base.DataContext;

	public ISizeableTarget Target
	{
		get
		{
			return (ISizeableTarget)((DependencyObject)this).GetValue(TargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TargetProperty, (object)value);
		}
	}

	public WarningSignSizeSelector()
	{
		InitializeComponent();
	}

	private void ContextMenu_Opened(object? sender, RoutedEventArgs e)
	{
		if (sender is ContextMenu contextMenu)
		{
			contextMenu.Items.Refresh();
		}
	}
}
