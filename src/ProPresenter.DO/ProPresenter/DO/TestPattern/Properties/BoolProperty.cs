using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.Properties;

public class BoolProperty : TestPatternPropertyBase, IBoolProperty, ITestPatternProperty, INotifyPropertyChanged
{
	private readonly ITestPatternPropertyFactory _factory;

	[ObservableProperty]
	private bool _value;

	[ObservableProperty]
	private IReadOnlyCollection<ITestPatternProperty> _dependentProperties = (IReadOnlyCollection<ITestPatternProperty>)(object)Array.Empty<ITestPatternProperty>();

	public override TestPatternPropertyType Type => TestPatternPropertyType.Bool;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool Value
	{
		get
		{
			return _value;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_value, value))
			{
				bool value2 = _value;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Value);
				_value = value;
				OnValueChanged(value2, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Value);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IReadOnlyCollection<ITestPatternProperty> DependentProperties
	{
		get
		{
			return _dependentProperties;
		}
		[MemberNotNull("_dependentProperties")]
		set
		{
			if (!EqualityComparer<IReadOnlyCollection<ITestPatternProperty>>.Default.Equals(_dependentProperties, value))
			{
				IReadOnlyCollection<ITestPatternProperty> dependentProperties = _dependentProperties;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DependentProperties);
				_dependentProperties = value;
				OnDependentPropertiesChanged(dependentProperties, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DependentProperties);
			}
		}
	}

	public BoolProperty(ITestPatternPropertyFactory factory)
	{
		_factory = factory;
	}

	protected override void DeserializeDefaults(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		DependentProperties = (IReadOnlyCollection<ITestPatternProperty>)(object)(protoProperty.BoolProperty?.DependentProperties.Select(_factory.CreateProperty).NonNull().ToArray() ?? Array.Empty<ITestPatternProperty>());
	}

	public override void OnDeserializeValue(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		Value = protoProperty?.BoolProperty?.Value == true;
		if (DependentProperties == null || protoProperty?.BoolProperty?.DependentProperties?.Any() != true)
		{
			return;
		}
		foreach (ITestPatternProperty property in DependentProperties)
		{
			Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property property2 = protoProperty.BoolProperty.DependentProperties.FirstOrDefault((Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property p) => p.PropertyTypeCase.ToPropertyType() == property.Type && p.NameLocalizationKey == property.Name);
			if (property2 != null)
			{
				property.Deserialize(property2);
			}
		}
	}

	protected override void OnSerialize(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property property)
	{
		property.BoolProperty = new Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.BoolProperty
		{
			Value = Value
		};
		property.BoolProperty.DependentProperties.AddRange(DependentProperties.Select((ITestPatternProperty p) => p.Serialize()));
	}

	protected override void OnSerialize(TestPatternDocument.Types.TestPatternData.Types.Property property)
	{
		property.BoolProperty = new TestPatternDocument.Types.TestPatternData.Types.BoolProperty
		{
			Value = Value
		};
		property.BoolProperty.DependentProperties.AddRange(DependentProperties.Select((ITestPatternProperty p) => p.SerializeValue()));
	}

	public override void DeserializeValue(TestPatternDocument.Types.TestPatternData.Types.Property protoProperty)
	{
		Value = protoProperty?.BoolProperty?.Value == true;
		if (DependentProperties == null || protoProperty?.BoolProperty?.DependentProperties?.Any() != true)
		{
			return;
		}
		foreach (ITestPatternProperty property in DependentProperties)
		{
			TestPatternDocument.Types.TestPatternData.Types.Property property2 = protoProperty.BoolProperty.DependentProperties.FirstOrDefault((TestPatternDocument.Types.TestPatternData.Types.Property p) => p.PropertyTypeCase.ToPropertyType() == property.Type && p.NameLocalizationKey == property.Name);
			if (property2 != null)
			{
				property.DeserializeValue(property2);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnValueChanged(bool oldValue, bool newValue)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnDependentPropertiesChanged(IReadOnlyCollection<ITestPatternProperty>? oldValue, IReadOnlyCollection<ITestPatternProperty> newValue)
	{
		oldValue?.NonNull().ForEach(delegate(ITestPatternProperty p)
		{
			p.DataModified -= base.OnDataModified;
		});
		newValue.NonNull().ForEach(delegate(ITestPatternProperty p)
		{
			p.DataModified += base.OnDataModified;
		});
	}
}
