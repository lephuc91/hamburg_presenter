using System;
using System.Windows.Markup;
using Pro.Localization;

namespace Pro.UI.MarkupExtensions;

public class LocalizedExtension : MarkupExtension
{
	private readonly string _key;

	private readonly string[] _parameters;

	private LocalizedExtension(string key, string[] parameters)
	{
		_key = key;
		_parameters = parameters;
	}

	public LocalizedExtension(string key)
		: this(key, Array.Empty<string>())
	{
	}

	public LocalizedExtension(string key, string param1)
		: this(key, new string[1] { param1 })
	{
	}

	public LocalizedExtension(string key, string param1, string param2)
		: this(key, new string[2] { param1, param2 })
	{
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		string key = _key;
		object[] parameters = _parameters;
		return LocalizedStrings.Get(key, parameters);
	}
}
