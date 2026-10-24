using System;
using System.Globalization;
using Pro.UI.Components;
using ProPresenter.DO.Audio;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.UI.Input;

public class IsLiveVideoInputLinkedConverter : DataConverterBase<LinkedVideoInputs>
{
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is LiveVideoInput videoInput && base.Data != null)
		{
			return base.Data.IsLinked(videoInput);
		}
		return false;
	}

	public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
