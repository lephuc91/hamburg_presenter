using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;

namespace ProPresenter.DO.Themes;

public class ThemeContainer : LinkedNotifyPropertyChangedBase, ITreeNode<ThemeContainer>, IIdentifiable, IThemeContainer
{
	private readonly List<ThemeContainer> _children = new List<ThemeContainer>();

	private string? _name;

	private Theme? _theme;

	public IEnumerable<ThemeContainer> Children => _children;

	public Guid ID { get; } = Guid.NewGuid();

	public string Name
	{
		get
		{
			string name;
			if (Theme == null)
			{
				name = _name;
				if (name == null)
				{
					return string.Empty;
				}
			}
			else
			{
				name = Theme.Name;
			}
			return name;
		}
		set
		{
			SetValue("Name", ref _name, value);
		}
	}

	public Theme? Theme
	{
		get
		{
			return _theme;
		}
		set
		{
			SetValue<Theme>("Theme", ref _theme, value, delegate(Theme o, Theme n)
			{
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
				}
			});
		}
	}

	private ThemeContainer(string? name = null)
	{
		_name = name;
		LinkProperties("Name", "Name");
	}

	private bool Contains(string containerName, [NotNullWhen(true)] out ThemeContainer? container)
	{
		container = Children.Append(this).FirstOrDefault((ThemeContainer c) => c.Name == containerName);
		return container != null;
	}

	public static ThemeContainer GenerateContainers(ThemeCollection themes)
	{
		ThemeContainer themeContainer = new ThemeContainer();
		foreach (KeyValuePair<Theme, string[]> item in themes.ToDictionary((Theme t) => t, (Theme t) => (from s in t.Path.Split(Path.DirectorySeparatorChar)
			where !string.IsNullOrEmpty(s)
			select s).ToArray()))
		{
			ThemeContainer themeContainer2 = themeContainer;
			string[] value = item.Value;
			foreach (string text in value)
			{
				if (themeContainer2.Contains(text, out ThemeContainer container))
				{
					themeContainer2 = container;
					continue;
				}
				ThemeContainer themeContainer3 = new ThemeContainer(text);
				themeContainer2._children.Add(themeContainer3);
				themeContainer2 = themeContainer3;
			}
			themeContainer2.Theme = item.Key;
		}
		return themeContainer;
	}
}
