using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI;

public partial class SizeMenuItem : MenuItem, IComponentConnector
{
	public static readonly DependencyProperty TargetProperty = DependencyProperty.Register("Target", typeof(ISizeableTarget), typeof(SizeMenuItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((SizeMenuItem)(object)s).VM.Target = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ISizeableTarget;
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

	public SizeMenuItem()
	{
		InitializeComponent();
	}
}
