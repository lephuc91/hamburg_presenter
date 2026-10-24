using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Win32;
using Pro.UI;
using Pro.UI.Commands;
using Pro.UI.Controls;
using Pro.UI.DependencyInjection;
using Pro.UI.InputActions;
using Pro.UI.Utility;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.SlideQuickEdit;

public partial class QuickEditWindow : ThemedWindow, IComponentConnector
{
	private readonly IInputActions _inputActions;

	private IQuickEditVM? QuickEditVM => base.DataContext as IQuickEditVM;

	public QuickEditWindow()
	{
		InitializeComponent();
		_inputActions = UIServiceProvider.GetService<IInputActions>();
		CommonInputActionGroup commonInputActions = _inputActions.CommonInputActions;
		base.CommandBindings.Add(commonInputActions.Undo.BindCommand, UndoExecuted);
		base.CommandBindings.Add(commonInputActions.Redo.BindCommand, RedoExecuted);
	}

	private void FormattedTextBoxEditHandler(Action<FormattedTextBox> textBoxAction)
	{
		if (ElementCanvas?.Children == null || ElementCanvas.Children.Count <= 0)
		{
			return;
		}
		foreach (FormattedTextBox item in ElementCanvas.Children.AllOfWhere((FormattedTextBox i) => i?.IsKeyboardFocused ?? false))
		{
			textBoxAction(item);
		}
	}

	private void FormattedTextBoxRedo(FormattedTextBox formattedTextBox)
	{
		if (formattedTextBox != null && formattedTextBox.Document?.UndoStack?.CanRedo == true)
		{
			formattedTextBox.Document.UndoStack.Redo();
		}
	}

	private void FormattedTextBoxUndo(FormattedTextBox formattedTextBox)
	{
		if (formattedTextBox != null && formattedTextBox.Document?.UndoStack?.CanUndo == true)
		{
			formattedTextBox.Document.UndoStack.Undo();
		}
	}

	private void RedoExecuted()
	{
		FormattedTextBoxEditHandler(FormattedTextBoxRedo);
	}

	private void UndoExecuted()
	{
		FormattedTextBoxEditHandler(FormattedTextBoxUndo);
	}

	public void UpdateContent(Vector2<double> position, ImageSource? source)
	{
		SetImage(source);
		SetPosition(position);
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.Key == 13)
		{
			if (ElementCanvas.Children.AnyOf((FormattedTextBox t) => t.IsKeyboardFocused))
			{
				RedrawTextControls();
			}
			else
			{
				Hide();
			}
		}
	}

	private void SetPosition(Vector2<double> pos)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		FrameworkElement obj = base.Content as FrameworkElement;
		obj?.Measure(new Vector2<double>(double.PositiveInfinity));
		Vector2<double> scalar;
		Rect<double> monitorPosition = GetMonitorPosition(out scalar);
		Vector2<double> vector = ((Vector2<double>)(obj?.DesiredSize ?? ((Size)Vector2<double>.Zero)) - (QuickEditVM?.RenderSize ?? Vector2<double>.Zero)) / 2.0;
		Vector2<double> vector2 = monitorPosition.Position.ComponentwiseQuotient(scalar);
		pos = (pos - vector).ComponentwiseQuotient(scalar);
		base.Left = Math.Max(vector2.X, pos.X);
		base.Top = Math.Max(vector2.Y, pos.Y);
	}

	private Rect<double> GetMonitorPosition(out Vector2<double> scalar)
	{
		nint hMonitor = WindowsFunctions.MonitorFromWindow(new WindowInteropHelper(this).EnsureHandle(), MONITOR.DEFAULTTOPRIMARY);
		WindowsFunctions.GetDpiForMonitor(hMonitor, MDT.EFFECTIVE_DPI, out var dpiX, out var dpiY);
		scalar = new Vector2<double>(dpiX, dpiY) / 96.0;
		MONITORINFO lpmi = MONITORINFO.Empty;
		WindowsFunctions.GetMonitorInfoW(hMonitor, ref lpmi);
		return (Rect<double>)lpmi.RcWork;
	}

	private void SetImage(ImageSource? source)
	{
		SlideRenderBitmap.Width = QuickEditVM?.TargetContainerSize.X ?? 0.0;
		SlideRenderBitmap.Height = QuickEditVM?.TargetContainerSize.Y ?? 0.0;
		SlideRenderBitmap.Source = source;
		RedrawTextControls();
	}

	private void RedrawTextControls()
	{
		ElementCanvas.Children.Clear();
		QuickEditVM?.TextElements.ForEach(AddTextVisuals);
	}

	private void AddTextVisuals(ClosedBezierPath element)
	{
		AddCanvasChild(GenerateFormattedTextBox(element, QuickEditVM?.ScaleRatio ?? Vector2<double>.One), element.Position.ComponentwiseQuotient(QuickEditVM?.ScaleRatio ?? Vector2<double>.One), element.ZOrder);
	}

	private FormattedTextBox GenerateFormattedTextBox(ClosedBezierPath element, Vector2<double> scalar)
	{
		FormattedTextBox textBox = new FormattedTextBox(element.BacklightSampler)
		{
			Width = element.Size.X,
			Height = element.Size.Y,
			IsEnabled = !element.IsLocked,
			SpellCheckEnable = true,
			Document = element.Text,
			RenderTransform = GetTextTransform(element, scalar)
		};
		textBox.AdjustCaretWidth(scalar.Invert().X);
		textBox.AddTunnelingCommand(_inputActions.ProCommon.BreakTextToNewSlide.BindCommand, delegate
		{
			QuickEditVM?.BreakToNewSlideCommand?.Invoke((element, textBox.CaretIndex));
		});
		return textBox;
	}

	private void AddCanvasChild(UIElement element, Vector2<double> scaledPosition, int zIndex)
	{
		Canvas.SetLeft(element, scaledPosition.X);
		Canvas.SetTop(element, scaledPosition.Y);
		Panel.SetZIndex(element, zIndex);
		ElementCanvas.Children.Add(element);
	}

	private static Transform GetTextTransform(ClosedBezierPath element, Vector2<double> scalar)
	{
		Vector2<double> vector = element.Size.ComponentwiseQuotient(scalar * 2.0);
		Vector2<double> vector2 = scalar.Invert();
		return new TransformGroup
		{
			Children = 
			{
				(Transform)new ScaleTransform(vector2.X, vector2.Y),
				(Transform)new TranslateTransform(vector2.X, vector2.Y),
				(Transform)new RotateTransform(element.Rotation.InvertedCartesianValue, vector.X, vector.Y)
			}
		};
	}
}
