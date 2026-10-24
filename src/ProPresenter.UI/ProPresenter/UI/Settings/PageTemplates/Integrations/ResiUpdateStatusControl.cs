using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations;

namespace ProPresenter.UI.Settings.PageTemplates.Integrations;

public partial class ResiUpdateStatusControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty UpdateStatusProperty = DependencyProperty.Register("UpdateStatus", typeof(UpdateStatusInternal), typeof(ResiUpdateStatusControl), new PropertyMetadata((object)UpdateStatusInternal.None));

	public static readonly DependencyProperty DownloadProgressProperty = DependencyProperty.Register("DownloadProgress", typeof(double), typeof(ResiUpdateStatusControl), new PropertyMetadata((object)0.0));

	public static readonly DependencyProperty CancelDownloadCommandProperty = DependencyProperty.Register("CancelDownloadCommand", typeof(ICommand), typeof(ResiUpdateStatusControl));

	public UpdateStatusInternal UpdateStatus
	{
		get
		{
			return (UpdateStatusInternal)((DependencyObject)this).GetValue(UpdateStatusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UpdateStatusProperty, (object)value);
		}
	}

	public double DownloadProgress
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(DownloadProgressProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DownloadProgressProperty, (object)value);
		}
	}

	public ICommand? CancelDownloadCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CancelDownloadCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelDownloadCommandProperty, (object)value);
		}
	}

	public ResiUpdateStatusControl()
	{
		InitializeComponent();
	}
}
