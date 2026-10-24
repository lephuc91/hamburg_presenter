using System;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;

namespace Pro.Text.Fills;

public class MediaTextFill : TextFillBase
{
	public override TextFillType TextFillType => TextFillType.Media;

	public override System.Windows.Media.Color PrimaryColor => Colors.White;

	public override bool IsTransparent => false;

	public bool IsValid
	{
		get
		{
			if (Media != null)
			{
				return Media.IsValid;
			}
			return false;
		}
	}

	public override bool IsMask => true;

	public virtual ITextFillMedia? Media { get; }

	public event Action? ValidityChanged;

	public override void SerializeToEntity(IEntityFactory entityFactory, IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes.Types.IFill> fill)
	{
		IGraphics.Types.IText.Types.IAttributes.Types.IFill.IMediaFill mediaFill = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.IFill.IMediaFill>();
		Media?.SerializeToEntity(entityFactory, mediaFill.Value.Media.Value);
		fill.Set(mediaFill);
	}

	public override void SerializeToEntity(IEntityFactory entityFactory, IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute> attributeProperty)
	{
		IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IMediaFill mediaFill = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IMediaFill>();
		Media?.SerializeToEntity(entityFactory, mediaFill.Value.Media.Value);
		attributeProperty.Set(mediaFill);
	}

	public override void DeserializeEntity(IGraphics.Types.IText.Types.IAttributes.Types.IFill attribute)
	{
		if (!(attribute is IGraphics.Types.IText.Types.IAttributes.Types.IFill.IMediaFill mediaFill))
		{
			throw new InvalidOperationException($"Type of {attribute} not valid in {"DeserializeEntity"}");
		}
		Media?.DeserializeEntity(mediaFill.Value.Media.Value);
	}

	public override void DeserializeEntity(IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute attribute)
	{
		if (!(attribute is IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IMediaFill mediaFill))
		{
			throw new InvalidOperationException($"Type of {attribute} not valid in {"DeserializeEntity"}");
		}
		Media?.DeserializeEntity(mediaFill.Value.Media.Value);
	}

	public MediaTextFill()
		: this(null)
	{
	}

	public MediaTextFill(ITextFillMedia? media)
	{
		Media = media;
		if (Media == null)
		{
			return;
		}
		Media.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			string propertyName = e.PropertyName;
			if (!(propertyName == "IsValid"))
			{
				if (propertyName == "PreviewImage")
				{
					OnFillChanged();
				}
			}
			else
			{
				this.ValidityChanged?.Invoke();
				OnFillChanged();
			}
		};
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(TextFillType, Media);
	}

	protected override bool OnEquals(TextFillBase other)
	{
		if ((object)this == other)
		{
			return true;
		}
		if (!(other is MediaTextFill mediaTextFill))
		{
			return false;
		}
		if (Media == mediaTextFill.Media)
		{
			return true;
		}
		return Media?.Equals(mediaTextFill.Media) ?? false;
	}

	public override TextFillBase Clone()
	{
		return new MediaTextFill(Media?.Clone())
		{
			ContainerId = base.ContainerId
		};
	}

	public override void UpdateContainerId(string containerId)
	{
		base.UpdateContainerId(containerId);
		Media?.UpdateContainerId(containerId);
	}
}
