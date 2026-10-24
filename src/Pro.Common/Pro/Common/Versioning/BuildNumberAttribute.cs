using System;

namespace Pro.Common.Versioning;

[AttributeUsage(AttributeTargets.Assembly)]
public class BuildNumberAttribute : Attribute
{
	public int Value { get; }

	public BuildNumberAttribute(int value)
	{
		Value = value;
	}
}
