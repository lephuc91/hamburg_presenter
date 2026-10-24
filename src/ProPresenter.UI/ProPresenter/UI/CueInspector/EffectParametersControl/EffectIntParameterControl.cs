using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;

namespace ProPresenter.UI.CueInspector.EffectParametersControl;

public partial class EffectIntParameterControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(IntParameterDescription), typeof(EffectIntParameterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDescriptionPropertyChanged)));

	public static readonly DependencyProperty ParametersProperty = DependencyProperty.Register("Parameters", typeof(EffectParameters), typeof(EffectIntParameterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnParametersPropertyChanged)));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(EffectIntParameterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0, new PropertyChangedCallback(OnValuePropertyChanged)));

	public IntParameterDescription? Description
	{
		get
		{
			return (IntParameterDescription)((DependencyObject)this).GetValue(DescriptionProperty);
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

	public int Value
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, (object)value);
		}
	}

	private static void OnDescriptionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as EffectIntParameterControl)?.OnDescriptionChanged();
	}

	private static void OnParametersPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as EffectIntParameterControl)?.OnParametersChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as EffectParameters, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as EffectParameters);
	}

	private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as EffectIntParameterControl)?.OnValueChanged((int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public EffectIntParameterControl()
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

	private void OnValueChanged(int newValue)
	{
		if (Description != null && (object)Parameters != null)
		{
			Parameters.SetValue(Description, newValue);
		}
	}

	private void OnParametersDataChanged(EffectParameters parameters)
	{
		UpdateDisplayValue();
	}

	private void UpdateDisplayValue()
	{
		if (Description != null && (object)Parameters?.EffectDescription != null && Parameters.EffectDescription.Parameters.Contains(Description))
		{
			((DependencyObject)this).SetCurrentValue(ValueProperty, (object)Parameters.GetValue<int>(Description));
		}
	}
}
