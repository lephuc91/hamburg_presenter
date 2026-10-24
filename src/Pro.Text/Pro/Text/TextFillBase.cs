using System;
using System.Diagnostics;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Properties;

namespace Pro.Text;

[DebuggerDisplay("{TextFillType}")]
public abstract class TextFillBase : IEquatable<TextFillBase>, ICloneable<TextFillBase>, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	public abstract TextFillType TextFillType { get; }

	public abstract System.Windows.Media.Color PrimaryColor { get; }

	public abstract bool IsTransparent { get; }

	public abstract bool IsMask { get; }

	public string ContainerId { get; protected set; } = string.Empty;

	public event Action<TextFillBase>? FillChanged;

	public abstract void SerializeToEntity(IEntityFactory entityFactory, IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes.Types.IFill> fill);

	public abstract void SerializeToEntity(IEntityFactory entityFactory, IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute> attribute);

	public abstract void DeserializeEntity(IGraphics.Types.IText.Types.IAttributes.Types.IFill attribute);

	public abstract void DeserializeEntity(IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute attribute);

	public abstract override int GetHashCode();

	protected abstract bool OnEquals(TextFillBase other);

	public override bool Equals(object? obj)
	{
		if (obj is TextFillBase other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(TextFillBase? other)
	{
		if ((object)other != null && TextFillType == other.TextFillType)
		{
			return OnEquals(other);
		}
		return false;
	}

	public abstract TextFillBase Clone();

	protected void OnFillChanged()
	{
		this.FillChanged?.Invoke(this);
	}

	public virtual void UpdateContainerId(string containerId)
	{
		ContainerId = containerId;
	}

	public static bool operator ==(TextFillBase? lhs, TextFillBase? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(TextFillBase? lhs, TextFillBase? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
