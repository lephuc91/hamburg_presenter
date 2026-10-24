using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.Properties;

public class SelectorProperty : TestPatternPropertyBase, ISelectorProperty, ITestPatternProperty, INotifyPropertyChanged
{
	[ObservableProperty]
	private int _selectedIndex;

	[ObservableProperty]
	private IEnumerable<string>? _values;

	public override TestPatternPropertyType Type => TestPatternPropertyType.Selector;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int SelectedIndex
	{
		get
		{
			return _selectedIndex;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_selectedIndex, value))
			{
				int selectedIndex = _selectedIndex;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedIndex);
				_selectedIndex = value;
				OnSelectedIndexChanged(selectedIndex, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedIndex);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IEnumerable<string>? Values
	{
		get
		{
			return _values;
		}
		set
		{
			if (!EqualityComparer<IEnumerable<string>>.Default.Equals(_values, value))
			{
				IEnumerable<string> values = _values;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Values);
				_values = value;
				OnValuesChanged(values, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Values);
			}
		}
	}

	public override void OnDeserializeValue(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		SelectedIndex = (protoProperty?.SelectorProperty?.SelectedIndex).GetValueOrDefault();
		Values = protoProperty?.SelectorProperty?.ValueLocalizationKeys?.Select((string v) => v).ToArray() ?? Array.Empty<string>();
	}

	protected override void OnSerialize(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property property)
	{
		property.SelectorProperty = new Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.SelectorProperty
		{
			SelectedIndex = SelectedIndex
		};
		property.SelectorProperty.ValueLocalizationKeys.AddRange(Values);
	}

	protected override void OnSerialize(TestPatternDocument.Types.TestPatternData.Types.Property property)
	{
		property.SelectorProperty = new TestPatternDocument.Types.TestPatternData.Types.SelectorProperty
		{
			Value = SelectedIndex
		};
	}

	public override void DeserializeValue(TestPatternDocument.Types.TestPatternData.Types.Property protoProperty)
	{
		SelectedIndex = (protoProperty?.SelectorProperty?.Value).GetValueOrDefault();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSelectedIndexChanged(int oldValue, int newValue)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnValuesChanged(IEnumerable<string>? oldValue, IEnumerable<string>? newValue)
	{
		OnDataModified();
	}
}
