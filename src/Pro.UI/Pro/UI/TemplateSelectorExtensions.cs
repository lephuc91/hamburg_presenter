using System;
using System.Windows;

namespace Pro.UI;

public static class TemplateSelectorExtensions
{
	public static DataTemplate? GetDataTemplate(this Type type, ResourceDictionary resourceDictionary)
	{
		return type.GetDataTemplateFromType(resourceDictionary) ?? type.GetDataTemplateFromInterfaces(resourceDictionary);
	}

	private static DataTemplate? GetDataTemplateFromType(this Type type, ResourceDictionary resourceDictionary)
	{
		DataTemplateKey key = new DataTemplateKey(type);
		if (resourceDictionary[key] is DataTemplate result)
		{
			return result;
		}
		return null;
	}

	private static DataTemplate? GetDataTemplateFromInterfaces(this Type type, ResourceDictionary resourceDictionary)
	{
		Type[] interfaces = type.GetInterfaces();
		for (int i = 0; i < interfaces.Length; i++)
		{
			DataTemplate dataTemplateFromType = interfaces[i].GetDataTemplateFromType(resourceDictionary);
			if (dataTemplateFromType != null)
			{
				return dataTemplateFromType;
			}
		}
		return null;
	}
}
