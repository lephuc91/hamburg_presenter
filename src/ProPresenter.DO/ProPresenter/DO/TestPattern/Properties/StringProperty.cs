using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.Properties;

public class StringProperty : TestPatternPropertyBase, IStringProperty, ITestPatternProperty, INotifyPropertyChanged
{
	[ObservableProperty]
	private string _value = string.Empty;

	public int MinChars { get; private set; }

	public int MaxChars { get; private set; }

	public override TestPatternPropertyType Type => TestPatternPropertyType.String;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Value
	{
		get
		{
			return _value;
		}
		[MemberNotNull("_value")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_value, value))
			{
				string value2 = _value;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Value);
				_value = value;
				OnValueChanged(value2, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Value);
			}
		}
	}

	protected override void DeserializeDefaults(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		MinChars = protoProperty.StringProperty?.MinChars ?? 0;
		MaxChars = protoProperty.StringProperty?.MaxChars ?? 0;
	}

	public override void OnDeserializeValue(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		Value = protoProperty?.StringProperty?.Value ?? string.Empty;
	}

	protected override void OnSerialize(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property property)
	{
		property.StringProperty = new Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.StringProperty
		{
			Value = Value,
			MinChars = MinChars,
			MaxChars = MaxChars
		};
	}

	protected override void OnSerialize(TestPatternDocument.Types.TestPatternData.Types.Property property)
	{
		property.StringProperty = new TestPatternDocument.Types.TestPatternData.Types.StringProperty
		{
			Value = Value
		};
	}

	public override void DeserializeValue(TestPatternDocument.Types.TestPatternData.Types.Property protoProperty)
	{
		Value = protoProperty?.StringProperty?.Value ?? string.Empty;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnValueChanged(string? oldValue, string newValue)
	{
		OnDataModified();
	}
}
