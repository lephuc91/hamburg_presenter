using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.PCO;

namespace ProPresenter.UI.PCOLive;

public partial class PCOPlanBrowser : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty SelectPCOPlanCommandProperty = DependencyProperty.Register("SelectPCOPlanCommand", typeof(ICommand<PCOPlan>), typeof(PCOPlanBrowser));

	public ICommand<PCOPlan> SelectPCOPlanCommand
	{
		get
		{
			return (ICommand<PCOPlan>)((DependencyObject)this).GetValue(SelectPCOPlanCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectPCOPlanCommandProperty, (object)value);
		}
	}

	public PCOPlanBrowser()
	{
		InitializeComponent();
	}

	private void SelectButton_Click(object? sender, RoutedEventArgs e)
	{
		Close();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
