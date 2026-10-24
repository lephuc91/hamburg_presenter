namespace Pro.Text.RTF.Tokens;

public class LevelJustification : TokenBase
{
	public enum JustificationType
	{
		Left,
		Center,
		Right
	}

	internal const string MatchPattern = "leveljc(n|)([0-9]+)";

	public override TokenType TokenType => TokenType.LevelJustification;

	public bool IsImportant { get; set; }

	public JustificationType Justification { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		IsImportant = value == "n";
		Justification = (JustificationType)int.Parse(additionalValues[0]);
	}

	protected internal override string ToRawValue()
	{
		return string.Format("leveljc{0}{1}", IsImportant ? "n" : string.Empty, (int)Justification);
	}
}
