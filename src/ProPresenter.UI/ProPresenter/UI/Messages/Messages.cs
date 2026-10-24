using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.Messages;

public partial class Messages : UserControl, IComponentConnector
{
	private const string RunningTimeDisplayName = "RunningTimeDisplay";

	private const double DragCollapseThreshold = 5.0;

	private readonly DispatcherTimer _timer = new DispatcherTimer();

	private GridLength _prevHeight;

	public static readonly DependencyProperty DefaultThemeProperty = DependencyProperty.Register("DefaultTheme", typeof(Theme), typeof(Messages));

	public Theme? DefaultTheme
	{
		get
		{
			return (Theme)((DependencyObject)this).GetValue(DefaultThemeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultThemeProperty, (object)value);
		}
	}

	public Messages()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		InitializeComponent();
		_timer.Interval = TimeSpan.FromMilliseconds(250L, 0L);
		_timer.Tick += TimerTick;
		_timer.Start();
		_prevHeight = Layout.Settings.MessageOutlineHeight;
		base.GotKeyboardFocus += delegate
		{
			if (base.DataContext is IMessagesVM messagesVM)
			{
				messagesVM.GotFocusCommand?.Invoke();
			}
		};
	}

	private void TimerTick(object? sender, EventArgs e)
	{
		foreach (TextBlock item in from t in ((DependencyObject)(object)MessageTokensList).FindVisualChildren<TextBlock>()
			where t.Name == "RunningTimeDisplay"
			select t)
		{
			item.GetBindingExpression(TextBlock.TextProperty)?.UpdateTarget();
		}
	}

	private void GridSplitter_DragDelta(object? sender, DragDeltaEventArgs e)
	{
		if (MessageListRow.ActualHeight < 5.0 && e.VerticalChange < -5.0)
		{
			Layout.Settings.MessagesOutlineVisible = false;
		}
		else if (MessageListRow.ActualHeight >= 5.0 || e.VerticalChange > 5.0)
		{
			Layout.Settings.MessagesOutlineVisible = true;
		}
	}

	private void ExpanderToggleButton_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is ExpanderToggleButton { IsChecked: var isChecked })
		{
			if (isChecked == true)
			{
				Layout.Settings.MessageOutlineHeight = ((_prevHeight.Value == 0.0) ? new GridLength(100.0, GridUnitType.Star) : _prevHeight);
				return;
			}
			_prevHeight = MessageListRow.Height;
			Layout.Settings.MessageOutlineHeight = new GridLength(0.0, GridUnitType.Star);
		}
	}

	private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		if (Keyboard.FocusedElement is TimeSliceTextBox)
		{
			Keyboard.ClearFocus();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
