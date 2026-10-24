using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using Pro.UI.Utility;

namespace ProPresenter.UI.Timer;

public partial class Timers : UserControl, IComponentConnector
{
	private const string RunningTimeDisplayName = "RunningTimeDisplay";

	private readonly DispatcherTimer _timer = new DispatcherTimer();

	public static readonly DependencyProperty GotFocusCommandProperty = DependencyProperty.Register("GotFocusCommand", typeof(ICommand), typeof(Timers));

	public ICommand? GotFocusCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(GotFocusCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GotFocusCommandProperty, (object)value);
		}
	}

	public Timers()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		InitializeComponent();
		_timer.Interval = TimeSpan.FromSeconds(1.0 / 60.0);
		_timer.Tick += Timer_Tick;
		_timer.Start();
		base.GotKeyboardFocus += delegate
		{
			GotFocusCommand?.Invoke();
		};
	}

	private void Timer_Tick(object? sender, EventArgs e)
	{
		foreach (TextBlock item in from t in ((DependencyObject)(object)TimerList).FindVisualChildren<TextBlock>()
			where t.Name == "RunningTimeDisplay"
			select t)
		{
			item.GetBindingExpression(TextBlock.TextProperty)?.UpdateTarget();
		}
	}

	private void TimerList_RequestBringIntoView(object? sender, RequestBringIntoViewEventArgs e)
	{
		e.Handled = true;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
