using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Settings.PageTemplates.General;

public partial class DuplicateWorkspaceProgressWindow : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty DuplicationTitleProperty = DependencyProperty.Register("DuplicationTitle", typeof(string), typeof(DuplicateWorkspaceProgressWindow), new PropertyMetadata((object)string.Empty));

	public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(string), typeof(DuplicateWorkspaceProgressWindow), new PropertyMetadata((object)string.Empty));

	public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register("Progress", typeof(double), typeof(DuplicateWorkspaceProgressWindow), new PropertyMetadata((object)0.0));

	public CancellationTokenSource CancellationTokenSource { get; }

	public ICommand CancelCommand => new RelayCommand(CancelOperation);

	public string Status
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(StatusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StatusProperty, (object)value);
		}
	}

	public string DuplicationTitle
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DuplicationTitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DuplicationTitleProperty, (object)value);
		}
	}

	public double Progress
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ProgressProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ProgressProperty, (object)value);
		}
	}

	public DuplicateWorkspaceProgressWindow()
	{
		InitializeComponent();
		CancellationTokenSource = new CancellationTokenSource();
	}

	public void CancelOperation()
	{
		CancellationTokenSource.Cancel();
	}
}
