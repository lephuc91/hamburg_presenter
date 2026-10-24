using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.ProContent.Dialog.Download;

namespace ProPresenter.UI.ProContent.Dialog.Download;

public partial class PackDownloadDialogHeader : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ContextProperty = DependencyProperty.Register("Context", typeof(IProContentDownloadPackDialogVM), typeof(PackDownloadDialogHeader));

	public IProContentDownloadPackDialogVM? Context
	{
		get
		{
			return (IProContentDownloadPackDialogVM)((DependencyObject)this).GetValue(ContextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContextProperty, (object)value);
		}
	}

	public PackDownloadDialogHeader()
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
