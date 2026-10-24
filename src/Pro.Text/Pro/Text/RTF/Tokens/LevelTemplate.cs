namespace Pro.Text.RTF.Tokens;

public class LevelTemplate : TokenBase
{
	internal const string MatchPattern = "leveltemplateid([0-9]+)";

	public override TokenType TokenType => TokenType.LevelTemplate;

	public int TemplateID { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		TemplateID = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"leveltemplateid{TemplateID}";
	}
}
