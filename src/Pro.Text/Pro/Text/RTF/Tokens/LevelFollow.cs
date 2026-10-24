using System;

namespace Pro.Text.RTF.Tokens;

public class LevelFollow : TokenBase
{
	internal const string MatchPattern = "levelfollow([0-9]+)";

	public override TokenType TokenType => TokenType.LevelFollow;

	public FollowType Follow { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		switch (int.Parse(value))
		{
		case 0:
			Follow = FollowType.Tab;
			break;
		case 1:
			Follow = FollowType.Space;
			break;
		case 2:
			Follow = FollowType.Nothing;
			break;
		}
	}

	protected internal override string ToRawValue()
	{
		return $"levelfollow{GetFollowValue(Follow)}";
	}

	private int GetFollowValue(FollowType follow)
	{
		return follow switch
		{
			FollowType.Tab => 0, 
			FollowType.Space => 1, 
			FollowType.Nothing => 2, 
			_ => throw new NotSupportedException(), 
		};
	}
}
