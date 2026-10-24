namespace Pro.Text.RTF.Tokens;

public class LevelStartAt : TokenBase
{
	internal const string MatchPattern = "levelstartat([0-9]+)";

	public override TokenType TokenType => TokenType.LevelStartAt;

	public int StartingNumber { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		StartingNumber = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"levelstartat{StartingNumber.ToString()}";
	}
}
