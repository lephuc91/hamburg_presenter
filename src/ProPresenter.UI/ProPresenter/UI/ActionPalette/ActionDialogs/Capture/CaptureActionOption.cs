using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Triggering;
using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Actions.Capture;
using ProPresenter.DO.Capture;

namespace ProPresenter.UI.ActionPalette.ActionDialogs.Capture;

public partial class CaptureActionOption : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ActionProperty;

	public static readonly DependencyProperty SelectPresetCommandProperty;

	public static readonly DependencyProperty PresetsProperty;

	private static readonly DependencyProperty CaptureActionProperty;

	private static readonly DependencyProperty CaptureStartProperty;

	private static readonly DependencyProperty CaptureStopProperty;

	public ActionBase? Action
	{
		get
		{
			return (ActionBase)((DependencyObject)this).GetValue(ActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActionProperty, (object)value);
		}
	}

	public ICommand<CapturePreset>? SelectPresetCommand
	{
		get
		{
			return (ICommand<CapturePreset>)((DependencyObject)this).GetValue(SelectPresetCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectPresetCommandProperty, (object)value);
		}
	}

	public ICapturePresetCollection? Presets
	{
		get
		{
			return (ICapturePresetCollection)((DependencyObject)this).GetValue(PresetsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PresetsProperty, (object)value);
		}
	}

	private CaptureAction? CaptureAction
	{
		get
		{
			return (CaptureAction)((DependencyObject)this).GetValue(CaptureActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptureActionProperty, (object)value);
		}
	}

	private CaptureStart? CaptureStart
	{
		get
		{
			return (CaptureStart)((DependencyObject)this).GetValue(CaptureStartProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptureStartProperty, (object)value);
		}
	}

	private CaptureStop? CaptureStop
	{
		get
		{
			return (CaptureStop)((DependencyObject)this).GetValue(CaptureStopProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptureStopProperty, (object)value);
		}
	}

	public CaptureActionOption()
	{
		InitializeComponent();
	}

	static CaptureActionOption()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		Type? typeFromHandle = typeof(ActionBase);
		Type? typeFromHandle2 = typeof(CaptureActionOption);
		FrameworkPropertyMetadata frameworkPropertyMetadata = new FrameworkPropertyMetadata();
		((PropertyMetadata)frameworkPropertyMetadata).PropertyChangedCallback = (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is CaptureActionOption captureActionOption)
			{
				CaptureAction captureAction = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as CaptureAction;
				((DependencyObject)captureActionOption).SetCurrentValue(CaptureActionProperty, (object)captureAction);
				((DependencyObject)captureActionOption).SetCurrentValue(CaptureStartProperty, (object)(captureAction?.Capture as CaptureStart));
				((DependencyObject)captureActionOption).SetCurrentValue(CaptureStopProperty, (object)(captureAction?.Capture as CaptureStop));
			}
		};
		ActionProperty = DependencyProperty.Register("Action", typeFromHandle, typeFromHandle2, (PropertyMetadata)(object)frameworkPropertyMetadata);
		SelectPresetCommandProperty = DependencyProperty.Register("SelectPresetCommand", typeof(ICommand<CapturePreset>), typeof(CaptureActionOption));
		PresetsProperty = DependencyProperty.Register("Presets", typeof(ICapturePresetCollection), typeof(CaptureActionOption));
		CaptureActionProperty = DependencyProperty.Register("CaptureAction", typeof(CaptureAction), typeof(CaptureActionOption));
		CaptureStartProperty = DependencyProperty.Register("CaptureStart", typeof(CaptureStart), typeof(CaptureActionOption));
		CaptureStopProperty = DependencyProperty.Register("CaptureStop", typeof(CaptureStop), typeof(CaptureActionOption));
	}
}
