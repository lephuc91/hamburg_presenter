using System.Globalization;
using System.Windows.Controls;
using Pro.Localization;

namespace ProPresenter.UI.Validation;

public class IntegerRangeValidationRule : ValidationRule
{
	public int Maximum { get; set; }

	public int Minimum { get; set; }

	public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
	{
		if (value == null || !(value is int num))
		{
			return new ValidationResult(isValid: false, LocalizedStrings.Get("VALIDATION_INVALID_TYPE_message", new object[1] { typeof(int) }));
		}
		if (num < Minimum || num > Maximum)
		{
			return new ValidationResult(isValid: false, LocalizedStrings.Get("VALIDATION_INVALID_RANGE_message", new object[2] { Minimum, Maximum }));
		}
		return new ValidationResult(isValid: true, string.Empty);
	}
}
