using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;

namespace ProPresenter.DO.TestPattern.Properties;

public class FontProperty : TestPatternPropertyBase, IFontProperty, ITestPatternProperty, INotifyPropertyChanged
{
	[ObservableProperty]
	private FontInfo _font;

	public override TestPatternPropertyType Type => TestPatternPropertyType.Font;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public FontInfo Font
	{
		get
		{
			return _font;
		}
		set
		{
			if (!EqualityComparer<FontInfo>.Default.Equals(_font, value))
			{
				FontInfo font = _font;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Font);
				_font = value;
				OnFontChanged(font, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Font);
			}
		}
	}

	public override void OnDeserializeValue(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property protoProperty)
	{
		Font = (protoProperty.FontProperty?.Font?.ToFont()).GetValueOrDefault();
	}

	protected override void OnSerialize(Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.Property property)
	{
		property.FontProperty = new Pro.SerializationInterop.RVProtoData.TestPatternDefinition.Types.FontProperty
		{
			Font = Font.ToProtoFont()
		};
	}

	protected override void OnSerialize(TestPatternDocument.Types.TestPatternData.Types.Property property)
	{
		property.FontProperty = new TestPatternDocument.Types.TestPatternData.Types.FontProperty
		{
			Value = Font.ToProtoFont()
		};
	}

	public override void DeserializeValue(TestPatternDocument.Types.TestPatternData.Types.Property protoProperty)
	{
		Font = (protoProperty.FontProperty?.Value?.ToFont()).GetValueOrDefault();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnFontChanged(FontInfo oldValue, FontInfo newValue)
	{
		OnDataModified();
	}
}
