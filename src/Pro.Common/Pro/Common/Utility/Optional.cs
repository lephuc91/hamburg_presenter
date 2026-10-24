using System.Diagnostics.CodeAnalysis;

namespace Pro.Common.Utility;

public class Optional<T>
{
	private T? _value;

	public bool HasValue { get; private set; }

	[MemberNotNullWhen(true, "HasValue")]
	public T? Value
	{
		[MemberNotNullWhen(true, "HasValue")]
		get
		{
			return _value;
		}
		[MemberNotNullWhen(true, "HasValue")]
		set
		{
			_value = value;
			HasValue = true;
		}
	}
}
