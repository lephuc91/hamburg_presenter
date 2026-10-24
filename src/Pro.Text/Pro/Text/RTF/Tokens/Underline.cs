using System;

namespace Pro.Text.RTF.Tokens;

public class Underline : TokenBase
{
	internal const string MatchPattern = "ul(0|none|d|dash|dashd|dashdd|)";

	public override TokenType TokenType => TokenType.Underline;

	public BarType UnderlineType { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		switch (value)
		{
		case "0":
		case "none":
			UnderlineType = BarType.None;
			break;
		case "d":
			UnderlineType = BarType.Dot;
			break;
		case "dash":
			UnderlineType = BarType.Dash;
			break;
		case "dashd":
			UnderlineType = BarType.DotDash;
			break;
		case "dashdd":
			UnderlineType = BarType.DotDotDash;
			break;
		case "":
			UnderlineType = BarType.Solid;
			break;
		default:
			throw new NotSupportedException();
		}
	}

	protected internal override string ToRawValue()
	{
		return $"ul{GetUnderlineTypeValue()}";
	}

	private string GetUnderlineTypeValue()
	{
		return UnderlineType switch
		{
			BarType.None => "0", 
			BarType.Solid => string.Empty, 
			BarType.Dot => "d", 
			BarType.Dash => "dash", 
			BarType.DotDash => "dashd", 
			BarType.DotDotDash => "dashdd", 
			_ => throw new NotSupportedException(), 
		};
	}
}
