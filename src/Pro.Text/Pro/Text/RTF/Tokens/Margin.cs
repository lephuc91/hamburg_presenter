using System;

namespace Pro.Text.RTF.Tokens;

public class Margin : TokenBase
{
	public enum MarginEdge
	{
		Left,
		Right,
		Top,
		Bottom
	}

	internal const string MatchPattern = "marg(l|r|t|b)(-?[0-9]+)";

	public override TokenType TokenType => TokenType.Margin;

	public MarginEdge Edge { get; set; }

	public double Value { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		switch (value)
		{
		case "l":
			Edge = MarginEdge.Left;
			break;
		case "r":
			Edge = MarginEdge.Right;
			break;
		case "t":
			Edge = MarginEdge.Top;
			break;
		case "b":
			Edge = MarginEdge.Bottom;
			break;
		default:
			throw new NotSupportedException();
		}
		Value = double.Parse(additionalValues[0]) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return $"marg{GetEdgeValue()}{(int)(Value * 20.0)}";
	}

	private string GetEdgeValue()
	{
		return Edge switch
		{
			MarginEdge.Left => "l", 
			MarginEdge.Right => "r", 
			MarginEdge.Top => "t", 
			MarginEdge.Bottom => "b", 
			_ => throw new NotSupportedException(), 
		};
	}
}
