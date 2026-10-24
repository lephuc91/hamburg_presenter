using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.Properties;

public abstract class TestPatternPropertyBase : ObservableObject, ITestPatternProperty, INotifyPropertyChanged
{
	[ObservableProperty]
	public string _name = string.Empty;

	public abstract TestPatternPropertyType Type { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Name
	{
		get
		{
			return _name;
		}
		[MemberNotNull("_name")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_name, value))
			{
				string name = _name;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Name);
				_name = value;
				OnNameChanged(name, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Name);
			}
		}
	}

	public event System.Action? DataModified;

	public void Deserialize(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		if (protoProperty != null)
		{
			Name = protoProperty.NameLocalizationKey;
			DeserializeDefaults(protoProperty);
			OnDeserializeValue(protoProperty);
		}
	}

	protected virtual void DeserializeDefaults(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
	}

	public abstract void OnDeserializeValue(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty);

	public Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property Serialize()
	{
		Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property property = new Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property
		{
			NameLocalizationKey = Name
		};
		OnSerialize(property);
		return property;
	}

	protected abstract void OnSerialize(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property property);

	protected abstract void OnSerialize(TestPatternDocument.Types.TestPatternData.Types.Property property);

	public abstract void DeserializeValue(TestPatternDocument.Types.TestPatternData.Types.Property protoProperty);

	public TestPatternDocument.Types.TestPatternData.Types.Property SerializeValue()
	{
		TestPatternDocument.Types.TestPatternData.Types.Property property = new TestPatternDocument.Types.TestPatternData.Types.Property
		{
			NameLocalizationKey = Name
		};
		OnSerialize(property);
		return property;
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnNameChanged(string? oldValue, string newValue)
	{
		OnDataModified();
	}
}
