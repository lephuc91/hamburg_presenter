using System.Collections.Generic;

namespace Pro.Loro;

public record TextDelta
{
	public record Retain(uint retain, Dictionary<string, LoroValue>? attributes) : TextDelta();

	public record Insert(string insert, Dictionary<string, LoroValue>? attributes) : TextDelta();

	public record Delete(uint delete) : TextDelta();
}
