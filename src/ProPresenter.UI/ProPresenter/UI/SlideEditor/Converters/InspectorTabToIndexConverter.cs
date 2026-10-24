using System;
using System.Globalization;
using System.Windows.Data;

namespace ProPresenter.UI.SlideEditor.Converters;

public class InspectorTabToIndexConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is InspectorTab)
		{
			_ = (InspectorTab)value;
			if (value is InspectorTab inspectorTab)
			{
				switch (inspectorTab)
				{
				case InspectorTab.StageLayout:
					return 1;
				case InspectorTab.PropSlide:
					return 2;
				case InspectorTab.Mask:
					return 3;
				case InspectorTab.Template:
					return 4;
				case InspectorTab.Shape:
					return 5;
				case InspectorTab.Slide:
					return 6;
				case InspectorTab.Text:
					return 7;
				case InspectorTab.Build:
					return 8;
				}
			}
			return 0;
		}
		return Binding.DoNothing;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is int)
		{
			return (int)value switch
			{
				0 => InspectorTab.Document, 
				1 => InspectorTab.StageLayout, 
				2 => InspectorTab.PropSlide, 
				3 => InspectorTab.Mask, 
				4 => InspectorTab.Template, 
				5 => InspectorTab.Shape, 
				6 => InspectorTab.Slide, 
				7 => InspectorTab.Text, 
				8 => InspectorTab.Build, 
				_ => InspectorTab.None, 
			};
		}
		return Binding.DoNothing;
	}
}
