using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.ChangeDirectory;

namespace ProPresenter.UI.Settings.PageTemplates.General;

public partial class ChangeDirectoryProgressWindow : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty ProcessProperty = DependencyProperty.Register("Process", typeof(ChangeDirectoryProcess), typeof(ChangeDirectoryProgressWindow));

	public IChangeDirectoryProcess? Process
	{
		get
		{
			return (IChangeDirectoryProcess)((DependencyObject)this).GetValue(ProcessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ProcessProperty, (object)value);
		}
	}

	public ChangeDirectoryProgressWindow()
	{
		InitializeComponent();
	}
}
