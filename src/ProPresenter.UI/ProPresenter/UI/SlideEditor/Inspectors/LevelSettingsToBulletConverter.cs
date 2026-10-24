using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Text;
using Pro.UI.Components;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public class LevelSettingsToBulletConverter : DataConverterBase<LevelSettings?>
{
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if ((object)base.Data == null)
		{
			return null;
		}
		if (!base.Data.IsBullet)
		{
			return base.Data.NumberingScheme;
		}
		return base.Data.BulletType;
	}

	public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if ((object)base.Data != null)
		{
			if (value is BulletType bulletType)
			{
				base.Data.BulletType = bulletType;
			}
			else if (value is NumberingScheme numberingScheme)
			{
				base.Data.NumberingScheme = numberingScheme;
			}
		}
		return Binding.DoNothing;
	}
}
