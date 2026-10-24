using System.Globalization;
using System.Windows.Controls;

namespace ProPresenter.ViewModels;

public class StringValueValidationRule : ValidationRule
{
	private IStringValueValidator _validator;

	public StringValueValidationRule(IStringValueValidator validator)
	{
		_validator = validator;
	}

	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		return new ValidationResult(_validator.Validate(value as string), string.Empty);
	}
}
