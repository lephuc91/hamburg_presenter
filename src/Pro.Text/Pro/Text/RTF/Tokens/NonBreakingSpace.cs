using System;

namespace Pro.Text.RTF.Tokens;

public class NonBreakingSpace : TokenBase
{
	public const string SPACE = " ";

	internal const string MatchPattern = "(~)(.*)";

	public override TokenType TokenType => TokenType.NonBreakingSpace;

	public override bool IsText => true;

	protected internal override void ParseRawValue(string value, string[] additionalValues, out string unconsumedData)
	{
		unconsumedData = additionalValues[0];
	}

	protected internal override string ToRawValue()
	{
		throw new NotImplementedException();
	}
}
