using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Mathematics;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.Properties;

public class DoubleProperty : TestPatternPropertyBase, IDoubleProperty, ITestPatternProperty, INotifyPropertyChanged
{
	[ObservableProperty]
	private double _value;

	[ObservableProperty]
	private DoublePropertyViewType _viewType;

	public double Min { get; private set; }

	public double Max { get; private set; }

	public double StepSize { get; private set; }

	public string Units { get; private set; } = string.Empty;

	public override TestPatternPropertyType Type => TestPatternPropertyType.Double;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double Value
	{
		get
		{
			return _value;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_value, value))
			{
				double value2 = _value;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Value);
				_value = value;
				OnValueChanged(value2, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Value);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public DoublePropertyViewType ViewType
	{
		get
		{
			return _viewType;
		}
		set
		{
			if (!EqualityComparer<DoublePropertyViewType>.Default.Equals(_viewType, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ViewType);
				_viewType = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ViewType);
			}
		}
	}

	protected override void DeserializeDefaults(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		Min = protoProperty.DoubleProperty?.Min ?? 0.0;
		Max = protoProperty.DoubleProperty?.Max ?? 0.0;
		Units = protoProperty.DoubleProperty?.Units ?? string.Empty;
		StepSize = protoProperty.DoubleProperty?.Step ?? 0.0;
		ViewType = ToViewType(protoProperty.DoubleProperty?.ViewType);
	}

	public override void OnDeserializeValue(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		Value = (protoProperty?.DoubleProperty?.Value).GetValueOrDefault().Clamp(Min, Max);
	}

	protected override void OnSerialize(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property property)
	{
		property.DoubleProperty = new Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.DoubleProperty
		{
			Value = Value,
			Min = Min,
			Max = Max,
			Units = Units,
			Step = StepSize,
			ViewType = ToProtoViewType(ViewType)
		};
	}

	protected override void OnSerialize(TestPatternDocument.Types.TestPatternData.Types.Property property)
	{
		property.DoubleProperty = new TestPatternDocument.Types.TestPatternData.Types.DoubleProperty
		{
			Value = Value
		};
	}

	public override void DeserializeValue(TestPatternDocument.Types.TestPatternData.Types.Property protoProperty)
	{
		Value = (protoProperty?.DoubleProperty?.Value).GetValueOrDefault().Clamp(Min, Max);
	}

	private static DoublePropertyViewType ToViewType(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.DoubleProperty.Types.ViewType? protoViewType)
	{
		return protoViewType switch
		{
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.DoubleProperty.Types.ViewType.Slider => DoublePropertyViewType.Slider, 
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.DoubleProperty.Types.ViewType.SpeedSlider => DoublePropertyViewType.SpeedSlider, 
			_ => DoublePropertyViewType.Stepper, 
		};
	}

	private static Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.DoubleProperty.Types.ViewType ToProtoViewType(DoublePropertyViewType viewType)
	{
		return viewType switch
		{
			DoublePropertyViewType.Slider => Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.DoubleProperty.Types.ViewType.Slider, 
			DoublePropertyViewType.SpeedSlider => Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.DoubleProperty.Types.ViewType.SpeedSlider, 
			_ => Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.DoubleProperty.Types.ViewType.Stepper, 
		};
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnValueChanged(double oldValue, double newValue)
	{
		OnDataModified();
	}
}
