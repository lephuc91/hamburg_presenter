using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Pro.UI;

public partial class SharedResourceDictionary : ResourceDictionary
{
	public static Dictionary<Uri, SharedResourceDictionary> SharedDictionaries = new Dictionary<Uri, SharedResourceDictionary>();

	private Uri _sourceUri = new Uri("about:blank");

	public static bool IsInDesignMode => (bool)DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty, typeof(DependencyObject)).Metadata.DefaultValue;

	public new Uri Source
	{
		get
		{
			if (!IsInDesignMode)
			{
				return _sourceUri;
			}
			return base.Source;
		}
		set
		{
			_sourceUri = value;
			if (!SharedDictionaries.ContainsKey(value))
			{
				base.Source = value;
				if (!SharedDictionaries.ContainsKey(value))
				{
					SharedDictionaries.Add(value, this);
				}
			}
			else if (!base.MergedDictionaries.Contains(SharedDictionaries[value]))
			{
				base.MergedDictionaries.Add(SharedDictionaries[value]);
			}
		}
	}
}
