namespace Pro.Text.RTF.Tokens;

public class ListTemplate : TokenBase
{
	internal const string MatchPattern = "listtemplateid([0-9]+)";

	public override TokenType TokenType => TokenType.ListTemplate;

	public int TemplateID { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		TemplateID = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"listtemplateid{TemplateID}";
	}
}
