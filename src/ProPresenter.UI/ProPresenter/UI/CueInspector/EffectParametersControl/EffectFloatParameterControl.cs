using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;

namespace ProPresenter.UI.CueInspector.EffectParametersControl;

public partial class EffectFloatParameterControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(FloatParameterDescription), typeof(EffectFloatParameterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDescriptionPropertyChanged)));

	public static readonly DependencyProperty ParametersProperty = DependencyProperty.Register("Parameters", typeof(EffectParameters), typeof(EffectFloatParameterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnParametersPropertyChanged)));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(float), typeof(EffectFloatParameterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0f, new PropertyChangedCallback(OnValuePropertyChanged)));

	public FloatParameterDescription? Description
	{
		get
		{
			return (FloatParameterDescription)((DependencyObject)this).GetValue(DescriptionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DescriptionProperty, (object)value);
		}
	}

	public EffectParameters? Parameters
	{
		get
		{
			return (EffectParameters)((DependencyObject)this).GetValue(ParametersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ParametersProperty, (object)value);
		}
	}

	public float Value
	{
		get
		{
			return (float)((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, (object)value);
		}
	}

	private static void OnDescriptionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as EffectFloatParameterControl)?.OnDescriptionChanged();
	}

	private static void OnParametersPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as EffectFloatParameterControl)?.OnParametersChanged((EffectParameters)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (EffectParameters)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as EffectFloatParameterControl)?.OnValueChanged((float)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public EffectFloatParameterControl()
	{
		InitializeComponent();
	}

	private void OnDescriptionChanged()
	{
		UpdateDisplayValue();
	}

	private void OnParametersChanged(EffectParameters? oldParameters, EffectParameters? newParameters)
	{
		if ((object)oldParameters != null)
		{
			oldParameters.ParametersChanged -= OnParametersDataChanged;
		}
		if ((object)newParameters != null)
		{
			newParameters.ParametersChanged += OnParametersDataChanged;
		}
		UpdateDisplayValue();
	}

	private void OnValueChanged(float newValue)
	{
		if (Description != null && (object)Parameters != null)
		{
			Parameters.SetValue(Description, newValue);
		}
	}

	private void OnParametersDataChanged(EffectParameters obj)
	{
		UpdateDisplayValue();
	}

	private void UpdateDisplayValue()
	{
		if (Description != null && (object)Parameters?.EffectDescription != null && Parameters.EffectDescription.Parameters.Contains(Description))
		{
			((DependencyObject)this).SetCurrentValue(ValueProperty, (object)Parameters.GetValue<float>(Description));
		}
	}
}
