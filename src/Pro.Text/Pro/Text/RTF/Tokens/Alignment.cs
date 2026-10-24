using System;

namespace Pro.Text.RTF.Tokens;

public class Alignment : TokenBase
{
	internal const string MatchPattern = "q(l|c|j|r)";

	public override TokenType TokenType => TokenType.Alignment;

	public ParagraphAlignment ParagraphAlignment { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		switch (value)
		{
		case "l":
			ParagraphAlignment = ParagraphAlignment.Left;
			break;
		case "c":
			ParagraphAlignment = ParagraphAlignment.Center;
			break;
		case "r":
			ParagraphAlignment = ParagraphAlignment.Right;
			break;
		case "j":
			ParagraphAlignment = ParagraphAlignment.Justified;
			break;
		default:
			throw new NotSupportedException();
		}
	}

	protected internal override string ToRawValue()
	{
		return $"q{GetAlignmentValue()}";
	}

	private string GetAlignmentValue()
	{
		return ParagraphAlignment switch
		{
			ParagraphAlignment.Left => "l", 
			ParagraphAlignment.Center => "c", 
			ParagraphAlignment.Right => "r", 
			ParagraphAlignment.Justified => "j", 
			_ => throw new NotSupportedException(), 
		};
	}
}
