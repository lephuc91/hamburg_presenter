using System;
using System.Globalization;

namespace Pro.Localization.Services;

public interface ILocalization
{
	CultureInfo LoadedCulture { get; }

	string Get(string key, params object[] parameters);

	string Get<E>(string key, params E[] parameters) where E : Enum;

	string Get<E>(E enumValue) where E : Enum;
}
