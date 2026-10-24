using System;
using System.Globalization;
using Pro.UI.Converters;
using ProPresenter.DO;

namespace ProPresenter.UI.LibraryView;

public class SelectedCueDestinationsToThreeStateBooleanValueConverter : ValueConverterBase<OutputDestination?, bool?>
{
	public OutputDestination Destination { get; set; }

	protected override bool? ValidationFailResult => null;

	protected override bool? ConvertValue(OutputDestination? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!value.HasValue)
		{
			return null;
		}
		return value == Destination;
	}
}
