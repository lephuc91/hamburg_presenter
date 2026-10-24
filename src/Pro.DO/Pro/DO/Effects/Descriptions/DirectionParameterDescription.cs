using System;
using Pro.Common.Operations;

namespace Pro.DO.Effects.Descriptions;

public class DirectionParameterDescription : ParameterDescriptionBase
{
	public override ParameterType ParameterType => ParameterType.Direction;

	public override Type BackingType { get; } = typeof(Direction);

	public Direction DefaultDirection { get; }

	public Direction AllowedDirections { get; }

	public DirectionParameterDescription(string name, string description, Direction defaultDirection, Direction allowedDirections)
		: base(name, description)
	{
		DefaultDirection = defaultDirection;
		AllowedDirections = allowedDirections;
	}

	internal override object GetDefaultValue()
	{
		return DefaultDirection;
	}

	internal override bool IsValueValid<T>(T value)
	{
		return AllowedDirections.HasFlag(value.Cast<Direction, T>());
	}
}
