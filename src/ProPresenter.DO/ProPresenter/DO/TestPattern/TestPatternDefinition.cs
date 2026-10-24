using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.TestPattern.Properties;

namespace ProPresenter.DO.TestPattern;

public class TestPatternDefinition : ObservableObject, ITestPatternDefinition, INotifyPropertyChanged
{
	private readonly ITestPatternPropertyFactory _factory;

	[ObservableProperty]
	private string _name = string.Empty;

	[ObservableProperty]
	private IEnumerable<ITestPatternProperty> _properties = Enumerable.Empty<ITestPatternProperty>();

	[ObservableProperty]
	private bool _showDelaySettings;

	[ObservableProperty]
	private BitmapSource? _thumbnail;

	public Guid ID { get; private set; } = Guid.NewGuid();

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
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Name);
				_name = value;
				OnNameChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Name);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IEnumerable<ITestPatternProperty> Properties
	{
		get
		{
			return _properties;
		}
		[MemberNotNull("_properties")]
		set
		{
			if (!EqualityComparer<IEnumerable<ITestPatternProperty>>.Default.Equals(_properties, value))
			{
				IEnumerable<ITestPatternProperty> properties = _properties;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Properties);
				_properties = value;
				OnPropertiesChanged(properties, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Properties);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowDelaySettings
	{
		get
		{
			return _showDelaySettings;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showDelaySettings, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ShowDelaySettings);
				_showDelaySettings = value;
				OnShowDelaySettingsChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ShowDelaySettings);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public BitmapSource? Thumbnail
	{
		get
		{
			return _thumbnail;
		}
		set
		{
			if (!EqualityComparer<BitmapSource>.Default.Equals(_thumbnail, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Thumbnail);
				_thumbnail = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Thumbnail);
			}
		}
	}

	public event System.Action? DataModified;

	public TestPatternDefinition(ITestPatternPropertyFactory factory)
	{
		_factory = factory;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.TestPatternDefinition protoTestPatternDefinition)
	{
		if (protoTestPatternDefinition != null)
		{
			ID = protoTestPatternDefinition.Uuid.ToGuid();
			Name = protoTestPatternDefinition.NameLocalizationKey;
			ShowDelaySettings = protoTestPatternDefinition.ShowDelaySettings;
			Properties = protoTestPatternDefinition.Properties.Select((Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property p) => _factory.CreateProperty(p)).NonNull().ToArray();
		}
	}

	public Pro.SerializationInterop.RVProtoData.TestPatternDefinition Serialize()
	{
		Pro.SerializationInterop.RVProtoData.TestPatternDefinition testPatternDefinition = new Pro.SerializationInterop.RVProtoData.TestPatternDefinition();
		testPatternDefinition.Uuid = ID.ToUUID();
		testPatternDefinition.NameLocalizationKey = Name;
		testPatternDefinition.ShowDelaySettings = ShowDelaySettings;
		testPatternDefinition.Properties.AddRange(Properties.Select((ITestPatternProperty p) => p.Serialize()));
		return testPatternDefinition;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnNameChanged(string value)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnPropertiesChanged(IEnumerable<ITestPatternProperty>? oldValue, IEnumerable<ITestPatternProperty> newValue)
	{
		if (oldValue != null)
		{
			foreach (ITestPatternProperty item in oldValue)
			{
				item.DataModified -= OnDataModified;
			}
		}
		foreach (ITestPatternProperty item2 in newValue)
		{
			item2.DataModified += OnDataModified;
		}
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnShowDelaySettingsChanged(bool value)
	{
		OnDataModified();
	}
}
