using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using Pro.Text;
using Pro.UI.Commands;
using Pro.UI.Controls;
using Pro.UI.DependencyInjection;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.InputActionMap;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.ReflowEditor;

public partial class ReflowText : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SlideProperty = DependencyProperty.Register("Slide", typeof(ArrangedCue), typeof(ReflowText), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ReflowText)(object)s).VM.Slide = (ArrangedCue)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}));

	public static readonly DependencyProperty ZoomLevelProperty = FormattedTextBox.ZoomLevelProperty.AddOwner(typeof(ReflowText));

	public static readonly DependencyProperty SlideTextContextMenuProperty = DependencyProperty.Register("SlideTextContextMenu", typeof(ContextMenu), typeof(ReflowText));

	public static readonly DependencyProperty IgnoreMarginsProperty = DependencyProperty.Register("IgnoreMargins", typeof(bool), typeof(ReflowText));

	public ArrangedCue? Slide
	{
		get
		{
			return (ArrangedCue)((DependencyObject)this).GetValue(SlideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SlideProperty, (object)value);
		}
	}

	public double ZoomLevel
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ZoomLevelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomLevelProperty, (object)value);
		}
	}

	public ContextMenu SlideTextContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(SlideTextContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SlideTextContextMenuProperty, (object)value);
		}
	}

	public bool IgnoreMargins
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IgnoreMarginsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IgnoreMarginsProperty, (object)value);
		}
	}

	public ReflowTextVM VM { get; }

	public event Action? BackSpaceMerge;

	public event Action<ReflowText>? Select;

	public event Action<Vector2<double>, FormattedTextBox.CaretLocation>? CaretPositionChanged;

	public ReflowText()
	{
		IInputActions service = UIServiceProvider.GetService<IInputActions>();
		VM = new ReflowTextVM(UIServiceProvider.GetService<IProPresenterDOFactoryProvider>());
		InitializeComponent();
		ReflowMenuGroup reflowMenu = service.ReflowMenu;
		base.CommandBindings.Add(reflowMenu.Bold.BindCommand, VM.BoldCommand);
		base.CommandBindings.Add(reflowMenu.Italic.BindCommand, VM.ItalicCommand);
		base.CommandBindings.Add(reflowMenu.Underline.BindCommand, VM.UnderlineCommand);
		base.CommandBindings.Add(reflowMenu.StrikeThrough.BindCommand, VM.StrikethroughCommand);
		base.CommandBindings.Add(reflowMenu.Bigger.BindCommand, VM.IncreaseFontSizeCommand);
		base.CommandBindings.Add(reflowMenu.Smaller.BindCommand, VM.DecreaseFontSizeCommand);
	}

	public void HandleNewCaretPosition(Vector2<double> position, FormattedTextBox.CaretLocation location)
	{
		switch (location)
		{
		case FormattedTextBox.CaretLocation.Beginning:
			FormattedTextBox.SetCaretEnd();
			break;
		case FormattedTextBox.CaretLocation.End:
			FormattedTextBox.SetCaretBeginning();
			break;
		case FormattedTextBox.CaretLocation.Top:
			FormattedTextBox.SetCaretFromBottom(position);
			break;
		case FormattedTextBox.CaretLocation.Bottom:
			FormattedTextBox.SetCaretFromTop(position);
			break;
		}
		FormattedTextBox.Focus();
	}

	private void UIElement_OnPreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		this.Select?.Invoke(this);
	}

	private void FormattedTextBox_PreviewKeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Invalid comparison between Unknown and I4
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Invalid comparison between Unknown and I4
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Invalid comparison between Unknown and I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Invalid comparison between Unknown and I4
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Invalid comparison between Unknown and I4
		if ((int)e.Key == 2 && !FormattedTextBox.SelectionRanges.ContainsSelection() && FormattedTextBox.CaretIndex == 0)
		{
			e.Handled = true;
			this.BackSpaceMerge?.Invoke();
		}
		if (((int)e.Key == 24 || (int)e.Key == 26 || (int)e.Key == 23 || (int)e.Key == 25) && base.DataContext is ArrangedCue arrangedCue && arrangedCue.Source.SlideAction != null && arrangedCue.Source.SlideAction.Slide.Text == null)
		{
			e.Handled = true;
			this.CaretPositionChanged?.Invoke(Vector2<double>.Zero, ((int)e.Key != 26 && (int)e.Key != 25) ? FormattedTextBox.CaretLocation.Beginning : FormattedTextBox.CaretLocation.End);
		}
	}

	private void OnCaretPositionChanged(Vector2<double> position, FormattedTextBox.CaretLocation location, double height)
	{
		if (location != 0)
		{
			this.CaretPositionChanged?.Invoke(position, location);
		}
	}

	private void FormattedTextBox_LostFocus(object? sender, RoutedEventArgs e)
	{
		FormattedTextBox.DeselectAll();
	}
}
