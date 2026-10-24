using System;

namespace Pro.Localization;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class LocalizedStringAttribute : Attribute
{
	public string Key { get; }

	public LocalizedStringAttribute(string key)
	{
		Key = key;
	}
}
