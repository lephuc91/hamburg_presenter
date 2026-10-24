using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Pro.UI.Controls;

public partial class EditableTextBlock : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TextProperty;

	public static readonly DependencyProperty DisplayStringFormatProperty;

	public static readonly DependencyProperty ValidationRuleProperty;

	public static readonly DependencyProperty CanEditProperty;

	public static readonly DependencyProperty IsInEditModeProperty;

	public static readonly DependencyProperty ClickToEditProperty;

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

	public string DisplayStringFormat
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DisplayStringFormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayStringFormatProperty, (object)value);
		}
	}

	public ValidationRule ValidationRule
	{
		get
		{
			return (ValidationRule)((DependencyObject)this).GetValue(ValidationRuleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValidationRuleProperty, (object)value);
		}
	}

	public bool CanEdit
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanEditProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanEditProperty, (object)value);
		}
	}

	public bool IsInEditMode
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsInEditModeProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(IsInEditModeProperty, (object)value);
		}
	}

	public bool ClickToEdit
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ClickToEditProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClickToEditProperty, (object)value);
		}
	}

	private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((EditableTextBlock)(object)d).UpdateText();
	}

	private static void OnDisplayStringFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((EditableTextBlock)(object)d).UpdateText();
	}

	private static void OnValidationRuleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((EditableTextBlock)(object)d).EditTextBox.GetBindingExpression(TextBox.TextProperty).ParentBinding.ValidationRules.Add((ValidationRule)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	static EditableTextBlock()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(EditableTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnTextChanged)));
		DisplayStringFormatProperty = DependencyProperty.Register("DisplayStringFormat", typeof(string), typeof(EditableTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDisplayStringFormatChanged)));
		ValidationRuleProperty = DependencyProperty.Register("ValidationRule", typeof(ValidationRule), typeof(EditableTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnValidationRuleChanged)));
		CanEditProperty = DependencyProperty.Register("CanEdit", typeof(bool), typeof(EditableTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		IsInEditModeProperty = DependencyProperty.Register("IsInEditMode", typeof(bool), typeof(EditableTextBlock));
		ClickToEditProperty = DependencyProperty.Register("ClickToEdit", typeof(bool), typeof(EditableTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		Control.BackgroundProperty.OverrideMetadata(typeof(EditableTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Transparent));
	}

	public EditableTextBlock()
	{
		InitializeComponent();
	}

	public void EnterEditMode()
	{
		if (!IsInEditMode && CanEdit)
		{
			VisualTextBlock.Visibility = Visibility.Collapsed;
			EditTextBox.Visibility = Visibility.Visible;
			IsInEditMode = true;
		}
	}

	public void LeaveEditMode(bool isCancel)
	{
		if (IsInEditMode)
		{
			BindingExpression bindingExpression = EditTextBox.GetBindingExpression(TextBox.TextProperty);
			if (isCancel)
			{
				OnLeaveEditMode();
				bindingExpression.UpdateTarget();
			}
			else if (EditTextBox.Text == Text)
			{
				OnLeaveEditMode();
			}
			else if (bindingExpression.ValidateWithoutUpdate())
			{
				OnLeaveEditMode();
				bindingExpression.UpdateSource();
			}
			else
			{
				bindingExpression.UpdateTarget();
			}
		}
	}

	private void OnLeaveEditMode()
	{
		VisualTextBlock.Visibility = Visibility.Visible;
		EditTextBox.Visibility = Visibility.Collapsed;
		IsInEditMode = false;
	}

	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		if (e.ClickCount == 2 && ClickToEdit)
		{
			EnterEditMode();
		}
	}

	private void TextBox_LostFocus(object? sender, RoutedEventArgs e)
	{
		LeaveEditMode(isCancel: false);
	}

	private void TextBox_KeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6)
		{
			LeaveEditMode(isCancel: false);
			e.Handled = true;
		}
		if ((int)e.Key == 13)
		{
			LeaveEditMode(isCancel: true);
			e.Handled = true;
		}
	}

	private void TextBox_LayoutUpdated(object? sender, EventArgs e)
	{
		if (EditTextBox.Visibility == Visibility.Visible && !EditTextBox.IsFocused)
		{
			SelectAll();
		}
	}

	private void UpdateText()
	{
		VisualTextBlock.Text = ((!string.IsNullOrEmpty(DisplayStringFormat)) ? string.Format(DisplayStringFormat, Text) : Text);
	}

	public void SelectAll()
	{
		if (IsInEditMode)
		{
			EditTextBox.Focus();
			EditTextBox.SelectAll();
		}
	}

	private void EditTextBox_Error(object? sender, ValidationErrorEventArgs e)
	{
		EditTextBox.Focus();
		EditTextBox.CaretIndex = EditTextBox.Text.Length;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
