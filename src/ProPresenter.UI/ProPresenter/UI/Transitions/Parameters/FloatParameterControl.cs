using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Transitions;

namespace ProPresenter.UI.Transitions.Parameters;

public partial class FloatParameterControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(FloatParameterDescription), typeof(FloatParameterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDescriptionPropertyChanged)));

	public static readonly DependencyProperty ParametersProperty = DependencyProperty.Register("Parameters", typeof(TransitionParameters), typeof(FloatParameterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnParametersPropertyChanged)));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(float), typeof(FloatParameterControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

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

	public TransitionParameters? Parameters
	{
		get
		{
			return (TransitionParameters)((DependencyObject)this).GetValue(ParametersProperty);
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
		(d as FloatParameterControl)?.OnDescriptionChanged();
	}

	private static void OnParametersPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as FloatParameterControl)?.OnParametersChanged((TransitionParameters)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (TransitionParameters)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as FloatParameterControl)?.OnValueChanged((float)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public FloatParameterControl()
	{
		InitializeComponent();
	}

	private void OnDescriptionChanged()
	{
		UpdateDisplayValue();
	}

	private void OnParametersChanged(TransitionParameters oldParameters, TransitionParameters newParameters)
	{
		if (oldParameters != null)
		{
			oldParameters.ParametersChanged -= OnParametersDataChanged;
		}
		if (newParameters != null)
		{
			newParameters.ParametersChanged += OnParametersDataChanged;
		}
		UpdateDisplayValue();
	}

	private void OnValueChanged(float newValue)
	{
		if (Description != null && !(Parameters == null))
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
		if (Description != null && !(Parameters?.TransitionDescription == null) && Parameters.TransitionDescription.Parameters.Contains(Description))
		{
			((DependencyObject)this).SetCurrentValue(ValueProperty, (object)Parameters.GetValue<float>(Description));
		}
	}
}
