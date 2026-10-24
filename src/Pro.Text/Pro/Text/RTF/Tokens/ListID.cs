namespace Pro.Text.RTF.Tokens;

public class ListID : TokenBase
{
	internal const string MatchPattern = "listid([0-9]+)";

	public override TokenType TokenType => TokenType.ListID;

	public int ID { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		ID = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"listid{ID}";
	}
}
