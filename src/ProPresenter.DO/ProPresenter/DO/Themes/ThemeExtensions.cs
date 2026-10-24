using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProPresenter.DO.Themes;

public static class ThemeExtensions
{
	public const string Assets = "Assets";

	public static string GetAssetPath(this Theme theme)
	{
		return GetAssetPath(theme.Path);
	}

	public static string GetAssetPath(string themePath)
	{
		return Path.Combine(CommonPaths.Themes, themePath, "Assets");
	}

	public static ThemeContainer? RenameContainer(this ThemeContainer root, string path, string name)
	{
		ThemeContainer container = null;
		if (string.IsNullOrEmpty(name) || !root.TryFindContainer(path, out container))
		{
			return null;
		}
		if (container != null)
		{
			container.Name = name;
		}
		return container;
	}

	public static bool TryFindContainer(this ThemeContainer root, string path, out ThemeContainer? container)
	{
		container = null;
		if (string.IsNullOrEmpty(path) || root == null)
		{
			return false;
		}
		global::_003C_003Ey__InlineArray2<char> buffer = default(global::_003C_003Ey__InlineArray2<char>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<char>, char>(ref buffer, 0) = Path.DirectorySeparatorChar;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<char>, char>(ref buffer, 1) = Path.AltDirectorySeparatorChar;
		string[] array = path.Split(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<char>, char>(in buffer, 2));
		IEnumerable<ThemeContainer> source = root.Children.Where((ThemeContainer t) => t.Theme == null);
		bool result = false;
		for (int i = 0; i < array.Length; i++)
		{
			string folder = array.ElementAt(i);
			container = source.FirstOrDefault((ThemeContainer t) => t.Name == folder);
			result = true;
			if (container == null)
			{
				result = false;
				break;
			}
			if (i + 1 < array.Length)
			{
				source = container.Children;
			}
		}
		return result;
	}
}
