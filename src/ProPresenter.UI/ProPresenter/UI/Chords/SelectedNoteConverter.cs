using System;
using System.Globalization;
using System.Windows.Data;
using Pro.UI.Components;
using ProPresenter.DO.Chords;

namespace ProPresenter.UI.Chords;

internal class SelectedNoteConverter : DataConverterBase<Key>
{
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is Key key && parameter is Note note)
		{
			return key.Note == note;
		}
		return false;
	}

	public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		bool flag = default(bool);
		int num;
		if (value is bool)
		{
			flag = (bool)value;
			num = 1;
		}
		else
		{
			num = 0;
		}
		if (((uint)num & (flag ? 1u : 0u)) != 0 && parameter is Note note)
		{
			return new Key(note, base.Data?.Scale ?? Scale.Major);
		}
		return Binding.DoNothing;
	}
}
