using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.UI.Commands;
using Pro.UI.Theming;

namespace Pro.UI.Utility;

public static class UIElementHelper
{
	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static KeyboardFocusChangedEventHandler _003C0_003E__Element_LostFocus;

		public static DependencyPropertyChangedEventHandler _003C1_003E__Element_IsVisibleChanged;

		public static SizeChangedEventHandler _003C2_003E__FrameworkElement_SizeChanged;
	}

	private const string DisableUndoInputBindings = "DisableUndoInputBindings";

	private const string FocusedElement = "FocusedElement";

	private const string KeepFocus = "KeepFocus";

	private const string RegisterCutCommand = "RegisterCutCommand";

	private const string RegisterCopyCommand = "RegisterCopyCommand";

	private const string RegisterPasteCommand = "RegisterPasteCommand";

	private const string RegisterDuplicateCommand = "RegisterDuplicateCommand";

	private const string RegisterDeleteCommand = "RegisterDeleteCommand";

	private const string Palette = "Palette";

	private const string CornerRadius = "CornerRadius";

	private const string FocusOnVisible = "FocusOnVisible";

	private const string RegisterChangeOutputDestinationCommand = "RegisterChangeOutputDestinationCommand";

	private const string HideWhenHeightLessThan = "HideWhenHeightLessThan";

	public static readonly DependencyProperty DisableUndoInputBindingsProperty = DependencyProperty.RegisterAttached("DisableUndoInputBindings", typeof(bool), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(DisableUndoInputBindingsChanged)));

	public static readonly DependencyProperty FocusedElementProperty = DependencyProperty.RegisterAttached("FocusedElement", typeof(UIElement), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(FocusedElementChanged)));

	public static readonly DependencyProperty KeepFocusProperty = DependencyProperty.RegisterAttached("KeepFocus", typeof(bool), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(KeepFocusChanged)));

	public static readonly DependencyProperty RegisterCutCommandProperty = DependencyProperty.RegisterAttached("RegisterCutCommand", typeof(ICommand), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RegisterCutCommandChanged)));

	public static readonly DependencyProperty RegisterCopyCommandProperty = DependencyProperty.RegisterAttached("RegisterCopyCommand", typeof(ICommand), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RegisterCopyCommandChanged)));

	public static readonly DependencyProperty RegisterPasteCommandProperty = DependencyProperty.RegisterAttached("RegisterPasteCommand", typeof(ICommand), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RegisterPasteCommandChanged)));

	public static readonly DependencyProperty RegisterDuplicateCommandProperty = DependencyProperty.RegisterAttached("RegisterDuplicateCommand", typeof(ICommand), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RegisterDuplicateCommandChanged)));

	public static readonly DependencyProperty RegisterDeleteCommandProperty = DependencyProperty.RegisterAttached("RegisterDeleteCommand", typeof(ICommand), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RegisterDeleteCommandChanged)));

	public static readonly DependencyProperty PaletteProperty = DependencyProperty.RegisterAttached("Palette", typeof(StatePalette), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.Inherits));

	public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)default(CornerRadius), FrameworkPropertyMetadataOptions.Inherits));

	public static readonly DependencyProperty FocusOnVisibleProperty = DependencyProperty.RegisterAttached("FocusOnVisible", typeof(bool), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(FocusOnVisibleChanged)));

	public static readonly DependencyProperty ChangeOutputDestinationProperty = DependencyProperty.RegisterAttached("RegisterChangeOutputDestinationCommand", typeof(ICommand), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(RegisterChangeOutputDestinationCommandChanged)));

	public static readonly DependencyProperty HideWhenHeightLessThanProperty = DependencyProperty.RegisterAttached("HideWhenHeightLessThan", typeof(double), typeof(UIElementHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(HideWhenHeightLessThanPropertyChanged)));

	private static void DisableUndoInputBindingsChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnDisableUndoInputBindingsChanged((UIElement)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void FocusedElementChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnFocusedElementChanged((FrameworkElement)(object)callerObject, (UIElement)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void KeepFocusChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnKeepFocusChanged((UIElement)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void RegisterCopyCommandChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnRegisterCopyCommandChanged((UIElement)(object)callerObject, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void RegisterCutCommandChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnRegisterCutCommandChanged((UIElement)(object)callerObject, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void RegisterPasteCommandChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnRegisterPasteCommandChanged((UIElement)(object)callerObject, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void RegisterDuplicateCommandChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnRegisterDuplicateCommandChanged((UIElement)(object)callerObject, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void RegisterDeleteCommandChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnRegisterDeleteCommandChanged((UIElement)(object)callerObject, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void FocusOnVisibleChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnFocusOnVisibleChanged((UIElement)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void RegisterChangeOutputDestinationCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		OnRegisterChangeOutputDestinationCommandChanged((UIElement)(object)d, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void HideWhenHeightLessThanPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		HideWhenHeightLessThanChanged((FrameworkElement)(object)callerObject);
	}

	public static bool GetDisableUndoInputBindings(UIElement element)
	{
		return (bool)((DependencyObject)element).GetValue(DisableUndoInputBindingsProperty);
	}

	public static void SetDisableUndoInputBindings(UIElement element, bool value)
	{
		((DependencyObject)element).SetValue(DisableUndoInputBindingsProperty, (object)value);
	}

	private static void OnDisableUndoInputBindingsChanged(UIElement element, bool disableUndoInputBindings)
	{
		if (disableUndoInputBindings)
		{
			element.InputBindings.Add(new InputBinding(ApplicationCommands.NotACommand, new KeyGesture((Key)69, (ModifierKeys)2)));
			element.InputBindings.Add(new InputBinding(ApplicationCommands.NotACommand, new KeyGesture((Key)68, (ModifierKeys)2)));
		}
		else
		{
			(from InputBinding i in element.InputBindings
				where i.Command == ApplicationCommands.NotACommand
				select i).ToArray().ForEach(element.InputBindings.Remove);
		}
	}

	public static UIElement GetFocusedElement(UIElement element)
	{
		return (UIElement)((DependencyObject)element).GetValue(FocusedElementProperty);
	}

	public static void SetFocusedElement(UIElement element, UIElement value)
	{
		((DependencyObject)element).SetValue(FocusedElementProperty, (object)value);
	}

	private static void OnFocusedElementChanged(FrameworkElement caller, UIElement newValue)
	{
		if (newValue == null)
		{
			return;
		}
		caller.Loaded += delegate
		{
			((DispatcherObject)caller).Dispatcher.InvokeAsync<IInputElement>((Func<IInputElement>)(() => Keyboard.Focus(newValue)));
		};
	}

	public static UIElement GetKeepFocus(UIElement element)
	{
		return (UIElement)((DependencyObject)element).GetValue(KeepFocusProperty);
	}

	public static void SetKeepFocus(UIElement element, UIElement value)
	{
		((DependencyObject)element).SetValue(KeepFocusProperty, (object)value);
	}

	private static void OnKeepFocusChanged(UIElement element, bool newValue)
	{
		if (newValue)
		{
			element.PreviewLostKeyboardFocus += Element_LostFocus;
		}
		else
		{
			element.PreviewLostKeyboardFocus -= Element_LostFocus;
		}
	}

	private static void Element_LostFocus(object? sender, RoutedEventArgs e)
	{
		if (sender is UIElement { IsFocused: false } uIElement)
		{
			uIElement.Focus();
		}
		e.Handled = true;
	}

	public static UIElement GetFocusOnVisible(UIElement element)
	{
		return (UIElement)((DependencyObject)element).GetValue(FocusOnVisibleProperty);
	}

	public static void SetFocusOnVisible(UIElement element, UIElement value)
	{
		((DependencyObject)element).SetValue(FocusOnVisibleProperty, (object)value);
	}

	private static void OnFocusOnVisibleChanged(UIElement element, bool newValue)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		if (newValue)
		{
			object obj = _003C_003EO._003C1_003E__Element_IsVisibleChanged;
			if (obj == null)
			{
				DependencyPropertyChangedEventHandler val = Element_IsVisibleChanged;
				_003C_003EO._003C1_003E__Element_IsVisibleChanged = val;
				obj = (object)val;
			}
			element.IsVisibleChanged += (DependencyPropertyChangedEventHandler)obj;
		}
		else
		{
			object obj2 = _003C_003EO._003C1_003E__Element_IsVisibleChanged;
			if (obj2 == null)
			{
				DependencyPropertyChangedEventHandler val2 = Element_IsVisibleChanged;
				_003C_003EO._003C1_003E__Element_IsVisibleChanged = val2;
				obj2 = (object)val2;
			}
			element.IsVisibleChanged -= (DependencyPropertyChangedEventHandler)obj2;
		}
	}

	private static void Element_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (sender is TextBoxBase textBoxBase && (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			Keyboard.Focus(textBoxBase);
			textBoxBase.SelectAll();
		}
	}

	private static void HideWhenHeightLessThanChanged(FrameworkElement callerObject)
	{
		callerObject.SizeChanged += FrameworkElement_SizeChanged;
	}

	private static void FrameworkElement_SizeChanged(object? sender, SizeChangedEventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if (sender is FrameworkElement frameworkElement)
		{
			Size newSize = e.NewSize;
			frameworkElement.Visibility = ((((Size)(ref newSize)).Height < GetHideWhenHeightLessThan(frameworkElement)) ? Visibility.Hidden : Visibility.Visible);
		}
	}

	public static ICommand GetRegisterCutCommand(UIElement element)
	{
		return (ICommand)((DependencyObject)element).GetValue(RegisterCutCommandProperty);
	}

	public static void SetRegisterCutCommand(UIElement element, ICommand value)
	{
		((DependencyObject)element).SetValue(RegisterCutCommandProperty, (object)value);
	}

	private static void OnRegisterCutCommandChanged(UIElement caller, ICommand newValue)
	{
		caller.CommandBindings.Add(CommonApplicationCommands.CutCommand, newValue);
	}

	public static ICommand GetRegisterCopyCommand(UIElement element)
	{
		return (ICommand)((DependencyObject)element).GetValue(RegisterCopyCommandProperty);
	}

	public static void SetRegisterCopyCommand(UIElement element, ICommand value)
	{
		((DependencyObject)element).SetValue(RegisterCopyCommandProperty, (object)value);
	}

	private static void OnRegisterCopyCommandChanged(UIElement caller, ICommand newValue)
	{
		caller.CommandBindings.Add(CommonApplicationCommands.Copy, newValue);
	}

	public static ICommand GetRegisterPasteCommand(UIElement element)
	{
		return (ICommand)((DependencyObject)element).GetValue(RegisterPasteCommandProperty);
	}

	public static void SetRegisterPasteCommand(UIElement element, ICommand value)
	{
		((DependencyObject)element).SetValue(RegisterPasteCommandProperty, (object)value);
	}

	private static void OnRegisterPasteCommandChanged(UIElement caller, ICommand newValue)
	{
		caller.CommandBindings.Add(CommonApplicationCommands.Paste, newValue);
	}

	public static ICommand GetRegisterDuplicateCommand(UIElement element)
	{
		return (ICommand)((DependencyObject)element).GetValue(RegisterDuplicateCommandProperty);
	}

	public static void SetRegisterDuplicateCommand(UIElement element, ICommand value)
	{
		((DependencyObject)element).SetValue(RegisterDuplicateCommandProperty, (object)value);
	}

	private static void OnRegisterDuplicateCommandChanged(UIElement caller, ICommand newValue)
	{
		caller.CommandBindings.Add(CommonApplicationCommands.Duplicate, newValue);
	}

	public static ICommand GetRegisterDeleteCommand(UIElement element)
	{
		return (ICommand)((DependencyObject)element).GetValue(RegisterDeleteCommandProperty);
	}

	public static void SetRegisterDeleteCommand(UIElement element, ICommand value)
	{
		((DependencyObject)element).SetValue(RegisterDeleteCommandProperty, (object)value);
	}

	private static void OnRegisterDeleteCommandChanged(UIElement caller, ICommand newValue)
	{
		caller.CommandBindings.Add(CommonApplicationCommands.Delete, newValue);
	}

	private static void OnRegisterChangeOutputDestinationCommandChanged(UIElement e, ICommand c)
	{
		e.CommandBindings.Add(CommonApplicationCommands.ChangeOutputDestination, c);
	}

	public static StatePalette GetPalette(UIElement element)
	{
		return (StatePalette)((DependencyObject)element).GetValue(PaletteProperty);
	}

	public static void SetPalette(UIElement element, StatePalette value)
	{
		((DependencyObject)element).SetValue(PaletteProperty, (object)value);
	}

	public static CornerRadius GetCornerRadius(UIElement element)
	{
		return (CornerRadius)((DependencyObject)element).GetValue(CornerRadiusProperty);
	}

	public static void SetCornerRadius(UIElement element, CornerRadius value)
	{
		((DependencyObject)element).SetValue(CornerRadiusProperty, (object)value);
	}

	public static ICommand GetRegisterChangeOutputDestinationCommand(UIElement element)
	{
		return (ICommand)((DependencyObject)element).GetValue(ChangeOutputDestinationProperty);
	}

	public static void SetRegisterChangeOutputDestinationCommand(UIElement element, ICommand value)
	{
		((DependencyObject)element).SetValue(ChangeOutputDestinationProperty, (object)value);
	}

	public static double GetHideWhenHeightLessThan(UIElement element)
	{
		return (double)((DependencyObject)element).GetValue(HideWhenHeightLessThanProperty);
	}

	public static void SetHideWhenHeightLessThan(UIElement element, double value)
	{
		((DependencyObject)element).SetValue(HideWhenHeightLessThanProperty, (object)value);
	}
}
