using System;
using System.Windows;

namespace Pro.UI.Controls.Windowing;

internal static class ResourceProvider
{
	private const string ResourcesUri = "pack://application:,,,/Pro.UI;component/Controls/Windowing/WindowResources.xaml";

	private static ResourceDictionary _resources;

	static ResourceProvider()
	{
		_resources = new SharedResourceDictionary
		{
			Source = new Uri("pack://application:,,,/Pro.UI;component/Controls/Windowing/WindowResources.xaml")
		};
	}

	public static object GetResource(object key)
	{
		return _resources[key];
	}
}
