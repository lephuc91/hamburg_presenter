using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Text.RTF.Tokens;

namespace Pro.Text.RTF;

internal class ListTable
{
	private Dictionary<int, ListData> _listData = new Dictionary<int, ListData>();

	public ListData[] ListData => _listData.Values.ToArray();

	public void AddList(int listIndex)
	{
		_listData.Add(listIndex, new ListData(_listData.Count + 1));
	}

	public void AddLevel(int listIndex, FollowType follow, NumberingScheme numberingScheme, string numberingFormat, bool isBullet, int startNumber)
	{
		_listData[listIndex].Levels.Add(new LevelData(follow, ParseNumberingScheme(numberingScheme, isBullet), numberingFormat, startNumber));
	}

	public ListData? GetListData(int listIndex)
	{
		if (!_listData.TryGetValue(listIndex, out ListData value))
		{
			return null;
		}
		return value;
	}

	public void Clear()
	{
		_listData.Clear();
	}

	private LevelNumberType.NumberType ParseNumberingScheme(NumberingScheme numberingScheme, bool isBullet)
	{
		if (isBullet)
		{
			return LevelNumberType.NumberType.Bullet;
		}
		return numberingScheme switch
		{
			NumberingScheme.Arabic => LevelNumberType.NumberType.Arabic, 
			NumberingScheme.ArabicWithLeadingZero => LevelNumberType.NumberType.ArabicWithLeadingZero, 
			NumberingScheme.OrdinalNumber => LevelNumberType.NumberType.OrdinalNumber, 
			NumberingScheme.UppercaseRomanNumeral => LevelNumberType.NumberType.UppercaseRomanNumeral, 
			NumberingScheme.LowercaseRomanNumeral => LevelNumberType.NumberType.LowercaseRomanNumeral, 
			NumberingScheme.UppercaseLetter => LevelNumberType.NumberType.UppercaseLetter, 
			NumberingScheme.LowercaseLetter => LevelNumberType.NumberType.LowercaseLetter, 
			NumberingScheme.LowercaseRussianAlphabet => LevelNumberType.NumberType.LowercaseRussianAlphabet, 
			NumberingScheme.UppercaseRussianAlphabet => LevelNumberType.NumberType.UppercaseRussianAlphabet, 
			NumberingScheme.LowercaseGreekNumerals => LevelNumberType.NumberType.LowercaseGreekNumerals, 
			NumberingScheme.UppercaseGreekNumerals => LevelNumberType.NumberType.UppercaseGreekNumerals, 
			_ => throw new NotSupportedException(), 
		};
	}
}
