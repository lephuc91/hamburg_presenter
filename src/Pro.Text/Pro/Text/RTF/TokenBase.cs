using System;

namespace Pro.Text.RTF;

public abstract class TokenBase : IToken
{
	public abstract TokenType TokenType { get; }

	public virtual bool IsText => false;

	protected internal virtual void ParseRawValue(string value, string[] additionalValues, out string unconsumedData)
	{
		unconsumedData = string.Empty;
		ParseRawValue(value, additionalValues);
	}

	protected virtual void ParseRawValue(string value, string[] additionalValues)
	{
		throw new NotSupportedException();
	}

	protected internal abstract string ToRawValue();
}
