using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Bibles;

namespace ProPresenter.UI.Bibles;

public partial class BiblesViewerSettings : UserControl, IComponentConnector
{
	public static readonly DependencyProperty IsThemeUIOpenProperty = DependencyProperty.Register("IsThemeUIOpen", typeof(bool), typeof(BiblesViewerSettings), new PropertyMetadata((object)false));

	private ICommand? RefreshBiblesCommand => (base.DataContext as IBiblesVM)?.RefreshBiblesCommand;

	public bool IsThemeUIOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsThemeUIOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsThemeUIOpenProperty, (object)value);
		}
	}

	public BiblesViewerSettings()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.IsVisibleChanged += (DependencyPropertyChangedEventHandler)delegate(object s, DependencyPropertyChangedEventArgs e)
		{
			object newValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			if (newValue is bool && (bool)newValue)
			{
				RefreshCurrentBibleSelection();
			}
		};
	}

	private void RefreshCurrentBibleSelection()
	{
		RefreshBiblesCommand?.Invoke();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
