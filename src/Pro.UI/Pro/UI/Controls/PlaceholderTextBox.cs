using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Collections;

namespace Pro.UI.Controls;

public partial class PlaceholderTextBox : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(PlaceholderTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty PlaceholderTextProperty = DependencyProperty.RegisterAttached("PlaceholderText", typeof(string), typeof(PlaceholderTextBox));

	public static readonly DependencyProperty PlaceholderPathTypeProperty = DependencyProperty.Register("PlaceholderPathType", typeof(PathType?), typeof(PlaceholderTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));

	public static readonly DependencyProperty PlaceholderForegroundProperty = DependencyProperty.RegisterAttached("PlaceholderForeground", typeof(Brush), typeof(PlaceholderTextBox), new PropertyMetadata((object)Brushes.LightGray));

	public static readonly DependencyProperty ShowClearButtonProperty = DependencyProperty.Register("ShowClearButton", typeof(bool), typeof(PlaceholderTextBox));

	public static readonly DependencyProperty IsTextBindingExplicitProperty = DependencyProperty.Register("IsTextBindingExplicit", typeof(bool), typeof(PlaceholderTextBox));

	public static readonly DependencyProperty KeepFocusProperty = DependencyProperty.Register("KeepFocus", typeof(bool), typeof(PlaceholderTextBox));

	public static readonly DependencyProperty SelectAndFocusProperty = DependencyProperty.Register("SelectAndFocus", typeof(bool), typeof(PlaceholderTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is PlaceholderTextBox placeholderTextBox && (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			placeholderTextBox.InputBox.Focus();
			placeholderTextBox.SelectAll();
		}
	}));

	public static readonly DependencyProperty CustomContextMenuProperty = DependencyProperty.Register("CustomContextMenu", typeof(ContextMenu), typeof(PlaceholderTextBox));

	public static readonly DependencyProperty TextContentVerticalAlignmentProperty = DependencyProperty.Register("TextContentVerticalAlignment", typeof(VerticalAlignment), typeof(PlaceholderTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)VerticalAlignment.Center));

	public static readonly DependencyProperty TextContentHorizontalAlignmentProperty = DependencyProperty.Register("TextContentHorizontalAlignment", typeof(HorizontalAlignment), typeof(PlaceholderTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)HorizontalAlignment.Stretch));

	public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(PlaceholderTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TextWrapping.NoWrap));

	public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register("MaxLength", typeof(int), typeof(PlaceholderTextBox));

	public static readonly DependencyProperty AcceptsReturnProperty = DependencyProperty.Register("AcceptsReturn", typeof(bool), typeof(PlaceholderTextBox));

	public static readonly DependencyProperty MinLinesProperty = DependencyProperty.Register("MinLines", typeof(int), typeof(PlaceholderTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1));

	public static readonly DependencyProperty MaxLinesProperty = DependencyProperty.Register("MaxLines", typeof(int), typeof(PlaceholderTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)int.MaxValue));

	public static readonly DependencyProperty FocusOnVisibleProperty = DependencyProperty.Register("FocusOnVisible", typeof(bool), typeof(PlaceholderTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty AutoCompleteItemsSourceProperty = DependencyProperty.Register("AutoCompleteItemsSource", typeof(IEnumerable<string>), typeof(PlaceholderTextBox));

	public static readonly DependencyProperty SpellCheckEnableProperty = DependencyProperty.Register("SpellCheckEnable", typeof(bool), typeof(PlaceholderTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public string Text
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextProperty, (object)value);
		}
	}

	public string PlaceholderText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(PlaceholderTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlaceholderTextProperty, (object)value);
		}
	}

	public PathType? PlaceholderPathType
	{
		get
		{
			return (PathType?)((DependencyObject)this).GetValue(PlaceholderPathTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlaceholderPathTypeProperty, (object)value);
		}
	}

	public Brush PlaceholderForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(PlaceholderForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlaceholderForegroundProperty, (object)value);
		}
	}

	public bool ShowClearButton
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowClearButtonProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowClearButtonProperty, (object)value);
		}
	}

	public bool IsTextBindingExplicit
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsTextBindingExplicitProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsTextBindingExplicitProperty, (object)value);
		}
	}

	public bool KeepFocus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(KeepFocusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(KeepFocusProperty, (object)value);
		}
	}

	public bool SelectAndFocus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SelectAndFocusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectAndFocusProperty, (object)value);
		}
	}

	public ContextMenu CustomContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(CustomContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CustomContextMenuProperty, (object)value);
		}
	}

	public VerticalAlignment TextContentVerticalAlignment
	{
		get
		{
			return (VerticalAlignment)((DependencyObject)this).GetValue(TextContentVerticalAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextContentVerticalAlignmentProperty, (object)value);
		}
	}

	public HorizontalAlignment TextContentHorizontalAlignment
	{
		get
		{
			return (HorizontalAlignment)((DependencyObject)this).GetValue(TextContentHorizontalAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextContentHorizontalAlignmentProperty, (object)value);
		}
	}

	public TextWrapping TextWrapping
	{
		get
		{
			return (TextWrapping)((DependencyObject)this).GetValue(TextWrappingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextWrappingProperty, (object)value);
		}
	}

	public int MaxLength
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(MaxLengthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxLengthProperty, (object)value);
		}
	}

	public bool AcceptsReturn
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AcceptsReturnProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AcceptsReturnProperty, (object)value);
		}
	}

	public int MinLines
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(MinLinesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinLinesProperty, (object)value);
		}
	}

	public int MaxLines
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(MaxLinesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxLinesProperty, (object)value);
		}
	}

	public bool FocusOnVisible
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(FocusOnVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FocusOnVisibleProperty, (object)value);
		}
	}

	public IEnumerable<string> AutoCompleteItemsSource
	{
		get
		{
			return (IEnumerable<string>)((DependencyObject)this).GetValue(AutoCompleteItemsSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoCompleteItemsSourceProperty, (object)value);
		}
	}

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

	public PlaceholderTextBox()
	{
		InitializeComponent();
	}

	private void UpdateTextBinding()
	{
		if (IsTextBindingExplicit)
		{
			InputBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
		}
	}

	private void TextBox_KeyEvent(object? sender, KeyEventArgs e)
	{
		HandleKeyEvent(e);
	}

	protected virtual void HandleKeyEvent(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (e.Key.IsAnyOf((Key[])(object)new Key[2]
		{
			(Key)6,
			(Key)6
		}))
		{
			UpdateTextBinding();
		}
	}

	private void ClearButton_Click(object? sender, RoutedEventArgs e)
	{
		ClearInput();
	}

	protected void ClearInput()
	{
		InputBox.Clear();
		UpdateTextBinding();
		InputBox.Focus();
	}

	protected override void OnGotFocus(RoutedEventArgs e)
	{
		InputBox.Focus();
	}

	public void SelectAll()
	{
		InputBox.SelectAll();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
