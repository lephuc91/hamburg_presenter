using System.Xml;

namespace ProPresenter.DO.Bibles.Formats;

internal static class XmlNodeExtensions
{
	public delegate bool ParseDelegate<T>(string input, out T output);

	public static string? GetAttribute(this XmlNode node, string attributeName)
	{
		return node.Attributes?[attributeName]?.Value.Trim();
	}

	public static T GetAttribute<T>(this XmlNode node, string attributeName, T defaultValue, ParseDelegate<T> parseDelegate)
	{
		string attribute = node.GetAttribute(attributeName);
		if (attribute == null)
		{
			return defaultValue;
		}
		if (!parseDelegate(attribute, out var output))
		{
			return defaultValue;
		}
		return output;
	}

	public static string GetStringAttribute(this XmlNode node, string attributeName, string defaultValue)
	{
		return node.GetAttribute(attributeName) ?? defaultValue;
	}

	public static int GetIntAttribute(this XmlNode node, string attributeName, int defaultValue)
	{
		return node.GetAttribute(attributeName, defaultValue, int.TryParse);
	}

	public static float GetFloatAttribute(this XmlNode node, string attributeName, float defaultValue)
	{
		return node.GetAttribute(attributeName, defaultValue, float.TryParse);
	}

	public static string GetValue(this XmlNode node, string xpath, string defaultValue = "")
	{
		return node.SelectSingleNode(xpath)?.InnerText ?? defaultValue;
	}
}
