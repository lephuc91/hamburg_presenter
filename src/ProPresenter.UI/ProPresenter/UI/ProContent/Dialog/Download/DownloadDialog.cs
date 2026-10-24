using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using ProPresenter.UI.ViewModels.ProContent.Dialog.Download;

namespace ProPresenter.UI.ProContent.Dialog.Download;

public partial class DownloadDialog : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty ContextProperty = DependencyProperty.Register("Context", typeof(IProContentDownloadDialogVM), typeof(DownloadDialog));

	public IProContentDownloadDialogVM Context
	{
		get
		{
			return (IProContentDownloadDialogVM)((DependencyObject)this).GetValue(ContextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContextProperty, (object)value);
		}
	}

	public DownloadDialog(IProContentDownloadDialogVM context)
	{
		Context = context;
		InitializeComponent();
	}

	private void OK_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
		Close();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
