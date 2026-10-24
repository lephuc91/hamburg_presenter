using System;

namespace Pro.Text;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
internal class ListPresetDataAttribute : Attribute
{
	public NumberingScheme NumberingScheme { get; }

	public BulletType BulletType { get; }

	public bool IsBullet { get; }

	public string Prefix { get; }

	public string Suffix { get; }

	public ListPresetDataAttribute(NumberingScheme numberingScheme, string? prefix, string suffix)
	{
		NumberingScheme = numberingScheme;
		Prefix = prefix ?? string.Empty;
		Suffix = suffix ?? string.Empty;
	}

	public ListPresetDataAttribute(BulletType bulletType, string? prefix, string? suffix)
	{
		BulletType = bulletType;
		IsBullet = true;
		Prefix = prefix ?? string.Empty;
		Suffix = suffix ?? string.Empty;
	}
}
