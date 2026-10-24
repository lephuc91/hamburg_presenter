using System;
using System.Collections.Generic;
using System.Diagnostics;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Effects.Descriptions;

[DebuggerDisplay("{Name,nq}")]
public class EffectDescription : IEquatable<EffectDescription?>
{
	private int? _hashCode;

	public Guid ID { get; }

	public string Name { get; }

	public string? DisplayName { get; }

	public string? Description { get; }

	public string Category { get; }

	public ParameterDescriptionBase[] Parameters { get; }

	public EffectDescription(Effect protoEffect)
	{
		ID = (Guid.TryParse(protoEffect.RenderId, out var result) ? result : Guid.Empty);
		Name = protoEffect.Name ?? string.Empty;
		string name = protoEffect.Name;
		DisplayName = ((name != null && name.TryGetLocalizedName(out string localizedName)) ? localizedName : protoEffect.Name);
		Description = protoEffect.Name;
		Category = protoEffect.Category;
		Parameters = DeserializeParameters(protoEffect.Variables);
	}

	public EffectDescription(Guid id, string name, string displayName, string description, string category, ParameterDescriptionBase[] parameters)
	{
		ID = id;
		Name = name;
		DisplayName = displayName;
		Description = description;
		Category = category;
		Parameters = parameters;
	}

	private ParameterDescriptionBase[] DeserializeParameters(IEnumerable<Effect.Types.EffectVariable> protoVariables)
	{
		List<ParameterDescriptionBase> list = new List<ParameterDescriptionBase>();
		foreach (Effect.Types.EffectVariable protoVariable in protoVariables)
		{
			switch (protoVariable.TypeCase)
			{
			case Effect.Types.EffectVariable.TypeOneofCase.Color:
				list.Add(new ColorParameterDescription(protoVariable.Name, protoVariable.Description, protoVariable.Color.DefaultColor.ToColor()));
				break;
			case Effect.Types.EffectVariable.TypeOneofCase.Direction:
				list.Add(new DirectionParameterDescription(protoVariable.Name, protoVariable.Description, (Direction)protoVariable.Direction.DefaultDirection, (Direction)protoVariable.Direction.AvailableDirections));
				break;
			case Effect.Types.EffectVariable.TypeOneofCase.Double:
				list.Add(new DoubleParameterDescription(protoVariable.Name, protoVariable.Description, protoVariable.Double.Min, protoVariable.Double.Max, protoVariable.Double.DefaultValue));
				break;
			case Effect.Types.EffectVariable.TypeOneofCase.Float:
				list.Add(new FloatParameterDescription(protoVariable.Name, protoVariable.Description, protoVariable.Float.Min, protoVariable.Float.Max, protoVariable.Float.DefaultValue));
				break;
			case Effect.Types.EffectVariable.TypeOneofCase.Int:
				list.Add(new IntParameterDescription(protoVariable.Name, protoVariable.Description, protoVariable.Int.Min, protoVariable.Int.Max, protoVariable.Int.DefaultValue));
				break;
			default:
				throw new NotSupportedException("Unknown effect variable type");
			case Effect.Types.EffectVariable.TypeOneofCase.None:
				break;
			}
		}
		return list.ToArray();
	}

	public override bool Equals(object? obj)
	{
		if (obj is EffectDescription)
		{
			return Equals((EffectDescription)obj);
		}
		return false;
	}

	public bool Equals(EffectDescription? other)
	{
		Guid iD = ID;
		Guid? guid = other?.ID;
		if (guid.HasValue && iD == guid.GetValueOrDefault() && Name == other.Name && Description == other.Description)
		{
			return Category == other.Category;
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			_hashCode = GenerateHashCode();
		}
		return _hashCode.Value;
	}

	protected virtual int GenerateHashCode()
	{
		return HashCodeHelper.GenerateHashCode(ID, Name, Description, Category);
	}

	public static bool operator ==(EffectDescription lhs, EffectDescription rhs)
	{
		return lhs.NullableEquals<EffectDescription>(rhs);
	}

	public static bool operator !=(EffectDescription? lhs, EffectDescription? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
