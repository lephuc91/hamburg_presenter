using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Pro.UI.Controls;

namespace Pro.UI.Utility;

public static class UIHelper
{
	private static Type[] InputBlacklist { get; } = new Type[7]
	{
		typeof(TextBox),
		typeof(RichTextBox),
		typeof(FormattedTextBox),
		typeof(IntegerUpDown),
		typeof(DoubleUpDown),
		typeof(ByteUpDown),
		typeof(FloatUpDown)
	};

	public static bool IsInputRestricted(this KeyEventArgs e)
	{
		return e.OriginalSource.GetType().IsInputRestricted();
	}

	public static bool IsInputRestricted(this Type type)
	{
		if (!InputBlacklist.Contains(type))
		{
			return Array.Exists(InputBlacklist, (Type t) => type.IsSubclassOf(t));
		}
		return true;
	}
}
