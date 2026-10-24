using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Collections;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class ColorPropertiesControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ColorAdjustmentOptionsProperty = DependencyProperty.Register("ColorAdjustmentOptions", typeof(ColorAdjustmentOptions), typeof(ColorPropertiesControl));

	public static readonly DependencyProperty HardwareRectangleProperty = DependencyProperty.Register("HardwareRectangle", typeof(HardwareScreenRectangleOptions), typeof(ColorPropertiesControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ColorPropertiesControl colorPropertiesControl)
		{
			colorPropertiesControl.OnHardwareRectangleChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as HardwareScreenRectangleOptions, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as HardwareScreenRectangleOptions);
		}
	}));

	private static readonly DependencyProperty CanSetHdrMaxNitsOffsetProperty = DependencyProperty.Register("CanSetHdrMaxNitsOffset", typeof(bool), typeof(ColorPropertiesControl));

	public ColorAdjustmentOptions? ColorAdjustmentOptions
	{
		get
		{
			return (ColorAdjustmentOptions)((DependencyObject)this).GetValue(ColorAdjustmentOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ColorAdjustmentOptionsProperty, (object)value);
		}
	}

	public HardwareScreenRectangleOptions? HardwareRectangle
	{
		get
		{
			return (HardwareScreenRectangleOptions)((DependencyObject)this).GetValue(HardwareRectangleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HardwareRectangleProperty, (object)value);
		}
	}

	private bool CanSetHdrMaxNitsOffset
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanSetHdrMaxNitsOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanSetHdrMaxNitsOffsetProperty, (object)value);
		}
	}

	public ColorPropertiesControl()
	{
		InitializeComponent();
		NotifyCanSetHdrMaxNitsOffset();
	}

	private void OnHardwareRectangleChanged(HardwareScreenRectangleOptions? oldValue, HardwareScreenRectangleOptions? newValue)
	{
		if (oldValue != null)
		{
			oldValue.OutputDeviceChanged -= HardwareScreenRectangleOptions_OutputDeviceChanged;
		}
		if (newValue != null)
		{
			newValue.OutputDeviceChanged += HardwareScreenRectangleOptions_OutputDeviceChanged;
			if (newValue.OutputDevice != null)
			{
				newValue.OutputDevice.PropertyChanged += Device_PropertyChanged;
			}
		}
		NotifyCanSetHdrMaxNitsOffset();
	}

	private void HardwareScreenRectangleOptions_OutputDeviceChanged(IDevice? oldValue, IDevice? newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= Device_PropertyChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += Device_PropertyChanged;
		}
		NotifyCanSetHdrMaxNitsOffset();
	}

	private void Device_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "SupportsHdrRendering" || e.PropertyName == "SelectedHdrFormat")
		{
			NotifyCanSetHdrMaxNitsOffset();
		}
	}

	private void NotifyCanSetHdrMaxNitsOffset()
	{
		bool flag = HardwareRectangle?.OutputDevice != null && HardwareRectangle.OutputDevice.SupportsHdrRendering && HardwareRectangle.OutputDevice.SelectedHdrFormat.IsAnyOf(HdrFormats.Rec2100HLG, HdrFormats.Rec2100PQ);
		((DependencyObject)this).SetCurrentValue(CanSetHdrMaxNitsOffsetProperty, (object)flag);
	}
}
