using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Primitives;

namespace Pro.UI.Controls.Primitives;

[TemplatePart(Name = "PART_Editor", Type = typeof(TextBox))]
[TemplatePart(Name = "PART_ValuePopup", Type = typeof(AnchoredPopup))]
public class UnitsThumb : Thumb
{
	private const string EditorPart = "PART_Editor";

	private const string PopupPart = "PART_ValuePopup";

	private readonly DispatcherTimer _debouncer;

	private DoubleUpDown? _editor;

	private bool _isEditorSelected;

	private AnchoredPopup? _popup;

	private bool _suppressLostFocus;

	public static readonly DependencyProperty UnitsProperty = DependencyProperty.Register("Units", typeof(string), typeof(UnitsThumb));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(UnitsThumb));

	public static readonly DependencyProperty CanShowPopupProperty = DependencyProperty.Register("CanShowPopup", typeof(bool), typeof(UnitsThumb), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public string Units
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(UnitsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnitsProperty, (object)value);
		}
	}

	public object Value
	{
		get
		{
			return ((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, value);
		}
	}

	public bool CanShowPopup
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanShowPopupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanShowPopupProperty, (object)value);
		}
	}

	public UnitsThumb()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		_debouncer = new DispatcherTimer((DispatcherPriority)5, ((DispatcherObject)Application.Current).Dispatcher)
		{
			Interval = TimeSpan.FromMilliseconds(800L, 0L)
		};
		base.Loaded += delegate
		{
			_debouncer.Tick += DebouncerOnElapsed;
			base.DragDelta += OnDragDelta;
			if (_editor != null)
			{
				_editor.KeyUp -= EditorOnKeyUp;
				_editor.SourceUpdated -= EditorOnSourceUpdated;
				_editor.KeyUp += EditorOnKeyUp;
				_editor.SourceUpdated += EditorOnSourceUpdated;
				_editor.GotKeyboardFocus -= EditorOnGotKeyboardFocus;
				_editor.GotKeyboardFocus += EditorOnGotKeyboardFocus;
				_editor.LostKeyboardFocus -= EditorOnLostKeyboardFocus;
				_editor.LostKeyboardFocus += EditorOnLostKeyboardFocus;
			}
		};
		base.Unloaded += delegate
		{
			_debouncer.Tick -= DebouncerOnElapsed;
			base.DragDelta -= OnDragDelta;
			if (_editor != null)
			{
				_editor.KeyUp -= EditorOnKeyUp;
				_editor.SourceUpdated -= EditorOnSourceUpdated;
				_editor.GotKeyboardFocus -= EditorOnGotKeyboardFocus;
				_editor.LostKeyboardFocus -= EditorOnLostKeyboardFocus;
			}
		};
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_editor = GetTemplateChild("PART_Editor") as DoubleUpDown;
		_popup = GetTemplateChild("PART_ValuePopup") as AnchoredPopup;
		if (_editor != null)
		{
			_editor.KeyUp += EditorOnKeyUp;
			_editor.SourceUpdated += EditorOnSourceUpdated;
			_editor.GotKeyboardFocus += EditorOnGotKeyboardFocus;
			_editor.LostKeyboardFocus += EditorOnLostKeyboardFocus;
		}
		if (_popup != null)
		{
			_popup.PlacementTarget = this;
		}
	}

	protected override void OnLostFocus(RoutedEventArgs e)
	{
		base.OnLostFocus(e);
		Update();
	}

	protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
	{
		base.OnMouseDoubleClick(e);
		_debouncer.Stop();
		_suppressLostFocus = true;
		_editor?.Focus();
		_suppressLostFocus = false;
		_isEditorSelected = true;
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		base.OnMouseDown(e);
		_debouncer.Start();
		if (CanShowPopup)
		{
			ShowPopup();
		}
	}

	protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
	{
		base.OnPreviewMouseUp(e);
		if (!_isEditorSelected)
		{
			_debouncer.Stop();
			_debouncer.Start();
		}
	}

	public void ShowPopup()
	{
		if (_popup != null)
		{
			_popup.IsOpen = true;
		}
	}

	private void ClosePopup()
	{
		_debouncer.Stop();
		Keyboard.ClearFocus();
		if (_popup != null)
		{
			_popup.IsOpen = false;
		}
		_isEditorSelected = false;
		_suppressLostFocus = false;
	}

	private void DebouncerOnElapsed(object? sender, EventArgs e)
	{
		_debouncer.Stop();
		Update();
	}

	private void EditorOnGotKeyboardFocus(object? sender, KeyboardFocusChangedEventArgs e)
	{
		_debouncer.Stop();
		_isEditorSelected = true;
	}

	private void EditorOnKeyUp(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6)
		{
			_isEditorSelected = false;
			Update();
		}
	}

	private void EditorOnLostKeyboardFocus(object? sender, KeyboardFocusChangedEventArgs e)
	{
		if (!_suppressLostFocus)
		{
			Update();
		}
	}

	private void EditorOnSourceUpdated(object? sender, DataTransferEventArgs e)
	{
		if (!base.IsDragging)
		{
			ClosePopup();
		}
	}

	private void OnDragDelta(object? sender, DragDeltaEventArgs e)
	{
		_isEditorSelected = false;
		_debouncer.Start();
		_debouncer.Stop();
	}

	private void Update()
	{
		if (_editor != null)
		{
			BindingOperations.GetBindingExpression((DependencyObject)(object)_editor, UpDownBase<double?>.ValueProperty)?.UpdateSource();
			FocusManager.SetFocusedElement((DependencyObject)(object)this, null);
			Keyboard.ClearFocus();
			ClosePopup();
		}
	}
}
