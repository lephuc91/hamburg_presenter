using System;
using System.Linq;
using System.Windows.Markup;
using Pro.Localization;

namespace Pro.UI.MarkupExtensions;

public class EnumerationItemSourceExtension : MarkupExtension
{
	private readonly Type _enumType;

	public EnumerationItemSourceExtension(Type enumType)
	{
		if (enumType == null)
		{
			throw new ArgumentException("value cannot be null", "enumType");
		}
		Type type = Nullable.GetUnderlyingType(enumType) ?? enumType;
		if (!type.IsEnum)
		{
			throw new ArgumentException(enumType.FullName + " needs to be an enum", "enumType");
		}
		_enumType = type;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return (from Enum value in Enum.GetValues(_enumType)
			select new EnumerationMember(GetDescription(value), value)).ToArray();
	}

	private string GetDescription(Enum enumValue)
	{
		if (!(_enumType.GetField(enumValue.ToString())?.GetCustomAttributes(typeof(LocalizedStringAttribute), inherit: false).FirstOrDefault() is LocalizedStringAttribute localizedStringAttribute))
		{
			return enumValue.ToString();
		}
		return LocalizedStrings.Get(localizedStringAttribute.Key);
	}
}
