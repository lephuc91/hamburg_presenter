using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.DO.Token;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.Messages;

namespace ProPresenter.UI.Messages;

public partial class AddTokenControl : UserControl, IComponentConnector, IStyleConnector
{
	public static readonly DependencyProperty DefaultTokensProperty = DependencyProperty.Register("DefaultTokens", typeof(IEnumerable<TokenBase>), typeof(AddTokenControl));

	public static readonly DependencyProperty TimersProperty = DependencyProperty.Register("Timers", typeof(IEnumerable<TimerToken>), typeof(AddTokenControl));

	public static readonly DependencyProperty AddTokenCommandProperty = DependencyProperty.Register("AddTokenCommand", typeof(ICommand<MessageTokenBase>), typeof(AddTokenControl));

	public static readonly DependencyProperty AddCustomTokenCommandProperty = DependencyProperty.Register("AddCustomTokenCommand", typeof(ICommand<string>), typeof(AddTokenControl));

	public static readonly DependencyProperty AddTokenTextProperty = DependencyProperty.Register("AddTokenText", typeof(string), typeof(AddTokenControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public IEnumerable<TokenBase>? DefaultTokens
	{
		get
		{
			return (IEnumerable<TokenBase>)((DependencyObject)this).GetValue(DefaultTokensProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultTokensProperty, (object)value);
		}
	}

	public IEnumerable<TimerToken>? Timers
	{
		get
		{
			return (IEnumerable<TimerToken>)((DependencyObject)this).GetValue(TimersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimersProperty, (object)value);
		}
	}

	public ICommand<MessageTokenBase>? AddTokenCommand
	{
		get
		{
			return (ICommand<MessageTokenBase>)((DependencyObject)this).GetValue(AddTokenCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddTokenCommandProperty, (object)value);
		}
	}

	public ICommand<string>? AddCustomTokenCommand
	{
		get
		{
			return (ICommand<string>)((DependencyObject)this).GetValue(AddCustomTokenCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddCustomTokenCommandProperty, (object)value);
		}
	}

	public string? AddTokenText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(AddTokenTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddTokenTextProperty, (object)value);
		}
	}

	public AddTokenControl()
	{
		InitializeComponent();
	}

	private void TokenName_Keydown(object? sender, KeyEventArgs e)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Invalid comparison between Unknown and I4
		PlaceholderTextBox textBox = sender as PlaceholderTextBox;
		if (textBox != null && !string.IsNullOrEmpty(textBox.Text) && (int)e.Key == 6)
		{
			IEnumerable<TokenBase>? first = DefaultTokens ?? Enumerable.Empty<TokenBase>();
			IEnumerable<TokenBase> timers = Timers;
			if (first.Concat(timers ?? Enumerable.Empty<TokenBase>()).FirstOrDefault((TokenBase t) => t.Content.Equals(textBox.Text))?.Clone() is MessageTokenBase parameter)
			{
				AddTokenCommand?.Invoke(parameter);
			}
			else
			{
				AddCustomTokenCommand?.Invoke(textBox.Text);
			}
			textBox.Text = string.Empty;
		}
	}

	private void ClockToken_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is MenuItem { DataContext: ClockToken dataContext })
		{
			AddTokenCommand?.Invoke((ClockToken)dataContext.Clone());
		}
	}

	private void TextToken_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is MenuItem { DataContext: TextToken dataContext })
		{
			AddTokenCommand?.Invoke((TextToken)dataContext.Clone());
		}
	}

	private void Timer_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is MenuItem { DataContext: TimerToken dataContext })
		{
			AddTokenCommand?.Invoke((TimerToken)dataContext.Clone());
		}
	}

	private void ContextMenu_Opened(object? sender, RoutedEventArgs e)
	{
		if (sender is ContextMenu contextMenu)
		{
			contextMenu.HorizontalOffset = 0.0 - base.ActualWidth + dropButton.Width;
		}
	}
}
