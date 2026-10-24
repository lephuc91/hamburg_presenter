using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Capture;

public partial class CaptureWindow : ChromedWindow, IComponentConnector
{
	private readonly ICommand _gotFocusCommand;

	public CaptureWindow(ICommand gotFocusCommand)
	{
		InitializeComponent();
		_gotFocusCommand = gotFocusCommand;
	}

	protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		_gotFocusCommand.Execute(null);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
