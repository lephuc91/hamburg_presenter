using System;

namespace Pro.Text.RTF.Tokens;

public class ColorComponent : TokenBase
{
	public enum ComponentType
	{
		Red,
		Green,
		Blue
	}

	internal const string MatchPattern = "(red|green|blue)([0-9]+)";

	public override TokenType TokenType => TokenType.ColorComponent;

	public ComponentType Component { get; set; }

	public byte Value { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		switch (value)
		{
		case "red":
			Component = ComponentType.Red;
			break;
		case "green":
			Component = ComponentType.Green;
			break;
		case "blue":
			Component = ComponentType.Blue;
			break;
		default:
			throw new NotSupportedException();
		}
		Value = byte.Parse(additionalValues[0]);
	}

	protected internal override string ToRawValue()
	{
		return $"{GetComponentValue()}{Value}";
	}

	private string GetComponentValue()
	{
		return Component switch
		{
			ComponentType.Red => "red", 
			ComponentType.Green => "green", 
			ComponentType.Blue => "blue", 
			_ => throw new NotSupportedException(), 
		};
	}
}
