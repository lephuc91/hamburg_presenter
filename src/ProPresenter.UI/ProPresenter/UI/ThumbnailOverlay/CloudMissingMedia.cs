using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Utility;

namespace ProPresenter.UI.ThumbnailOverlay;

public partial class CloudMissingMedia : UserControl, IComponentConnector
{
	private bool _canExecuteCommand;

	private Vector2<double> _mouseDownPosition;

	public static readonly DependencyProperty RingGridProperty = DependencyProperty.Register("RingGrid", typeof(FrameworkElement), typeof(CloudMissingMedia), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(CloudMissingMedia), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty RingSizeProperty = DependencyProperty.Register("RingSize", typeof(RingSize), typeof(CloudMissingMedia), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)RingSize.Large));

	public static readonly DependencyProperty AllowOpenVideoInputSetupProperty = DependencyProperty.Register("AllowOpenVideoInputSetup", typeof(bool), typeof(CloudMissingMedia), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowTextProperty = DependencyProperty.Register("ShowText", typeof(bool), typeof(CloudMissingMedia), new PropertyMetadata((object)true));

	public FrameworkElement? RingGrid
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(RingGridProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RingGridProperty, (object)value);
		}
	}

	public ICommand? Command
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandProperty, (object)value);
		}
	}

	public RingSize RingSize
	{
		get
		{
			return (RingSize)((DependencyObject)this).GetValue(RingSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RingSizeProperty, (object)value);
		}
	}

	public bool AllowOpenVideoInputSetup
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowOpenVideoInputSetupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowOpenVideoInputSetupProperty, (object)value);
		}
	}

	public bool ShowText
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTextProperty, (object)value);
		}
	}

	public CloudMissingMedia()
	{
		InitializeComponent();
		((DependencyObject)this).SetCurrentValue(RingGridProperty, (object)IconGrid);
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		_canExecuteCommand = Command?.CanExecute(null) ?? false;
		_mouseDownPosition = (Vector2<double>)e.GetPosition(this);
		base.OnPreviewMouseLeftButtonDown(e);
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		if (_canExecuteCommand && e.LeftButton == MouseButtonState.Pressed && e.CanDrag(this, _mouseDownPosition))
		{
			_canExecuteCommand = false;
		}
		base.OnPreviewMouseMove(e);
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		if (_canExecuteCommand && !Keyboard.Modifiers.AnyFlags<ModifierKeys>((ModifierKeys)6))
		{
			Command?.Execute(null);
		}
		_canExecuteCommand = false;
		base.OnPreviewMouseLeftButtonUp(e);
	}

	private void ContentGrid_SizeChanged(object? sender, SizeChangedEventArgs e)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		BackgroundBorder.Clip = new EllipseGeometry
		{
			Center = new Vector2<double>(ContentGrid.ActualWidth / 2.0, ContentGrid.ActualHeight / 2.0),
			RadiusX = ContentGrid.ActualWidth / 2.0,
			RadiusY = ContentGrid.ActualHeight / 2.0
		};
	}

	private void IconGrid_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		((DependencyObject)this).SetCurrentValue(RingGridProperty, (object)IconGrid);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
