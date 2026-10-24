using System;
using System.Diagnostics;

namespace Pro.DO.Effects.Descriptions;

[DebuggerDisplay("{Name,nq}")]
public abstract class ParameterDescriptionBase
{
	public abstract ParameterType ParameterType { get; }

	public abstract Type BackingType { get; }

	public string Name { get; }

	public string Label { get; }

	public string Description { get; }

	protected ParameterDescriptionBase(string name, string description)
	{
		Name = name;
		Label = (name.TryGetLocalizedParameter(out string localizedName) ? localizedName : name);
		Description = description;
	}

	internal abstract object GetDefaultValue();

	internal abstract bool IsValueValid<T>(T value);
}
