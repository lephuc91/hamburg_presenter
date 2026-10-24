using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Mathematics;
using Pro.UI.Components;

namespace Pro.UI.Converters;

public abstract class RectConverterBase<T> : DataConverterBase<Rect<T>>
{
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		RectComponent rectComponent = ((parameter is RectComponent) ? ((RectComponent)parameter) : RectComponent.Top);
		if (value is Rect<T> rect)
		{
			return rectComponent switch
			{
				RectComponent.Top => rect.Top, 
				RectComponent.Left => rect.Left, 
				RectComponent.Width => rect.Width, 
				RectComponent.Height => rect.Height, 
				_ => throw new NotSupportedException(), 
			};
		}
		return Binding.DoNothing;
	}

	public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		RectComponent rectComponent = ((parameter is RectComponent) ? ((RectComponent)parameter) : RectComponent.Top);
		if (value is T val)
		{
			Rect<T> data = base.Data;
			switch (rectComponent)
			{
			case RectComponent.Top:
				data.Top = val;
				break;
			case RectComponent.Left:
				data.Left = val;
				break;
			case RectComponent.Width:
				data.Width = val;
				break;
			case RectComponent.Height:
				data.Height = val;
				break;
			}
			return data;
		}
		return base.Data;
	}
}
