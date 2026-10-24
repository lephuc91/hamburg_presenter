using System;

namespace Pro.Text.RTF.Tokens;

public class LineSpacingMode : TokenBase
{
	public enum SpacingMode
	{
		Absolute,
		Multiple
	}

	internal const string MatchPattern = "slmult([0-9]+)";

	public override TokenType TokenType => TokenType.LineSpacingMode;

	public SpacingMode Mode { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		if (!(value == "0"))
		{
			if (!(value == "1"))
			{
				throw new NotSupportedException();
			}
			Mode = SpacingMode.Multiple;
		}
		else
		{
			Mode = SpacingMode.Absolute;
		}
	}

	protected internal override string ToRawValue()
	{
		return $"slmult{GetSpacingModeValue()}";
	}

	private string GetSpacingModeValue()
	{
		return Mode switch
		{
			SpacingMode.Absolute => "0", 
			SpacingMode.Multiple => "1", 
			_ => throw new NotSupportedException(), 
		};
	}
}
