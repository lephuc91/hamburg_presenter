using System;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

internal static class ProtoTextInspectorEventExtensions
{
	public static TextInspectorForeground.Types.FillType ToFillType(this FillType fillType)
	{
		return fillType switch
		{
			FillType.Solid => TextInspectorForeground.Types.FillType.Solid, 
			FillType.Gradient => TextInspectorForeground.Types.FillType.Gradient, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static SelectionMode ToSelectionMode(this SelectionType selection)
	{
		return selection switch
		{
			SelectionType.Object => SelectionMode.Object, 
			SelectionType.Range => SelectionMode.Range, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static TextInspectorBackgroundColor.Types.ColorType ToColorType(this ColorType colorType)
	{
		return colorType switch
		{
			ColorType.Clear => TextInspectorBackgroundColor.Types.ColorType.Clear, 
			ColorType.Other => TextInspectorBackgroundColor.Types.ColorType.Other, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static TextInspectorLineTransform.Types.TransformType ToLineTransformType(this TextTransformType transformType)
	{
		return transformType switch
		{
			TextTransformType.None => TextInspectorLineTransform.Types.TransformType.None, 
			TextTransformType.RemoveLineReturns => TextInspectorLineTransform.Types.TransformType.RemoveLineReturns, 
			TextTransformType.ReplaceLineReturns => TextInspectorLineTransform.Types.TransformType.ReplaceLineReturns, 
			TextTransformType.OneWordPerLine => TextInspectorLineTransform.Types.TransformType.OneWordPerLine, 
			TextTransformType.OneCharacterPerLine => TextInspectorLineTransform.Types.TransformType.OneCharacterPerLine, 
			_ => throw new NotImplementedException(), 
		};
	}
}
