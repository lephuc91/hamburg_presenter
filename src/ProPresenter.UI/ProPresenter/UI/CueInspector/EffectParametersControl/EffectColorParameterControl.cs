using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;

namespace ProPresenter.UI.CueInspector.EffectParametersControl;

public partial class EffectColorParameterControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(ColorParameterDescription), typeof(EffectColorParameterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDescriptionPropertyChanged)));

	public static readonly DependencyProperty ParametersProperty = DependencyProperty.Register("Parameters", typeof(EffectParameters), typeof(EffectColorParameterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnParametersPropertyChanged)));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(Color), typeof(EffectColorParameterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)default(Color), new PropertyChangedCallback(OnValuePropertyChanged)));

	public ColorParameterDescription? Description
	{
		get
		{
			return (ColorParameterDescription)((DependencyObject)this).GetValue(DescriptionProperty);
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

	public Color Value
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, (object)value);
		}
	}

	private static void OnDescriptionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as EffectColorParameterControl)?.OnDescriptionChanged();
	}

	private static void OnParametersPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as EffectColorParameterControl)?.OnParametersChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as EffectParameters, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as EffectParameters);
	}

	private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as EffectColorParameterControl)?.OnValueChanged((Color)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public EffectColorParameterControl()
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

	private void OnValueChanged(Color newValue)
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
			((DependencyObject)this).SetCurrentValue(ValueProperty, (object)Parameters.GetValue<Color>(Description));
		}
	}
}
