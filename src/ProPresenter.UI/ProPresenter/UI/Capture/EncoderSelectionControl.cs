using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Capture;

namespace ProPresenter.UI.Capture;

public partial class EncoderSelectionControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty DestinationProperty;

	public static readonly DependencyProperty SelectedEncoderProperty;

	public static readonly DependencyProperty SelectEncoderCommandProperty;

	public static readonly DependencyProperty SelectCustomEncoderCommandProperty;

	private static readonly DependencyProperty DefaultEncodersProperty;

	private static readonly DependencyProperty IsCustomEncoderProperty;

	public DestinationType Destination
	{
		get
		{
			return (DestinationType)((DependencyObject)this).GetValue(DestinationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DestinationProperty, (object)value);
		}
	}

	public Encoder? SelectedEncoder
	{
		get
		{
			return (Encoder)((DependencyObject)this).GetValue(SelectedEncoderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedEncoderProperty, (object)value);
		}
	}

	public ICommand<Encoder>? SelectEncoderCommand
	{
		get
		{
			return (ICommand<Encoder>)((DependencyObject)this).GetValue(SelectEncoderCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectEncoderCommandProperty, (object)value);
		}
	}

	public ICommand? SelectCustomEncoderCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(SelectCustomEncoderCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectCustomEncoderCommandProperty, (object)value);
		}
	}

	private IEnumerable<Encoder> DefaultEncoders
	{
		get
		{
			return (IEnumerable<Encoder>)((DependencyObject)this).GetValue(DefaultEncodersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultEncodersProperty, (object)value);
		}
	}

	private bool IsCustomEncoder
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsCustomEncoderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsCustomEncoderProperty, (object)value);
		}
	}

	public EncoderSelectionControl()
	{
		InitializeComponent();
		SetDefaultEncoders();
	}

	private void SetDefaultEncoders()
	{
		Encoder[] array = Destination switch
		{
			DestinationType.Disk => Encoder.DiskDefaults, 
			DestinationType.RTMP => Encoder.RtmpDefaults, 
			_ => null, 
		};
		((DependencyObject)this).SetCurrentValue(DefaultEncodersProperty, (object)array);
	}

	static EncoderSelectionControl()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		Type? typeFromHandle = typeof(DestinationType);
		Type? typeFromHandle2 = typeof(EncoderSelectionControl);
		FrameworkPropertyMetadata frameworkPropertyMetadata = new FrameworkPropertyMetadata((object)DestinationType.Disk);
		((PropertyMetadata)frameworkPropertyMetadata).PropertyChangedCallback = (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is EncoderSelectionControl encoderSelectionControl)
			{
				encoderSelectionControl.SetDefaultEncoders();
			}
		};
		DestinationProperty = DependencyProperty.Register("Destination", typeFromHandle, typeFromHandle2, (PropertyMetadata)(object)frameworkPropertyMetadata);
		Type? typeFromHandle3 = typeof(Encoder);
		Type? typeFromHandle4 = typeof(EncoderSelectionControl);
		FrameworkPropertyMetadata frameworkPropertyMetadata2 = new FrameworkPropertyMetadata();
		((PropertyMetadata)frameworkPropertyMetadata2).PropertyChangedCallback = (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is EncoderSelectionControl encoderSelectionControl2)
			{
				DependencyProperty isCustomEncoderProperty = IsCustomEncoderProperty;
				int num;
				if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is Encoder value2)
				{
					IEnumerable<Encoder> defaultEncoders = encoderSelectionControl2.DefaultEncoders;
					num = ((defaultEncoders != null && !defaultEncoders.Contains(value2)) ? 1 : 0);
				}
				else
				{
					num = 0;
				}
				((DependencyObject)encoderSelectionControl2).SetCurrentValue(isCustomEncoderProperty, (object)((byte)num != 0));
			}
		};
		SelectedEncoderProperty = DependencyProperty.Register("SelectedEncoder", typeFromHandle3, typeFromHandle4, (PropertyMetadata)(object)frameworkPropertyMetadata2);
		SelectEncoderCommandProperty = DependencyProperty.Register("SelectEncoderCommand", typeof(ICommand<Encoder>), typeof(EncoderSelectionControl));
		SelectCustomEncoderCommandProperty = DependencyProperty.Register("SelectCustomEncoderCommand", typeof(ICommand), typeof(EncoderSelectionControl));
		Type? typeFromHandle5 = typeof(IEnumerable<Encoder>);
		Type? typeFromHandle6 = typeof(EncoderSelectionControl);
		FrameworkPropertyMetadata frameworkPropertyMetadata3 = new FrameworkPropertyMetadata((object)Encoder.DiskDefaults);
		((PropertyMetadata)frameworkPropertyMetadata3).CoerceValueCallback = (CoerceValueCallback)((DependencyObject d, object value) => (!(value is IEnumerable<Encoder> enumerable)) ? Encoder.DiskDefaults : enumerable);
		DefaultEncodersProperty = DependencyProperty.Register("DefaultEncoders", typeFromHandle5, typeFromHandle6, (PropertyMetadata)(object)frameworkPropertyMetadata3);
		IsCustomEncoderProperty = DependencyProperty.Register("IsCustomEncoder", typeof(bool), typeof(EncoderSelectionControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
	}
}
