using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using Pro.Text;

namespace Pro.UI.Controls;

public partial class ScrollableFormattedTextBox : UserControl, IFormattedTextBox, IComponentConnector
{
	public static readonly DependencyProperty DocumentProperty = DependencyProperty.Register("Document", typeof(TextDocument), typeof(ScrollableFormattedTextBox));

	public static readonly DependencyProperty SelectionRangesProperty = DependencyProperty.Register("SelectionRanges", typeof(Pro.Text.Range[]), typeof(ScrollableFormattedTextBox));

	public static readonly DependencyProperty CaretIndexProperty = DependencyProperty.Register("CaretIndex", typeof(int), typeof(ScrollableFormattedTextBox));

	public static readonly DependencyProperty ActiveRunSettingsProperty = DependencyProperty.Register("ActiveRunSettings", typeof(RunSettings), typeof(ScrollableFormattedTextBox));

	public static readonly DependencyProperty DefaultRunSettingsProperty = DependencyProperty.Register("DefaultRunSettings", typeof(RunSettings), typeof(ScrollableFormattedTextBox));

	public static readonly DependencyProperty SpellCheckEnableProperty = DependencyProperty.Register("SpellCheckEnable", typeof(bool), typeof(ScrollableFormattedTextBox));

	public Pro.Text.Range[] SelectionRanges
	{
		get
		{
			return (Pro.Text.Range[])((DependencyObject)this).GetValue(SelectionRangesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectionRangesProperty, (object)value);
		}
	}

	public int CaretIndex
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(CaretIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaretIndexProperty, (object)value);
		}
	}

	public TextDocument Document
	{
		get
		{
			return (TextDocument)((DependencyObject)this).GetValue(DocumentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentProperty, (object)value);
		}
	}

	public RunSettings ActiveRunSettings
	{
		get
		{
			return (RunSettings)((DependencyObject)this).GetValue(ActiveRunSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveRunSettingsProperty, (object)value);
		}
	}

	public RunSettings DefaultRunSettings
	{
		get
		{
			return (RunSettings)((DependencyObject)this).GetValue(DefaultRunSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultRunSettingsProperty, (object)value);
		}
	}

	public FormattedTextBox EditText => CustomTextBox;

	public bool SpellCheckEnable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SpellCheckEnableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SpellCheckEnableProperty, (object)value);
		}
	}

	public event Action<Vector2<double>, FormattedTextBox.CaretLocation, double>? CaretPositionChanged;

	public event Action? TextChanged;

	public event Action? ExitRequested;

	public ScrollableFormattedTextBox()
	{
		InitializeComponent();
		base.SizeChanged += ScrollableFormattedTextBox_SizeChanged;
		CustomTextBox.CaretPositionChanged += CustomTextBox_CaretPositionChanged;
		CustomTextBox.TextChanged += delegate
		{
			this.TextChanged?.Invoke();
		};
		CustomTextBox.ExitRequested += delegate
		{
			this.ExitRequested?.Invoke();
		};
	}

	private void CustomTextBox_CaretPositionChanged(Vector2<double> caretPosition, FormattedTextBox.CaretLocation caretLocation, double caretHeight)
	{
		if (Mouse.LeftButton != MouseButtonState.Pressed && (caretPosition.Y + caretHeight > Scroller.VerticalOffset + Scroller.ViewportHeight || caretPosition.Y < Scroller.VerticalOffset))
		{
			Scroller.ScrollToVerticalOffset(caretPosition.Y - caretHeight);
		}
		this.CaretPositionChanged?.Invoke(caretPosition, caretLocation, caretHeight);
	}

	private void ScrollableFormattedTextBox_SizeChanged(object? sender, SizeChangedEventArgs e)
	{
		CustomTextBox.InvalidateVisual();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
