using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Feedback;

public partial class FeedbackDialog : ChromedWindow, IComponentConnector
{
	public FeedbackDialog()
	{
		InitializeComponent();
	}

	private void FeedbackRequestTypeComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		if (e.AddedItems.Contains(FeedbackRequestType.None) && e.RemovedItems.Count > 0 && sender is ComboBox comboBox)
		{
			comboBox.SelectedItem = e.RemovedItems[0];
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
