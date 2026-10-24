using System.Globalization;
using Pro.Common.Nullability;

namespace Pro.Localization.Services;

public class Localization : ILocalization
{
	public CultureInfo LoadedCulture
	{
		get
		{
			CultureInfo? loadedCulture = LocalizedStrings.LoadedCulture;
			loadedCulture.ThrowWhenNull("culture");
			return loadedCulture;
		}
	}

	public string Get(string key, params object[] parameters)
	{
		return LocalizedStrings.Get(key, parameters);
	}

	string ILocalization.Get<E>(string key, params E[] parameters)
	{
		return LocalizedStrings.Get(key, parameters);
	}

	string ILocalization.Get<E>(E enumValue)
	{
		return LocalizedStrings.Get(enumValue);
	}
}
