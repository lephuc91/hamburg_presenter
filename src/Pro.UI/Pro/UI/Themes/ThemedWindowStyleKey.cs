using System.Windows;

namespace Pro.UI.Themes;

public class ThemedWindowStyleKey : ComponentResourceKey
{
	public ThemedWindowStyleKey()
	{
		base.TypeInTargetAssembly = typeof(ThemedWindow);
		base.ResourceId = "STYLE_ThemedWindow";
	}
}
