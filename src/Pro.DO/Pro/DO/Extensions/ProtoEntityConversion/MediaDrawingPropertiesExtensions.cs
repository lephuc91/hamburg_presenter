using System.Linq;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class MediaDrawingPropertiesExtensions
{
	public static Media.Types.DrawingProperties ToProto(this IMedia.Types.IDrawingProperties value)
	{
		Media.Types.DrawingProperties drawingProperties = new Media.Types.DrawingProperties
		{
			ScaleBehavior = value.ScaleBehavior.Value.ToProto(),
			ScaleAlignment = value.ScaleAlignment.Value.ToProto(),
			FlippedHorizontally = value.FlippedHorizontally.Value,
			FlippedVertically = value.FlippedVertically.Value,
			NaturalSize = value.NaturalSize.Value.ToProto(),
			CustomImageRotation = value.CustomImageRotation.Value,
			CustomImageBounds = value.CustomImageBounds.Value.ToProto(),
			CustomImageAspectLocked = value.CustomImageAspectLocked.Value,
			AlphaInverted = value.AlphaInverted.Value,
			NativeRotation = value.NativeRotation.Value.ToProto(),
			CropEnable = value.CropEnable.Value,
			AlphaType = value.AlphaType.Value.ToProto(),
			IsBlurred = value.IsBlurred.Value
		};
		if (value.SelectedEffectPresetUuid.Value.HasValue)
		{
			drawingProperties.SelectedEffectPresetUuid = value.SelectedEffectPresetUuid.Value.Value.ToUUID();
		}
		drawingProperties.Effects.AddRange(value.Effects.Items.Select((IEffect e) => e.ToProtoEffect()));
		if (value.CropInsets.Value != null)
		{
			drawingProperties.CropInsets = value.CropInsets.Value.ToProto();
		}
		return drawingProperties;
	}

	public static IMedia.Types.IDrawingProperties ToEntity(this Media.Types.DrawingProperties source, IEntityFactory entityFactory)
	{
		IMedia.Types.IDrawingProperties drawingProperties = entityFactory.Create<IMedia.Types.IDrawingProperties>();
		drawingProperties.ScaleBehavior.Set(source.ScaleBehavior.ToEntity());
		drawingProperties.ScaleAlignment.Set(source.ScaleAlignment.ToEntity());
		drawingProperties.FlippedHorizontally.Set(source.FlippedHorizontally);
		drawingProperties.FlippedVertically.Set(source.FlippedVertically);
		drawingProperties.NaturalSize.Set(source.NaturalSize.ToEntity());
		drawingProperties.CustomImageRotation.Set(source.CustomImageRotation);
		drawingProperties.CustomImageBounds.Set(source.CustomImageBounds.ToEntity());
		drawingProperties.CustomImageAspectLocked.Set(source.CustomImageAspectLocked);
		drawingProperties.AlphaInverted.Set(source.AlphaInverted);
		drawingProperties.NativeRotation.Set(source.NativeRotation.ToEntity());
		drawingProperties.CropEnable.Set(source.CropEnable);
		drawingProperties.AlphaType.Set(source.AlphaType.ToEntity());
		drawingProperties.IsBlurred.Set(source.IsBlurred);
		drawingProperties.SelectedEffectPresetUuid.Set(source.SelectedEffectPresetUuid?.ToGuid());
		drawingProperties.Effects.Reset(source.Effects.Select((Effect e) => e.ToEntityEffect(entityFactory)));
		drawingProperties.CropInsets.Set(source.CropInsets?.ToEntity(entityFactory));
		return drawingProperties;
	}
}
