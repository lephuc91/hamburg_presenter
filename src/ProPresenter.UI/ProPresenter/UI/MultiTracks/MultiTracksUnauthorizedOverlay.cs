using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using ProPresenter.DO.Presentation;

namespace ProPresenter.UI.MultiTracks;

public partial class MultiTracksUnauthorizedOverlay : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectedPresentationProperty = DependencyProperty.Register("SelectedPresentation", typeof(PresentationBase), typeof(MultiTracksUnauthorizedOverlay), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty OpenWebsiteCommandProperty = DependencyProperty.Register("OpenWebsiteCommand", typeof(ICommand), typeof(MultiTracksUnauthorizedOverlay));

	public static readonly DependencyProperty RetryAuthorizationCommandProperty = DependencyProperty.Register("RetryAuthorizationCommand", typeof(ICommand), typeof(MultiTracksUnauthorizedOverlay));

	public static readonly DependencyProperty IsMultiTracksAvailableProperty = DependencyProperty.Register("IsMultiTracksAvailable", typeof(bool), typeof(MultiTracksUnauthorizedOverlay), new PropertyMetadata((object)false));

	public static readonly DependencyProperty IsCheckingAccountStatusProperty = DependencyProperty.Register("IsCheckingAccountStatus", typeof(bool), typeof(MultiTracksUnauthorizedOverlay), new PropertyMetadata((object)false));

	public ICommand? OpenWebsiteCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(OpenWebsiteCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OpenWebsiteCommandProperty, (object)value);
		}
	}

	public ICommand? RetryAuthorizationCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(RetryAuthorizationCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RetryAuthorizationCommandProperty, (object)value);
		}
	}

	public bool IsMultiTracksAvailable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsMultiTracksAvailableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsMultiTracksAvailableProperty, (object)value);
		}
	}

	public bool IsCheckingAccountStatus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsCheckingAccountStatusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsCheckingAccountStatusProperty, (object)value);
		}
	}

	public PresentationBase? SelectedPresentation
	{
		get
		{
			return (PresentationBase)((DependencyObject)this).GetValue(SelectedPresentationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedPresentationProperty, (object)value);
		}
	}

	public MultiTracksUnauthorizedOverlay()
	{
		InitializeComponent();
	}
}
