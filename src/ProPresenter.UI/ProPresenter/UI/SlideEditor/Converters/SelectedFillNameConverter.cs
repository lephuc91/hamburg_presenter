using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Localization;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.UI.SlideEditor.Converters;

public class SelectedFillNameConverter : IMultiValueConverter
{
	public object? Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 5 && values[1] is LinkedFillType linkedFillType)
		{
			switch (linkedFillType)
			{
			case LinkedFillType.None:
				return (values[0] is FillType enumValue) ? LocalizedStrings.Get(enumValue) : string.Empty;
			case LinkedFillType.Element:
				return (values[2] is ClosedBezierPath closedBezierPath) ? (closedBezierPath.Name ?? LocalizedStrings.Get(linkedFillType)) : string.Empty;
			case LinkedFillType.PreviewScreen:
				return (values[4] is ScreenArrangementBase screenArrangementBase) ? (screenArrangementBase.Name ?? LocalizedStrings.Get(linkedFillType)) : string.Empty;
			case LinkedFillType.SlidePreview:
			{
				object obj = values[3];
				return (!(obj is SlideTargetSourceMode)) ? string.Empty : LocalizedStrings.Get(((SlideTargetSourceMode)obj == SlideTargetSourceMode.Current) ? "FILL_LINK_CURRENT_SLIDE_IMAGE_title" : "FILL_LINK_NEXT_SLIDE_IMAGE_title");
			}
			default:
				return LocalizedStrings.Get(linkedFillType);
			}
		}
		return string.Empty;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
