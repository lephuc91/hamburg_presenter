using System;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions;

public class Identifier : NotifyPropertyChangedBase, ICloneable<Identifier>, IIdentifiable, IEquatable<Identifier>
{
	public static readonly Identifier Empty = new Identifier(Guid.Empty, string.Empty);

	private string _name = string.Empty;

	public Guid ID { get; }

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, OnDataModified);
		}
	}

	public event System.Action? DataModified;

	public Identifier(Guid id, string name)
	{
		ID = id;
		Name = name;
	}

	public Identifier(CollectionElementType collectionElement)
		: this(collectionElement.ParameterUuid.ToGuid(), collectionElement.ParameterName)
	{
	}

	public CollectionElementType Serialize()
	{
		return new CollectionElementType
		{
			ParameterUuid = ID.ToUUID(),
			ParameterName = (Name ?? string.Empty)
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public Identifier Clone()
	{
		return new Identifier(ID, Name);
	}

	public bool Equals(Identifier? other)
	{
		if ((object)other != null && ID == other.ID)
		{
			return Name == other.Name;
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Identifier other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ID.GetHashCode();
	}

	public static bool operator ==(Identifier lhs, Identifier rhs)
	{
		return lhs.NullableEquals<Identifier>(rhs);
	}

	public static bool operator !=(Identifier lhs, Identifier rhs)
	{
		return !lhs.NullableEquals<Identifier>(rhs);
	}
}
