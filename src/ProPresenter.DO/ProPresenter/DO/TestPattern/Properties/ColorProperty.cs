using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.Properties;

public class ColorProperty : TestPatternPropertyBase, IColorProperty, ITestPatternProperty, INotifyPropertyChanged
{
	[ObservableProperty]
	private System.Windows.Media.Color _color = Colors.Transparent;

	[ObservableProperty]
	private bool _allowAlpha;

	[ObservableProperty]
	private IEnumerable<System.Windows.Media.Color> _defaultColors = new System.Windows.Media.Color[8]
	{
		Colors.Black,
		Colors.White,
		Colors.Red,
		Colors.Blue,
		Colors.Green,
		Colors.Cyan,
		Colors.Magenta,
		Colors.Yellow
	};

	public override TestPatternPropertyType Type => TestPatternPropertyType.Color;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public System.Windows.Media.Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			if (!EqualityComparer<System.Windows.Media.Color>.Default.Equals(_color, value))
			{
				System.Windows.Media.Color color = _color;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Color);
				_color = value;
				OnColorChanged(color, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Color);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool AllowAlpha
	{
		get
		{
			return _allowAlpha;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_allowAlpha, value))
			{
				bool allowAlpha = _allowAlpha;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AllowAlpha);
				_allowAlpha = value;
				OnAllowAlphaChanged(allowAlpha, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AllowAlpha);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IEnumerable<System.Windows.Media.Color> DefaultColors
	{
		get
		{
			return _defaultColors;
		}
		[MemberNotNull("_defaultColors")]
		set
		{
			if (!EqualityComparer<IEnumerable<System.Windows.Media.Color>>.Default.Equals(_defaultColors, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DefaultColors);
				_defaultColors = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DefaultColors);
			}
		}
	}

	protected override void DeserializeDefaults(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		DefaultColors = protoProperty.ColorProperty?.DefaultColors?.Select((Pro.SerializationInterop.RVProtoData.Color c) => c.ToColor()).ToArray() ?? Array.Empty<System.Windows.Media.Color>();
		AllowAlpha = protoProperty.ColorProperty?.AllowAlpha ?? false;
	}

	public override void OnDeserializeValue(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		Color = protoProperty?.ColorProperty?.Value?.ToColor() ?? Colors.Transparent;
	}

	protected override void OnSerialize(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property property)
	{
		property.ColorProperty = new Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.ColorProperty
		{
			Value = Color.ToProtoColor(),
			AllowAlpha = AllowAlpha
		};
	}

	protected override void OnSerialize(TestPatternDocument.Types.TestPatternData.Types.Property property)
	{
		property.ColorProperty = new TestPatternDocument.Types.TestPatternData.Types.ColorProperty
		{
			Value = Color.ToProtoColor()
		};
	}

	public override void DeserializeValue(TestPatternDocument.Types.TestPatternData.Types.Property protoProperty)
	{
		Color = protoProperty?.ColorProperty?.Value?.ToColor() ?? Colors.Transparent;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnColorChanged(System.Windows.Media.Color oldValue, System.Windows.Media.Color newValue)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnAllowAlphaChanged(bool oldValue, bool newValue)
	{
		OnDataModified();
	}
}
