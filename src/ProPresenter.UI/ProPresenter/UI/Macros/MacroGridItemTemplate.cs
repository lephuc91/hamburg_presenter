using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using Pro.Common.Time;
using ProPresenter.DO;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels.Macros;

namespace ProPresenter.UI.Macros;

public partial class MacroGridItemTemplate : UserControl, IUniformViewControl, IComponentConnector
{
	public delegate void MacroEventDelegate(MacroGridItemTemplate thumbnail, ModifierKeys modifierKeys);

	private readonly DoubleAnimation _triggerAnimation;

	public static readonly DependencyProperty IsTriggeringProperty = DependencyProperty.Register("IsTriggering", typeof(bool), typeof(MacroGridItemTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsTriggeringChanged)));

	public bool IsTriggering
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsTriggeringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsTriggeringProperty, (object)value);
		}
	}

	public int Index { get; set; }

	public IUniformViewSource? Source
	{
		get
		{
			return base.DataContext as IUniformViewSource;
		}
		set
		{
			base.DataContext = value;
		}
	}

	public bool IsSelected { get; set; }

	public IPanelViewSettings? ViewSettings { get; set; }

	public MacroEventDelegate? ClickedDelegate { get; set; }

	private static void OnIsTriggeringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as MacroGridItemTemplate)?.IsTriggerChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public MacroGridItemTemplate()
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		InitializeComponent();
		_triggerAnimation = new DoubleAnimation
		{
			From = 0.0,
			To = 1.0,
			BeginTime = TimeSlice.FromMilliseconds(0.0),
			Duration = new Duration(TimeSlice.FromMilliseconds(400.0)),
			AutoReverse = true
		};
		_triggerAnimation.Completed += TriggerAnimation_Completed;
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(MacroGridItemTemplate_DataContextChanged);
	}

	private void MacroGridItemTemplate_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (base.DataContext is IMacroItemVM source)
		{
			SetBinding(IsTriggeringProperty, new Binding("IsTriggering")
			{
				Source = source
			});
		}
	}

	private void TriggerAnimation_Completed(object? sender, EventArgs e)
	{
		if (IsTriggering)
		{
			triggerBorder.BeginAnimation(UIElement.OpacityProperty, _triggerAnimation);
		}
	}

	private void IsTriggerChanged(bool newValue)
	{
		if (newValue)
		{
			triggerBorder.BeginAnimation(UIElement.OpacityProperty, _triggerAnimation);
		}
	}

	protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (e.ChangedButton == MouseButton.Left)
		{
			ClickedDelegate?.Invoke(this, Keyboard.Modifiers);
		}
	}

	public void TearDown()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
