using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Utility;

namespace Pro.Text;

public static class ListPresetFactory
{
	private static Dictionary<ListPreset, ListSettings> _presetData;

	private static IEnumerable<ListPreset> ListPresets { get; }

	static ListPresetFactory()
	{
		ListPresets = Enum.GetValues<ListPreset>().ToArray();
		_presetData = new Dictionary<ListPreset, ListSettings>();
		foreach (ListPreset listPreset in ListPresets)
		{
			ListPresetDataAttribute attribute = listPreset.GetAttribute<ListPreset, ListPresetDataAttribute>();
			if (attribute != null)
			{
				ListSettings listSettings = new ListSettings();
				listSettings.Levels.AddLevel(new LevelSettings
				{
					BulletType = attribute.BulletType,
					IsBullet = attribute.IsBullet,
					NumberingScheme = attribute.NumberingScheme,
					Prefix = attribute.Prefix,
					Suffix = attribute.Suffix
				});
				_presetData.Add(listPreset, listSettings);
			}
		}
	}

	public static ListSettings LoadPreset(ListPreset preset)
	{
		if (preset != 0)
		{
			return _presetData[preset].Clone();
		}
		return new ListSettings();
	}

	public static ListPreset MatchToPreset(LevelSettings settings)
	{
		return (from p in ListPresets
			select new
			{
				Preset = p,
				Score = WeightedPresetSearch(settings, p.GetAttribute<ListPreset, ListPresetDataAttribute>())
			} into p
			where p.Score > 0
			orderby p.Score
			select p.Preset).LastOrDefault();
	}

	private static int WeightedPresetSearch(LevelSettings settings, ListPresetDataAttribute? presetData)
	{
		if (presetData == null)
		{
			return -1;
		}
		int num = 0;
		if (settings.IsBullet && settings.BulletType == presetData.BulletType)
		{
			num++;
		}
		if (settings.NumberingScheme == presetData.NumberingScheme)
		{
			num++;
		}
		if (settings.Prefix == presetData.Prefix)
		{
			num++;
		}
		if (settings.Suffix == presetData.Suffix)
		{
			num++;
		}
		return num;
	}
}
