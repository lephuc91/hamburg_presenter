using System.Collections.Generic;

namespace Pro.Loro;

public record LoroValue
{
	public record Null : LoroValue;

	public record Bool(bool value) : LoroValue();

	public record Double(double value) : LoroValue();

	public record I64(long value) : LoroValue();

	public record Binary(byte[] value) : LoroValue();

	public record String(string value) : LoroValue();

	public record List(List<LoroValue> value) : LoroValue();

	public record Map(Dictionary<string, LoroValue> value) : LoroValue();

	public record Container(ContainerId value) : LoroValue();
}
