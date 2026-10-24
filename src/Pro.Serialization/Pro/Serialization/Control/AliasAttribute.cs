using System;

namespace Pro.Serialization.Control;

public class AliasAttribute : ControlAttributeBase
{
	public string NameAlias { get; }

	public Type TypeAlias { get; }

	public bool DisplayName { get; }

	public AliasAttribute(string nameAlias, Type typeAlias, bool displayName = false)
	{
		NameAlias = nameAlias;
		TypeAlias = typeAlias;
		DisplayName = displayName;
	}
}
