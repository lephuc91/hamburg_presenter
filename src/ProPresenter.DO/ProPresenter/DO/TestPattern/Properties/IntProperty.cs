using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Mathematics;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.Properties;

public class IntProperty : TestPatternPropertyBase, IIntProperty, ITestPatternProperty, INotifyPropertyChanged
{
	[ObservableProperty]
	private int _value;

	public int Min { get; private set; }

	public int Max { get; private set; }

	public string Units { get; private set; } = string.Empty;

	public override TestPatternPropertyType Type => TestPatternPropertyType.Int;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Value
	{
		get
		{
			return _value;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_value, value))
			{
				int value2 = _value;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Value);
				_value = value;
				OnValueChanged(value2, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Value);
			}
		}
	}

	protected override void DeserializeDefaults(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		Min = protoProperty.IntProperty?.Min ?? 0;
		Max = protoProperty.IntProperty?.Max ?? 0;
		Units = protoProperty.IntProperty?.Units ?? string.Empty;
	}

	public override void OnDeserializeValue(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		Value = (protoProperty?.IntProperty?.Value).GetValueOrDefault().Clamp(Min, Max);
	}

	protected override void OnSerialize(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property property)
	{
		property.IntProperty = new Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.IntProperty
		{
			Value = Value,
			Min = Min,
			Max = Max,
			Units = (Units ?? string.Empty)
		};
	}

	protected override void OnSerialize(TestPatternDocument.Types.TestPatternData.Types.Property property)
	{
		property.IntProperty = new TestPatternDocument.Types.TestPatternData.Types.IntProperty
		{
			Value = Value
		};
	}

	public override void DeserializeValue(TestPatternDocument.Types.TestPatternData.Types.Property protoProperty)
	{
		Value = (protoProperty?.IntProperty?.Value).GetValueOrDefault().Clamp(Min, Max);
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnValueChanged(int oldValue, int newValue)
	{
		OnDataModified();
	}
}
