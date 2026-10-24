using Pro.Text.RTF.Tokens;

namespace Pro.Text.RTF;

internal class LevelData
{
	public FollowType Follow { get; }

	public LevelNumberType.NumberType NumberType { get; }

	public string NumberingFormat { get; }

	public int StartNumber { get; }

	public LevelData(FollowType follow, LevelNumberType.NumberType numberType, string numberingFormat, int startNumber)
	{
		Follow = follow;
		NumberType = numberType;
		NumberingFormat = numberingFormat;
		StartNumber = startNumber;
	}
}
