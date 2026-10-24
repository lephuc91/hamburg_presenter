using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.ProContent.Dialog.Download;

namespace ProPresenter.UI.ProContent.Dialog.Download;

public partial class FileDownloadDialogHeader : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ContextProperty = DependencyProperty.Register("Context", typeof(IProContentDownloadFileDialogVM), typeof(FileDownloadDialogHeader));

	public IProContentDownloadFileDialogVM? Context
	{
		get
		{
			return (IProContentDownloadFileDialogVM)((DependencyObject)this).GetValue(ContextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContextProperty, (object)value);
		}
	}

	public FileDownloadDialogHeader()
	{
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
